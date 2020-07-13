using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Call = Falcon.App.Core.CallCenter.Domain.Call;
using Relationship = Falcon.App.Core.Users.Domain.Relationship;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class CustomerExportModelFactory : ICustomerExportModelFactory
    {
        public CustomerExportListModel Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages,
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<Role> roles, IEnumerable<SourceCode> sourceCodes, IEnumerable<Call> calls, IEnumerable<Language> languages, IEnumerable<Lab> labs,
            IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<Notes> doNotContactReasonNotes, IEnumerable<OrderedPair<long, string>> customersPreApprovedTests,
            IEnumerable<OrderedPair<long, string>> customersPreApprovedPackages, IEnumerable<Appointment> appointments, IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> additionalFields,
            IEnumerable<CustomerPredictedZip> customerPredictedZips, IEnumerable<CustomerEligibility> customerEligibilities, IEnumerable<ChaseOutbound> chaseOutbounds, IEnumerable<Relationship> relationships, IEnumerable<Falcon.App.Core.Medical.Domain.ActivityType> activityTypes)
        {
            var model = new CustomerExportListModel();
            var customerExportModels = new List<CustomerExportModel>();

            foreach (var customer in customers)
            {
                string signupMode;
                if (customer.AddedByRoleId.HasValue && customer.AddedByRoleId.Value != (long)Roles.Customer)
                    signupMode = roles.First(r => r.Id == customer.AddedByRoleId.Value).DisplayName;
                else
                    signupMode = "Online";

                var incomingLine = calls.Where(c => c.CalledCustomerId == customer.CustomerId && !string.IsNullOrEmpty(c.CalledInNumber)).Select(c => c.CalledInNumber).LastOrDefault();
                var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                var isEligible = "N/A";
                var language = "N/A";
                var lab = "N/A";
                var corporateCustomTags = "N/A";

                if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                {
                    if (customerEligibility.IsEligible.Value)
                        isEligible = EligibleStatus.Yes.ToString();
                    else
                        isEligible = EligibleStatus.No.ToString();
                }

                if (customer.LanguageId.HasValue)
                {
                    var customerLanguage = languages.FirstOrDefault(l => l.Id == customer.LanguageId.Value);
                    if (customerLanguage != null)
                        language = customerLanguage.Name;
                }

                if (customer.LabId.HasValue)
                {
                    var customerLab = labs.FirstOrDefault(l => l.Id == customer.LabId.Value);
                    if (customerLab != null)
                        lab = customerLab.Name;
                }

                if (customTags != null && customTags.Any())
                {
                    var customerCustomTags = customTags.Where(ct => ct.CustomerId == customer.CustomerId).Select(ct => ct.Tag).ToArray();

                    if (customerCustomTags.Any())
                    {
                        corporateCustomTags = string.Join(", ", customerCustomTags);
                    }
                }

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == customer.CustomerId).Select(p => p).FirstOrDefault();

                var doNotContactReason = string.Empty;
                var doNotContactReasonNote = string.Empty;
                if (customer.DoNotContactReasonId.HasValue)
                {
                    doNotContactReason = ((DoNotContactReason)customer.DoNotContactReasonId.Value).GetDescription();
                }

                if (customer.DoNotContactReasonNotesId.HasValue)
                {
                    doNotContactReasonNote = doNotContactReasonNotes.First(x => x.Id == customer.DoNotContactReasonNotesId).Text;
                }

                var customerPreApprovedTest = "N/A";

                if (customersPreApprovedTests != null && customersPreApprovedTests.Any())
                {
                    var customerTests = customersPreApprovedTests.Where(x => x.FirstValue == customer.CustomerId);
                    if (customerTests != null && customerTests.Any())
                    {
                        var preApproveTestTemp = customerTests.Select(x => string.Format("\"{0}\"", x.SecondValue)).ToArray();

                        customerPreApprovedTest = string.Join(", ", preApproveTestTemp);
                    }
                }

                var customerPreApprovedPakages = "N/A";

                if (customersPreApprovedPackages != null && customersPreApprovedPackages.Any())
                {
                    var customerPackages = customersPreApprovedPackages.Where(x => x.FirstValue == customer.CustomerId);
                    if (customerPackages != null && customerPackages.Any())
                    {
                        var preApproveTestTemp = customerPackages.Select(x => string.Format("\"{0}\"", x.SecondValue)).ToArray();

                        customerPreApprovedPakages = string.Join(", ", preApproveTestTemp);
                    }
                }

                var customerPredictedZip = customerPredictedZips != null ? customerPredictedZips.Where(x => x.CustomerId == customer.CustomerId) : null;

                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId && x.IsActive);
                var relationship = chaseOutbound != null && chaseOutbound.RelationshipId.HasValue ? relationships.FirstOrDefault(x => x.Id == chaseOutbound.RelationshipId.Value) : null;

                Falcon.App.Core.Medical.Domain.ActivityType activityType = null;
                if (customer.ActivityId.HasValue)
                    activityType = activityTypes != null && activityTypes.Any() ? activityTypes.First(x => x.Id == customer.ActivityId.Value) : null;

                var customerExportModel = new CustomerExportModel
                                              {
                                                  CustomerId = customer.CustomerId,
                                                  FirstName = customer.Name.FirstName,
                                                  MiddleName = customer.Name.MiddleName,
                                                  LastName = customer.Name.LastName,
                                                  PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                                                  Gender = customer.Gender.ToString(),
                                                  DateofBirth = customer.DateOfBirth,
                                                  Address1 = customer.Address.StreetAddressLine1,
                                                  Address2 = customer.Address.StreetAddressLine2,
                                                  City = customer.Address.City,
                                                  State = customer.Address.State,
                                                  Zip = customer.Address.ZipCode.Zip,
                                                  DateCreated = customer.DateCreated,
                                                  MarketingSource = customer.MarketingSource,
                                                  SignUpMode = signupMode,
                                                  Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                                                  Race = customer.Race.ToString(),
                                                  Height = customer.Height != null ? customer.Height.TotalInches.ToString() : string.Empty,
                                                  Weight = customer.Weight != null ? customer.Weight.Pounds.ToString() : string.Empty,
                                                  LastScreeningDate = customer.LastScreeningDate,
                                                  IncomingPhoneLine = incomingLine,
                                                  Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                                                  MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                                                  IsEligible = isEligible,
                                                  Language = language,
                                                  Lab = lab,
                                                  CustomTag = corporateCustomTags,
                                                  Copay = customer.Copay,
                                                  MedicarePlanName = string.IsNullOrEmpty(customer.MedicareAdvantagePlanName) ? "N/A" : customer.MedicareAdvantagePlanName,
                                                  Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                                                  Lpi = string.IsNullOrEmpty(customer.Lpi) ? "N/A" : customer.Lpi,
                                                  Market = string.IsNullOrEmpty(customer.Market) ? "N/A" : customer.Market,
                                                  Mrn = string.IsNullOrEmpty(customer.Mrn) ? "N/A" : customer.Mrn,
                                                  GroupName = string.IsNullOrEmpty(customer.GroupName) ? "N/A" : customer.GroupName,
                                                  DoNotContactReason = doNotContactReason,
                                                  DoNotContactReasonNote = doNotContactReasonNote,
                                                  PreApprovedTest = customerPreApprovedTest,
                                                  PreApprovedPackage = customerPreApprovedPakages,
                                                  Activity = activityType != null ? activityType.Name : "N/A",
                                                  PredictedZip = customerPredictedZip != null ? string.Join(", ", customerPredictedZip.Select(x => x.PredictedZip)) : "N/A",
                                                  Mbi = string.IsNullOrEmpty(customer.Mbi) ? "N/A" : customer.Mbi,
                                                  AcesId = string.IsNullOrWhiteSpace(customer.AcesId) ? "N/A" : customer.AcesId,
                                                  RelationshipCode = relationship != null ? relationship.Code : string.Empty,
                                                  RelationshipName = relationship != null ? relationship.Description : string.Empty,
                                                  Product = customer.ProductTypeId.HasValue && customer.ProductTypeId.Value > 0 ? ((ProductType)customer.ProductTypeId.Value).GetDescription() : "N/A"
                                              };

                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    var corporateAccount = corporateAccounts.FirstOrDefault(x => x.Tag == customer.Tag);

                    if (corporateAccount != null)
                    {
                        var accountAdditionalFields = additionalFields.Where(x => x.AccountId == corporateAccount.Id);
                        customerExportModel.AdditionalFields = accountAdditionalFields.Select(x => new OrderedPair<string, string>(x.DisplayName, GetCustomerAdditionalField(customer, x.AdditionalFieldId)));
                    }
                }

                if (pcp != null)
                {
                    customerExportModel.PcpFirstName = pcp.Name.FirstName;
                    customerExportModel.PcpLastName = pcp.Name.LastName;
                    customerExportModel.PcpNpi = string.IsNullOrEmpty(pcp.Npi) ? "N/A" : pcp.Npi;

                    if (pcp.Address != null && !pcp.Address.IsEmpty())
                    {
                        customerExportModel.PcpAddress1 = pcp.Address.StreetAddressLine1;
                        customerExportModel.PcpAddress2 = pcp.Address.StreetAddressLine2;
                        customerExportModel.PcpCity = pcp.Address.City;
                        customerExportModel.PcpState = pcp.Address.State;
                        customerExportModel.PcpZip = pcp.Address.ZipCode.Zip;
                    }
                    customerExportModel.PcpFax = pcp.Fax != null ? pcp.Fax.ToString() : string.Empty;
                    customerExportModel.PcpPhone = pcp.Primary != null ? pcp.Primary.ToString() : string.Empty;
                }

                if (eventCustomers != null && eventCustomers.Any())
                {
                    var eventCustomer = (from ec in eventCustomers
                                         join e in eventListModel.Collection on ec.EventId equals e.EventCode
                                         where ec.AppointmentId.HasValue && ec.CustomerId == customer.CustomerId
                                         orderby e.EventDate descending
                                         select ec).FirstOrDefault();

                    if (eventCustomer != null)
                    {
                        var order = orders.FirstOrDefault(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);
                        if (order != null)
                        {
                            var sourceCodeOrderDetail = order.OrderDetails.Where(od => od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive).Select(od => od.SourceCodeOrderDetail).FirstOrDefault();

                            string sourceCode = string.Empty;
                            decimal sourceCodeAmount = 0;
                            if (sourceCodeOrderDetail != null)
                            {
                                var coupon = sourceCodes.FirstOrDefault(sc => sc.Id == sourceCodeOrderDetail.SourceCodeId);

                                sourceCode = coupon.CouponCode;
                                sourceCodeAmount = sourceCodeOrderDetail.Amount;
                            }

                            var package = packages.FirstOrDefault(p => p.FirstValue == order.Id);

                            var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                            var productPurchased = string.Empty;

                            if (package != null && !test.IsNullOrEmpty())
                                productPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                            else if (!test.IsNullOrEmpty())
                                productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                            else if (package != null)
                                productPurchased = package.SecondValue;

                            customerExportModel.IsPaid = order.TotalAmountPaid >= order.DiscountedTotal;
                            customerExportModel.Amount = order.DiscountedTotal;
                            customerExportModel.Package = productPurchased;
                            customerExportModel.ScreeningCost = order.OrderDetails.Where(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.IsCompleted).Sum(od => od.Price);
                            customerExportModel.SourceCode = sourceCode;
                            customerExportModel.SourceCodeAmount = sourceCodeAmount;
                        }

                        var eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == eventCustomer.EventId);
                        if (eventModel != null)
                        {
                            customerExportModel.EventId = eventModel.EventCode;
                            customerExportModel.EventName = eventModel.Location;
                            customerExportModel.EventDate = eventModel.EventDate;
                            customerExportModel.EventAddress1 = eventModel.StreetAddressLine1;
                            customerExportModel.EventAddress2 = eventModel.StreetAddressLine2;
                            customerExportModel.EventCity = eventModel.City;
                            customerExportModel.EventState = eventModel.State;
                            customerExportModel.EventZip = eventModel.Zip;
                            customerExportModel.Pod = eventModel.Pod;
                        }
                        var appointment = appointments.FirstOrDefault(a => a.Id == eventCustomer.AppointmentId.Value);
                        customerExportModel.Status = (appointment != null && appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue && !eventCustomer.LeftWithoutScreeningReasonId.HasValue) ? "Availed" : "Not Availed";

                    }
                }
                customerExportModels.Add(customerExportModel);
            }

            model.Collection = customerExportModels;
            return model;
        }

        private string GetCustomerAdditionalField(Customer customer, long additionalField)
        {
            switch ((AdditionalFieldsEnum)additionalField)
            {
                case AdditionalFieldsEnum.AdditionalField1:
                    return string.IsNullOrEmpty(customer.AdditionalField1) ? "N/A" : customer.AdditionalField1;
                case AdditionalFieldsEnum.AdditionalField2:
                    return string.IsNullOrEmpty(customer.AdditionalField2) ? "N/A" : customer.AdditionalField2;
                case AdditionalFieldsEnum.AdditionalField3:
                    return string.IsNullOrEmpty(customer.AdditionalField3) ? "N/A" : customer.AdditionalField3;
                case AdditionalFieldsEnum.AdditionalField4:
                    return string.IsNullOrEmpty(customer.AdditionalField4) ? "N/A" : customer.AdditionalField4;
            }

            return string.Empty;
        }
    }
}
