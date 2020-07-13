using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Enum;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace API.Areas.CallCenter.Controllers
{
    public class ContactCustomerController : BaseController
    {
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IEventService _eventService;
        private readonly ICallQueueCustomerLockRepository _callQueueCustomerLockRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueCustomerContactService _callQueueCustomerContactService;
        private readonly ISessionContext _sessionContext;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPrimaryCarePhysicianHelper _primaryCarePhysicianHelper;
        private readonly IStateRepository _stateRepository;
        private readonly ICallOutcomeService _callOutcomeService;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly ICustomerService _customerService;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ISmsHelper _smsHelper;

        private const int PageSize = 10;
        private static readonly string[] DaylightSavingNotApplicableStates = { "Arizona" };

        public ContactCustomerController(ICallQueueRepository callQueueRepository, IEventService eventService,
            ICallQueueCustomerLockRepository callQueueCustomerLockRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
            ICallQueueCustomerContactService callQueueCustomerContactService, ISessionContext sessionContext,
            IProspectCustomerRepository prospectCustomerRepository, IEventSchedulerService eventSchedulerService,
            IStateRepository stateRepository, ICallOutcomeService callOutcomeService, ICustomerRepository customerRepository, IPrimaryCarePhysicianHelper primaryCarePhysicianHelper,
            ICallCenterCallRepository callCenterCallRepository, ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository,
            ICustomerService customerService, IEventCustomerRepository eventCustomerRepository,
            IAppointmentRepository appointmentRepository, ISmsHelper smsHelper)
        {
            _callQueueRepository = callQueueRepository;
            _eventService = eventService;
            _callQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueCustomerContactService = callQueueCustomerContactService;
            _sessionContext = sessionContext;
            _prospectCustomerRepository = prospectCustomerRepository;
            _eventSchedulerService = eventSchedulerService;
            _stateRepository = stateRepository;
            _callOutcomeService = callOutcomeService;
            _customerRepository = customerRepository;
            _primaryCarePhysicianHelper = primaryCarePhysicianHelper;
            _callCenterCallRepository = callCenterCallRepository;
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _customerService = customerService;
            _eventCustomerRepository = eventCustomerRepository;
            _appointmentRepository = appointmentRepository;
            _smsHelper = smsHelper;
        }

        //[HttpGet]
        //public CustomerContactViewModel GetCustomerContactView([FromUri] long callQueueCustomerId, [FromUri] long callId)
        //{
        //    return _callQueueCustomerContactService.Get(callQueueCustomerId, callId);
        //}

        [HttpGet]
        public EventHostListModel GetEventList([FromUri]EventSearchFilterCallQueueCustomer filter)
        {
            filter = filter ?? new EventSearchFilterCallQueueCustomer();

            filter.Radius = filter.Radius ?? 25;
            filter.PageSize = filter.PageSize > 0 ? filter.PageSize : PageSize;
            filter.AgentOrganizationId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            filter.ShowFutureEvents = true;

            int totalCount;
            var list = _eventService.SearchEventForCallCenter(filter, out totalCount);

            var model = new EventHostListModel
            {
                Events = list,
                PagingModel = new PagingModel(filter.PageNumber, filter.PageSize, totalCount, null)
            };
            return model;
        }

        [HttpGet]
        public bool DoesEventCustomerAlreadyExists([FromUri]long customerId, [FromUri]long eventId)
        {
            var doesEventCustomerAlreadyExists = customerId > 0 ? _eventSchedulerService.DoesEventCustomerAlreadyExists(customerId, eventId) : null;

            if (doesEventCustomerAlreadyExists != null && doesEventCustomerAlreadyExists.FirstValue)
            {
                throw new Exception(doesEventCustomerAlreadyExists.SecondValue);
            }

            return false;
        }

        [HttpGet]
        public ScreeningInfoViewModel GetCustomerMedicalHistory(long customerId)
        {
            return _callQueueCustomerContactService.GetCustomerMedicalHistory(customerId);
        }

        [HttpPost]
        public CustomerContactViewModel UpdateCallQueueCustomer([FromBody] CallQueueCustomerEditModel customerEditModel)
        {
            _callQueueCustomerContactService.UpdateCustomerData(customerEditModel, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            if (customerEditModel.IsHealthPlanQueue)
            {
                _primaryCarePhysicianHelper.UpdatePrimaryCarePhysician(customerEditModel.PrimaryCarePhysician, customerEditModel.CustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            return _callQueueCustomerContactService.Get(customerEditModel.CallQueueCustomerId, customerEditModel.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpGet]
        public IEnumerable<OrderedPair<long, string>> GetStatesDropDown()
        {
            return _stateRepository.GetAllStates().ToList().Select(x => new OrderedPair<long, string>(x.Id, x.Name)); ;
        }

        [HttpGet]
        public IEnumerable<OrderedPair<long, string>> GetUsaStatesDropDown()
        {
            return _stateRepository.GetStateByCountryId((long)AddressValidatableCountries.USA).ToList().Select(x => new OrderedPair<long, string>(x.Id, x.Name)); ;
        }

        [HttpGet]
        public bool EndActiveCall([FromUri]long callQueueCustomerId, [FromUri]long callId, [FromUri]bool isCallQueueRequsted, [FromUri]bool removeFromCallQueue)
        {
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            _callQueueCustomerContactService.EndActiveCall(callQueueCustomer, callId, isCallQueueRequsted, orgRoleUserId, removeFromCallQueue);

            var customerId = callQueueCustomer.CustomerId ?? 0;
            var prospectCustomerId = callQueueCustomer.ProspectCustomerId ?? 0;

            if (prospectCustomerId == 0)
            {
                var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
                if (prospectCustomer != null)
                {
                    prospectCustomerId = prospectCustomer.Id;
                }
            }

            _callQueueCustomerRepository.UpdateOtherCustomerAttempt(callQueueCustomerId, customerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, removeFromCallQueue, callQueueCustomer.CallQueueId);

            return true;
        }

        [HttpPost]
        public CallQueuePatientInfomationViewModel SaveCallOutCome([FromBody]CallOutComeEditModel model)
        {
            var customer = _callOutcomeService.SaveCallOutCome(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return _callQueueCustomerContactService.PatientInfoPhoneModelForConsentUpdateCcRep(customer, model.CallId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        [HttpGet]
        public CallOutComeEditModel GetCallOutCome(long callId, long callQueueCustomerId, long customerId)
        {
            return _callOutcomeService.GetCallOutCome(callId, callQueueCustomerId, customerId);

        }

        [HttpGet]
        public StartOutBoundCallViewModel UpdateDoNotCallStatus([FromUri]long callQueueCustomerId, bool dontCall)
        {
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            if (dontCall)
            {
                if (callQueueCustomer.Status == CallQueueStatus.Removed)
                    return new StartOutBoundCallViewModel() { IsRemovedFromQueue = true };
                if (callQueueCustomer.ProspectCustomerId.HasValue)
                {
                    var prospectCust =
                        _prospectCustomerRepository.GetProspectCustomer(callQueueCustomer.ProspectCustomerId.Value);
                    if (prospectCust.Status == (long)ProspectCustomerConversionStatus.Declined)
                        return new StartOutBoundCallViewModel() { IsDoNotCall = true };
                }
                if (callQueueCustomer.CustomerId.HasValue)
                {
                    var customer = _customerRepository.GetCustomer(callQueueCustomer.CustomerId.Value);
                    if (customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId == (long)DoNotContactType.DoNotCall))
                    {
                        return new StartOutBoundCallViewModel() { IsDoNotCall = true };
                    }
                }
                var isLocked = _callQueueCustomerLockRepository.GetCallQueueCustomerLock(callQueueCustomer) != null;
                if (isLocked)
                {
                    return new StartOutBoundCallViewModel() { CallId = 1L };
                }
            }

            if (dontCall)
            {
                if (callQueueCustomer.ProspectCustomerId.HasValue)
                    _prospectCustomerRepository.UpdateDoNotCallStatus(callQueueCustomer.ProspectCustomerId.Value, ProspectCustomerConversionStatus.Declined);
                if (callQueueCustomer.CustomerId.HasValue)
                    _customerService.UpdateDoNotCallStatus(callQueueCustomer.CustomerId.Value, false, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, (long)DoNotContactSource.CallCenter);
            }
            else
            {
                if (callQueueCustomer.ProspectCustomerId.HasValue)
                    _prospectCustomerRepository.UpdateDoNotCallStatus(callQueueCustomer.ProspectCustomerId.Value, ProspectCustomerConversionStatus.NotConverted);
                if (callQueueCustomer.CustomerId.HasValue)
                    _customerService.UpdateDoNotCallStatus(callQueueCustomer.CustomerId.Value, true, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            return new StartOutBoundCallViewModel();
        }

        [HttpGet]
        public CallQueueContactViewModel GetCategoryByCallQueueCustomerId(long callQueueCustomerId)
        {
            var callQueueContactViewModel = new CallQueueContactViewModel();
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var callQueue = _callQueueRepository.GetById(callQueueCustomer.CallQueueId);
            callQueueContactViewModel.CallQueueId = callQueue.Id;
            callQueueContactViewModel.Name = callQueue.Name;
            callQueueContactViewModel.Category = callQueue.Category;
            //if (callQueueCustomer.EventId.HasValue)
            //{
            //    var host = _hostRepository.GetHostForEvent(callQueueCustomer.EventId.Value);
            //    callQueueContactViewModel.EventZipCode = host.Address.ZipCode.Zip;
            //}
            return callQueueContactViewModel;
        }

        [HttpPost]
        public bool EndHealthPlanActiveCall([FromBody]EndHealthPlanCallEditModel model)
        {
            var isCallQueueRequsted = false;
            var removeFromCallQueue = false;
            var callQueueCustomer = _callQueueCustomerRepository.GetById(model.CallQueueCustomerId);

            if (model.IsSkipped && model.AttemptId > 0)
            {
                var attempt = _customerCallQueueCallAttemptRepository.GetById(model.AttemptId);
                attempt.IsCallSkipped = true;

                if (!string.IsNullOrEmpty(model.SkipCallNote))
                {
                    attempt.SkipCallNote = model.SkipCallNote;
                }

                _customerCallQueueCallAttemptRepository.Save(attempt);

                _callQueueCustomerLockRepository.RelaseCallQueueCustomerLock(attempt.CallQueueCustomerId);

                var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                callQueueCustomer.Status = CallQueueStatus.Initial;
                callQueueCustomer.DateModified = DateTime.Now;
                callQueueCustomer.ModifiedByOrgRoleUserId = orgRoleUserId;
                callQueueCustomer.CallStatus = (long)CallStatus.CallSkipped;
                callQueueCustomer.ContactedDate = DateTime.Now;
                _callQueueCustomerRepository.Save(callQueueCustomer);

                var customerId = callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0;
                var prospectCustomerId = callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0;
                _callQueueCustomerRepository.UpdateOtherCustomerAttempt(attempt.CallQueueCustomerId, customerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, false,
                    callQueueCustomer.CallQueueId, callQueueCustomer.CallStatus, callQueueCustomer.ContactedDate);
            }
            else if (model.CallId != 0)
            {
                Call callCenterCalll = null;
                if (model.CallId > 0)
                {
                    callCenterCalll = _callCenterCallRepository.GetById(model.CallId);
                    //if (callCenterCalll != null && callCenterCalll.Status == (long)CallStatus.IncorrectPhoneNumber)
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

                    if (tag == ProspectCustomerTag.LanguageBarrier && callQueueCustomer.CustomerId.HasValue && callQueueCustomer.CustomerId.Value > 0)
                    {
                        _customerService.UpdateIsLanguageBarrier(callQueueCustomer.CustomerId.Value, true, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    }

                    if (tag == ProspectCustomerTag.RescheduleAppointment && callQueueCustomer.EventCustomerId.HasValue)
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

                    if (tag == ProspectCustomerTag.PatientConfirmed && callQueueCustomer.EventCustomerId.HasValue)
                    {
                        var eventCustomer = _eventCustomerRepository.GetById(callQueueCustomer.EventCustomerId.Value);
                        eventCustomer.IsAppointmentConfirmed = true;
                        eventCustomer.ConfirmedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                        _eventCustomerRepository.Save(eventCustomer);
                    }
                }

                var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                _callQueueCustomerContactService.EndActiveCall(callQueueCustomer, model.CallId, isCallQueueRequsted, orgRoleUserId, removeFromCallQueue, model.CallOutcomeId, model.SkipCallNote);

                var customerId = callQueueCustomer.CustomerId ?? 0;
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
            //_callQueueCustomerRepository.UpdateOtherCustomerAttempt(model.CallQueueCustomerId, customerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, removeFromCallQueue, callQueueCustomer.CallQueueId, model.CallOutcomeId);
            return true;
        }

        [HttpGet]
        public bool ReleaseLockedCustomer(long callQueueCustomerId)
        {
            _callQueueCustomerLockRepository.RelaseCallQueueCustomerLock(callQueueCustomerId);

            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var orgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            callQueueCustomer.Status = CallQueueStatus.Initial;
            callQueueCustomer.DateModified = DateTime.Now;
            callQueueCustomer.ModifiedByOrgRoleUserId = orgRoleUserId;
            callQueueCustomer.CallStatus = (long)CallStatus.Initiated;
            callQueueCustomer.ContactedDate = DateTime.Now;
            _callQueueCustomerRepository.Save(callQueueCustomer);

            var customerId = callQueueCustomer.CustomerId.HasValue ? callQueueCustomer.CustomerId.Value : 0;
            var prospectCustomerId = callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0;
            _callQueueCustomerRepository.UpdateOtherCustomerAttempt(callQueueCustomerId, customerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, false,
                callQueueCustomer.CallQueueId, callQueueCustomer.CallStatus, callQueueCustomer.ContactedDate);
            return true;
        }
    }
}
