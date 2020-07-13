using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;
using Falcon.App.Core.CallQueues.Domain;
using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;


namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class CallQueueController : Controller
    {
        private readonly ICallQueueService _callQueueService;
        private readonly ISessionContext _sessionContext;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IPreQualifiedQuestionTemplateService _preQualifiedQuestionTemplateService;
        private readonly IEventCustomerQuestionAnswerService _eventCustomerQuestionAnswerService;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IPreQualificationTemplateDependentTestRepository _preQualificationTemplateDependentTestRepository;
        private readonly IUniqueItemRepository<UserLoginLog> _userLoginLogUniqueItemRepository;

        private readonly ISettings _settings;

        private readonly int _pageSize;

        public CallQueueController(ICallQueueService callQueueService, ISessionContext sessionContext, ISettings settings, IOutboundCallQueueService outboundCallQueueService,
            ICallQueueRepository callQueueRepository, ICallQueueCustomerRepository callQueueCustomerRepository, ICallCenterCallRepository callCenterCallRepository,
            ICorporateAccountRepository corporateAccountRepository, IEventRepository eventRepository, IMedicareApiService medicareApiService, IEventCustomerRepository eventCustomerRepository,
            IPreQualifiedQuestionTemplateService preQualifiedQuestionTemplateService, IEventCustomerQuestionAnswerService eventCustomerQuestionAnswerService, IEventTestRepository eventTestRepository,
            IPreQualificationTemplateDependentTestRepository preQualificationTemplateDependentTestRepository, IUniqueItemRepository<UserLoginLog> userLoginLogUniqueItemRepository)
        {
            _callQueueService = callQueueService;
            _sessionContext = sessionContext;
            _pageSize = settings.DefaultPageSizeForReports;
            _outboundCallQueueService = outboundCallQueueService;
            _callQueueRepository = callQueueRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventRepository = eventRepository;
            _medicareApiService = medicareApiService;
            _eventCustomerRepository = eventCustomerRepository;
            _preQualifiedQuestionTemplateService = preQualifiedQuestionTemplateService;
            _eventCustomerQuestionAnswerService = eventCustomerQuestionAnswerService;
            _eventTestRepository = eventTestRepository;
            _preQualificationTemplateDependentTestRepository = preQualificationTemplateDependentTestRepository;
            _userLoginLogUniqueItemRepository = userLoginLogUniqueItemRepository;
            _settings = settings;
        }

        public ActionResult Index(CallQueueListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var model = _callQueueService.GetCallQueueList(pageNumber, _pageSize, filter, out totalRecords) ??
                        new CallQueueListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn =>
                Url.Action(currentAction,
                           new
                           {
                               pageNumber = pn,
                               filter.Name,
                               filter.CriteriaId,
                           });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }


        public ActionResult Create()
        {
            var model = new CallQueueEditModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CallQueueEditModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model = _callQueueService.SaveCallQueue(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                var callQueue = _callQueueRepository.GetById(model.Id);
                var queueCount = _outboundCallQueueService.GetCallQueueCustomers(callQueue).Count;

                ModelState.Clear();
                var newModel = new CallQueueEditModel
                 {

                     FeedbackMessage = queueCount > 0
                     ? FeedbackMessageModel.CreateSuccessMessage(string.Format("Call Queue created sucessfully. You can create more call queue or close this page. Based on the Queue created, currently there are {0} records satisfying the criteria(s).", queueCount))
                     : FeedbackMessageModel.CreateWarningMessage(string.Format("Call Queue created sucessfully. You can create more call queue or close this page. Based on the Queue created, currently there are {0} records satisfying the criteria(s).", queueCount))
                 };
                return View(newModel);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var model = _callQueueService.GetCallQueue(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CallQueueEditModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model = _callQueueService.SaveCallQueue(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                var callQueue = _callQueueRepository.GetById(model.Id);
                var queueCount = _outboundCallQueueService.GetCallQueueCustomers(callQueue).Count;
                model.FeedbackMessage = queueCount > 0
                     ? FeedbackMessageModel.CreateSuccessMessage(string.Format("Call Queue is edited successfully. Based on the updated call queue, currently there are {0} records satisfying the criteria(s).", queueCount))
                     : FeedbackMessageModel.CreateWarningMessage(string.Format("Call Queue is edited successfully. Based on the updated call queue, currently there are {0} records satisfying the criteria(s).", queueCount));

                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                return View(model);
            }
        }

        public ActionResult OutboundCallQueue(long callQueueId, int pageNumber)
        {
            int totalRecords;
            int pageSize = 10;
            var model = _outboundCallQueueService.GetOutboundCallQueueList(callQueueId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, pageNumber, pageSize, out totalRecords);
            if (model == null)
            {
                var isQueueGenerated = true;
                if (callQueueId > 0)
                    isQueueGenerated = _callQueueRepository.GetById(callQueueId).IsQueueGenerated;
                model = new OutboundCallQueueListModel { IsQueueGenerated = isQueueGenerated };
            }

            model.PagingModel = new PagingModel(pageNumber, pageSize, totalRecords, null);
            return View(model);
        }

        public ActionResult SetCallQueueIsActiveState(long callQueueId, bool isActive)
        {
            _callQueueRepository.SetCallQueueIsActiveState(callQueueId, isActive);
            return Content("");
        }

        public ActionResult Call()
        {
            return View();
        }

        public ActionResult RegisterForEvent(long callQueueCustomerId, long eventId, long callId, long attemptId, bool isGmsCall = false, bool isViciCall = false, long previousEventId = 0)
        {
            var guid = Guid.NewGuid().ToString();
            CallQueueCustomer callQueueCustomer = null;
            long customerId = 0;
            long prospectCustomerId = 0;
            long campaignId = 0;

            if (callQueueCustomerId > 0)
            {
                callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
                customerId = callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0;
                prospectCustomerId = callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0;
                campaignId = callQueueCustomer.CampaignId.HasValue ? callQueueCustomer.CampaignId.Value : 0;
            }
            else
            {
                var call = _callCenterCallRepository.GetById(callId);
                customerId = call.CalledCustomerId;
            }

            var registrationFlow = new RegistrationFlowModel
            {
                GuId = guid,
                CallId = callId,
                EventId = eventId,
                CallQueueCustomerId = callQueueCustomerId,
                CustomerId = customerId,
                ProspectCustomerId = prospectCustomerId,
                CampaignId = campaignId,
                AttempId = attemptId,
                IsGmsCall = isGmsCall,
                IsViciCall = isViciCall
            };

            Session[guid] = registrationFlow;


            if (registrationFlow.CustomerId > 0)
            {
                if (previousEventId > 0)
                {
                    _eventCustomerQuestionAnswerService.UpdatePreQualifiedTestAnswers(customerId, eventId, previousEventId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }
                _callCenterCallRepository.UpdateCallCenterCallStatus(CallType.Existing_Customer.ToString().Replace("_", " "), callId);
                string redirectUrl = _settings.AppUrl + "/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=Existing&CustomerID=" + registrationFlow.CustomerId + "&guid=" + guid;
                Response.RedirectUser(redirectUrl);
                return null;
            }
            if (registrationFlow.ProspectCustomerId > 0)
            {
                _callCenterCallRepository.UpdateCallCenterCallStatus(CallType.Register_New_Customer.ToString().Replace("_", " "), callId);
                string redirectUrl = _settings.AppUrl + "/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=New&guid=" + guid;
                Response.RedirectUser(redirectUrl);
                return null;
            }
            return null;
        }

        public ActionResult ChangeAppointment(long callQueueCustomerId, long callId, long attemptId, long eventId)
        {
            var guid = Guid.NewGuid().ToString();
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var registrationFlow = new RegistrationFlowModel
            {
                GuId = guid,
                CallId = callId,
                CallQueueCustomerId = callQueueCustomerId,
                CustomerId = callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0,
                AttempId = attemptId,
                EventId = eventId
            };

            Session[guid] = registrationFlow;


            if (registrationFlow.CustomerId > 0)
            {
                string redirectUrl = _settings.AppUrl + "/App/CallCenter/CallCenterRep/CallCenterRepRescheduleCustomerAppointment.aspx?Call=Yes&EventCustomerID=" + callQueueCustomer.EventCustomerId + "&CustomerID=" + registrationFlow.CustomerId
                    + "&EventID=" + eventId + "&callQueueCustomerId=" + callQueueCustomerId + "&attemptId=" + attemptId + "&guid=" + guid;
                Response.RedirectUser(redirectUrl);
                return null;
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateCustomerVisitInfo(string guid, long visitId)
        {
            
            if (!_settings.SyncWithHra)
            {
                return Json(new { Result = false }, JsonRequestBehavior.DenyGet);
            }
            if (string.IsNullOrEmpty(guid) || Session[guid] == null)
                return Json(new { Result = false }, JsonRequestBehavior.DenyGet);
            var registrationFlowModel = (RegistrationFlowModel)Session[guid];
            registrationFlowModel.AwvVisitId = visitId;

            var account = _corporateAccountRepository.GetbyEventId(registrationFlowModel.EventId);
            if (account != null)
            {
                var theEvent = _eventRepository.GetById(registrationFlowModel.EventId);
                _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                _medicareApiService.Post<long>(MedicareApiUrl.EventInfoUpdateUrl,
                    new MedicareEventEditModel
                    {
                        EventId = registrationFlowModel.EventId,
                        Tag = account.Tag,
                        VisitId = visitId,
                        VisitDate = theEvent.EventDate
                    });
            }
            return Json(new { Result = true }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public bool UpdateVisitStatus(long visitId, int status, bool unlock = true, bool updateAccordinglyIfCancelledOrNoshow = false)
        {
            
            if (_settings.SyncWithHra)
            {
                if (updateAccordinglyIfCancelledOrNoshow)
                {
                    var cstatus = _eventCustomerRepository.IsNoShowOrCancelled(visitId);
                    var isNoShow = cstatus == 1;
                    var isCancelled = cstatus == 2;
                    if (isNoShow)
                        status = 3;
                    if (isCancelled)
                        status = 2;
                }
                _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                return _medicareApiService.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + visitId + "&status=" + status + "&unlock=" + unlock);
            }

            return false;
        }

        [HttpGet]
        public void UnlockMedicarePatient(long visitId)
        {
            if (_settings.SyncWithHra)
            {
                _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                _medicareApiService.Get<bool>(MedicareApiUrl.UnlockPatient + "?visitId=" + visitId + "&ehrUserId=" + _sessionContext.UserSession.UserId + "&roleAlias=" + _sessionContext.UserSession.CurrentOrganizationRole.RoleAlias);
            }

        }

        public ActionResult CustomerDetails(long callQueueCustomerId, long customerId, long callId)
        {
            var guid = Guid.NewGuid().ToString();

            var registrationFlow = new RegistrationFlowModel
            {
                GuId = guid,
                CallId = callId,
                CallQueueCustomerId = callQueueCustomerId,
                CustomerId = customerId
            };

            Session[guid] = registrationFlow;

            Response.RedirectUser(_settings.AppUrl + "/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + customerId + "&guid=" + guid);
            return null;
        }

        [HttpGet]
        public ActionResult GetOutreachCallChart()
        {
            var model = _callQueueService.GetOutreachCallChart();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public PartialViewResult GetPreQualificationQuestion(long[] templateIds)
        {
            if (templateIds == null)
            {
                return PartialView(null);
            }

            IEnumerable<PreQualificationQuestionViewModel> model;
            model = _preQualifiedQuestionTemplateService.GetPreQualificationQuestionsbyTemplateIds(templateIds);
            return PartialView("PreQualificationQuestion", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetEventCustomerQuestionAnswer(long customerId)
        {
            if (customerId > 0)
            {
                var result = _eventCustomerQuestionAnswerService.GetQuestionAnswerTestIdString(customerId, 0);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SavePreQualificationAnswers(EventCustomerQuestionAnswerPostModel model)
        {
            _eventCustomerQuestionAnswerService.SavePreQualifiedTestAnswers(model.QuestionAnswerTestIds, model.DisqualifiedTests, null, model.CustomerId, model.EventId,
                _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public string GetDependentTestsToRemove(long eventId, long testId)
        {
            var eventTest = _eventTestRepository.GetByEventAndTestId(eventId, testId);

            if (eventTest == null || eventTest.PreQualificationQuestionTemplateId == null) return string.Empty;

            var dependentTests = _preQualificationTemplateDependentTestRepository.GetByTemplateId(eventTest.PreQualificationQuestionTemplateId.Value);

            return string.Join(",", dependentTests.Select(x => x.TestId));
        }

        [HttpGet]
        public ActionResult MedicarePopupSessionCheck()
        {
            //this repo call is not required here, but to ensure that session do exist on API as medicare popup hits API and session must exist there.
            var ull = _userLoginLogUniqueItemRepository.GetById(_sessionContext.UserSession.UserLoginLogId);
            if (ull.LogOutDateTime.HasValue)
            {
                return Json(bool.FalseString, JsonRequestBehavior.AllowGet);
            }

            //if it reach here then both API and WEBUI session exists for this user
            return Json(bool.TrueString, JsonRequestBehavior.AllowGet);
        }
    }
}