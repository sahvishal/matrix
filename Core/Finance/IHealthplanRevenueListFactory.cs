using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IHealthplanRevenueListFactory
    {
      HealthPlanRevenueDetailsListModel CreateHealthPlanDetails(HealthPlanRevenue healthPlanRevenue, IEnumerable<OrderedPair<long, decimal>> customerAndRevenuePairs, CorporateAccount corporateAccount,
            IEnumerable<HealthPlanRevenue> healthPlanRevenueList, IEnumerable<HealthPlanRevenueItem> healthPlanRevenueItems, IEnumerable<OrderedPair<long, string>> packages,
           IEnumerable<OrderedPair<long, string>> tests, int maleCustomerCount, int femaleCustomerCount);

      HealthPlanRevenueEventListModel GetEventListByHealthPlan(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> customersAttended);
    }

}