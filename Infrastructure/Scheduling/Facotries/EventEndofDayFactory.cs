using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation(Interface = typeof(IEventEndofDayFactory))]
    public class EventEndofDayFactory : IEventEndofDayFactory
    {
        public EventEndofDayListModel Create(Event theEvent, Host host, IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventTests, IEnumerable<Order> orders, IEnumerable<BasicBiometric> basicBiometrics, IEnumerable<OrderedPair<long, bool>> lipidStates, IEnumerable<OrderedPair<long, bool>> hbA1CStates,
            IEnumerable<CustomerResultStatusViewModel> customerResultStatuses, bool isHospitalPartnerAttached, IEnumerable<OrderedPair<long, DateTime>> hafDateSavePairs, string signOff, IEnumerable<OrderedPair<long, bool>> kynStates,
            bool isHospitalFacilitiesAttached, bool isKynIntegrationEnabled, bool isMedicareEnabled, IEnumerable<OrderedPair<long, DateTime>> orderdPairsMedicareSaved, CorporateAccount account, IEnumerable<OrderedPair<long, bool>> hypertensionStates,
            DateTime basicBiometricCutOfDate, IEnumerable<OrderedPair<long, bool>> cholesterolStates, IEnumerable<OrderedPair<long, bool>> awvLipidStates, IEnumerable<OrderedPair<long, bool>> diabetesStates, IEnumerable<OrderedPair<long, bool>> awvGlucoseStates,
            IEnumerable<OrderedPair<long, bool>> hPyloriStates, IEnumerable<OrderedPair<long, bool>> hemoglobinStates, IEnumerable<OrderedPair<long, bool>> qualityMeasuresState, IEnumerable<OrderedPair<long, bool>> phq9States,
            IEnumerable<OrderedPair<long, bool>> facAttestationStates, IEnumerable<OrderedPair<long, bool>> ifobtStates, IEnumerable<OrderedPair<long, bool>> hkynStates, IEnumerable<OrderedPair<long, bool>> myBioCheckAssessmentStates, bool IsShowGiftCertificateOnEod)
        {
            var model = new EventEndofDayListModel
            {
                EventId = theEvent.Id,
                Address = Mapper.Map<Address, AddressViewModel>(host.Address),
                HostName = host.OrganizationName,
                SignOffBy = signOff,
                SignOffDate = theEvent.SignOffDate,
                IsSignOff = theEvent.IsSignOff,
                IsHospitalPartnerAttached = isHospitalPartnerAttached,
                IsHospitalFacilityAttached = isHospitalFacilitiesAttached,
                IsKynIntegrationEnabled = isKynIntegrationEnabled,
                IsMspFormEnabled = isMedicareEnabled,
                EventDate = theEvent.EventDate,
                IsShowGiftCertificateOnEod = IsShowGiftCertificateOnEod,
                IsHealthPlanEvent = account != null && account.IsHealthPlan,
            };

            var customerEndOfDayModels = new List<EventEndofDayViewModel>();

            foreach (EventCustomer eventCustomer in eventCustomers)
            {
                var customer = customers.SingleOrDefault(c => c.CustomerId == eventCustomer.CustomerId);
                var appointment = appointments.SingleOrDefault(ap => ap.Id == eventCustomer.AppointmentId);
                var order = orders.SingleOrDefault(od => od.CustomerId == customer.CustomerId);
                var eventPackageId =
                    order.OrderDetails.Where(
                        od =>
                            od.DetailType == OrderItemType.EventPackageItem &&
                            od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess)
                        .Select(od => od.OrderItem.ItemId)
                        .SingleOrDefault();
                var eventPackage = eventPackages.SingleOrDefault(ep => ep.Id == eventPackageId);
                var eventTestIds =
                    order.OrderDetails.Where(
                        od =>
                            od.DetailType == OrderItemType.EventTestItem &&
                            od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess)
                        .Select(od => od.OrderItem.ItemId)
                        .ToArray();
                var orderEventTests = eventTests.Where(et => eventTestIds.Contains(et.Id)).ToArray();
                if (eventPackage != null) orderEventTests = orderEventTests.Concat(eventPackage.Tests).ToArray();
                var basicBiometric = basicBiometrics.SingleOrDefault(bb => bb.Id == eventCustomer.Id);
                var allConductedByMarked = false;

                var allTestNotRecordable = false;

                if (customerResultStatuses != null)
                {
                    var resultStatus = customerResultStatuses.SingleOrDefault(crs => crs.CustomerId == customer.CustomerId);
                    if (resultStatus != null)
                    {
                        var tests = orderEventTests.Where(t => t.Test.IsRecordable).ToArray();
                        if (resultStatus.TestResults.IsNullOrEmpty() && tests.IsNullOrEmpty())
                            allConductedByMarked = true;
                        else if (!resultStatus.TestResults.IsNullOrEmpty() && !tests.IsNullOrEmpty() && resultStatus.TestResults.Count() == tests.Count())
                        {
                            var countwithNoConductedBy = resultStatus.TestResults.Where(tr => string.IsNullOrEmpty(tr.ConductedBy)).Count();
                            if (countwithNoConductedBy < 1) allConductedByMarked = true;
                        }
                    }
                }
                else
                {
                    var tests = orderEventTests.Where(t => t.Test.IsRecordable).ToArray();
                    if (tests.IsNullOrEmpty())
                        allTestNotRecordable = true;
                }

                var mspFormStatus = EndofDayStatus.NotApplicable;
                var insuranceReleaseStatus = EndofDayStatus.NotApplicable;

                var isMedicareTestPurchased = orderEventTests != null && orderEventTests.Any(x => TestGroup.AwvTestIds.Contains(x.TestId));

                if (isMedicareTestPurchased && isMedicareEnabled)
                {
                    mspFormStatus = EndofDayStatus.Missing;

                    var isFilled = orderdPairsMedicareSaved.Any(x => x.FirstValue == eventCustomer.Id);

                    if (isFilled)
                    {
                        mspFormStatus = EndofDayStatus.Complete;
                    }

                    insuranceReleaseStatus = (((int)eventCustomer.InsuranceReleaseStatus > 0 &&
                                               eventCustomer.InsuranceReleaseStatus != RegulatoryState.Unknown)
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing);
                }

                var lipidState = lipidStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;
                if (orderEventTests.Count(oe => TestType.Lipid == (TestType)oe.TestId) < 1)
                {
                    lipidState = EndofDayStatus.NotApplicable;
                }

                var cholesterolState = cholesterolStates.Where(s => s.FirstValue == eventCustomer.Id)
                        .Select(s => s.SecondValue)
                        .SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;
                if (orderEventTests.Count(oe => TestType.Cholesterol == (TestType)oe.TestId) < 1)
                {
                    cholesterolState = EndofDayStatus.NotApplicable;
                }

                var awvLipidState = awvLipidStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.AwvLipid == (TestType)oe.TestId) < 1)
                {
                    awvLipidState = EndofDayStatus.NotApplicable;
                }

                var diabetesState = diabetesStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.Diabetes == (TestType)oe.TestId) < 1)
                {
                    diabetesState = EndofDayStatus.NotApplicable;
                }

                var awvGlucoseState = awvGlucoseStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.AwvGlucose == (TestType)oe.TestId) < 1)
                {
                    awvGlucoseState = EndofDayStatus.NotApplicable;
                }


                var cholesterolStatus = EndofDayStatus.NotApplicable;
                var glucoseStatus = EndofDayStatus.NotApplicable;

                if (lipidState == EndofDayStatus.Complete || lipidState == EndofDayStatus.Missing)
                {
                    cholesterolStatus = lipidState;
                    glucoseStatus = lipidState;
                }
                else
                {
                    if (cholesterolState == EndofDayStatus.Missing || awvLipidState == EndofDayStatus.Missing)
                        cholesterolStatus = EndofDayStatus.Missing;
                    else if (cholesterolState == EndofDayStatus.Complete || awvLipidState == EndofDayStatus.Complete)
                        cholesterolStatus = EndofDayStatus.Complete;

                    if (diabetesState == EndofDayStatus.Missing || awvGlucoseState == EndofDayStatus.Missing)
                        glucoseStatus = EndofDayStatus.Missing;
                    else if (diabetesState == EndofDayStatus.Complete || awvGlucoseState == EndofDayStatus.Complete)
                        glucoseStatus = EndofDayStatus.Complete;
                }


                var hbA1CState = hbA1CStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;
                if (orderEventTests.Count(oe => TestType.A1C == (TestType)oe.TestId) < 1)
                {
                    hbA1CState = EndofDayStatus.NotApplicable;
                }

                var hPyloriState = hPyloriStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.HPylori == (TestType)oe.TestId) < 1)
                {
                    hPyloriState = EndofDayStatus.NotApplicable;
                }

                var hemoglobinState = hemoglobinStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.Hemoglobin == (TestType)oe.TestId) < 1)
                {
                    hemoglobinState = EndofDayStatus.NotApplicable;
                }

                var hasKyn = true;


                var kynState = EndofDayStatus.NotApplicable;
                var hafState = EndofDayStatus.NotApplicable;
                if (account == null || account.CaptureHaf)
                {
                    kynState = kynStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing;

                    if (orderEventTests.Count(oe => TestType.Kyn == (TestType)oe.TestId) < 1)
                    {
                        hasKyn = false;
                        kynState = EndofDayStatus.NotApplicable;
                    }
                    else if (!isKynIntegrationEnabled)
                    {
                        kynState = EndofDayStatus.NotApplicable;
                    }

                    var hafSaved = hafDateSavePairs.SingleOrDefault(hf => hf.FirstValue == eventCustomer.Id);
                    hafState = hafSaved != null
                        ? ((hafSaved.SecondValue.Date >= theEvent.EventDate.Date)
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing)
                        : EndofDayStatus.Missing;
                }
                else
                {
                    if (orderEventTests.Count(oe => TestType.Kyn == (TestType)oe.TestId) < 1)
                    {
                        hasKyn = false;
                    }
                }

                var hasHKyn = true;


                var HkynState = EndofDayStatus.NotApplicable;
                hafState = EndofDayStatus.NotApplicable;
                if (account == null || account.CaptureHaf)
                {
                    HkynState = hkynStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing;

                    if (orderEventTests.Count(oe => TestType.HKYN == (TestType)oe.TestId) < 1)
                    {
                        hasHKyn = false;
                        HkynState = EndofDayStatus.NotApplicable;
                    }
                    else if (!isKynIntegrationEnabled)
                    {
                        HkynState = EndofDayStatus.NotApplicable;
                    }

                    var hafSaved = hafDateSavePairs.SingleOrDefault(hf => hf.FirstValue == eventCustomer.Id);
                    hafState = hafSaved != null
                        ? ((hafSaved.SecondValue.Date >= theEvent.EventDate.Date)
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing)
                        : EndofDayStatus.Missing;
                }
                else
                {
                    if (orderEventTests.Count(oe => TestType.HKYN == (TestType)oe.TestId) < 1)
                    {
                        hasHKyn = false;
                    }
                }


                var signedPartnerRelease = EndofDayStatus.NotApplicable;
                var hospitalFacilityStatus = EndofDayStatus.NotApplicable;
                if (isHospitalPartnerAttached)
                {
                    signedPartnerRelease = (((int)eventCustomer.PartnerRelease > 0 && eventCustomer.PartnerRelease != RegulatoryState.Unknown)
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing);

                    if (isHospitalFacilitiesAttached)
                    {
                        hospitalFacilityStatus = eventCustomer.HospitalFacilityId.HasValue
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing;

                        if ((int)eventCustomer.PartnerRelease > 0 && eventCustomer.PartnerRelease != RegulatoryState.Signed && !eventCustomer.HospitalFacilityId.HasValue)
                        {
                            hospitalFacilityStatus = EndofDayStatus.NotApplicable;
                        }
                    }
                }

                EndofDayStatus bloodPressureStatus;

                if (theEvent.EventDate >= basicBiometricCutOfDate)
                {
                    bloodPressureStatus = hypertensionStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing;

                    if (orderEventTests.Count(oe => TestType.Hypertension == (TestType)oe.TestId) < 1)
                    {
                        bloodPressureStatus = EndofDayStatus.NotApplicable;
                    }
                }
                else
                {
                    bloodPressureStatus = (basicBiometric != null && basicBiometric.SystolicPressure.HasValue && basicBiometric.DiastolicPressure.HasValue)
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;
                }

                var isBioAssesmentPurchased = orderEventTests.Any(oe => oe.TestId == (long)TestType.MyBioCheckAssessment && oe.Test.IsRecordable);
                var myBioAssessmentStatus = EndofDayStatus.NotApplicable;

                if (isBioAssesmentPurchased)
                {
                    myBioAssessmentStatus = (myBioCheckAssessmentStates.Where(mbcas => mbcas.FirstValue == eventCustomer.Id)
                                            .Select(s => s.SecondValue).SingleOrDefault())
                                            ? EndofDayStatus.Complete
                                            : EndofDayStatus.Missing;
                }

                var isCustomerInfoCompleted = account != null && account.IsHealthPlan ? true : (customer.Height != null && customer.Height.TotalInches > 0 && customer.Weight != null && customer.Weight.Pounds > 0);

                if (hasKyn && isCustomerInfoCompleted)
                {
                    isCustomerInfoCompleted = ((int)customer.Race > 0 && customer.DateOfBirth.HasValue && ((int)customer.Gender) > 0);
                }

                if (hasHKyn && isCustomerInfoCompleted)
                {
                    isCustomerInfoCompleted = ((int)customer.Race > 0 && customer.DateOfBirth.HasValue && ((int)customer.Gender) > 0);
                }

                if (isBioAssesmentPurchased && isCustomerInfoCompleted)
                {
                    isCustomerInfoCompleted = ((int)customer.Race > 0 && customer.DateOfBirth.HasValue && ((int)customer.Gender) > 0 && customer.Gender != Gender.Unspecified);
                }

                var qualityMeasuresStatus = qualityMeasuresState.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                                    ? EndofDayStatus.Complete
                                    : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.QualityMeasures == (TestType)oe.TestId) < 1)
                {
                    qualityMeasuresStatus = EndofDayStatus.NotApplicable;
                }

                var phq9Status = phq9States.Where(s => s.FirstValue == eventCustomer.Id)
                                .Select(s => s.SecondValue)
                                .SingleOrDefault()
                                ? EndofDayStatus.Complete
                                : EndofDayStatus.Missing;

                if (orderEventTests.Count(oe => TestType.PHQ9 == (TestType)oe.TestId) < 1)
                {
                    phq9Status = EndofDayStatus.NotApplicable;
                }

                var facAttestationStatus = EndoOfDayStatus(eventCustomer.Id, (long)TestType.FocAttestation, orderEventTests, facAttestationStates);

                var ifobtStatus = EndoOfDayStatus(eventCustomer.Id, (long)TestType.IFOBT, orderEventTests, ifobtStates);

                var giftcardStatus = (!eventCustomer.IsGiftCertificateDelivered.HasValue)
                    ? EndofDayStatus.Missing
                    : (eventCustomer.IsGiftCertificateDelivered.Value == true ? (!string.IsNullOrEmpty(eventCustomer.GiftCode)
                    ? EndofDayStatus.Complete : EndofDayStatus.Missing)
                        : ((eventCustomer.GcNotGivenReasonId.HasValue && string.IsNullOrEmpty(eventCustomer.GiftCode))
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing));

                var endOfDayCustomer = new EventEndofDayViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.NameAsString,
                    CustomerInfo = isCustomerInfoCompleted ? EndofDayStatus.Complete : EndofDayStatus.Missing,
                    BloodPressure = bloodPressureStatus,
                    CheckInTime = appointment.CheckInTime.HasValue ? EndofDayStatus.Complete : EndofDayStatus.Missing,
                    CheckOutTime = appointment.CheckOutTime.HasValue ? EndofDayStatus.Complete : EndofDayStatus.Missing,
                    IsPaid = order.DiscountedTotal <= order.TotalAmountPaid ? EndofDayStatus.Complete : EndofDayStatus.Missing,
                    SignedHipaa = eventCustomer.HIPAAStatus == RegulatoryState.Signed ? EndofDayStatus.Complete : EndofDayStatus.Missing,
                    SignedPartnerRelease = signedPartnerRelease,
                    TestConductedBy = allTestNotRecordable ? EndofDayStatus.NotApplicable : (allConductedByMarked ? EndofDayStatus.Complete : EndofDayStatus.Missing),
                    HospitalFacilityStatus = hospitalFacilityStatus,
                    CholesterolStatus = cholesterolStatus,
                    GlucoseStatus = glucoseStatus,
                    HbA1C = hbA1CState,
                    HPyloriStatus = hPyloriState,
                    HealthAssesmentForm = hafState,
                    Kyn = kynState,
                    HKyn = HkynState,
                    IsHkynPurchased = !hasKyn && hasHKyn,
                    IsKynPurchased = hasKyn,
                    MspFormFilled = mspFormStatus,
                    SignedInsuranceRelease = insuranceReleaseStatus,
                    HemoglobinStatus = hemoglobinState,
                    Phq9Status = phq9Status,
                    QualityMeasuresStatus = qualityMeasuresStatus,
                    FocAttestation = facAttestationStatus,
                    Ifobt = ifobtStatus,
                    MybioStatus = myBioAssessmentStatus,
                    GiftCardStatus = (IsShowGiftCertificateOnEod) ? giftcardStatus : EndofDayStatus.Complete,
                    EventDate = theEvent.EventDate
                };

                customerEndOfDayModels.Add(endOfDayCustomer);
            }

            model.Customers = customerEndOfDayModels;
            return model;
        }

        private EndofDayStatus EndoOfDayStatus(long eventCustomerId, long testId, IEnumerable<EventTest> orderEventTests, IEnumerable<OrderedPair<long, bool>> resultStates)
        {
            var resultStatus = resultStates.Where(s => s.FirstValue == eventCustomerId).Select(s => s.SecondValue).SingleOrDefault() ? EndofDayStatus.Complete : EndofDayStatus.Missing;

            if (!orderEventTests.Any(oe => oe.TestId == testId && oe.Test.IsRecordable))
            {
                resultStatus = EndofDayStatus.NotApplicable;
            }

            return resultStatus;
        }

        public EventEndofDayListModel CreateForMyBioCheck(Event theEvent, IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventTests, IEnumerable<Order> orders, IEnumerable<BasicBiometric> basicBiometrics,
            IEnumerable<CustomerResultStatusViewModel> customerResultStatuses, IEnumerable<OrderedPair<long, bool>> hypertensionStates,
            DateTime basicBiometricCutOfDate,
            IEnumerable<OrderedPair<long, bool>> myBioCheckAssessmentStates, CorporateAccount account)
        {
            var model = new EventEndofDayListModel
            {
                EventId = theEvent.Id,

                SignOffDate = theEvent.SignOffDate,
                IsSignOff = theEvent.IsSignOff,
                EventDate = theEvent.EventDate,
                IsHealthPlanEvent = account != null && account.IsHealthPlan,
            };

            var customerEndOfDayModels = new List<EventEndofDayViewModel>();

            foreach (EventCustomer eventCustomer in eventCustomers)
            {
                var customer = customers.SingleOrDefault(c => c.CustomerId == eventCustomer.CustomerId);

                var order = orders.SingleOrDefault(od => od.CustomerId == customer.CustomerId);
                var eventPackageId =
                    order.OrderDetails.Where(od => od.DetailType == OrderItemType.EventPackageItem && od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess)
                        .Select(od => od.OrderItem.ItemId)
                        .SingleOrDefault();
                var eventPackage = eventPackages.SingleOrDefault(ep => ep.Id == eventPackageId);
                var eventTestIds = order.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem && od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess)
                        .Select(od => od.OrderItem.ItemId).ToArray();

                var orderEventTests = eventTests.Where(et => eventTestIds.Contains(et.Id)).ToArray();
                if (eventPackage != null) orderEventTests = orderEventTests.Concat(eventPackage.Tests).ToArray();
                var basicBiometric = basicBiometrics.SingleOrDefault(bb => bb.Id == eventCustomer.Id);

                var allConductedByMarked = false;

                var allTestNotRecordable = false;

                if (customerResultStatuses != null)
                {
                    var resultStatus = customerResultStatuses.SingleOrDefault(crs => crs.CustomerId == customer.CustomerId);
                    if (resultStatus != null)
                    {
                        var tests = orderEventTests.Where(t => t.Test.IsRecordable).ToArray();
                        if (resultStatus.TestResults.IsNullOrEmpty() && tests.IsNullOrEmpty())
                            allConductedByMarked = true;
                        else if (!resultStatus.TestResults.IsNullOrEmpty() && !tests.IsNullOrEmpty() && resultStatus.TestResults.Count() == tests.Count())
                        {
                            var countwithNoConductedBy = resultStatus.TestResults.Where(tr => string.IsNullOrEmpty(tr.ConductedBy)).Count();
                            if (countwithNoConductedBy < 1) allConductedByMarked = true;
                        }
                    }
                }
                else
                {
                    var tests = orderEventTests.Where(t => t.Test.IsRecordable).ToArray();
                    if (tests.IsNullOrEmpty())
                        allTestNotRecordable = true;
                }


                EndofDayStatus bloodPressureStatus;

                if (theEvent.EventDate >= basicBiometricCutOfDate)
                {
                    bloodPressureStatus = hypertensionStates.Where(s => s.FirstValue == eventCustomer.Id).Select(s => s.SecondValue).SingleOrDefault()
                            ? EndofDayStatus.Complete
                            : EndofDayStatus.Missing;

                    if (orderEventTests.Count(oe => TestType.Hypertension == (TestType)oe.TestId) < 1)
                    {
                        bloodPressureStatus = EndofDayStatus.NotApplicable;
                    }
                }
                else
                {
                    bloodPressureStatus = (basicBiometric != null && basicBiometric.SystolicPressure.HasValue && basicBiometric.DiastolicPressure.HasValue)
                        ? EndofDayStatus.Complete
                        : EndofDayStatus.Missing;
                }

                var isCustomerInfoCompleted = account != null && account.IsHealthPlan ? true : (customer.Height != null && customer.Height.TotalInches > 0 && customer.Weight != null && customer.Weight.Pounds > 0);

                var myBioAssessmentStatus = EndofDayStatus.NotApplicable;

                var isBioAssesmentPurchased = orderEventTests.Any(oe => oe.TestId == (long)TestType.MyBioCheckAssessment && oe.Test.IsRecordable);

                if (isBioAssesmentPurchased)
                {
                    myBioAssessmentStatus = (myBioCheckAssessmentStates.Where(mbcas => mbcas.FirstValue == eventCustomer.Id)
                                            .Select(s => s.SecondValue).SingleOrDefault())
                                            ? EndofDayStatus.Complete
                                            : EndofDayStatus.Missing;
                }

                if (isBioAssesmentPurchased && isCustomerInfoCompleted)
                {
                    isCustomerInfoCompleted = ((int)customer.Race > 0 && customer.DateOfBirth.HasValue && ((int)customer.Gender) > 0 && customer.Gender != Gender.Unspecified);
                }

                var endOfDayCustomer = new EventEndofDayViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerInfo = isCustomerInfoCompleted ? EndofDayStatus.Complete : EndofDayStatus.Missing,
                    BloodPressure = bloodPressureStatus,
                    TestConductedBy = allTestNotRecordable ? EndofDayStatus.NotApplicable : (allConductedByMarked ? EndofDayStatus.Complete : EndofDayStatus.Missing),
                    MybioStatus = myBioAssessmentStatus,
                    EventDate = theEvent.EventDate
                };

                customerEndOfDayModels.Add(endOfDayCustomer);
            }

            model.Customers = customerEndOfDayModels;
            return model;
        }


    }
}