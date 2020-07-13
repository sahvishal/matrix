namespace Falcon.App.Core.Medical.Domain
{
    public class PhysicianEventQueueListItem
    {
        public long PhysicianId { get; set; }
        public long EventId { get; set; }
        public int CustomersInQueue { get; set; }
    }
}
