using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Finance.Impl
{

    [DefaultImplementation]
    public class HealthPlanRevenueHelper : IHealthPlanRevenueHelper
    {
        private readonly IHealthPlanRevenueItemRepository _healthPlanRevenueItemRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public HealthPlanRevenueHelper(IHealthPlanRevenueItemRepository healthPlanRevenueItemRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _healthPlanRevenueItemRepository = healthPlanRevenueItemRepository;
            _eventCustomerRepository = eventCustomerRepository;
        }

        public IEnumerable<OrderedPair<long, decimal>> GetHealthplanRevenue(IEnumerable<HealthPlanRevenue> healthPlanRevenues)
        {
            if (healthPlanRevenues == null || !healthPlanRevenues.Any()) return null;

            var revenueItems = _healthPlanRevenueItemRepository.GetAllHealthPlanRevenueItemByIds(healthPlanRevenues.Select(x => x.Id));
            var list = new List<OrderedPair<long, decimal>>();

            foreach (var revenue in healthPlanRevenues)
            {
                var accountRevenueItems = revenueItems.Where(x => x.HealthPlanRevenueId == revenue.Id);

                if (revenue.RevenueItemTypeId == (long)HealthPlanRevenueType.PerCustomer)
                {
                    var revenueItem = revenueItems.Single(x => x.HealthPlanRevenueId == revenue.Id);
                    GetReveneuePairByCustomer(revenue, revenueItem, list);
                }
                else if (revenue.RevenueItemTypeId == (long)HealthPlanRevenueType.PerPackage)
                {
                    GetRevenuePairByPacakge(accountRevenueItems, revenue, list);
                }
                else if (revenue.RevenueItemTypeId == (long)HealthPlanRevenueType.PerTest)
                {
                    GetRevenuePairByTest(accountRevenueItems, revenue, list);
                }
            }

            return list;
        }

        public void GetReveneuePairByCustomer(HealthPlanRevenue revenue, HealthPlanRevenueItem revenueItem, List<OrderedPair<long, decimal>> list)
        {
            var customerCount = _eventCustomerRepository.GetEventCustomerCountForHealthPlanRevenueByCustomer(revenue.AccountId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1));
            var price = revenueItem.Price;

            var revenueGenderated = (price * customerCount);

            list.Add(new OrderedPair<long, decimal>(customerCount, revenueGenderated));
        }

        public void GetRevenuePairByTest(IEnumerable<HealthPlanRevenueItem> accountRevenueItems, HealthPlanRevenue revenue, List<OrderedPair<long, decimal>> list)
        {

            var testIdRevenueItems = accountRevenueItems.Where(x => x.TestId.HasValue);
            var testIds = testIdRevenueItems.Select(x => x.TestId.Value).Distinct();

            var testAvailedTestPair = _eventCustomerRepository.GetTestAvailedForHealthPlanRevenueByTest(revenue.AccountId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1), testIds);
            var customerCountByTest = _eventCustomerRepository.GetCustomerCountForHealthPlanRevenueByTest(revenue.AccountId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1), testIds);

            decimal revenueGeneatedbyTest = 0;
           
            foreach (var testId in testIds)
            {
                var customersAvailedTestPair = testAvailedTestPair.SingleOrDefault(x => x.FirstValue == testId);

                if (customersAvailedTestPair != null)
                {
                    var customersAvailedTest = customersAvailedTestPair.SecondValue;

                    var testPrice = testIdRevenueItems.First(x => x.TestId.Value == testId).Price;

                    revenueGeneatedbyTest = revenueGeneatedbyTest + (testPrice * customersAvailedTest);
                }
            }

            list.Add(new OrderedPair<long, decimal>(customerCountByTest, revenueGeneatedbyTest));

        }

        public void GetRevenuePairByPacakge(IEnumerable<HealthPlanRevenueItem> accountRevenueItems, HealthPlanRevenue revenue, List<OrderedPair<long, decimal>> list)
        {
            var packageRevenueItems = accountRevenueItems.Where(x => x.PackageId.HasValue);

            var pacakgeIds = packageRevenueItems.Select(x => x.PackageId.Value).Distinct();

            var customerCountByPackage = _eventCustomerRepository.GetEventCustomerCountForHealthPlanRevenueByPackage(revenue.AccountId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1), pacakgeIds);

            decimal revenueGeneatedbyPackage = 0;
            long customerCount = 0;

            foreach (var pacakgeId in pacakgeIds)
            {
                var customersAvailedPackagePair = customerCountByPackage.SingleOrDefault(x => x.FirstValue == pacakgeId);

                if (customersAvailedPackagePair != null)
                {
                    var customersAvailedPackage = customersAvailedPackagePair.SecondValue;
                    customerCount += customersAvailedPackage;
                    var packagePrice = packageRevenueItems.First(x => x.PackageId.Value == pacakgeId).Price;

                    revenueGeneatedbyPackage = revenueGeneatedbyPackage + (packagePrice * customersAvailedPackage);
                }
            }

            list.Add(new OrderedPair<long, decimal>(customerCount, revenueGeneatedbyPackage));
        }
    }
}