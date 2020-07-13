using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Impl;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.TwoFactor;
using Newtonsoft.Json;
using Roles = Falcon.App.Core.Enum.Roles;

namespace Falcon.App.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISettings _settings;
        private readonly ISessionContext _sessionContext;
        private readonly IUserLoginRepository _loginRepository;
        private readonly IUserLoginService _loginService;
        private readonly IUserRepository<User> _userRepository;

        private readonly ICustomerRepository _customerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILoginOtpService _loginOtpService;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly ILoginSettingRepository _loginSettingRepository;
        private readonly ISafeComputerHistoryService _safeComputerHistoryService;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IMedicareService _medicareService;
        private readonly ILogger _logger;

        public LoginController(ISettings settings, ISessionContext sessionContext, IUserLoginRepository userLoginRepository, IUserLoginService userLoginService, IUserRepository<User> userRepository,
                                ICustomerRepository customerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICorporateAccountRepository corporateAccountRepository,
                                IRoleRepository roleRepository, ILoginOtpService loginOtpService, IConfigurationSettingRepository configurationSettingRepository, ILoginSettingRepository loginSettingRepository,
                                ISafeComputerHistoryService safeComputerHistoryService, IMedicareApiService medicareApiService, IMedicareService medicareService, ILogManager logManager)
        {
            _settings = settings;
            _sessionContext = sessionContext;
            _loginRepository = userLoginRepository;
            _loginService = userLoginService;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _roleRepository = roleRepository;
            _loginOtpService = loginOtpService;
            _configurationSettingRepository = configurationSettingRepository;
            _loginSettingRepository = loginSettingRepository;
            _safeComputerHistoryService = safeComputerHistoryService;
            _medicareApiService = medicareApiService;
            _medicareService = medicareService;
            _logger = logManager.GetLogger<LoginController>();
        }

        public ActionResult Index(string sessionTimeout = "", bool isSessionTaken = false)
        {
            if (!Request.IsAuthenticated || _sessionContext == null || _sessionContext.UserSession == null)
            {
                if (string.IsNullOrEmpty(sessionTimeout) && isSessionTaken == false)
                    return View();


                var model = new UserLoginModel()
                {
                    FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Your session has expired! Please login to continue.")
                };

                if (isSessionTaken)
                {
                    model = new UserLoginModel()
                   {
                       FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("This session has been logged out because another user has logged in with these credentials.")
                   };
                    return View(model);
                }

                return View(model);
            }
            Response.RedirectUser("/Users/Role/Switch?roleId=" + _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "&organizationId=" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
            return null;
        }


        [HttpPost]
        public ActionResult Index(UserLoginModel userLoginModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginModel);
            }

            bool isValid = _loginRepository.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
            if (isValid)
            {
                try
                {
                    var userLogin = _loginRepository.GetByUserName(userLoginModel.UserName);
                    var user = _userRepository.GetUser(userLogin.Id);
                    var orgRoles = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(user.Id);
                    if (orgRoles.Any(oru => oru.RoleId == (long)Roles.Customer) && user.DefaultRole == Roles.Customer)
                    {
                        var customer = _customerRepository.GetCustomerByUserId(user.Id);
                        if (!string.IsNullOrEmpty(customer.Tag))
                        {
                            var account = _corporateAccountRepository.GetByTag(customer.Tag);
                            if (account != null && !account.AllowCustomerPortalLogin)
                            {
                                userLoginModel.FeedbackMessage =
                                    FeedbackMessageModel.CreateFailureMessage("Unable to login in. Please contact " +
                                                                              _settings.SupportEmail + " OR call us at " +
                                                                              _settings.PhoneTollFree);
                                return View(userLoginModel);
                            }
                        }
                    }

                    var userName = userLoginModel.UserName;
                    FormsAuthentication.SetAuthCookie(userName, true);
                    _sessionContext.UserSession = _loginService.GetUserSessionModel(userName);
                    _sessionContext.LastLoggedInTime = userLogin.LastLogged.ToString();

                    if (_sessionContext.UserSession.CurrentOrganizationRole == null)
                    {
                        userLoginModel.FeedbackMessage =
                            FeedbackMessageModel.CreateFailureMessage(
                                "Your default role has been removed. Please contact your administrator.");
                        return View(userLoginModel);
                    }

                    Role role = null;
                    var isTwoFactorAuthrequired = true;
                    var useOtpSms = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms);
                    var useOtpEmail = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail);
                    var useOtpByGoogleAuthenticator = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpByGoogleAuthenticator);

                    var isPinRequired = false;


                    if (useOtpSms == "True" || useOtpEmail == "True" || useOtpByGoogleAuthenticator == "True")
                    {
                        var defaultRole = orgRoles.FirstOrDefault(oru => oru.RoleId == (long)user.DefaultRole);
                        if (defaultRole != null)
                        {
                            role = _roleRepository.GetByRoleId(defaultRole.RoleId);
                            isPinRequired = role.IsPinRequired;
                        }

                        if (userLogin.IsTwoFactorAuthrequired == null)
                        {
                            if (defaultRole != null)
                            {
                                isTwoFactorAuthrequired = role.IsTwoFactorAuthrequired;
                            }
                        }
                        else
                        {
                            isTwoFactorAuthrequired = userLogin.IsTwoFactorAuthrequired.Value;
                        }
                    }
                    else
                    {
                        isTwoFactorAuthrequired = false;
                    }

                    if (isTwoFactorAuthrequired || isPinRequired)
                    {
                        var loginSettings = _loginSettingRepository.Get(_sessionContext.UserSession.UserId);

                        if (loginSettings == null || loginSettings.IsFirstLogin)
                        {
                            TempData["IsTwoFactorAuthrequired"] = isTwoFactorAuthrequired;
                            return RedirectToAction("Setup");
                        }
                        else if (isPinRequired && loginSettings.DownloadFilePin == "")
                        {
                            TempData["IsTwoFactorAuthrequired"] = isTwoFactorAuthrequired;
                            TempData["setPinOnly"] = true;
                            return RedirectToAction("Setup");
                        }

                        if (isTwoFactorAuthrequired)
                        {
                            var isSafe = false;
                            var isSafeAllowed = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AllowSafeComputerRemember);

                            if (isSafeAllowed == "True")
                            {
                                var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
                                var requestingIp = Request.UserHostAddress;
                                var safeComputer = new SafeComputerHistory()
                                {
                                    BrowserType = browserName,
                                    ComputerIp = requestingIp,
                                    DateCreated = DateTime.Now,
                                    IsActive = true,
                                    UserLoginId = user.Id
                                };
                                isSafe = _safeComputerHistoryService.IsSafe(safeComputer);
                            }

                            if (!isSafe)
                            {
                                if (loginSettings.AuthenticationModeId == (long)AuthenticationMode.Sms)
                                {
                                    if (useOtpSms == "True")
                                        return RedirectToAction("Otp");
                                    TempData["IsTwoFactorAuthrequired"] = true;
                                    TempData["IsOnGlobalSettingChange"] = true;
                                    return RedirectToAction("Setup");
                                }
                                if (loginSettings.AuthenticationModeId == (long)AuthenticationMode.Email)
                                {
                                    if (useOtpEmail == "True")
                                        return RedirectToAction("Otp");
                                    TempData["IsTwoFactorAuthrequired"] = true;
                                    TempData["IsOnGlobalSettingChange"] = true;
                                    return RedirectToAction("Setup");
                                }
                                if (loginSettings.AuthenticationModeId == (long)AuthenticationMode.BothSmsEmail)
                                {
                                    if (useOtpSms == "True" || useOtpEmail == "True")
                                        return RedirectToAction("Otp");
                                    TempData["IsTwoFactorAuthrequired"] = true;
                                    TempData["IsOnGlobalSettingChange"] = true;
                                    return RedirectToAction("Setup");
                                }
                                if (loginSettings.AuthenticationModeId == (long)AuthenticationMode.AuthenticatorApp)
                                {
                                    return RedirectToAction("Authenticator");
                                }
                            }
                        }
                    }


                    return GoToDashboard(_sessionContext.UserSession.UserId, returnUrl);
                }
                catch (Exception ex)
                {
                    _logger.Error("Error: Message: " + ex.Message + "\n Stack trace:" + ex.StackTrace);
                    userLoginModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error: Unable to login in. Please contact support.");
                    return View(userLoginModel);
                }
            }

            //not logged in.
            return View(GetLoginFailureMessage(userLoginModel));
        }

        private UserLoginModel GetLoginFailureMessage(UserLoginModel userLogin)
        {
            try
            {
                var notLoggedInUser = _loginRepository.GetByUserName(userLogin.UserName);
                if (notLoggedInUser == null)
                {
                    userLogin.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage(
                            "Username and/or password do not match. Please try again.");
                    return userLogin;
                }
                if (notLoggedInUser.IsActive == false)
                {
                    userLogin.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage(
                            "Your account is disabled.");
                    return userLogin;
                }
                //found user but could not login.
                if (notLoggedInUser.Locked)
                {
                    userLogin.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage(
                            "Your account has been locked, due to too many attempts. Please contact " +
                            _settings.SupportEmail + " OR call us at " + _settings.PhoneTollFree);
                    return userLogin;
                }

                var loginAttempts = notLoggedInUser.FailedAttempts;
                _loginRepository.UpdateLoginStatus(notLoggedInUser.Id, false);

                if (loginAttempts == 1)
                {
                    userLogin.FeedbackMessage =
                        FeedbackMessageModel.CreateWarningMessage(
                            "Looks like you are having trouble logging in. You have only 3 more attempts before your " +
                            "account will be temporarily locked for security reasons. Please click on link beside the login button to try and reset your password.");
                    return userLogin;
                }
                if (loginAttempts == 3)
                {
                    userLogin.FeedbackMessage =
                        FeedbackMessageModel.CreateWarningMessage(
                            "You have only one attempt left before your account will be temporarily locked " +
                            "for security reasons. Please click on link beside the login button to try and reset your password.");
                    return userLogin;
                }
                if (loginAttempts == 4)
                {
                    userLogin.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage(
                            "Your account has been locked, due to too many attempts. Please contact " +
                            _settings.SupportEmail + " OR call us at " + _settings.PhoneTollFree);
                    return userLogin;
                }

                userLogin.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage("Username and/or password do not match. Please try again.");
                return userLogin;
            }
            catch (Exception)
            {
                userLogin.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage("Username and/or password do not match. Please try again.");
                return userLogin;
            }
        }

        public ActionResult UserLogin()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public ActionResult ValidateUser(UserLoginModel userLoginModel)
        {
            var jsonResult = new { CustomerId = 0L, CustomerName = "", IsValid = true, Message = "" };
            if (!ModelState.IsValid)
            {
                jsonResult = new { CustomerId = 0L, CustomerName = "", IsValid = false, Message = "Please enter a valid Username/Password!" };
                return Json(jsonResult);
            }

            bool isValid = _loginRepository.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
            if (!isValid)
            {
                userLoginModel = GetLoginFailureMessage(userLoginModel);
                jsonResult = new { CustomerId = 0L, CustomerName = "", IsValid = false, userLoginModel.FeedbackMessage.Message };
                return Json(jsonResult);
            }

            var userLogin = _loginRepository.GetByUserName(userLoginModel.UserName);
            var customer = _customerRepository.GetCustomerByUserId(userLogin.Id);
            jsonResult = new { customer.CustomerId, CustomerName = customer.NameAsString, IsValid = true, Message = "" };


            return Json(jsonResult);
        }

        public ActionResult RefreshSession()
        {
            return new EmptyResult();
        }


        public ActionResult Otp()
        {
            var model = new OtpModel();
            ViewBag.ExpirationMinutes = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpExpirationMinutes);
            ViewBag.AttemptCount = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpMisMatchAttemptCount);
            model.IsAllowSafeComputerEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AllowSafeComputerRemember) == "True";

            if (_sessionContext.UserSession == null && Session["UserId"] != null)
            {
                model.UserId = (long)Session["UserId"];
                return View(model);
            }
            if (_sessionContext.UserSession == null && Session["UserId"] == null)
                return RedirectToAction("Index");

            _loginOtpService.ResetOtp(_sessionContext.UserSession.UserId);
            _loginOtpService.GenerateOtp(_sessionContext.UserSession.UserId, Request.Url.ToString());

            Session["UserId"] = model.UserId = _sessionContext.UserSession.UserId;
            _sessionContext.UserSession = null;
            return View(model);
        }

        [HttpPost]
        public ActionResult Otp(OtpModel model)
        {
            ViewBag.ExpirationMinutes = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpExpirationMinutes);
            ViewBag.AttemptCount = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpMisMatchAttemptCount);
            model.IsAllowSafeComputerEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AllowSafeComputerRemember) == "True";

            var userId = (long)Session["UserId"];
            model.UserId = userId;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isOtpExpired;
            bool isAttemptExpired;
            var isOtpVerified = _loginOtpService.VerifyOtp(model.Otp, userId, out isOtpExpired, out isAttemptExpired);
            if (isAttemptExpired)
            {
                _loginRepository.AssignUserLoginLock(userId);
                model.IsOtpVerified = false;
                model.IsAccountLocked = true;
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Your account has been locked, due to too many attempts. Please contact " +
                            _settings.SupportEmail + " OR call us at " + _settings.PhoneTollFree);
                return View(model);
            }
            if (isOtpExpired)
            {
                model.IsOtpVerified = false;
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("The OTP is expired. Please use resend link to generate a new OTP.");
                return View(model);
            }
            if (!isOtpVerified)
            {
                model.IsOtpVerified = false;
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("The OTP entered is wrong. Please try again.");
                return View(model);
            }
            if (model.MarkAsSafe)
            {
                var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
                var requestingIp = Request.UserHostAddress;
                var safeComputer = new SafeComputerHistory() { BrowserType = browserName, ComputerIp = requestingIp, DateCreated = DateTime.Now, DateModified = DateTime.Now, IsActive = true, UserLoginId = userId };
                _safeComputerHistoryService.Save(safeComputer);

            }
            return GoToDashboard(userId);
        }

        public ActionResult Authenticator()
        {
            if (_sessionContext.UserSession == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.IsOtpBySmsEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms) == "True";
            ViewBag.IsOtpByEmailEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail) == "True";
            ViewBag.IsOtpByAppEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpByGoogleAuthenticator) == "True";

            var model = new OtpModel();
            model.IsAllowSafeComputerEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AllowSafeComputerRemember) == "True";
            if (_sessionContext.UserSession == null && Session["UserId"] != null)
            {
                model.UserId = (long)Session["UserId"];
                return View(model);
            }

            Session["UserId"] = _sessionContext.UserSession.UserId;
            _sessionContext.UserSession = null;

            return View(model);
        }
        [HttpPost]
        public ActionResult Authenticator(OtpModel model)
        {
            ViewBag.IsOtpBySmsEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms) == "True";
            ViewBag.IsOtpByEmailEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail) == "True";
            ViewBag.IsOtpByAppEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpByGoogleAuthenticator) == "True";

            model.IsAllowSafeComputerEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AllowSafeComputerRemember) == "True";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = (long)Session["UserId"];
            var loginSettings = _loginSettingRepository.Get(userId);
            var isValid = TimeBasedOneTimePassword.IsValid(loginSettings.GoogleAuthenticatorSecretKey, model.Otp, 50);
            if (!isValid)
            {
                model.IsOtpVerified = false;
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("The OTP entered is wrong. Please try again.");
                return View(model);
            }
            if (model.MarkAsSafe)
            {
                var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
                var requestingIp = Request.UserHostAddress;
                var safeComputer = new SafeComputerHistory() { BrowserType = browserName, ComputerIp = requestingIp, DateCreated = DateTime.Now, DateModified = DateTime.Now, IsActive = true, UserLoginId = userId };
                _safeComputerHistoryService.Save(safeComputer);

            }

            return GoToDashboard(userId);
        }

        private ActionResult GoToDashboard(long userId, string returnUrl = "")
        {
            var loggedInUser = _userRepository.GetUser(userId);
            _sessionContext.UserSession = _loginService.GetUserSessionModel(userId);

            int lastPasswordChangeDays = 0;
            Int32.TryParse(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PasswordExpirationDays), out lastPasswordChangeDays);

            if (!loggedInUser.UserLogin.UserVerified) //!loggedInUser.UserLogin.IsSecurityQuestionVerified || -- removed as nothing is happening for this case
            {
                Response.RedirectUser("/App/FirstTimeLoginStep.aspx?FirstTimeLogin=Y&returnUrl=" + returnUrl);
                return null;
            }
            if (_loginRepository.IsPasswordExpired(loggedInUser.UserLogin.UserName, lastPasswordChangeDays))
            {
                Response.RedirectUser("/App/FirstTimeLoginStep.aspx?FirstTimeLogin=Y&PwdExpire=Y&returnUrl=" + returnUrl);
                return null;
            }

            int daysBeforAlert = 0;

            Int32.TryParse(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AlertBeforePasswordExpirationInDays), out daysBeforAlert);
            var passwordExpireInDays = _loginRepository.PasswordWillExpiredInDays(loggedInUser.UserLogin.UserName, lastPasswordChangeDays);

            if (passwordExpireInDays <= daysBeforAlert)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("PasswordExpiration", new
                    {
                        passwordExpireInDays = passwordExpireInDays <= 0 ? 0 : passwordExpireInDays,
                        returnUrl = returnUrl //do not remove variable name
                    });
                }

                return RedirectToAction("PasswordExpiration", new
                {
                    passwordExpireInDays = passwordExpireInDays <= 0 ? 0 : passwordExpireInDays
                });
            }


            _loginOtpService.ResetOtp(loggedInUser.Id);

            _sessionContext.LastLoggedInTime = loggedInUser.UserLogin.LastLogged.ToString();
            _loginRepository.UpdateLoginStatus(_sessionContext.UserSession.UserId, true);

            var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
            var sessionId = Session.SessionID;
            sessionId = RegenrateSessionId();

            var loginLog = _loginService.SaveLoginInfo(loggedInUser.Id, loggedInUser.UserLogin.UserName, sessionId, browserName, Request.UserHostAddress, Request.UrlReferrer);

            _sessionContext.UserSession.UserLoginLogId = loginLog.Id;

            if ((_sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Roles.CallCenterRep || _sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Roles.NursePractitioner) && !string.IsNullOrEmpty(returnUrl))
                Response.RedirectUser(returnUrl);
            else
                Response.RedirectUser("/Users/Role/Switch?roleId=" + _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "&organizationId=" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
            return null;
        }

        public ActionResult Setup()
        {
            //to do : if user pastes the url then move him to dashboard based on condition if the entry is present in the database
            if (_sessionContext.UserSession == null)
            {
                return RedirectToAction("Index");
            }
            var IsOnGlobalSettingChange = false;
            var loginSettings = _loginSettingRepository.Get(_sessionContext.UserSession.UserId);
            if (TempData["IsOnGlobalSettingChange"] != null)
            {
                IsOnGlobalSettingChange = (bool)TempData["IsOnGlobalSettingChange"];
            }

            var setPinOnly = TempData["setPinOnly"];
            if (loginSettings != null && loginSettings.IsFirstLogin == false && IsOnGlobalSettingChange == false && (setPinOnly == null || (bool)setPinOnly == false))
            {
                Response.RedirectUser("/Users/Role/Switch?roleId=" + _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "&organizationId=" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
                return null;
            }


            var isTwoFactorAuthrequired = (bool)TempData["IsTwoFactorAuthrequired"];

            string secret = "", enc = "";
            secret = TimeBasedOneTimePassword.GenerateSecret(out enc);
            TempData["EncodedSecret"] = secret;

            var role = _roleRepository.GetByRoleId(_sessionContext.UserSession.CurrentOrganizationRole.RoleId);
            var model = new SetupViewModel()
            {
                EncodedSecret = enc,
                IsPinRequired = role.IsPinRequired,
                UserLoginId = _sessionContext.UserSession.CurrentOrganizationRole.UserId
            };
            if (isTwoFactorAuthrequired)
            {
                model.IsOtpBySmsEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms) == "True";
                model.IsOtpByEmailEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail) == "True";
                model.IsOtpByAppEnabled = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.OtpByGoogleAuthenticator) == "True";
            }
            if (setPinOnly != null && (bool)setPinOnly)
            {
                model.IsOtpBySmsEnabled = false;
                model.IsOtpByEmailEnabled = false;
                model.IsOtpByAppEnabled = false;
            }
            TempData.Keep("setPinOnly");
            TempData.Keep("IsTwoFactorAuthrequired");
            TempData.Keep("IsOnGlobalSettingChange");
            return View(model);
        }
        [HttpPost]
        public ActionResult Setup(SetupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var secret = TempData["EncodedSecret"];

            var loginSettings = new LoginSettings();
            loginSettings.DownloadFilePin = null;
            loginSettings.UserLoginId = model.UserLoginId;
            if (model.IsPinRequired)
            {
                loginSettings.DownloadFilePin = model.Pin;
            }

            if (model.UseAuthenticator)
            {
                loginSettings.GoogleAuthenticatorSecretKey = (string)secret;
                loginSettings.AuthenticationModeId = (long)AuthenticationMode.AuthenticatorApp;
            }
            else if (model.UseEmail || model.UseSms)
            {
                loginSettings.AuthenticationModeId = model.UseSms && model.UseEmail ? (long)AuthenticationMode.BothSmsEmail : (model.UseSms ? (long)AuthenticationMode.Sms : (long)AuthenticationMode.Email); ;
                if (!string.IsNullOrEmpty(model.PhoneCell))// To eliminate masking
                    model.PhoneCell = model.PhoneCell.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
                _userRepository.UpdateUsePhoneAndEmail(_sessionContext.UserSession.CurrentOrganizationRole.UserId, model.PhoneCell, model.Email);
            }
            else
            {
                loginSettings.AuthenticationModeId = (long)AuthenticationMode.Sms;
            }

            _loginSettingRepository.Save(loginSettings);

            if (model.UseAuthenticator)
            {
                return RedirectToAction("Authenticator");
            }
            if (model.UseEmail || model.UseSms)
            {
                return RedirectToAction("Otp");
            }
            return GoToDashboard(_sessionContext.UserSession.CurrentOrganizationRole.UserId);
        }

        [HttpPost]
        public ActionResult RedirectToOtp(AuthenticatorModel model)
        {
            var jsonResult = new { IsValid = true, Message = "" };
            var emailValidator = new AuthenticatorModelValidator();
            var isValid = emailValidator.Validate(model).IsValid;
            if (!isValid)
            {
                jsonResult = new { IsValid = false, Message = "" };
            }
            if (model.UseSms)
                model.Email = null;
            else
            {
                model.Phone = null;
            }

            var userId = (long)Session["UserId"];
            var logginSettings = _loginSettingRepository.Get(userId);
            logginSettings.AuthenticationModeId = model.UseSms
                ? (long)AuthenticationMode.Sms
                : (long)AuthenticationMode.Email;
            _loginSettingRepository.Save(logginSettings);

            _userRepository.UpdateUsePhoneAndEmail(userId, model.Phone, model.Email);

            _sessionContext.UserSession = _loginService.GetUserSessionModel(userId);
            _loginOtpService.ResetOtp(userId);
            _loginOtpService.GenerateOtp(userId, Request.Url.AbsolutePath.ToString());
            _sessionContext.UserSession = null;
            return Json(jsonResult);
        }

        public ActionResult ResendOtp(long userId)
        {
            if (_loginRepository.IsUserLocked(userId))
                return Json("Your Account is Locked", JsonRequestBehavior.AllowGet);
            _loginOtpService.ResetOtp(userId);
            _sessionContext.UserSession = _loginService.GetUserSessionModel(userId);
            _loginOtpService.GenerateOtp(userId, Request.Url.AbsolutePath.ToString());
            _sessionContext.UserSession = null;
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        private string RegenrateSessionId()
        {
            var manager = new SessionIDManager();
            HttpContext context = System.Web.HttpContext.Current;
            string oldId = manager.GetSessionID(context);
            string newId = manager.CreateSessionID(context);
            bool isAdd = false, isRedir = false;
            manager.SaveSessionID(context, newId, out isRedir, out isAdd);
            var ctx = (HttpApplication)System.Web.HttpContext.Current.ApplicationInstance;
            HttpModuleCollection mods = ctx.Modules;
            var ssm = (SessionStateModule)mods.Get("Session");
            FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            SessionStateStoreProviderBase store = null;
            FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;
            foreach (FieldInfo field in fields)
            {
                if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
                if (field.Name.Equals("_rqId")) rqIdField = field;
                if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
                if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;
            }
            if (rqLockIdField != null)
            {
                object lockId = rqLockIdField.GetValue(ssm);
                if ((lockId != null) && (oldId != null))
                    if (store != null) store.ReleaseItemExclusive(context, oldId, lockId);
            }
            if (rqStateNotFoundField != null) rqStateNotFoundField.SetValue(ssm, true);
            if (rqIdField != null) rqIdField.SetValue(ssm, newId);
            return newId;
        }

        public ActionResult PasswordExpiration(int passwordExpireInDays, string returnUrl = "")
        {
            ViewBag.PasswordExpireInDays = passwordExpireInDays;
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public ActionResult PasswordExpiration(string returnUrl = "")
        {
            if (_sessionContext.UserSession == null)
            {
                return RedirectToAction("Index", new { returnUrl });
            }
            var loggedInUser = _userRepository.GetUser(_sessionContext.UserSession.UserId);

            _loginOtpService.ResetOtp(loggedInUser.Id);

            _sessionContext.LastLoggedInTime = loggedInUser.UserLogin.LastLogged.ToString();
            _loginRepository.UpdateLoginStatus(_sessionContext.UserSession.UserId, true);

            var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
            var sessionId = Session.SessionID;
            sessionId = RegenrateSessionId();

            var loginLog = _loginService.SaveLoginInfo(loggedInUser.Id, loggedInUser.UserLogin.UserName, sessionId, browserName, Request.UserHostAddress, Request.UrlReferrer);

            _sessionContext.UserSession.UserLoginLogId = loginLog.Id;

            if (_sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Roles.CallCenterRep && !string.IsNullOrEmpty(returnUrl))
                Response.RedirectUser(returnUrl);
            else
                Response.RedirectUser("/Users/Role/Switch?roleId=" + _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "&organizationId=" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
            return null;

        }

        public ActionResult MedicareResult(string id, bool isFromHraPopup = false)
        {
            var userData = ValidateMedicareToken(id);
            try
            {
                if (isFromHraPopup)
                    GetSession(userData);
                else
                    GetSession(userData, true);

                var eventId = Convert.ToInt64(userData[2]);
                var customerId = Convert.ToInt64(userData[3]);
                var resultstate = _medicareService.GetResultState(eventId, customerId);
                if (userData[5] == "True")
                {
                    Response.RedirectUser("/App/Common/Results.aspx?EventId=" + eventId + "&CustomerId=" + customerId + "&IsMedicare=true");
                }
                else
                {
                    if (resultstate >= 0 && resultstate <= 3)
                        Response.RedirectUser("/App/Franchisee/Technician/AuditResultEntry.aspx?EventId=" + eventId + "&CustomerId=" + customerId + "&IsMedicare=true");
                    if (resultstate >= 4 && resultstate <= 7)
                        Response.RedirectUser("/App/Common/Results.aspx?EventId=" + eventId + "&CustomerId=" + customerId + "&IsMedicare=true");
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.Error("Error: Login Ehr From Medicare Message: " + ex.Message + "\n Stack trace:" + ex.StackTrace);
            }
            return new EmptyResult();
        }

        public string MedicareLogin(string id)
        {
            var userData = ValidateMedicareToken(id);
            try
            {
                return GetSession(userData);
            }
            catch (Exception ex)
            {
                _logger.Error("Error: Login EHR From Medicare Message: " + ex.Message + "\n Stack trace:" + ex.StackTrace);
            }
            return null;
        }

        private string[] ValidateMedicareToken(string id)
        {
            const int count = 6;
            var currentPrivateToken = id.Replace("$$", "+");
            if (string.IsNullOrEmpty(currentPrivateToken))
                throw new Exception("Invalid Medicare token.");

            var decryptedToken = currentPrivateToken.Decrypt();
            var userData = decryptedToken.Split('_');
            if (userData.Length != count)
            {
                throw new InvalidDataException("Invalid Medicare token.");
            }
            return userData;
        }

        private string GetSession(string[] userData, bool isPopupOpened = false)
        {
            var userId = Convert.ToInt64(userData[1]);
            var user = _userRepository.GetUser(userId);

            var userName = user.UserLogin.UserName;
            FormsAuthentication.SetAuthCookie(userName, true);
            _sessionContext.UserSession = _loginService.GetUserSessionModel(userName);

            if (_sessionContext.UserSession.CurrentOrganizationRole == null)
            {
                throw new Exception("Your default role has been removed. Please contact your administrator.");
            }

            //Code Removed as it was redundant hit to Database 
            //var loggedInUser = _userRepository.GetUser(userId);
            //_sessionContext.UserSession = _loginService.GetUserSessionModel(userId);

            //_loginOtpService.ResetOtp(loggedInUser.Id); 
            _sessionContext.LastLoggedInTime = user.UserLogin.LastLogged.ToString();
            _loginRepository.UpdateLoginStatus(_sessionContext.UserSession.UserId, true);

            var browserName = Request.Browser.Browser + " " + Request.Browser.Version;
            string sessionId = "";

            var loginLog = new UserLoginLog();
            var roles = _roleRepository.GetRolesByAlias(userData[0]);
            roles = roles.Where(x => x.ParentId == null);
            var role = roles.First();

            var availableRole = _sessionContext.UserSession.AvailableOrganizationRoles.FirstOrDefault(x => x.RoleId == role.Id);
            if (availableRole == null)
            {
                throw new Exception("Your role is not available in HIP. Please contact your administrator.");
            }

            if (!isPopupOpened)
            {
                loginLog = _loginService.GetLatestUserLogin(userId);
                if (loginLog == null)
                //if no login present then we'll login the user in case of NON-POPUP request logins
                {
                    sessionId = RegenrateSessionId();
                    MedicareLoginTask(user, sessionId, browserName, role, availableRole);
                }
                else
                {
                    _sessionContext.UserSession.UserLoginLogId = loginLog.Id;
                    sessionId = loginLog.BrowserSession; //if old login is found then use old session id too
                }
            }
            else
            {
                sessionId = RegenrateSessionId();
                MedicareLoginTask(user, sessionId, browserName, role, availableRole);
            }

            // send the EHR Session to Medicare

            var token = (sessionId + "_" + _sessionContext.UserSession.UserId + "_" + _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();
            var auth = new MedicareUpdateTokenModel { Token = token, SessionId = sessionId };
            
            if (_settings.SyncWithHra)
            {
                _medicareApiService.Post<string>(_settings.MedicareApiUrl + MedicareApiUrl.SetEhrToken, auth);
            }

            return JsonConvert.SerializeObject(auth);
        }

        private UserLoginLog MedicareLoginTask(User user, string sessionId, string browserName, Role role, OrganizationRoleUserModel availableRole)
        {
            var newLoginlog = _loginService.SaveLoginInfo(user.Id, user.UserLogin.UserName, sessionId, browserName, Request.UserHostAddress, Request.UrlReferrer ?? new Uri("https://hip.healthfair.com/Login/MedicareLogin"));
            _sessionContext.UserSession.UserLoginLogId = newLoginlog.Id;
            _sessionContext.UserSession = _loginService.SwitchOrganizationRole(_sessionContext.UserSession, role.Id, availableRole.OrganizationId);

            return newLoginlog;
        }
    }
}
