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
    public class ZipRadiusCallQueuePollingAgent : IZipRadiusCallQueuePollingAgent
    {
        private readonly ILogger _logger;

        private readonly ICallQueueRepository _callQueueRepository;

        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;

        public ZipRadiusCallQueuePollingAgent(ILogManager logManager, ICallQueueRepository callQueueRepository,
            IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService, IHealthPlanCallRoundService healthPlanCallRoundService,
            ICorporateAccountRepository corporateAccountRepository,
            IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository)
        {
            _logger = logManager.GetLogger("ZipRadiusCallQueuePollingAgent");

            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
        }

        public void PollForCallQueue()
        {
            try
            {
                _logger.Info("Entering Single Health Plan Zip Radius Polling Agent");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.ZipRadius);
                var criterias = _healthPlanCallQueueCriteriaService.GetHealthPlanCallQueueCriteriaNotGenerated(callQueue.Id);

                var healthPlanIds = criterias.Where(x => x.HealthPlanId != null).Select(x => x.HealthPlanId.Value).ToArray();
                var healthPlans = _corporateAccountRepository.GetByIds(healthPlanIds);

                foreach (var criteria in criterias)
                {
                    try
                    {
                        _logger.Info(string.Format("Generating single Zip Radius call queue."));
                        _healthPlanCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);

                        if (criteria.HealthPlanId.HasValue)
                        {
                            var healthPlan = healthPlans.First(x => x.Id == criteria.HealthPlanId.Value);
                            _healthPlanCallRoundService.SaveHealthPlanZipRadiusCallQueueCustomers(healthPlan, criteria, callQueue, _logger);
                        }

                        _logger.Info(string.Format("Completed single Zip Radius call queue."));

                        criteria.IsQueueGenerated = true;
                        criteria.LastQueueGeneratedDate = DateTime.Now;

                        _healthPlanCallQueueCriteriaService.Save(criteria);
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("Error while generating call queue Zip Radius  customer data for Criteria Id: {0} \n message: {1} stack trace {2}", criteria.Id, exception.Message, exception.StackTrace));
                    }

                }

                callQueue.IsQueueGenerated = true;
                callQueue.LastQueueGeneratedDate = DateTime.Now;
                _callQueueRepository.Save(callQueue);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while pulling single Zip Radius call queue. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

    }
}