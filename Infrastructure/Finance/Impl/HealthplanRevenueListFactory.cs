using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class HealthplanRevenueListFactory : IHealthplanRevenueListFactory
    {
        public HealthPlanRevenueDetailsListModel CreateHealthPlanDetails(HealthPlanRevenue currrentRevenuePlan, IEnumerable<OrderedPair<long, decimal>> customerAndRevenuePairs, CorporateAccount corporateAccount,
            IEnumerable<HealthPlanRevenue> healthPlanRevenueList, IEnumerable<HealthPlanRevenueItem> healthPlanRevenueItems, IEnumerable<OrderedPair<long, string>> packages,
           IEnumerable<OrderedPair<long, string>> tests, int maleCustomerCount,int femaleCustomerCount)
        {
            var model = new HealthPlanRevenueDetailsListModel();
            decimal totalRevenue = 0;
            long totalCustomerCount = 0;
            if (customerAndRevenuePairs != null && customerAndRevenuePairs.Any())
            {
                foreach (var item in customerAndRevenuePairs)
                {
                    totalRevenue = totalRevenue + item.SecondValue;
                    totalCustomerCount = totalCustomerCount + item.FirstValue;
                }
            }
           
            var objHealthPlanRevenue = new HealthPlanRevenueDetailsModel
            {
                HealthPlanName = corporateAccount.Name,
                HealthPlanId = corporateAccount.Id,
                PricingType = ((HealthPlanRevenueType)currrentRevenuePlan.RevenueItemTypeId).GetDescription(),
                TotalRevenue = totalRevenue,
                TotalCustomerCount = totalCustomerCount,
                CustomerMaleCount = maleCustomerCount,
                CustomerFemaleCount = femaleCustomerCount
            };
            model.HealthPlanRevenueDetails = objHealthPlanRevenue;
            model.PricingConfigurationModel = BindPricingConfiguration(healthPlanRevenueList, healthPlanRevenueItems, packages, tests);
            return model;
        }
        private IEnumerable<HealthPlanRevenuePricingConfigurationModel> BindPricingConfiguration(IEnumerable<HealthPlanRevenue> healthPlanRevenueList, IEnumerable<HealthPlanRevenueItem> healthPlanRevenueItems
            , IEnumerable<OrderedPair<long, string>> packages,
           IEnumerable<OrderedPair<long, string>> tests)
        {
            var model = new List<HealthPlanRevenuePricingConfigurationModel>();
            foreach (var item in healthPlanRevenueList)
            {
                var obj = new HealthPlanRevenuePricingConfigurationModel();
                obj.EffectiveDate = item.DateFrom;
                obj.HealthPlanRevenuePricingTypeId = item.RevenueItemTypeId;
                obj.PricingType = ((HealthPlanRevenueType)item.RevenueItemTypeId).GetDescription();
                if (item.RevenueItemTypeId == (long)HealthPlanRevenueType.PerCustomer)
                    obj.Price = healthPlanRevenueItems.Single(m => m.HealthPlanRevenueId == item.Id).Price;
                else if (item.RevenueItemTypeId == (long)HealthPlanRevenueType.PerPackage)
                    obj.PackageAndPricePairs = GetPackageDetails(item, healthPlanRevenueItems, packages);
                else if (item.RevenueItemTypeId == (long)HealthPlanRevenueType.PerTest)
                    obj.TestAndPricePairs = GetTestDetails(item, healthPlanRevenueItems, tests);
                model.Add(obj);
            }
            return model;
        }
        private IEnumerable<OrderedPair<string, decimal>> GetTestDetails(HealthPlanRevenue healthPlanRevenue, IEnumerable<HealthPlanRevenueItem> healthPlanRevenueItems, IEnumerable<OrderedPair<long, string>> tests)
        {
            var testList = new List<OrderedPair<string, decimal>>();
            foreach (var item in healthPlanRevenueItems)
            {
                if (tests != null && tests.Any() && item.HealthPlanRevenueId == healthPlanRevenue.Id)
                {
                    testList.Add(new OrderedPair<string, decimal>(tests.First(x => x.FirstValue == item.TestId).SecondValue, item.Price));
                }
            }
            return testList;
        }
        private IEnumerable<OrderedPair<string, decimal>> GetPackageDetails(HealthPlanRevenue healthPlanRevenue, IEnumerable<HealthPlanRevenueItem> healthPlanRevenueItems, IEnumerable<OrderedPair<long, string>> packages)
        {
            var packageList = new List<OrderedPair<string, decimal>>();
            foreach (var item in healthPlanRevenueItems)
            {
                if (packages != null && packages.Any() && item.HealthPlanRevenueId == healthPlanRevenue.Id)
                {
                    packageList.Add(new OrderedPair<string, decimal>(packages.First(x => x.FirstValue == item.PackageId).SecondValue, item.Price));
                }
            }
            return packageList;
        }

        public HealthPlanRevenueEventListModel GetEventListByHealthPlan(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> customersAttended)
        {
            var model =new HealthPlanRevenueEventListModel();
            var healthPlanRevenueEventInfoList = new List<HealthPlanRevenueEventInfoModel>();
            events.ToList().ForEach(e =>
            {
                var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();
                
                var screenedCustomersCount = customersAttended.Where(bs => bs.FirstValue == e.Id).FirstOrDefault().SecondValue;

                var healthPlanRevenueEventInfo = new HealthPlanRevenueEventInfoModel
                {
                    EventId = e.Id,
                    Location = host != null ? host.Address : null,
                    ScreenedCustomers = screenedCustomersCount,
                };
                healthPlanRevenueEventInfoList.Add(healthPlanRevenueEventInfo);
            });
            model.Collection = healthPlanRevenueEventInfoList;
            return model;

        }
    }
}
