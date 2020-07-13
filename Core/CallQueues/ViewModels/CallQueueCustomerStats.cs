namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueCustomerStats
    {
        public long CallQueueId { get; set; }
        public long AssignedToOrgRoleUserId { get; set; }
        public long Count { get; set; }
    }
}
