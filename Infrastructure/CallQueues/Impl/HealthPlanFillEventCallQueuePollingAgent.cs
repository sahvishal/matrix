using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanFillEventCallQueuePollingAgent : IHealthPlanFillEventCallQueuePollingAgent
    {
        private readonly ILogger _logger;

        private readonly ICallQueueRepository _callQueueRepository;

        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;
        private readonly IHealthPlanFillEventCallQueueRepository _healthPlanFillEventCallQueueRepository;

        public HealthPlanFillEventCallQueuePollingAgent(ILogManager logManager, ICallQueueRepository callQueueRepository,
            IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService, IHealthPlanCallRoundService healthPlanCallRoundService,
            ICorporateAccountRepository corporateAccountRepository,IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository,
            IHealthPlanFillEventCallQueueRepository healthPlanFillEventCallQueueRepository)
        {
            _logger = logManager.GetLogger("HealthPlanFillEventCallQueuePollingAgent");

            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
            _healthPlanFillEventCallQueueRepository = healthPlanFillEventCallQueueRepository;
        }

        public void PollForCallQueue()
        {
            try
            {
                _logger.Info("Entering Single Health Plan Fill Event Polling Agent");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.FillEventsHealthPlan);
                var criterias = _healthPlanCallQueueCriteriaService.GetHealthPlanCallQueueCriteriaNotGenerated(callQueue.Id);

                var healthPlanIds = criterias.Where(x => x.HealthPlanId != null).Select(x => x.HealthPlanId.Value).ToArray();
                var healthPlans = _corporateAccountRepository.GetByIds(healthPlanIds);

                foreach (var criteria in criterias)
                {
                    try
                    {
                        _logger.Info("Single Health Plan Fill Event Polling Agent");
                        _healthPlanCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);

                        _healthPlanFillEventCallQueueRepository.DeleteByCriteriaId(criteria.Id);

                        if (criteria.HealthPlanId.HasValue)
                        {
                            var healthPlan = healthPlans.First(x => x.Id == criteria.HealthPlanId.Value);
                            _healthPlanCallRoundService.SaveHealthPlanFillEventCallQueueCustomers(healthPlan, criteria, callQueue, _logger);
                        }

                        criteria.IsQueueGenerated = true;
                        criteria.LastQueueGeneratedDate = DateTime.Now;

                        _healthPlanCallQueueCriteriaService.Save(criteria);
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("Error while generating call queue customer data for Criteria Id: {0} \n message: {1} stack trace {2}", criteria.Id, exception.Message, exception.StackTrace));
                    }

                }

                callQueue.IsQueueGenerated = true;
                callQueue.LastQueueGeneratedDate = DateTime.Now;
                _callQueueRepository.Save(callQueue);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while pulling single call round call queue. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

    }
}