namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class UpsellQueueCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; } 
        public int NoOfDays { get; set; }
        public decimal Amount { get; set; }
    }
}
