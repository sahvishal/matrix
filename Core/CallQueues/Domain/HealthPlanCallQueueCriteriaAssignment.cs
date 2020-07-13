namespace Falcon.App.Core.CallQueues.Domain
{
    public class HealthPlanCallQueueCriteriaAssignment
    {
        public long CallQueueCustomerId { get; set; }
        public long CallQueueId { get; set; }
        public long CriteriaId { get; set; }
    }
}