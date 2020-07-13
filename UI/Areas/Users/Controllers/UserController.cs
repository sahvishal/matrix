using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Impl;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.UI.Filters;
using System.Collections.Generic;

namespace Falcon.App.UI.Areas.Users.Controllers
{
    [RoleBasedAuthorize]
    public class UserController : Controller
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IUserService _userService;

        private const int PAGE_SIZE = 50;

        private readonly IUsersListModelRepository _usersListModelRepository;
        private readonly ITestRepository _testRepository;
        private readonly IPodRepository _podRepository;
        private readonly ISessionContext _sessionContext;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly IPasswordChangelogService _passwordChangelogService;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IMedicareService _medicareService;
        private readonly IRoleRepository _roleRepository;
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();
        private readonly ILogger _logger;
        private readonly IUserNpiInfoRepository _userNpiInfoRepository;
        private readonly ISystemUserInfoRepository _systemUserInfoRepository;
        private readonly IPinChangeLogService _pinChangelogService;

        public UserController(IUserRepository<User> userRepository, IUserService userService, IUsersListModelRepository usersListModelRepository, ITestRepository testRepository, IPodRepository podRepository, ISessionContext sessionContext,
            IUniqueItemRepository<Core.Application.Domain.File> fileRepository, IMediaRepository mediaRepository, IUserLoginRepository userLoginRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IPhysicianRepository physicianRepository, IEventStaffAssignmentRepository eventStaffAssignmentRepository, IPasswordChangelogService passwordChangelogService, IConfigurationSettingRepository configurationSettingRepository,
            IMedicareApiService medicareApiService, IMedicareService medicareService, IRoleRepository roleRepository, ILogManager logManager,
            IUserNpiInfoRepository userNpiInfoRepository, ISystemUserInfoRepository systemUserInfoRepository, IPinChangeLogService pinChangelogService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _usersListModelRepository = usersListModelRepository;
            _testRepository = testRepository;
            _podRepository = podRepository;
            _sessionContext = sessionContext;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _userLoginRepository = userLoginRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _physicianRepository = physicianRepository;
            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _passwordChangelogService = passwordChangelogService;
            _configurationSettingRepository = configurationSettingRepository;
            _medicareApiService = medicareApiService;
            _medicareService = medicareService;
            _roleRepository = roleRepository;
            _logger = logManager.GetLogger<UserController>();
            _userNpiInfoRepository = userNpiInfoRepository;
            _systemUserInfoRepository = systemUserInfoRepository;
            _pinChangelogService = pinChangelogService;
        }


