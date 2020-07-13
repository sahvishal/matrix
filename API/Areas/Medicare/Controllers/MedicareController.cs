using System.Threading.Tasks;
using API.Areas.Application.Controllers;
using API.Areas.Users.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Areas.Medicare.Controllers
{
    public class MedicareController : BaseController
    {
        private readonly ISessionContext _sessionContext;
        private readonly IMedicareService _medicareService;
        private readonly IMedicareOrderService _medicareOrderService;
        private readonly UserService _userService;
        private readonly IRoleRepository _roleRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerCheckListService _customerCheckListService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        
        private readonly ITestResultService _testResultService;
        private readonly ILogger _logger;

        public MedicareController(ISessionContext sessionContext, IMedicareService medicareService,
            IMedicareOrderService medicareOrderService, UserService userService, IRoleRepository roleRepository, IEventCustomerRepository eventCustomerRepository,
            ICustomerCheckListService customerCheckListService, ILogManager logManager, ITestResultService testResultService,
            IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            ValidateToken();
            _sessionContext = sessionContext;
            _medicareService = medicareService;
            _medicareOrderService = medicareOrderService;
            _userService = userService;
            _roleRepository = roleRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerCheckListService = customerCheckListService;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            
            _testResultService = testResultService;
            _logger = logManager.GetLogger<LoginController>();
        }

        private void ValidateToken()
        {
            var currentPrivateToken = HttpContext.Current.Request.Headers["Penguin-token"];
            if (string.IsNullOrEmpty(currentPrivateToken))
                throw new Exception("Invalid medicare token.");

            var decryptedToken = currentPrivateToken.Decrypt();
            var userData = decryptedToken.Split('_');
            if (userData.Length != 5)
            {
                throw new InvalidDataException("Invalid medicare token.");
            }
            // var sessionId = userData[3];
            var userId = long.Parse(userData[1]);
            // var roleId = long.Parse(userData[0]);
            // var organizationId = long.Parse(userData[2]);
            var currentTimestamp = userData[4];
            var _userLoginLogRepository = IoC.Resolve<IUserLoginLogRepository>();
            var currentUserLog = _userLoginLogRepository.GetCurrentLoggedInLogforUser(userId);
            if (currentUserLog == null) throw new Exception("Invalid medicare token.");

            if (!string.IsNullOrEmpty(currentUserLog.MedicareToken))
            {
                var decriptedExistingToken = currentUserLog.MedicareToken.Decrypt();
                var tokenData = decriptedExistingToken.Split('_');
                if (tokenData.Length != 5 || currentTimestamp == tokenData[4]) throw new Exception("Invalid medicare token.");

            }

            var uniqueItemRepository = IoC.Resolve<IUniqueItemRepository<UserLoginLog>>();
            currentUserLog.MedicareToken = currentPrivateToken;
            uniqueItemRepository.Save(currentUserLog);

        }

        [HttpPost]
        public MedicareUserViewModel AuthenticateUser()
        {
            var model = _medicareService.GetUser(_sessionContext.UserSession.UserId);
            model.RoleAlias = _sessionContext.UserSession.CurrentOrganizationRole.RoleAlias;
            return model;
        }

        [HttpPost]
        public MedicareCustomerViewModel GetCustomerDetails(long customerId)
        {
            return _medicareService.GetCustomerDetails(customerId);
        }

        [HttpPost]
        public MedicareEventCustomerViewModel GetEventCustomerDetails(long customerId, long eventId)
        {
            return _medicareService.GetEventCustomerDetails(customerId, eventId);
        }

        [HttpPost]
        public bool UpdateCustomerDetails([FromBody]MedicareCustomerViewModel model)
        {
            model.UpdatedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            return _medicareService.UpdateCustomerDetails(model);
        }

        [HttpPost]
        public bool AddPatientTestFromEhr(MedicareTestRecommendationListModel testAliasList)
        {
            var testids = _medicareService.GetTestListByAliasList(testAliasList.Alias).ToList();
            _medicareOrderService.AddMissingTestToEvent(testAliasList.EventId, testids.Select(x => x.FirstValue));
            return _medicareOrderService.ChangePackage(testAliasList.EventId, testAliasList.CustomerId, testids.Select(x => x.FirstValue));
        }

        [HttpGet]
        public MedicareUserEditModel GetEhrUserForMedicare(long id)
        {
            var userEditModel = _userService.Get(id);
            var defaultRole = userEditModel.UsersRoles.FirstOrDefault(x => x.IsDefault);
            var roelIds = userEditModel.UsersRoles.Select(x => x.RoleId).ToList();
            var roles = _roleRepository.GetByRoleIds(roelIds);
            var defaultRoleAlias = "";
            defaultRoleAlias = defaultRole != null ? roles.First(x => x.Id == defaultRole.RoleId).Alias : roles.First().Alias;
            return _medicareService.CreateUserEditModel(userEditModel, defaultRoleAlias, roles.Select(x => x.Alias), new List<string>());
        }

        [HttpPost]
        public MedicareLogoutModel Logout(MedicareLogoutModel model)
        {
            try
            {
                var sessionContext = IoC.Resolve<ISessionContext>();
                if (sessionContext == null || sessionContext.UserSession == null)
                    return new MedicareLogoutModel();

                var repository = IoC.Resolve<IUserLoginLogRepository>();
                var singleSessionHelper = IoC.Resolve<ISingleSessionHelper>();


                var tkn = model.EhrToken.Decrypt();
                var userData = tkn.Split('_');
                var username = _sessionContext.UserSession.UserName;
                singleSessionHelper.RemoveUserSessionFromCache(_sessionContext.UserSession.UserName, userData[0]);

                repository.UpdateLogOutTimeforUser(_sessionContext.UserSession.UserLoginLogId);
                _logger.Info("Logout form Medicare API call , User name : " + username);
            }
            catch (Exception ex)
            {
                _logger.Error("error while logout from Medicare API controller");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

            model.EhrToken = "";
            return model;
        }

        [HttpPost]
        public bool SaveCheckList(MedicareStandingOrderViewModel standingOrder)
        {
            _logger.Info("Saving CheckList from HRA for Visit : " + standingOrder.PatientVisitId + ", version :" + standingOrder.Version + "-> Started");
            var evtCust = _eventCustomerRepository.GetByMedicareVisitId(standingOrder.PatientVisitId);
            if (evtCust != null)
            {
                var model = new CheckListAnswerEditModel();
                model.EventCustomerId = evtCust.Id;
                model.Answers = standingOrder.Questions.Select(ques => new CheckListQuestionAnswerEditModel { QuestionId = ques.QuestionId, Answer = ques.Answer }).ToList();
                _customerCheckListService.SaveCheckListAnswer(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, _sessionContext.UserSession.UserLoginLogId, "");
            }
            _logger.Info("Saving CheckList from HRA for Visit : " + standingOrder.PatientVisitId + ", version :" + standingOrder.Version + "-> Completed");
            return true;
        }

        [HttpPost]
        public bool SaveCustomerResultSigned(MedicareCustomerResultSignedNPViewModel model)
        {
            _logger.Info("Method called : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
            {
                _logger.Error(string.Format("No OrganizationRoleUser found for username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method Completed : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            if (orgRoleUser.RoleId != (long)Roles.NursePractitioner)
            {
                _logger.Error(string.Format("Provided role is not NursePractitioner. username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method Completed : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            var isUpdated = _testResultService.SaveCustomerResultSigned(model, orgRoleUser);

            if (isUpdated)
            {
                _logger.Info(string.Format("EventCustomerResult Signed saved successfully for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                _logger.Info("Method Completed : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                
            }
            else
            {
                _logger.Info(string.Format("EventCustomerResult Chart Not Signed for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
                _logger.Info("Method Completed : SaveCustomerResultSigned for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            }

            return isUpdated;
        }

        [HttpPost]
        public bool SaveCustomerResultAfterEvaluation(MedicareCustomerResultVerifiedViewModel model)
        {
            _logger.Info("Method called : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
            {
                _logger.Error(string.Format("No OrganizationRoleUser found for username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completd : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            if (orgRoleUser.RoleId != (long)Roles.NursePractitioner)
            {
                _logger.Error(string.Format("Provided role is not NursePractitioner. username: {0}, roleAlias: {1},  CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completd : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            _logger.Info(string.Format("EventCustomerResult NpSigned saved successfully for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));

            var isSaved = _testResultService.SaveCustomerResultAfterNpReview(model, orgRoleUser);
            
            _logger.Info("Method completed : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            return isSaved;
        }

        [HttpPost]
        public bool SaveCustomerResultCoded(MedicareCustomerResultCodedViewModel model)
        {
            _logger.Info("Method called : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);

            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
            {
                _logger.Error(string.Format("No OrganizationRoleUser found for username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completd : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            if (orgRoleUser.RoleId != (long)Roles.Coder)
            {
                _logger.Error(string.Format("Provided role is not Coder. username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completd : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            _testResultService.SaveCustomerResultCoded(model, orgRoleUser);

            _logger.Info(string.Format("EventCustomerResult Coding saved successfully for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));
            _logger.Info("Method completd : SaveCustomerResultAfterEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            return true;
        }

        [HttpPost]
        public bool RevertToPreAudit(EhrRevertToPreAuditStateViewModel model)
        {
            _logger.Info("Method called : RevertToPreAudit for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
            {
                _logger.Error(string.Format("No OrganizationRoleUser found for username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completed : RevertToPreAudit for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            if (orgRoleUser.RoleId != (long)Roles.Coder)
            {
                _logger.Error(string.Format("Provided role is not NursePractitioner. username: {0}, roleAlias: {1},  CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completed : RevertToPreAudit for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.ResultEntryCompleted, false, orgRoleUser.Id);

            _logger.Info(string.Format("Undo PreAudit Has been marked successfully. Method completed : RevertToPreAudit for CustomerId: {0}, EventId: {1}", model.CustomerId, model.EventId));


            return true;
        }

        [HttpPost]
        public bool RevertToNpReviewState(EhrRevertToNpReviewViewModel model)
        {
            _logger.Info("Method called : RevertToNpReviewState for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
            {
                _logger.Error(string.Format("No OrganizationRoleUser found for username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completed : RevertToNpReviewState  for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            if (orgRoleUser.RoleId != (long)Roles.Coder)
            {
                _logger.Error(string.Format("Provided role is not Coder. username: {0}, roleAlias: {1},  CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completed : RevertToNpReviewState for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.NpNotificationSent, false, orgRoleUser.Id);

            _logger.Info("Method completed : RevertToNpReviewState for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);

            return true;
        }

        [HttpPost]
        public bool RevertToPhysicianEvaluation(EhrRevertToPhysicianEvaluationViewMoel model)
        {
            _logger.Info("Method called : RevertToPhysicianEvaluation for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
            var orgRoleUser = _organizationRoleUserRepository.GetByUserNameAndRoleAlias(model.UserName, model.RoleAlias);
            if (orgRoleUser == null)
            {
                _logger.Error(string.Format("No OrganizationRoleUser found for username: {0}, roleAlias: {1}, CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completed : RevertToPhysicianEvaluation State for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            if (orgRoleUser.RoleId != (long)Roles.NursePractitioner)
            {
                _logger.Error(string.Format("Provided role is not Coder. username: {0}, roleAlias: {1},  CustomerId: {2}, EventId: {3}", model.UserName, model.RoleAlias, model.CustomerId, model.EventId));
                _logger.Info("Method completed : RevertToPhysicianEvaluation State for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);
                return false;
            }

            _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.PreAudit, false, orgRoleUser.Id);

            _logger.Info("Method completed : RevertToPhysicianEvaluation State for CustmerId: " + model.CustomerId + " EventId: " + model.EventId);

            return true;
        }
    }
}
