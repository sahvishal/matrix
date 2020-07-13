using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Marketing.Domain;
using DateTime = System.DateTime;


namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class MemberStatusModelFactory : IMemberStatusModelFactory
    {
        public MemberStatusListModel Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Order> orders,
            IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests, IEnumerable<Core.CallCenter.Domain.Call> calls,
            IEnumerable<CorporateCustomerCustomTag> customTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<Notes> doNotContactReasonNotes,
            IEnumerable<OrderedPair<long, string>> customersPreApprovedTests, IEnumerable<OrderedPair<long, string>> customersPreApprovedPackages,
            IEnumerable<DirectMail> directMails, IEnumerable<Appointment> appointments, IEnumerable<ShippingDetail> shipingDetails,
            IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<ShippingOption> shippingOptions, ShippingOption pcpShippingOptions,
            IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<AccountAdditionalFields> accountAdditionalFields, DateTime fromDate, DateTime toDate,
            IEnumerable<ProspectCustomer> prospectCustomers, IEnumerable<CustomerPredictedZip> customerPredictedZips, IEnumerable<CustomerEligibility> customerEligibilityList,
            IEnumerable<CustomerTargeted> customerTargetedList, IEnumerable<Core.Medical.Domain.ActivityType> activityTypes)
        {
            var model = new MemberStatusListModel();
            var memberStatusModels = new List<MemberStatusModel>();

            foreach (var customer in customers)
            {
                var customerCalls = calls.Where(c => c.CalledCustomerId == customer.CustomerId);
                var callDetail = customerCalls.OrderByDescending(x => x.CallDateTime).FirstOrDefault();
                var customerDirectMails = directMails.Where(x => x.CustomerId == customer.CustomerId);
                var customerPredictedZip = customerPredictedZips != null ? customerPredictedZips.Where(x => x.CustomerId == customer.CustomerId) : null;
                var customerEligibility = customerEligibilityList.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                var customerTargeted = customerTargetedList.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                var isEligible = "N/A";

                var corporateCustomTags = "N/A";

                if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
                {
                    isEligible = customerEligibility.IsEligible.Value ? "Yes" : "No";
                }

                var prospectCustomer = prospectCustomers.FirstOrDefault(p => p.CustomerId == customer.CustomerId);

                if (customTags != null && customTags.Any())
                {
                    var customerCustomTags = customTags.Where(ct => ct.CustomerId == customer.CustomerId).Select(ct => ct.Tag).ToArray();

                    if (customerCustomTags.Any())
                    {
                        corporateCustomTags = string.Join(", ", customerCustomTags);
                    }
                }

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == customer.CustomerId).Select(p => p).FirstOrDefault();

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

                string activityType = "N/A";
                if (customer.ActivityId.HasValue && !activityTypes.IsNullOrEmpty())
                    activityType = activityTypes.Single(x => x.Id == customer.ActivityId.Value).Name;

                var isTargetedMember = "N/A";
                if (customerTargeted != null && customerTargeted.IsTargated.HasValue)
                {
                    isTargetedMember = customerTargeted.IsTargated.Value ? "Yes" : "No";
                }

                var customerExportModel = new MemberStatusModel
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
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                    MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    IsEligible = isEligible,
                    IsTargetedMember = isTargetedMember,
                    CustomTag = corporateCustomTags,
                    MedicarePlanName = string.IsNullOrEmpty(customer.MedicareAdvantagePlanName) ? "N/A" : customer.MedicareAdvantagePlanName,
                    Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                    Mbi = string.IsNullOrEmpty(customer.Mbi) ? "N/A" : customer.Mbi,
                    Market = string.IsNullOrEmpty(customer.Market) ? "N/A" : customer.Market,
                    GroupName = string.IsNullOrEmpty(customer.GroupName) ? "N/A" : customer.GroupName,
                    PreApprovedTest = customerPreApprovedTest,
                    PreApprovedPackage = customerPreApprovedPakages,
                    AdditionalFields = displayFielAandAdditionalFieldsPairs,
                    Activity = activityType,
                    PredictedZip = customerPredictedZip != null ? string.Join(", ", customerPredictedZip.Select(x => x.PredictedZip)) : "N/A",
                    AcesId = customer.AcesId,
                    Product=customer.ProductTypeId.HasValue && customer.ProductTypeId.Value > 0 ? ((ProductType)customer.ProductTypeId.Value).GetDescription() : "N/A"
                };

                GetRestrictionData(customerExportModel, customer, fromDate, toDate, doNotContactReasonNotes);

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

                EventCustomer eventCustomer = null;
                EventVolumeModel eventModel = null;
                EventVolumeModel lastScreeningDate = null;

                var scheduledStatus = ScheduledStatus.NotScheduled;
                if (eventCustomers != null && eventCustomers.Any())
                {
                    //var startDate = new DateTime(DateTime.Today.Year, 1, 1);
                    //var endDate = new DateTime(DateTime.Today.Year, 12, 31);

                    eventCustomer = (from ec in eventCustomers
                                     join e in eventListModel.Collection on ec.EventId equals e.EventCode
                                     where ec.CustomerId == customer.CustomerId
                                     orderby e.EventDate descending
                                     select ec).FirstOrDefault();

                    var appointmentIds = eventCustomers.Where(ec => ec.AppointmentId.HasValue && ec.CustomerId == customer.CustomerId).Select(x => x.AppointmentId.Value).ToArray();


                    var hasBeenScheduledForCurrentyear = (from ec in eventCustomers
                                                          join e in eventListModel.Collection on ec.EventId equals e.EventCode
                                                          where ec.CustomerId == customer.CustomerId
                                                          select ec).Any();

                    lastScreeningDate = (from a in appointments
                                         join e in eventListModel.Collection on a.EventId equals e.EventCode
                                         join ec in eventCustomers on e.EventCode equals ec.EventId
                                         where a.CheckInTime != null && a.CheckOutTime != null && appointmentIds.Contains(a.Id) && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue
                                         orderby e.EventDate descending
                                         select e).FirstOrDefault();

                    if (hasBeenScheduledForCurrentyear)
                        scheduledStatus = ScheduledStatus.Scheduled;

                    if (eventCustomer != null)
                    {
                        if (shipingDetails != null && shipingDetails.Any())
                        {
                            var shipingIds = shippingDetailIdEventCustomerIdPairs.Where(m => m.SecondValue == eventCustomer.Id).Select(m => m.FirstValue);
                            if (shipingIds != null && shipingIds.Any())
                            {

                                var shipingDetail = shipingDetails.Where(m => shipingIds.Contains(m.Id) && m.Status == ShipmentStatus.Shipped);
                                if (shipingDetail != null && shipingDetail.Any())
                                {
                                    var customerResultShipDetail = (from s in shipingDetail
                                                                    join so in shippingOptions on s.ShippingOption.Id equals so.Id
                                                                    orderby s.ShipmentDate descending
                                                                    select s).FirstOrDefault();

                                    var pcpResultShipDetail = (from s in shipingDetail
                                                               where s.ShippingOption.Id == pcpShippingOptions.Id
                                                               select s).FirstOrDefault();
                                    if (pcpResultShipDetail != null)
                                    {
                                        customerExportModel.PCPResultShipedDate = pcpResultShipDetail.ShipmentDate;
                                    }

                                    if (customerResultShipDetail != null)
                                    {
                                        customerExportModel.CustomerResultShipedDate = customerResultShipDetail.ShipmentDate;
                                    }
                                }
                            }
                        }


                        var order = orders.FirstOrDefault(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);
                        if (order != null)
                        {
                            var package = packages.FirstOrDefault(p => p.FirstValue == order.Id);

                            var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                            var productPurchased = string.Empty;

                            if (package != null && !test.IsNullOrEmpty())
                                productPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                            else if (!test.IsNullOrEmpty())
                                productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                            else if (package != null)
                                productPurchased = package.SecondValue;

                            customerExportModel.Package = productPurchased;
                        }

                        eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == eventCustomer.EventId);
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
                            customerExportModel.CompletionStatus = GetCompletionStatus(eventCustomer, eventModel.EventDate, lastScreeningDate);
                            customerExportModel.RegistrationDate = eventCustomer.DataRecorderMetaData.DateCreated;
                        }
                    }
                }

                customerExportModel.CurrentStatus = GetCurrentStatus(customer, customerDirectMails, eventCustomer, eventModel, lastScreeningDate, prospectCustomer, fromDate, toDate, customerEligibility);
                customerExportModel.ScheduledStatus = scheduledStatus;

                if (callDetail != null)
                {
                    int? dispositionId = null;
                    if (!string.IsNullOrEmpty(callDetail.Disposition))
                    {
                        ProspectCustomerTag tag;
                        Enum.TryParse(callDetail.Disposition, true, out tag);

                        dispositionId = (int)tag;
                    }

                    customerExportModel.CurrentOutboundCallOutcome = ((CallStatus)callDetail.Status).GetDescription();

                    if (dispositionId.HasValue)
                        customerExportModel.CurrentOutboundCallDisposition = ((ProspectCustomerTag)dispositionId.Value).GetDescription();

                    customerExportModel.CurrentOutboundCallCategory = GetCallCategoryByStatus(callDetail.Status, dispositionId);
                }

                SetReportModelOutReachType(customerExportModel, customerCalls, customerDirectMails, customer.CustomerId);

                memberStatusModels.Add(customerExportModel);
            }

            model.Collection = memberStatusModels;
            return model;
        }

        private void GetRestrictionData(MemberStatusModel model, Customer customer, DateTime fromDate, DateTime toDate, IEnumerable<Notes> doNotContactReasonNotes)
        {
            model.RestrictionStatus = "N/A";
            model.DoNotContactReason = "N/A";
            model.DoNotContactReasonNote = string.Empty;

            if (IsCustomerMarkedDonotContact(customer, fromDate, toDate))
            {
                if (customer.DoNotContactTypeId.HasValue)
                {
                    model.RestrictionStatus = ((DoNotContactType)customer.DoNotContactTypeId.Value).GetDescription();
                }

                if (customer.DoNotContactReasonId.HasValue)
                {
                    model.DoNotContactReason = ((DoNotContactReason)customer.DoNotContactReasonId.Value).GetDescription();
                }

                if (customer.DoNotContactReasonNotesId.HasValue)
                {
                    model.DoNotContactReasonNote = doNotContactReasonNotes.First(x => x.Id == customer.DoNotContactReasonNotesId).Text;
                }
            }
        }

        private bool IsCustomerMarkedDonotContact(Customer customer, DateTime fromDate, DateTime toDate)
        {
            return customer.DoNotContactUpdateDate.HasValue && customer.DoNotContactUpdateDate >= fromDate && customer.DoNotContactUpdateDate <= toDate.AddDays(1);
        }

        private string GetCallCategoryByStatus(long callStatus, int? disposition)
        {
            switch ((CallStatus)callStatus)
            {
                case CallStatus.VoiceMessage:
                case CallStatus.NoAnswer:
                    return CurrentOutboundCallCategory.InProgress;
                case CallStatus.IncorrectPhoneNumber:
                    return CurrentOutboundCallCategory.InvalidData;
                case CallStatus.TalkedtoOtherPerson:
                    {
                        if (disposition.HasValue && ((ProspectCustomerTag)disposition) == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers)
                            return CurrentOutboundCallCategory.InvalidData;
                        return string.Empty;
                    }
                case CallStatus.NoEventsInArea:
                    return CurrentOutboundCallCategory.UnabletoSchedule;
                case CallStatus.Attended:
                case CallStatus.LeftMessageWithOther:
                    {
                        if (disposition.HasValue && ((ProspectCustomerTag)disposition) == ProspectCustomerTag.LeftMessage)
                            return CurrentOutboundCallCategory.InProgress;
                        if (disposition.HasValue)
                            return GetCallCategoryForAttended(disposition.Value);
                    }

                    return string.Empty;
            }

            return string.Empty;
        }

        private string GetCallCategoryForAttended(int disposition)
        {
            switch ((ProspectCustomerTag)disposition)
            {
                case ProspectCustomerTag.CallBackLater:
                case ProspectCustomerTag.SpeakWithPhysician:
                    return CurrentOutboundCallCategory.InProgress;
                case ProspectCustomerTag.BookedAppointment:
                    return CurrentOutboundCallCategory.Scheduled;
                case ProspectCustomerTag.NoEventsInTheArea:
                case ProspectCustomerTag.DateTimeConflict:
                case ProspectCustomerTag.HomeVisitRequested:
                case ProspectCustomerTag.MobilityIssue:
                case ProspectCustomerTag.TransportationIssue:
                case ProspectCustomerTag.NoLongeronInsurancePlan:
                case ProspectCustomerTag.MovedRelocated:
                case ProspectCustomerTag.InLongTermCareNursingHome:
                case ProspectCustomerTag.LanguageBarrier:
                case ProspectCustomerTag.MobilityIssues_LeftMessageWithOther:
                case ProspectCustomerTag.DebilitatingDisease:
                case ProspectCustomerTag.Deceased:

                    return CurrentOutboundCallCategory.UnabletoSchedule;
                case ProspectCustomerTag.NotInterested:
                // case ProspectCustomerTag.RecentlySawDoc:
                case ProspectCustomerTag.DoNotCall:
                    return CurrentOutboundCallCategory.Refusal;
            }
            return string.Empty;
        }

        private string GetCompletionStatus(EventCustomer eventCustomer, DateTime eventDate, EventVolumeModel lastScreeningEvent)
        {
            if (eventCustomer.NoShow)
            {
                return CompletionStatus.NoShow;
            }

            if (eventCustomer.LeftWithoutScreeningReasonId.HasValue)
            {
                return CompletionStatus.LeftWithoutScreening;
            }

            if (!eventCustomer.AppointmentId.HasValue)
            {
                return CompletionStatus.Cancellation;
            }

            if (eventDate.Date > DateTime.Today)
            {
                return CompletionStatus.FutureAppointment;
            }

            if (lastScreeningEvent != null && lastScreeningEvent.EventCode == eventCustomer.EventId)
            {
                return CompletionStatus.Completed;
            }

            if (eventDate.Date == DateTime.Today)
            {
                return CompletionStatus.ScheduledForToday;
            }

            return string.Empty;
        }

        private void SetReportModelOutReachType(MemberStatusModel customerExportModel, IEnumerable<Core.CallCenter.Domain.Call> calls, IEnumerable<DirectMail> directMails, long customerId)
        {
            customerExportModel.TotalDirectMailCount = directMails.Count();
            customerExportModel.TotalInboundCallCount = calls.Count(x => x.IsIncoming);
            customerExportModel.TotalOutboundCallCount = calls.Count(x => !x.IsIncoming);

            var directMailOutReach = directMails.OrderByDescending(x => x.MailDate).Take(5)
                                       .Select(x => new OutreachCallReportModel
                                       {
                                           CustomerId = x.CustomerId,
                                           OutreachType = "Direct Mail",
                                           OutreachDate = x.MailDate,
                                       }).ToArray();

            var outboundOutReach = calls.Where(c => !c.IsIncoming)
                                    .OrderByDescending(x => x.CallDateTime).Take(5)
                                    .Select(x => new OutreachCallReportModel
                                    {
                                        CustomerId = x.CalledCustomerId,
                                        OutreachType = "Outbound",
                                        OutreachDate = x.CallDateTime,
                                    }).ToArray();

            if (!directMailOutReach.IsNullOrEmpty())
            {
                var outreachCallReportModel = directMailOutReach.ElementAtOrDefault(0);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.DirectMailDate1 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = directMailOutReach.ElementAtOrDefault(1);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.DirectMailDate2 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = directMailOutReach.ElementAtOrDefault(2);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.DirectMailDate3 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = directMailOutReach.ElementAtOrDefault(3);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.DirectMailDate4 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = directMailOutReach.ElementAtOrDefault(4);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.DirectMailDate5 = outreachCallReportModel.OutreachDate;
                }
            }

            if (!outboundOutReach.IsNullOrEmpty())
            {
                var outreachCallReportModel = outboundOutReach.ElementAtOrDefault(0);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.OutreachCallDate1 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = outboundOutReach.ElementAtOrDefault(1);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.OutreachCallDate2 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = outboundOutReach.ElementAtOrDefault(2);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.OutreachCallDate3 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = outboundOutReach.ElementAtOrDefault(3);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.OutreachCallDate4 = outreachCallReportModel.OutreachDate;
                }

                outreachCallReportModel = outboundOutReach.ElementAtOrDefault(4);

                if (outreachCallReportModel != null)
                {
                    customerExportModel.OutreachCallDate5 = outreachCallReportModel.OutreachDate;
                }
            }

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

        private string GetCurrentStatus(Customer customer, IEnumerable<DirectMail> directMails, EventCustomer eventCustomer,
            EventVolumeModel eventModel, EventVolumeModel lastScreeningEvent, ProspectCustomer prospectCustomer, DateTime fromDate, DateTime toDate, CustomerEligibility customerEligibility)
        {

            if (eventCustomer != null && eventCustomer.NoShow)
            {
                return CurrentStatus.NoShow;
            }

            if (eventModel != null && eventModel.EventDate.Date >= DateTime.Today && (eventCustomer != null && eventCustomer.AppointmentId.HasValue))
            {
                return CurrentStatus.ScheduledFutureAppointment;
            }

            //if (eventModel != null && eventModel.EventDate.Date == DateTime.Today && (eventCustomer != null && eventCustomer.AppointmentId.HasValue))
            //{
            //    return CompletionStatus.ScheduledForToday;
            //}

            if (lastScreeningEvent != null)
            {
                return CurrentStatus.ScheduledTestingComplete;
            }

            if (eventCustomer != null && !eventCustomer.AppointmentId.HasValue)
            {
                return CurrentStatus.ScheduledCancelled;
            }

            if (customer.IsIncorrectPhoneNumber)
            {
                return CurrentStatus.InvalidData;
            }

            if (CheckCustomerUnableToSchedule(prospectCustomer, fromDate, toDate, customerEligibility))
            {
                return CurrentStatus.UnableToSchedule;
            }

            if (CheckCustomerRefusal(prospectCustomer, fromDate, toDate) || IsCustomerMarkedDonotContact(customer, fromDate, toDate))
            {
                return CurrentStatus.Refusal;
            }

            if (directMails != null && directMails.Count() > 4)
            {
                var customerDirectMail = directMails.OrderByDescending(dm => dm.MailDate).FirstOrDefault();
                if (customerDirectMail.MailDate.AddDays(28) < DateTime.Today)
                {
                    return CurrentStatus.Exhausted;
                }
            }

            return CurrentStatus.InProgress;
        }

        private bool CheckCustomerRefusal(ProspectCustomer prospectCustomer, DateTime fromDate, DateTime toDateTime)
        {
            return (prospectCustomer != null && prospectCustomer.TagUpdateDate >= fromDate && prospectCustomer.TagUpdateDate <= toDateTime && (prospectCustomer.Tag == ProspectCustomerTag.RecentlySawDoc));
        }

        private bool CheckCustomerUnableToSchedule(ProspectCustomer prospectCustomer, DateTime from, DateTime todDate, CustomerEligibility customerEligibility)
        {
            if (prospectCustomer != null && (prospectCustomer.Tag == ProspectCustomerTag.Deceased))
            {
                return true;
            }

            if (customerEligibility == null || !customerEligibility.IsEligible.HasValue || !customerEligibility.IsEligible.Value)
            {
                return true;
            }

            return (prospectCustomer != null && ((prospectCustomer.TagUpdateDate.HasValue && prospectCustomer.TagUpdateDate.Value >= from && prospectCustomer.TagUpdateDate.Value <= todDate) && (prospectCustomer.Tag == ProspectCustomerTag.HomeVisitRequested ||
                                                  prospectCustomer.Tag == ProspectCustomerTag.MobilityIssue ||
                                                  prospectCustomer.Tag == ProspectCustomerTag.NoLongeronInsurancePlan)));
        }

    }
}