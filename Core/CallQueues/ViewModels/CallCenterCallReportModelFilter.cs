using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CallCenterCallReportModelFilter : ModelFilterBase
    {
        public string Tag { get; set; }
        public string[] CustomTags { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long? CustomerId { get; set; }
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
        public int CallType { get; set; }
    }
}
