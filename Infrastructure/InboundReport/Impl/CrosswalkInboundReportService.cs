using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using NLog;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class CrosswalkInboundReportService : ICrosswalkInboundReportService
    {
        private readonly ICrosswalkInboundReportFactory _crosswalkInboundReportFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;
        private readonly IRelationshipRepository _relationshipRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private const int PageSize = 100;



        public CrosswalkInboundReportService(ICrosswalkInboundReportFactory crosswalkInboundReportFactory, IEventCustomerResultRepository eventCustomerResultRepository, ICustomerRepository customerRepository, IChaseOutboundRepository chaseOutboundRepository,
            IChaseCampaignRepository chaseCampaignRepository, IRelationshipRepository relationshipRepository, IEventCustomerRepository eventCustomerRepository, IUniqueItemRepository<File> fileRepository, IEventRepository eventRepository,
            IUniqueItemRepository<CorporateAccount> corporateAccountRepository)
        {
            _crosswalkInboundReportFactory = crosswalkInboundReportFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerRepository = customerRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
            _relationshipRepository = relationshipRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _fileRepository = fileRepository;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public ListModelBase<CrosswalkInboundViewModel, CrosswalkInboundFilter> GetCrosswalkInboundReportList(CrosswalkInboundFilter filter, ILogger logger)
        {
            filter = filter ?? new CrosswalkInboundFilter();

            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsToFax((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, filter.EndDate.HasValue ? filter.EndDate.Value : DateTime.Now, filter.StartDate,
                filter.AccountId, filter.Tag, true, filter.CustomTags, true, stopSendingPdftoHealthPlanDate: filter.StopSendingPdftoHealthPlanDate);
            if (!eventCustomerResults.IsNullOrEmpty())
            {
                eventCustomerResults = eventCustomerResults.OrderBy(x => x.Id);
                var collection = new List<CrosswalkInboundViewModel>();

                var account = _corporateAccountRepository.GetById(filter.AccountId);

                var pageNumber = 1;
                while (true)
                {
                    var totalRecords = eventCustomerResults.Count();

                    logger.Info(string.Format("Total Number of Records: {0} Current Page:  {1}", totalRecords, pageNumber));

                    var pagedEventCustomerResults = eventCustomerResults.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToArray();

                    var eventCustomerIds = pagedEventCustomerResults.Select(x => x.Id);
                    var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

                    var customerIds = pagedEventCustomerResults.Select(x => x.CustomerId).ToArray();
                    var customers = _customerRepository.GetCustomers(customerIds);

                    var eventIds = pagedEventCustomerResults.Select(x => x.EventId).ToArray();
                    var events = _eventRepository.GetEvents(eventIds);

                    var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

                    var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds);
                    var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
                    var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

                    var relationships = _relationshipRepository.GetAll();

                    var customerEventScreeningTests = _eventCustomerResultRepository.GetByEventCustomerResultAndTestIds(eventCustomerIds, new[] { (long)TestType.IFOBT, (long)TestType.UrineMicroalbumin });

                    var customerEventScreeningTestIds = customerEventScreeningTests.Select(x => x.Id);
                    var customerEventScreeningTestIdFileIdPairs = _eventCustomerResultRepository.GetCustomerEventScreeningTestIdFileIdPairs(customerEventScreeningTestIds);

                    collection.AddRange(_crosswalkInboundReportFactory.Create(customers, chaseOutbounds, customerChaseCampaigns, chaseCampaigns, relationships, eventCustomers, pagedEventCustomerResults, events, account, customerEventScreeningTests,
                                            customerEventScreeningTestIdFileIdPairs));

                    if (pageNumber * PageSize >= totalRecords)
                        break;

                    pageNumber++;
                }

                return new CrosswalkInboundListModel
                {
                    Collection = collection
                };
            }

            return null;
        }

        public ListModelBase<CrosswalkLabInboundViewModel, CrosswalkLabInboundFilter> GetCrosswalkLabInboundReportList(CrosswalkLabInboundFilter filter)
        {
            filter = filter ?? new CrosswalkLabInboundFilter();

            var eventCustomerResults = _eventCustomerResultRepository.GetForCrosswalkLabReport((int)TestResultStateNumber.ResultDelivered, (int)NewTestResultStateNumber.ResultDelivered, false, filter.EndDate.HasValue ? filter.EndDate.Value : DateTime.Now, filter.StartDate, filter.AccountId, filter.Tag, customTags: filter.CustomTags);
            if (!eventCustomerResults.IsNullOrEmpty())
            {
                var eventCustomerIds = eventCustomerResults.Select(x => x.Id);
                var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

                var customerIds = eventCustomerResults.Select(x => x.CustomerId).ToArray();
                var customers = _customerRepository.GetCustomers(customerIds);

                var eventIds = eventCustomers.Select(x => x.EventId).ToArray();
                var events = _eventRepository.GetEvents(eventIds);

                var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);

                var customerChaseCampaigns = _chaseCampaignRepository.GetCustomerChaseCampaignsByCustomerIds(customerIds);
                var chaseCampaignIds = customerChaseCampaigns.Select(x => x.ChaseCampaignId).Distinct();
                var chaseCampaigns = _chaseCampaignRepository.GetByIds(chaseCampaignIds);

                var relationships = _relationshipRepository.GetAll();

                var customerEventScreeningTests = _eventCustomerResultRepository.GetByEventCustomerResultAndTestIds(eventCustomerIds, new long[] { (long)TestType.IFOBT, (long)TestType.UrineMicroalbumin });

                var customerEventScreeningTestIds = customerEventScreeningTests.Select(x => x.Id);
                var customerEventScreeningTestIdFileIdPairs = _eventCustomerResultRepository.GetCustomerEventScreeningTestIdFileIdPairs(customerEventScreeningTestIds);

                var fileIds = customerEventScreeningTestIdFileIdPairs.Select(x => x.SecondValue);
                var files = _fileRepository.GetByIds(fileIds);

                return _crosswalkInboundReportFactory.CreateCrosswalkLabInboundList(customers, chaseOutbounds, customerChaseCampaigns, chaseCampaigns, relationships, eventCustomers, eventCustomerResults, events, customerEventScreeningTests, customerEventScreeningTestIdFileIdPairs, files);
            }

            return null;
        }
    }
}
