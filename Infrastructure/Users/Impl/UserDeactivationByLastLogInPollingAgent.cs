using System;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class UserDeactivationByLastLogInPollingAgent : IUserDeactivationByLastLogInPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IUserRepository<User> _userRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        private readonly int _lastLoggedInBeforeDays;

        public UserDeactivationByLastLogInPollingAgent(ILogManager logManager, IUserRepository<User> userRepository, IUserLoginRepository userLoginRepository, ISettings settings, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _logger = logManager.GetLogger("UserDeactivationByLastLogInPollingAgent");
            _userRepository = userRepository;
            _userLoginRepository = userLoginRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _lastLoggedInBeforeDays = settings.LastLoggedInBeforeDays;
        }

        public void PollForDeactivation()
        {
            _logger.Info("Getting users which have not logged in since past " + _lastLoggedInBeforeDays + " days.");

            var userLogins = _userLoginRepository.GetUsersNotLoggedInWithinDays(_lastLoggedInBeforeDays).OrderBy(x => x.Id);

            foreach (var userLogin in userLogins)
            {
                try
                {
                    if (userLogin.LastLogged.HasValue)
                    {
                        _logger.Info("Deactivating login for user : " + userLogin.Id + " as last log in date is " + userLogin.LastLogged.Value.ToString("M/dd/yyyy hh:mm:ss tt"));
                    }
                    else
                    _logger.Info("Deactivating login for user : " + userLogin.Id + " as user never logged in.");

                    using (var scope = new TransactionScope())
                    {
                        _userRepository.UpdateUserIsActiveStatus(userLogin.Id, false);

                        _userLoginRepository.UpdateUserLoginIsActiveStatus(userLogin.Id, false);

                        _organizationRoleUserRepository.DeactivateAllOrganizationRolesForUser(userLogin.Id);

                        scope.Complete();
                    }

                    _logger.Info("User : " + userLogin.Id + " deactivated successfully.");
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error deactivating user : {0} \nMessage : {1}\nStack Trace : {2}", userLogin.Id, ex.Message, ex.StackTrace));
                }
            }
        }
    }
}
