using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ResultReadyNotificationPollingAgent : IResultReadyNotificationPollingAgent
    {
        private readonly ILogger _logger;

        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IDigitalAssetAccessLogRepository _digitalAssetAccessLogRepository;

        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;

        private readonly ISettings _setting;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;

        public ResultReadyNotificationPollingAgent(ILogManager logManager, IEventCustomerResultRepository eventCustomerResultRepository, ICustomerRepository customerRepository, IConfigurationSettingRepository configurationSettingRepository,
            IEventRepository eventRepository, IShippingDetailRepository shippingDetailRepository, IDigitalAssetAccessLogRepository digitalAssetAccessLogRepository, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory,
            ISettings setting, ICorporateAccountRepository corporateAccountRepository, IEmailTemplateRepository emailTemplateRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository)
        {
            _logger = logManager.GetLogger<ResultReadyNotificationPollingAgent>();
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerRepository = customerRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _eventRepository = eventRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _digitalAssetAccessLogRepository = digitalAssetAccessLogRepository;

            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;

            _setting = setting;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
        }

        public void PollforResultReadyNotification()
        {
            _logger.Info("Starting the Polling Agent for Second Result Ready Notification.");

            bool sendNotification = Convert.ToBoolean(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableResultDeliveryNotification));

            if (!sendNotification)
                return;

            var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultsForResultReadyNotification(_setting.DaysAfterResultReady);
            if (eventCustomerResults != null && eventCustomerResults.Any())
            {
                foreach (var eventCustomerResult in eventCustomerResults)
                {
                    try
                    {
                        var isResultAccessed = _digitalAssetAccessLogRepository.IsDigitalAssetAccessed(eventCustomerResult.CustomerId, eventCustomerResult.DataRecorderMetaData.DateModified.Value);
                        if (isResultAccessed)
                            continue;

                        var shippingDetails = _shippingDetailRepository.GetShippingDetailsForEventCustomer(eventCustomerResult.EventId, eventCustomerResult.CustomerId);
                        bool isPaperCopyPurchased = shippingDetails != null && shippingDetails.Any();

                        if (isPaperCopyPurchased)
                            continue;

                        var account = _corporateAccountRepository.GetbyEventId(eventCustomerResult.EventId);
                        if (account != null && !(account.SendResultReadyMail && account.ResultReadyMailTemplateId > 0))
                            continue;

                        var eventData = _eventRepository.GetById(eventCustomerResult.EventId);

                        if (eventData.NotifyResultReady)
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

                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.Info(String.Format("\n System failure: For EventId:{0} and CustomerId:{1} \n Message{2}", eventCustomerResult.EventId, eventCustomerResult.CustomerId, ex.Message));
                    }

                }
            }
            else
            {
                _logger.Info("No records found result found for Second Result Ready Notification.");
            }
        }
    }
}
