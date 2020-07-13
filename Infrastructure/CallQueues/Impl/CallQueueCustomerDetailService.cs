using System;
using System.Threading;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallQueueCustomerDetailService : ICallQueueCustomerDetailService
    {
        private readonly ICallQueueCustomerLockRepository _callQueueCustomerLockRepository;
        private readonly ISessionContext _sessionContext;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IProspectCustomerFactory _prospectCustomerFactory;
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCustomerContactService _callQueueCustomerContactService;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly ICallQueueCriteriaRepository _callQueueCriteriaRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        private const int PageSizeForContactCustomer = 50;
        private readonly ILogger _logger;
        public CallQueueCustomerDetailService(ICallQueueCustomerLockRepository callQueueCustomerLockRepository, ISessionContext sessionContext,
            ICallQueueCustomerRepository callQueueCustomerRepository, ICustomerRepository customerRepository, IProspectCustomerRepository prospectCustomerRepository,
            IProspectCustomerFactory prospectCustomerFactory, ICallQueueRepository callQueueRepository,
            ICallQueueCustomerContactService callQueueCustomerContactService, ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository, ILogManager logManager,
            IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService, ICallQueueCriteriaRepository callQueueCriteriaRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _callQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _sessionContext = sessionContext;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _prospectCustomerFactory = prospectCustomerFactory;
            _callQueueRepository = callQueueRepository;
            _callQueueCustomerContactService = callQueueCustomerContactService;
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _callQueueCriteriaRepository = callQueueCriteriaRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _logger = logManager.GetLogger<CallQueueCustomerDetailService>();
        }

        public StartOutBoundCallViewModel GetCustomerContactViewModel(OutboundCallQueueFilter filter)
        {
            StartOutBoundCallViewModel customerContactViewModel = null;

            //var isAllowed = _callQueueCriteriaRepository.CheckForHealthplanRestriction(filter.AgentOrganizationId, filter.HealthPlanId);
            //if (!isAllowed)
            //{
            //    return new StartOutBoundCallViewModel
            //    {
            //        NoMoreCustomerInList = true
            //    };
            //}

            var iscriteriaAssignmentChanged = _callQueueCriteriaRepository.CheckForCriteriaAssignmentChange(filter.CriteriaId, filter.AgentOrganizationRoleUserId,
                filter.AgentOrganizationId, filter.HealthPlanId);

            if (iscriteriaAssignmentChanged)
            {
                return new StartOutBoundCallViewModel
                {
                    AssignmentChanged = true
                };
            }

            var callQueue = _callQueueRepository.GetById(filter.CallQueueId);

            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
            var index = 1;
            _logger.Info("fetching customer for agent " + _sessionContext.UserSession.UserName);
            do
            {
                _logger.Info(string.Format("Call Queue Customer loop number {0} for agent {1}", index++, _sessionContext.UserSession.UserName));

                _logger.Info("fetching next customers");
                customerContactViewModel = GetStartOutboundCallViewModel(filter, callQueue);
                if (customerContactViewModel != null && customerContactViewModel.NoMoreCustomerInList)
                {
                    _logger.Info("queue completed no customer found");
                    break;
                }

                Thread.Sleep(100);
            } while (customerContactViewModel == null && index < 3);

            if (customerContactViewModel == null)
            {
                customerContactViewModel = new StartOutBoundCallViewModel
                {
                    TryAgain = true
                };
            }

            return customerContactViewModel;
        }

        public StartOutBoundCallViewModel GetStartOutboundCallViewModel(OutboundCallQueueFilter filter, CallQueue callQueue)
        {
            var callQueueCustomers = _callQueueCustomerContactService.GetSingleCustomerFromCallQueue(filter, PageSizeForContactCustomer, callQueue);

            if (callQueueCustomers.IsNullOrEmpty())
            {
                return new StartOutBoundCallViewModel
                {
                    NoMoreCustomerInList = true
                };
            }
            _logger.Info("customers found in queue");

            long count = 1;
            foreach (var callQueueCustomer in callQueueCustomers)
            {
                _logger.Info("call queue customer " + callQueueCustomer.Id + " checking for locked ");
                _logger.Info(string.Format("Check for lock loop number {0} for agent {1}", count++, _sessionContext.UserSession.UserName));

                var callAttempt = SetCustomerCallQueueAttempt(callQueueCustomer);
                if (callAttempt != null)
                {
                    _logger.Info(" customer locked for agent " + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    return new StartOutBoundCallViewModel
                    {
                        CallQueueCustomerId = callQueueCustomer.Id,
                        AttemptId = callAttempt.CallAttemptId
                    };
                }
            }

            _logger.Info("Batch completed no customer found.");

            return null;
        }

        private CustomerCallQueueCallAttempt SetCustomerCallQueueAttempt(CallQueueCustomer callQueueCustomer)
        {

            try
            {
                var lockedCustomer = _callQueueCustomerLockRepository.GetCallQueueCustomerLock(callQueueCustomer);

                if (lockedCustomer != null)
                {
                    return null;
                }

                var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(callQueueCustomer.CustomerId.Value);

                Customer customer = null;
                if (prospectCustomer == null)
                    customer = _customerRepository.GetCustomer(callQueueCustomer.CustomerId.Value);

                using (var scope = new TransactionScope())
                {
                    //lock customer in call queue so that other agent not be able to call them;
                    var domain = new CallQueueCustomerLock
                    {
                        CallQueueCustomerId = callQueueCustomer.Id,
                        CustomerId = callQueueCustomer.CustomerId,
                        ProspectCustomerId = callQueueCustomer.ProspectCustomerId,
                        CreatedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                        CreatedOn = DateTime.Now
                    };

                    _callQueueCustomerLockRepository.SaveCallQueueCustomerLock(domain);                                     //Lock Customer

                    callQueueCustomer.Status = CallQueueStatus.InProcess;
                    callQueueCustomer.DateModified = DateTime.Now;
                    callQueueCustomer.ModifiedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                    _callQueueCustomerRepository.Save(callQueueCustomer, false);                                                  //Update CallQueueCustomer Status



                    if (prospectCustomer == null && customer != null)
                    {
                        prospectCustomer = _prospectCustomerFactory.CreateProspectCustomerFromCustomer(customer, false);
                        ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);
                    }

                    var customerCallQueueCallAttempt = new CustomerCallQueueCallAttempt
                    {
                        DateCreated = DateTime.Now,
                        IsCallSkipped = false,
                        IsNotesReadAndUnderstood = false,
                        CreatedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                        CustomerId = callQueueCustomer.CustomerId.Value,
                        CallId = null,
                        CallQueueCustomerId = callQueueCustomer.Id,
                        NotInterestedReasonId = null
                    };

                    var callAttempt = _customerCallQueueCallAttemptRepository.Save(customerCallQueueCallAttempt);           //CustomerCallQueueCallAttempt Entry
                    scope.Complete();
                    return callAttempt;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some Error occured");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
            return null;
        }

        public void DoNoShowCallQueueCustomerChanges(long eventCustomerId, bool isNoShow, DateTime? noShowDateTime)
        {
            var appointmentCallQueueId = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.AppointmentConfirmation).Id;
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            if (eventCustomer == null)                                                                          //if wrong eventcustomerId provided
                return;

            var appointmentDate = _eventCustomerRepository.GetFutureMostAppointmentDateForEventCustomerByCustomerId(eventCustomer.CustomerId);

            if (appointmentDate != null)
            {
                noShowDateTime = null;
            }
            _callQueueCustomerRepository.UpdateCallQueueCustomerForNoShow(eventCustomer.CustomerId, appointmentDate, noShowDateTime, appointmentCallQueueId);
        }
    }
}