using Falcon.App.Core.Application.ViewModels;
using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class OutreachCallReportModelFilter : ModelFilterBase
    {
        public string Tag { get; set; }
        public string[] CustomTags { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long? CustomerId { get; set; }
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
        public long? EventId { get; set; }
        public CallAttemptFilterStatus CallAttemptFilter { get; set; }
        public long ProductTypeId { get; set; }
    }
}
