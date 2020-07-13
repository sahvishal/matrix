using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class EventCustomNotificationPollingAgent : IEventCustomNotificationPollingAgent
    {

        private readonly ILogger _logger;

        private readonly IEventCustomerRepository _eventCustomerRepository;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomEventNotificationRepository _customEventNotificationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IPhoneNotificationModelsFactory _phoneNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IEventCustomerCustomNotificationRepository _eventCustomerCustomNotificationRepository;

        public EventCustomNotificationPollingAgent(ILogManager logManager, IEventCustomerRepository eventCustomerRepository,
            ICorporateAccountRepository corporateAccountRepository, ICustomEventNotificationRepository customEventNotificationRepository,
            ICustomerRepository customerRepository, IEventCustomerNotificationRepository eventCustomerNotificationRepository, IEventCustomerCustomNotificationRepository eventCustomerCustomNotificationRepository,
            IPhoneNotificationModelsFactory phoneNotificationModelsFactory, INotifier notifier, INotificationTypeRepository notificationTypeRepository)
        {
            _logger = logManager.GetLogger("EventCustomNotification");

            _eventCustomerRepository = eventCustomerRepository;

            _corporateAccountRepository = corporateAccountRepository;
            _customEventNotificationRepository = customEventNotificationRepository;
            _customerRepository = customerRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _phoneNotificationModelsFactory = phoneNotificationModelsFactory;
            _notifier = notifier;
            _notificationTypeRepository = notificationTypeRepository;
            _eventCustomerCustomNotificationRepository = eventCustomerCustomNotificationRepository;
        }

        public void PollforCustomNotification()
        {
            try
            {
                var customEventNotifications = _customEventNotificationRepository.GetNotificationByStatus((long)CustomNotificationServiceStatus.Unserviced);

                if (customEventNotifications.IsNullOrEmpty())
                {
                    _logger.Info("No Custom Notification found for Event");
                    return;
                }


                var notificationType = _notificationTypeRepository.GetByAlias(NotificationTypeAlias.CustomEventSmsNotification);
                if (!notificationType.IsQueuingEnabled)
                {
                    _logger.Info("Custom Notification Queuing is disabled. To Send this message, enable Queuing and reset status of message.");
                    return;
                }

                foreach (var customEventNotification in customEventNotifications)
                {
                    try
                    {
                        var eventId = customEventNotification.EventId;
                        _logger.Info("running for event Id: " + eventId);

                        var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

                        if (!eventCustomers.IsNullOrEmpty())
                        {
                            CorporateAccount corporateAccount = null;
                            if (customEventNotification.AccountId.HasValue && customEventNotification.AccountId.Value > 0)
                            {
                                corporateAccount = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(customEventNotification.AccountId.Value);
                            }
                            var customers = _customerRepository.GetCustomers(eventCustomers.Select(x => x.CustomerId).ToArray());

                            foreach (var eventCustomer in eventCustomers)
                            {
                                var customer = customers.First(s => s.CustomerId == eventCustomer.CustomerId);

                                var message = SendCustomNotification(customer, eventCustomer, corporateAccount, customEventNotification);

                                _eventCustomerCustomNotificationRepository.Save(new EventCustomerCustomNotification
                                {
                                    CustomEventNotificationId = customEventNotification.Id,
                                    EventCustomerId = eventCustomer.Id,
                                    Message = message
                                });
                            }
                            customEventNotification.ServiceStatus = (long)CustomNotificationServiceStatus.Serviced;
                        }
                        else { customEventNotification.ServiceStatus = (long)CustomNotificationServiceStatus.Failed; }
                    }
                    catch (Exception)
                    {
                        customEventNotification.ServiceStatus = (long)CustomNotificationServiceStatus.Failed;
                    }

                    customEventNotification.ServiceDate = DateTime.Now;

                    _customEventNotificationRepository.SaveNotification(customEventNotification);
                }

            }
            catch (Exception ex)
            {
                _logger.Info("ex message: " + ex.Message);
            }
        }

        private string SendCustomNotification(Customer customer, EventCustomer eventCustomer, CorporateAccount account, CustomEventNotification customEventNotification)
        {
            try
            {
                var message = string.Empty;
                _logger.Info("Running Custom SMS for  Customer: " + customer.CustomerId);
                if (!eventCustomer.EnableTexting)
                {
                    message = "Customer has not opted for SMS";
                    _logger.Info(message);
                    return message;
                }
                if (customer.IsSubscribed == null || customer.IsSubscribed.Value == false)
                {
                    message = "Customer has not subscribed for SMS";
                    _logger.Info(message);
                    return message;
                }
                var messageAlreadySentList = _eventCustomerNotificationRepository.GetAllByEventCustomerId(eventCustomer.EventId, NotificationTypeAlias.CustomEventSmsNotification);

                var messageCount = (!messageAlreadySentList.IsNullOrEmpty()) ? EnumerableExtensions.Count(messageAlreadySentList) : 0;

                if (account != null)
                {
                    var accountMaxSmscount = (account.MaximumSms.HasValue) ? account.MaximumSms.Value : 0;

                    if (messageCount >= accountMaxSmscount)
                    {
                        _logger.Info("Maximum SMS has Been Sent ");
                        _logger.Info(string.Format("Allowed SMS {0}, SMS Already Sent {0} " + accountMaxSmscount, messageCount));
                        message = "Maximum SMS limit has been reached.";

                        return message;
                    }
                }
                if (messageAlreadySentList.Any() && (account == null || !account.MaximumSms.HasValue))
                {
                    message = "Maximum SMS limit has been reached.";
                    return message;
                }
                var smsNotificaionModel = _phoneNotificationModelsFactory.GetCustomEventSmsNotificatonModel(customEventNotification.Body);

                var notification = _notifier.NotifyViaSms(NotificationTypeAlias.CustomEventSmsNotification, EmailTemplateAlias.CustomEventSms, smsNotificaionModel, customer.Id, customEventNotification.CreatedBy, "Event Detail ");

                if (notification != null)
                {
                    var eventCustomerNotification = new EventCustomerNotification
                    {
                        EventCustomerId = eventCustomer.Id,
                        NotificationId = notification.Id,
                        NotificationTypeId = notification.NotificationType.Id
                    };
                    _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                }

                message = "Message has been successfully Queued";

                return message;
            }
            catch (Exception exception)
            {
                _logger.Error("Some Error occurred while Queuing message");
                _logger.Info("Message: " + exception.Message);
                _logger.Info("Stack Trace: " + exception.StackTrace);

                return "Some Error occurred while Queuing message";
            }
        }
    }
}
