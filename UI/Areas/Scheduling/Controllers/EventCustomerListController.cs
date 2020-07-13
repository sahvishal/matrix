using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Lib;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    // [RoleBasedAuthorize]
    public class EventCustomerListController : Controller
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IEventMetricsService _eventMetricsService;
        private readonly ISessionContext _sessionContext;
        private readonly IEventCustomerPcpAppointmentService _eventCustomerPcpAppointmentService;
        private readonly IPcpShippingService _pcpShippingService;
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;
        private readonly ICorporateAccountRepository _accountRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly ICustomerBarrierService _customerBarrierService;
        private readonly ICustomerCheckListService _customerCheckListService;
        private readonly ICustomerLeftWithoutScreeningService _customerLeftWithoutScreeningService;
        private readonly ICustomerNotesService _customerNotesService;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ITestResultService _testResultService;


        public EventCustomerListController(IEventCustomerReportingService eventCustomerReportingService, IEventMetricsService eventMetricsService,
            ISessionContext sessionContext, IEventCustomerPcpAppointmentService eventCustomerPcpAppointmentService,
            ILogManager logManager, IPcpShippingService pcpShippingService, IEventRepository eventRepository, ISettings settings,
            ICorporateAccountRepository accountRepository, IEventCustomerRepository eventCustomerRepository, IMedicareApiService medicareApiService, ICustomerRepository customerRepository, ICustomerService customerService,
            ICustomerBarrierService customerBarrierService, ICustomerCheckListService customerCheckListService, ICustomerLeftWithoutScreeningService customerLeftWithoutScreeningService, ICustomerNotesService customerNotesService,
            ICallQueueCustomerRepository callQueueCustomerRepository, ITestResultService testResultService)
        {
            _eventCustomerReportingService = eventCustomerReportingService;
            _eventMetricsService = eventMetricsService;
            _sessionContext = sessionContext;
            _eventCustomerPcpAppointmentService = eventCustomerPcpAppointmentService;
            _pcpShippingService = pcpShippingService;
            _eventRepository = eventRepository;
            _settings = settings;
            _accountRepository = accountRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _medicareApiService = medicareApiService;
            _customerRepository = customerRepository;
            _customerService = customerService;
            _customerBarrierService = customerBarrierService;
            _customerCheckListService = customerCheckListService;
            _customerLeftWithoutScreeningService = customerLeftWithoutScreeningService;
            _customerNotesService = customerNotesService;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _testResultService = testResultService;
            _logger = logManager.GetLogger<EventCustomerListController>();
        }

        [RoleBasedAuthorize]
        public ActionResult Index(long id, EventCustomerListModelFilter filter = null, long customerIdforAcceptPayment = 0, long hId = 0)
        {
            filter = filter ?? new EventCustomerListModelFilter();

            //if (_sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.NursePractitioner))
            //{
            //    if (id > 0)
            //    {
            //        var isValidEvent = _eventRepository.ValidateEventForAccount(id, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
            //        if (!isValidEvent)
            //            Response.RedirectUser("/Home/UnauthorizeAccess");
            //    }
            //}

            var eventCustomerListModel = _eventCustomerReportingService.GetEventCustomerList(id, filter);

            if (customerIdforAcceptPayment > 0)
                eventCustomerListModel.CustomerIdforAcceptPayment = customerIdforAcceptPayment;

            eventCustomerListModel.HighlightCustomerId = 0;
            if (Request != null && Request.UrlReferrer != null && Request.UrlReferrer.AbsoluteUri.Contains("Results/HealthAssessment"))
                eventCustomerListModel.HighlightCustomerId = hId;

            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();
            eventCustomerListModel.HraQuestionerAppUrl = _settings.HraQuestionerAppUrl;
            eventCustomerListModel.OrganizationNameForHraQuestioner = _settings.OrganizationNameForHraQuestioner;
            eventCustomerListModel.Token = (Session.SessionID + "_" + _sessionContext.UserSession.UserId + "_" +
                           _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                           _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();

            eventCustomerListModel.ChatQuestionerAppUrl = eventCustomerListModel.ShowChatQuestionnaire ? _settings.ChatQuestionerAppUrl : string.Empty;

            return View(eventCustomerListModel);
        }

        [RoleBasedAuthorize]
        public ActionResult EventMetrics(long id)
        {
            var eventMetrics = _eventMetricsService.GetEventMetricsViewData(id, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return PartialView(eventMetrics);
        }

        [RoleBasedAuthorize]
        public JsonResult CustomerScreeningTestResultExist(long eventCustomerId)
        {
            return Json(_eventCustomerReportingService.IsCustomerScreeningTestResultExists(eventCustomerId), JsonRequestBehavior.AllowGet);
        }

        [RoleBasedAuthorize]
        public ActionResult PcpAppointment(long eventCustomerId)
        {
            return View(_eventCustomerPcpAppointmentService.GetEventCustomerPcpAppointment(eventCustomerId));
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult PcpAppointment(EventCustomerPcpAppointmentEditModel model)
        {
            var eventCustomerInfo = _eventCustomerPcpAppointmentService.GetEventCustomerEventModel(model.EventCustomerId);
            var generatePdf = false;
            FeedbackMessageModel feedbackMesage = null;

            try
            {
                if (ModelState.IsValid)
                {
                    var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                    _eventCustomerPcpAppointmentService.UpdatePcpAppointmentTime(model, orgRoleUserId);
                    generatePdf = model.Print;
                    feedbackMesage = FeedbackMessageModel.CreateSuccessMessage("Pcp information updated successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Some Error Occured \n Exception Message {0} \t\n Stack Trace: {1}", ex.Message, ex.StackTrace));
                feedbackMesage = FeedbackMessageModel.CreateFailureMessage("Some error occured.");
            }

            eventCustomerInfo.Pcp = model.Pcp;
            eventCustomerInfo.NotAbleToSchedule = model.NotAbleToSchedule;
            model = eventCustomerInfo;
            model.FeedbackMessage = feedbackMesage;

            if (generatePdf)
            {
                var fileName = "PcpAppointment_" + Guid.NewGuid() + ".pdf";
                var mediaLocation = _pcpShippingService.PrintEventCustomerPcpAppointmentForm(model.EventId, model.CustomerId, fileName);
                model.PrintUrl = mediaLocation.Url + fileName;
            }
            return View(model);
        }

        public ActionResult ViewPcpAppointment(long eventId, long customerId, bool print = false)
        {
            var model = _eventCustomerPcpAppointmentService.GetEventCustomerPcpAppointmentViewModel(eventId, customerId);

            return View(model);
        }


        [HttpPost]
        [RoleBasedAuthorize]
        public JsonResult UpdateLeftReason(PatientLeftPostModel model)
        {
            bool isSuccessfull = false;
            try
            {
                if (model.LeftWithoutScreeningReasonId.HasValue && model.LeftWithoutScreeningReasonId.Value > 0)
                {
                    var eventCustomer = _eventCustomerRepository.GetById(model.EventCustomerId);
                    var note = _customerNotesService.SaveCustomerNotes(eventCustomer.CustomerId, eventCustomer.EventId, model.Notes, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                        CustomerRegistrationNotesType.LeftWithoutScreeningNotes, model.LeftWithoutScreeningReasonId);
                    isSuccessfull = _eventCustomerRepository.UpdateLeftReason(model.EventCustomerId, model.LeftWithoutScreeningReasonId, note.Id);
                    if (isSuccessfull)
                        _customerLeftWithoutScreeningService.SendPatientLeftNotification(model.EventCustomerId, model.LeftWithoutScreeningReasonId, model.Notes, _sessionContext.UserSession, "Update Left Reason");
                }
                else
                    isSuccessfull = _eventCustomerRepository.UpdateLeftReason(model.EventCustomerId, null, null);
            }
            catch (Exception ex)
            {
                _logger.Error("error while SetPatientLeftReason");
                _logger.Error("exception Message: " + ex.Message);
                _logger.Error("stack Trace " + ex.StackTrace);
            }

            return Json(isSuccessfull, JsonRequestBehavior.AllowGet);

        }

        [RoleBasedAuthorize]
        [HttpPost]
        public long UpdateCustomerVisitInfo(long customerId, long visitId, long eventId)
        {
            var account = _accountRepository.GetbyEventId(eventId);
            if (account != null)
            {
                var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
                if (!eventCustomer.AwvVisitId.HasValue)
                {
                    eventCustomer.AwvVisitId = visitId;
                    _eventCustomerRepository.Save(eventCustomer);
                }
                
                if (_settings.SyncWithHra)
                {
                    var theEvent = _eventRepository.GetById(eventId);
                    try
                    {
                        _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                    }
                    catch (Exception)
                    {
                        var userSession = _sessionContext.UserSession;
                        var token = (Session.SessionID + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                        var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = _settings.OrganizationNameForHraQuestioner, Tag = _settings.OrganizationNameForHraQuestioner, IsForAdmin = false, RoleAlias = "CallCenterRep" };
                        _medicareApiService.PostAnonymous<string>(_settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                        _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                    }
                    _medicareApiService.Post<long>(MedicareApiUrl.EventInfoUpdateUrl,
                        new MedicareEventEditModel
                        {
                            EventId = eventId,
                            Tag = account.Tag,
                            VisitId = visitId,
                            VisitDate = theEvent.EventDate
                        });   
                }

                return eventCustomer.Id;
            }
            return 0;
        }
        [RoleBasedAuthorize]
        [HttpPost]
        public long UpdateMedicareVisitStatus(long eventCustomerId, bool isNoShowMarked)
        {
            
            if (_settings.SyncWithHra)
            {
                var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
                if (eventCustomer.AwvVisitId.HasValue)
                {
                    try
                    {
                        _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                    }
                    catch (Exception)
                    {
                        var userSession = _sessionContext.UserSession;
                        var token = (Session.SessionID + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                        var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = _settings.OrganizationNameForHraQuestioner, Tag = _settings.OrganizationNameForHraQuestioner, IsForAdmin = false, RoleAlias = "CallCenterRep" };
                        _medicareApiService.PostAnonymous<string>(_settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                        _medicareApiService.Connect(_sessionContext.UserSession.UserLoginLogId);
                    }


                    if (isNoShowMarked)
                    {
                        _medicareApiService.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.NoShow + "&unlock=true");
                    }
                    else
                    {
                        if (_testResultService.IsTestPurchasedByCustomer(eventCustomerId, (long)TestType.eAWV))
                        {
                            _medicareApiService.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.Visited + "&unlock=true");
                        }
                    }
                }

                return eventCustomer.Id;
            }
            return eventCustomerId;
        }

        [HttpGet]
        [RoleBasedAuthorize]
        public ActionResult EnableTexting(long eventCustomerId, long customerId)
        {
            return PartialView(EnableTextingModel(eventCustomerId, customerId));
        }

        [HttpGet]
        [RoleBasedAuthorize]
        public ActionResult UpdateEnableTexting(long eventCustomerId, long customerId)
        {
            return PartialView(EnableTextingModel(eventCustomerId, customerId));
        }

        private EnableTextingEditModel EnableTextingModel(long eventCustomerId, long customerId)
        {
            EnableTextingEditModel model = new EnableTextingEditModel();
            var eventCustomerDetails = _eventCustomerRepository.GetById(eventCustomerId);
            var customer = _customerRepository.GetCustomer(customerId);
            model.EnableTexting = eventCustomerDetails.EnableTexting;
            model.PhoneCell = customer.MobilePhoneNumber;
            model.CustomerId = customer.CustomerId;

            return model;
        }

        [HttpPost]
        [RoleBasedAuthorize]
        public ActionResult UpdateEnableTexting(EnableTextingEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EnableTexting)
                    {
                        var commonCode = new CommonCode();
                        var customer = _customerRepository.GetCustomer(model.CustomerId);
                        customer.MobilePhoneNumber = model.PhoneCell;
                        _customerService.SaveCustomer(customer, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    }
                    _eventCustomerRepository.UpdateEnableTextingById(model.EventCustomerId, model.EnableTexting);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Updated successfully");
                }
                else
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateWarningMessage("validation fails");
                }

            }
            catch (Exception ex)
            {
                _logger.Error("error while updating enable Texting Info");
                _logger.Error("exception Message: " + ex.Message);
                _logger.Error("stack Trace " + ex.StackTrace);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("failed to update. Please try again.");
            }
            return PartialView(model);
        }

        [RoleBasedAuthorize]
        public ActionResult AddBarrierForCustomer(long eventCustomerId)
        {
            return View(_customerBarrierService.GetCustomerBarrier(eventCustomerId));
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public ActionResult AddBarrierForCustomer(BarrierEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerBarrierService.Save(model);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Customer Barrier has been saved successfully!");
                }
                catch (Exception ex)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(string.Format("System Failure! Message: {0}", ex.Message));
                    _logger.Info(string.Format(" Message: {0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                }

            }
            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpGet]
        public ActionResult CustomerCheckListForm(long customerId, long eventId)
        {
            var model = _customerCheckListService.GetCustomerCheckListEdtiModel(customerId, eventId);
            var currentOrgRole = _sessionContext.UserSession.CurrentOrganizationRole;

            if (model.IsEditable)
            {
                model.IsEditable = (currentOrgRole.CheckRole((long)Roles.Technician) || currentOrgRole.CheckRole((long)Roles.NursePractitioner));
            }

            return View(model);
        }

        [RoleBasedAuthorize]
        [HttpGet]
        public ActionResult CheckListForm(long customerId, long eventId)
        {
            var model = _customerCheckListService.GetCustomerCheckListEdtiModel(customerId, eventId);
            var currentOrgRole = _sessionContext.UserSession.CurrentOrganizationRole;

            if (model.IsEditable)
            {
                model.IsEditable = (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.Technician) || currentOrgRole.CheckRole((long)Roles.NursePractitioner));
            }

            return PartialView(model);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public bool SaveChecklistAnswers(CheckListAnswerEditModel model)
        {
            try
            {
                if (model != null && !model.Answers.IsNullOrEmpty())
                {
                    model.Answers = model.Answers.Where(x => x != null);
                    
                    var token = (Session.SessionID + "_" + _sessionContext.UserSession.UserId + "_" + _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" + _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();
                    _customerCheckListService.SaveCheckListAnswer(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, _sessionContext.UserSession.UserLoginLogId, token);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format(" Message: {0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                return false;
            }
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public JsonResult UpdateGiftCertificate(UpdateGiftCertificatePostModel model)
        {
            bool isSuccessfull = false;
            try
            {
                if (model.IsGiftCertificateDelivered)
                    isSuccessfull = _eventCustomerRepository.UpdateGiftCertificate(model.EventCustomerId, model.GiftCode, null);
                else
                    isSuccessfull = _eventCustomerRepository.UpdateGiftCertificate(model.EventCustomerId, null, model.GcNotGivenReasonId);
            }
            catch (Exception ex)
            {
                _logger.Error("error while UpdateGiftCertificate");
                _logger.Error("exception Message: " + ex.Message);
                _logger.Error("stack Trace " + ex.StackTrace);
            }

            return Json(isSuccessfull, JsonRequestBehavior.AllowGet);
        }

        [RoleBasedAuthorize]
        public JsonResult CanMarkedAsLeftWithoutScreening(long eventCustomerId)
        {
            return Json(_eventCustomerReportingService.CanMarkedAsLeftWithoutScreening(eventCustomerId), JsonRequestBehavior.AllowGet);
        }

        [RoleBasedAuthorize]
        [HttpPost]
        public JsonResult ConfirmAppointment(long customerId, long eventCustomerId, long? callId = null)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
            eventCustomer.IsAppointmentConfirmed = true;
            eventCustomer.ConfirmedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            _eventCustomerRepository.Save(eventCustomer);

            _callQueueCustomerRepository.UpdateConfirmationQueueCustomers(customerId, eventCustomerId, callId.HasValue ? callId.Value : 0);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
