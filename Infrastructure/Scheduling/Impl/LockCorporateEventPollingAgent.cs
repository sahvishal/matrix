using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class LockCorporateEventPollingAgent : ILockCorporateEventPollingAgent
    {
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IUserRepository<User> _userRepository;
        private readonly IEventService _eventService;

        public LockCorporateEventPollingAgent(ILogManager logManager, ISettings settings, IEventRepository eventRepository, ICorporateAccountRepository corporateAccountRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, INotifier notifier, IEmailNotificationModelsFactory emailNotificationModelsFactory, IUserRepository<User> userRepository, IEventService eventService)
        {
            _logger = logManager.GetLogger("LockCorporateEvent");
            _settings = settings;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _userRepository = userRepository;
            _eventService = eventService;
        }

        public void PollForLockCorporateEvent()
        {
            try
            {
                var corporateAccounts = _corporateAccountRepository.GetCorporateAccountForLockEvent();
                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("No corporate account has been set for lock event.");
                    return;
                }
                
                var createdByOrgRoleUserId = _organizationRoleUserRepository.GetOrganizationRoleUserIdsForRole((long)Roles.FranchisorAdmin).First();

                foreach (var corporateAccount in corporateAccounts)
                {
                    try
                    {
                        if(!corporateAccount.EventLockDaysCount.HasValue)
                            continue;
                        var eventDate = DateTime.Now.AddDays(corporateAccount.EventLockDaysCount.Value).Date;
                        var eventIds = _eventRepository.LockCorporateEvents(corporateAccount.Id, eventDate);
                        if (eventIds != null && eventIds.Any())
                        {
                            foreach (var eventId in eventIds)
                            {
                                _logger.Info(string.Format("Events locked for Corporate: {0} and EventId : {1}", corporateAccount.Tag, eventId));
                            }

                            var orgRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsersByOrganizationIdAndRoleId(corporateAccount.Id, (long)Roles.CorporateAccountCoordinator);
                            if (orgRoleUsers != null && orgRoleUsers.Any())
                            {
                                var userIds = orgRoleUsers.Select(oru => oru.UserId).ToList();

                                var users = _userRepository.GetUsers(userIds);
                                foreach (var eventId in eventIds)
                                {
                                    var eventHostViewData = _eventService.GetById(eventId);
                                    foreach (var user in users)
                                    {
                                        if (user.Email == null || string.IsNullOrEmpty(user.Email.ToString()))
                                            continue;

                                        var model = _emailNotificationModelsFactory.GetEventLockedNotificationViewModel(user, eventHostViewData);
                                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EventLocked, EmailTemplateAlias.EventLocked, model, new string[] { user.Email.ToString() }, user.Id, createdByOrgRoleUserId, "Event Lock Notification");
                                    }
                                }
                                
                            }
                            else
                            {
                                _logger.Info("No Nurse Practitioner Pr for Corporate: " + corporateAccount.Tag);
                            }
                            

                        }
                        else
                            _logger.Info("No Events locked for Corporate: " + corporateAccount.Tag);


                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error while locking events for corporate {0}. Messsage: {1} \n StackTrace {2}", corporateAccount.Tag, ex.Message, ex.StackTrace));
                    }


                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while polling events for corporate. Messsage: {0} \n StackTrace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
