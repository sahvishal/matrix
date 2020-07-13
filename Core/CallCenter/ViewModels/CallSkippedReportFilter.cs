using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallSkippedReportFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
        //public DateTime? SkippedDate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long CustomerId { get; set; }
        public long AgentId { get; set; }
        public string AgentName { get; set; }
    }
}
