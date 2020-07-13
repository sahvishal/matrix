
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using System.Collections.Generic;
namespace Falcon.App.Core.Finance
{
    public interface IHealthPlanRevenueFactory
    {
       HealthPlanRevenueEditModel Create(HealthPlanRevenue healthPlanRevenue, IEnumerable<HealthPlanRevenueItem>  healthPlanRevenueItems);
        HealthPlanRevenue MapHealthPlanRevenueInfo(HealthPlanRevenueEditModel model, long createdById);
        IEnumerable<HealthPlanRevenueItem> MapHealthPlanRevenueItemInfo(HealthPlanRevenueEditModel model, long healthPlanRevenueId);
    }
}
