using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CallQueueSchedulingReportFilter : ModelFilterBase
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public long CallQueueId { get; set; }
        public long HealthPlanId { get; set; }
    }
}