using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class LabsInboundReportService : ILabsInboundReportService
    {
        private readonly ILabsInboundReportFactory _labsInboundReportFactory;
        private readonly ICustomerEventTestStateRepository _customerEventTestStateRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;
        private readonly ITestRepository _testRepository;

        public LabsInboundReportService(ILabsInboundReportFactory labsInboundReportFactory, ICustomerEventTestStateRepository customerEventTestStateRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IEventCustomerRepository eventCustomerRepository, IUniqueItemRepository<Event> eventRepository, ICustomerRepository customerRepository, IChaseOutboundRepository chaseOutboundRepository, IChaseCampaignRepository chaseCampaignRepository, ITestRepository testRepository)
        {
            _labsInboundReportFactory = labsInboundReportFactory;
            _customerEventTestStateRepository = customerEventTestStateRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _customerRepository = customerRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
            _testRepository = testRepository;
        }

        public ListModelBase<LabsInboundViewModel, LabsInboundFilter> GetLabsInboundReportList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new LabsInboundFilter();

            var customerEventTestStates = _customerEventTestStateRepository.GetForLabInboundReport(filter as LabsInboundFilter, pageNumber, pageSize, out totalRecords);

            if (customerEventTestStates.IsNullOrEmpty()) return null;

            var customerEventScreeningTestIds = customerEventTestStates.Select(x => x.CustomerEventScreeningTestId).Distinct();
            var customerEventScreeningTests = _eventCustomerResultRepository.GetCustomerEventScreeningTestsByIds(customerEventScreeningTestIds);

            var testIds = customerEventScreeningTests.Select(x => x.TestId).Distinct();
            var tests = _testRepository.GetTestByIds(testIds);

            var eventCustomerResultIds = customerEventScreeningTests.Select(x => x.EventCustomerResultId).Distinct();
            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerResultIds);
            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerResultIds);

            var eventIds = eventCustomers.Select(x => x.EventId).Distinct();
            var events = _eventRepository.GetByIds(eventIds);
            var customerIds = eventCustomers.Select(x => x.CustomerId).Distinct().ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

            var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds);
            var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
            var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

            return _labsInboundReportFactory.Create(customerEventTestStates, customerEventScreeningTests, eventCustomers, customers, chaseOutbounds, customerChaseCampaigns, chaseCampaigns, tests, events, eventCustomerResults);
        }
    }
}
