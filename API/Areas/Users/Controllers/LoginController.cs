using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Areas.Users.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using UserLoginModel = API.Areas.Users.Models.UserLoginModel;

namespace API.Areas.Users.Controllers
{    
    public class LoginController : ApiController
    {

        private readonly ISessionContext _sessionContext;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IUserLoginService _userLoginService;
        private readonly IUserRepository<User> _userRepository;
        private readonly IUniqueItemRepository<UserLoginLog> _uniqueItemRepository;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IPinChangeLogService _pinChangeLogService;

        private readonly ILogger _logger;

        public LoginController(ISessionContext sessionContext, IUserLoginRepository userLoginRepository, IUserLoginService userLoginService, IUserRepository<User> userRepository, IUniqueItemRepository<UserLoginLog> uniqueItemRepository,
            ILogManager logManager, ITechnicianRepository technicianRepository, IConfigurationSettingRepository configurationSettingRepository, IPinChangeLogService pinChangeLogService)
        {

            _sessionContext = sessionContext;
            _userLoginRepository = userLoginRepository;
            _userLoginService = userLoginService;
            _userRepository = userRepository;
            _uniqueItemRepository = uniqueItemRepository;
            _technicianRepository = technicianRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _pinChangeLogService = pinChangeLogService;
            _logger = logManager.GetLogger<LoginController>();
        }

        [AllowAnonymous]
        public MobileResponseModel Post([FromBody] UserLoginModel model)
        {
            var authenticationModel = new MobileResponseModel
            {
                IsSuccess = false
            };
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.UserName) ||
                string.IsNullOrEmpty(model.DeviceKey))
            {
                authenticationModel.Message = "UserName or Password can not be empty";
                return authenticationModel;
            }

            var isValid = _userLoginRepository.ValidateUser(model.UserName, model.Password);

            if (isValid)
            {
                try
                {
                    var userSession = _userLoginService.GetUserSessionModel(model.UserName);

                    if (userSession.CurrentOrganizationRole == null)
                    {
                        authenticationModel.Message = "Your default role has been removed. Please contact your administrator.";
                        return authenticationModel;
                    }

                    if (!userSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician) && !userSession.CurrentOrganizationRole.CheckRole((long)Roles.NursePractitioner))
                    {
                        authenticationModel.Message = "Your default role must be Technician or Nurse Practitioner. Please contact your administrator.";
                        return authenticationModel;
                    }

                    int pinExpirationDays = 0;
                    Int32.TryParse(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PinExpirationDays), out pinExpirationDays);

                    int daysBeforAlert = 0;

                    Int32.TryParse(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AlertBeforePinExpirationInDays), out daysBeforAlert);
                    var pinExpireInDays = _technicianRepository.GetPinExpireInDays(userSession.CurrentOrganizationRole.OrganizationRoleUserId, pinExpirationDays);

                    if (pinExpireInDays <= daysBeforAlert)
                    {
                        pinExpireInDays = pinExpireInDays <= 0 ? 0 : pinExpireInDays;
                    }

                    _sessionContext.UserSession = userSession;

                    var loggedInUser = _userRepository.GetUser(userSession.UserId);
                    _sessionContext.LastLoggedInTime = loggedInUser.UserLogin.LastLogged.ToString();
                    _userLoginRepository.UpdateLoginStatus(_sessionContext.UserSession.UserId, true);

                    var sessionId = Guid.NewGuid().ToString();

                    var userLoginLog = SaveLoginInfo(userSession.UserId, sessionId, model.DeviceKey);

                    _sessionContext.UserSession.UserLoginLogId = userLoginLog.Id;

                    var technicianProfile = new Technician();

                    if (_sessionContext.UserSession.AvailableOrganizationRoles.Any(x => x.RoleId == (long)Roles.Technician))
                    {
                        var technicianOrgRoleUserId = _sessionContext.UserSession.AvailableOrganizationRoles.First(x => x.RoleId == (long)Roles.Technician).OrganizationRoleUserId;
                        technicianProfile = _technicianRepository.GetTechnician(technicianOrgRoleUserId);
                    }

                    authenticationModel = new MobileResponseModel
                   {
                       IsSuccess = true,
                       Message = "Successfully Logged In",
                       StatusCode = 200,
                       Data = new AuthenticationModel
                       {
                           UserId = userSession.UserId,//Todo: need to check if OrgRoleUserID Can be Sent
                           Token = (sessionId + "_" + userLoginLog.UserId).Encrypt(),
                           Name = userSession.FullName,
                           Role = userSession.CurrentOrganizationRole.RoleDisplayName,
                           Pin = !string.IsNullOrWhiteSpace(technicianProfile.Pin) ? technicianProfile.Pin.Encrypt() : string.Empty,
                           ShowAlertBeforePinExpirationInDays = daysBeforAlert,
                           RemainingDays = pinExpireInDays,
                       }

                   };
                }
                catch (Exception exception)
                {
                    _logger.Error("while loging user" + exception.StackTrace);
                    authenticationModel.Message = "UserName or Password is not valid";

                    return authenticationModel;

                }
            }
            else
            {
                _logger.Warn("Tried to access with invalid cridential");

                authenticationModel.Message = "UserName or Password is not valid";
                return authenticationModel;

            }

            return authenticationModel;
        }

        private UserLoginLog SaveLoginInfo(long userid, string sessionId, string deviceKey)
        {
            var userLoginLog = new UserLoginLog
               {
                   UserId = userid,
                   LogInDateTime = DateTime.Now,
                   BrowserSession = sessionId,
                   BrowserName = " ",
                   SessionIP = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress,
                   DeviceKey = deviceKey,
                   RefferedUrl = Request.RequestUri
               };

            return _uniqueItemRepository.Save(userLoginLog);
        }

        [HttpPost]
        public MobileResponseModel UpdateTechnicianPin(TechnicianPinEditModel model)
        {
            var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            if (!_pinChangeLogService.IsPinRepeated(orgId, model.Pin))
            {
                _technicianRepository.UpdatePin(orgId, model.Pin);
                _pinChangeLogService.Update(model.Pin, orgId, orgId);

                int pinExpirationDays = 0;
                Int32.TryParse(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PinExpirationDays), out pinExpirationDays);

                int daysBeforAlert = 0;

                Int32.TryParse(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AlertBeforePinExpirationInDays), out daysBeforAlert);
                var pinExpireInDays = _technicianRepository.GetPinExpireInDays(orgId, pinExpirationDays);

                if (pinExpireInDays <= daysBeforAlert)
                {
                    pinExpireInDays = pinExpireInDays <= 0 ? 0 : pinExpireInDays;
                }

                return new MobileResponseModel
                {
                    IsSuccess = true,
                    Message = "Successfully Updated PIN",
                    StatusCode = 200,
                    Data = new PinUpdateResponseModel
                    {
                        ShowAlertBeforePinExpirationInDays = daysBeforAlert,
                        RemainingDays = pinExpireInDays,
                    }
                };
            }
            else
            {
                var nonRepeatCount = Convert.ToInt32(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPinNonRepetitionCount));
                return new MobileResponseModel
                {

                    IsSuccess = false,
                    Message = "New password can not be same as last " + nonRepeatCount + " password(s). Please enter a different password.",
                    StatusCode = 200
                };
            }
        }
    }
}
