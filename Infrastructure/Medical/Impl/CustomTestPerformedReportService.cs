using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CustomTestPerformedReportService : ICustomTestPerformedReportService
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ITestRepository _testRepository;
        private readonly ICustomTestPerformedListModelFactory _customTestPerformedListModelFactory;
        
        public CustomTestPerformedReportService(IEventCustomerResultRepository eventCustomerResultRepository, IEventRepository eventRepository, ICustomerRepository customerRepository, IEventCustomerRepository eventCustomerRepository,
            ITestRepository testRepository, ICustomTestPerformedListModelFactory customTestPerformedListModelFactory)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _testRepository = testRepository;
            _customTestPerformedListModelFactory = customTestPerformedListModelFactory;
        }

        public ListModelBase<CustomTestPerformedViewModel, CustomTestPerformedReportFilter> CustomTestPerformedReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomerResults = _eventCustomerRepository.GetEventCustomerResultByFilter(filter as CustomTestPerformedReportFilter, pageNumber, pageSize, out totalRecords);

            if (eventCustomerResults.IsNullOrEmpty())
            {
                return null;
            }

            var eventCustomeResultIds = eventCustomerResults.Select(x => x.EventCustomerId).ToArray();
            var customerEventScreeningTests = _eventCustomerResultRepository.GetCustomerEventScreeningTestsByEventCustomerResultIds(eventCustomeResultIds);

            var events = _eventRepository.GetEventswithPodbyIds(eventCustomerResults.Select(ecr => ecr.EventId).Distinct().ToArray());
            var customers = _customerRepository.GetCustomers(eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray());
            var tests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(customerEventScreeningTests.Select(ces => ces.TestId).Distinct().ToArray());

            return _customTestPerformedListModelFactory.Create(eventCustomerResults, customerEventScreeningTests, events, customers, tests);
        }
    }
}