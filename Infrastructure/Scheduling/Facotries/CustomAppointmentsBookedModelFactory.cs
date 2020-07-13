using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Sales.Domain;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class CustomAppointmentsBookedModelFactory : ICustomAppointmentsBookedModelFactory
    {
        public CustomAppointmentsBookedListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders,
            EventVolumeListModel eventListModel, IEnumerable<Customer> customers, IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs,
            IEnumerable<EventAppointmentChangeLog> eventAppointmentChangeLogs, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests,
            IEnumerable<Language> languages)
        {
            var model = new CustomAppointmentsBookedListModel();
            var appointmentsBookedModels = new List<CustomAppointmentsBookedModel>();

            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == ec.EventId);

                var order = orders.FirstOrDefault(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId);

                var customer = customers.FirstOrDefault(c => c.CustomerId == ec.CustomerId);

                var customerLanguage = "N/A";
                if (customer.LanguageId.HasValue)
                {
                    var language = languages.FirstOrDefault(x => x.Id == customer.LanguageId);
                    if (language != null)
                    {
                        customerLanguage = language.Name;
                    }
                }

                var productPurchased = string.Empty;

                if (order != null && order.OrderDetails != null && order.OrderDetails.Any())
                {
                    var packageOrderItem = order.OrderDetails.FirstOrDefault(od => od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted);
                    var testOrderItems = order.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem && od.IsCompleted);

                    if (packageOrderItem != null)
                    {
                        var eventPackage = eventPackages.FirstOrDefault(x => x.Id == packageOrderItem.OrderItem.ItemId);
                        if (eventPackage != null)
                        {
                            productPurchased = eventPackage.Package.Name;
                        }
                    }

                    if (!testOrderItems.IsNullOrEmpty())
                    {
                        var orderIds = testOrderItems.Select(x => x.OrderItem.ItemId);
                        var customerTests = eventTests.Where(x => orderIds.Contains(x.Id));

                        if (!customerTests.IsNullOrEmpty())
                        {
                            var testNames = customerTests.Select(x => x.Test.Name).ToArray();

                            productPurchased = string.IsNullOrEmpty(productPurchased) ? string.Join(",", testNames) : productPurchased + "," + string.Join(",", testNames);
                        }
                    }
                }

                var rescheduleApplointmentModels = new List<RescheduleApplointmentModel>();

                var eventCustomerReschedules = eventAppointmentChangeLogs.Where(eacl => eacl.EventCustomerId == ec.Id).Select(eacl => eacl).ToArray();

                if (eventCustomerReschedules != null && eventCustomerReschedules.Any())
                {
                    foreach (var ecr in eventCustomerReschedules)
                    {
                        var rescheduledBy = agents.Single(a => a.Id == ecr.CreatedByOrgRoleUserId);

                        var rescheduleAgentRole = roles.Single(r => r.Id == rescheduledBy.RoleId).DisplayName;
                        var rescheduleAgentName = agentIdNamePairs.Single(ap => ap.FirstValue == rescheduledBy.Id).SecondValue;

                        rescheduleApplointmentModels.Add(new RescheduleApplointmentModel()
                        {
                            RescheduledOn = ecr.DateCreated,
                            RescheduledBy = rescheduleAgentName + "(" + rescheduleAgentRole + ")",
                            Reason = ecr.ReasonId.HasValue && ecr.ReasonId > 0 ? ((RescheduleAppointmentReason)ecr.ReasonId.Value).GetDescription() : "N/A",
                            Notes = ecr.Notes,
                            SubReason = ecr.SubReasonId.HasValue && ecr.SubReasonId > 0 ? ((RescheduleAppointmentSubReason)ecr.SubReasonId.Value).GetDescription() : string.Empty,
                        });
                    }
                }

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == ec.CustomerId).Select(p => p).FirstOrDefault();

                var appointment = ec.AppointmentId.HasValue ? appointments.FirstOrDefault(a => a.Id == ec.AppointmentId.Value) : null;

                var groupName = "N/A";

                if (!string.IsNullOrEmpty(customer.GroupName))
                {
                    groupName = customer.GroupName;
                }
                var status = (appointment != null && appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue) ? "Availed" : "Not Availed";

                var apptModel = new CustomAppointmentsBookedModel
                {

                    CustomerId = ec.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    RegistrantId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    RegistrationStatus = !ec.AppointmentId.HasValue ? "Cancelled" : string.Empty,
                    RescheduleInfo = rescheduleApplointmentModels,
                    EventDate = eventModel.EventDate,
                    AppointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointment.StartTime : null,
                    CustomerName = customer.NameAsString,
                    DateofBirth = customer.DateOfBirth,
                    Gender = customer.Gender.ToString(),
                    Market = string.IsNullOrEmpty(customer.Market) ? "N/A" : customer.Market,
                    AdditionalField3 = string.IsNullOrEmpty(customer.AdditionalField3) ? "N/A" : customer.AdditionalField3,
                    AdditionalField4 = string.IsNullOrEmpty(customer.AdditionalField4) ? "N/A" : customer.AdditionalField4,
                    Language = customerLanguage,
                    InsuranceId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    Address = customer.Address,
                    PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : string.Empty,
                    MedicareAdvantagePlanName = string.IsNullOrEmpty(customer.MedicareAdvantagePlanName) ? "N/A" : customer.MedicareAdvantagePlanName,
                    Package = productPurchased,
                    Host = eventModel.Location,
                    HostAddress = eventModel.Address,
                    Status = status,
                    RegistrationDate = ec.DataRecorderMetaData.DateCreated,
                    EventId = ec.EventId.ToString(),
                    GroupName = groupName,
                    PreferredContactType = customer.PreferredContactType.HasValue ? ((PreferredContactType)customer.PreferredContactType).GetDescription() : "N/A",
                };

                if (pcp != null)
                {
                    apptModel.PcpName = pcp.Name.FullName;
                    apptModel.PcpPhone = pcp.Primary != null ? pcp.Primary.ToString() : string.Empty;
                    apptModel.PcpNpi = pcp.Npi;

                    if (pcp.Address != null && !pcp.Address.IsEmpty())
                    {
                        apptModel.PcpAddress1 = pcp.Address.StreetAddressLine1;
                        apptModel.PcpAddress2 = pcp.Address.StreetAddressLine2;
                        apptModel.PcpCity = pcp.Address.City;
                        apptModel.PcpState = pcp.Address.State;
                        apptModel.PcpZip = pcp.Address.ZipCode.Zip;
                    }
                }

                appointmentsBookedModels.Add(apptModel);
            });

            model.Collection = appointmentsBookedModels;
            return model;
        }


        public HourlyAppointmentsBookedListModel CreateHourlyModel(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel, IEnumerable<Customer> customers,
                                                    IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, IEnumerable<SourceCode> sourceCodes, IEnumerable<Call> calls, IEnumerable<ShippingDetail> shippingDetails,
                                                    ShippingOption cdShippingOption, IEnumerable<ShippingOption> shippingOptions, IEnumerable<EventAppointmentChangeLog> eventAppointmentChangeLogs,
                                                    IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests, IEnumerable<Language> languages,
                                                    IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> accountAdditionalFields,
                                                    IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var model = new HourlyAppointmentsBookedListModel();
            var appointmentsBookedModels = new List<HourlyAppointmentBookedModel>();

            foreach (var ec in eventCustomers)
            {
                var eventModel = eventListModel.Collection.First(e => e.EventCode == ec.EventId);

                var order = orders.FirstOrDefault(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId);

                var productCost = order != null ? order.ProductCost : null;

                var sourceCodeOrderDetail = order == null ? null : order.OrderDetails.Where(
                    od =>
                    od.SourceCodeOrderDetail != null &&
                    od.SourceCodeOrderDetail.IsActive).Select(od => od.SourceCodeOrderDetail).FirstOrDefault();

                var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == ec.CustomerId);

                string sourceCode = string.Empty;
                decimal sourceCodeDisc = 0;
                if (sourceCodeOrderDetail != null)
                {
                    var coupon = sourceCodes.FirstOrDefault(sc => sc.Id == sourceCodeOrderDetail.SourceCodeId);

                    sourceCode = coupon != null ? coupon.CouponCode : string.Empty;
                    sourceCodeDisc = sourceCodeOrderDetail.Amount;
                }

                var customer = customers.First(c => c.CustomerId == ec.CustomerId);

                var displayFielAandAdditionalFieldsPairs = new List<OrderedPair<string, string>>();
                if (corporateAccounts != null && corporateAccounts.Any() && !string.IsNullOrEmpty(customer.Tag) && accountAdditionalFields != null && accountAdditionalFields.Any())
                {
                    var corporateAccount = corporateAccounts.FirstOrDefault(a => a.Tag == customer.Tag);

                    if (corporateAccount != null)
                    {
                        var additionalFields = accountAdditionalFields.Where(x => x.AccountId == corporateAccount.Id).ToArray();

                        foreach (var additionalField in additionalFields)
                        {
                            displayFielAandAdditionalFieldsPairs.Add(new OrderedPair<string, string>(additionalField.DisplayName, GetCustomersAdditionFiledValue(customer, (AdditionalFieldsEnum)additionalField.AdditionalFieldId)));
                        }
                    }
                }

                var productPurchased = string.Empty;
                decimal remibursmentRateSum = 0;
                if (order != null && order.OrderDetails != null && order.OrderDetails.Any())
                {
                    var packageOrderItem = order.OrderDetails.FirstOrDefault(od => od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted);
                    var testOrderItems = order.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem && od.IsCompleted);

                    if (packageOrderItem != null)
                    {
                        var eventPackage = eventPackages.FirstOrDefault(x => x.Id == packageOrderItem.OrderItem.ItemId);
                        if (eventPackage != null)
                        {
                            productPurchased = eventPackage.Package.Name;
                            remibursmentRateSum = eventPackage.Tests.Sum(t => t.ReimbursementRate);
                        }
                    }

                    if (!testOrderItems.IsNullOrEmpty())
                    {
                        var orderIds = testOrderItems.Select(x => x.OrderItem.ItemId);
                        var customerTests = eventTests.Where(x => orderIds.Contains(x.Id));

                        if (!customerTests.IsNullOrEmpty())
                        {
                            var testNames = customerTests.Select(x => x.Test.Name).ToArray();
                            remibursmentRateSum = remibursmentRateSum + customerTests.Sum(x => x.ReimbursementRate);
                            productPurchased = string.IsNullOrEmpty(productPurchased) ? string.Join(",", testNames) : productPurchased + "," + string.Join(",", testNames);
                        }
                    }
                }

                var registeredBy = (ec.DataRecorderMetaData == null || ec.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.Where(a => a.Id == ec.DataRecorderMetaData.DataRecorderCreator.Id).FirstOrDefault());
                string agentName, callType;
                string agentRole = agentName = callType = string.Empty;

                var incomingLine = calls.Where(c => c.CalledCustomerId == ec.CustomerId && !string.IsNullOrEmpty(c.CalledInNumber)).Select(c => c.CalledInNumber).LastOrDefault();
                var callerNumber = calls.Where(c => c.CalledCustomerId == ec.CustomerId && !string.IsNullOrEmpty(c.CallerNumber)).Select(c => c.CallerNumber).LastOrDefault();


                if (registeredBy != null)
                {
                    if (GetParentRoleIdByRoleId(roles, registeredBy.RoleId) != (long)Roles.CallCenterRep)
                    {
                        incomingLine = "";
                    }

                    if (GetParentRoleIdByRoleId(roles, registeredBy.RoleId) == (long)Roles.Customer)
                    {
                        agentRole = "Internet";
                        agentName = "";
                    }
                    else
                    {
                        agentRole = roles.Where(r => r.Id == registeredBy.RoleId).FirstOrDefault().DisplayName;
                        agentName = agentIdNamePairs.Where(ap => ap.FirstValue == registeredBy.Id).FirstOrDefault().SecondValue;

                        if (GetParentRoleIdByRoleId(roles, registeredBy.RoleId) == (long)Roles.CallCenterRep)
                        {
                            var isIncoming = calls.Where(c => c.CalledCustomerId == ec.CustomerId && c.CreatedByOrgRoleUserId == registeredBy.Id && c.EventId == ec.EventId).Select(c => c.IsIncoming).LastOrDefault();
                            if (isIncoming)
                            {
                                callType = "Inbound ";
                            }
                            else
                            {
                                callType = "Outbound";
                            }
                        }
                    }
                }
                var corporateCustomTags = "N/A";

                if (customTags != null && customTags.Any())
                {
                    var customerCustomTags = customTags.Where(ct => ct.CustomerId == customer.CustomerId).Select(ct => ct.Tag).ToArray();

                    if (customerCustomTags.Any())
                    {
                        corporateCustomTags = string.Join(",", customerCustomTags);
                    }
                }

                var shippingDetailIds = order == null ? new long[0] : order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Where(sdod => sdod.IsActive).Select(sdod => sdod.ShippingDetailId)).ToArray();

                var customerShippingDetails = shippingDetails.Where(sd => shippingDetailIds.Contains(sd.Id) && sd.ShippingOption.Id != (cdShippingOption != null ? cdShippingOption.Id : 0)).Select(sd => sd).ToArray();

                IEnumerable<string> customerShippingOptions = null;
                var shippingCost = 0.0m;
                if (customerShippingDetails != null && customerShippingDetails.Count() > 0)
                {
                    var shippingoptionIds = customerShippingDetails.Select(csd => csd.ShippingOption.Id).ToArray();
                    shippingCost = customerShippingDetails.Sum(sd => sd.ActualPrice);
                    customerShippingOptions = shippingOptions.Where(so => shippingoptionIds.Contains(so.Id)).Select(so => so.Name).ToArray();
                }
                else
                {
                    customerShippingOptions = new[] { "Online" };
                }

                var rescheduleApplointmentModels = new List<RescheduleApplointmentModel>();

                var eventCustomerReschedules = eventAppointmentChangeLogs.Where(eacl => eacl.EventCustomerId == ec.Id).Select(eacl => eacl).ToArray();

                if (eventCustomerReschedules != null && eventCustomerReschedules.Any())
                {

                    foreach (var ecr in eventCustomerReschedules)
                    {
                        var rescheduledBy = agents.Single(a => a.Id == ecr.CreatedByOrgRoleUserId);

                        var rescheduleAgentRole = roles.Single(r => r.Id == rescheduledBy.RoleId).DisplayName;
                        var rescheduleAgentName = agentIdNamePairs.Single(ap => ap.FirstValue == rescheduledBy.Id).SecondValue;

                        rescheduleApplointmentModels.Add(new RescheduleApplointmentModel()
                        {
                            RescheduledOn = ecr.DateCreated,
                            RescheduledBy = rescheduleAgentName + "(" + rescheduleAgentRole + ")",
                            Reason = ecr.ReasonId.HasValue && ecr.ReasonId > 0 ? ((RescheduleAppointmentReason)ecr.ReasonId.Value).GetDescription() : "N/A",
                            Notes = ecr.Notes,
                            SubReason = ecr.SubReasonId.HasValue && ecr.SubReasonId > 0 ? ((RescheduleAppointmentSubReason)ecr.SubReasonId.Value).GetDescription() : string.Empty,
                        });
                    }
                }

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == ec.CustomerId).Select(p => p).FirstOrDefault();

                var appointment = ec.AppointmentId.HasValue ? appointments.FirstOrDefault(a => a.Id == ec.AppointmentId.Value) : null;

                PcpAppointment pcpAppointment = null;

                if (!pcpAppointments.IsNullOrEmpty())
                    pcpAppointment = pcpAppointments.FirstOrDefault(x => x.EventCustomerId == ec.Id);

                var isEligible = "N/A";
                if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                {
                    if (customerEligibility.IsEligible.Value)
                        isEligible = EligibleStatus.Yes.ToString();
                    else
                        isEligible = EligibleStatus.No.ToString();
                }

                var groupName = "N/A";

                if (!string.IsNullOrEmpty(customer.GroupName))
                {
                    groupName = customer.GroupName;
                }
                var status = (appointment != null && appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue) ? "Availed" : "Not Availed";

                var apptModel = new HourlyAppointmentBookedModel
                {
                    CustomerId = ec.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    EventId = ec.EventId.ToString(),
                    RecommendPackage = eventModel.RecommendPackage ? "Yes" : "No",
                    MedicareAdvantagePlanName = string.IsNullOrEmpty(customer.MedicareAdvantagePlanName) ? "N/A" : customer.MedicareAdvantagePlanName,
                    RegistrationDate = ec.DataRecorderMetaData.DateCreated,
                    //RegistrationTime
                    RegistrationStatus = !ec.AppointmentId.HasValue ? "Cancelled" : string.Empty,
                    AppointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointment.StartTime : null,
                    Package = productPurchased,
                    ShippingOptions = customerShippingOptions,
                    ShippingCost = shippingCost,
                    ImagesPurchased = productCost.HasValue ? "Yes" : "No",
                    ImagesCost = productCost.HasValue ? productCost.Value : 0,
                    PackageCost = order == null ? 0 : order.UndiscountedTotal, // Need the Package Cost This includes CD also
                    TotalAmount = order == null ? 0 : order.DiscountedTotal,
                    AmountPaid = order == null ? 0 : order.TotalAmountPaid,
                    ReimbursementRate = remibursmentRateSum,
                    //PrePaid
                    Pod = eventModel.Pod,
                    PriortyCode = sourceCode,
                    PriortyCodeDiscount = sourceCodeDisc,
                    AdSource = ec.MarketingSource,
                    EventDate = eventModel.EventDate,
                    EventType = eventModel.EventType,

                    Host = eventModel.Location,
                    HostAddress = eventModel.Address,
                    SponsoredBy = string.IsNullOrEmpty(eventModel.CorporateAccount) && string.IsNullOrEmpty(eventModel.HospitalPartner) ? "N/A"
                    : (string.IsNullOrEmpty(eventModel.CorporateAccount) ? eventModel.HospitalPartner : eventModel.CorporateAccount),
                    IncomingPhoneLine = incomingLine,
                    CallersPhoneNumber = callerNumber,
                    LastScreeningDate = string.Empty,
                    RegisterationByRole = agentRole,
                    CallType = callType,
                    RegisteredBy = agentName,
                    RescheduleInfo = rescheduleApplointmentModels,
                    CheckInTime = (appointment != null && appointment.CheckInTime.HasValue) ? (DateTime?)appointment.CheckInTime.Value : null,
                    CheckOutTime = (appointment != null && appointment.CheckOutTime.HasValue) ? (DateTime?)appointment.CheckOutTime.Value : null,
                    Status = status,
                    Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                    CustomTag = corporateCustomTags,
                    PcpAppointmentDate = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null,
                    IsEligible = isEligible,
                    GroupName = groupName,
                    AdditionalFields = displayFielAandAdditionalFieldsPairs,
                };
                if (pcp != null)
                {
                    apptModel.PcpName = pcp.Name.FullName;
                    apptModel.PcpPhone = pcp.Primary != null ? pcp.Primary.ToString() : string.Empty;
                    apptModel.PcpFax = pcp.Fax != null ? pcp.Fax.ToString() : string.Empty;
                    apptModel.PcpNpi = pcp.Npi;
                }

                appointmentsBookedModels.Add(apptModel);
            };

            model.Collection = appointmentsBookedModels;
            return model;
        }

        private long GetParentRoleIdByRoleId(IEnumerable<Role> roles, long roleId)
        {
            if (roles.IsNullOrEmpty()) return roleId;
            var role = roles.FirstOrDefault(x => x.Id == roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

        private string GetCustomersAdditionFiledValue(Customer customer, AdditionalFieldsEnum additionalfiled)
        {
            switch (additionalfiled)
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