using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.UI.Filters;


namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class PreAssessmentCallQueueController : Controller
    {
        private readonly ILogger _logger;

        private readonly IPreAssessmentCallQueueService _preAssessmentCallQueueService;
        private readonly ISessionContext _sessionContext;
        private readonly IPrimaryCarePhysicianHelper _primaryCarePhysicianHelper;
        private readonly ICallOutcomeService _callOutcomeService;
        private readonly ITagRepository _tagRepository;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ICallCenterCallRepository _callCenterCallRepository;


        private readonly IPreAssessmentCustomerCallQueueCallAttemptRepository _preAssessmentCustomerCallQueueCallAttemptRepository;
        private readonly ICustomerService _customerService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventService _eventService;
        private readonly ISmsHelper _smsHelper;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;

        public PreAssessmentCallQueueController(ILogManager logManager, ISessionContext sessionContext, IPrimaryCarePhysicianHelper primaryCarePhysicianHelper,
       ICallOutcomeService callOutcomeService, ITagRepository tagRepository, IOutboundCallQueueService outboundCallQueueService, ICallCenterCallRepository callCenterCallRepository,
      IPreAssessmentCustomerCallQueueCallAttemptRepository preAssessmentCustomerCallQueueCallAttemptRepository, ICustomerService customerService, IEventCustomerRepository eventCustomerRepository, IAppointmentRepository appointmentRepository,
      IEventService eventService, ISmsHelper smsHelper, IProspectCustomerRepository prospectCustomerRepository, IPreAssessmentCallQueueService preAssessmentCallQueueService
      )
        {
            _logger = logManager.GetLogger("PreAssessmentCallQueueController");
            _sessionContext = sessionContext;
            _primaryCarePhysicianHelper = primaryCarePhysicianHelper;
            _callOutcomeService = callOutcomeService;
            _tagRepository = tagRepository;
            _outboundCallQueueService = outboundCallQueueService;
            _callCenterCallRepository = callCenterCallRepository;

            _preAssessmentCustomerCallQueueCallAttemptRepository = preAssessmentCustomerCallQueueCallAttemptRepository;
            _customerService = customerService;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _eventService = eventService;
            _smsHelper = smsHelper;
            _prospectCustomerRepository = prospectCustomerRepository;
            _preAssessmentCallQueueService = preAssessmentCallQueueService;

        }

        public ActionResult PreAssessmentCall(long customerId, long callQueueId, long eventId, long callId = 0)
        {
            try
            {
                if (callQueueId < 1 || eventId < 1 || customerId < 1)
                {
                    _logger.Info(string.Format("Invalid data in parameters , CallQueueId {0}, EventId {1} ,CustomerId {2}", callQueueId, eventId, customerId));
                    const string s = "Cannot start call, invalid data provided";
                    return View("ErrorPage", model: s);
                }

                if (callId == 0)
                {
                    callId = _preAssessmentCallQueueService.StartCallForPreAssessment(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, customerId, eventId, callQueueId);

                    if (callId == 0)
                    {
                        _logger.Info(string.Format("Patient Not Found:  Customer Id {0}", customerId));
                        const string s = "Cannot start call for this customer";
                        return View("ErrorPage", model: s);
                    }

                    return RedirectToAction("PreAssessmentCall", new
                    {
                        customerId = customerId,
                        eventId = eventId,
                        callQueueId = callQueueId,
                        callId = callId
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception Message: {0} for Customer Id {1} \n Stack Trace: {2}", ex.Message, customerId, ex.StackTrace));
                const string s = "Cannot start call for this customer";
                return View("ErrorPage", model: s);
            }

            try
            {
                var model = _preAssessmentCallQueueService.GetByCustomerId(customerId, callId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.IsCalledForVici = true;
                //To open HRA
                model.EventInformation.Token = (Session.SessionID + "_" + _sessionContext.UserSession.UserId + "_" +
                           _sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                           _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception Message: {0}\nStack Trace: {1}", ex.Message, ex.StackTrace));
                const string s = "Customer not found";
                return View("ErrorPage", model: s);
            }
        }
        [HttpPost]
        public ActionResult SavePatientInfoPreAssessment(CallQueueCustomerEditModel model)
        {
            if (ModelState.IsValid)
            {
                _preAssessmentCallQueueService.UpdateCustomerData(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                if (model.IsHealthPlanQueue)
                {
                    _primaryCarePhysicianHelper.UpdatePrimaryCarePhysician(model.PrimaryCarePhysician, model.CustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }

            }
            var viewModel = _preAssessmentCallQueueService.GetByCustomerId(model.CustomerId, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            if (!ModelState.IsValid)
            {
                viewModel.HasError = true;
                viewModel.PatientInfoEditModel = model;
            }
            return PartialView("GetPatientInfoPreAssessment", viewModel);
        }

        [HttpPost]
        public ActionResult SaveCallOutComePreAssessment(CallOutComeEditModel model)
        {
            _callOutcomeService.SaveCallOutCome(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            var viewModel = _preAssessmentCallQueueService.GetByCustomerId(model.CustomerId, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return PartialView("GetPatientInfoPreAssessment", viewModel);
        }

        public JsonResult GetCallDispositionTags()
        {
            var model = _tagRepository.GetForPreAssessmentTags(Core.Sales.Enum.ProspectCustomerSource.CallCenter, true).OrderBy(x => x.Name);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetCallOutComePreAssessment(long callId, long callQueueCustomerId, long prospectCustomerId, long customerId)
        {
            var model = _callOutcomeService.GetCallOutCome(callId, callQueueCustomerId, customerId);
            return PartialView(model);
        }

        public PartialViewResult GetCallHistoryDetailsPreAssessment(long callId, long callQueueCustomerId)
        {
            var model = _outboundCallQueueService.GetCustomerNotes(callId, callQueueCustomerId);
            return PartialView(model);
        }
        public bool UpdateCallersPhoneNumber(long callId, string patientPhoneNumber)
        {
            return _callCenterCallRepository.UpdateCallersPhoneNumber(callId, patientPhoneNumber.Replace("-", ""));
        }

        [HttpPost]
        public bool EndHealthPlanActiveCall(EndHealthPlanCallEditModel model)
        {
            var isCallQueueRequsted = false;
            var removeFromCallQueue = false;
            long customerId = 0;

            var call = _callCenterCallRepository.GetById(model.CallId);
            var eventCustomer = _eventCustomerRepository.Get(call.EventId, call.CalledCustomerId);

            customerId = call.CalledCustomerId;

            //update call status in CustomerCallQueueCallAttempt Table
            if (model.IsSkipped && model.AttemptId > 0)
            {
                var attempt = _preAssessmentCustomerCallQueueCallAttemptRepository.GetByCallId(model.CallId);
                attempt.IsCallSkipped = true;

                if (!string.IsNullOrEmpty(model.SkipCallNote))
                {
                    attempt.SkipCallNote = model.SkipCallNote;
                }
                _preAssessmentCustomerCallQueueCallAttemptRepository.Save(attempt);
            }

            else if (model.CallId != 0)
            {

                if (model.CallId > 0)
                {
                    if (call != null && call.Status == (long)CallStatus.TalkedtoOtherPerson)
                    {
                        removeFromCallQueue = true;
                    }
                }
                if (!string.IsNullOrEmpty(model.SelectedDisposition))
                {
                    var tag = (ProspectCustomerTag)System.Enum.Parse(typeof(ProspectCustomerTag), model.SelectedDisposition);
                    if (tag == ProspectCustomerTag.CallBackLater)
                    { isCallQueueRequsted = true; }
                    else if (tag == ProspectCustomerTag.BookedAppointment || tag == ProspectCustomerTag.HomeVisitRequested || tag == ProspectCustomerTag.MobilityIssue
                        || tag == ProspectCustomerTag.DoNotCall || tag == ProspectCustomerTag.Deceased || tag == ProspectCustomerTag.NoLongeronInsurancePlan
                        || tag == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther || tag == ProspectCustomerTag.DebilitatingDisease || tag == ProspectCustomerTag.InLongTermCareNursingHome
                        || tag == ProspectCustomerTag.PatientConfirmed || tag == ProspectCustomerTag.CancelAppointment || tag == ProspectCustomerTag.ConfirmLanguageBarrier)
                    {
                        removeFromCallQueue = true;
                    }

                    if (tag == ProspectCustomerTag.LanguageBarrier && customerId > 0)
                    {
                        _customerService.UpdateIsLanguageBarrier(customerId, true, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    }

                    if (tag == ProspectCustomerTag.IncorrectPhoneNumber && customerId > 0)
                    {
                        _customerService.UpdateIsIncorrectPhoneNumber(customerId, true, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    }

                    if (tag == ProspectCustomerTag.PatientConfirmed && call != null && eventCustomer.Id > 0)
                    {

                        eventCustomer.IsAppointmentConfirmed = true;
                        eventCustomer.ConfirmedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                        _eventCustomerRepository.Save(eventCustomer);
                    }
                }

                var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                _preAssessmentCallQueueService.EndActiveCall(customerId, model.CallId, isCallQueueRequsted, orgRoleUserId, removeFromCallQueue, model.CallOutcomeId, model.SkipCallNote);

            }
            return true;
        }

    }
}