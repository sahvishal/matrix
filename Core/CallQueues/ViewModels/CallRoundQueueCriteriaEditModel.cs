namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallRoundQueueCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public int RoundOfCalls { get; set; }
        public int NoOfDays { get; set; }
        public int HealthPlanId { get; set; }
        public string CustomCorporateTag { get; set; }
    }
}