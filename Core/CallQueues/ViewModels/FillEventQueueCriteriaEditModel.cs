namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class FillEventQueueCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; }
        public decimal Percentage { get; set; } 
        public int NoOfDays { get; set; }
    }
}
