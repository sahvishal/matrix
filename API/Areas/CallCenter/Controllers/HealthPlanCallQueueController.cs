using System;
using System.Collections.Generic;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.CallCenter.Controllers
{
    public class HealthPlanCallQueueController : BaseController
    {
        private readonly IHealthPlanCallQueueService _healthPlanCallQueueService;
        private readonly ISessionContext _sessionContext;
        private readonly IHealthPlanEventService _eventService;
        private readonly ICampaignService _campaignService;
        private readonly ICampaignActivityRepository _campaignActivityRepository;
        private readonly ICustomerCallQueueCallAttemptService _customerCallQueueCallAttemptService;
        private readonly ICallQueueCustomerDetailService _callQueueCustomerDetailService;
        private readonly ICallQueueCustomerContactService _callQueueCustomerContactService;

        private const int PageSize = 10;

        public HealthPlanCallQueueController(IHealthPlanCallQueueService healthPlanCallQueueService, ISessionContext sessionContext, IHealthPlanEventService eventService, 
            ICampaignService campaignService,ICampaignActivityRepository campaignActivityRepository, ICustomerCallQueueCallAttemptService customerCallQueueCallAttemptService,
            ICallQueueCustomerDetailService callQueueCustomerDetailService, ICallQueueCustomerContactService callQueueCustomerContactService)
        {
            _healthPlanCallQueueService = healthPlanCallQueueService;
            _sessionContext = sessionContext;
            _eventService = eventService;
            _campaignService = campaignService;
            _campaignActivityRepository = campaignActivityRepository;
            _customerCallQueueCallAttemptService = customerCallQueueCallAttemptService;
            _callQueueCustomerDetailService = callQueueCustomerDetailService;
            _callQueueCustomerContactService = callQueueCustomerContactService;
        }
        
        [HttpGet]
        public EventBasicInfoListModel GetEventsForFillEventHealthPlan([FromUri]FillEventsCallQueueFilter filter)
        {
            int totalRecords;
            filter.AssignedToOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var model = _eventService.GetEventBasicInfoForCallQueue(filter, PageSize, out totalRecords) ?? new EventBasicInfoListModel();
            model.PagingModel = new PagingModel(filter.PageNumber, PageSize, totalRecords, null);

            return model;
        }

        [HttpGet]
        public CallQueueCampaignListModel GetCampaignHealthPlan([FromUri]CampaignCallQueueFilter filter)
        {
            int totalRecords;
            filter.AssignedToOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var model = _campaignService.GetCampaignListModel(filter, PageSize, out totalRecords);

            return model;
        }

        [HttpGet]
        public IEnumerable<DateTime> DirectMailDates([FromUri]long campaignId)
        {
            return _campaignActivityRepository.GetDirectMailActivityDates(campaignId);
        }

        [HttpGet]
        public CallCentreAgentQueueListModel GetCallAgentSpecificQueuesData([FromUri]CallCentreAgentQueueFilter filter, int pageNumber)
        {
            int totalRecords = 0;
            var agentOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var agentOrganizationId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            filter.AgentOrganizationRoleUserId = agentOrgRoleUserId;
            filter.AgentOrganizationId = agentOrganizationId;

            var collection = _customerCallQueueCallAttemptService.CallCenterAgentDashboardData(filter, pageNumber, PageSize, out totalRecords);

            var model = new CallCentreAgentQueueListModel
            {
                HealthPlanList = _healthPlanCallQueueService.GetHealthPlanDropdownList(agentOrganizationId),
                CallQueuesList = _healthPlanCallQueueService.GetHealthPlanCallQueueDropDownList(),
                Collection = collection,
                Filter = filter,
                PagingModel = new PagingModel(pageNumber, PageSize, totalRecords, null)
            };
            return model;
        }

        [HttpPost]
        public StartOutBoundCallViewModel GetAvailableCustomer([FromBody]OutboundCallQueueFilter filter)
        {
            var agentOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var agentOrganizationId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            filter.AgentOrganizationRoleUserId = agentOrgRoleUserId;
            filter.AgentOrganizationId = agentOrganizationId;

            return _callQueueCustomerDetailService.GetCustomerContactViewModel(filter);
        }

        [HttpGet]
        public CustomerContactViewModel GetCustomerInfo(long callQueueCustomerId, long attemptId)
        {
            return _callQueueCustomerContactService.GetCustomerContactViewModelByAttempt(callQueueCustomerId, attemptId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
}
