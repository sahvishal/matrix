using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class SecondScreeningReminderPollingAgent : ISecondScreeningReminderPollingAgent
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;

        private readonly int _hoursBeforeAppointment;
        private readonly int _interval;


        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public SecondScreeningReminderPollingAgent(ISettings settings, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory,
                                                IConfigurationSettingRepository configurationSettingRepository, INotifier notifier, ILogManager logManager, ICorporateAccountRepository corporateAccountRepository,
                                                IEmailTemplateRepository emailTemplateRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _logger = logManager.GetLogger<SecondScreeningReminderPollingAgent>();
            _hoursBeforeAppointment = settings.HoursBeforeSecondScreeningReminder;
            _interval = settings.IntervalSecondScreeningReminder;

            _configurationSettingRepository = configurationSettingRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
        }

        public void PollforSendingScondScreeningReminders()
        {
            try
            {
                var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.ScreeningReminderNotification);

                if (value.ToLower() != bool.TrueString.ToLower())
                    return;

                var eventCustomers = _eventCustomerRepository.GetEventCustomersForSecondScreeingReminderNotification(_hoursBeforeAppointment, _interval);
                if (eventCustomers != null && eventCustomers.Any())
                {
                    foreach (var eventCustomer in eventCustomers)
                    {
                        try
                        {
                            var account = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);
                            if (account != null && !(account.SendAppointmentMail && account.AppointmentReminderMailTemplateId > 0))
                                continue;

                            _logger.Info(string.Format("Sending second screening reminder for Customer [Id:{0}] and Event[Id:{1}]  ", eventCustomer.CustomerId, eventCustomer.EventId));

                            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

                            var appointmentConfirmationViewModel = _emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventCustomer.EventId, eventCustomer.CustomerId);

                            string emailTemplateAlias = EmailTemplateAlias.ScreeningReminderMail;

                            if (account != null && account.AppointmentReminderMailTemplateId > 0)
                            {
                                var emailTemplate = _emailTemplateRepository.GetById(account.AppointmentReminderMailTemplateId);
                                emailTemplateAlias = emailTemplate.Alias;
                            }

                            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.TwoHoursBeforeAppointment, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, eventCustomer.CustomerId, "Second Automated Reminder Notification");
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    _logger.Info("No Customers Found for Second screening reminder!");
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Exception occurred while Poll for Sending Second Screening Reminders");
                _logger.Error("Exception:  " + exception.Message);
                _logger.Error("Exception:  " + exception.StackTrace);
            }

        }
    }
}
