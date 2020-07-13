namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class HealthPlanFillEventCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public int Percentage { get; set; }
        public int NoOfDays { get; set; }
        public int HealthPlanId { get; set; }
        public string CustomCorporateTag { get; set; }
    }
}