using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class AnnualReminderPollingAgent : IAnnualReminderPollingAgent
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventService _eventService;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ISettings _settings;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        private readonly ILogger _logger;
        public AnnualReminderPollingAgent(ICustomerRepository customerRepository, IEventService eventService, IEmailNotificationModelsFactory emailNotificationModelsFactory,
            INotifier notifier, ISettings settings, INotificationTypeRepository notificationTypeRepository, ILogManager logManager)
        {
            _customerRepository = customerRepository;
            _eventService = eventService;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _settings = settings;
            _notificationTypeRepository = notificationTypeRepository;
            _logger = logManager.GetLogger<AnnualReminderPollingAgent>();
        }

        public void PollforSendingAnnualReminders()
        {
            var notificationTypes = _notificationTypeRepository.GetAll();

            var annualNotificationIsActive =
                notificationTypes.Where(
                    nt =>
                    (nt.NotificationTypeAlias == NotificationTypeAlias.ThirtyDaysFromAnnualAnniversaryEmailer
                     || nt.NotificationTypeAlias == NotificationTypeAlias.OneWeekAfter30DayReminder
                     || nt.NotificationTypeAlias == NotificationTypeAlias.TwoWeekAfter30DayReminder
                     || nt.NotificationTypeAlias == NotificationTypeAlias.OnOneYearAnniversaryDate)
                    && nt.IsActive).Any();

            if (!annualNotificationIsActive)
                return;

            var annualdate = DateTime.Now.Date.AddYears(-1);
            var todayDate = DateTime.Now.Date;
            var daysBeforeAnnualDate = _settings.DaysBeforeAnnualDate;
            var maxNumberOfRecordsToFetch = _settings.MaxNumberOfRecordsToFetch;
            var showNoOfRecords = _settings.ShowNoOfRecords;

            var checkOutUrl = _settings.CheckOutUrl;
            var annualReminderPhoneTollFree = _settings.AnnualReminderPhoneTollFree;

            var sourceCode = string.Empty;

            var mailerMessage = "30-Days from Annual Anniversary Emailer";
            var customers = _customerRepository.GetCustomerForAnnualNotification(annualdate, daysBeforeAnnualDate);
            SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, sourceCode, checkOutUrl, annualReminderPhoneTollFree, NotificationTypeAlias.ThirtyDaysFromAnnualAnniversaryEmailer, EmailTemplateAlias.ThirtyDaysFromAnnualAnniversaryEmailer);


            mailerMessage = "1 Week After 30-day Reminder";
            customers = _customerRepository.GetCustomerForAnnualNotification(annualdate, daysBeforeAnnualDate - 7);
            SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, sourceCode, checkOutUrl, annualReminderPhoneTollFree, NotificationTypeAlias.OneWeekAfter30DayReminder, EmailTemplateAlias.OneWeekAfter30DayReminder);


            mailerMessage = "2 Weeks After 30 Day Reminder";
            customers = _customerRepository.GetCustomerForAnnualNotification(annualdate, daysBeforeAnnualDate - 14);
            SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, sourceCode, checkOutUrl, annualReminderPhoneTollFree, NotificationTypeAlias.TwoWeekAfter30DayReminder, EmailTemplateAlias.TwoWeekAfter30DayReminder);


            mailerMessage = "On One-Year Anniversary Date";
            customers = _customerRepository.GetCustomerForAnnualNotification(annualdate, 0);
            SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, sourceCode, checkOutUrl, annualReminderPhoneTollFree, NotificationTypeAlias.OnOneYearAnniversaryDate, EmailTemplateAlias.OnOneYearAnniversaryDate);
        }

        private void SendMail(IEnumerable<Customer> customers, string mailerMessage, DateTime todayDate, int maxNumberOfRecordsToFetch, int showNoOfRecords, string sourceCode, string checkOutUrl, string annualReminderPhoneTollFree,
            string notificationType, string emailTemplateType)
        {
            if (customers.IsNullOrEmpty())
            {
                _logger.Info(string.Format("No customer found for {0} on {1}", mailerMessage, todayDate.ToShortDateString()));
                _logger.Info("\n");

            }
            else
            {
                foreach (var customer in customers)
                {
                    try
                    {
                        if ((customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail)) || !customer.EnableEmail)
                            continue;

                        var annualReminderNotificationModel = GetAnnualReminderNotificationModel(todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, sourceCode, checkOutUrl, customer, annualReminderPhoneTollFree, mailerMessage);
                        if (annualReminderNotificationModel == null)
                            continue;

                        _notifier.NotifySubscribersViaEmail(notificationType, emailTemplateType, annualReminderNotificationModel, customer.Id, customer.CustomerId, mailerMessage);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                    }
                }
            }
        }

        private AnnualReminderNotificationViewModel GetAnnualReminderNotificationModel(DateTime todayDate, int maxNumberofRecordstoFetch, int showNoOfRecords, string sourceCode, string checkOutUrl, Customer customer,
            string annualReminderPhoneTollFree, string message)
        {
            int totalEvents;
            var model = GetEvents(customer.Address.ZipCode.Zip, maxNumberofRecordstoFetch, out totalEvents);
            if (totalEvents == 0)
            {
                _logger.Info(string.Format("No event found for {0} on {1} for zip {2} for Customer [Id: {3}]", message, todayDate.ToShortDateString(), customer.Address.ZipCode.Zip, customer.CustomerId));
                _logger.Info("\n");
                return null;
            }

            var events = model.Events.Where(e => e.AvailableSlots > 0).Select(e => e).ToArray().Take(showNoOfRecords);

            if (events.IsNullOrEmpty())
            {
                _logger.Info(string.Format("Event found but no available slot for {0} on {1} for zip {2} for Customer [Id: {3}]", message, todayDate.ToShortDateString(), customer.Address.ZipCode.Zip, customer.CustomerId));
                _logger.Info("\n");
                return null;
            }
            checkOutUrl = checkOutUrl + "?Radius=50&ZipCode=" + customer.Address.ZipCode.Zip;
            return _emailNotificationModelsFactory.GetAnnualReminderNotificationViewModel(customer, sourceCode, checkOutUrl, annualReminderPhoneTollFree, events);
        }

        private OnlineSchedulingEventListModel GetEvents(string zipCode, int maxNumberofRecordstoFetch, out int totalRecords)
        {

            var filter = new OnlineSchedulingEventListModelFilter
                             {
                                 DateFrom = DateTime.Now.Date.AddDays(1),
                                 DateTo = DateTime.Now.Date.AddDays(30),
                                 ZipCode = zipCode,
                                 Radius = 50
                             };
            return _eventService.GetOnlineSchedulingEventCollection(filter, SortOrderBy.Distance, SortOrderType.Ascending, maxNumberofRecordstoFetch, 1, maxNumberofRecordstoFetch, out totalRecords);
        }
    }
}
