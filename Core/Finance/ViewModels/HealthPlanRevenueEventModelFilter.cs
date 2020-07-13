using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class HealthPlanRevenueEventModelFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
