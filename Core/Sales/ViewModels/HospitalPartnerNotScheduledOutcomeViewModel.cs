namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerNotScheduledOutcomeViewModel
    {
        public long NotScheduledOutcome { get; set; }
        public long NotScheduledSentInformationOutcome { get; set; }
        public long NotScheduledNotInterestedOutcome { get; set; }
        public long NotReachedOutcome { get; set; }
        public long OtherOutcome { get; set; }
        public long NotCalledOutcome { get; set; }
        public long TotalCount { get; set; }
        public long RequiresCallBack { get; set; }
    }
}
