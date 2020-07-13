using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class SmsReceivedNotificationService : ISmsReceivedNotificationService
    {
        private readonly ISmsReceivedRepository _smsReceivedRepository;
        private readonly ICustomerUnsubscribedSmsNotificationRepository _customerUnsubscribedSmsNotificationRepository;
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly ICustomerService _customerService;
        private readonly IPhoneNotificationModelsFactory _phoneNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        public SmsReceivedNotificationService(ISmsReceivedRepository smsReceivedRepository,
            ICustomerUnsubscribedSmsNotificationRepository customerUnsubscribedSmsNotificationRepository,
            IPhoneNumberFactory phoneNumberFactory, ICustomerRepository customerRepository,
            INotificationRepository notificationRepository, ICustomerService customerService,
            IPhoneNotificationModelsFactory phoneNotificationModelsFactory, INotifier notifier, ILogManager logManager)
        {
            _smsReceivedRepository = smsReceivedRepository;
            _customerUnsubscribedSmsNotificationRepository = customerUnsubscribedSmsNotificationRepository;
            _phoneNumberFactory = phoneNumberFactory;
            _customerRepository = customerRepository;
            _notificationRepository = notificationRepository;
            _customerService = customerService;
            _phoneNotificationModelsFactory = phoneNotificationModelsFactory;
            _notifier = notifier;
            _logger = logManager.GetLogger("TwilioMessgePollingAgent");
        }

        public void SmsReceivedNotification(TwillioMessageResponse message)
        {
            if (message != null)
            {
                var phoneMobile = _phoneNumberFactory.CreatePhoneNumber(message.From, PhoneNumberType.Mobile);
                if (phoneMobile == null) return;

                var mobilePhonNumber = phoneMobile.AreaCode + phoneMobile.Number;
                var customers = _customerRepository.GetCustomersByPhoneNumber(mobilePhonNumber, PhoneNumberType.Mobile);
                var smsReceivedTime = DateTime.Now;

                var smsReceived = new SmsReceived
                {
                    DateCreated = smsReceivedTime,
                    Message = message.Body,
                    PhoneNumber = mobilePhonNumber
                };

                smsReceived = _smsReceivedRepository.SaveSmsReceived(smsReceived);

                if (customers.IsNullOrEmpty())
                {
                    _logger.Info("No customer found with matching Phone Number");
                    return;
                }

                if (!string.IsNullOrEmpty(message.Body) && SmsOptOutKeyWords.OptOutKey.Contains(message.Body.ToLower()))
                {
                    var unsubscriptModel = new CustomerUnsubscribedSmsNotification
                    {
                        DateCreated = smsReceivedTime,
                        SmsReceivedId = smsReceived.Id,
                        StatusId = (long)SmsNotificationSubscriptionStatus.Unsubscribe
                    };

                    foreach (var customer in customers)
                    {
                        unsubscriptModel.CustomerId = customer.CustomerId;

                        _customerUnsubscribedSmsNotificationRepository.SaveUnsubscribedSmsStatus(unsubscriptModel);

                        customer.IsSubscribed = false;
                        _customerService.SaveCustomerOnly(customer, customer.CustomerId);
                    }
                }
                else if (!string.IsNullOrEmpty(message.Body) && SmsOptInKeyWords.OptInKey.Contains(message.Body.ToLower()))
                {
                    var unsubscriptModel = new CustomerUnsubscribedSmsNotification
                    {
                        DateCreated = smsReceivedTime,
                        SmsReceivedId = smsReceived.Id,
                        StatusId = (long)SmsNotificationSubscriptionStatus.Subscribe
                    };

                    foreach (var customer in customers)
                    {
                        unsubscriptModel.CustomerId = customer.CustomerId;
                        _customerUnsubscribedSmsNotificationRepository.SaveUnsubscribedSmsStatus(unsubscriptModel);

                        customer.IsSubscribed = true;
                        _customerService.SaveCustomerOnly(customer, customer.CustomerId);
                    }
                }
                else
                {
                    if (!customers.IsNullOrEmpty())
                    {
                        Customer customer = null;
                        if (customers.Count() > 1)
                        {
                            var lastNotificationSentTo =
                                _notificationRepository.GetLatestNotificationByPhone(mobilePhonNumber);
                            customer = customers.FirstOrDefault(s => s.Id == lastNotificationSentTo.UserId) ?? customers.First();

                        }
                        else
                        {
                            customer = customers.First();
                        }

                        if (customer != null)
                        {
                            var screeningReminderSmsNotification = _phoneNotificationModelsFactory.GetDummyWrongSmsResponseNotificationViewModel();

                            var notification = _notifier.NotifyViaSms(NotificationTypeAlias.WrongSmsReponse, EmailTemplateAlias.WrongSmsReponse, screeningReminderSmsNotification, customer.Id, customer.CustomerId, "Wrong Sms Response");
                        }
                    }
                }
            }
        }

    }
}
