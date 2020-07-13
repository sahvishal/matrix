using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class CustomerChaseProduct : DomainObjectBase
    {
        public long ChaseOutboundId { get; set; }
        public long CustomerId { get; set; }
        public long ChaseProductId { get; set; }
    }
}
