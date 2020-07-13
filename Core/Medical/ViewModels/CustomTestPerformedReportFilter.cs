using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomTestPerformedReportFilter : ModelFilterBase
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long HealthPlanId { get; set; }
        public string[] CustomTags { get; set; }
        public bool ExcludeCustomerWithCustomTag { get; set; }
        public string Tag { get; set; }
    }
}