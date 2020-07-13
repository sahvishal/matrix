using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Product = Falcon.App.Core.Enum.Product;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventCustomerListModelFactory : IEventCustomerListModelFactory
    {
        private readonly ICustomerUpsellModelFactory _customerUpsellModelFactory;
        private readonly IRoleRepository _roleRepository;

        public EventCustomerListModelFactory(ICustomerUpsellModelFactory customerUpsellModelFactory, IRoleRepository roleRepository)
        {
            _customerUpsellModelFactory = customerUpsellModelFactory;
            _roleRepository = roleRepository;
        }

        public EventCustomerListModel Create(EventCustomerListModel model, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<CustomerCallNotes> customerCallNotes,
            IEnumerable<AssignedPhysicianViewModel> physicians, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<SourceCode> sourceCodes,
            IEnumerable<long> authorizedEventCustomerIds, IEnumerable<long> undeliveredShippingCustomerIds, IEnumerable<long> filledHealthAssesmentForms, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventtests, IEnumerable<ElectronicProduct> products, EventCustomerListModelFilter filter, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<RefundRequest> refundRequests,
            IEnumerable<ShippingDetail> cdShippingDetails, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<OrderedPair<long, DateTime>> answeredMedicareQuestionsOrderdPair, CorporateAccount corporateAccount,
            IEnumerable<OrderedPair<long, string>> preApprovedTests, IEnumerable<CustomerCallNotes> patientLeftNotes, IEnumerable<OrderedPair<long, long>> eawvTestNotPerformed)
        {
            model.AvailableProductsCount = products != null ? products.Count() : 0;

            model.CanceledCustomers = CreateCancelledEventCustomerList(eventCustomers, customers, customerCallNotes,
                                                                       orders);

            if (filter.CustomerListFilterOption > 0 && (customers == null || !customers.Any()))
                return model;

            IEnumerable<EventCustomer> eventCustomerswithFilterApplied = eventCustomers;
            IEnumerable<EventAppointmentBasicInfoModel> eventAppointmentswithFilterApplied = eventAppointments;

            if (filter.CustomerListFilterOption > 0)
            {
                var customerIds = GetCustomerIdsforFilterOption(orders, eventCustomers, eventAppointments, (EventCustomerListFilterOption)filter.CustomerListFilterOption, orgRoleUsers);
                eventCustomerswithFilterApplied = eventCustomers.Where(ec => customerIds.Contains(ec.CustomerId)).ToArray();

                var filteredAppointmentIds = eventCustomerswithFilterApplied.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToArray();
                eventAppointmentswithFilterApplied = eventAppointments.Where(ea => filteredAppointmentIds.Contains(ea.AppointmentId) && ea.AppointmentStatus == AppointmentStatus.Booked).ToArray();

                if (!eventCustomerswithFilterApplied.Any())
                    return model;
            }
            else if (filter.AppointmentSlotViewOption > 0)
            {
                eventAppointmentswithFilterApplied = GetEventAppointmentsforSlotOption(eventAppointments, (EventSlotListViewOption)filter.AppointmentSlotViewOption);

                if (eventAppointmentswithFilterApplied == null || !eventAppointmentswithFilterApplied.Any()) return model;
            }

            var distModel = new List<EventAppointmentSlotDistributionViewModel>();

            foreach (var appointment in eventAppointmentswithFilterApplied)
            {
                var eventAppointmentDistModel = new EventAppointmentSlotDistributionViewModel();

                var appointmentViewModel = Create(appointment);
                eventAppointmentDistModel.Appointment = appointmentViewModel;

                var eventCustomer = eventCustomerswithFilterApplied != null && eventCustomerswithFilterApplied.Any()
                    ? eventCustomerswithFilterApplied.SingleOrDefault(ec => ec.AppointmentId != null && ec.AppointmentId == appointment.AppointmentId
                        && appointment.AppointmentStatus == AppointmentStatus.Booked) : null;

                if (eventCustomer == null) { distModel.Add(eventAppointmentDistModel); continue; }

                var customer = customers.Single(c => eventCustomer.CustomerId == c.CustomerId);
                var eventCustomerResult = eventCustomerResults == null
                                              ? null
                                              : eventCustomerResults.SingleOrDefault(ecr => ecr.Id == eventCustomer.Id);

                var order = orders.Single(o => o.CustomerId == customer.CustomerId);

                var callNotes = customerCallNotes != null
                    ? customerCallNotes.Where(c => c.CustomerId == customer.CustomerId).ToArray() : null;

                var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId).SingleOrDefault();

                var eventPackage = eventPackages.SingleOrDefault(ep => eventpackageId == ep.Id);

                var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();

                var eventTestsonOrder = eventtests.Where(et => eventTestIds.Contains(et.Id)).ToArray();

                var product = products != null ? products.SingleOrDefault(p => p.Id == order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.ProductItem)
                                                                                           .Select(od => od.OrderItem.ItemId).FirstOrDefault()) : null;

                var shippingDetailIds = order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId)).ToArray();

                IEnumerable<ShippingDetail> customerCdshippingDetails = null;
                if (!cdShippingDetails.IsNullOrEmpty())
                    customerCdshippingDetails = cdShippingDetails.Where(sd => shippingDetailIds.Contains(sd.Id)).ToArray();

                var sourceCodeId =
                    order.OrderDetails.Where(
                        od =>
                        od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess &&
                        od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive).Select(
                            od => od.SourceCodeOrderDetail.SourceCodeId).SingleOrDefault();

                var sourceCode = sourceCodeId > 0
                                     ? sourceCodes.SingleOrDefault(sc => sc.Id == sourceCodeId)
                                     : null;

                var assignedPhysician = physicians.SingleOrDefault(p => p.CustomerId == eventCustomer.CustomerId);

                var isCancelProductRequestPending = refundRequests.Where(rr => rr.OrderId == order.Id && rr.RefundRequestType == RefundRequestType.CDRemoval && rr.RequestStatus == (long)RequestStatus.Pending).Any();
                var isCancelShippingRequestPending = refundRequests.Where(rr => rr.OrderId == order.Id && rr.RefundRequestType == RefundRequestType.CancelShipping && rr.RequestStatus == (long)RequestStatus.Pending).Any();
                bool showAwvPcpConsentForm = false;

                bool isFlushotTestAttachedWithEvent = eventtests.Any(x => TestGroup.FluShotTestIds.Contains(x.TestId));

                if (model.CapturePcpStatus && primaryCarePhysicians != null && primaryCarePhysicians.Any())
                {
                    showAwvPcpConsentForm = primaryCarePhysicians.Any(x => x.CustomerId == customer.CustomerId);
                }

                var isMedicareQuestionisfilled = answeredMedicareQuestionsOrderdPair != null && answeredMedicareQuestionsOrderdPair.Any(x => x.FirstValue == eventCustomer.Id);

                var preApprovedTest = preApprovedTests.Where(x => x.FirstValue == customer.CustomerId).Select(x => x.SecondValue);

                var notes = string.Empty;
                if (eventCustomer.LeftWithoutScreeningReasonId.HasValue && eventCustomer.LeftWithoutScreeningNotesId.HasValue)
                {
                    var patientLeftNote = patientLeftNotes.SingleOrDefault(x => x.Id == eventCustomer.LeftWithoutScreeningNotesId.Value);
                    notes = patientLeftNote.Notes;
                }

                long? eawvTestNotPerformedReason = null;
                if (!eawvTestNotPerformed.IsNullOrEmpty())
                {
                    var eawvTestStatus = eawvTestNotPerformed.FirstOrDefault(x => x.FirstValue == eventCustomer.Id);
                    if (eawvTestStatus != null)
                        eawvTestNotPerformedReason = eawvTestStatus.SecondValue;
                }
                var customerViewModel = Create(eventCustomer, customer, order, eventCustomerResult, callNotes, eventPackage, eventTestsonOrder, sourceCode, product, assignedPhysician,
                    (authorizedEventCustomerIds != null && authorizedEventCustomerIds.Contains(eventCustomer.Id)), (undeliveredShippingCustomerIds == null ? false : undeliveredShippingCustomerIds.Contains(customer.CustomerId)),
                    (filledHealthAssesmentForms != null && filledHealthAssesmentForms.Contains(customer.CustomerId)), isCancelProductRequestPending, isCancelShippingRequestPending, customerCdshippingDetails, showAwvPcpConsentForm,
                    isMedicareQuestionisfilled, corporateAccount, isFlushotTestAttachedWithEvent, preApprovedTest, notes, eawvTestNotPerformedReason);

                eventAppointmentDistModel.Customer = customerViewModel;

                distModel.Add(eventAppointmentDistModel);
            }

            model.EventAppointmentSlotDistributions = distModel;

            return model;
        }

        private IEnumerable<long> GetCustomerIdsforFilterOption(IEnumerable<Order> orders, IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments, EventCustomerListFilterOption option, IEnumerable<OrganizationRoleUser> orgRoleUsers)
        {
            var validCustomerIds =
                eventCustomers.Where(ec => !ec.NoShow && ec.AppointmentId.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue).Select(ec => ec.CustomerId).ToArray();

            var customerIdsWithNoShow =
                eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.CustomerId).ToArray();

            var customersLeftWithoutScreening = eventCustomers.Where(ec => ec.LeftWithoutScreeningReasonId.HasValue).Select(ec => ec.CustomerId).ToArray();

            switch (option)
            {
                case EventCustomerListFilterOption.All:
                    return eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

                case EventCustomerListFilterOption.Attended:
                    return eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow)
                        .Join(eventAppointments, ec => ec.AppointmentId.Value, ea => ea.AppointmentId, (ec, ea) => new { Appointment = ea, EventCustomer = ec })
                        .Where(e => e.Appointment.CheckInTime != null || e.Appointment.CheckOutTime != null)
                        .Select(e => e.EventCustomer.CustomerId).Distinct().ToArray();

                case EventCustomerListFilterOption.NoShow:
                    return eventCustomers.Where(ec => ec.NoShow).Select(ec => ec.CustomerId).Distinct().ToArray();

                case EventCustomerListFilterOption.LeftWithoutScreening:
                    return eventCustomers.Where(ec => ec.LeftWithoutScreeningReasonId.HasValue).Select(ec => ec.CustomerId).Distinct().ToArray();

                case EventCustomerListFilterOption.Paid:
                    return orders.Where(o => (o.TotalAmountPaid == o.DiscountedTotal && o.DiscountedTotal > 0) && customerIdsWithNoShow.Contains(o.CustomerId))
                        .Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.Unpaid:
                    return orders.Where(o => (o.TotalAmountPaid < o.DiscountedTotal && o.DiscountedTotal > 0) && customerIdsWithNoShow.Contains(o.CustomerId))
                        .Select(o => o.CustomerId).ToArray();

                // Include No Shows
                case EventCustomerListFilterOption.PaidviaCard:
                    return orders.Where(o =>
                                        o.PaymentsApplied != null && o.PaymentsApplied.Count() > 0 && customerIdsWithNoShow.Contains(o.CustomerId) &&
                                        o.PaymentsApplied.Where(p => p.PaymentType.PersistenceLayerId == PaymentType.CreditCard.PersistenceLayerId).Count() > 0
                        ).Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.PaidviaCash:
                    return orders.Where(o =>
                                        o.PaymentsApplied != null && o.PaymentsApplied.Count() > 0 && customerIdsWithNoShow.Contains(o.CustomerId) &&
                                        o.PaymentsApplied.Where(p => p.PaymentType.PersistenceLayerId == PaymentType.Cash.PersistenceLayerId).Count() > 0
                        ).Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.PaidviaCheck:
                    return orders.Where(o =>
                                        o.PaymentsApplied != null && o.PaymentsApplied.Count() > 0 && customerIdsWithNoShow.Contains(o.CustomerId) &&
                                        o.PaymentsApplied.Where(p => p.PaymentType.PersistenceLayerId == PaymentType.Check.PersistenceLayerId).Count() > 0
                        ).Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.PaidviaeCheck:
                    return orders.Where(o =>
                                        o.PaymentsApplied != null && o.PaymentsApplied.Count() > 0 && customerIdsWithNoShow.Contains(o.CustomerId) &&
                                        o.PaymentsApplied.Where(p => p.PaymentType.PersistenceLayerId == PaymentType.ElectronicCheck.PersistenceLayerId).Count() > 0
                        ).Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.PaidviaGiftCertificate:
                    return orders.Where(o =>
                                        o.PaymentsApplied != null && o.PaymentsApplied.Count() > 0 && customerIdsWithNoShow.Contains(o.CustomerId) &&
                                        o.PaymentsApplied.Where(p => p.PaymentType.PersistenceLayerId == PaymentType.GiftCertificate.PersistenceLayerId).Count() > 0
                        ).Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.UnpaidExcludingNoShow:
                    return orders.Where(o => (o.TotalAmountPaid < o.DiscountedTotal && o.DiscountedTotal > 0) && validCustomerIds.Contains(o.CustomerId))
                        .Select(o => o.CustomerId).ToArray();

                case EventCustomerListFilterOption.MetricsOnsite:
                    if (orgRoleUsers == null || orgRoleUsers.Count() < 1)
                        return new long[0];

                    var orgRoleUserIds = orgRoleUsers.Where(org => GetParentRoleIdByRoleId(org.RoleId) == (long)Roles.Technician).Select(org => org.Id).ToArray();

                    return orders.Where(o =>
                                        o.DiscountedTotal == o.TotalAmountPaid
                                        && orgRoleUserIds.Contains(o.DataRecorderMetaData.DataRecorderCreator.Id)
                                        && validCustomerIds.Contains(o.CustomerId)
                        ).Select(o => o.CustomerId).ToArray();



                case EventCustomerListFilterOption.MetricsUpgrades:
                    return orders.Where(o =>
                                            {
                                                var previousComp =
                                                    _customerUpsellModelFactory.GetPreviousSuccesfulCompositionofOrderDetails(o);

                                                if (previousComp == null || previousComp.Count() < 1) return false;

                                                var scheduledCost = previousComp.Sum(od => od.Price);
                                                var revisedCost = o.OrderDetails.Where(s => s.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).Sum(od => od.Price);

                                                if (scheduledCost >= revisedCost) return false;

                                                return validCustomerIds.Contains(o.CustomerId);
                                            }).Select(o => o.CustomerId).ToArray();


                case EventCustomerListFilterOption.MetricsDowngrades:
                    return orders.Where(o =>
                                            {
                                                var previousComp =
                                                    _customerUpsellModelFactory.GetPreviousSuccesfulCompositionofOrderDetails(o);

                                                if (previousComp == null || previousComp.Count() < 1) return false;

                                                var scheduledCost = previousComp.Sum(od => od.Price);
                                                var revisedCost = o.OrderDetails.Where(s => s.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).Sum(od => od.Price);

                                                if (scheduledCost <= revisedCost) return false;

                                                return validCustomerIds.Contains(o.CustomerId);
                                            }).Select(o => o.CustomerId).ToArray();
            }

            return new long[0];
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

        private static IEnumerable<EventAppointmentBasicInfoModel> GetEventAppointmentsforSlotOption(IEnumerable<EventAppointmentBasicInfoModel> appointments, EventSlotListViewOption option)
        {
            switch (option)
            {
                case EventSlotListViewOption.All:
                    return appointments;

                case EventSlotListViewOption.Booked:
                    return appointments.Where(ap => ap.AppointmentStatus == AppointmentStatus.Booked).ToArray();

                case EventSlotListViewOption.Open:
                    return appointments.Where(ap => ap.AppointmentStatus == AppointmentStatus.Free).ToArray();

            }

            return null;
        }

        private static EventCustomerViewModel Create(EventCustomer eventCustomer, Customer customer, Order order, EventCustomerResult eventCustomerResult, IEnumerable<CustomerCallNotes> customerCallNotes,
                                            EventPackage package, IEnumerable<EventTest> eventTests, SourceCode sourceCode, ElectronicProduct product, AssignedPhysicianViewModel physicians, bool isCustomerAuthorized, bool hasUndeliveredShipping,
                                            bool filledHealthAssesmentForm, bool isCancelProductRequestPending, bool isCancelShippingRequestPending, IEnumerable<ShippingDetail> cdShippingDetails, bool showAwvPcpConsentForm,
                                            bool isMedicareQuestionisfilled, CorporateAccount corporateAccount, bool isFlushotTestAttachedWithEvent, IEnumerable<string> preApprovedTest, string patientLeftNotes, long? eawvTestNotPerformedReason)
        {
            string orderPurchased = "";

            if (package != null)
                orderPurchased = package.Package.Name;

            if (eventTests != null && eventTests.Count() > 0)
            {
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + string.Join(", ", eventTests.Select(t => t.Test.Name));
            }

            var isShippingPurchased = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.ShippingDetailOrderDetails != null && od.ShippingDetailOrderDetails.Where(sdod => sdod.IsActive).Any()).Any();

            if (product != null && product.Id == (long)Product.PremiumVersionPdf)
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + product.Name;
            else if (product != null && product.Id == (long)Product.UltraSoundImages && isShippingPurchased)
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + "Ultrasound Images CD";
            else if (product != null && product.Id == (long)Product.UltraSoundImages && !isShippingPurchased)
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + "Ultrasound Images Online";

            var hasUnShippedCd = false;
            if (!cdShippingDetails.IsNullOrEmpty())
                hasUnShippedCd = cdShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).Any();

            var isMammoPurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.Mammogram)) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.Mammogram));

            var isLipidPurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.Lipid && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip))) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.Lipid && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip)));

            var isKynPurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.Kyn && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip))) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.Kyn && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip)));

            var isEawvPurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.eAWV)) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.eAWV));

            var isShowMyBioCheckAssessmentPurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.MyBioCheckAssessment && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip))) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.MyBioCheckAssessment && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip)));

            var isEawvMarkedTestNotPerfromred = false;

            var isAwvPurchased = (package != null && package.Tests.Any(t => TestGroup.AwvTestIds.Contains(t.TestId))) || (eventTests != null && eventTests.Any(t => TestGroup.AwvTestIds.Contains(t.TestId)));

            if (isEawvPurchased)
            {
                isEawvMarkedTestNotPerfromred = eawvTestNotPerformedReason.HasValue;
            }

            var isFluShotTestPurchased = false;

            if (isFlushotTestAttachedWithEvent)
            {
                if (corporateAccount == null)
                {
                    isFluShotTestPurchased = (package != null && package.Tests.Any(t => TestGroup.FluShotTestIds.Contains(t.TestId))) || (eventTests != null && eventTests.Any(t => TestGroup.FluShotTestIds.Contains(t.TestId)));
                }
                else if (corporateAccount.GenerateFluPneuConsentForm)
                {
                    isFluShotTestPurchased = true;
                }
            }

            var isIfobtPurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.IFOBT)) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.IFOBT));

            var isUnineMicroalbumiePurchased = (package != null && package.Tests.Any(t => t.TestId == (long)TestType.UrineMicroalbumin)) ||
                                   (eventTests != null && eventTests.Any(t => t.TestId == (long)TestType.UrineMicroalbumin));

            return new EventCustomerViewModel
                       {
                           AmountDue = order.DiscountedTotal - order.TotalAmountPaid,
                           AmountPaid = order.TotalAmountPaid,
                           AssignedPhysicians = physicians,
                           Address = Mapper.Map<Address, AddressViewModel>(customer.Address),
                           CustomerId = customer.CustomerId,
                           CustomerName = customer.NameAsString,
                           CustomerNotes = customerCallNotes,
                           Email = customer.Email != null ? customer.Email.ToString() : "",
                           EventCustomerId = eventCustomer.Id,
                           IsHealthAssessmentFormFilled = filledHealthAssesmentForm,
                           HipaaStatus = eventCustomer.HIPAAStatus,
                           IsNoShow = eventCustomer.NoShow,
                           IsProductPurchased = (product != null && cdShippingDetails.IsNullOrEmpty()) || hasUnShippedCd,
                           IsAuthorized = isCustomerAuthorized,
                           IsUndeliveredShippinginOrder = hasUndeliveredShipping,
                           IsShippingPurchased = isShippingPurchased,
                           OrderId = order.Id,
                           OrderPurchased = orderPurchased,
                           PartnerRelease = eventCustomer.PartnerRelease,
                           Phone = (((customer.HomePhoneNumber ?? customer.OfficePhoneNumber) ?? customer.MobilePhoneNumber) ?? new PhoneNumber()).ToString(),
                           SourceCode = sourceCode != null ? sourceCode.CouponCode : "",
                           TestResultStateNumber = (eventCustomerResult != null ? eventCustomerResult.ResultState : 0),
                           TotalAmount = order.DiscountedTotal,
                           EmployeeId = customer.EmployeeId,
                           InsuranceId = customer.InsuranceId,
                           IsCancelProductRequestPending = isCancelProductRequestPending,
                           IsCancelShippingRequestPending = isCancelShippingRequestPending,
                           IsMammoPurchased = isMammoPurchased,
                           HospitalFacilityId = eventCustomer.HospitalFacilityId,
                           ShowLipidPrint = isLipidPurchased && !isKynPurchased,
                           ShowKynPrint = isKynPurchased,
                           AbnStatus = eventCustomer.AbnStatus,
                           ShowAwvPcpForm = showAwvPcpConsentForm,
                           PcpConsentStatus = eventCustomer.PcpConsentStatus,
                           ShowMedicareForm = isAwvPurchased,
                           InsuranceReleaseStatus = eventCustomer.InsuranceReleaseStatus,
                           IsMedicareQuestionAnswered = isMedicareQuestionisfilled,
                           IsFluShotTestPurchased = isFluShotTestPurchased,
                           LeftWithoutScreeningReasonId = eventCustomer.LeftWithoutScreeningReasonId,
                           LeftWithoutScreeningNotes = patientLeftNotes,
                           AwvVisitId = eventCustomer.AwvVisitId,
                           PreApprovedTests = preApprovedTest.IsNullOrEmpty()? preApprovedTest: preApprovedTest.Distinct(),
                           IsGiftCertificateDelivered = eventCustomer.IsGiftCertificateDelivered,
                           GiftCode = eventCustomer.GiftCode,
                           IsIfobtTestPurchased = isIfobtPurchased,
                           IsUrineMicroalbumineTestPurchased = isUnineMicroalbumiePurchased,
                           IsForRetest = eventCustomer.IsForRetest,
                           GiftCodeNotGivenReasonId = eventCustomer.GcNotGivenReasonId,
                           IsEawvPurchased = isEawvPurchased,
                           AcesId = customer.AcesId,
                           IsEawvMarkedAsTestNotPerformed = isEawvMarkedTestNotPerfromred,
                           ShowMyBioCheckAssessmentPrint = isShowMyBioCheckAssessmentPurchased,
                           ShowGiftCard = corporateAccount != null && corporateAccount.AttachGiftCard,
                           ShowParticipationConsent = corporateAccount != null && corporateAccount.AttachParicipantConsentForm
                       };
        }

        private static EventAppointmentViewModel Create(EventAppointmentBasicInfoModel appointment)
        {
            return new EventAppointmentViewModel
                       {
                           AppointmentId = appointment.AppointmentId,
                           AppointmentStatus = appointment.AppointmentStatus,
                           AppointmentTime = appointment.StartTime,
                           CheckInTime = appointment.CheckInTime,
                           CheckOutTime = appointment.CheckOutTime,
                           Reason = appointment.Reason,
                           RoomSlots = appointment.RoomSlots
                       };
        }

        private static IEnumerable<EventCustomerViewModel> CreateCancelledEventCustomerList(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers,
            IEnumerable<CustomerCallNotes> customerCallNotes, IEnumerable<Order> orders)
        {
            if (eventCustomers == null || eventCustomers.Count() < 1) return null;

            var cancelledEventCustomers = eventCustomers.Where(ec => !ec.AppointmentId.HasValue).ToArray();

            return (from ec in cancelledEventCustomers
                    join c in customers on ec.CustomerId equals c.CustomerId
                    let cnotes = (customerCallNotes == null ? null : (from cn in customerCallNotes where cn.CustomerId == ec.CustomerId select cn).ToArray())
                    let orderId = (orders == null ? 0 : orders.Where(o => o.CustomerId == c.CustomerId).Select(o => o.Id).SingleOrDefault())
                    select new EventCustomerViewModel
                               {
                                   CustomerName = c.NameAsString,
                                   CustomerId = c.CustomerId,
                                   EventCustomerId = ec.Id,
                                   CustomerNotes = cnotes,
                                   Email = c.Email != null ? c.Email.ToString() : "",
                                   OrderId = orderId,
                                   EmployeeId = c.EmployeeId,
                                   InsuranceId = c.InsuranceId
                               }).ToArray();
        }

        private static CustomerDetailViewModel CreateCustomerDetail(EventCustomer eventCustomer, Customer customer, Order order, ElectronicProduct product, bool filledHealthAssesmentForm, EventPackage package, IEnumerable<EventTest> eventTests,
            IEnumerable<ShippingDetail> customerCdshippingDetails, SourceCode sourceCode, CorporateAccount account, bool showAwvPcpForm)
        {
            var orderPurchased = "";

            if (package != null)
                orderPurchased = package.Package.Name;

            if (eventTests != null && eventTests.Any())
            {
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + string.Join(", ", eventTests.Select(t => t.Test.Name));
            }



            var isShippingPurchased = order.OrderDetails.Any(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.ShippingDetailOrderDetails != null && od.ShippingDetailOrderDetails.Any(sdod => sdod.IsActive));

            if (product != null && product.Id == (long)Product.PremiumVersionPdf)
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + product.Name;
            else if (product != null && product.Id == (long)Product.UltraSoundImages && isShippingPurchased)
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + "Ultrasound Images CD";
            else if (product != null && product.Id == (long)Product.UltraSoundImages && !isShippingPurchased)
                orderPurchased = (string.IsNullOrEmpty(orderPurchased) ? "" : orderPurchased + ", ") + "Ultrasound Images Online";

            long[] shipingIds = null;

            if (isShippingPurchased && customerCdshippingDetails.Any())
            {
                var orderShiping = order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails);

                var shipingdetailIds = orderShiping.Where(os => os.IsActive).Select(x => x.ShippingDetailId).ToArray();
                shipingIds = customerCdshippingDetails.Where(x => shipingdetailIds.Contains(x.Id)).Select(x => x.ShippingOption.Id).ToArray();
            }

            var isAwvPurchased = (package != null && package.Tests.Any(t => TestGroup.AwvTestIds.Contains(t.TestId))) ||
                                  (eventTests != null && eventTests.Any(t => TestGroup.AwvTestIds.Contains(t.TestId)));

            return new CustomerDetailViewModel
            {
                AmountDue = order.DiscountedTotal - order.TotalAmountPaid,
                AmountPaid = order.TotalAmountPaid,
                Address = Mapper.Map<Address, AddressEditModel>(customer.Address),
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                Email = customer.Email != null ? customer.Email.ToString() : "",
                EventCustomerId = eventCustomer.Id,
                IsHealthAssessmentFormFilled = filledHealthAssesmentForm,
                HipaaStatus = eventCustomer.HIPAAStatus,
                IsNoShow = eventCustomer.NoShow,
                OrderPurchased = orderPurchased,
                HomePhone = customer.HomePhoneNumber ?? new PhoneNumber(),
                MobileNumber = customer.MobilePhoneNumber ?? new PhoneNumber(),
                TotalAmount = order.UndiscountedTotal,
                EmployeeId = customer.EmployeeId,
                InsuranceId = customer.InsuranceId,
                PackageId = package != null ? package.PackageId : 0,
                TestIds = (eventTests != null && eventTests.Any() ? eventTests.Select(x => x.TestId) : null),
                Weight = customer.Weight,
                Height = customer.Height,
                EnableTexting = customer.EnableTexting,
                Gender = customer.Gender,
                Dob = customer.DateOfBirth,
                Race = customer.Race,
                AllowPrequalifiedTestOnly = account != null && account.AllowPreQualifiedTestOnly,
                ProductId = product == null ? 0 : product.Id,
                ShippingOptions = shipingIds,
                SourceCode = sourceCode != null ? sourceCode.CouponCode : string.Empty,
                PartnerReleaseStatus = eventCustomer.PartnerRelease,
                PcpConsentStatus = eventCustomer.PcpConsentStatus,
                ShowAwvPcpForm = showAwvPcpForm,
                AbnStatus = eventCustomer.AbnStatus,
                InsuranceReleaseStatus = eventCustomer.InsuranceReleaseStatus,
                Tag = (account != null && account.AllowPreQualifiedTestOnly) ? 170 : (long?)null,
                CaptureInsuranceRelease = isAwvPurchased

            };
        }


        public EventCustomerBrifListModel CreateBrifListModel(EventCustomerBrifListModel model,
            IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments, IEnumerable<Customer> customers,
            IEnumerable<Order> orders, IEnumerable<long> filledHealthAssesmentForms, IEnumerable<ElectronicProduct> products, EventCustomerListModelFilter filter, IEnumerable<EventPackage> eventPackages,
            IEnumerable<EventTest> eventtests, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<ShippingDetail> cdShippingDetails, IEnumerable<SourceCode> sourceCodes, CorporateAccount account, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians)
        {

            if (filter.CustomerListFilterOption > 0 && (customers == null || !customers.Any()))
                return model;

            var eventCustomerswithFilterApplied = eventCustomers;
            var eventAppointmentswithFilterApplied = eventAppointments;

            if (filter.CustomerListFilterOption > 0)
            {
                var customerIds = GetCustomerIdsforFilterOption(orders, eventCustomers, eventAppointments, (EventCustomerListFilterOption)filter.CustomerListFilterOption, orgRoleUsers);
                eventCustomerswithFilterApplied = eventCustomers.Where(ec => customerIds.Contains(ec.CustomerId)).ToArray();

                var filteredAppointmentIds = eventCustomerswithFilterApplied.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToArray();
                eventAppointmentswithFilterApplied = eventAppointments.Where(ea => filteredAppointmentIds.Contains(ea.AppointmentId) && ea.AppointmentStatus == AppointmentStatus.Booked).ToArray();

                if (!eventCustomerswithFilterApplied.Any())
                    return model;
            }
            else if (filter.AppointmentSlotViewOption > 0)
            {
                eventAppointmentswithFilterApplied = GetEventAppointmentsforSlotOption(eventAppointments, (EventSlotListViewOption)filter.AppointmentSlotViewOption);

                if (eventAppointmentswithFilterApplied == null || !eventAppointmentswithFilterApplied.Any()) return model;
            }

            var distModel = new List<EventCustomerAppointmentViewModel>();

            foreach (var appointment in eventAppointmentswithFilterApplied)
            {
                var eventAppointmentDistModel = new EventCustomerAppointmentViewModel();

                var appointmentViewModel = Create(appointment);
                eventAppointmentDistModel.Appointment = appointmentViewModel;

                var eventCustomer = eventCustomerswithFilterApplied != null && eventCustomerswithFilterApplied.Any()
                    ? eventCustomerswithFilterApplied.SingleOrDefault(ec => ec.AppointmentId != null && ec.AppointmentId == appointment.AppointmentId
                        && appointment.AppointmentStatus == AppointmentStatus.Booked) : null;

                if (eventCustomer == null) { distModel.Add(eventAppointmentDistModel); continue; }

                var customer = customers.Single(c => eventCustomer.CustomerId == c.CustomerId);

                var order = orders.Single(o => o.CustomerId == customer.CustomerId);

                var sourceCodeId =
                   order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess
                                                    && od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive)
                                                            .Select(od => od.SourceCodeOrderDetail.SourceCodeId).SingleOrDefault();

                var sourceCode = sourceCodeId > 0 ? sourceCodes.SingleOrDefault(sc => sc.Id == sourceCodeId) : null;

                bool showAwvPcpConsentForm = false;

                if (model.CapturePcpConsent && primaryCarePhysicians != null && primaryCarePhysicians.Any())
                {
                    showAwvPcpConsentForm = primaryCarePhysicians.Any(x => x.CustomerId == customer.CustomerId);
                }


                var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem).Select(od => od.OrderItem.ItemId).SingleOrDefault();
                var eventPackage = eventPackages.SingleOrDefault(ep => eventpackageId == ep.Id);

                var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
                var eventTestsonOrder = eventtests.Where(et => eventTestIds.Contains(et.Id)).ToArray();

                var product = products != null ? products.SingleOrDefault(p => p.Id == order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.ProductItem)
                                                                                           .Select(od => od.OrderItem.ItemId).FirstOrDefault()) : null;


                var shippingDetailIds = order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId)).ToArray();

                IEnumerable<ShippingDetail> customerCdshippingDetails = null;
                if (!cdShippingDetails.IsNullOrEmpty())
                    customerCdshippingDetails = cdShippingDetails.Where(sd => shippingDetailIds.Contains(sd.Id)).ToArray();


                var customerViewModel = CreateCustomerDetail(eventCustomer, customer, order, product, (filledHealthAssesmentForms != null && filledHealthAssesmentForms.Contains(customer.CustomerId)), eventPackage, eventTestsonOrder, customerCdshippingDetails, sourceCode, account, showAwvPcpConsentForm);

                eventAppointmentDistModel.Customer = customerViewModel;

                distModel.Add(eventAppointmentDistModel);
            }

            model.EventAppointmentSlotDistributions = distModel;

            return model;
        }


        public IEnumerable<ShortPatientInfoViewModel> CreateCustomerAppointmentList(IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventAppointmentBasicInfoModel> eventAppointments, IEnumerable<Customer> customers,
            IEnumerable<Order> orders, EventCustomerListModelFilter filter, IEnumerable<OrganizationRoleUser> orgRoleUsers, Host host, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests,
            IEnumerable<ParticipationConsentSignature> participationConsentSignatures, IEnumerable<FluConsentSignature> fluConsentSignatures, IEnumerable<PhysicianRecordRequestSignature> physicianRecordRequestSignatures, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians,
            IEnumerable<ChaperoneSignature> chaperoneSignature)
        {
            var list = new List<ShortPatientInfoViewModel>();
            if (filter.CustomerListFilterOption > 0 && (customers.IsNullOrEmpty()))
                return list;

            var eventCustomerswithFilterApplied = eventCustomers;
            var eventAppointmentswithFilterApplied = eventAppointments;

            if (filter.CustomerListFilterOption > 0)
            {
                var customerIds = GetCustomerIdsforFilterOption(orders, eventCustomers, eventAppointments, (EventCustomerListFilterOption)filter.CustomerListFilterOption, orgRoleUsers);
                eventCustomerswithFilterApplied = eventCustomers.Where(ec => customerIds.Contains(ec.CustomerId)).ToArray();

                var filteredAppointmentIds = eventCustomerswithFilterApplied.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToArray();
                eventAppointmentswithFilterApplied = eventAppointments.Where(ea => filteredAppointmentIds.Contains(ea.AppointmentId) && ea.AppointmentStatus == AppointmentStatus.Booked).ToArray();

                if (!eventCustomerswithFilterApplied.Any())
                    return list;
            }
            else if (filter.AppointmentSlotViewOption > 0)
            {
                eventAppointmentswithFilterApplied = GetEventAppointmentsforSlotOption(eventAppointments, (EventSlotListViewOption)filter.AppointmentSlotViewOption);

                if (eventAppointmentswithFilterApplied == null || !eventAppointmentswithFilterApplied.Any()) return list;
            }

            foreach (var appointment in eventAppointmentswithFilterApplied)
            {
                if (appointment.AppointmentStatus != AppointmentStatus.Booked) continue;

                var model = new ShortPatientInfoViewModel
                {
                    AppointmentTime = appointment.StartTime,
                    CheckInTime = appointment.CheckInTime,
                    CheckOutTime = appointment.CheckOutTime
                };

                var eventCustomer = !eventCustomerswithFilterApplied.IsNullOrEmpty() ? eventCustomerswithFilterApplied.SingleOrDefault(ec => ec.AppointmentId != null && ec.AppointmentId == appointment.AppointmentId) : null;

                if (eventCustomer == null) continue;

                var customer = customers.Single(c => eventCustomer.CustomerId == c.CustomerId);

                var order = orders.Single(o => o.CustomerId == eventCustomer.CustomerId);

                var eventpackageId = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventPackageItem)
                    .Select(od => od.OrderItem.ItemId).SingleOrDefault();
                var eventPackage = eventPackages.SingleOrDefault(ep => eventpackageId == ep.Id);

                var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.OrderItem.OrderItemType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
                var eventTestsonOrder = eventTests.Where(et => eventTestIds.Contains(et.Id)).ToArray();


                model.EventCustomerId = eventCustomer.Id;
                model.CustomerId = customer.CustomerId;
                model.FirstName = customer.Name.FirstName;
                model.MiddleName = customer.Name.MiddleName;
                model.LastName = customer.Name.LastName;
                model.HomePhone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : "";
                model.Email = customer.Email != null ? customer.Email.ToString() : "";
                model.MobileNumber = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : "";
                model.EventId = eventCustomer.EventId;
                model.Packages = eventPackage != null ? eventPackage.Package.Name : "";
                model.Tests = !eventTestsonOrder.IsNullOrEmpty() ? string.Join(", ", eventTestsonOrder.Select(t => t.Test.Name)) : "";
                model.HipaaConsent = eventCustomer.HIPAAStatus;
                model.MatrixConsent = participationConsentSignatures != null && participationConsentSignatures.SingleOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null;
                model.PhysicianRecordRequest = physicianRecordRequestSignatures != null && physicianRecordRequestSignatures.SingleOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null;
                model.FluVaccine = fluConsentSignatures != null && fluConsentSignatures.SingleOrDefault(x => x.EventCustomerId == eventCustomer.Id) != null;
                model.NoShow = eventCustomer.AppointmentId.HasValue && eventCustomer.NoShow;
                model.LeftWithoutScreening = eventCustomer.AppointmentId.HasValue && eventCustomer.LeftWithoutScreeningReasonId.HasValue;

                model.ChaperoneConsent = chaperoneSignature.Any(x => x.EventCustomerId == eventCustomer.Id);

                var pcp = primaryCarePhysicians != null ? primaryCarePhysicians.FirstOrDefault(x => x.CustomerId == eventCustomer.CustomerId) : null;
                if (pcp != null)
                {
                    var pcpAddress = pcp.Address != null ? Mapper.Map<Address, AddressViewModel>(pcp.Address) : null;
                    model.PrimaryCarePhysician = new PcpInfoViewModel
                    {
                        Name = pcp.Name.FullName,
                        Address = pcpAddress,
                        PhoneNumber = pcp.Primary != null ? pcp.Primary.FormatPhoneNumber : pcp.Secondary != null ? pcp.Secondary.FormatPhoneNumber : "",
                        Fax = pcp.Fax != null ? pcp.Fax.FormatPhoneNumber : ""
                    };
                }

                list.Add(model);
            }

            return list;
        }
    }
}