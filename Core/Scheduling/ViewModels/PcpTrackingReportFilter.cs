using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class PcpTrackingReportFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }

        public long? PatientId { get; set; }

        public string PatientName { get; set; }
    }
}
