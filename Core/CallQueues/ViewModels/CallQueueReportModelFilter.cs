using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CallQueueReportModelFilter : ModelFilterBase
    {
        public long AssignedToOrgRoleUserId { get; set; }

        public long CallQueueId { get; set; }
    }
}
