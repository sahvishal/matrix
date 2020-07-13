using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CampaignActivityAssignmentEditModel
    {
        public long CampaignActivityId { get; set; }
        public long AssignedOrgRoleUserId { get; set; }
        public string Name { get; set; }
    }
}