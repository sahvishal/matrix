using System;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories.Screening;


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IResultNotificationPollingAgent))]
    public class ResultNotificationPollingAgent : IResultNotificationPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotifier _notifier;
        private readonly ITestResultRepository _testResultRepository;
        private readonly ILogger _logger;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly int _buffer;
        private readonly IOrderRepository _orderRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ISettings _settings;


        public ResultNotificationPollingAgent(IEventCustomerResultRepository eventCustomerResultRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, ICustomerRepository customerRepository,
            INotifier notifier, ILogManager logManager, ISettings settings, IConfigurationSettingRepository configurationSettingRepository, IOrderRepository orderRepository, IShippingDetailRepository shippingDetailRepository,
            IEventRepository eventRepository, ICorporateAccountRepository corporateAccountRepository, IEmailTemplateRepository emailTemplateRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _customerRepository = customerRepository;
            _notifier = notifier;
            _testResultRepository = new TestResultRepository();
            _logger = logManager.GetLogger<ResultNotificationPollingAgent>();
            _buffer = settings.IntervalResultDeliveryBuffer;

            _configurationSettingRepository = configurationSettingRepository;
            _orderRepository = orderRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _settings = settings;
        }

        public void PollforResultNotification()
        {
            _logger.Info("Starting the Polling Agent for Result Notification.");

            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsForResultReadyNotification((int)TestResultStateNumber.PostAudit, (int)NewTestResultStateNumber.PdfGenerated, false);
            if (eventCustomerResults != null && eventCustomerResults.Any())
            {
                _logger.Info("Get the event customer result list.");

                eventCustomerResults = eventCustomerResults.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DateModified != null && ec.DataRecorderMetaData.DateModified.Value < DateTime.Now.AddMinutes(-1 * _buffer)).ToArray();
                bool sendNotification = Convert.ToBoolean(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableResultDeliveryNotification));

                foreach (var eventCustomerResult in eventCustomerResults)
                {
                    try
                    {
                        //Check, if is unpaid. if yes, continue
                        var isPaperCopyPurchased = false;
                        var order = _orderRepository.GetOrderByEventCustomerId(eventCustomerResult.Id);
                        if (order != null)
                        {
                            var orderDetail = order.OrderDetails.SingleOrDefault(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem)
                                                        && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted);

                            if (orderDetail != null)
                            {
                                var resultShippingDetails = _shippingDetailRepository.GetShippingDetailsForCancellation(orderDetail.Id);
                                isPaperCopyPurchased = resultShippingDetails != null && resultShippingDetails.Count() > 0 ? true : false;
                                //resultShippingDetails = resultShippingDetails.Where(sd => sd.Status == ShipmentStatus.Processing).Select(sd => sd).ToArray();
                            }
                            if (order.DiscountedTotal > order.TotalAmountPaid)
                            {
                                _logger.Info("\n Customer [Id: " + eventCustomerResult.CustomerId + "] has not paid for event [Id:" + eventCustomerResult.EventId + "]");
                                continue;
                            }
                        }
                        _logger.Info(string.Format("\n Customer Id [{0}] & Event Id [{1}] being taken to delivery state. ----------------------------", eventCustomerResult.CustomerId, eventCustomerResult.EventId));

                        var eventData = _eventRepository.GetById(eventCustomerResult.EventId);

                        var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

                        //if (isNewResultFlow)
                        //{
                        //    if (!eventCustomerResult.AcesApprovedOn.HasValue || eventCustomerResult.AcesApprovedOn.Value > DateTime.Now.Date)
                        //        continue;
                        //}
                        var customerEventScreeningTestIds = _testResultRepository.GetCustomerEventScreeningTestIds(eventCustomerResult.EventId, eventCustomerResult.CustomerId);
                        var customerTests = _eventCustomerResultRepository.GetCustomerTests(eventCustomerResult.Id);

                        using (var scope = new TransactionScope())
                        {
                            if (isNewResultFlow)
                            {
                                _testResultRepository.SetResultstoState((int)NewTestResultStateNumber.ResultDelivered, false, eventCustomerResult.DataRecorderMetaData.DataRecorderModifier.Id, customerEventScreeningTestIds);
                            }
                            else
                            {
                                _testResultRepository.UpdateStateforCustomerNotification(eventCustomerResult.Id);
                            }

                            _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.Id, customerTests);

                            var account = _corporateAccountRepository.GetbyEventId(eventCustomerResult.EventId);
                            if (account == null || (account.SendResultReadyMail && account.ResultReadyMailTemplateId > 0))
                            {
                                
                                if (sendNotification && eventData.NotifyResultReady)
                                {
                                    string emailTemplateAlias = EmailTemplateAlias.ResultsReady;

                                    if (account != null && account.ResultReadyMailTemplateId > 0)
                                    {
                                        var emailTemplate = ((IUniqueItemRepository<EmailTemplate>)_emailTemplateRepository).GetById(account.ResultReadyMailTemplateId);
                                        emailTemplateAlias = emailTemplate.Alias;
                                    }

                                    var customer = _customerRepository.GetCustomer(eventCustomerResult.CustomerId);

                                    _logger.Info("\n Sending Notification at " + (customer.Email != null ? customer.Email.ToString() : ""));

                                    if (emailTemplateAlias == EmailTemplateAlias.ResultsReady)
                                    {
                                        var resultReadyViewModel = _emailNotificationModelsFactory.GetResultReadyModel(customer.Name.FullName, customer.UserLogin.UserName, isPaperCopyPurchased, eventCustomerResult.EventId);
                                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ResultsReady, emailTemplateAlias, resultReadyViewModel, customer.Id, customer.CustomerId, "Result Notification");
                                    }
                                    else
                                    {
                                        var primaryCarePhysician = _primaryCarePhysicianRepository.Get(customer.CustomerId);

                                        if (primaryCarePhysician == null)
                                        {
                                            _logger.Error(string.Format("No primary Care Physician found for Customer Id: {0} \n", customer.CustomerId));
                                            continue;
                                        }

                                        var resultReadyViewModel = _emailNotificationModelsFactory.GetPpCustomerResultNotificationModel(customer, primaryCarePhysician);
                                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ResultsReady, emailTemplateAlias, resultReadyViewModel, customer.Id, customer.CustomerId, "Result Notification");
                                    }

                                    // Commented when implemented one way password hashing
                                    //if (customer.UserLogin != null && !customer.UserLogin.UserVerified && (account == null || account.SendWelcomeEmail))
                                    //{
                                    //    var passwordNotificationModel = _emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel(customer.Name.ToString(), customer.UserLogin.Password);
                                    //    _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithPassword, EmailTemplateAlias.CustomerWelcomeEmailWithPassword, passwordNotificationModel, customer.Id, customer.CustomerId, "Result Notification");
                                    //}

                                }
                            }
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Info(
                            String.Format("\n System failure: For EventId:{0} and CustomerId:{1} \n Message{2}", eventCustomerResult.EventId, eventCustomerResult.CustomerId, ex.Message));
                    }

                }
            }
            else
            {
                _logger.Info("No event customer result found.");
            }
        }
    }
}
