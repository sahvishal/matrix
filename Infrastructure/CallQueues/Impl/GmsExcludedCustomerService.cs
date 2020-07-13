using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class GmsExcludedCustomerService : IGmsExcludedCustomerService
    {
        private readonly IGmsExcludedCustomerRepository _gmsExcludedCustomerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ICallQueueRepository _callQueueRepository;

        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly ICampaignRepository _campaignRepository;
        private const int PageSize = 100;

        public GmsExcludedCustomerService(IGmsExcludedCustomerRepository gmsExcludedCustomerRepository,
            IOrganizationRepository organizationRepository, ICustomerRepository customerRepository,
            ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, ICallQueueRepository callQueueRepository,
            IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, ICampaignRepository campaignRepository)
        {
            _gmsExcludedCustomerRepository = gmsExcludedCustomerRepository;
            _organizationRepository = organizationRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _callQueueRepository = callQueueRepository;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _campaignRepository = campaignRepository;
        }

        public IEnumerable<GmsExcludedCustomerViewModel> GetGmsExcludedCustomers(OutboundCallQueueFilter filter, CallQueue callQueue)
        {
            var suppressionTypes = SuppressionFilterType.MaxAttempt.GetNameValuePairs();

            var organization = _organizationRepository.GetOrganizationbyId(filter.HealthPlanId);
            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
            var collection = new List<GmsExcludedCustomerViewModel>();

            foreach (var suppressionType in suppressionTypes)
            {
                int totalRecords = 0;
                var suppressionTypeCustomers = new List<GmsExcludedCustomerViewModel>();
                var pageNumber = 1;

                while (true)
                {
                    var excludedCustomers = _gmsExcludedCustomerRepository.GetGmsExcludedCallQueueCustomers(pageNumber, PageSize, filter, callQueue,
                        (SuppressionFilterType)suppressionType.FirstValue, out totalRecords);

                    if (excludedCustomers.IsNullOrEmpty())
                        break;

                    var customerIds = excludedCustomers.Where(x => x.CustomerId.HasValue).Select(x => x.CustomerId.Value).ToArray();

                    var customers = _customerRepository.GetCustomers(customerIds);
                    var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

                    suppressionTypeCustomers.AddRange(Create(excludedCustomers, customers, customTags, organization));

                    if ((pageNumber * PageSize) >= totalRecords)
                        break;

                    pageNumber++;
                }

                var distinctCustomers = suppressionTypeCustomers.Where(x => !collection.Select(c => c.CustomerId).Contains(x.CustomerId));
                collection.AddRange(distinctCustomers);
            }

            return collection;
        }

        private IEnumerable<GmsExcludedCustomerViewModel> Create(IEnumerable<GmsExcludedCustomerViewModel> excludedCustomers, IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> customTags, Organization organization)
        {
            var excludedCustomerViewModel = new List<GmsExcludedCustomerViewModel>();

            foreach (var model in excludedCustomers)
            {
                model.HealthPlan = organization.Name;

                if (model.CustomerId.HasValue)
                {
                    var customer = customers.Single(x => x.CustomerId == model.CustomerId.Value);
                    var tags = customTags.Where(c => c.CustomerId == model.CustomerId.Value);
                    if (!tags.IsNullOrEmpty())
                        model.CustomTags = String.Join(",", tags.Select(x => x.Tag).ToArray());
                    model.MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? string.Empty : customer.InsuranceId;
                }

                excludedCustomerViewModel.Add(model);
            }

            return excludedCustomerViewModel;
        }

        public ListModelBase<GmsExcludedCustomerViewModel, OutboundCallQueueFilter> GetExcludedCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var outboundCallQueueFilter = filter as OutboundCallQueueFilter ?? new OutboundCallQueueFilter();
            var organization = _organizationRepository.GetOrganizationbyId(outboundCallQueueFilter.HealthPlanId);

            CallQueue callQueue = null;

            var criteria = _healthPlanCallQueueCriteriaRepository.GetById(outboundCallQueueFilter.CriteriaId);
            
            callQueue = _callQueueRepository.GetById(outboundCallQueueFilter.CallQueueId > 0 ? outboundCallQueueFilter.CallQueueId : criteria.CallQueueId);
            outboundCallQueueFilter.CallQueueId = callQueue.Id;

            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(outboundCallQueueFilter);

            var excludedCustomers = _gmsExcludedCustomerRepository.GetExcludedCallQueueCustomers(pageNumber, pageSize, outboundCallQueueFilter, callQueue, outboundCallQueueFilter.SuppressionType, out totalRecords);

            var model = new ExcludedCustomerListModel { Filter = outboundCallQueueFilter };
            var customerIds = excludedCustomers.Where(x => x.CustomerId.HasValue).Select(x => x.CustomerId.Value).ToArray();
            if (!customerIds.IsNullOrEmpty())
            {
                var customers = _customerRepository.GetCustomers(customerIds);
                var customTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);
                model.Collection = Create(excludedCustomers, customers, customTags, organization);

                return model;

            }
            model.Collection = Create(excludedCustomers, null, null, organization);

            return model;
        }

        public ExcludedCustomerListModel SetHeaderData(OutboundCallQueueFilter filter, ExcludedCustomerListModel model)
        {
            var organization = _organizationRepository.GetOrganizationbyId(filter.HealthPlanId);
            CallQueue callQueue = null;
            var criteria = _healthPlanCallQueueCriteriaRepository.GetById(filter.CriteriaId);
            callQueue = _callQueueRepository.GetById(filter.CallQueueId > 0 ? filter.CallQueueId : criteria.CallQueueId);
            var criteriaName = string.Empty;
            if (filter.CampaignId.HasValue && filter.CampaignId.Value > 0)
            {
                var campagin = _campaignRepository.GetById(filter.CampaignId.Value);
                criteriaName = campagin.Name;
            }

            model.CallQueueType = callQueue.Name;
            model.HealthPlanName = organization.Name;
            model.SuppressionType = filter.SuppressionType.GetDescription();
            model.CriteriaName = string.IsNullOrEmpty(criteria.CriteriaName) ? criteriaName : criteria.CriteriaName;

            return model;
        }
    }


}
