using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallQueueCustomerReportService : ICallQueueCustomerReportService
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ICallQueueCustomerReportFactory _callQueueCustomerReportFactory;
        private readonly ISettings _settings;
        private readonly IHealthPlanCallQueueCriteriaRepository _callQueueCriteriaRepository;
        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly IGmsCallQueueCustomerModelFactory _gmsCallQueueCustomerModelFactory;
        private readonly IHostRepository _hostRepository;
        private readonly IEventReportingService _eventReportingService;

        private readonly ICustomerAccountGlocomNumberService _customerAccountGlocomNumberService;
        private readonly IExcludedCustomerRepository _excludedCustomerRepository;
        private readonly IDirectMailRepository _directMailRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IMailRoundCustomersReportFactory _mailRoundCustomersReportFactory;


        public CallQueueCustomerReportService(ICallQueueRepository callQueueRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
            ICorporateAccountRepository corporateAccountRepository, ICustomerRepository customerRepository,
            ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, ICallQueueCustomerReportFactory callQueueCustomerReportFactory,
            ISettings settings, IHealthPlanCallQueueCriteriaRepository callQueueCriteriaRepository, IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService,
            IOrganizationRepository organizationRepository, IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService,
            IGmsCallQueueCustomerModelFactory gmsCallQueueCustomerModelFactory, IHostRepository hostRepository, IEventReportingService eventReportingService,
            IDirectMailRepository directMailRepository, ICallCenterCallRepository callCenterCallRepository, IMailRoundCustomersReportFactory mailRoundCustomersReportFactory,
            ICustomerAccountGlocomNumberService customerAccountGlocomNumberService, IExcludedCustomerRepository excludedCustomerRepository)
        {
            _callQueueRepository = callQueueRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;

            _callQueueCustomerReportFactory = callQueueCustomerReportFactory;
            _settings = settings;
            _callQueueCriteriaRepository = callQueueCriteriaRepository;
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _organizationRepository = organizationRepository;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _gmsCallQueueCustomerModelFactory = gmsCallQueueCustomerModelFactory;
            _hostRepository = hostRepository;
            _eventReportingService = eventReportingService;

            _customerAccountGlocomNumberService = customerAccountGlocomNumberService;
            _excludedCustomerRepository = excludedCustomerRepository;

            _directMailRepository = directMailRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _mailRoundCustomersReportFactory = mailRoundCustomersReportFactory;
        }

        public ListModelBase<CallQueueCustomersReportModel, OutboundCallQueueFilter> GetCallQueueCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callQueueFilter = filter as OutboundCallQueueFilter;
            callQueueFilter = callQueueFilter ?? new OutboundCallQueueFilter();
            if (!callQueueFilter.CustomTags.IsNullOrEmpty())
            {
                callQueueFilter.CustomCorporateTag = string.Join(",", callQueueFilter.CustomTags);
            }

            var criteria = _callQueueCriteriaRepository.GetById(callQueueFilter.CriteriaId);

            var callQueueId = callQueueFilter.CallQueueId;

            callQueueFilter.CallQueueId = criteria.CallQueueId;
            callQueueFilter.GmsAccountIds = _settings.GmsAccountIds;
            //callQueueFilter.NumberOfDays = _settings.CustomerReturnInCallQueue;
            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(callQueueFilter);

            var callQueue = _callQueueRepository.GetById(callQueueFilter.CallQueueId);
            var callqueueCustomersList = new List<CallQueueCustomer>();
            totalRecords = 0;


            if (criteria.IsQueueGenerated)
            {
                if (callQueue.Category == HealthPlanCallQueueCategory.CallRound)
                {
                    var customersInQueueList = _callQueueCustomerRepository.GetOutboundCallRoundCallQueue(callQueueFilter, pageNumber, pageSize, callQueue, callQueueFilter.CriteriaId, out totalRecords);
                    callqueueCustomersList = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();
                }
                else if (callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
                {
                    var customersInQueueList = _callQueueCustomerRepository.GetCallQueueCustomerForHealthPlanFillEvents(callQueueFilter, pageNumber, pageSize, callQueueFilter.CriteriaId, callQueue, out totalRecords);
                    callqueueCustomersList = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();
                }
                else if (callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier)
                {
                    var customersInQueueList = _callQueueCustomerRepository.GetLanguageBarrierCallQueueCustomer(callQueueFilter, pageNumber, pageSize, callQueueFilter.CriteriaId, callQueue, out totalRecords);
                    callqueueCustomersList = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();
                }
                else if (callQueue.Category == HealthPlanCallQueueCategory.UncontactedCustomers)
                {
                    var customersInQueueList = _callQueueCustomerRepository.GetUncontactedCallQueueCustomers(callQueueFilter, pageNumber, pageSize, callQueueFilter.CriteriaId, _settings.NeverBeenCalledInDays, _settings.NoPastAppointmentInDaysUncontactedCustomers, out totalRecords);
                    callqueueCustomersList = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();
                }
                else if (callQueue.Category == HealthPlanCallQueueCategory.NoShows)
                {
                    var customersInQueueList = _callQueueCustomerRepository.GetNoShowCallQueueCustomer(callQueueFilter, pageNumber, pageSize, callQueueFilter.CriteriaId, out totalRecords);
                    callqueueCustomersList = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();
                }
                else if (callQueue.Category == HealthPlanCallQueueCategory.MailRound)
                {
                    var customersInQueueList = _callQueueCustomerRepository.GetMailRoundCallqueueCustomer(callQueueFilter, pageNumber, pageSize, callQueueFilter.CriteriaId, callQueue, out totalRecords);
                    callqueueCustomersList = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();
                }
            }

            var organization = _organizationRepository.GetOrganizationbyId(callQueueFilter.HealthPlanId);

            var rejectedCustomersStats = _excludedCustomerRepository.GetExcludedCustomers(callQueueFilter, callQueue);
            CallQueueCustomersReportModelListModel model = null;

            var criteriaModel = _healthPlanCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(callQueueFilter.CallQueueId, callQueueFilter.HealthPlanId, null, callQueueFilter.CampaignId.HasValue ? callQueueFilter.CampaignId.Value : 0, callQueueFilter.CriteriaId);
            callQueueFilter.CallQueueId = callQueueId;

            if (!callqueueCustomersList.IsNullOrEmpty())
            {
                var customerIds = callqueueCustomersList.Select(x => x.CustomerId.Value);

                var customers = _customerRepository.GetCustomers(customerIds.ToArray());
                var corporateAccount = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(callQueueFilter.HealthPlanId);
                var corporateCustomTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);
                model = _callQueueCustomerReportFactory.GetCallQueueCustomersList(callqueueCustomersList, customers, corporateCustomTags, corporateAccount, criteria.IsQueueGenerated, criteriaModel);
            }

            model = model ?? new CallQueueCustomersReportModelListModel();
            model.CallQueueCriteria = criteriaModel;
            model.IsQueueGenerated = criteria.IsQueueGenerated;
            model.RejectedCustomersStats = rejectedCustomersStats ?? new CallQueueCustomersStatsViewModel();
            model.HealthPlanName = organization.Name;
            model.CallQueueCategory = callQueue.Category;
            model.CallQueueName = callQueue.Name;
            model.Filter = callQueueFilter;

            return model;
        }

        public ListModelBase<GmsCallQueueCustomerViewModel, OutboundCallQueueFilter> GetGmsCallQueueCustomersReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callQueueFilter = filter as OutboundCallQueueFilter;
            callQueueFilter = callQueueFilter ?? new OutboundCallQueueFilter();
            if (!callQueueFilter.CustomTags.IsNullOrEmpty())
            {
                callQueueFilter.CustomCorporateTag = string.Join(",", callQueueFilter.CustomTags);
            }

            var criteria = _callQueueCriteriaRepository.GetById(callQueueFilter.CriteriaId);


            var collection = new List<GmsCallQueueCustomerViewModel>();

            if (criteria.IsQueueGenerated)
            {
                var callQueue = _callQueueRepository.GetById(callQueueFilter.CallQueueId);
                var customersInQueueList = _callQueueCustomerRepository.GetMailRoundCustomersForGms(callQueueFilter, pageNumber, pageSize, callQueueFilter.CriteriaId, callQueue, out totalRecords);
                var callqueueCustomers = customersInQueueList == null ? new List<CallQueueCustomer>() : customersInQueueList.ToList();

                if (!callqueueCustomers.IsNullOrEmpty())
                {
                    var customerIds = callqueueCustomers.Where(x => x.CustomerId.HasValue).Select(x => x.CustomerId.Value).ToArray();
                    var customers = _customerRepository.GetCustomers(customerIds);

                    var events = _eventReportingService.GetFutureHealthPlanEvents(callQueueFilter.HealthPlanId, DateTime.Today);
                    var hosts = _hostRepository.GetHostsForFutureHealthPlanEvents(callQueueFilter.HealthPlanId, DateTime.Today);

                    var healthPlan = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(callQueueFilter.HealthPlanId);
                    var organization = _organizationRepository.GetOrganizationbyId(callQueueFilter.HealthPlanId);
                    var customerIdCheckoutNumberPairList = _customerAccountGlocomNumberService.GetGlocomNumberForGmsReport(organization.Id, customers);

                    var setAdditionalField = !string.IsNullOrEmpty(callQueueFilter.CustomCorporateTag);
                    collection = _gmsCallQueueCustomerModelFactory.Create(callqueueCustomers, customers, events, hosts, healthPlan, organization, customerIdCheckoutNumberPairList, setAdditionalField).ToList();
                }
            }
            else
            {
                totalRecords = 0;
            }

            return new GmsCallQueueCustomerListModel
            {
                Collection = collection
            };
        }

        public ListModelBase<MailRoundCustomersReportViewModel, OutboundCallQueueFilter> GetCustomersForMatrixReport(int pageNumber, int pageSize, OutboundCallQueueFilter filter, CallQueue callQueue, out int totalRecords)
        {
            totalRecords = 0;
            MailRoundCustomersListModel model = null;
            IEnumerable<long> customerIds = null;

            if (callQueue.Category == HealthPlanCallQueueCategory.MailRound)
                customerIds = _callQueueCustomerRepository.GetMailRoundCustomerIdsForMatrixReport(filter, callQueue, pageNumber, pageSize, out totalRecords);
            else if (callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
                customerIds = _callQueueCustomerRepository.GetFillEventCustomerIDsForMatrixReport(filter, callQueue, pageNumber, pageSize, out totalRecords);
            else if (callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier)
                customerIds = _callQueueCustomerRepository.GetLanguageBarrierCustomerIDsForMatrixReport(filter, callQueue, pageNumber, pageSize, out totalRecords);

            if (!customerIds.IsNullOrEmpty())
            {
                var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                var customers = _customerRepository.GetCustomers(customerIds.ToArray());
                var directMails = _directMailRepository.GetByCustomerIds(customerIds, startOfYear);
                var callDetails = _callCenterCallRepository.GetCallsByCustomerIds(customerIds, fromDate: startOfYear, isOutbound: true);
                var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds, startOfYear);

                model = _mailRoundCustomersReportFactory.Create(customers, callDetails, directMails, customTags);
            }

            model = model ?? new MailRoundCustomersListModel();
            model.Filter = filter;

            return model;
        }
    }
}