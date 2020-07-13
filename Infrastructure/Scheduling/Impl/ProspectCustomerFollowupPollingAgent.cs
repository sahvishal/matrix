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
using Falcon.App.Core.Marketing.Domain;
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
    public class ProspectCustomerFollowupPollingAgent : IProspectCustomerFollowupPollingAgent
    {
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IEventService _eventService;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ISettings _settings;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationRepository _notificationRepository;


        private readonly ILogger _logger;

        public ProspectCustomerFollowupPollingAgent(IProspectCustomerRepository prospectCustomerRepository, IEventService eventService, IEmailNotificationModelsFactory emailNotificationModelsFactory,
            INotifier notifier, ISettings settings, INotificationTypeRepository notificationTypeRepository, ILogManager logManager, ICustomerRepository customerRepository, INotificationRepository notificationRepository)
        {
            _prospectCustomerRepository = prospectCustomerRepository;
            _eventService = eventService;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _settings = settings;
            _notificationTypeRepository = notificationTypeRepository;
            _customerRepository = customerRepository;
            _notificationRepository = notificationRepository;
            _logger = logManager.GetLogger<ProspectCustomerFollowupPollingAgent>();
        }

        public void PollForSendingProspectCustomerReminders()
        {
            try
            {
                var notificationTypes = _notificationTypeRepository.GetAll();

                var notificationIsActive =
                    notificationTypes.Where(
                        nt =>
                        (nt.NotificationTypeAlias == NotificationTypeAlias.OneDayAfterProspectCreationFollowup
                         || nt.NotificationTypeAlias == NotificationTypeAlias.TwoWeekAfterProspectCreationFollowup
                         || nt.NotificationTypeAlias == NotificationTypeAlias.ThreeWeekAfterProspectCreationFollowup
                         || nt.NotificationTypeAlias == NotificationTypeAlias.FourWeekAfterProspectCreationFollowup
                         || nt.NotificationTypeAlias == NotificationTypeAlias.FiveWeekAfterProspectCreationFollowup
                         || nt.NotificationTypeAlias == NotificationTypeAlias.SixWeekAfterProspectCreationFollowup
                         || nt.NotificationTypeAlias == NotificationTypeAlias.SevenWeekAfterProspectCreationFollowup)
                        && nt.IsActive).Any();

                if (!notificationIsActive)
                    return;

                var todayDate = DateTime.Now.Date;
                var maxNumberOfRecordsToFetch = _settings.MaxNumberOfRecordsToFetch;
                var showNoOfRecords = _settings.ShowNoOfRecords;
                var checkOutUrl = _settings.CheckOutUrl;

                var mailerMessage = "OneDayAfterProspectCreationFollowup";
                var customers = _prospectCustomerRepository.GetProspectCustomersForReminder(1);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.OneDayAfterProspectCreationFollowup, EmailTemplateAlias.OneDayAfterProspectCreationFollowup);

                mailerMessage = "OneWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(8);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.OneWeekAfterProspectCreationFollowup, EmailTemplateAlias.OneWeekAfterProspectCreationFollowup);

                mailerMessage = "TwoWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(15);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.TwoWeekAfterProspectCreationFollowup, EmailTemplateAlias.TwoWeekAfterProspectCreationFollowup);

                mailerMessage = "ThreeWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(22);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.ThreeWeekAfterProspectCreationFollowup, EmailTemplateAlias.ThreeWeekAfterProspectCreationFollowup);

                mailerMessage = "FourWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(29);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.FourWeekAfterProspectCreationFollowup, EmailTemplateAlias.FourWeekAfterProspectCreationFollowup);

                mailerMessage = "FiveWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(36);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.FiveWeekAfterProspectCreationFollowup, EmailTemplateAlias.FiveWeekAfterProspectCreationFollowup);

                mailerMessage = "SixWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(43);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.SixWeekAfterProspectCreationFollowup, EmailTemplateAlias.SixWeekAfterProspectCreationFollowup);

                mailerMessage = "SevenWeekAfterProspectCreationFollowup";
                customers = _prospectCustomerRepository.GetProspectCustomersForReminder(50);
                SendMail(customers, mailerMessage, todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, NotificationTypeAlias.SevenWeekAfterProspectCreationFollowup, EmailTemplateAlias.SevenWeekAfterProspectCreationFollowup);
            }
            catch (Exception ex)
            {
                _logger.Error("Message:" + ex.Message);
                _logger.Error("StackTrace:" + ex.StackTrace);
            }

        }

        private void SendMail(IEnumerable<ProspectCustomer> prospectCustomers, string mailerMessage, DateTime todayDate, int maxNumberOfRecordsToFetch, int showNoOfRecords, string checkOutUrl, string notificationType, string emailTemplateType)
        {
            if (prospectCustomers.IsNullOrEmpty())
            {
                _logger.Info(string.Format("No prospect customer found for {0} on {1}", mailerMessage, todayDate.ToShortDateString()));
                _logger.Info("\n");

            }
            else
            {
                foreach (var prospectCustomer in prospectCustomers)
                {
                    try
                    {
                        Customer customer = null;
                        if (prospectCustomer.CustomerId.HasValue && prospectCustomer.CustomerId.Value > 0)
                        {
                            customer = _customerRepository.GetCustomer(prospectCustomer.CustomerId.Value);

                            //if (customer.DoNotContactReasonId.HasValue && customer.DoNotContactReasonId.Value > 0)
                            //    continue;
                            if ((customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail)) || !customer.EnableEmail)
                                continue;
                        }
                        var prospectCustomerFollowup = GetProspectCustomerFollowupNotificationModel(todayDate, maxNumberOfRecordsToFetch, showNoOfRecords, checkOutUrl, prospectCustomer, mailerMessage);
                        if (prospectCustomerFollowup == null)
                            continue;

                        if (customer != null)
                            _notifier.NotifySubscribersViaEmail(notificationType, emailTemplateType, prospectCustomerFollowup, customer.Id, customer.CustomerId, mailerMessage);
                        else
                        {
                            var notifications = _notifier.NotifySubscribersViaEmail(notificationType, emailTemplateType, prospectCustomerFollowup, new[] { prospectCustomer.Email.ToString() }, 0, 1, mailerMessage);
                            if (notifications != null && notifications.Any())
                                _notificationRepository.SaveProspectCustomerNotification(prospectCustomer.Id, notifications.First().Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                    }
                }
            }
        }

        private ProspectCustomerFollowupNotificationViewModel GetProspectCustomerFollowupNotificationModel(DateTime todayDate, int maxNumberofRecordstoFetch, int showNoOfRecords, string checkOutUrl, ProspectCustomer prospectCustomer, string message)
        {
            int totalEvents;
            var model = GetEvents(prospectCustomer.Address.ZipCode.Zip, maxNumberofRecordstoFetch, out totalEvents);
            if (totalEvents == 0)
            {
                _logger.Info(string.Format("No event found for {0} on {1} for zip {2} for Prospect Customer [Id: {3}]", message, todayDate.ToShortDateString(), prospectCustomer.Address.ZipCode.Zip, prospectCustomer.Id));
                _logger.Info("\n");
                return null;
            }

            var events = model.Events.Where(e => e.AvailableSlots > 0).Select(e => e).ToArray().Take(showNoOfRecords);

            if (events.IsNullOrEmpty())
            {
                _logger.Info(string.Format("Event found but no available slot for {0} on {1} for zip {2} for Prospect Customer [Id: {3}]", message, todayDate.ToShortDateString(), prospectCustomer.Address.ZipCode.Zip, prospectCustomer.Id));
                _logger.Info("\n");
                return null;
            }
            checkOutUrl = checkOutUrl + "?Radius=50&ZipCode=" + prospectCustomer.Address.ZipCode.Zip;
            return _emailNotificationModelsFactory.GetProspectCustomerFollowupNotificationViewModel(prospectCustomer.FirstName + " " + prospectCustomer.LastName, checkOutUrl, events);
        }

        private OnlineSchedulingEventListModel GetEvents(string zipCode, int maxNumberofRecordstoFetch, out int totalRecords)
        {

            var filter = new OnlineSchedulingEventListModelFilter
            {
                DateFrom = DateTime.Now.Date.AddDays(1),
                //DateTo = DateTime.Now.Date.AddDays(30),
                ZipCode = zipCode,
                Radius = 25
            };
            return _eventService.GetOnlineSchedulingEventCollection(filter, SortOrderBy.Distance, SortOrderType.Ascending, maxNumberofRecordstoFetch, 1, maxNumberofRecordstoFetch, out totalRecords);
        }
    }
}
