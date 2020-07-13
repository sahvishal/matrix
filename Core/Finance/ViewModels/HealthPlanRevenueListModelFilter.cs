using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    [NoValidationRequired]
    public class HealthPlanRevenueListModelFilter : ModelFilterBase
    {
        public long HealthPlanId { get; set; }
    }
}