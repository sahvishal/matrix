using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;
using Call = Falcon.App.Core.CallCenter.Domain.Call;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class AppointmentsBookedModelFactory : IAppointmentsBookedModelFactory
    {
        //private readonly IKynHealthAssessmentHelper _healthAssessmentHelper;
        // private readonly IRoleRepository _roleRepository;

        //public AppointmentsBookedModelFactory()
        //{
        //    //_healthAssessmentHelper = healthAssessmentHelper;
        //   // _roleRepository = roleRepository;

        //}

        public AppointmentsBookedListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel, IEnumerable<Customer> customers,
                                                    IEnumerable<OrganizationRoleUser> agents, IEnumerable<Role> roles, IEnumerable<OrderedPair<long, string>> agentIdNamePairs, IEnumerable<SourceCode> sourceCodes, IEnumerable<Call> calls, IEnumerable<ShippingDetail> shippingDetails,
                                                    ShippingOption cdShippingOption, IEnumerable<ShippingOption> shippingOptions, IEnumerable<EventAppointmentChangeLog> eventAppointmentChangeLogs,
                                                    IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests, IEnumerable<Language> languages,
                                                    IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> accountAdditionalFields,
                                                    IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<CustomerPredictedZip> customerPredictedZips, IEnumerable<OrderedPair<long, string>> confirmedByAgentNameIdPairs,
                                                    IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var model = new AppointmentsBookedListModel();
            var appointmentsBookedModels = new List<AppointmentsBookedModel>();

            eventCustomers.ToList().ForEach(ec =>
                                                {
                                                    var eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == ec.EventId);

                                                    var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == ec.CustomerId);

                                                    var order = orders.FirstOrDefault(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId);

                                                    var productCost = order != null ? order.ProductCost : null;

                                                    var sourceCodeOrderDetail = order == null ? null : order.OrderDetails.Where(
                                                        od =>
                                                        od.SourceCodeOrderDetail != null &&
                                                        od.SourceCodeOrderDetail.IsActive).Select(od => od.SourceCodeOrderDetail).FirstOrDefault();

                                                    string sourceCode = string.Empty;
                                                    decimal sourceCodeDisc = 0;
                                                    if (sourceCodeOrderDetail != null)
                                                    {
                                                        var coupon = sourceCodes.FirstOrDefault(sc => sc.Id == sourceCodeOrderDetail.SourceCodeId);

                                                        sourceCode = coupon.CouponCode;
                                                        sourceCodeDisc = sourceCodeOrderDetail.Amount;
                                                    }

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
                                                                productPurchased = string.IsNullOrEmpty(productPurchased) ? string.Join(", ", testNames) : productPurchased + ", " + string.Join(", ", testNames);
                                                            }
                                                        }
                                                    }

                                                    var registeredBy = (ec.DataRecorderMetaData == null || ec.DataRecorderMetaData.DataRecorderCreator == null ? null : agents.Where(a => a.Id == ec.DataRecorderMetaData.DataRecorderCreator.Id).FirstOrDefault());
                                                    string agentName, agentRole, callType;
                                                    agentRole = agentName = callType = string.Empty;

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


                                                    //bool? isHafPrefilled = null;
                                                    //if (appointment != null)
                                                    //    isHafPrefilled = _healthAssessmentHelper.IsKynHafPrefilled(ec.EventId, ec.CustomerId, appointment.StartTime, false);

                                                    var isEligible = "N/A";
                                                    if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                                                    {
                                                        isEligible = customerEligibility.IsEligible.Value ? "Yes" : "No";
                                                    }
                                                    var groupName = "N/A";

                                                    if (!string.IsNullOrEmpty(customer.GroupName))
                                                    {
                                                        groupName = customer.GroupName;
                                                    }
                                                    var status = (appointment != null && appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue) ? "Availed" : "Not Availed";

                                                    var customerPredictedZip = customerPredictedZips != null ? customerPredictedZips.Where(x => x.CustomerId == customer.CustomerId) : null;

                                                    var confirmedByAgentName = ec.ConfirmedBy.HasValue && ec.ConfirmedBy.Value > 0 ? confirmedByAgentNameIdPairs.First(x => x.FirstValue == ec.ConfirmedBy.Value).SecondValue : string.Empty;

                                                    var apptModel = new AppointmentsBookedModel
                                                                        {
                                                                            Address = customer.Address,
                                                                            AmountPaid = order == null ? 0 : order.TotalAmountPaid,
                                                                            AppointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointment.StartTime : null,
                                                                            CustomerId = ec.CustomerId,
                                                                            CustomerCode = customer.CustomerId.ToString(),
                                                                            CustomerName = customer.NameAsString,
                                                                            RequestedNewsLetter = customer.RequestForNewsLetter ? "Yes" : "No",
                                                                            DateofBirth = customer.DateOfBirth,
                                                                            Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                                                                            EventDate = eventModel.EventDate,
                                                                            Gender = customer.Gender.ToString(),
                                                                            Host = eventModel.Location,
                                                                            HostAddress = eventModel.Address,
                                                                            Package = productPurchased,
                                                                            PackageCost = order == null ? 0 : order.UndiscountedTotal, // Need the Package Cost This includes CD also
                                                                            PhoneBusiness = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.ToString() : string.Empty,
                                                                            PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : string.Empty,
                                                                            PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                                                                            RegistrationDate = ec.DataRecorderMetaData.DateCreated,
                                                                            RegistrationStatus = !ec.AppointmentId.HasValue ? "Cancelled" : string.Empty,
                                                                            IsConfirmed = ec.IsAppointmentConfirmed ? "Yes" : "No",
                                                                            ConfirmedBy = confirmedByAgentName,
                                                                            Pod = eventModel.Pod,
                                                                            TotalAmount = order == null ? 0 : order.DiscountedTotal,
                                                                            PriortyCode = sourceCode,//
                                                                            PriortyCodeDiscount = sourceCodeDisc,
                                                                            RegisteredBy = agentName,
                                                                            AdSource = ec.MarketingSource,
                                                                            EventType = eventModel.EventType,
                                                                            RegisterationByRole = agentRole,
                                                                            IncomingPhoneLine = incomingLine,
                                                                            CallersPhoneNumber = callerNumber,
                                                                            PhoneOfficeExtension = customer.PhoneOfficeExtension,
                                                                            LastScreeningDate = string.Empty,
                                                                            ShippingOptions = customerShippingOptions,
                                                                            ShippingCost = shippingCost,
                                                                            ImagesPurchased = productCost.HasValue ? "Yes" : "No",
                                                                            ImagesCost = productCost.HasValue ? productCost.Value : 0,
                                                                            InsuranceId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                                                                            Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                                                                            MedicareAdvantageNumber = string.IsNullOrEmpty(customer.MedicareAdvantageNumber) ? "N/A" : customer.MedicareAdvantageNumber,
                                                                            MedicareAdvantagePlanName = string.IsNullOrEmpty(customer.MedicareAdvantagePlanName) ? "N/A" : customer.MedicareAdvantagePlanName,
                                                                            RescheduleInfo = rescheduleApplointmentModels,
                                                                            SsnCaptured = string.IsNullOrEmpty(customer.Ssn) ? "No" : "Yes",
                                                                            SponsoredBy = string.IsNullOrEmpty(eventModel.CorporateAccount) && string.IsNullOrEmpty(eventModel.HospitalPartner) ? "N/A"
                                                                            : (string.IsNullOrEmpty(eventModel.CorporateAccount) ? eventModel.HospitalPartner : eventModel.CorporateAccount),
                                                                            CheckInTime = (appointment != null && appointment.CheckInTime.HasValue) ? (DateTime?)appointment.CheckInTime.Value : null,
                                                                            CheckOutTime = (appointment != null && appointment.CheckOutTime.HasValue) ? (DateTime?)appointment.CheckOutTime.Value : null,
                                                                            Status = status,
                                                                            EventId = ec.EventId.ToString(),
                                                                            Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                                                                            CustomTag = corporateCustomTags,
                                                                            ReimbursementRate = remibursmentRateSum,
                                                                            RecommendPackage = eventModel.RecommendPackage ? "Yes" : "No",
                                                                            //HafStatus = isHafPrefilled.HasValue ? (isHafPrefilled.Value ? "Filled" : "Not Filled") : "N/A"
                                                                            PcpAppointmentDate = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null,
                                                                            Language = customerLanguage,
                                                                            Market = string.IsNullOrEmpty(customer.Market) ? "N/A" : customer.Market,
                                                                            IsEligible = isEligible,
                                                                            GroupName = groupName,
                                                                            AdditionalFields = displayFielAandAdditionalFieldsPairs,
                                                                            CallType = callType,
                                                                            PredictedZip = customerPredictedZip != null ? string.Join(", ", customerPredictedZip.Select(x => x.PredictedZip)) : "N/A",
                                                                            PreferredContactType = ec.PreferredContactType.HasValue && ec.PreferredContactType.Value > 0 ? ((PreferredContactType)ec.PreferredContactType).GetDescription() : "N/A",
                                                                            Product=customer.ProductTypeId.HasValue && customer.ProductTypeId.Value > 0 ? ((ProductType)customer.ProductTypeId.Value).GetDescription() : "N/A",
                                                                        };
                                                    if (pcp != null)
                                                    {
                                                        apptModel.PcpName = pcp.Name.FullName;
                                                        apptModel.PcpPhone = pcp.Primary != null ? pcp.Primary.ToString() : string.Empty;
                                                        apptModel.PcpFax = pcp.Fax != null ? pcp.Fax.ToString() : string.Empty;
                                                        apptModel.PcpNpi = pcp.Npi;
                                                    }

                                                    appointmentsBookedModels.Add(apptModel);
                                                });

            //if (appointmentsBookedModels != null) appointmentsBookedModels = appointmentsBookedModels.OrderBy(a => a.RegistrationDate).ToList();

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
