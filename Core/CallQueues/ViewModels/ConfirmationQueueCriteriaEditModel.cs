namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class ConfirmationQueueCriteriaEditModel
    {
        public long CriteriaId { get; set; }
        public long CallQueueId { get; set; } 
        public int NoOfDays { get; set; }
    }
}
