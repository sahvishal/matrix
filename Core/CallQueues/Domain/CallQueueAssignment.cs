namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallQueueAssignment
    {
        public long CallQueueId { get; set; }
        public long AssignedOrgRoleUserId { get; set; }
        public int Percentage { get; set; }
    }
}
