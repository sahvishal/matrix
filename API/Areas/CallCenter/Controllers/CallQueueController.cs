using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.CallCenter.Controllers
{
    public class CallQueueController : BaseController
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly IEventService _eventService;
        private readonly ICallQueueCustomerLockRepository _callQueueCustomerLockRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ISystemGeneratedCallQueueCriteriaService _systemGeneratedCallQueueCritairaService;
        private readonly ISessionContext _sessionContext;

        private const int PageSize = 25;
        
        public CallQueueController(ICallQueueRepository callQueueRepository, IOutboundCallQueueService outboundCallQueueService, IEventService eventService,
            ICallQueueCustomerLockRepository callQueueCustomerLockRepository, ICallQueueCustomerRepository callQueueCustomerRepository, ISystemGeneratedCallQueueCriteriaService systemGeneratedCallQueueCritairaService, ISessionContext sessionContext)
        {
            _callQueueRepository = callQueueRepository;
            _outboundCallQueueService = outboundCallQueueService;
            _eventService = eventService;
            _callQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;

            _systemGeneratedCallQueueCritairaService = systemGeneratedCallQueueCritairaService;
            _sessionContext = sessionContext;
        }

        [HttpGet]
        public IEnumerable<CallQueueCategoryViewModel> GetCallQueueCategories()
        {
            var callqueues = _callQueueRepository.GetAll(false);
            var callQueueCategory = new List<CallQueueCategoryViewModel>();
            if (callqueues != null)
            {
                callQueueCategory.AddRange(callqueues.Select(x => new CallQueueCategoryViewModel { CallQueueId = x.Id, Name = x.Name, Category = x.Category, Description = x.Description }).OrderBy(s => s.CallQueueId));
            }

            return callQueueCategory;
        }

        [HttpGet]
        public OutboundCallQueueListModel GetOutboundCallQueue([FromUri]OutboundCallQueueFilter filter)
        {
            int totalRecords;
            var callQueue = _callQueueRepository.GetById(filter.CallQueueId);
            var criteria =  _systemGeneratedCallQueueCritairaService.GetSystemGeneratedCallQueueCriteria(filter.CallQueueId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            long criteriaId = criteria != null ? criteria.Id : 0;
            OutboundCallQueueListModel model = null;
            if (callQueue.Category == CallQueueCategory.Upsell || callQueue.Category == CallQueueCategory.Confirmation)
            {
                if (criteria != null && criteria.IsQueueGenerated == false)
                {
                    model = new OutboundCallQueueListModel() { IsQueueGenerated = false};
                    totalRecords = 0;
                }
                else
                {
                    model =_outboundCallQueueService.GetOutboundCallQueueUpsellAndConfirmation(filter, callQueue, PageSize,criteriaId, out totalRecords) ??
                        new OutboundCallQueueListModel() { IsQueueGenerated = true };
                }
            }
            else
            {
                if (criteria != null && criteria.IsQueueGenerated == false)
                {
                    model = new OutboundCallQueueListModel() { IsQueueGenerated = false };
                    totalRecords = 0;
                }
                else
                {
                    model = _outboundCallQueueService.GetOutboundCallQueueListModel(filter, callQueue, PageSize, criteriaId, out totalRecords) ?? new OutboundCallQueueListModel() { IsQueueGenerated = true };
                }
            }

            model.PagingModel = new PagingModel(filter.PageNumber, PageSize, totalRecords, null);

            return model;
        }

        [HttpGet]
        public EventBasicInfoListModel GetEventsForFillEventCallQueue([FromUri]FillEventsCallQueueFilter filter)
        {
            int totalRecords;
            filter.AssignedToOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var model = _eventService.GetEventBasicInfoForCallQueue(filter, PageSize, out totalRecords) ?? new EventBasicInfoListModel();
            model.PagingModel = new PagingModel(filter.PageNumber, PageSize, totalRecords, null);

            return model;
        }

        [HttpGet]
        public bool LockCallQueueCustomer([FromUri] long callQueueCustomerId)
        {
            var customer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var domain = new CallQueueCustomerLock
            {
                CallQueueCustomerId = customer.Id,
                CustomerId = customer.CustomerId,
                ProspectCustomerId = customer.ProspectCustomerId,
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            };

            _callQueueCustomerLockRepository.SaveCallQueueCustomerLock(domain);

            return true;
        }

        [HttpGet]
        public SystemGeneratedCallQueueCriteria GetSystemGeneratedCallQueueCriteria(long callQueueId)
        {
            return _systemGeneratedCallQueueCritairaService.GetSystemGeneratedCallQueueCriteria(callQueueId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpPost]
        public SystemGeneratedCallQueueCriteria UpdateFillEventQueueCriteria(FillEventQueueCriteriaEditModel model)
        {
            return _systemGeneratedCallQueueCritairaService.UpdateEventQueueCriteria(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        } 

        [HttpPost]
        public SystemGeneratedCallQueueCriteria UpdateUpsellQueueCriteria(UpsellQueueCriteriaEditModel model)
        {
            return _systemGeneratedCallQueueCritairaService.UpdateUpsellQueueCriteria(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        } 

        [HttpPost]
        public SystemGeneratedCallQueueCriteria UpdateConfirmationQueueCriteria(ConfirmationQueueCriteriaEditModel model)
        {
            return _systemGeneratedCallQueueCritairaService.UpdateConfirmationQueueCriteria(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpGet]
        public CallQueue GetCallQueueById([FromUri]long callQueueId)
        {
            return _callQueueRepository.GetById(callQueueId);
        }

    }
}
