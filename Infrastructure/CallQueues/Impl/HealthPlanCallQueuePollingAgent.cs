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
    public class HealthPlanCallQueuePollingAgent : IHealthPlanCallQueuePollingAgent
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteria;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignment;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly ILogger _logger;

        public HealthPlanCallQueuePollingAgent(ICallQueueRepository callQueueRepository, ILogManager logManager, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteria,
            IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignment, ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallRoundService healthPlanCallRoundService)
        {
            _logger = logManager.GetLogger("For24hrs_HealthPlanCallQueuePollingAgent");
            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueCriteria = healthPlanCallQueueCriteria;
            _healthPlanCallQueueAssignment = healthPlanCallQueueAssignment;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;
        }

        public void PollForHealthPlanCallQueue()
        {
            try
            {
                _logger.Info("Entering Health Plan Polling Agent To Generate Call Queue For CallRound, NoShows and ZipRadius");

                var callQueues = _callQueueRepository.GetAll(false, true);
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();

                if (!callQueues.IsNullOrEmpty())
                {
                    callQueues = callQueues.Where(x => x.Category != HealthPlanCallQueueCategory.FillEventsHealthPlan && x.Category != HealthPlanCallQueueCategory.UncontactedCustomers
                                                    && x.Category != HealthPlanCallQueueCategory.MailRound);

                    foreach (var callQueue in callQueues)
                    {
                        try
                        {
                            var criteria = _healthPlanCallQueueCriteria.GetQueueCriteriasByQueueId(callQueue.Id);
                            criteria = criteria.Where(x => x.IsQueueGenerated);

                            switch (callQueue.Category)
                            {
                                case HealthPlanCallQueueCategory.CallRound:
                                    {
                                        foreach (var queueCriteria in criteria)
                                        {
                                            try
                                            {
                                                _healthPlanCallQueueAssignment.DeleteByCriteriaId(queueCriteria.Id);

                                                if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                                                {
                                                    var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);
                                                    _healthPlanCallRoundService.SaveCallRoundCallQueueCustomers(corporateAccount, queueCriteria, callQueue, _logger);
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
                                    break;

                                //case HealthPlanCallQueueCategory.NoShows:
                                //    {
                                //        foreach (var queueCriteria in criteria)
                                //        {
                                //            try
                                //            {
                                //                _healthPlanCallQueueAssignment.DeleteByCriteriaId(queueCriteria.Id);

                                //                if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                                //                {
                                //                    var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);
                                //                    _healthPlanCallRoundService.SaveNoShowCallQueueCustomers(corporateAccount, queueCriteria, callQueue, _logger);
                                //                }
                                //                queueCriteria.IsQueueGenerated = true;
                                //                queueCriteria.LastQueueGeneratedDate = DateTime.Now;
                                //                _healthPlanCallQueueCriteria.Save(queueCriteria);
                                //            }
                                //            catch (Exception exception)
                                //            {
                                //                _logger.Error("call Queue Id " + callQueue.Id);
                                //                _logger.Error("criteira Id " + queueCriteria.Id);
                                //                _logger.Error("Message " + exception.Message);
                                //                _logger.Error("Stack Trace " + exception.StackTrace);
                                //            }
                                            
                                //        }
                                //    }
                                //    break;
                                //case HealthPlanCallQueueCategory.ZipRadius:
                                //    {
                                //        foreach (var queueCriteria in criteria)
                                //        {
                                //            _healthPlanCallQueueAssignment.DeleteByCriteriaId(queueCriteria.Id);

                                //            if (queueCriteria.IsDefault)
                                //            {
                                //                foreach (var corporateAccount in healthPlans)
                                //                {
                                //                    _healthPlanCallRoundService.SaveHealthPlanZipRadiusCallQueueCustomers(corporateAccount, queueCriteria, callQueue, _logger);
                                //                }
                                //            }
                                //            else if (queueCriteria.HealthPlanId.HasValue && !healthPlans.IsNullOrEmpty())
                                //            {
                                //                var corporateAccount = healthPlans.First(x => x.Id == queueCriteria.HealthPlanId.Value);
                                //                _healthPlanCallRoundService.SaveHealthPlanZipRadiusCallQueueCustomers(corporateAccount, queueCriteria, callQueue, _logger);
                                //            }
                                //            queueCriteria.IsQueueGenerated = true;
                                //            queueCriteria.LastQueueGeneratedDate = DateTime.Now;
                                //            _healthPlanCallQueueCriteria.Save(queueCriteria);
                                //        }
                                //    }
                                //    break;
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
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("error health plan call queue."));
                _logger.Error(string.Format("Message {0} stack trace: {1} ", exception.Message, exception.StackTrace));
            }
        }

    }
}