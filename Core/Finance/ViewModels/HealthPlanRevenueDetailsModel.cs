
using System.Collections.Generic;
namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueDetailsModel
    {
        public string HealthPlanName { get; set; }
        public long HealthPlanId { get; set; }
        public string PricingType { get; set; }
        public long HealthPlanRevenuePricingTypeId { get; set; }
        public decimal TotalRevenue { get; set; }
        public long CustomerMaleCount { get; set; }
        public long CustomerFemaleCount { get; set; }
        public long TotalCustomerCount { get; set; }
    }
}
 