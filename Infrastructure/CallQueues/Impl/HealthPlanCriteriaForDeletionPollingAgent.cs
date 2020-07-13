using System;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Application.Attributes;


namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCriteriaForDeletionPollingAgent : IHealthPlanCriteriaForDeletionPollingAgent
    {
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;
        private readonly ILogger _logger;

        public HealthPlanCriteriaForDeletionPollingAgent(IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, ILogManager logManager, 
            IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository)
        {
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
            _logger = logManager.GetLogger("HealthPlanCriteriaForDeletionPollingAgent");
        }

        public void PollforCriteriaDeletion()
        {
            try
            {
                _logger.Info("Entering For Deletion of Criteria");

                var criteriaforDeletion = _healthPlanCallQueueCriteriaRepository.GetQueueCriteriaMarkedDeleted();

                foreach (var criteria in criteriaforDeletion)
                {
                    try
                    {

                        if (_healthPlanCallQueueAssignmentRepository.IsCustomerLockedForCriteria(criteria.Id))
                        {
                            _logger.Info("Some customers are still locked for Criteria id: " + criteria.Id);
                            continue;
                        }

                        _healthPlanCallQueueCriteriaRepository.DeleteById(criteria.Id);

                        _logger.Info("deleted Successfully criteria Id" + criteria.Id);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error While deleting HealthPlan Call Queue Criteria :  Message: " + ex.Message + " Stack Trace: " + ex.StackTrace + "For criteria Id : " + criteria.Id);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Error While deleting HealthPlan Call Queue Criteria :  Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }
    }
}