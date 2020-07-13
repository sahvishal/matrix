using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IHealthPlanRevenueHelper
    {
        IEnumerable<OrderedPair<long, decimal>> GetHealthplanRevenue(IEnumerable<HealthPlanRevenue> healthPlanRevenues);

        void GetReveneuePairByCustomer(HealthPlanRevenue revenue, HealthPlanRevenueItem revenueItem, List<OrderedPair<long, decimal>> list);
        void GetRevenuePairByTest(IEnumerable<HealthPlanRevenueItem> accountRevenueItems, HealthPlanRevenue revenue, List<OrderedPair<long, decimal>> list);
        void GetRevenuePairByPacakge(IEnumerable<HealthPlanRevenueItem> accountRevenueItems, HealthPlanRevenue revenue, List<OrderedPair<long, decimal>> list);
    }
}