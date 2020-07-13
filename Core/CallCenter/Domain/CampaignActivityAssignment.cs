using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CampaignActivityAssignment : DomainObjectBase
    {
        public long CampaignActivityId { get; set; }
        public long AssignedToOrgRoleUserId { get; set; }
    }
}