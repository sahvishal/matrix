using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using System;

namespace Falcon.App.Core.Finance
{
    public interface IHealthPlanRevenueRepository
    {
        HealthPlanRevenue GetHealthPlanRevenueId(long healthPlanId);
        HealthPlanRevenue Save(HealthPlanRevenue domain);
        IEnumerable<HealthPlanRevenue> GetByHealthPlanIds(IEnumerable<long> healthPlanIds);
        bool UpdatePreviousHealthPlanRevenue(DateTime dateTo, long healthPlanRevenueId);
        IEnumerable<HealthPlanRevenue> GetListByHealthPlanId(long healthPlanId);
        IEnumerable<HealthPlanRevenue> GetHealthPlanRevenuesId(long healthPlanId);
        HealthPlanRevenue GetHealthPlanRevenueForEventListing(long healthPlanId);
        bool DeleteRevenue(long revenueId);

    }
}
