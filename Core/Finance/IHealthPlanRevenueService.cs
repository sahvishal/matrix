using Falcon.App.Core.Finance.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance
{
    public interface IHealthPlanRevenueService
    {
        HealthPlanRevenueEditModel GetHealthPlanRevenueById(long id);
        IEnumerable<OrderedPair<long, string>> GetHealthPlansPackages(long healthPlanId);
        IEnumerable<OrderedPair<long, string>> GetHealthPlansTests(long healthPlanId);
        HealthPlanRevenueEditModel SaveHealthPlanRevenue(HealthPlanRevenueEditModel model, long createdBy);

        HealthPlanRevenueListModel GetHealthPlanRevenues(HealthPlanRevenueListModelFilter filter, int pageNumber,int pageSize, out int totalRecords);
        HealthPlanRevenueDetailsListModel GetHealthPlanRevenueDetails(long healthPlanId);
        HealthPlanRevenueEventListModel GetEventListByHealthPlan(HealthPlanRevenueEventModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}
