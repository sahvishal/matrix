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
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class PollForAppointmentReminderViaSms : IPollForAppointmentReminderViaSms
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotifier _notifier;
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly int _inverval;
        private readonly int _hoursBeforeScreeningReminderViaSms;
        private readonly IPhoneNotificationModelsFactory _smsNotificationModelsFactory;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly ISmsHelper _smsHelper;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;

        public PollForAppointmentReminderViaSms(IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
                                               INotifier notifier, ILogManager logManager, ISettings settings, IConfigurationSettingRepository configurationSettingRepository,
            IPhoneNotificationModelsFactory smsNotificationModelsFactory, IEventCustomerNotificationRepository eventCustomerNotificationRepository,
            ISmsHelper smsHelper, ICorporateAccountRepository corporateAccountRepository, IEmailTemplateRepository emailTemplateRepository)
        {
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _notifier = notifier;
            _settings = settings;
            _logger = logManager.GetLogger<PollForAppointmentReminderViaSms>();
            _hoursBeforeScreeningReminderViaSms = settings.HoursBeforeScreeningReminderViaSms;
            _inverval = settings.SmsInterval;
            _configurationSettingRepository = configurationSettingRepository;
            _smsNotificationModelsFactory = smsNotificationModelsFactory;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _smsHelper = smsHelper;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
        }


        private DateTime CreateTimeAsPerEventDate(DateTime time, DateTime eventDate)
        {
            return new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, time.Hour, 0, 0);
        }

        private bool IsLastRunforFutureEvent(DateTime clientTime, DateTime restrictionStartTime, Event eventData)
        {
            return clientTime.AddHours(_inverval) >= restrictionStartTime && clientTime.AddDays(1).Date == eventData.EventDate.Date;
        }

        private bool IsLastRunforTodayEvent(DateTime clientTime, DateTime restrictionStartTime, Event eventData)
        {
            return clientTime.AddHours(_inverval) >= restrictionStartTime && clientTime.Date == eventData.EventDate.Date;
        }

        public void PollforSendingAppointmentReminderViaSms()
        {
            try
            {
                var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification);

                if (value.ToLower() != bool.TrueString.ToLower()) return;

                var todayDate = DateTime.Now;
                var eventList = _eventRepository.GetEventsToSendSms(todayDate.AddDays(-1).Date, todayDate.AddDays(1).Date);

                if (eventList == null || !eventList.Any())
                {
                    _logger.Info(string.Format("No Event found for dates between {0} to {1} \n", todayDate.AddDays(-1).Date, todayDate.AddDays(1).Date));
                    return;
                }

                _logger.Info(string.Format("number of Event found for dates between {0} to {1} count: {2} \n", todayDate.AddDays(-1).Date, todayDate.AddDays(1).Date, eventList.Count()));

                foreach (var eventData in eventList)
                {
                    _logger.Info(string.Format("Running for Event id {0} \n", eventData.Id));

                    var restrictedStart = CreateTimeAsPerEventDate(_settings.SendSmsBeforeTime, eventData.EventDate.AddDays(-1));
                    var restrictedTimeEnd = CreateTimeAsPerEventDate(_settings.DoNotSendSmsBeforeTime, eventData.EventDate);

                    var restrictedTodayStart = CreateTimeAsPerEventDate(_settings.SendSmsBeforeTime, eventData.EventDate);
                    var restrictedTimeForTodayEventEnd = CreateTimeAsPerEventDate(_settings.DoNotSendSmsBeforeTime, eventData.EventDate.AddDays(1));
                    var clientTime = _smsHelper.ConvertLocalTimeToClientTime(DateTime.Now, eventData.TimeZone);

                    var account = _corporateAccountRepository.GetbyEventId(eventData.Id);

                    if (account != null && !account.EnableSms)
                    {
                        _logger.Info("SMS feature has been disabled by corporate account: " + account.Tag + " EventId: " + eventData.Id);
                        continue;
                    }

                    if ((eventData.EventDate.Date < clientTime.Date) || (clientTime >= restrictedStart && clientTime < restrictedTimeEnd) || (clientTime >= restrictedTodayStart && eventData.EventDate.Date == clientTime.Date))
                    {
                        _logger.Info(string.Format("Event Id {0} Time Zone falls in restreicted Time. Time at event Zone time {1} \n", eventData.Id, clientTime));
                        continue;
                    }

                    _logger.Info(string.Format("Time at timezone {0} is {1}", eventData.TimeZone, clientTime));

                    var isLastRunforFuture = IsLastRunforFutureEvent(clientTime, restrictedStart, eventData);
                    var isLastRunForToday = IsLastRunforTodayEvent(clientTime, restrictedTodayStart, eventData);

                    var fromTime = clientTime.AddHours(_hoursBeforeScreeningReminderViaSms);
                    var toTime = fromTime.AddHours(_inverval);

                    if (isLastRunforFuture)
                        toTime = restrictedTimeEnd.AddHours(_hoursBeforeScreeningReminderViaSms);

                    if (isLastRunForToday)
                        toTime = restrictedTimeForTodayEventEnd.AddHours(_hoursBeforeScreeningReminderViaSms);


                    var eventCustomerList = _eventCustomerRepository.GetEventCustomerBasedOnTime(fromTime, toTime, eventData.Id);

                    if (eventCustomerList == null)
                    {
                        _logger.Info(string.Format("No eventCustomer List found for start time {0} to End Time {1}", fromTime, toTime));
                        continue;
                    }

                    _logger.Info(string.Format("Number of EventCustomer List found for start time {0} to End Time {1} count: {2}", fromTime, toTime, eventCustomerList.Count()));

                    var customerIds = eventCustomerList.Select(ec => ec.CustomerId).Distinct().ToArray();

                    var customers = _customerRepository.GetCustomers(customerIds);

                    var messageAlreadySentList = _eventCustomerNotificationRepository.GetByEventCustomerIds(eventCustomerList.Select(x => x.Id), NotificationTypeAlias.AppointmentReminder);

                    foreach (var eventCustomer in eventCustomerList)
                    {
                        var customer = customers.First(x => x.CustomerId == eventCustomer.CustomerId);

                        _logger.Info(string.Format("Customer Id {0}, EventCustomer Id {1}, Event Id {2} \n", customer.Id, eventCustomer.Id, eventCustomer.EventId));

                        try
                        {
                            if (customer.IsSubscribed == null || customer.IsSubscribed == false)
                            {
                                _logger.Info(string.Format("customer has not Subscribed SMS. eventId {0} Customer Id: {1}", eventCustomer.EventId, eventCustomer.Id));
                                continue;
                            }
                            if (!eventCustomer.EnableTexting)
                            {
                                _logger.Info(string.Format("customer has not enable SMS. eventId {0} Customer Id: {1}", eventCustomer.EventId, eventCustomer.Id));
                                continue;
                            }

                            if (account != null && messageAlreadySentList != null && messageAlreadySentList.Any() && account.MaximumSms <= messageAlreadySentList.Count(q => q.EventCustomerId == eventCustomer.Id))
                            {
                                _logger.Info(string.Format("Maximum Number of reminder message sms has been sent for this event. eventId {0} Customer Id: {1}", eventCustomer.EventId, eventCustomer.Id));
                                continue;
                            }

                            if (account == null && messageAlreadySentList != null && messageAlreadySentList.Any() && messageAlreadySentList.Any(x => x.EventCustomerId == eventCustomer.Id))
                            {
                                _logger.Info(string.Format("reminder message has been sent for the event Customer Id {0}", eventCustomer.Id));
                                continue;
                            }


                            var smsTemplateAlias = EmailTemplateAlias.AppointmentReminder;

                            if (account != null && account.ReminderSmsTemplateId.HasValue && account.ReminderSmsTemplateId.Value > 0)
                            {
                                var smsTemplate = _emailTemplateRepository.GetById(account.ReminderSmsTemplateId.Value);
                                smsTemplateAlias = smsTemplate.Alias;
                            }

                            var screeningReminderSmsNotification = _smsNotificationModelsFactory.GetScreeningReminderSmsNotificationModel(customer, eventData);

                            var notification = _notifier.NotifyViaSms(NotificationTypeAlias.AppointmentReminder, smsTemplateAlias, screeningReminderSmsNotification, customer.Id, customer.CustomerId, "Automated Reminder Notification");

                            if (notification != null)
                            {
                                var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomer.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                                _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                            }

                            _logger.Info(string.Format("notification sent in to queue for the evetn customer {0}", eventCustomer.Id));
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
            }

        }
    }
}
