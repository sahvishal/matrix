using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallCentreAgentQueueFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
        public long AgentOrganizationRoleUserId { get; set; }
        public long AgentOrganizationId { get; set; }
    }
}
