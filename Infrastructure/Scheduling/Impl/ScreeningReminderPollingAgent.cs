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
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class ScreeningReminderPollingAgent : IScreeningReminderPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;

        private readonly int _daysIntervalBeforeEvent;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;

        public ScreeningReminderPollingAgent(IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory, ICustomerRepository customerRepository,
                                                INotifier notifier, ILogManager logManager, ISettings settings, IConfigurationSettingRepository configurationSettingRepository, ICorporateAccountRepository corporateAccountRepository,
                                                IEmailTemplateRepository emailTemplateRepository)
        {
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _logger = logManager.GetLogger<ScreeningReminderPollingAgent>();
            _daysIntervalBeforeEvent = settings.DaysBeforeScreeningReminder;
            _configurationSettingRepository = configurationSettingRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
        }

        public void PollforSendingScreeningReminders()
        {
            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.ScreeningReminderNotification);

            if (value.ToLower() != bool.TrueString.ToLower()) return;

            const int pageSize = 50;
            int pageNumber = 1;

            _logger.Info("\n");
            _logger.Info(string.Format("Screening Reminder Queuing. Date: {0:MM/dd/yyyy} ", DateTime.Now));
            _logger.Info("\n");

            var filter = new EventBasicInfoViewModelFilter
                             {
                                 DateFrom = DateTime.Now.Date.AddDays(_daysIntervalBeforeEvent),
                                 DateTo = DateTime.Now.Date.AddDays(_daysIntervalBeforeEvent)
                             };

            while (true)
            {
                int totalRecords;

                var events = _eventRepository.GetEventsbyFilters(filter, pageNumber, pageSize, out totalRecords);

                events = events.Where(e => e.Status == EventStatus.Active || (e.Status == EventStatus.Suspended && e.IsLocked));

                if (events == null || !events.Any())
                {
                    _logger.Info("No Events Found!");
                    break;
                }

                foreach (var theEvent in events)
                {
                    CorporateAccount account = null;
                    if (theEvent.EventType == EventType.Corporate)
                    {
                        var sendNotification = false;

                        if (theEvent.AccountId.HasValue && theEvent.AccountId.Value > 0)
                        {
                            account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(theEvent.AccountId.Value);
                            sendNotification = account.SendAppointmentMail && account.AppointmentReminderMailTemplateId > 0;
                        }
                        if (!sendNotification)
                            continue;
                    }

                    _logger.Info(string.Format("Queuing Event [Id:{0}] [Name:{1}]  [Date:{2:MM/dd/yyyy}] ", theEvent.Id, theEvent.Name, theEvent.EventDate));
                    _logger.Info("\n");

                    var eventCustomers = _eventCustomerRepository.GetbyEventId(theEvent.Id);

                    var customerIds = eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue).Select(ec => ec.CustomerId).Distinct().ToArray();
                    if (!customerIds.Any())
                    {
                        _logger.Info("No Customers Found!");
                        continue;
                    }

                    var customers = _customerRepository.GetCustomers(customerIds);

                    foreach (var customer in customers)
                    {
                        _logger.Info(string.Format("Queuing Customer [Id:{0}] [Name:{1}]  ", customer.CustomerId, customer.NameAsString));
                        try
                        {
                            var appointmentConfirmationViewModel = _emailNotificationModelsFactory.GetAppointmentConfirmationModel(theEvent.Id, customer.CustomerId);

                            string emailTemplateAlias = EmailTemplateAlias.ScreeningReminderMail;

                            if (account != null && account.AppointmentReminderMailTemplateId > 0)
                            {
                                var emailTemplate = _emailTemplateRepository.GetById(account.AppointmentReminderMailTemplateId);
                                emailTemplateAlias = emailTemplate.Alias;
                            }

                            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ScreeningReminderMail, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, customer.CustomerId, "Automated Reminder Notification", useAlternateEmail: true);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                        }
                    }
                }

                if ((pageNumber * pageSize) >= totalRecords)
                    break;

                pageNumber++;
            }

        }

    }
}