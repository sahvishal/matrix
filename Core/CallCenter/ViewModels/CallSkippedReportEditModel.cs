using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallSkippedReportEditModel
    {
        public long CallId { get; set; }
        public long CustomerId { get; set; }
        public long AgentId { get; set; }
        public long CallQueueCustomerId { get; set; }
        public long CallAttemptId { get; set; }
        public string SkipCallNote { get; set; }
        public long HealthPlanId { get; set; }
        public long CallQueueId { get; set; }
        public DateTime SkipCallDate { get; set; }
    }
}
