using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class HealthPlanEventService : IHealthPlanEventService
    {
        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly IEventRepository _eventRepository;
        private readonly IFillEventsCallQueueHelper _fillEventsCallQueueHelper;

        private readonly IEventBasicInfoListHelper _eventCallQueueHelper;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly ISettings _settings;

        public HealthPlanEventService(IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService, IEventRepository eventRepository, IFillEventsCallQueueHelper fillEventsCallQueueHelper, IEventBasicInfoListHelper eventCallQueueHelper,
            IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, ICallQueueCustomerRepository callQueueCustomerRepository, IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService, ISettings settings)
        {
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _eventRepository = eventRepository;
            _fillEventsCallQueueHelper = fillEventsCallQueueHelper;

            _eventCallQueueHelper = eventCallQueueHelper;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _settings = settings;
        }

        public EventBasicInfoListModel GetEventBasicInfoForCallQueue(FillEventsCallQueueFilter filter, int pageSize, out int totalRecords)
        {
            var criteria = _healthPlanCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(filter.CallQueueId, filter.HealthPlanId, filter.AssignedToOrgRoleUserId, 0, filter.CriteriaId);
            if (criteria != null && criteria.IsQueueGenerated == false)
                throw new Exception("Please wait for 10 minutes(max) after you have changed the criteria so that the queue is regenerated.");
            var events = _eventRepository.GetHealthPlanEventsForCallQueue(filter, criteria.Id);

            if (events == null || !events.Any())
            {
                totalRecords = 0;
                return null;
            }

            var endDate = DateTime.Today.AddDays(criteria.NoOfDays);

            events = events.Where(x => x.EventDate.Date <= endDate.Date);

            var outboundCallQueueFilter = new OutboundCallQueueFilter
            {
                CallQueueId = criteria.CallQueueId,
                CriteriaId = criteria.Id,
                HealthPlanId = criteria.HealthPlanId ?? 0,
                Radius = 25,
                GmsAccountIds = _settings.GmsAccountIds
            };

            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(outboundCallQueueFilter);

            var eventIdsWithCustomers = _callQueueCustomerRepository.GetHealthPlanEventsForCriteria(outboundCallQueueFilter);
            events = events.Where(x => (eventIdsWithCustomers.IsNullOrEmpty() || eventIdsWithCustomers.Contains(x.Id)));

            events = _fillEventsCallQueueHelper.GetAllTheEventFilledUnderPecentage(events, criteria.Percentage);
            totalRecords = events.Count();
            events = events.OrderBy(ev => ev.EventDate).Skip((filter.PageNumber - 1) * pageSize).Take(pageSize);

            var eventList = _eventCallQueueHelper.EventBasicInfoListForCallQueue(events);
            return eventList;
        }

        public FillEventCallQueueModel GetEventBasicInfoForCallQueueReport(FillEventsCallQueueFilter filter, int pageSize, out int totalRecords)
        {
            var criteria = _healthPlanCallQueueCriteriaRepository.GetById(filter.CriteriaId);

            if (criteria != null && criteria.IsQueueGenerated == false)
            {
                totalRecords = 0;
                return new FillEventCallQueueModel
                {
                    Filter = filter,
                    IsQueueGenerated = false,
                    CallQueueCriteria = criteria
                };
            }
            var callQueueId = filter.CallQueueId;

            filter.CallQueueId = criteria.CallQueueId;

            var events = _eventRepository.GetHealthPlanEventsForCallQueue(filter, criteria.Id);

            if (events == null || !events.Any())
            {
                totalRecords = 0;
                return null;
            }

            var endDate = DateTime.Today.AddDays(criteria.NoOfDays);

            events = events.Where(x => x.EventDate.Date <= endDate.Date);

            events = _fillEventsCallQueueHelper.GetAllTheEventFilledUnderPecentage(events, criteria.Percentage);

            var outboundCallQueueFilter = new OutboundCallQueueFilter
            {
                CallQueueId = criteria.CallQueueId,
                CriteriaId = criteria.Id,
                HealthPlanId = criteria.HealthPlanId ?? 0,
                Radius = 25,
                GmsAccountIds = _settings.GmsAccountIds
            };

            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(outboundCallQueueFilter);

            var eventIdsWithCustomers = _callQueueCustomerRepository.GetHealthPlanEventsForCriteria(outboundCallQueueFilter);
            events = events.Where(x => (!eventIdsWithCustomers.IsNullOrEmpty() && eventIdsWithCustomers.Contains(x.Id)));

            totalRecords = events.Count();
            events = events.OrderBy(ev => ev.EventDate).Skip((filter.PageNumber - 1) * pageSize).Take(pageSize);

            filter.CallQueueId = callQueueId;

            var model = _eventCallQueueHelper.EventBasicInfoListForCallQueue(events);
            if (model == null || model.Events.IsNullOrEmpty())
                return new FillEventCallQueueModel
                {
                    Events = null,
                    Filter = filter,
                    IsQueueGenerated = true,
                    CallQueueCriteria = criteria
                };

            return new FillEventCallQueueModel
            {
                Events = model.Events,
                Filter = filter,
                IsQueueGenerated = true,
                CallQueueCriteria = criteria
            };
        }
    }
}