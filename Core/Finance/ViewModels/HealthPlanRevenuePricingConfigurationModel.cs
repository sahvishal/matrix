using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenuePricingConfigurationModel
    {
        public DateTime EffectiveDate { get; set; }
        public string PricingType { get; set; }
        public decimal Price { get; set; }
        public long HealthPlanRevenuePricingTypeId { get; set; }
        public IEnumerable<OrderedPair<string, decimal>> PackageAndPricePairs { get; set; }
        public IEnumerable<OrderedPair<string, decimal>> TestAndPricePairs { get; set; }
    }
}
