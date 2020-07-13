using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpSummaryLogReportModelFilter : ModelFilterBase
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long HealthPlanId { get; set; }
        public string Tag { get; set; }
    }
}
