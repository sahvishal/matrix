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
    public class HealthPlanUncontactedCustomersPollingAgent : IHealthPlanUncontactedCustomersPollingAgent
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ILogger _logger;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteria;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;
        // private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;


        public HealthPlanUncontactedCustomersPollingAgent(ICallQueueRepository callQueueRepository, ILogManager logManager, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteria,
            ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallRoundService healthPlanCallRoundService,IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository)//, ICallQueueCustomerRepository callQueueCustomerRepository)
        {
            _callQueueRepository = callQueueRepository;
            _logger = logManager.GetLogger("For24hrs_HealthPlanUncontactedCustomers");
            _healthPlanCallQueueCriteria = healthPlanCallQueueCriteria;

            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
            //_callQueueCustomerRepository = callQueueCustomerRepository;
        }

        public void PollForHealthPlanUncontactedCustomer()
        {
            try
            {
                _logger.Info("Entering Health Plan Uncontacted Customers Polling Agent For 24 hrs");
                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.UncontactedCustomers);
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();

                if (callQueue != null)
                {
                   // _callQueueCustomerRepository.DeleteCallQueueCustomersHasNotBeenCalled(callQueue.Id);

                    var criteria = _healthPlanCallQueueCriteria.GetQueueCriteriasByQueueId(callQueue.Id);

                    criteria = criteria.Where(x => x.IsQueueGenerated);

                    foreach (var queueCriteria in criteria)
                    {
                        try
                        {
                            _healthPlanCallQueueAssignmentRepository.DeleteByCriteriaId(queueCriteria.Id);
                            //if (queueCriteria.IsDefault)
                            //{
                            //    foreach (var corporateAccount in healthPlans)
                            //    {
                            //        _healthPlanCallRoundService.SaveHealthPlanUncontactedCustomerCallQueue(corporateAccount, queueCriteria, callQueue, _logger);
                            //    }
                            //}
                            //else
                            if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                            {
                                var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);
                                _healthPlanCallRoundService.SaveHealthPlanUncontactedCustomerCallQueue(corporateAccount, queueCriteria, callQueue, _logger);
                            }

                            queueCriteria.IsQueueGenerated = true;
                            queueCriteria.LastQueueGeneratedDate = DateTime.Now;
                            _healthPlanCallQueueCriteria.Save(queueCriteria);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("call Queue Id " + callQueue.Id);
                            _logger.Error("criteria Id " + queueCriteria.Id);
                            _logger.Error("Message " + exception.Message);
                            _logger.Error("Stack Trace " + exception.StackTrace);
                        }
                        
                    }
                }

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }

        }

    }
}