
namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventCustomerBarrier
    {
        public long EventCustomerId { get; set; }
        public long BarrierId { get; set; }
        public string Reason { get; set; }
        public string Resolution { get; set; }
    }
}
