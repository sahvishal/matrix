using System.Collections.Generic;
namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueDetailsListModel 
    {
        public IEnumerable<HealthPlanRevenuePricingConfigurationModel> PricingConfigurationModel { get; set; }
        public HealthPlanRevenueDetailsModel HealthPlanRevenueDetails { get; set; }
        public HealthPlanRevenueEventListModel HealthPlanRevenueEventListModel { get; set; }
        public long SelectedAccountId { get; set; }
    }
}
