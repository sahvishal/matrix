using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class CustomerChaseCampaign : DomainObjectBase
    {
        public long ChaseOutboundId { get; set; }
        public long CustomerId { get; set; }
        public long ChaseCampaignId { get; set; }
        public bool IsActive { get; set; }
    }
}
