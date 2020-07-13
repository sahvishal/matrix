using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CorporateEventResultReadyNotificationPollingAgent : ICorporateEventResultReadyNotificationPollingAgent
    {
        private readonly ILogger _logger;

        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;

        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventNotificationRepository _eventNotificationRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IEventService _eventService;

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly DateTime? _cutofDate;

        public CorporateEventResultReadyNotificationPollingAgent(ILogManager logManager, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotificationTypeRepository notificationTypeRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IEventNotificationRepository eventNotificationRepository,
            IUserRepository<User> userRepository, IEventService eventService, ICorporateAccountRepository corporateAccountRepository, ISettings settings)
        {
            _logger = logManager.GetLogger<EventResultReadyNotificationPollingAgent>();

            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notificationTypeRepository = notificationTypeRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventNotificationRepository = eventNotificationRepository;
            _userRepository = userRepository;
            _eventService = eventService;
            _cutofDate = settings.CorporateEventResultReadyCutoffDate;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public void PollforEventResultReadyNotification()
        {
            var notificationTypes = _notificationTypeRepository.GetAll();

            var notificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.EventResultReadyNotification) && nt.IsActive);

            if (!notificationIsActive)
                return;

            if (!_cutofDate.HasValue)
            {
                _logger.Info("Please provide cut of date to sent Corporate Event Result Ready Notification");
                return;
            }

            var eventIds = _eventCustomerResultRepository.GetEventIdsForCorporateAccountEventResultReadyNotiFication(_cutofDate.Value).ToArray();

            if (eventIds.Count() == 0)
            {
                _logger.Info("No Corporate Event found for sending Result Ready notification");
                return;
            }

            var createdByOrgRoleUserId = _organizationRoleUserRepository.GetOrganizationRoleUserIdsForRole((long)Roles.FranchisorAdmin).First();

            foreach (var eventId in eventIds)
            {
                try
                {
                    var notificationSent = _eventNotificationRepository.GetByEventId(eventId, NotificationTypeAlias.EventResultReadyNotification);
                    if (notificationSent != null && notificationSent.IsForCorporateAccount)
                        continue;

                    var account = _corporateAccountRepository.GetbyEventId(eventId);
                    if (account != null && account.SendEventResultReadyNotification)
                    {
                        var orgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationIdAndRoleId(account.Id, (long)Roles.CorporateAccountCoordinator);

                        if (!orgRoleUsers.IsNullOrEmpty())
                        {
                            var userIds = orgRoleUsers.Select(oru => oru.UserId).ToList();

                            var users = _userRepository.GetUsers(userIds);
                            var eventHostViewData = _eventService.GetById(eventId);

                            foreach (var user in users)
                            {
                                if (user.Email == null || string.IsNullOrEmpty(user.Email.ToString()))
                                    continue;

                                var model =
                                    _emailNotificationModelsFactory.GetEventResultReadyNotificationViewModel(user,
                                        eventHostViewData);
                                var notifications =
                                    _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EventResultReadyNotification, EmailTemplateAlias.EventResultReadyNotification, model, new string[] { user.Email.ToString() }, user.Id, createdByOrgRoleUserId,
                                        "Event Result Ready Notification");

                                if (notifications != null && notifications.Any())
                                {
                                    var eventNotification = new EventNotification
                                    {
                                        EventId = eventId,
                                        NotificationId = notifications.First().Id,
                                        IsForCorporateAccount = true
                                    };
                                    _eventNotificationRepository.SaveForCorporateAccount(eventNotification);
                                }
                            }
                        }
                        else
                        {
                            _logger.Info(string.Format("No coordinator Attached to Event For Account {0}  is Off", account.Id));
                        }

                    }
                    else
                    {
                        _logger.Info(string.Format("Send Event Result Ready Notification For Account {0}  is Off", account.Id));
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Corporat Event Result Ready Notification Error For Event Id {0} \nMessage:{1} \nStackTrace: {2}", eventId, ex.Message, ex.StackTrace));
                }
            }
        }
    }
}