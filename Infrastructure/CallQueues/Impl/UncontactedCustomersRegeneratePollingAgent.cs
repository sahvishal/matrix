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
    public class UncontactedCustomersRegeneratePollingAgent : IUncontactedCustomersRegeneratePollingAgent
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ILogger _logger;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteria;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;

        public UncontactedCustomersRegeneratePollingAgent(ICallQueueRepository callQueueRepository, ILogManager logManager, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteria,
            ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallRoundService healthPlanCallRoundService, IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository)
        {
            _callQueueRepository = callQueueRepository;
            _logger = logManager.GetLogger("UncontactedCustomersRegeneratePollingAgent");
            _healthPlanCallQueueCriteria = healthPlanCallQueueCriteria;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
        }

        public void PollForRegenerateUncontactedCustomer()
        {
            try
            {
                _logger.Info("Entering Single Health Plan Uncontacted Customers Polling Agent");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.UncontactedCustomers);
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();

                if (callQueue != null)
                {
                    var criteria = _healthPlanCallQueueCriteria.GetQueueCriteriasByQueueId(callQueue.Id);

                    criteria = criteria.Where(x => !x.IsQueueGenerated && !x.IsDefault);

                    foreach (var queueCriteria in criteria)
                    {
                        _healthPlanCallQueueAssignmentRepository.DeleteByCriteriaId(queueCriteria.Id);

                        if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                        {
                            var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);
                            _healthPlanCallRoundService.SaveHealthPlanUncontactedCustomerCallQueue(corporateAccount, queueCriteria, callQueue, _logger);
                        }

                        queueCriteria.IsQueueGenerated = true;
                        queueCriteria.LastQueueGeneratedDate = DateTime.Now;
                        _healthPlanCallQueueCriteria.Save(queueCriteria);
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.Error("Error while regenration");
                _logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }
    }
}