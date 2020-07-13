using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Service
{

    public sealed class UserLoginService : IUserLoginService
    {
        public event UserLoginLocked OnLoginAccountLocked;

        public event UserLoginValidation OnLoginSuccessful;

        public event UserLoginValidation OnLoginUnuccessful;

        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserSessionModelFactory _userSessionModelFactory;

        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPasswordChangelogService _passwordChangelogService;
        private readonly IUniqueItemRepository<UserLoginLog> _uniqueItemRepository;
        private readonly ISingleSessionHelper _singleSessionHelper;
        private readonly IUserLoginLogRepository _userLoginLogRepository;
        private readonly ISettings _setting;

        public UserLoginService(IUserLoginRepository userLoginRepository, IUserRepository<User> userRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IUniqueItemRepository<File> fileRepository,
                                    IMediaRepository mediaRepository, IRoleRepository roleRepository, IOrganizationRepository organizationRepository, IUserSessionModelFactory userSessionModelFactory,
                                IPasswordChangelogService passwordChangelogService, IUniqueItemRepository<UserLoginLog> uniqueItemRepository, ISingleSessionHelper singleSessionHelper, IUserLoginLogRepository userLoginLogRepository,
                                ISettings setting)
        {
            OnLoginSuccessful += UpdateLogin;
            OnLoginUnuccessful += UpdateLogin;

            _userLoginRepository = userLoginRepository;
            _userRepository = userRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _roleRepository = roleRepository;
            _userSessionModelFactory = userSessionModelFactory;
            _organizationRepository = organizationRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _passwordChangelogService = passwordChangelogService;
            _uniqueItemRepository = uniqueItemRepository;
            _singleSessionHelper = singleSessionHelper;
            _userLoginLogRepository = userLoginLogRepository;
            _setting = setting;
        }


        //public UserLoginService()
        //    : this(new UserLoginRepository(), new UserRepository<User>(), new OrganizationRoleUserRepository(), )
        //{ }

        public void ValidateUser(string userName, string password)
        {
            try
            {
                var userLogin = _userLoginRepository.GetByUserName(userName);

                if (userLogin != null && userLogin.Locked && userLogin.LastLoginAttemptAt.HasValue && userLogin.LastLoginAttemptAt.Value.AddMinutes(60) > DateTime.Now && OnLoginAccountLocked != null)
                    OnLoginAccountLocked();

                if (userLogin != null && userLogin.Password == password && OnLoginSuccessful != null)
                    OnLoginSuccessful(userLogin.Id, true);
                if ((userLogin == null || userLogin.Password != password) && OnLoginUnuccessful != null)
                    OnLoginUnuccessful(userLogin != null ? userLogin.Id : 0, false);
            }
            catch (Exception)
            {
                if (OnLoginUnuccessful != null)
                    OnLoginUnuccessful(0, false);
            }
        }

        public UserSessionModel GetUserSessionModel(string userName)
        {
            var user = _userRepository.GetUser(_userLoginRepository.GetByUserName(userName).Id);
            var orgRoles = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(user.Id);
            var orgs = _organizationRepository.GetAllOrganizationsforUser(user.Id);
            var files = orgs.Where(o => o.LogoImageId > 0).Select(o => _fileRepository.GetById(o.LogoImageId)).ToArray();
            var mediaLocation = _mediaRepository.GetOrganizationLogoImageFolderLocation();

            var roles = _roleRepository.GetAll();
            return _userSessionModelFactory.Create(user, orgRoles, orgs, roles, files, mediaLocation);

        }

        public UserSessionModel GetUserSessionModel(long userId)
        {
            var user = _userRepository.GetUser(userId);
            var orgRoles = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(user.Id);
            var orgs = _organizationRepository.GetAllOrganizationsforUser(user.Id);
            var files = orgs.Where(o => o.LogoImageId > 0).Select(o => _fileRepository.GetById(o.LogoImageId)).ToArray();
            var mediaLocation = _mediaRepository.GetOrganizationLogoImageFolderLocation();

            var roles = _roleRepository.GetAll();
            return _userSessionModelFactory.Create(user, orgRoles, orgs, roles, files, mediaLocation);

        }

        public UserSessionModel SwitchOrganizationRole(UserSessionModel currentUserSession, long switchToRoleId, long switchToOrganizationId)
        {
            var userSession = currentUserSession;
            userSession.CurrentOrganizationRole =
                currentUserSession.AvailableOrganizationRoles.Where(
                    ar => ar.RoleId == switchToRoleId && ar.OrganizationId == switchToOrganizationId).First();

            return userSession;
        }


        private void UpdateLogin(long userLoginId, bool isSuccessful)
        {
            if (userLoginId > 0)
                _userLoginRepository.UpdateLoginStatus(userLoginId, isSuccessful);
        }

        public bool ForceChangePassword(long userLoginId, string password, bool forceChangePassword, long orgRoleUserId, bool updatePasswordLog)
        {
            var securehash = _userLoginRepository.ForceChangePassword(userLoginId, password, forceChangePassword);

            if (securehash != null && updatePasswordLog)
            {
                _passwordChangelogService.Update(userLoginId, securehash, orgRoleUserId);
            }
            return securehash != null;
        }

        public bool ResetPassword(long userLoginId, string password, bool userVerified, long orgRoleUserId, bool updatePasswordLog)
        {
            var securehash = _userLoginRepository.ResetPassword(userLoginId, password, userVerified);

            if (securehash != null && updatePasswordLog)
            {
                _passwordChangelogService.Update(userLoginId, securehash, orgRoleUserId);
            }
            return securehash != null;
        }

        public UserLoginLog SaveLoginInfo(long userId, string userName, string browserSessionId, string browserName, string sessionIp, Uri refferedUrl)
        {
            var userLoginLog = new UserLoginLog
            {
                UserId = userId,
                LogInDateTime = DateTime.Now,
                BrowserSession = browserSessionId,
                BrowserName = browserName,
                SessionIP = sessionIp,
                RefferedUrl = refferedUrl
            };

            _singleSessionHelper.CreateAndStoreSessionToken(userName, browserSessionId);

            return _uniqueItemRepository.Save(userLoginLog);
        }

        public UserLoginLog GetLatestUserLogin(long userId)
        {
            //pick latest login and see if login is not more than configurable time

            var loginLog = _userLoginLogRepository.GetCurrentLoggedInLogforUser(userId);

            if (loginLog == null || loginLog.LogInDateTime < DateTime.Now.AddHours(-_setting.MedicareSessionValidityDuration))
                return null;

            return loginLog;
        }

    }
}
