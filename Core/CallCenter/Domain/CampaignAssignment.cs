using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CampaignAssignment : DomainObjectBase
    {
        public long CampaignId { get; set; }
        public long AssignedToOrgRoleUserId { get; set; }
    }
}