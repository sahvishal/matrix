using Falcon.App.Core.Finance.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance
{
    public interface IHealthPlanRevenueItemRepository
    {
        IEnumerable<HealthPlanRevenueItem> GetAllHealthPlanRevenueItemById(long revenuId);
        HealthPlanRevenueItem Save(HealthPlanRevenueItem domain);
        IEnumerable<HealthPlanRevenueItem> GetAllHealthPlanRevenueItemByIds(IEnumerable<long> revenueIds);
    }
}
