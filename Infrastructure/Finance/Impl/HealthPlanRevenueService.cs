using System;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class HealthPlanRevenueService : IHealthPlanRevenueService
    {
        private readonly IHealthPlanRevenueFactory _healthPlanRevenueFactory;
        private readonly IHealthPlanRevenueRepository _healthPlanRevenueRepository;
        private readonly IHealthPlanRevenueItemRepository _healthPlanRevenueItemRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly ITestRepository _testRepository;
        private readonly IHealthplanRevenueListFactory _healthplanRevenueListFactory;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanRevenueHelper _healthPlanRevenueHelper;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;

        public HealthPlanRevenueService(IHealthPlanRevenueFactory healthPlanRevenueFactory, IHealthPlanRevenueRepository healthPlanRevenueRepository,
            IHealthPlanRevenueItemRepository healthPlanRevenueItemRepository, IPackageRepository packageRepository, ITestRepository testRepository,
            ICorporateAccountRepository corporateAccountRepository, IHealthPlanRevenueHelper healthPlanRevenueHelper, IHealthplanRevenueListFactory healthplanRevenueListFactory, IEventCustomerRepository eventCustomerRepository,
            IEventRepository eventRepository, IHostRepository hostRepository)
        {
            _healthPlanRevenueFactory = healthPlanRevenueFactory;
            _healthPlanRevenueRepository = healthPlanRevenueRepository;
            _healthPlanRevenueItemRepository = healthPlanRevenueItemRepository;
            _packageRepository = packageRepository;
            _testRepository = testRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanRevenueHelper = healthPlanRevenueHelper;
            _healthplanRevenueListFactory = healthplanRevenueListFactory;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
        }

        public HealthPlanRevenueEditModel GetHealthPlanRevenueById(long id)
        {
            var healthPlanRevenueDetail = _healthPlanRevenueRepository.GetHealthPlanRevenueId(id);
            var healthPlanRevenueItems = _healthPlanRevenueItemRepository.GetAllHealthPlanRevenueItemById(healthPlanRevenueDetail.Id);
            return _healthPlanRevenueFactory.Create(healthPlanRevenueDetail, healthPlanRevenueItems);
        }
        public IEnumerable<OrderedPair<long, string>> GetHealthPlansPackages(long healthPlanId)
        {
            var packagesDetails = new List<OrderedPair<long, string>>();
            var packages = _packageRepository.GetPackagesByHealthPlanId(healthPlanId);

            if (packages != null)
            {
                packagesDetails = packages.Select(ct => new OrderedPair<long, string>()
                {
                    FirstValue = ct.Id,
                    SecondValue = ct.Name
                }).ToList();
            }

            return packagesDetails;
        }

        public IEnumerable<OrderedPair<long, string>> GetHealthPlansTests(long healthPlanId)
        {
            var testsDetails = new List<OrderedPair<long, string>>();
            var tests = _testRepository.GetTestsByHealthPlanId(healthPlanId);

            if (tests != null)
            {
                testsDetails = tests.Select(ct => new OrderedPair<long, string>()
                {
                    FirstValue = ct.Id,
                    SecondValue = ct.Name
                }).ToList();
            }

            return testsDetails;
        }

        public HealthPlanRevenueListModel GetHealthPlanRevenues(HealthPlanRevenueListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var healthPlans = _corporateAccountRepository.GetHealthPlanbyFilter(pageNumber, pageSize, filter, out totalRecords);

            if (healthPlans.IsNullOrEmpty())
            {
                return null;
            }

            var healthPlanRevenues = _healthPlanRevenueRepository.GetByHealthPlanIds(healthPlans.Select(x => x.Id));


            var healthPlanRevenueViewModelList = new List<HealthPlanRevenueViewModel>();
            var listModel = new HealthPlanRevenueListModel();

            foreach (var corporateAccount in healthPlans)
            {
                var revenueCustomerPair = _healthPlanRevenueHelper.GetHealthplanRevenue(healthPlanRevenues.Where(x => x.AccountId == corporateAccount.Id));
                var model = new HealthPlanRevenueViewModel
                {
                    HealthPlanName = corporateAccount.Name,
                    HealthPlanId = corporateAccount.Id,
                };

                if (revenueCustomerPair != null && revenueCustomerPair.Any())
                {
                    model.ShowDetails = true;
                    model.TotalCustomer = revenueCustomerPair.Sum(x => x.FirstValue);
                    model.Revenue = revenueCustomerPair.Sum(x => x.SecondValue);
                }

                healthPlanRevenueViewModelList.Add(model);
            }

            listModel.Collection = healthPlanRevenueViewModelList;

            return listModel;
        }

        public HealthPlanRevenueEditModel SaveHealthPlanRevenue(HealthPlanRevenueEditModel model, long createdBy)
        {

            var healthPlanRevenue = _healthPlanRevenueFactory.MapHealthPlanRevenueInfo(model, createdBy);
            var helathPlanPrevious = _healthPlanRevenueRepository.GetHealthPlanRevenuesId(model.HealthPlanId);

            if (helathPlanPrevious != null && helathPlanPrevious.Any())
            {
                foreach (var revenue in helathPlanPrevious)
                {
                    if (revenue.DateFrom >= model.DateFrom.Value)
                    {
                        _healthPlanRevenueRepository.DeleteRevenue(revenue.Id);
                    }
                    else if (revenue.DateTo == null)
                    {
                        _healthPlanRevenueRepository.UpdatePreviousHealthPlanRevenue(model.DateFrom.Value, revenue.Id);
                    }
                    else if (revenue.DateTo.HasValue && revenue.DateTo.Value >= model.DateFrom.Value && revenue.DateTo.Value <= DateTime.Today)
                    {
                        _healthPlanRevenueRepository.UpdatePreviousHealthPlanRevenue(model.DateFrom.Value, revenue.Id);
                    }

                }

            }

            var healthPlanSaved = _healthPlanRevenueRepository.Save(healthPlanRevenue);
            var healthPlanRevenueItems = _healthPlanRevenueFactory.MapHealthPlanRevenueItemInfo(model, healthPlanSaved.Id);

            foreach (var item in healthPlanRevenueItems)
            {
                _healthPlanRevenueItemRepository.Save(item);
            }

            model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Health Plan Revenue Saved Successfully.");
            return model;
        }

        public HealthPlanRevenueDetailsListModel GetHealthPlanRevenueDetails(long healthPlanId)
        {
            var currentHealthPlanRevenue = _healthPlanRevenueRepository.GetHealthPlanRevenueId(healthPlanId);

            var healthPlanRevenueList = _healthPlanRevenueRepository.GetListByHealthPlanId(healthPlanId);

            if (healthPlanRevenueList == null && !healthPlanRevenueList.Any()) return null;

            if (currentHealthPlanRevenue == null)
            {
                currentHealthPlanRevenue = healthPlanRevenueList.OrderBy(x => x.DataRecorderMetaData.DateCreated).First();
            }

            var packages = GetHealthPlansPackages(healthPlanId);
            var tests = GetHealthPlansTests(healthPlanId);
            var healthPlanRevenueItemList = _healthPlanRevenueItemRepository.GetAllHealthPlanRevenueItemByIds(healthPlanRevenueList.Select(x => x.Id));
            var maleCustomerCount = 0;
            var femaleCustomerCount = 0;
            //foreach (var revenue in healthPlanRevenueList)
            //{
            //    var accountRevenueItems = healthPlanRevenueItemList.Where(x => x.HealthPlanRevenueId == revenue.Id);

            //    if (revenue.RevenueItemTypeId == (long)HealthPlanRevenueType.PerCustomer)
            //    {
            //        //var maleFemaleCountByCustomer = _eventCustomerRepository.GetCustomerMaleFemaleCountForHealthPlanRevenueByCustomer(healthPlanId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1));
            //        //if (maleFemaleCountByCustomer != null)
            //        //{
            //        //    maleCustomerCount = maleCustomerCount + maleFemaleCountByCustomer.FirstValue;
            //        //    femaleCustomerCount = femaleCustomerCount + maleFemaleCountByCustomer.SecondValue;
            //        //}
            //    }
            //    else if (revenue.RevenueItemTypeId == (long)HealthPlanRevenueType.PerPackage)
            //    {
            //        var packageRevenueItems = accountRevenueItems.Where(x => x.PackageId.HasValue);
            //        var packageIds = packageRevenueItems.Select(x => x.PackageId.Value).Distinct();
            //        var maleFemaleCountByPackages = _eventCustomerRepository.GetMaleFemaleCountForHealthPlanRevenueByPackage(healthPlanId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1), packageIds);
            //        if (maleFemaleCountByPackages != null)
            //        {
            //            maleCustomerCount = maleCustomerCount + maleFemaleCountByPackages.FirstValue;
            //            femaleCustomerCount = femaleCustomerCount + maleFemaleCountByPackages.SecondValue;
            //        }
            //    }
            //    else if (revenue.RevenueItemTypeId == (long)HealthPlanRevenueType.PerTest)
            //    {
            //        var testIdRevenueItems = accountRevenueItems.Where(x => x.TestId.HasValue);
            //        var testIds = testIdRevenueItems.Select(x => x.TestId.Value).Distinct();
            //        var maleFemaleCountByPackageTest = _eventCustomerRepository.GetMaleFemaleCountForHealthPlanRevenueByPackageTest(healthPlanId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1), testIds);
            //        var maleFemaleCountByTest = _eventCustomerRepository.GetMaleFemaleCountForHealthPlanRevenueByTest(healthPlanId, revenue.DateFrom, revenue.DateTo ?? DateTime.Today.AddDays(1), testIds);

            //        if (maleFemaleCountByTest != null)
            //        {
            //            maleCustomerCount = maleCustomerCount + maleFemaleCountByTest.FirstValue;
            //            femaleCustomerCount = femaleCustomerCount + maleFemaleCountByTest.SecondValue;
            //        }
            //        if (maleFemaleCountByPackageTest != null)
            //        {
            //            maleCustomerCount = maleCustomerCount + maleFemaleCountByPackageTest.FirstValue;
            //            femaleCustomerCount = femaleCustomerCount + maleFemaleCountByPackageTest.SecondValue;
            //        }
            //    }
            //}
            var healthPlanCustomerAndRevenuePairs = _healthPlanRevenueHelper.GetHealthplanRevenue(healthPlanRevenueList);
            var corporateAccount = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(healthPlanId);
            return _healthplanRevenueListFactory.CreateHealthPlanDetails(currentHealthPlanRevenue, healthPlanCustomerAndRevenuePairs, corporateAccount, healthPlanRevenueList, healthPlanRevenueItemList, packages, tests, maleCustomerCount, femaleCustomerCount);
        }

        public HealthPlanRevenueEventListModel GetEventListByHealthPlan(HealthPlanRevenueEventModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var firstCreatedHealthPlanRevenue = _healthPlanRevenueRepository.GetHealthPlanRevenueForEventListing(filter.HealthPlanId);
            totalRecords = 0;
            if (firstCreatedHealthPlanRevenue == null)
            {
                return null;
            }

            filter.DateFrom = firstCreatedHealthPlanRevenue.DateFrom;
            filter.DateTo = filter.DateTo ?? DateTime.Today.AddDays(1);

            var events = _eventRepository.GetEventListByHealthPlanId(pageNumber, pageSize, filter, out totalRecords);
            if (events == null || !events.Any()) return null;

            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);

            return _healthplanRevenueListFactory.GetEventListByHealthPlan(events, hosts, customersAttended);
        }
    }
}
