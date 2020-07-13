namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueCriteriaEditModel
    {
        public long CallQueueId { get; set; }
        public long CriteriaId { get; set; }
        public string Name { get; set; }
        public int Radius { get; set; }
        public string Zipcode { get; set; }
        public bool Condition { get; set; }
        public string CallReason { get; set; }
    }
}
