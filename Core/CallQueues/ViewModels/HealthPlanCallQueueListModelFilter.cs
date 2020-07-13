using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class HealthPlanCallQueueListModelFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
        public bool ShowMailRoundCriteria { get; set; }

        public bool ShowAssignmentMetaData { get; set; }
    }
}
