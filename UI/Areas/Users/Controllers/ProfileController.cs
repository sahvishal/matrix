using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using Falcon.App.UI.TwoFactor;

namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class ProfileController : Controller
    {
        private readonly ISessionContext _sessionContext;
        private readonly IUserProfileService _userProfileService;
        private readonly ILoginSettingRepository _loginSettingRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly ITechnicianRepository _technicianRepository;

        public ProfileController(ISessionContext sessionContext, IUserProfileService userProfileService, ILoginSettingRepository loginSettingRepository, IUserLoginRepository userLoginRepository, ITechnicianRepository technicianRepository)
        {
            _sessionContext = sessionContext;
            _userProfileService = userProfileService;
            _loginSettingRepository = loginSettingRepository;
            _userLoginRepository = userLoginRepository;
            _technicianRepository = technicianRepository;
        }

        public ActionResult Edit(long id, Roles roleId)
        {
            var currentSession = _sessionContext.UserSession.CurrentOrganizationRole;
            if (currentSession.UserId == id && currentSession.RoleId == (long)roleId)
            {
                var profileEditModel = _userProfileService.GetProfileEditModel(id);
                if (string.IsNullOrEmpty(profileEditModel.Secret))
                {
                    string secret = "", enc = "";
                    secret = TimeBasedOneTimePassword.GenerateSecret(out enc);
                    TempData["EncodedSecret"] = secret;
                    profileEditModel.EncodedSecret = enc;
                }
                else
                {
                    TempData["EncodedSecret"] = profileEditModel.Secret;
                    profileEditModel.EncodedSecret = TimeBasedOneTimePassword.EncodeSecret(profileEditModel.Secret);
                }

                if (roleId == Roles.Technician)
                {
                    var technicianProfile = _technicianRepository.GetTechnician(currentSession.OrganizationRoleUserId);
                    profileEditModel.TechnicianPin = technicianProfile != null ? technicianProfile.Pin : "0000";
                }

                return View(profileEditModel);
            }
            Response.RedirectUser("/Home/UnauthorizeAccess");
            return null;
        }


        [HttpPost]
        public ActionResult Edit(ProfileEditModel profileEditModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userProfileService.SaveProfile(profileEditModel);
                    if (profileEditModel.IsOtpByAppEnabled || profileEditModel.IsOtpByEmailEnabled || profileEditModel.IsOtpBySmsEnabled || profileEditModel.IsPinRequiredForRole)
                    {
                        var loginSettings = _loginSettingRepository.Get(profileEditModel.Id);
                        loginSettings = loginSettings ?? new LoginSettings { UserLoginId = profileEditModel.Id };

                        loginSettings.DownloadFilePin = profileEditModel.IsPinRequiredForRole ? (string.IsNullOrEmpty(profileEditModel.DownloadFilePin) ? loginSettings.DownloadFilePin : profileEditModel.DownloadFilePin) : null;
                        if (profileEditModel.UseAuthenticator)
                        {
                            loginSettings.AuthenticationModeId = (long)AuthenticationMode.AuthenticatorApp;
                            loginSettings.GoogleAuthenticatorSecretKey = (string)TempData["EncodedSecret"];
                        }
                        else
                        {
                            loginSettings.GoogleAuthenticatorSecretKey = null;
                            loginSettings.AuthenticationModeId = profileEditModel.UseSms && profileEditModel.UseEmail ? (long)AuthenticationMode.BothSmsEmail : (profileEditModel.UseSms ? (long)AuthenticationMode.Sms : (long)AuthenticationMode.Email);
                        }
                        _loginSettingRepository.Save(loginSettings);
                    }

                    if (_sessionContext.UserSession.CurrentOrganizationRole.RoleId == (long)Roles.Technician)
                    {
                        var technicianProfile = _technicianRepository.GetTechnician(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                        if (technicianProfile != null)
                        {
                            technicianProfile.Pin = profileEditModel.TechnicianPin;
                        }
                        else
                        {
                            technicianProfile = new Technician
                            {
                                TechnicianId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                                CanDoPreAudit = false,
                                IsTeamLead = false,
                                Pin = profileEditModel.TechnicianPin
                            };
                        }
                        var repository = ((IRepository<Technician>)_technicianRepository);
                        repository.Save(technicianProfile);
                    }

                    profileEditModel = _userProfileService.GetProfileEditModel(profileEditModel.Id);

                    profileEditModel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Profile Updated Successfully.");
                    return View(profileEditModel);
                }

                var secret = (string)TempData["EncodedSecret"];
                profileEditModel.EncodedSecret = TimeBasedOneTimePassword.EncodeSecret(secret);
                TempData.Keep("EncodedSecret");
                return View(profileEditModel);
            }
            catch (Exception ex)
            {
                profileEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(ex.Message);
                return View(profileEditModel);
            }
        }

        public ActionResult GetQrCode(long userId)
        {
            var loginSettings = _loginSettingRepository.Get(userId);
            if (loginSettings != null)
            {
                var secret = loginSettings.GoogleAuthenticatorSecretKey;
                Session["EncodedSecret"] = secret;
                if (string.IsNullOrEmpty(secret))
                {
                    string enc = "";
                    secret = TimeBasedOneTimePassword.GenerateSecret(out enc);
                    Session["EncodedSecret"] = secret;
                    ViewBag.EncodedSecret = enc;
                }
                else
                {
                    Session["EncodedSecret"] = secret;
                    ViewBag.EncodedSecret = TimeBasedOneTimePassword.EncodeSecret(secret);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ValidateUserAndGetPin(string password, long userId)
        {
            var jsonResult = new { IsValid = true, Pin = "" };
            var userLoginModel = new UserLoginModel() { Password = password, UserName = _sessionContext.UserSession.UserName };
            bool isValid = _userLoginRepository.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
            var pin = "";
            if (isValid)
            {
                var loginSettings = _loginSettingRepository.Get(userId);
                pin = loginSettings.DownloadFilePin;
            }
            jsonResult = new { IsValid = isValid, Pin = pin };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

    }
}


/*

 switch (roleId)
            {
                case Roles.FranchiseeAdmin:
                    return Redirect("/App/Franchisor/Profile.aspx?");                    
                case Roles.CallCenterRep:
                    return Redirect("/App/Franchisor/Profile.aspx?");
                    
            }


*/