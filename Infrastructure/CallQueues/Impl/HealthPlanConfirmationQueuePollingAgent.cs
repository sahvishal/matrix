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
    public class HealthPlanConfirmationQueuePollingAgent : IHealthPlanConfirmationQueuePollingAgent
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly ILogger _logger;

        public HealthPlanConfirmationQueuePollingAgent(ILogManager logManager, ICallQueueRepository callQueueRepository, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository,
            IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository, ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallRoundService healthPlanCallRoundService)
        {
            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _logger = logManager.GetLogger("For24hrs_HealthPlanConfirmationQueue");
        }

        public void PollForQueueGeneration()
        {
            try
            {
                _logger.Info("Entering Health Plan Confirmation Queue Polling Agent For 24 hrs.");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.AppointmentConfirmation);
                var criterias = _healthPlanCallQueueCriteriaRepository.GetQueueCriteriasByQueueId(callQueue.Id);
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();

                foreach (var criteria in criterias)
                {
                    try
                    {
                        _healthPlanCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);

                        if (criteria.HealthPlanId.HasValue)
                        {
                            var healthPlan = healthPlans.FirstOrDefault(x => x.Id == criteria.HealthPlanId);

                            if (healthPlan != null)
                            {
                                _healthPlanCallRoundService.SaveHealthPlanConfirmationCustomerCallQueue(healthPlan, criteria, callQueue, _logger);
                            }

                            criteria.IsQueueGenerated = true;
                            criteria.LastQueueGeneratedDate = DateTime.Now;
                            _healthPlanCallQueueCriteriaRepository.Save(criteria);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error generating confirmation queue for HealthPlanId: {0} CallQueueId: {1} CriteriaId : {2}", criteria.HealthPlanId, callQueue.Id, criteria.Id));
                        _logger.Error(string.Format("Message : {0} \nStack Trace : {1}", ex.Message, ex.StackTrace));
                    }
                }

                _logger.Info("Completed Health Plan Confirmation Queue Polling Agent For 24 hrs.");

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message {0} stack trace: {1} ", ex.Message, ex.StackTrace));
            }
        }
    }
}
