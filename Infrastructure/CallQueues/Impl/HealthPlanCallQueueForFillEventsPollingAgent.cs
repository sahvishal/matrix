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
    public class HealthPlanCallQueueForFillEventsPollingAgent : IHealthPlanCallQueueForFillEventsPollingAgent
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteria;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignment;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;

        private readonly IHealthPlanFillEventCallQueueRepository _healthPlanFillEventCallQueueRepository;
        private readonly ILogger _logger;

        public HealthPlanCallQueueForFillEventsPollingAgent(ICallQueueRepository callQueueRepository, ILogManager logManager, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteria,
            IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignment, ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallRoundService healthPlanCallRoundService,
           IHealthPlanFillEventCallQueueRepository healthPlanFillEventCallQueueRepository)
        {
            _logger = logManager.GetLogger("For24hrs_HealthPlanFillEvents");
            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteria = healthPlanCallQueueCriteria;
            _healthPlanCallQueueAssignment = healthPlanCallQueueAssignment;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;

            _healthPlanFillEventCallQueueRepository = healthPlanFillEventCallQueueRepository;
        }

        public void PollForHealthPlanCallQueue()
        {
            try
            {
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.FillEventsHealthPlan);

                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
                _logger.Info("Started Healthfair Fill Event call Queue For Generated Call Queues For 24 hrs");

                if (callQueue != null)
                {
                    try
                    {
                        var criteria = _healthPlanCallQueueCriteria.GetQueueCriteriasByQueueId(callQueue.Id);
                        criteria = criteria.Where(x => x.IsQueueGenerated).OrderByDescending(x => x.Id);

                        foreach (var queueCriteria in criteria)
                        {
                            try
                            {
                                _healthPlanCallQueueAssignment.DeleteByCriteriaId(queueCriteria.Id);
                                _healthPlanFillEventCallQueueRepository.DeleteByCriteriaId(queueCriteria.Id);

                                //if (queueCriteria.IsDefault)
                                //{
                                //    foreach (var corporateAccount in healthPlans)
                                //    {
                                //        _healthPlanCallRoundService.SaveHealthPlanFillEventCallQueueCustomers(corporateAccount, queueCriteria, callQueue, _logger);
                                //    }
                                //}
                                //else
                                
                                if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                                {
                                    var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);

                                    _healthPlanCallRoundService.SaveHealthPlanFillEventCallQueueCustomers(corporateAccount, queueCriteria, callQueue, _logger);
                                }

                                queueCriteria.IsQueueGenerated = true;
                                queueCriteria.LastQueueGeneratedDate = DateTime.Now;
                                _healthPlanCallQueueCriteria.Save(queueCriteria);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error(string.Format("error health plan call queue. callQueueId: {0} CriteriaId {1} ", callQueue.Id, queueCriteria.Id));
                                _logger.Error(string.Format("Message {0} stack trace: {1} ", ex.Message, ex.StackTrace));
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("error health plan call queue. callQueueId: {0} ", callQueue.Id));
                        _logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
                    }
                    callQueue.IsQueueGenerated = true;
                    callQueue.LastQueueGeneratedDate = DateTime.Now;
                    _callQueueRepository.Save(callQueue);

                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("error health plan call queue."));
                _logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }
        }
    }
}