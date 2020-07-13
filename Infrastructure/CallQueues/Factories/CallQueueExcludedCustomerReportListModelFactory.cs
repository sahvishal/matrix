
using System.Runtime.InteropServices;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class CallQueueExcludedCustomerReportListModelFactory : ICallQueueExcludedCustomerReportListModelFactory
    {
        public CallQueueExcludedCustomerReportListModel Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> customTags,
            IEnumerable<ProspectCustomer> prospectCustomers, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<OrganizationRoleUser> orgRoleUsers,
            IEnumerable<User> users, IEnumerable<CallQueueCustomerCriteraAssignmentForStats> callQueueCustomers, IEnumerable<long> healthPlanZipIdPairs, CorporateAccount account,
            IEnumerable<AccountCallQueueSetting> callQueueSettings, IEnumerable<CustomerEligibility> customerEligibilityCollection, IEnumerable<CustomerTargeted> targetedCustomers)
        {
            var model = new CallQueueExcludedCustomerReportListModel();
            var collection = new List<CallQueueExcludedCustomerReportModel>();

            customers.ToList().ForEach(c =>
            {
                var customerTag = "N/A";
                if (customTags != null && customTags.Any())
                {
                    var customTag = (from ct in customTags where ct.CustomerId == c.CustomerId select ct.Tag).ToArray();

                    if (customTag != null && customTag.Any())
                    {
                        customerTag = string.Join(", ", customTag);
                    }
                }

                var reasons = "N/A";
                CallQueueCustomerCriteraAssignmentForStats callQueueCustomer = null;
                if (!callQueueCustomers.IsNullOrEmpty())
                {
                    callQueueCustomer = callQueueCustomers.FirstOrDefault(x => x.CustomerId == c.CustomerId);
                }
                var customerEligibility = customerEligibilityCollection.FirstOrDefault(x => x.CustomerId == c.CustomerId);
                var targetedCustomer = !targetedCustomers.IsNullOrEmpty() ? targetedCustomers.FirstOrDefault(x => x.CustomerId == c.CustomerId) : null;
                var reasonList = GetReasons(c, prospectCustomers, eventCustomers, events, orgRoleUsers, users, callQueueCustomer, healthPlanZipIdPairs, account, callQueueSettings, customerEligibility, targetedCustomer).ToArray();
                if (reasonList != null && reasonList.Any())
                {

                    if (reasonList != null && reasonList.Any())
                    {
                        reasons = string.Join(", ", reasonList);
                    }
                }
                var customerZipCode = "N/A";
                if (c.Address != null)
                {
                    if (c.Address.ZipCode != null)
                        customerZipCode = c.Address.ZipCode.ToString();
                }
                var callQueueExcludedCustomerReportModel = new CallQueueExcludedCustomerReportModel
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    MemberId = (!string.IsNullOrEmpty(c.InsuranceId)) ? c.InsuranceId : "N/A",
                    ZipCode = customerZipCode,
                    Tag = (!string.IsNullOrEmpty(c.Tag)) ? c.Tag : "N/A",
                    CustomTags = customerTag,
                    Reason = reasons
                };

                collection.Add(callQueueExcludedCustomerReportModel);
            });


            model.Collection = collection;
            return model;
        }

        private void SetReasonsForCampaign(List<string> resons, Customer customer, CallQueueCustomerCriteraAssignmentForStats callQueueCustomer, IEnumerable<long> healthPlanZipIdPairs, CorporateAccount account, IEnumerable<AccountCallQueueSetting> callQueueSetting)
        {
            var notInterested = ProspectCustomerTag.NotInterested.ToString();
            var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
            var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();

            var othersDays = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.Others)).NoOfDays;
            var leftVoiceMail = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.LeftVoiceMail)).NoOfDays;
            var refuseCustomer = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.RefuseCustomer)).NoOfDays;

            var othersFilterDate = DateTime.Today.AddDays(-(othersDays - 1));
            var leftVoiceMailDate = DateTime.Today.AddDays(-(leftVoiceMail - 1));
            var refusalDate = DateTime.Today.AddDays(-(refuseCustomer - 1));
            var firstDayOfYear = new DateTime(DateTime.Today.Year, 1, 1);

            var isHealtPlanLevel = false;
            var maxAttempt = 0;
            if (account.MaxAttempt.HasValue)
            {
                isHealtPlanLevel = true;
                maxAttempt = account.MaxAttempt.Value;
            }
            else
            {
                maxAttempt = callQueueSetting.FirstOrDefault(x => x.SuppressionTypeId == (long)CallQueueSuppressionType.MaxAttempts).NoOfDays;
            }

            if (callQueueCustomer != null)
            {
                if (!healthPlanZipIdPairs.IsNullOrEmpty() && !healthPlanZipIdPairs.Contains(customer.Address.ZipCode.Id))
                {
                    resons.Add("No Event In Area");
                }

                if (isHealtPlanLevel && callQueueCustomer.CallCount >= maxAttempt)
                {
                    resons.Add("Max Attempt");
                }
                else if (callQueueCustomer.Attempts >= maxAttempt)
                {
                    resons.Add("Max Attempt");
                }

                if (callQueueCustomer.IsLanguageBarrier && callQueueCustomer.LanguageBarrierMarkedDate >= firstDayOfYear)
                {
                    resons.Add("Marked Language Barrier");
                }

                if (callQueueCustomer.Disposition == ProspectCustomerTag.CallBackLater.ToString() && callQueueCustomer.CallBackRequestedDate > DateTime.Now)
                {
                    resons.Add("Requested for Callback on " + callQueueCustomer.CallBackRequestedDate.ToShortDateString() + " at " + callQueueCustomer.CallBackRequestedDate.ToShortTimeString()); ;
                }

                if (callQueueCustomer.AppointmentCancellationDate >= othersFilterDate)
                {
                    resons.Add("Appointment Canceled on " + callQueueCustomer.AppointmentCancellationDate.ToString("MM/dd/yyyy"));
                }

                if (callQueueCustomer.ContactedDate >= leftVoiceMailDate && callQueueCustomer.CallStatus == (long)CallStatus.VoiceMessage)
                {
                    resons.Add("Marked left Voice Mail on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                }

                if (callQueueCustomer.ContactedDate >= refusalDate &&
                    (callQueueCustomer.CallStatus != (long)CallStatus.CallSkipped && callQueueCustomer.CallStatus != (long)CallStatus.VoiceMessage)
                    && (callQueueCustomer.Disposition == notInterested || callQueueCustomer.Disposition == recentlySawDoc || callQueueCustomer.Disposition == transportationIssue))
                {

                    resons.Add("Marked " + GetDisposition(callQueueCustomer.Disposition) + " on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                }

                if (callQueueCustomer.ContactedDate >= othersFilterDate && (callQueueCustomer.Disposition != ProspectCustomerTag.CallBackLater.ToString() && callQueueCustomer.Disposition != (ProspectCustomerTag.LanguageBarrier.ToString())))
                {
                    if (callQueueCustomer.CallStatus == (long)CallStatus.CallSkipped)
                    {
                        resons.Add("Marked Call Skipped on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else if (callQueueCustomer.CallStatus == (long)CallStatus.NoAnswer)
                    {
                        resons.Add("Marked Call No Answer on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else if (callQueueCustomer.CallStatus == (long)CallStatus.Initiated)
                    {
                        resons.Add("Left call without saving outcome/disposition on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else if (callQueueCustomer.CallStatus == (long)CallStatus.NoEventsInArea)
                    {
                        resons.Add("Marked No Event In Area on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else if (callQueueCustomer.CallStatus == (long)CallStatus.LeftMessageWithOther)
                    {
                        resons.Add("Marked Left Message With Others on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else if (callQueueCustomer.CallStatus == (long)CallStatus.Attended)
                    {
                        if (!string.IsNullOrEmpty(callQueueCustomer.Disposition))
                            resons.Add("Marked " + GetDisposition(callQueueCustomer.Disposition) + " on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else if (callQueueCustomer.CallStatus == (long)CallStatus.InvalidNumber)
                    {
                        resons.Add("Marked Invalid Number on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(callQueueCustomer.Disposition))
                            resons.Add("Marked " + GetDisposition(callQueueCustomer.Disposition) + " on " + callQueueCustomer.ContactedDate.ToString("MM/dd/yyyy"));
                    }
                }

                if (callQueueCustomer.TargetedYear != DateTime.Today.Year || callQueueCustomer.IsTargeted == false)
                {
                    resons.Add("Non-Targeted Customer");
                }
            }
        }

        private string GetDisposition(string disposition)
        {
            ProspectCustomerTag tag;

            // Call Enum.TryParse method.
            if (Enum.TryParse(disposition, out tag))
            {
                if (Enum.IsDefined(typeof(ProspectCustomerTag), tag) && tag != ProspectCustomerTag.Unspecified)
                {
                    return tag.GetDescription();
                }
            }
            return string.Empty;
        }

        private List<string> GetReasons(Customer customer, IEnumerable<ProspectCustomer> prospectCustomers,
            IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<User> users,
            CallQueueCustomerCriteraAssignmentForStats callQueueCustomer, IEnumerable<long> healthPlanZipIdPairs, CorporateAccount account,
            IEnumerable<AccountCallQueueSetting> callQueueSettings, CustomerEligibility customerEligibility, CustomerTargeted customerTargeted)
        {
            var resons = new List<string>();

            var orgRoleUser = orgRoleUsers.Where(x => x.Id == customer.CustomerId).FirstOrDefault();


            var firstDayOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            if (orgRoleUser != null)
            {
                var user = users.Where(x => x.Id == orgRoleUser.UserId).FirstOrDefault();
                if (user != null && (string.IsNullOrEmpty(user.HomePhoneNumber.Number) && string.IsNullOrEmpty(user.HomePhoneNumber.Number) && string.IsNullOrEmpty(user.MobilePhoneNumber.Number)))
                {
                    resons.Add("Phone Number is not available");
                }
            }

            var prospectCustomer = prospectCustomers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();

            if (prospectCustomer != null)
            {

                var homeVisitRequested = ProspectCustomerTag.HomeVisitRequested.ToString();
                var doNotContact = ProspectCustomerTag.DoNotCall.ToString();
                var deceased = ProspectCustomerTag.Deceased.ToString();
                var mobilityIssue = ProspectCustomerTag.MobilityIssue.ToString();
                var inLongTermCareNursingHome = ProspectCustomerTag.InLongTermCareNursingHome.ToString();
                var mobilityIssue_LeftMessageWithOther = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString();
                var debilitatingDisease = ProspectCustomerTag.DebilitatingDisease.ToString();
                var noLongeronInsurancePlan = ProspectCustomerTag.NoLongeronInsurancePlan.ToString();

                var refusedCustomerTag = prospectCustomer.Tag.ToString();

                if (refusedCustomerTag == deceased || ((!prospectCustomer.ContactedDate.HasValue || prospectCustomer.ContactedDate.Value.Year == firstDayOfYear.Year) &&
                    (refusedCustomerTag == homeVisitRequested || refusedCustomerTag == doNotContact || refusedCustomerTag == mobilityIssue || refusedCustomerTag == inLongTermCareNursingHome ||
                    refusedCustomerTag == mobilityIssue_LeftMessageWithOther || refusedCustomerTag == debilitatingDisease || refusedCustomerTag == noLongeronInsurancePlan)))
                {
                    resons.Add(((ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), refusedCustomerTag, true)).GetDescription());
                }

                if (prospectCustomer.CallBackRequestedDate.HasValue && refusedCustomerTag == ProspectCustomerTag.CallBackLater.ToString() && prospectCustomer.CallBackRequestedDate > DateTime.Today.AddDays(1))
                {
                    resons.Add("Requested for Callback on " + prospectCustomer.CallBackRequestedDate.Value.ToShortDateString() + " at " + prospectCustomer.CallBackRequestedDate.Value.ToShortTimeString());
                }
            }

            if (customerEligibility == null || customerEligibility.IsEligible == null)
            {
                resons.Add("Eligibility is not available");
            }

            if (customerEligibility != null && customerEligibility.IsEligible == false)
            {
                resons.Add("Not Eligible");
            }

            if (customerTargeted == null || !customerTargeted.IsTargated.HasValue || customerTargeted.IsTargated == false)
            {
                resons.Add("Non-Targeted");
            }

            if (!customer.ActivityId.HasValue)
            {
                resons.Add("Activity is not available");
            }

            if (customer.ActivityId.HasValue && (customer.ActivityId == ((long)UploadActivityType.MailOnly) || customer.ActivityId == (long)UploadActivityType.DoNotCallDoNotMail))
            {
                var activty = ((UploadActivityType)customer.ActivityId.Value).GetDescription();
                resons.Add("Activity is " + activty);
            }

            if (!callQueueSettings.IsNullOrEmpty() && customer.IsIncorrectPhoneNumber && customer.IncorrectPhoneNumberMarkedDate >= firstDayOfYear)
            {
                resons.Add("Incorrect Phone Number");
            }
            else if (customer.IsIncorrectPhoneNumber)
            {
                resons.Add("Incorrect Phone Number");
            }

            //if ((customer.DoNotContactUpdateDate > firstDayOfYear && (customer.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId == (long)DoNotContactType.DoNotCall))
            //    || (customer.DoNotContactUpdateSource == (long)DoNotContactSource.Manual && customer.DoNotContactTypeId != (long)DoNotContactType.DoNotMail))
            if (customer.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
            {
                resons.Add(((DoNotContactType)customer.DoNotContactTypeId).GetDescription());
            }

            var eventCustomer = eventCustomers.Where(x => x.CustomerId == customer.CustomerId).ToArray();

            if (eventCustomer.Any())
            {
                var eventIds = eventCustomer.Select(x => x.EventId).ToArray();
                var customerEvents = events.Where(x => eventIds.Contains(x.Id)).ToArray();

                if (customerEvents.Any())
                {
                    var customerContactedThisYear = new DateTime(DateTime.Today.Year, 1, 1);
                    if (customerEvents.Any(x => x.EventDate.Year == customerContactedThisYear.Year) || customerEvents.Any(x => x.EventDate > customerContactedThisYear))
                    {
                        resons.Add("Booked Appointment");
                    }
                }
            }

            if (callQueueCustomer != null && account != null)
            {
                SetReasonsForCampaign(resons, customer, callQueueCustomer, healthPlanZipIdPairs, account, callQueueSettings);
            }


            return resons.Distinct().ToList();
        }

    }


}
