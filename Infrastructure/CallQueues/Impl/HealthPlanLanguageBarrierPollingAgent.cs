using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanLanguageBarrierPollingAgent : IHealthPlanLanguageBarrierPollingAgent
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ILogger _logger;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteria;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignment;

        public HealthPlanLanguageBarrierPollingAgent(ICallQueueRepository callQueueRepository, ILogManager logManager, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteria,
            ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallRoundService healthPlanCallRoundService, IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignment)
        {
            _callQueueRepository = callQueueRepository;
            _logger = logManager.GetLogger("For24hrs_HealthPlanLanguageBarrier");
            _healthPlanCallQueueCriteria = healthPlanCallQueueCriteria;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _healthPlanCallQueueAssignment = healthPlanCallQueueAssignment;
        }

        public void PollForHealthPlanLanguageBarrierCustomer()
        {
            try
            {
                _logger.Info("Entering Health Plan Language Barrier Polling Agent For 24 hrs");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.LanguageBarrier);
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();

                if (callQueue != null)
                {
                    var criteria = _healthPlanCallQueueCriteria.GetQueueCriteriasByQueueId(callQueue.Id);

                    criteria = criteria.Where(x => x.IsQueueGenerated);

                    foreach (var queueCriteria in criteria)
                    {
                        _healthPlanCallQueueAssignment.DeleteByCriteriaId(queueCriteria.Id);

                        //if (queueCriteria.IsDefault)
                        //{
                        //    foreach (var corporateAccount in healthPlans)
                        //    {
                        //        _healthPlanCallRoundService.SaveHealthPlanLanguageBarrierCustomerCallQueue(corporateAccount, queueCriteria, callQueue, _logger);
                        //    }
                        //}
                        //else 
                        if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                        {
                            var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);
                            _healthPlanCallRoundService.SaveHealthPlanLanguageBarrierCustomerCallQueue(corporateAccount, queueCriteria, callQueue, _logger);
                        }

                        queueCriteria.IsQueueGenerated = true;
                        queueCriteria.LastQueueGeneratedDate = DateTime.Now;
                        _healthPlanCallQueueCriteria.Save(queueCriteria);
                    }
                }

                _logger.Info("Completed Health Plan Language Barrier Polling Agent For 24 hrs");
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}