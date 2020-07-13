using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class InterviewInboundReportFactory : IInterviewInboundReportFactory
    {
        private const int Maxlength = 10;
        private const string RequirementCode = "In Home Assessments";

        public ListModelBase<InterviewInboundViewModel, InterviewInboundFilter> Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<ChaseOutbound> chaseOutbounds,
            IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<Call> calls, IEnumerable<Appointment> appointments, IEnumerable<Event> events,
            IEnumerable<EventAppointmentCancellationLog> eventAppointmentCancellationLogs, IEnumerable<CustomerCallNotes> customerCallNotes, IEnumerable<OrderedPair<long, long>> eventIdStaffIdPairs,
            IEnumerable<OrganizationRoleUser> organizationRoleUsers, IEnumerable<User> users)
        {
            var collection = new List<InterviewInboundViewModel>();

            foreach (var customer in customers)
            {
                var customerCalls = calls.Where(x => x.CalledCustomerId == customer.CustomerId).ToArray().OrderByDescending(x => x.CallDateTime).ToArray();

                var recentCall = customerCalls.Any() ? customerCalls.First() : null;

                var appointmentBookedCalls = customerCalls.OrderByDescending(x => x.CallDateTime).FirstOrDefault(x => x.EventId > 0);

                var eventCustomer = appointmentBookedCalls != null ? eventCustomers.FirstOrDefault(x => x.EventId == appointmentBookedCalls.EventId && x.CustomerId == customer.CustomerId) : null;

                if (appointmentBookedCalls != null && eventCustomer == null)
                {
                    eventCustomer = eventCustomers.FirstOrDefault(x => x.CustomerId == customer.CustomerId && x.AppointmentId.HasValue);
                }

                var theEvent = eventCustomer != null ? events.First(x => x.Id == eventCustomer.EventId) : null;

                var appointment = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? appointments.Single(x => x.Id == eventCustomer.AppointmentId.Value) : null;

                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                if (chaseOutbound == null) continue;

                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == customer.CustomerId) : null;
                var campaign = !chaseCampaigns.IsNullOrEmpty() && customerChaseCampaign != null ? chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId) : null;

                var eventIdStaffIdPairsForEvent = eventCustomer != null ? eventIdStaffIdPairs.Where(x => x.FirstValue == eventCustomer.EventId) : null;
                var organizationRoleUsersForEvent = eventIdStaffIdPairsForEvent != null && eventIdStaffIdPairsForEvent.Any() ? organizationRoleUsers.Where(x => eventIdStaffIdPairsForEvent.Select(y => y.SecondValue).Contains(x.Id)) : null;
                var usersForEvent = organizationRoleUsersForEvent != null && organizationRoleUsersForEvent.Any() ? users.Where(x => organizationRoleUsersForEvent.Select(y => y.UserId).Contains(x.Id)) : null;
                var userId = usersForEvent != null && usersForEvent.Any() ? usersForEvent.First().Id.ToString() : "";

                string requirementStatus = string.Empty;
                string requirementStatusDescription = string.Empty;

                if (eventCustomer != null && eventCustomer.AppointmentId.HasValue && appointment != null)
                {
                    requirementStatus = RequirementStatus.Open.ToString();
                    requirementStatusDescription = EnumExtension.GetDescription(RequirementStatusDescription.BookedAppointment);

                    if (appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue && !eventCustomer.NoShow && !eventCustomer.LeftWithoutScreeningReasonId.HasValue)
                    {
                        requirementStatus = RequirementStatus.Completed.ToString();
                        requirementStatusDescription = EnumExtension.GetDescription(RequirementStatusDescription.AssessmentCompleted);
                    }
                    else if (eventCustomer.NoShow)
                    {
                        requirementStatus = RequirementStatus.Cancelled.ToString();
                        requirementStatusDescription = EnumExtension.GetDescription(RequirementStatusDescription.NoShow);
                    }
                    else if (eventCustomer.LeftWithoutScreeningReasonId.HasValue)
                    {
                        requirementStatus = RequirementStatus.Cancelled.ToString();
                        requirementStatusDescription = EnumExtension.GetDescription(RequirementStatusDescription.LeftWithoutScreening);
                    }
                }
                else
                {
                    if (eventCustomer != null && !eventCustomer.AppointmentId.HasValue)
                    {
                        requirementStatus = RequirementStatus.Cancelled.ToString();
                        var eventAppointmentCancellationLog = eventAppointmentCancellationLogs.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id);
                        var reason = eventAppointmentCancellationLog != null ? ((CancelAppointmentReason)eventAppointmentCancellationLog.ReasonId).ToString() : "";
                        try
                        {
                            requirementStatusDescription = !string.IsNullOrEmpty(reason) ? EnumExtension.GetDescription(((RequirementStatusDescription)Enum.Parse(typeof(RequirementStatusDescription), reason))) : "";
                        }
                        catch (Exception)
                        {
                            requirementStatusDescription = eventAppointmentCancellationLog != null ? EnumExtension.GetDescription(((CancelAppointmentReason)eventAppointmentCancellationLog.ReasonId)) : "";
                        }

                        if (eventAppointmentCancellationLog != null)
                        {
                            customerCalls = customerCalls.Where(x => x.CallDateTime > eventAppointmentCancellationLog.DateCreated).OrderBy(x => x.CallDateTime).ToArray();
                        }
                    }
                    if (customerCalls.Any())
                    {
                        if (recentCall != null && recentCall.Disposition == ProspectCustomerTag.Deceased.ToString() || recentCall.Disposition == ProspectCustomerTag.DoNotCall.ToString() || recentCall.Disposition == ProspectCustomerTag.MobilityIssue.ToString()
                        || recentCall.Disposition == ProspectCustomerTag.TransportationIssue.ToString() || recentCall.Disposition == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString() || recentCall.Disposition == ProspectCustomerTag.IncorrectPhoneNumber.ToString() ||
                        recentCall.Disposition == ProspectCustomerTag.DebilitatingDisease.ToString() || recentCall.Disposition == ProspectCustomerTag.NoLongeronInsurancePlan.ToString() || recentCall.Disposition == ProspectCustomerTag.HomeVisitRequested.ToString()
                             || recentCall.Disposition == ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString())
                        {
                            requirementStatus = RequirementStatus.Cancelled.ToString();
                            try
                            {
                                requirementStatusDescription = EnumExtension.GetDescription(((RequirementStatusDescription)Enum.Parse(typeof(RequirementStatusDescription), recentCall.Disposition)));
                            }
                            catch (Exception)
                            {
                                requirementStatusDescription = EnumExtension.GetDescription(((ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), recentCall.Disposition)));
                            }
                            /*if (string.IsNullOrEmpty(requirementStatusDescription))
                            {
                                requirementStatusDescription = !eventCustomer.AppointmentId.HasValue && cancellationNote != null && !string.IsNullOrEmpty(cancellationNote.Notes) ? ReplaceNewLine(Truncate(cancellationNote.Notes, 0, 250), " ") : "";
                            }*/
                        }
                        else if (customerCalls.Count() <= 10)
                        {
                            requirementStatus = RequirementStatus.Open.ToString();
                            requirementStatusDescription = EnumExtension.GetDescription(RequirementStatusDescription.CallAttempt) + " " + customerCalls.Count();
                        }
                        else if (customerCalls.Count() > 10)
                        {
                            requirementStatus = RequirementStatus.Cancelled.ToString();
                            requirementStatusDescription = EnumExtension.GetDescription(RequirementStatusDescription.MemberCalledMaxAttempts);
                        }
                    }
                    else if (eventCustomer == null)
                    {
                        requirementStatus = string.IsNullOrEmpty(requirementStatus) ? RequirementStatus.Hold.ToString() : requirementStatus;
                    }
                }

                if (requirementStatus == RequirementStatus.Open.ToString() || requirementStatus == RequirementStatus.Hold.ToString())
                {
                    requirementStatus = RequirementStatus.Cancelled.ToString();
                }

                var interviewInboundViewModel = new InterviewInboundViewModel
                {
                    TenantId = chaseOutbound.TenantId,
                    ClientId = chaseOutbound.ClientId,
                    CampaignId = campaign != null ? campaign.CampaignId : "",
                    IndividualIDNumber = chaseOutbound.IndividualId,
                    ContractNumber = chaseOutbound.ContractNumber,
                    ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                    ConsumerId = chaseOutbound.ConsumerId,
                    VendorPersonId = customer.CustomerId.ToString(),
                    ChartNumber = "",
                    RequirementCode = RequirementCode,
                    RequirementStatus = requirementStatus,
                    RequirementStatusDescription = requirementStatusDescription,
                    RequirementStatusDate = eventCustomer != null && eventCustomer.AppointmentId.HasValue && theEvent != null ? theEvent.EventDate : recentCall != null ? recentCall.CallDateTime : (DateTime?)null,
                    RequirementStatusTime = appointment != null ? appointment.StartTime : recentCall != null ? recentCall.CallDateTime : (DateTime?)null,
                    RequirementUserCode = !string.IsNullOrEmpty(userId) ? userId.Length > Maxlength ? userId.Substring(0, Maxlength) : userId : ""
                };

                collection.Add(interviewInboundViewModel);
            }

            return new InterviewInboundListModel
            {
                Collection = collection
            };
        }

        private string Truncate(string text, int startIndex, int length)
        {
            try
            {
                if (string.IsNullOrEmpty(text)) return string.Empty;

                if (text.Length <= startIndex) return string.Empty;

                if (text.Length > startIndex && text.Length < length) return text.Substring(startIndex);

                if (text.Length >= length) return text.Substring(startIndex, length);

                return text;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private string ReplaceNewLine(string text, string replaceWith)
        {
            var newText = text.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
            return newText;
        }
    }
}
