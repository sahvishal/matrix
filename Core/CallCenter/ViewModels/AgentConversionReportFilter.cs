using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class AgentConversionReportFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long CallCenterAgentId { get; set; }

        public bool ShowPreviousDayData { get; set; }
    }
}
