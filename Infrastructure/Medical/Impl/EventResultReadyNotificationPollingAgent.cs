using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class EventResultReadyNotificationPollingAgent : IEventResultReadyNotificationPollingAgent
    {
        private readonly ILogger _logger;

        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventNotificationRepository _eventNotificationRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IEventService _eventService;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;


        public EventResultReadyNotificationPollingAgent(ILogManager logManager, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotificationTypeRepository notificationTypeRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, IHospitalPartnerRepository hospitalPartnerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IEventNotificationRepository eventNotificationRepository, IUserRepository<User> userRepository, IEventService eventService, IHospitalFacilityRepository hospitalFacilityRepository,
            ICorporateAccountRepository corporateAccountRepository)
        {
            _logger = logManager.GetLogger<EventResultReadyNotificationPollingAgent>();

            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notificationTypeRepository = notificationTypeRepository;

            _eventCustomerResultRepository = eventCustomerResultRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventNotificationRepository = eventNotificationRepository;
            _userRepository = userRepository;
            _eventService = eventService;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public void PollforEventResultReadyNotification()
        {
            var notificationTypes = _notificationTypeRepository.GetAll();

            var notificationIsActive = notificationTypes.Any(nt => (nt.NotificationTypeAlias == NotificationTypeAlias.EventResultReadyNotification) && nt.IsActive);

            if (!notificationIsActive)
                return;

            var eventIds = _eventCustomerResultRepository.GetEventIdsForEventResultReadyNotiFication().ToArray();
            if (eventIds.Count() == 0)
                return;

            var createdByOrgRoleUserId = _organizationRoleUserRepository.GetOrganizationRoleUserIdsForRole((long)Roles.FranchisorAdmin).First();

            foreach (var eventId in eventIds)
            {
                try
                {
                    var notificationSent = _eventNotificationRepository.GetByEventId(eventId, NotificationTypeAlias.EventResultReadyNotification);
                    if (notificationSent != null)
                        continue;

                    var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
                    if (hospitalPartnerId >= 1)
                    {
                        var partnerReleaseSinged = _eventCustomerResultRepository.CheckAnyCustomerResultsReadyAndSignedPartnerRelease(eventId);
                        if (partnerReleaseSinged)
                        {
                            var allResultsReady = _eventCustomerResultRepository.CheckAllCustomerResultsReadyForEvent(eventId);

                            if (!allResultsReady)
                            {
                                _logger.Info(string.Format("All Results are not ready For Event Id {0}", eventId));
                            }

                            var orgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationId(hospitalPartnerId);
                            var hospitalFacilityIds = _hospitalFacilityRepository.GetSelectedHospitalFacilityIdForEvent(eventId);
                            if (hospitalFacilityIds != null && hospitalFacilityIds.Any())
                            {
                                foreach (var hospitalFacilityId in hospitalFacilityIds)
                                {
                                    var hospitalFacilityOrgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationId(hospitalFacilityId);
                                    if (hospitalFacilityOrgRoleUsers != null && hospitalFacilityOrgRoleUsers.Any())
                                        orgRoleUsers = orgRoleUsers.Concat(hospitalFacilityOrgRoleUsers);
                                }
                            }
                            var userIds = orgRoleUsers.Select(oru => oru.UserId).ToList();

                            var users = _userRepository.GetUsers(userIds);
                            var eventHostViewData = _eventService.GetById(eventId);

                            foreach (var user in users)
                            {
                                if (user.Email == null || string.IsNullOrEmpty(user.Email.ToString()))
                                    continue;

                                var model = _emailNotificationModelsFactory.GetEventResultReadyNotificationViewModel(user, eventHostViewData);
                                var notifications = _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EventResultReadyNotification, EmailTemplateAlias.EventResultReadyNotification, model, new string[] { user.Email.ToString() }, user.Id, createdByOrgRoleUserId, "Event Result Ready Notification");
                                if (notifications != null && notifications.Any())
                                {
                                    var eventNotification = new EventNotification { EventId = eventId, NotificationId = notifications.First().Id };
                                    _eventNotificationRepository.Save(eventNotification);
                                }
                            }
                        }
                        
                    }

                    //var account = _corporateAccountRepository.GetbyEventId(eventId);
                    //if (account != null && account.Id > 0 && account.SendEventResultReadyNotification)
                    //{
                    //    var orgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationIdAndRoleId(account.Id, (long)Roles.CorporateAccountCoordinator);

                    //    var userIds = orgRoleUsers.Select(oru => oru.UserId).ToList();

                    //    var users = _userRepository.GetUsers(userIds);
                    //    var eventHostViewData = _eventService.GetById(eventId);

                    //    foreach (var user in users)
                    //    {
                    //        if (user.Email == null || string.IsNullOrEmpty(user.Email.ToString()))
                    //            continue;

                    //        var model = _emailNotificationModelsFactory.GetEventResultReadyNotificationViewModel(user, eventHostViewData);
                    //        var notifications = _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EventResultReadyNotification, EmailTemplateAlias.EventResultReadyNotification, model, new string[] { user.Email.ToString() }, user.Id, createdByOrgRoleUserId, "Event Result Ready Notification");
                    //        if (notifications != null && notifications.Any())
                    //        {
                    //            var eventNotification = new EventNotification { EventId = eventId, NotificationId = notifications.First().Id };
                    //            _eventNotificationRepository.Save(eventNotification);
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Event Result Ready Notification Error For Event Id {0} \nMessage:{1} \nStackTrace: {2}", eventId, ex.Message, ex.StackTrace));
                }
            }
        } 
    }
}