        public ActionResult Index(UserListModelFilter userListModelFilter = null, int pageNumber = 1)
        {
            int totalRecords;

            var userListModelPaged = _usersListModelRepository.GetUserListModelPaged(pageNumber, PAGE_SIZE, userListModelFilter, out totalRecords);
            userListModelPaged.Filter = userListModelFilter;


            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, userListModelFilter.Keyword, userListModelFilter.Roles, userListModelFilter.ActiveUser, userListModelFilter.InActiveUser, userListModelFilter.UserType });
            userListModelPaged.PagingModel = new PagingModel(pageNumber, PAGE_SIZE, totalRecords, urlFunc);


            return View(userListModelPaged);
        }


        public ActionResult Create(string message)
        {
            var userCreateModel = new UserEditModel();
            SetTestsAndPodsForPhysicianProfile(userCreateModel);
            if (message != null)
            {
                userCreateModel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(message);
            }
            return View(userCreateModel);
        }

        [HttpPost]
        public ActionResult Create(UserEditModel userEditModel)
        {
            if (userEditModel.UsersRoles != null && userEditModel.UsersRoles.Count() > 0)
            {
                if (!userEditModel.UsersRoles.Any(ur => ur.GetSystemRoleId == (long)Roles.MedicalVendorUser))
                    userEditModel.PhysicianProfile = null;
            }
            var userValidator = IoC.Resolve<UserEditModelValidator>();
            var result = userValidator.Validate(userEditModel);
            if (result.IsValid)//ModelState.IsValid
            {
                try
                {
                    if (userEditModel.PhysicianProfile != null)
                    {
                        if (Request.Files.Count > 0)
                        {
                            var signatureFile = UploadFile(Request.Files[0], userEditModel.FullName.ToString());
                            userEditModel.PhysicianProfile.SignatureFile = signatureFile;
                        }
                    }

                    userEditModel = _userService.Save(userEditModel);

                    ExportToMedicare(userEditModel, new List<string>());

                    SendNotificationMail(userEditModel);

                    ModelState.Clear();
                    return RedirectToAction("Create", "User", new { message = string.Format("The user {0} was saved successfully. You can add more users from here.", userEditModel.FullName) });
                    //var newModel = new UserEditModel();
                    //SetTestsAndPodsForPhysicianProfile(newModel);

                    //newModel.FeedbackMessage =
                    //    FeedbackMessageModel.CreateSuccessMessage(
                    //        string.Format("The user {0} was saved successfully. You can add more users from here.",
                    //                      userEditModel.FullName));
                    //return View(newModel);
                }

                catch (InvalidAddressException)
                {
                    SetTestsAndPodsForPhysicianProfile(userEditModel);
                    userEditModel.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage(
                            "Unable to save this address. Please check the city, state and zip are valid.");
                    return View(userEditModel);
                }

                catch (Exception exception)
                {
                    SetTestsAndPodsForPhysicianProfile(userEditModel);
                    userEditModel.FeedbackMessage =
                        FeedbackMessageModel.CreateFailureMessage("System Error:" + exception.Message);
                    return View(userEditModel);
                }
            }
            SetTestsAndPodsForPhysicianProfile(userEditModel);
            return View(userEditModel);

        }

        //
        // GET: /Users/User/Edit/5
        public ActionResult Edit(long id)
        {
            var model = _userService.Get(id);
            if (model.PhysicianProfile != null && model.PhysicianProfile.SignatureFile != null)
            {
                var signatureMediaFileLocation = _mediaRepository.GetPhysicianSignatureMediaFileLocation();
                model.PhysicianProfile.SignatureFile.Path = signatureMediaFileLocation.Url +
                                                            model.PhysicianProfile.SignatureFile.Path;
            }
            SetTestsAndPodsForPhysicianProfile(model);
            model.TechnicianProfile.Pin = string.Empty;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserEditModel userEditModel)
        {
            try
            {
                if (userEditModel.UsersRoles != null && userEditModel.UsersRoles.Count() > 0)
                {
                    if (!userEditModel.UsersRoles.Any(ur => ur.GetSystemRoleId == (long)Roles.MedicalVendorUser))
                        userEditModel.PhysicianProfile = null;
                }
                var userValidator = IoC.Resolve<UserEditModelValidator>();
                var result = userValidator.Validate(userEditModel);
                if (result.IsValid)//ModelState.IsValid
                {
                    if (!string.IsNullOrEmpty(userEditModel.Password) && _passwordChangelogService.IsPasswordRepeated(userEditModel.Id, userEditModel.Password))
                    {
                        SetTestsAndPodsForPhysicianProfile(userEditModel);
                        var nonRepeatCount = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPasswordNonRepetitionCount);
                        userEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("New password can not be same as last " + nonRepeatCount + " password(s). Please enter a different password.");
                        return View(userEditModel);
                    }

                    if (!string.IsNullOrEmpty(userEditModel.TechnicianProfile.Pin) && _pinChangelogService.IsPinRepeated(userEditModel.TechnicianProfile.TechnicianId, userEditModel.TechnicianProfile.Pin.Encrypt()))
                    {
                        SetTestsAndPodsForPhysicianProfile(userEditModel);
                        var nonRepeatPinCount = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPinNonRepetitionCount);
                        userEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("New Pin can not be same as last " + nonRepeatPinCount + " pin(s). Please enter a different Pin.");
                        return View(userEditModel);
                    }

                    try
                    {
                        if (userEditModel.PhysicianProfile != null)
                        {
                            if (Request.Files.Count > 0)
                            {
                                var signatureFile = UploadFile(Request.Files[0], userEditModel.FullName.ToString());
                                if (signatureFile != null)
                                {
                                    signatureFile.Id = userEditModel.PhysicianProfile.SignatureFile.Id;
                                    userEditModel.PhysicianProfile.SignatureFile = signatureFile;
                                }
                                else if (userEditModel.PhysicianProfile.SignatureFile != null && userEditModel.PhysicianProfile.SignatureFile.Id > 0)
                                {
                                    userEditModel.PhysicianProfile.SignatureFile =
                                        _fileRepository.GetById(userEditModel.PhysicianProfile.SignatureFile.Id);
                                }
                                else
                                    userEditModel.PhysicianProfile.SignatureFile = null;
                            }
                        }

                        var currentRoles = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(userEditModel.Id).Where(x => x.RoleId == (long)Roles.CallCenterRep || x.RoleId == (long)Roles.Technician ||
                            x.RoleId == (long)Roles.NursePractitioner || x.RoleId == (long)Roles.Coder || x.RoleId == (long)Roles.MedicalVendorUser).Select(x => x.RoleId);
                        var newRoles = userEditModel.UsersRoles.Where(x => x.RoleId == (long)Roles.CallCenterRep || x.RoleId == (long)Roles.Technician ||
                            x.RoleId == (long)Roles.NursePractitioner || x.RoleId == (long)Roles.Coder || x.RoleId == (long)Roles.MedicalVendorUser).Select(x => x.RoleId);

                        List<string> removedRoleAlias = new List<string>();
                        var removedRoles = currentRoles.Select(x => x).Except(newRoles).ToList();
                        removedRoleAlias = _roleRepository.GetByRoleIds(removedRoles).Select(x => x.Alias).ToList();


                        userEditModel = _userService.Save(userEditModel);

                        ExportToMedicare(userEditModel, removedRoleAlias);

                        userEditModel.Password = null;
                        userEditModel.ConfirmPassword = null;


                        if (userEditModel.PhysicianProfile != null && userEditModel.PhysicianProfile.SignatureFile != null)
                        {
                            var signatureMediaFileLocation = _mediaRepository.GetPhysicianSignatureMediaFileLocation();
                            userEditModel.PhysicianProfile.SignatureFile.Path = signatureMediaFileLocation.Url +
                                                                        userEditModel.PhysicianProfile.SignatureFile.Path;
                        }

                        SetTestsAndPodsForPhysicianProfile(userEditModel);
                        userEditModel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage(string.Format("The user {0} was saved successfully.", userEditModel.FullName));
                        return View(userEditModel);
                    }

                    catch (InvalidAddressException)
                    {
                        SetTestsAndPodsForPhysicianProfile(userEditModel);
                        userEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Unable to save this address. Please check the city, state and zip are valid.");
                        return View(userEditModel);
                    }

                    catch (Exception exception)
                    {
                        SetTestsAndPodsForPhysicianProfile(userEditModel);
                        userEditModel.FeedbackMessage =
                            FeedbackMessageModel.CreateFailureMessage("System Error:" + exception.Message);
                        return View(userEditModel);
                    }
                }
                SetTestsAndPodsForPhysicianProfile(userEditModel);
                return View(userEditModel);
            }
            catch
            {
                SetTestsAndPodsForPhysicianProfile(userEditModel);
                return View(userEditModel);
            }
        }

        private void ExportToMedicare(UserEditModel userEditModel, List<string> removedRoleAlias)
        {
            try
            {
                var canProceed = userEditModel.UsersRoles.Any(
                        x =>
                            x.RoleId == (long)Roles.CallCenterRep || x.RoleId == (long)Roles.Technician ||
                            x.RoleId == (long)Roles.NursePractitioner || x.RoleId == (long)Roles.Coder || x.RoleId == (long)Roles.MedicalVendorUser);
                if (!canProceed && removedRoleAlias != null && !removedRoleAlias.Any())
                    return;

                var roleIds = userEditModel.UsersRoles.Select(x => x.RoleId).ToList();
                var roles = _roleRepository.GetByRoleIds(roleIds);

                //var existRole=_roleRepository.

                var defaultRole = userEditModel.UsersRoles.FirstOrDefault(x => x.IsDefault);
                var defaultRoleAlias = "";
                defaultRoleAlias = defaultRole != null ? roles.First(x => x.Id == defaultRole.RoleId).Alias : roles.First().Alias;

                var token =
                    (Session.SessionID + "_" + _sessionContext.UserSession.UserId + "_" +
                     _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                     _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();
                var settings = IoC.Resolve<ISettings>();


                if (settings.SyncWithHra)
                {
                    var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                    _medicareApiService.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                    var medicareUserEditModel = _medicareService.CreateUserEditModel(userEditModel, defaultRoleAlias, roles.Select(x => x.Alias), removedRoleAlias);
                    _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                    _medicareApiService.Post<bool>(MedicareApiUrl.CreateUpdateUserForEhr, medicareUserEditModel);
                }
                else { _logger.Info("Sync with HRA is Off"); }
               
            }
            catch (Exception exception)
            {
                _logger.Error(
                   string.Format(
                       "Error while Exproting to penguin, \n message: {0} \n stack Trace {1}", exception.Message, exception.StackTrace));
            }
        }


        private void ExportToMedicareForDeActivateUser(long userId, bool isActive, OrganizationRoleUser[] organizationRoleUser)
        {
            try
            {
                var settings = IoC.Resolve<ISettings>();

                if (settings.SyncWithHra)
                {
                    var canProceed = organizationRoleUser.Any(
                        x =>
                            x.RoleId == (long)Roles.CallCenterRep || x.RoleId == (long)Roles.Technician ||
                            x.RoleId == (long)Roles.NursePractitioner || x.RoleId == (long)Roles.Coder || x.RoleId == (long)Roles.MedicalVendorUser);
                    if (!canProceed && !isActive)
                        return;

                    var token =
                        (Session.SessionID + "_" + _sessionContext.UserSession.UserId + "_" +
                         _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                         _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();



                    var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                    _medicareApiService.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);


                    var medicareUserDeActivateModel = _medicareService.DeactivateUserModel(userId, isActive);
                    _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                    _medicareApiService.Post<bool>(MedicareApiUrl.ActivateDeactivateUser, medicareUserDeActivateModel);
                }
                else
                {
                    _logger.Info("Sync with HRA is Off");
                }
                
            }
            catch (Exception exception)
            {
                _logger.Error(
                   string.Format(
                       "Error while Deactivate/Activate user to penguin, \n message: {0} \n stack Trace {1}", exception.Message, exception.StackTrace));
            }
        }

        //
        // GET: /Users/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult IsAvailable(string userName, long excludedUserId = -1)
        {
            if (excludedUserId <= 0)
            {
                return Json(!_userRepository.UserNameExists(userName), JsonRequestBehavior.AllowGet);
            }
            return Json(!_userRepository.UserNameExists(excludedUserId, userName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsEmailUnique(string email, long excludedUserId = -1)
        {
            if (excludedUserId <= 0)
            {
                return Json(_userRepository.UniqueEmail(email), JsonRequestBehavior.AllowGet);
            }
            return Json(_userRepository.UniqueEmail(excludedUserId, email), JsonRequestBehavior.AllowGet);
        }

        private void SendNotificationMail(UserEditModel userEditModel)
        {
            var notifier = IoC.Resolve<INotifier>();
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(userEditModel.UserName, userEditModel.FullName.FullName, userEditModel.DataRecorderMetaData.DateCreated);
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EmployeeWelcomeEmailWithUsername, EmailTemplateAlias.EmployeeWelcomeEmailWithUsername, welcomeEmailViewModel, userEditModel.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

            string resetPasswordQueryString = _cryptographyService.Encrypt(DateTime.Now.ToLongDateString()).Replace("+", "X");
            var welcomePasswordViewModel = emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel(userEditModel.FullName.FullName, userEditModel.Password, resetPasswordQueryString, userEditModel.Id);
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EmployeeWelcomeEmailWithResetMail, EmailTemplateAlias.EmployeeWelcomeEmailWithPassword, welcomePasswordViewModel, userEditModel.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            userLoginRepository.UpdateResetPasswordQueryString(userEditModel.Id, resetPasswordQueryString);
        }

        private void SetTestsAndPodsForPhysicianProfile(UserEditModel model)
        {
            if (model.PhysicianProfile == null)
                model.PhysicianProfile = new PhysicianModel();

            model.PhysicianProfile.Tests = _testRepository.GetReviewableTests().OrderBy(x => x.Name);
            model.PhysicianProfile.Pods = _podRepository.GetAllPods().OrderBy(x => x.Name);

        }

        private Core.Application.Domain.File UploadFile(HttpPostedFileBase file, string physicianName)
        {
            if (string.IsNullOrEmpty(file.FileName)) return null;

            string physicalPath = _mediaRepository.GetPhysicianSignatureMediaFileLocation().PhysicalPath;
            string filename = physicianName + file.FileName.Substring(file.FileName.LastIndexOf("."));
            file.SaveAs(physicalPath + filename);

            var signatureFile = new Core.Application.Domain.File
                                    {
                                        FileSize = file.ContentLength,
                                        Path = filename,
                                        Type = FileType.Image,
                                        UploadedOn = DateTime.Now,
                                        UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                                    };
            return signatureFile;
        }

        public ActionResult SetUserIsActiveStatus(long id, bool isActive)
        {
            try
            {
                var orgRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(id);

                if (!isActive && orgRoleUser != null && orgRoleUser.Count() > 0)
                {
                    var physicianIds = orgRoleUser.Where(org => org.RoleId == (long)Roles.MedicalVendorUser).Select(org => org.Id).ToArray();
                    if (physicianIds.Count() > 0)
                    {
                        if (physicianIds.Any(physicianId => _physicianRepository.IsPhysicianAssignedForFutureEvent(physicianId)))
                        {
                            return Json(new { Result = false, Message = "User is assigned as a physician for future event. You can not deactivate." });
                        }
                    }

                    var technicianIds = orgRoleUser.Where(org => org.RoleId == (long)Roles.Technician).Select(org => org.Id).ToArray();
                    if (technicianIds.Count() > 0)
                    {
                        if (technicianIds.Any(technicianId => _eventStaffAssignmentRepository.IsTechnicianAssignedForFutureEvent(technicianId)))
                        {
                            return Json(new { Result = false, Message = "User is assigned as a technician for future event. You can not deactivate." });
                        }
                    }
                }

                _userRepository.UpdateUserIsActiveStatus(id, isActive);
                _userLoginRepository.UpdateUserLoginIsActiveStatus(id, isActive);
                if (isActive)
                    _organizationRoleUserRepository.ActivateAllOrganizationRolesForUser(id);
                else
                    _organizationRoleUserRepository.DeactivateAllOrganizationRolesForUser(id);

                //  if (orgRoleUser != null && orgRoleUser.Count() > 0)
                ExportToMedicareForDeActivateUser(id, isActive, orgRoleUser);

                return Json(new { Result = true, Message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = "System Failure! " + ex.Message });
            }
        }

        public ActionResult ChangeUserName(long userId)
        {
            var model = new UserNameEditModel
                            {
                                UserId = userId
                            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeUserName(UserNameEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
                    var userNameUpdated = userLoginRepository.UpdateUserName(model.UserId, model.UserName);

                    if (userNameUpdated)
                    {
                        var notifier = IoC.Resolve<INotifier>();
                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                        var customerRepository = IoC.Resolve<ICustomerRepository>();
                        var customer = customerRepository.GetCustomerByUserId(model.UserId);

                        var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(model.UserName, customer.Name.FullName, customer.DateCreated);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, model.UserId, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                        model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("User Name updated uccessfully");

                        return View(model);
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage("System Failure. Message: " + ex.Message);
                return View(model);
            }
        }

        public JsonResult IsNpiExist(string npi, long userId)
        {
            bool isExist = false;
            if (string.IsNullOrEmpty(npi))
            {
                return Json(new { isExist }, JsonRequestBehavior.AllowGet);
            }

            isExist = _userNpiInfoRepository.IsNpiExist(npi, userId);
            return Json(new { isExist }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCredentialExist(string credential, long userId)
        {
            bool isExist = false;
            if (string.IsNullOrEmpty(credential))
            {
                return Json(new { isExist }, JsonRequestBehavior.AllowGet);
            }
            isExist = _userNpiInfoRepository.IsCredentialExist(credential, userId);
            return Json(new { isExist }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsEmployeeIdExist(long userId, string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(!_systemUserInfoRepository.IsEmployeeExist(userId, employeeId), JsonRequestBehavior.AllowGet);
        }
    }
}
