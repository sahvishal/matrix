using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CampaignAssignmentEditModel
    {
        public long CampaignId { get; set; }
        public long AssignedOrgRoleUserId { get; set; }
        public string Name { get; set; }
    }
}