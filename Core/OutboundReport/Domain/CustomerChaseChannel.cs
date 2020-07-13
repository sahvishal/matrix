using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class CustomerChaseChannel : DomainObjectBase
    {
        public long ChaseOutboundId { get; set; }
        public long CustomerId { get; set; }
        public long ChaseChannelLevelId { get; set; }
    }
}
