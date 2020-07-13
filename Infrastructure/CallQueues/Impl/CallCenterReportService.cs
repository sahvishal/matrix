using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallCenterReportService : ICallCenterReportService
    {

        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly IHealthPlanCallQueueReportListModelFactory _healthPlanCallQueueReportListModelFactory;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallCenterRepository _callCenterRepository;
        private readonly IAgentConversionReportFactory _agentConversionReportFactory;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventRepository _eventRepository;

        public CallCenterReportService(ICallQueueCustomerCallRepository callQueueCustomerCallRepository, ICustomerRepository customerRepository, IEventRepository eventRepository, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            IHealthPlanCallQueueReportListModelFactory healthPlanCallQueueReportListModelFactory, IOrganizationRepository organizationRepository, ICallQueueRepository callQueueRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            ICallCenterRepository callCenterRepository, IAgentConversionReportFactory agentConversionReportFactory, IEventCustomerRepository eventCustomerRepository)
        {
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _healthPlanCallQueueReportListModelFactory = healthPlanCallQueueReportListModelFactory;
            _organizationRepository = organizationRepository;
            _callQueueRepository = callQueueRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callCenterRepository = callCenterRepository;
            _agentConversionReportFactory = agentConversionReportFactory;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
        }

        public ListModelBase<CallQueueSchedulingReportModel, CallQueueSchedulingReportFilter> GetHealthPlanCallQueueReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var callDetails = _callQueueCustomerCallRepository.GetHealthPlanCallQueueCallReports(filter as CallQueueSchedulingReportFilter, pageNumber, pageSize, out totalRecords);

            if (callDetails == null || !callDetails.Any()) return null;

            var customerIds = callDetails.Select(c => c.CalledCustomerId).ToArray();

            var customers = _customerRepository.GetCustomers(customerIds);

            var customerTags = _corporateCustomerCustomTagRepository.GetByCustomerIds(customerIds);

            var eventIds = callDetails.Where(x => x.EventId > 0).Select(x => x.EventId);

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            var organisationRoleIds = callDetails.Select(c => c.CreatedByOrgRoleUserId).ToArray();

            IEnumerable<OrderedPair<long, string>> registeredbyAgentNameIdPair = null;

            if (organisationRoleIds != null && !organisationRoleIds.IsNullOrEmpty())
            {
                registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(organisationRoleIds).ToArray();
            }

            var healthPlanIds = callDetails.Select(x => x.HealthPlanId).ToArray();

            var organizations = _organizationRepository.GetOrganizations(healthPlanIds);

            var callQueue = _callQueueRepository.GetByIds(callDetails.Select(x => x.CallQueueId), isManual: false, isHealthPlan: true);

            return _healthPlanCallQueueReportListModelFactory.Create(callDetails, customers, customerTags, registeredbyAgentNameIdPair, events, organizations, callQueue);
        }

        public ListModelBase<AgentConversionReportViewModel, AgentConversionReportFilter> GetAgentConversionReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var agentConversionReportFilter = filter as AgentConversionReportFilter ?? new AgentConversionReportFilter();
            if (agentConversionReportFilter.ShowPreviousDayData)
            {
                agentConversionReportFilter.FromDate = DateTime.Today.AddDays(-1);
                agentConversionReportFilter.ToDate = DateTime.Today.AddDays(-1);
            }
            var agentOrgRoleUserIds = _callCenterRepository.GetCallCenterAgentsForConversionReport(agentConversionReportFilter, pageNumber, pageSize, out totalRecords);

            var outboundCallsForAgents = _callCenterRepository.GetoutboundCallsForAgents(agentConversionReportFilter, agentOrgRoleUserIds);

            var orgRoleUsers = _organizationRoleUserRepository.GetNameIdPairofUsers(agentOrgRoleUserIds);

            var model = _agentConversionReportFactory.Create(agentOrgRoleUserIds, outboundCallsForAgents, orgRoleUsers);

            model.Filter = agentConversionReportFilter;

            return model;
        }
    }
}