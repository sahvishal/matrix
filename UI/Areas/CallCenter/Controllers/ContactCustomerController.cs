using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using System.Web.Mvc;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{

    [RoleBasedAuthorize]
    public class ContactCustomerController : Controller
    {
        private readonly ICallQueueCustomerContactService _callQueueCustomerContactService;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ITagRepository _tagRepository;
        private readonly ICallOutcomeService _callOutcomeService;
        private readonly IEventService _eventService;
        private readonly ISessionContext _sessionContext;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly IPrimaryCarePhysicianHelper _primaryCarePhysicianHelper;
        private readonly ICityRepository _cityRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICustomerService _customerService;
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IPreQualificationTestTemplateRepository _preQualificationTestTemplateRepository;
        private readonly ISmsHelper _smsHelper;
        private readonly ILogger _logger;

        private const int PageSize = 10;
        private static readonly string[] DaylightSavingNotApplicableStates = { "Arizona" };

        public ContactCustomerController(ICallQueueCustomerContactService callQueueCustomerContactService, IOutboundCallQueueService outboundCallQueueService, ITagRepository tagRepository, ICallOutcomeService callOutcomeService,
            IEventService eventService, ISessionContext sessionContext, IPrimaryCarePhysicianHelper primaryCarePhysicianHelper, ICityRepository cityRepository, IEventSchedulerService eventSchedulerService,
            ICallQueueCustomerRepository callQueueCustomerRepository, IEventCustomerRepository eventCustomerRepository, IProspectCustomerRepository prospectCustomerRepository, ICustomerService customerService,
            ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository, ISmsHelper smsHelper, IAppointmentRepository appointmentRepository, ICallCenterCallRepository callCenterCallRepository, ILogManager logManager, 
            IPreApprovedTestRepository preApprovedTestRepository, IEventTestRepository eventTestRepository, IPreQualificationTestTemplateRepository preQualificationTestTemplateRepository)
        {
            _callQueueCustomerContactService = callQueueCustomerContactService;
            _outboundCallQueueService = outboundCallQueueService;
            _tagRepository = tagRepository;
            _callOutcomeService = callOutcomeService;
            _eventService = eventService;
            _sessionContext = sessionContext;
            _primaryCarePhysicianHelper = primaryCarePhysicianHelper;
            _cityRepository = cityRepository;
            _eventSchedulerService = eventSchedulerService;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _customerService = customerService;
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _smsHelper = smsHelper;
            _appointmentRepository = appointmentRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _eventTestRepository = eventTestRepository;
            _preQualificationTestTemplateRepository = preQualificationTestTemplateRepository;
            _logger = logManager.GetLogger("ContactCustomerController");
        }

        public ActionResult GetCustomerContactView(long customerId, long callId = 0)
        {
            try
            {
                if (callId == 0)
                {
                    callId = _callQueueCustomerContactService.StartCall(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, customerId);

                    if (callId == 0)
                    {
                        _logger.Info(string.Format("GMS Patient Not Found:  Customer Id {0}", customerId));
                        const string s = "Cannot start call for this customer";
                        return View("ErrorPage", model: s);
                    }

                    return RedirectToAction("GetCustomerContactView", new
                    {
                        customerId = customerId,
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
                var model = _callQueueCustomerContactService.GetByCustomerId(customerId, callId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception Message: {0}\nStack Trace: {1}", ex.Message, ex.StackTrace));
                const string s = "Customer not found";
                return View("ErrorPage", model: s);
            }
        }

        public PartialViewResult GetScreeningInfo(long customerId)
        {
            var model = _callQueueCustomerContactService.GetCustomerMedicalHistory(customerId);
            return PartialView(model);
        }

        public PartialViewResult GetEventList(EventSearchFilterCallQueueCustomer filter)
        {
            filter = filter ?? new EventSearchFilterCallQueueCustomer();
            filter.Radius = filter.Radius ?? 25;
            filter.AgentOrganizationId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            filter.ShowFutureEvents = true;

            filter.PageSize = filter.PageSize > 0 ? filter.PageSize : PageSize;

            int totalCount;
            var list = _eventService.SearchEventForCallCenter(filter, out totalCount);
            var model = new EventHostListModel
            {
                Events = list,
                Filter = filter,
                PagingModel = new PagingModel(filter.PageNumber, filter.PageSize, totalCount, null)
            };
            return PartialView(model);
        }

        public PartialViewResult GetCallHistoryDetails(long callId, long callQueueCustomerId)
        {
            var model = _outboundCallQueueService.GetCustomerNotes(callId, callQueueCustomerId);
            return PartialView(model);
        }

        public PartialViewResult GetCallOutCome(long callId, long callQueueCustomerId, long prospectCustomerId, long customerId)
        {
            var model = _callOutcomeService.GetCallOutCome(callId, callQueueCustomerId, customerId);
            return PartialView(model);
        }

        public JsonResult GetReadAndUnderstood(long callId)
        {
            _outboundCallQueueService.SetReadAndUnderstoodNotes(callId);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCallDispositionTags()
        {
            var model = _tagRepository.GetTags(Core.Sales.Enum.ProspectCustomerSource.CallCenter, true).OrderBy(x => x.Name);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool SetReadAndUnderstoodNotes(long callId)
        {
            _outboundCallQueueService.SetReadAndUnderstoodNotes(callId);
            return true;
        }

        [HttpPost]
        public ActionResult SavePatientInfo(CallQueueCustomerEditModel model)
        {
            if (ModelState.IsValid)
            {
                _callQueueCustomerContactService.UpdateCustomerData(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                if (model.IsHealthPlanQueue)
                {
                    _primaryCarePhysicianHelper.UpdatePrimaryCarePhysician(model.PrimaryCarePhysician, model.CustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }

            }
            var viewModel = _callQueueCustomerContactService.GetByCustomerId(model.CustomerId, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            if (!ModelState.IsValid)
            {
                viewModel.HasError = true;
                viewModel.PatientInfoEditModel = model;
            }
            return PartialView("GetPatientInfo", viewModel);

        }

        [HttpPost]
        public JsonResult GetCityByPrefixText(string text)
        {
            var cities = _cityRepository.GetbyPrefixTest(text).Select(m => m.Name).Distinct().ToList();
            return Json(cities);
        }

        [HttpPost]
        public ActionResult SaveCallOutCome(CallOutComeEditModel model)
        {
            _callOutcomeService.SaveCallOutCome(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            var viewModel = _callQueueCustomerContactService.GetByCustomerId(model.CustomerId, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return PartialView("GetPatientInfo", viewModel);
        }

        public string DoesEventCustomerAlreadyExists(long customerId, long eventId)
        {
            var doesEventCustomerAlreadyExists = customerId > 0 ? _eventSchedulerService.DoesEventCustomerAlreadyExists(customerId, eventId) : null;

            if (doesEventCustomerAlreadyExists != null && doesEventCustomerAlreadyExists.FirstValue)
            {
                return doesEventCustomerAlreadyExists.SecondValue;
            }
            return string.Empty;
        }

        [HttpPost]
        public bool EndHealthPlanActiveCall(EndHealthPlanCallEditModel model)
        {
            var isCallQueueRequsted = false;
            var removeFromCallQueue = false;
            long customerId = 0;

            var callQueueCustomer = _callQueueCustomerRepository.GetById(model.CallQueueCustomerId);
            if (callQueueCustomer != null)
                customerId = callQueueCustomer.CustomerId ?? 0;

            //update call status in CustomerCallQueueCallAttempt Table
            if (model.IsSkipped && model.AttemptId > 0)
            {
                var attempt = _customerCallQueueCallAttemptRepository.GetById(model.AttemptId);
                attempt.IsCallSkipped = true;

                if (!string.IsNullOrEmpty(model.SkipCallNote))
                {
                    attempt.SkipCallNote = model.SkipCallNote;
                }
                _customerCallQueueCallAttemptRepository.Save(attempt);
            }

            else if (model.CallId != 0)
            {
                Call callCenterCalll = null;
                if (model.CallId > 0)
                {
                    callCenterCalll = _callCenterCallRepository.GetById(model.CallId);
                    customerId = callCenterCalll != null ? callCenterCalll.CalledCustomerId : 0;

                    if (callCenterCalll != null && callCenterCalll.Status == (long)CallStatus.TalkedtoOtherPerson)
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

                    if (tag == ProspectCustomerTag.RescheduleAppointment && callQueueCustomer != null && callQueueCustomer.EventCustomerId.HasValue)
                    {
                        var eventCustomer = _eventCustomerRepository.GetById(callQueueCustomer.EventCustomerId.Value);
                        if (eventCustomer.AppointmentId.HasValue)
                        {
                            var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

                            var eventInfo = _eventService.GetById(eventCustomer.EventId);

                            callQueueCustomer.EventId = eventCustomer.EventId;
                            callQueueCustomer.AppointmentDate = appointment.StartTime;
                            callQueueCustomer.AppointmentDateTimeWithTimeZone = _smsHelper.ConvertToServerTime(appointment.StartTime, eventInfo.EventTimeZone, !DaylightSavingNotApplicableStates.Contains(eventInfo.State));
                        }
                    }

                    if (tag == ProspectCustomerTag.PatientConfirmed && callQueueCustomer != null && callQueueCustomer.EventCustomerId.HasValue)
                    {
                        var eventCustomer = _eventCustomerRepository.GetById(callQueueCustomer.EventCustomerId.Value);
                        eventCustomer.IsAppointmentConfirmed = true;
                        eventCustomer.ConfirmedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                        _eventCustomerRepository.Save(eventCustomer);
                    }
                }

                var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                _callQueueCustomerContactService.EndActiveCall(callQueueCustomer, model.CallId, isCallQueueRequsted, orgRoleUserId, removeFromCallQueue, model.CallOutcomeId, model.SkipCallNote);

                if (callQueueCustomer != null)
                {
                    var prospectCustomerId = callQueueCustomer.ProspectCustomerId ?? 0;

                    if (prospectCustomerId == 0)
                    {
                        var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
                        if (prospectCustomer != null)
                        {
                            prospectCustomerId = prospectCustomer.Id;
                        }
                    }
                    _callQueueCustomerRepository.UpdateOtherCustomerAttempt(model.CallQueueCustomerId, customerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, removeFromCallQueue, callQueueCustomer.CallQueueId, model.CallOutcomeId);
                }
            }
            return true;
        }

        public ActionResult GetDialerPatient(long customerId, long callQueueId, long callId = 0)
        {
            try
            {
                if (callQueueId > 0 && callId == 0)
                {
                    callId = _callQueueCustomerContactService.StartCallForDailer(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, customerId, callQueueId);

                    if (callId == 0)
                    {
                        _logger.Info(string.Format("Dialer Patient Not Found:  Customer Id {0} And CallQueueId {1}", customerId, callQueueId));
                        const string s = "Cannot start call for this customer";
                        return View("ErrorPage", model: s);
                    }
                    return RedirectToAction("GetDialerPatient", new
                    {
                        customerId = customerId,
                        callQueueId = callQueueId,
                        callId = callId,
                    });
                }
                else if (callQueueId == 0 && callId == 0)
                {
                    callId = _callQueueCustomerContactService.StartOutboundCallForCustomerNotInCallQueue(customerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                    if (callId == 0)
                    {
                        _logger.Info(string.Format("Dialer Patient Not Found:  Customer Id {0} And CallQueueId {1}", customerId, callQueueId));
                        const string s = "Customer not found for given customerId.";
                        return View("ErrorPage", model: s);
                    }
                    return RedirectToAction("GetDialerPatient", new
                    {
                        customerId = customerId,
                        callQueueId = callQueueId,
                        callId = callId,
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
                var model = _callQueueCustomerContactService.GetByCustomerId(customerId, callId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.IsCalledForVici = true;
                return View("GetCustomerContactView", model);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception Message: {0}\nStack Trace: {1}", ex.Message, ex.StackTrace));
                const string s = "Customer not found";
                return View("ErrorPage", model: s);
            }
        }

        public ActionResult AppointmentConfirmation(long customerId, long callQueueId, long eventId, long callId = 0)
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
                    callId = _callQueueCustomerContactService.StartCallForAppointmentConfirmation(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, customerId, eventId, callQueueId);

                    if (callId == 0)
                    {
                        _logger.Info(string.Format("Patient Not Found:  Customer Id {0}", customerId));
                        const string s = "Cannot start call for this customer";
                        return View("ErrorPage", model: s);
                    }

                    return RedirectToAction("AppointmentConfirmation", new
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
                var model = _callQueueCustomerContactService.GetByCustomerId(customerId, callId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
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

        public PartialViewResult GetEventRegisteredOn(long eventId, DateTime eventDate, string hostName, string hostAddress, DateTime? appointmentTime, string timeZone,
            string pods, long eventCustomerId, bool isCancelled, bool isRescheduled)
        {
            var eventRegData = new RegisteredEventViewModel
            {
                EventId = eventId,
                EventDate = eventDate,
                HostName = hostName,
                HostAddress = hostAddress,
                AppointmentTime = appointmentTime,
                TimeZone = timeZone,
                Pods = pods,
                EventCustomerId = eventCustomerId,
                IsCanceled = isCancelled,
                IsRescheduled = isRescheduled,
            };

            return PartialView(eventRegData);
        }

        public PartialViewResult GetCallOutComeAppointmentConfirmation(long callId, long callQueueCustomerId, long prospectCustomerId, long customerId)
        {
            var model = _callOutcomeService.GetCallOutCome(callId, callQueueCustomerId, customerId);
            return PartialView(model);
        }

        public PartialViewResult GetCallHistoryDetailsAppointmentConfirmation(long callId, long callQueueCustomerId)
        {
            var model = _outboundCallQueueService.GetCustomerNotes(callId, callQueueCustomerId);
            return PartialView(model);
        }

        public bool UpdateCallersPhoneNumber(long callId, string patientPhoneNumber)
        {
            return _callCenterCallRepository.UpdateCallersPhoneNumber(callId, patientPhoneNumber.Replace("-", ""));
        }

        [HttpPost]
        public ActionResult SavePatientInfoAppointmentConfirmation(CallQueueCustomerEditModel model)
        {
            if (ModelState.IsValid)
            {
                _callQueueCustomerContactService.UpdateCustomerData(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                if (model.IsHealthPlanQueue)
                {
                    _primaryCarePhysicianHelper.UpdatePrimaryCarePhysician(model.PrimaryCarePhysician, model.CustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }

            }
            var viewModel = _callQueueCustomerContactService.GetByCustomerId(model.CustomerId, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            if (!ModelState.IsValid)
            {
                viewModel.HasError = true;
                viewModel.PatientInfoEditModel = model;
            }
            return PartialView("GetPatientInfoAppointmentConfirmation", viewModel);
        }

        [HttpPost]
        public ActionResult SaveCallOutComeAppointmentConfirmation(CallOutComeEditModel model)
        {
            _callOutcomeService.SaveCallOutCome(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            var viewModel = _callQueueCustomerContactService.GetByCustomerId(model.CustomerId, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return PartialView("GetPatientInfoAppointmentConfirmation", viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetPreQualificationTemplateIds(long customerId, long eventId)
        {
            var eventTests = _eventTestRepository.GetEventTestsByEventIds(new[] { eventId });
            var preQualificationTemplateIds = eventTests.Where(x => x.PreQualificationQuestionTemplateId.HasValue).Select(x => x.PreQualificationQuestionTemplateId.Value).ToArray();

            var preQualificationTestTemplates = _preQualificationTestTemplateRepository.GetByIds(preQualificationTemplateIds);

            var selectedTemplateIds = new List<long>(); //preQualificationTestTemplates.Select(x => x.TestId).ToArray();
            foreach (var preQualificationTestTemplate in preQualificationTestTemplates)
            {
                if (CheckPreApprovedTest(customerId, new[] { preQualificationTestTemplate.TestId }))
                {
                    selectedTemplateIds.Add(preQualificationTestTemplate.Id);
                }
            }

            return string.Join(",", selectedTemplateIds);
        }

        private bool CheckPreApprovedTest(long customerId, IEnumerable<long> testIdsToCheck)
        {
            return _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customerId, testIdsToCheck);
        }
    }
}