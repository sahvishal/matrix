using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class FillEventsCallQueuePollingAgent : IFillEventsCallQueuePollingAgent
    {
        private readonly ILogger _logger;

        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCustomerHelper _callQueueCustomerHelper;
        private readonly IFillEventsCallQueueService _fillEventsCallQueueService;
        private readonly ISystemGeneratedCallQueueCriteriaService _systemGeneratedCallQueueCriteriaService;
        private readonly ISystemGeneratedCallQueueAssignmentRepository _systemGeneratedCallQueueAssignmentRepository;

        public FillEventsCallQueuePollingAgent(ILogManager logManager, ICallQueueRepository callQueueRepository, ICallQueueCustomerHelper callQueueCustomerHelper,
            IFillEventsCallQueueService fillEventsCallQueueService, ISystemGeneratedCallQueueCriteriaService systemGeneratedCallQueueCriteriaService,
            ISystemGeneratedCallQueueAssignmentRepository systemGeneratedCallQueueAssignmentRepository)
        {
            _logger = logManager.GetLogger<FillEventsCallQueuePollingAgent>();

            _callQueueRepository = callQueueRepository;
            _callQueueCustomerHelper = callQueueCustomerHelper;
            _fillEventsCallQueueService = fillEventsCallQueueService;
            _systemGeneratedCallQueueCriteriaService = systemGeneratedCallQueueCriteriaService;
            _systemGeneratedCallQueueAssignmentRepository = systemGeneratedCallQueueAssignmentRepository;
        }

        public void PollForCallQueue()
        {
            try
            {
                _logger.Info("Starting single call queue customer for FillEvents");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(CallQueueCategory.FillEvents);
                var criterias = _systemGeneratedCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteriaNotGenerated(callQueue.Id);
                foreach (var criteria in criterias)
                {
                    _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                    var callQueueCustomers = _fillEventsCallQueueService.GetCallQueueCustomers(callQueue.Id, criteria);
                    if (callQueueCustomers != null && callQueueCustomers.Any())
                    {
                        _logger.Info(string.Format("{0} single call queue customer found for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                        _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers,criteria.Id);
                        _logger.Info(string.Format("{0} single call queue customer saved for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                    }
                    else
                        _logger.Info(string.Format("No single call queue customer found for {0}  for Agent Id : {1}", callQueue.Category, criteria.AssignedToOrgRoleUserId));

                    criteria.IsQueueGenerated = true;
                    criteria.LastQueueGeneratedDate = DateTime.Now;
                    _systemGeneratedCallQueueCriteriaService.Save(criteria);
                }

                callQueue.IsQueueGenerated = true;
                callQueue.LastQueueGeneratedDate = DateTime.Now;
                _callQueueRepository.Save(callQueue);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while pulling single Fill Event call queue. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
