
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
    public class KynFirstNotificationPollingAgent : IKynFirstNotificationPollingAgent
    {
        private readonly ILogger _logger;

        private readonly INotifier _notifier;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        private readonly int _daysAfterRegistration;

        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IKynNotificationService _kynNotificationService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;


        public KynFirstNotificationPollingAgent(ISettings settings, ILogManager logManager, INotifier notifier, INotificationTypeRepository notificationTypeRepository,
            IEventCustomerRepository eventCustomerRepository, IKynNotificationService kynNotificationService, ICorporateAccountRepository corporateAccountRepository)
        {
            _logger = logManager.GetLogger<KynFirstNotificationPollingAgent>();

            _notifier = notifier;
            _notificationTypeRepository = notificationTypeRepository;

            _daysAfterRegistration = settings.DaysAfterRegistrationKynFirstNotification;

            _eventCustomerRepository = eventCustomerRepository;
            _kynNotificationService = kynNotificationService;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public void PollforKynNotification()
        {
            var notificationTypes = _notificationTypeRepository.GetAll();

            var notificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.KynFirstNotification) && nt.IsActive);

            if (!notificationIsActive)
                return;

            const int pageSize = 50;
            int pageNumber = 1;

            while (true)
            {
                long totalRecords;

                var eventCustomers = _eventCustomerRepository.GetEventCustomersForKynFirstNotification(_daysAfterRegistration, pageNumber, pageSize, out totalRecords);

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
                            _logger.Info(string.Format("Sending First Kyn Notification for Customer [Id:{0}] and Event[Id:{1}]  ", eventCustomer.CustomerId, eventCustomer.EventId));
                            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.KynFirstNotification, EmailTemplateAlias.KynFirstNotification, notificationModel, notificationModel.UserId, eventCustomer.CustomerId, "Kyn First Notification");
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
