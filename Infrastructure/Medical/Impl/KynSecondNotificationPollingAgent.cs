using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynSecondNotificationPollingAgent : IKynSecondNotificationPollingAgent
    {
        private readonly ILogger _logger;

        private readonly INotifier _notifier;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        private readonly int _hoursBeforeKynSecondNotification;
        private readonly int _intervalKynSecondNotification;

        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IKynNotificationService _kynNotificationService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public KynSecondNotificationPollingAgent(ISettings settings, ILogManager logManager, INotifier notifier, INotificationTypeRepository notificationTypeRepository,
            IEventCustomerRepository eventCustomerRepository, IKynNotificationService kynNotificationService, ICorporateAccountRepository corporateAccountRepository)
        {
            _logger = logManager.GetLogger<KynSecondNotificationPollingAgent>();

            _notifier = notifier;
            _notificationTypeRepository = notificationTypeRepository;

            _hoursBeforeKynSecondNotification = settings.HoursBeforeKynSecondNotification;
            _intervalKynSecondNotification = settings.IntervalKynSecondNotification;

            _eventCustomerRepository = eventCustomerRepository;
            _kynNotificationService = kynNotificationService;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public void PollforKynNotification()
        {
            var notificationTypes = _notificationTypeRepository.GetAll();

            var notificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.KynSecondNotification) && nt.IsActive);

            if (!notificationIsActive)
                return;

            const int pageSize = 50;
            int pageNumber = 1;

            while (true)
            {
                long totalRecords;

                var eventCustomers = _eventCustomerRepository.GetEventCustomersForKynSecondNotification(_hoursBeforeKynSecondNotification,_intervalKynSecondNotification, pageNumber, pageSize, out totalRecords);

                if (eventCustomers == null || !eventCustomers.Any())
                {
                    _logger.Info("No Customers Found!");
                    break;
                }

                foreach (var eventCustomer in eventCustomers)
                {
                    try
                    {
                        var corporateAccount = _corporateAccountRepository.GetbyEventId(eventCustomer.EventId);
                        if (corporateAccount != null && !corporateAccount.AllowCustomerPortalLogin)
                            continue;

                        var notificationModel = _kynNotificationService.IsApplicableForNotification(eventCustomer);
                        if (notificationModel != null)
                        {
                            _logger.Info(string.Format("Sending Second Kyn Notification for Customer [Id:{0}] and Event[Id:{1}]  ", eventCustomer.CustomerId, eventCustomer.EventId));
                            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.KynSecondNotification, EmailTemplateAlias.KynSecondNotification, notificationModel, notificationModel.UserId, eventCustomer.CustomerId, "Kyn Second Notification");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Message:{0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                    }

                }
                if ((pageNumber * pageSize) >= totalRecords)
                    break;

                pageNumber++;
            }
        }
    }
}
