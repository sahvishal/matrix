using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueCustomersStatsViewModel : ViewModelBase
    {
        public long TotalCustomerInCallQueue { get; set; }

        public long TotalCustomerInAvilable
        {
            get
            {
                return (TotalCustomerInCallQueue - CustomersNotInQueue);
            }
        }

        public long CustomersNotInQueue
        {
            get
            {
                return (MaxAttempt + NotEligible + AppointmentBooked + DoNotContact + Activity + IncorrectPhone +
                        NoPhone + Deceased + HomeVisitRequested + MobilityIssue + InLongTermCareNursingHome +
                        MobilityIssuesLeftMessageWithOther + NoLongeronInsurancePlan + DebilitatingDisease +
                        CallBackLater + NoEventsInArea + LeftVoiceMessage + NotInterested + RecentlySawDoc +
                        TransportationIssue + AppointmentCancelledDate + CallSkipped + CallInitiated +
                        MovedRelocated + WillSpeakWithPhysician + DateTimeConflict + NoAnswer + NoEventsInAreaCallStatus +
                        LeftMessageWithOthers + LanguageBarrier + NoShowCustomers + InvalidNumbers + NotinterestedInMammogramCount +
                        MemberNotMammoAvailableNoEventsInAreaCount + NonTargetedCount
                    );
            }
        }

        public long MaxAttempt { get; set; }

        public long NotEligible { get; set; }

        public long AppointmentBooked { get; set; }

        public long DoNotContact { get; set; }

        public long Activity { get; set; }

        public long IncorrectPhone { get; set; }

        public long NoPhone { get; set; }

        public long Deceased { get; set; }

        public long HomeVisitRequested { get; set; }

        public long MobilityIssue { get; set; }

        public long InLongTermCareNursingHome { get; set; }

        public long MobilityIssuesLeftMessageWithOther { get; set; }

        public long NoLongeronInsurancePlan { get; set; }

        public long DebilitatingDisease { get; set; }

        public long CallBackLater { get; set; }

        public long NoEventsInArea { get; set; }

        public long LeftVoiceMessage { get; set; }

        public long NotInterested { get; set; }

        public long RecentlySawDoc { get; set; }

        public long TransportationIssue { get; set; }

        public long AppointmentCancelledDate { get; set; }

        public long CallSkipped { get; set; }

        public long CallInitiated { get; set; }

        public long MovedRelocated { get; set; }

        public long WillSpeakWithPhysician { get; set; }

        public long DateTimeConflict { get; set; }

        public long NoAnswer { get; set; }

        public long NoEventsInAreaCallStatus { get; set; }

        public long LeftMessageWithOthers { get; set; }

        public long LanguageBarrier { get; set; }

        public long NoShowCustomers { get; set; }

        public long InvalidNumbers { get; set; }

        public long NotinterestedInMammogramCount { get; set; }

        public long MemberNotMammoAvailableNoEventsInAreaCount { get; set; }

        public long NonTargetedCount { get; set; }
    }
}
