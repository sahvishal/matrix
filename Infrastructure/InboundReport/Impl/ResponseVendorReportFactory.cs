using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Call = Falcon.App.Core.CallCenter.Domain.Call;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class ResponseVendorReportFactory : IResponseVendorReportFactory
    {
        private const string GenderMaleAbbr = "M";
        private const string GenderFemaleAbbr = "F";
        private const string GenderUnspecifiedAbbr = "U";
        private const string AbbrYes = "Y";
        private const string AbbrNo = "N";
        private const string RequirementCode = "In Home Assessments";

        public ResponseVendorReportListModel Create(IEnumerable<Customer> customers, IEnumerable<Language> languages, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Event> events, IEnumerable<Call> calls,
            IEnumerable<PcpAppointment> pcpAppointments, IEnumerable<PcpDisposition> pcpDispositions, IEnumerable<EventCustomerBarrier> eventCustomerBarriers, IEnumerable<Barrier> barriers, IEnumerable<ChaseOutbound> chaseOutbounds,
            IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns, IEnumerable<ChaseCampaignType> chaseCampaignTypes, IEnumerable<EventAppointmentCancellationLog> eventAppointmentCancellationLogs,
            IEnumerable<CustomerInfo> resultPostedCustomers, IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var collection = new List<ResponseVendorReportViewModel>();

            foreach (var customer in customers)
            {
                var customerCalls = calls.Where(x => x.CalledCustomerId == customer.CustomerId).OrderByDescending(x => x.CallDateTime).ToArray();

                var customerEligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                var recentCall = customerCalls.Any() ? customerCalls.First() : null;

                var language = customer.LanguageId.HasValue ? languages.First(x => x.Id == customer.LanguageId.Value) : null;

                var appointmentBookedCalls = customerCalls.OrderByDescending(x => x.CallDateTime).FirstOrDefault(x => x.EventId > 0);

                var eventCustomer = appointmentBookedCalls != null ? eventCustomers.FirstOrDefault(x => x.EventId == appointmentBookedCalls.EventId && x.CustomerId == customer.CustomerId) : null;

                if (appointmentBookedCalls != null && eventCustomer == null)
                {
                    eventCustomer = eventCustomers.FirstOrDefault(x => x.CustomerId == customer.CustomerId && x.AppointmentId.HasValue);
                }

                var theEvent = eventCustomer != null ? events.First(x => x.Id == eventCustomer.EventId) : null;

                var appointment = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? appointments.Single(x => x.Id == eventCustomer.AppointmentId.Value) : null;

                var totalDuration = customerCalls.Where(x => x.StartTime.HasValue && x.EndTime.HasValue && x.EndTime.Value > x.StartTime.Value).Select(x => x.EndTime.Value.Subtract(x.StartTime.Value)).Aggregate(new TimeSpan(0), (p, v) => p.Add(v));

                var pcpAppointment = eventCustomer != null ? pcpAppointments.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id) : null;
                var pcpDisposition = eventCustomer != null ? pcpDispositions.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id) : null;

                var eventCustomerBarrier = eventCustomer != null ? eventCustomerBarriers.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id) : null;
                var barrier = eventCustomerBarrier != null ? barriers.FirstOrDefault(x => x.Id == eventCustomerBarrier.BarrierId) : null;

                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                if (chaseOutbound == null) continue;

                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == customer.CustomerId) : null;
                var campaign = !chaseCampaigns.IsNullOrEmpty() && customerChaseCampaign != null ? chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId) : null;
                var campaignType = campaign != null ? chaseCampaignTypes.FirstOrDefault(x => x.Id == campaign.ChaseCampaignTypeId) : null;

                string serviceStatus = string.Empty;
                string campaignOutcome = string.Empty;

                CustomerInfo resultPostedCustomer = null;

                if (eventCustomer != null && eventCustomer.AppointmentId.HasValue && appointment != null)
                {
                    serviceStatus = RequirementStatus.Open.ToString();
                    campaignOutcome = EnumExtension.GetDescription(RequirementStatusDescription.BookedAppointment);

                    if (appointment.CheckInTime.HasValue && appointment.CheckOutTime.HasValue && !eventCustomer.NoShow && !eventCustomer.LeftWithoutScreeningReasonId.HasValue)
                    {
                        serviceStatus = RequirementStatus.Completed.ToString();
                        campaignOutcome = EnumExtension.GetDescription(RequirementStatusDescription.AssessmentCompleted);
                    }
                    else if (eventCustomer.NoShow)
                    {
                        serviceStatus = RequirementStatus.Cancelled.ToString();
                        campaignOutcome = EnumExtension.GetDescription(RequirementStatusDescription.NoShow);
                    }
                    else if (eventCustomer.LeftWithoutScreeningReasonId.HasValue)
                    {
                        serviceStatus = RequirementStatus.Cancelled.ToString();
                        campaignOutcome = EnumExtension.GetDescription(RequirementStatusDescription.LeftWithoutScreening);
                    }

                    resultPostedCustomer = resultPostedCustomers.FirstOrDefault(x => x.CustomerId == customer.CustomerId && x.EventId == theEvent.Id);
                }
                else
                {
                    if (eventCustomer != null && !eventCustomer.AppointmentId.HasValue)
                    {
                        serviceStatus = RequirementStatus.Cancelled.ToString();
                        var eventAppointmentCancellationLog = eventAppointmentCancellationLogs.FirstOrDefault(x => x.EventCustomerId == eventCustomer.Id);
                        var reason = eventAppointmentCancellationLog != null ? ((CancelAppointmentReason)eventAppointmentCancellationLog.ReasonId).ToString() : "";
                        try
                        {
                            campaignOutcome = !string.IsNullOrEmpty(reason) ? EnumExtension.GetDescription(((RequirementStatusDescription)Enum.Parse(typeof(RequirementStatusDescription), reason))) : "";
                        }
                        catch (Exception)
                        {
                            campaignOutcome = eventAppointmentCancellationLog != null ? EnumExtension.GetDescription(((CancelAppointmentReason)eventAppointmentCancellationLog.ReasonId)) : "";
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
                            serviceStatus = RequirementStatus.Cancelled.ToString();
                            try
                            {
                                campaignOutcome = EnumExtension.GetDescription(((RequirementStatusDescription)Enum.Parse(typeof(RequirementStatusDescription), recentCall.Disposition)));
                            }
                            catch (Exception)
                            {
                                campaignOutcome = EnumExtension.GetDescription(((ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), recentCall.Disposition)));
                            }
                            /*if (string.IsNullOrEmpty(requirementStatusDescription))
                            {
                                requirementStatusDescription = !eventCustomer.AppointmentId.HasValue && cancellationNote != null && !string.IsNullOrEmpty(cancellationNote.Notes) ? ReplaceNewLine(Truncate(cancellationNote.Notes, 0, 250), " ") : "";
                            }*/
                        }
                        else if (customerCalls.Count() <= 10)
                        {
                            serviceStatus = RequirementStatus.Open.ToString();
                            campaignOutcome = EnumExtension.GetDescription(RequirementStatusDescription.CallAttempt) + " " + customerCalls.Count();
                        }
                        else if (customerCalls.Count() > 10)
                        {
                            serviceStatus = RequirementStatus.Cancelled.ToString();
                            campaignOutcome = EnumExtension.GetDescription(RequirementStatusDescription.MemberCalledMaxAttempts);
                        }
                    }
                    else if (eventCustomer == null)
                    {
                        serviceStatus = string.IsNullOrEmpty(serviceStatus) ? RequirementStatus.Hold.ToString() : serviceStatus;
                    }
                }

                if (serviceStatus == RequirementStatus.Open.ToString() || serviceStatus == RequirementStatus.Hold.ToString())
                {
                    serviceStatus = RequirementStatus.Cancelled.ToString();
                }

                var responseVendorReportViewModel = new ResponseVendorReportViewModel
                {
                    TenantId = chaseOutbound.TenantId,
                    ClientId = chaseOutbound.ClientId,
                    CampaignId = campaign != null ? campaign.CampaignId : "",
                    IndividualIdNumber = chaseOutbound.IndividualId,
                    ContractNumber = chaseOutbound.ContractNumber,
                    ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                    ConsumerId = chaseOutbound.ConsumerId,
                    VendorPersonId = customer.CustomerId.ToString(),
                    CampaignType = campaignType != null ? campaignType.Name : "",
                    FirstName = customer.Name.FirstName,
                    MiddleInitial = !string.IsNullOrEmpty(customer.Name.MiddleName) ? customer.Name.MiddleName.Substring(0, 1) : string.Empty,
                    LastName = customer.Name.LastName,
                    GenderCode = customer.Gender == Gender.Male ? GenderMaleAbbr : (customer.Gender == Gender.Female ? GenderFemaleAbbr : GenderUnspecifiedAbbr),
                    BirthDate = customer.DateOfBirth,
                    Height = customer.Height != null ? ((customer.Height.Feet * 12) + customer.Height.Inches).ToString() : "",
                    Weight = customer.Weight != null && customer.Weight.Pounds > 0 ? Math.Round(customer.Weight.Pounds).ToString() : "",
                    EligibilityDate = customerEligibility != null && customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value ? DateTime.Now : (DateTime?)null,
                    HealthAssessComp = eventCustomer != null && appointment != null && appointment.CheckInTime.HasValue && !eventCustomer.NoShow && !eventCustomer.LeftWithoutScreeningReasonId.HasValue ? AbbrYes : AbbrNo,
                    HealthAssessCompDate = eventCustomer != null && appointment != null && appointment.CheckInTime.HasValue && !eventCustomer.NoShow && !eventCustomer.LeftWithoutScreeningReasonId.HasValue ? theEvent.EventDate : (DateTime?)null,
                    Race = EnumExtension.GetDescription(customer.Race),
                    LanguagePreferenceUpdate = language != null ? language.Name : null,
                    MemberPhonePreference = PhoneNumber.ToNumber(customer.HomePhoneNumber.ToString()),
                    MemberSecondPhonePreference = PhoneNumber.ToNumber(customer.MobilePhoneNumber.ToString()),
                    MemberEmailPreference = customer.Email.ToString(),
                    NewProviderName = customer.PrimaryCarePhysician != null ? customer.PrimaryCarePhysician.Name.FullName : "",
                    NewProviderId = customer.PrimaryCarePhysician != null ? customer.PrimaryCarePhysician.Id.ToString() : "",
                    CareBarrier1 = barrier != null ? barrier.Name : "",
                    /*ApptScheduled = pcpAppointment != null ? AbbrYes : AbbrNo,
                    ApptScheduledDate = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null,
                    ApptScheduledTime = pcpAppointment != null ? pcpAppointment.AppointmentOn : (DateTime?)null,*/
                    ApptScheduled = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? AbbrYes : AbbrNo,
                    ApptScheduledDate = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? theEvent.EventDate : (DateTime?)null,
                    ApptScheduledTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                    ApptScheduledProviderName = pcpAppointment != null && customer.PrimaryCarePhysician != null ? customer.PrimaryCarePhysician.Name.FullName : "",
                    ApptScheduledProviderId = pcpAppointment != null && customer.PrimaryCarePhysician != null ? customer.PrimaryCarePhysician.Id.ToString() : "",
                    ServiceCode = RequirementCode,
                    ServiceStatus = serviceStatus,
                    CampaignOutcome = campaignOutcome,
                    ServiceStartDate = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? theEvent.EventDate : recentCall != null ? recentCall.CallDateTime : (DateTime?)null,
                    ServiceEndDate = eventCustomer != null && eventCustomer.AppointmentId.HasValue ? theEvent.EventDate : (DateTime?)null,
                    ServiceStatusTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                    LengthOfCall = totalDuration.Seconds == 0 ? "" : new DateTime(totalDuration.Ticks).ToString("HH:mm:ss"),
                    DoNotContact = customer.DoNotContactTypeId.HasValue && customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact ? AbbrYes : AbbrNo,
                    DoNotCall = customer.DoNotContactTypeId.HasValue && customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotCall ? AbbrYes : AbbrNo,
                    CallAttempt1Datetime = customerCalls.Any() ? customerCalls.First().CallDateTime : (DateTime?)null,
                    CallAttempt2Datetime = customerCalls.Any() && customerCalls.Count() >= 2 ? customerCalls.ElementAt(1).CallDateTime : (DateTime?)null,
                    CallAttempt3Datetime = customerCalls.Any() && customerCalls.Count() >= 3 ? customerCalls.ElementAt(2).CallDateTime : (DateTime?)null,
                    CallAttempt4Datetime = customerCalls.Any() && customerCalls.Count() >= 4 ? customerCalls.ElementAt(3).CallDateTime : (DateTime?)null,
                    CallAttempt5Datetime = customerCalls.Any() && customerCalls.Count() >= 5 ? customerCalls.ElementAt(4).CallDateTime : (DateTime?)null,
                    CallAttempt6Datetime = customerCalls.Any() && customerCalls.Count() >= 6 ? customerCalls.ElementAt(5).CallDateTime : (DateTime?)null,
                    CallAttempt7Datetime = customerCalls.Any() && customerCalls.Count() >= 7 ? customerCalls.ElementAt(6).CallDateTime : (DateTime?)null,
                    CallAttempt8Datetime = customerCalls.Any() && customerCalls.Count() >= 8 ? customerCalls.ElementAt(7).CallDateTime : (DateTime?)null,
                    NoResponse = totalDuration.Seconds == 0 ? AbbrYes : AbbrNo,
                    AcceptedScheduleAssistance = pcpDisposition != null && pcpDisposition.Disposition == PcpAppointmentDisposition.ScheduledHealthFairBooked ? AbbrYes : AbbrNo,
                    AcceptedScheduleAssistanceDate = pcpDisposition != null ? pcpDisposition.DataRecorderMetaData.DateCreated : (DateTime?)null,
                    Assisted = pcpDisposition != null && pcpDisposition.Disposition == PcpAppointmentDisposition.ScheduledHealthFairBooked ? AbbrYes : AbbrNo,
                    AppointmentNotRequired = pcpDisposition != null && (pcpDisposition.Disposition == PcpAppointmentDisposition.DeniedRefusesToReviewHealthFairResults ||
                                             pcpDisposition.Disposition == PcpAppointmentDisposition.DeniedNotCurrentPatient || pcpDisposition.Disposition == PcpAppointmentDisposition.DeniedRequiresPatientCallDirectly)
                                             ? AbbrYes : AbbrNo,
                    FormSubmitted = resultPostedCustomer != null ? AbbrYes : AbbrNo
                    //PreferredContactMethod = pcpAppointment != null ? ((PreferredContactMethod)pcpAppointment.PreferredContactMethod).GetDescription() : ""
                };

                collection.Add(responseVendorReportViewModel);
            }

            return new ResponseVendorReportListModel
            {
                Collection = collection
            };
        }

        private string GetCampaignOutcome(string disposition)
        {
            return EnumExtension.GetDescription(((RequirementStatusDescription)Enum.Parse(typeof(RequirementStatusDescription), disposition)));
        }
    }
}
