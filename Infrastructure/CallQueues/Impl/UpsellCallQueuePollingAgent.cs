using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class UpsellCallQueuePollingAgent : IUpsellCallQueuePollingAgent
    {
        private readonly ILogger _logger;

        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCustomerHelper _callQueueCustomerHelper;
        private readonly IUpsellCallQueueService _upsellCallQueueService;
        private readonly ISystemGeneratedCallQueueCriteriaService _systemGeneratedCallQueueCriteriaService;
        private readonly ISystemGeneratedCallQueueAssignmentRepository _systemGeneratedCallQueueAssignmentRepository;


        public UpsellCallQueuePollingAgent(ILogManager logManager, ICallQueueRepository callQueueRepository, ICallQueueCustomerHelper callQueueCustomerHelper, IUpsellCallQueueService upsellCallQueueService,
            ISystemGeneratedCallQueueCriteriaService systemGeneratedCallQueueCriteriaService, ISystemGeneratedCallQueueAssignmentRepository systemGeneratedCallQueueAssignmentRepository)
        {
            _logger = logManager.GetLogger<UpsellCallQueuePollingAgent>();

            _callQueueRepository = callQueueRepository;
            _callQueueCustomerHelper = callQueueCustomerHelper;
            _upsellCallQueueService = upsellCallQueueService;
            _systemGeneratedCallQueueCriteriaService = systemGeneratedCallQueueCriteriaService;
            _systemGeneratedCallQueueAssignmentRepository = systemGeneratedCallQueueAssignmentRepository;
        }
        public void PollForCallQueue()
        {
            try
            {
                _logger.Info("Starting single call queue customer for Upsell");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(CallQueueCategory.Upsell);
                var criterias = _systemGeneratedCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteriaNotGenerated(callQueue.Id);
                foreach (var criteria in criterias)
                {
                    _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                    var callQueueCustomers = _upsellCallQueueService.GetCallQueueCustomers(callQueue.Id, criteria.Amount, criteria.NoOfDays);
                    if (callQueueCustomers != null && callQueueCustomers.Any())
                    {
                        _logger.Info(string.Format("{0} single call queue customer found for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                        _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);
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
                _logger.Error(string.Format("Error while pulling single Upsell Event call queue. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
