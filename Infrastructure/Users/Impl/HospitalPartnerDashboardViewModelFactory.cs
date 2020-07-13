using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class HospitalPartnerDashboardViewModelFactory : IHospitalPartnerDashboardViewModelFactory
    {
        private readonly IHospitalPartnerEventListFactory _hospitalPartnerEventListFactory;
        public HospitalPartnerDashboardViewModelFactory(IHospitalPartnerEventListFactory hospitalPartnerEventListFactory)
        {
            _hospitalPartnerEventListFactory = hospitalPartnerEventListFactory;
        }
        public HospitalPartnerDashboardViewModel Create(long scheduledEvents, IEnumerable<OrderedPair<long, int>> totalCustomers, IEnumerable<OrderedPair<long, int>> customersAttended, IEnumerable<OrderedPair<long, int>> criticalCustomers,
            IEnumerable<OrderedPair<long, int>> normalCustomers, IEnumerable<OrderedPair<long, int>> abnormalCustomers, IEnumerable<Event> events, IEnumerable<Host> hosts,
            long reccentContactedEventId, IEnumerable<OrderedPair<long, DateTime>> recentMailedEvents, DateTime? mailedDate, IEnumerable<EventCustomerResult> recentCriticalCustomers, IEnumerable<Customer> customers,
            IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels, IEnumerable<OrderedPair<long, int>> urgentCustomers)
        {

            var model = new HospitalPartnerDashboardViewModel
                            {
                                ScheduleEvents = scheduledEvents,
                                RegisteredCustomers = totalCustomers.Sum(tc => tc.SecondValue),
                                ScreenedCustomers = customersAttended.Sum(ca => ca.SecondValue),
                                NormalCustomers = normalCustomers.Sum(ec => ec.SecondValue),
                                AbnormalCustomers = abnormalCustomers.Sum(ac => ac.SecondValue),
                                CriticalCustomers = criticalCustomers.Sum(cc => cc.SecondValue),
                                UrgentCustomers = urgentCustomers.Sum(uc => uc.SecondValue),
                            };
            if (events != null && events.Count() > 0)
            {
                if (recentMailedEvents != null && recentMailedEvents.Count() > 0)
                    model.RecentMailedEvents = _hospitalPartnerEventListFactory.Create(events, hosts, recentMailedEvents);

                var recentContactedEvent = events.Where(e => e.Id == reccentContactedEventId).SingleOrDefault();
                if (recentContactedEvent != null)
                {
                    var host = hosts.Where(h => h.Id == recentContactedEvent.HostId).Single();
                    model.RecentContactedEvent = _hospitalPartnerEventListFactory.Create(recentContactedEvent, host,
                                                                                         mailedDate);
                }

                if (recentCriticalCustomers != null && recentCriticalCustomers.Count() > 0)
                {
                    var customerModel = (from recentCriticalCustomer in recentCriticalCustomers
                                         let theEvent = events.Where(e => e.Id == recentCriticalCustomer.EventId).Single()
                                         let customer = customers.Where(c => c.CustomerId == recentCriticalCustomer.CustomerId).Single()
                                         let customerResultStatus = customerResultStatusViewModels.Where(crs => crs.EventCustomerId == recentCriticalCustomer.Id).Single()
                                         select new HospitalPartnerDashboardCustomerViewData
                                                    {
                                                        CustomerId = customer.CustomerId,
                                                        CustomerName = customer.Name,
                                                        EventDate = theEvent.EventDate,
                                                        EventId = theEvent.Id,
                                                        CriticalMarkedByPhysician = customerResultStatus.TestResults.Where(tr => tr.CriticalMarkedByPhysician && !tr.IsCritical).Any(),
                                                        ResultSummary = (recentCriticalCustomer.ResultSummary.HasValue ? (ResultInterpretation)recentCriticalCustomer.ResultSummary : ResultInterpretation.Critical).ToString()
                                                    }).ToList();
                    model.Customers = customerModel;
                }
            }
            return model;
        }


        public HospitalPartnerCallStatusViewModel CreateCallStatus(int abnormalCustomers, int criticalCustomers, int urgentCustomers, IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers)
        {
            long notCalledStatus = abnormalCustomers + criticalCustomers + urgentCustomers;
            long talkedToPersonStatus = 0;
            long leftVoiceMailStatus = 0;
            long leftVoiceMail2Status = 0;
            long leftVoiceMail3Status = 0;
            long leftVoiceMail4Status = 0;
            long voiceMail5Status = 0;
            long voiceMail6Status = 0;
            long mailedEmailedStatus = 0;
            long unReachableStatus = 0;

            if (hospitalPartnerCustomers != null && hospitalPartnerCustomers.Any())
            {
                talkedToPersonStatus = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.TalkedToPerson);

                leftVoiceMailStatus = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.LeftVoiceMail);

                leftVoiceMail2Status = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.LeftVoiceMail2);

                leftVoiceMail3Status = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.LeftVoiceMail3);

                leftVoiceMail4Status = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.LeftVoiceMail4);

                voiceMail5Status = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.Voicemail5);

                voiceMail6Status = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.Voicemail6);

                mailedEmailedStatus = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.MailedEmailed);

                unReachableStatus = hospitalPartnerCustomers.Count(hpc => hpc.Status == (int)HospitalPartnerCustomerStatus.Unreachable);

                notCalledStatus = abnormalCustomers + criticalCustomers + urgentCustomers
                    - talkedToPersonStatus - leftVoiceMailStatus - leftVoiceMail2Status - leftVoiceMail3Status - leftVoiceMail4Status - voiceMail5Status - voiceMail6Status - mailedEmailedStatus - unReachableStatus;
            }

            return new HospitalPartnerCallStatusViewModel
                       {
                           NotCalledStatus = notCalledStatus,
                           TalkedToPersonStatus = talkedToPersonStatus,
                           LeftVoiceMailStatus = leftVoiceMailStatus,
                           LeftVoiceMail2Status = leftVoiceMail2Status,
                           LeftVoiceMail3Status = leftVoiceMail3Status,
                           LeftVoiceMail4Status = leftVoiceMail4Status,
                           VoiceMail5Status = voiceMail5Status,
                           VoiceMail6Status = voiceMail6Status,
                           MailedEmailedStatus = mailedEmailedStatus,
                           UnReachableStatus = unReachableStatus,
                           TotalCount = abnormalCustomers + criticalCustomers + urgentCustomers
                       };
        }

        public HospitalPartnerScheduledOutcomeViewModel CreateScheduledOutcome(int abnormalCustomers, int criticalCustomers, int urgentCustomers, IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers)
        {
            long scheduledOutcome = 0;
            long scheduledWithAffiliatedPcpOutcome = 0;
            long scheduledWithAffiliatedSpecialistOutcome = 0;
            long referredToAffiliatedPcpOutcome = 0;
            long referredToAffiliatedSpecialistOutcome = 0;
            long selfScheduledWithNonAffiliatedPhysician = 0;
            long selfScheduledWithAffiliatedPhysician = 0;
            long scheduledWithEmployedPhysician = 0;
            long referredToEmployedPhysician = 0;
            long selfScheduledWithEmployedPhysician = 0;
            long uninsured = 0;

            if (hospitalPartnerCustomers != null && hospitalPartnerCustomers.Any())
            {
                scheduledOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.Scheduled);

                scheduledWithAffiliatedPcpOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ScheduledWithAffiliatedPcp);

                scheduledWithAffiliatedSpecialistOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ScheduledWithAffiliatedSpecialist);

                referredToAffiliatedPcpOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ReferredToAffiliatedPcp);

                referredToAffiliatedSpecialistOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ReferredToAffiliatedSpecialist);

                selfScheduledWithNonAffiliatedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.SelfScheduledWithNonAffiliatedPhysician);

                selfScheduledWithAffiliatedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.SelfScheduledWithAffiliatedPhysician);

                scheduledWithEmployedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ScheduledWithEmployedPhysician);

                referredToEmployedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ReferredToEmployedPhysician);

                selfScheduledWithEmployedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.SelfScheduledWithEmployedPhysician);

                uninsured = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.Uninsured);

            }

            return new HospitalPartnerScheduledOutcomeViewModel
                       {
                           ScheduledOutcome = scheduledOutcome,
                           ScheduledWithAffiliatedPcpOutcome = scheduledWithAffiliatedPcpOutcome,
                           ScheduledWithAffiliatedSpecialistOutcome = scheduledWithAffiliatedSpecialistOutcome,
                           ReferredToAffiliatedPcpOutcome = referredToAffiliatedPcpOutcome,
                           ReferredToAffiliatedSpecialistOutcome = referredToAffiliatedSpecialistOutcome,
                           SelfScheduledWithAffiliatedPhysicianOutcome = selfScheduledWithAffiliatedPhysician,
                           SelfScheduledWithNonAffiliatedPhysicianOutcome = selfScheduledWithNonAffiliatedPhysician,
                           ScheduledWithEmployedPhysician = scheduledWithEmployedPhysician,
                           ReferredToEmployedPhysician = referredToEmployedPhysician,
                           SelfScheduledWithEmployedPhysician = selfScheduledWithEmployedPhysician,
                           Uninsured = uninsured,
                           TotalCount = abnormalCustomers + criticalCustomers + urgentCustomers
                       };
        }

        public HospitalPartnerNotScheduledOutcomeViewModel CreateNotScheduledOutcome(int abnormalCustomers, int criticalCustomers, int urgentCustomers, IEnumerable<HospitalPartnerCustomer> hospitalPartnerCustomers)
        {
            long notScheduledOutcome = 0;
            long notScheduledSentInformationOutcome = 0;
            long notScheduledNotInterestedOutcome = 0;
            long notReachedOutcome = 0;
            long otherOutcome = 0;
            long requiresCallBack = 0;
            long notCalledOutcome = abnormalCustomers + criticalCustomers + urgentCustomers;


            if (hospitalPartnerCustomers != null && hospitalPartnerCustomers.Any())
            {
                var scheduledOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.Scheduled);

                var scheduledWithAffiliatedPcpOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ScheduledWithAffiliatedPcp);

                var scheduledWithAffiliatedSpecialistOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ScheduledWithAffiliatedSpecialist);

                var referredToAffiliatedPcpOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ReferredToAffiliatedPcp);

                var referredToAffiliatedSpecialistOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ReferredToAffiliatedSpecialist);

                var selfScheduledWithNonAffiliatedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.SelfScheduledWithNonAffiliatedPhysician);

                var selfScheduledWithAffiliatedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.SelfScheduledWithAffiliatedPhysician);

                var scheduledWithEmployedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ScheduledWithEmployedPhysician);

                var referredToEmployedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.ReferredToEmployedPhysician);

                var selfScheduledWithEmployedPhysician = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.SelfScheduledWithEmployedPhysician);

                var uninsured = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.Uninsured);

                notScheduledOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.NotScheduled);

                notScheduledSentInformationOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.NotScheduledSentInformation);

                notReachedOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.NotReached);

                otherOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.Other);

                notScheduledNotInterestedOutcome = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.NotScheduledNotInterested);

                requiresCallBack = hospitalPartnerCustomers.Count(hpc => hpc.Outcome == (int)HospitalPartnerCustomerOutcome.RequiresCallBack);

                notCalledOutcome = abnormalCustomers + criticalCustomers + urgentCustomers
                    - scheduledOutcome - scheduledWithAffiliatedPcpOutcome - scheduledWithAffiliatedSpecialistOutcome - referredToAffiliatedPcpOutcome - referredToAffiliatedSpecialistOutcome - selfScheduledWithNonAffiliatedPhysician
                    - selfScheduledWithAffiliatedPhysician - scheduledWithEmployedPhysician - referredToEmployedPhysician - selfScheduledWithEmployedPhysician - uninsured
                    - notScheduledOutcome - notScheduledSentInformationOutcome - notReachedOutcome - otherOutcome - notScheduledNotInterestedOutcome - requiresCallBack;

            }

            return new HospitalPartnerNotScheduledOutcomeViewModel
                       {
                           NotScheduledOutcome = notScheduledOutcome,
                           NotScheduledSentInformationOutcome = notScheduledSentInformationOutcome,
                           NotReachedOutcome = notReachedOutcome,
                           OtherOutcome = otherOutcome,
                           NotScheduledNotInterestedOutcome = notScheduledNotInterestedOutcome,
                           NotCalledOutcome = notCalledOutcome,
                           TotalCount = abnormalCustomers + criticalCustomers + urgentCustomers,
                           RequiresCallBack = requiresCallBack

                       };
        }
    }
}
