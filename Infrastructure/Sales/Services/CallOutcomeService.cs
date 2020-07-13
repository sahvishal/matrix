using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;

namespace Falcon.App.Infrastructure.Sales.Services
{
    [DefaultImplementation]
    public class CallOutcomeService : ICallOutcomeService
    {
        private readonly IUniqueItemRepository<CustomerCallNotes> _customerCallNotesRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IProspectCustomerFactory _prospectCustomerFactory;
        private readonly ICustomerService _customerService;
        private readonly ICallQueueCustomerContactService _callQueueCustomerContactService;
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly INotesRepository _notesRepository;

        private readonly ILogger _logger;

        public CallOutcomeService(IUniqueItemRepository<CustomerCallNotes> customerCallNotesRepository, ICallCenterCallRepository callCenterCallRepository,
            ICallQueueCustomerRepository callQueueCustomerRepository, ICallCenterNotesRepository callCenterNotesRepository, IProspectCustomerRepository prospectCustomerRepository
            , ICustomerRepository customerRepository, IEventRepository eventRepository, IProspectCustomerFactory prospectCustomerFactory,
            ICustomerService customerService, ICallQueueCustomerContactService callQueueCustomerContactService,
            ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository, ICallQueueRepository callQueueRepository, INotesRepository notesRepository,
            ILogManager logManager)
        {
            _customerCallNotesRepository = customerCallNotesRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _prospectCustomerFactory = prospectCustomerFactory;
            _customerService = customerService;
            _callQueueCustomerContactService = callQueueCustomerContactService;
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _callQueueRepository = callQueueRepository;
            _notesRepository = notesRepository;
            _logger = logManager.GetLogger("CallOutcomeService");
        }

        public Customer SaveCallOutCome(CallOutComeEditModel model, long organizationRoleUserId)
        {
            Customer customer = _customerRepository.GetCustomer(model.CustomerId);
            var isConverted = _eventRepository.CheckCustomerRegisteredForFutureEvent(model.CustomerId);
            var prospectCustomer = ((IProspectCustomerRepository)_prospectCustomerRepository).GetProspectCustomerByCustomerId(model.CustomerId);
            if (prospectCustomer == null)
            {
                prospectCustomer = _prospectCustomerFactory.CreateProspectCustomerFromCustomer(customer, isConverted);
            }
            else
            {
                prospectCustomer.IsConverted = isConverted;
            }

            if (model.CallStatusId == (long)CallStatus.Attended || model.CallStatusId == (long)CallStatus.VoiceMessage || model.CallStatusId == (long)CallStatus.LeftMessageWithOther
              || model.CallStatusId == (long)CallStatus.InvalidNumber || model.CallStatusId == (long)CallStatus.NoAnswer || model.CallStatusId == (long)CallStatus.NoEventsInArea || model.CallStatusId == (long)CallStatus.TalkedtoOtherPerson)
            {
                prospectCustomer.IsContacted = true;
                prospectCustomer.ContactedDate = DateTime.Now;
                prospectCustomer.ContactedBy = organizationRoleUserId;
            }
            if (!string.IsNullOrEmpty(model.DispositionAlias))
            {
                prospectCustomer.Tag = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), model.DispositionAlias);
                prospectCustomer.TagUpdateDate = DateTime.Now;
            }

            prospectCustomer = UpdateProspectCustomer(prospectCustomer, model.CallBackDateTime);
            model.ProspectCustomerId = prospectCustomer.Id;
            // }

            var notes = string.IsNullOrWhiteSpace(model.Note) ? "" : model.Note;
            if ((ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), model.DispositionAlias) == ProspectCustomerTag.MemberStatesIneligibleMastectomy)
            {
                notes = notes.Replace(ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription() + " : ", "");
                notes = !string.IsNullOrWhiteSpace(notes) ? ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription() + " : " + notes : ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription();
            }

            SaveNotes(notes, model.CallId);
            SaveRegistrationNotes(model.CustomerId, notes, organizationRoleUserId);

            var objCall = _callCenterCallRepository.GetById(model.CallId);

            var disposition = "";
            var tag = ProspectCustomerTag.Unspecified;
            if ((model.CallStatusId == (long)CallStatus.Attended || model.CallStatusId == (long)CallStatus.LeftMessageWithOther || model.CallStatusId == (long)CallStatus.TalkedtoOtherPerson
                || model.CallStatusId == (long)CallStatus.NoEventsInArea) && !string.IsNullOrEmpty(model.DispositionAlias))
            {
                tag = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), model.DispositionAlias);
                if (tag == ProspectCustomerTag.BookedAppointment || tag == ProspectCustomerTag.HomeVisitRequested || tag == ProspectCustomerTag.MobilityIssue
                    || tag == ProspectCustomerTag.DoNotCall || tag == ProspectCustomerTag.Deceased || tag == ProspectCustomerTag.NoLongeronInsurancePlan
                    || tag == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther || tag == ProspectCustomerTag.DebilitatingDisease || tag == ProspectCustomerTag.InLongTermCareNursingHome
                    || tag == ProspectCustomerTag.PatientConfirmed || tag == ProspectCustomerTag.CancelAppointment || tag == ProspectCustomerTag.ConfirmLanguageBarrier || tag == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers
                    || tag == ProspectCustomerTag.DeclinedMobileAndTransferredToHome || tag == ProspectCustomerTag.DeclinedMobileAndHomeVisit)
                {
                    model.RemoveFromQueue = true;
                }

                disposition = model.DispositionAlias;
            }

            objCall.NotInterestedReasonId = model.NotIntrestedReasonId;

            if (model.CallQueueId > 0)
            {
                var callQueue = _callQueueRepository.GetById(model.CallQueueId);
                if (callQueue != null)
                {
                    objCall.IsContacted = false;
                    if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                        objCall.IsContacted = null;
                    else
                    {
                        if (model.CallStatusId == (long)CallStatus.Attended || model.CallStatusId == (long)CallStatus.VoiceMessage || model.CallStatusId == (long)CallStatus.LeftMessageWithOther || model.CallStatusId == (long)CallStatus.InvalidNumber || model.CallStatusId == (long)CallStatus.NoAnswer || model.CallStatusId == (long)CallStatus.NoEventsInArea || model.CallStatusId == (long)CallStatus.TalkedtoOtherPerson)
                        {
                            objCall.IsContacted = true;
                        }
                    }
                }
            }

            if (model.DoNotCall || tag == ProspectCustomerTag.DoNotCall)
            {
                if (model.ProspectCustomerId > 0)
                    ((IProspectCustomerRepository)_prospectCustomerRepository).UpdateDoNotCallStatus(model.ProspectCustomerId, ProspectCustomerConversionStatus.Declined);

                customer = _customerService.UpdateDoNotCallStatus(customer, false, (long)DoNotContactSource.CallCenter);
            }
            else if (model.CallStatusId == (long)CallStatus.Attended && tag == ProspectCustomerTag.LanguageBarrier)
            {
                customer = _customerService.UpdateIsLanguageBarrier(customer, true);
            }
            else
            {
                if (model.ProspectCustomerId > 0)
                    ((IProspectCustomerRepository)_prospectCustomerRepository).UpdateDoNotCallStatus(model.ProspectCustomerId, ProspectCustomerConversionStatus.NotConverted);

                customer = _customerService.UpdateDoNotCallStatus(customer, true);
            }

            if (model.CustomerId > 0 && (model.CallStatusId == (long)CallStatus.TalkedtoOtherPerson && tag == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers) || (model.CallStatusId == (long)CallStatus.Attended && tag == ProspectCustomerTag.IncorrectPhoneNumber))
            {
                customer = _customerService.UpdateIsIncorrectPhoneNumber(customer, true);
            }
            else if (model.CallStatusId == (long)CallStatus.InvalidNumber)
            {
                var secondLastCall = _callCenterCallRepository.GetSecondLastCall(model.CustomerId, model.CallId);
                if (secondLastCall != null && secondLastCall.Status == (long)CallStatus.InvalidNumber && secondLastCall.InvalidNumberCount == 1)
                {
                    objCall.InvalidNumberCount = 2;
                    customer = _customerService.UpdateIsIncorrectPhoneNumber(customer, true);
                }
                else
                {
                    objCall.InvalidNumberCount = 1;
                    customer = _customerService.UpdateIsIncorrectPhoneNumber(customer, false);
                }
            }
            else
            {
                objCall.InvalidNumberCount = 0;
                customer = _customerService.UpdateIsIncorrectPhoneNumber(customer, false);
            }

            if (model.CallStatusId == (long)CallStatus.Attended && (tag == ProspectCustomerTag.DeclinedMobileAndTransferredToHome || tag == ProspectCustomerTag.MemberStatesIneligibleMastectomy))
            {
                customer.ActivityId = null;
            }
            else if (objCall.Status == (long)CallStatus.Attended && (objCall.Disposition == ProspectCustomerTag.DeclinedMobileAndTransferredToHome.ToString() || objCall.Disposition == ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString()))
            {
                customer.ActivityId = model.ActivityId > 0 ? model.ActivityId : (long?)null;
            }

            if (model.CallStatusId == (long)CallStatus.Attended && tag == ProspectCustomerTag.MemberStatesIneligibleMastectomy)
            {
                customer = _customerService.UpdateDoNotCallStatuswithReason(customer, false, ProspectCustomerTag.MemberStatesIneligibleMastectomy);
                var noteId = SaveDNCNotes(ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription(), organizationRoleUserId);
                customer.DoNotContactReasonNotesId = noteId;
            }
            else if (objCall.Status == (long)CallStatus.Attended && objCall.Disposition == ProspectCustomerTag.MemberStatesIneligibleMastectomy.ToString())
            {
                customer = _customerService.UpdateDoNotCallStatus(customer, true);
            }

            objCall.Status = model.CallStatusId;
            objCall.Disposition = disposition;
            _callCenterCallRepository.Save(objCall);

            UpdateOutboundCallStatus(organizationRoleUserId, model.CallQueueCustomerId, model.CallBackDateTime, model.RemoveFromQueue);

            if (objCall.Status == (long)CallStatus.Attended)
            {
                ModifyCustomerToSaveConsent(customer, model);
            }
            _customerService.SaveCustomerOnly(customer, organizationRoleUserId);

            UpdateCallProspectCustomerData(model, model.CallBackDateTime, organizationRoleUserId, model.CallQueueCustomerId, model.RemoveFromQueue);

            return customer;
        }

        private void ModifyCustomerToSaveConsent(Customer customer, CallOutComeEditModel model)
        {
            customer.HomePhoneNumber = PhoneNumber.Create(model.PhoneHome, PhoneNumberType.Home);
            customer.OfficePhoneNumber = PhoneNumber.Create(model.PhoneOffice, PhoneNumberType.Office);
            customer.MobilePhoneNumber = PhoneNumber.Create(model.PhoneCell, PhoneNumberType.Mobile);

            customer.PhoneHomeConsentId = model.PhoneHomeConsent;
            customer.PhoneCellConsentId = model.PhoneCellConsent;
            customer.PhoneOfficeConsentId = model.PhoneOfficeConsent;
        }

        private ProspectCustomer UpdateProspectCustomer(ProspectCustomer prospectCustomer, DateTime? callDateTime)
        {
            if (callDateTime.HasValue)
            {
                prospectCustomer.CallBackRequestedDate = callDateTime.Value;
                prospectCustomer.CallBackRequestedOn = DateTime.Now;
                prospectCustomer.IsQueuedForCallBack = true;
            }
            prospectCustomer = ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);
            return prospectCustomer;
        }

        public CallOutComeEditModel GetCallOutCome(long callId, long callQueueCustomerId, long customerId)
        {
            var callOutComeModel = new CallOutComeEditModel();
            var objCall = _callCenterCallRepository.GetById(callId);

            if (objCall == null)
            {
                return callOutComeModel;
            }

            callOutComeModel.CallStatusId = objCall.Status;
            callOutComeModel.NotIntrestedReasonId = objCall.NotInterestedReasonId;

            var objNote = _callCenterNotesRepository.GetByCallId(callId);
            if (objNote != null)
            {
                callOutComeModel.Note = objNote.Notes.Replace(ProspectCustomerTag.MemberStatesIneligibleMastectomy.GetDescription(), "").Replace(":", "").Trim();
            }

            callOutComeModel.DispositionAlias = objCall.Disposition;

            var customer = _customerRepository.GetCustomer(customerId);
            if (customer.DoNotContactTypeId.HasValue && (customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotContact || customer.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotCall))
                callOutComeModel.DoNotCall = true;

            callOutComeModel.PhoneHome = customer.HomePhoneNumber.FormatPhoneNumber;
            callOutComeModel.PhoneHomeConsent = customer.PhoneHomeConsentId;

            callOutComeModel.PhoneOffice = customer.OfficePhoneNumber.FormatPhoneNumber;
            callOutComeModel.PhoneOfficeConsent = customer.PhoneOfficeConsentId;

            callOutComeModel.PhoneCell = customer.MobilePhoneNumber.FormatPhoneNumber;
            callOutComeModel.PhoneCellConsent = customer.PhoneCellConsentId;

            if (customerId > 0 && objCall.Disposition == (ProspectCustomerTag.CallBackLater).ToString())
            {
                var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
                if (prospectCustomer != null && prospectCustomer.IsQueuedForCallBack && prospectCustomer.CallBackRequestedOn.HasValue) //&& prospectCustomer.CallBackRequestedOn.Value.Date == DateTime.Today
                {
                    callOutComeModel.CallBackDateTime = prospectCustomer.CallBackRequestedDate;
                }
            }

            if (callQueueCustomerId > 0)
            {
                var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);

                if (callQueueCustomer.Status == CallQueueStatus.Removed)
                    callOutComeModel.RemoveFromQueue = true;
                callOutComeModel.CallQueueId = callQueueCustomer.CallQueueId;
            }

            return callOutComeModel;
        }

        private void SaveNotes(string note, long callId)
        {
            var callCenterNotes = new CallCenterNotes();

            callCenterNotes.CallId = callId;
            callCenterNotes.Notes = note;
            callCenterNotes.IsActive = true;
            callCenterNotes.NotesSequence = 1;

            _callCenterNotesRepository.Save(callCenterNotes);
        }

        private void SaveRegistrationNotes(long customerId, string notes, long organizationRoleUserId)
        {
            if (customerId <= 0) return;
            var customerRegistrationNotes = new CustomerCallNotes
            {
                CustomerId = customerId,
                EventId = null,
                Notes = notes,
                NotesType = CustomerRegistrationNotesType.AppointmentNote,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(organizationRoleUserId)
                }
            };

            _customerCallNotesRepository.Save(customerRegistrationNotes);
        }

        private void UpdateOutboundCallStatus(long orgRoleUserId, long callQueueCustomerId, DateTime? callDateTime, bool isRemovedFromQueue)
        {
            if (callQueueCustomerId <= 0) return;
            var callDate = callDateTime.HasValue ? callDateTime.Value : DateTime.Now.AddDays(30);

            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);


            callQueueCustomer.DateModified = DateTime.Now;
            callQueueCustomer.ModifiedByOrgRoleUserId = orgRoleUserId;
            if (isRemovedFromQueue)
            { callQueueCustomer.Status = CallQueueStatus.Removed; }
            else
            {
                callQueueCustomer.Status = CallQueueStatus.InProcess;
            }

            callQueueCustomer.CallDate = callDate;
            _callQueueCustomerRepository.Save(callQueueCustomer);
        }
        private bool UpdateCallProspectCustomerData(CallOutComeEditModel model, DateTime? callDateTime, long orgRoleUserId, long callQueueCustomerId, bool isRemovedFromQueue)
        {
            var disposition = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), model.DispositionAlias);
            var tag = disposition == ProspectCustomerTag.Unspecified ? string.Empty : model.DispositionAlias;

            var callDate = callDateTime.HasValue
                ? callDateTime.Value
                : model.CallStatusId == (long)CallStatus.CallSkipped
                    ? DateTime.Now.AddDays(1)
                    : DateTime.Now.AddDays(30);

            var editmodel = new CallQueueCustomerCallDetailsEditModel
            {
                CallQueueCustomerId = callQueueCustomerId,
                Disposition = tag,
                CallStatusId = model.CallStatusId,

                CallbackDate = tag == ProspectCustomerTag.CallBackLater.ToString() ? model.CallBackDateTime : null,
                IsCallSkipped = model.CallStatusId == (long)CallStatus.CallSkipped,
                ModifiedByOrgRoleUserId = orgRoleUserId,
                Attempt = 0,
                CallQueueStatus = (long)(isRemovedFromQueue ? CallQueueStatus.Removed : CallQueueStatus.Initial),
                CallDate = callDate,

            };

            //bool setOtherCustomerStatus = !(disposition == ProspectCustomerTag.CancelAppointment || disposition == ProspectCustomerTag.RescheduleAppointment
            //                                || disposition == ProspectCustomerTag.CHATCompleted || disposition == ProspectCustomerTag.RequestedCHATMailed || disposition == ProspectCustomerTag.MemberDoesntHaveTimeForQuestions
            //                                || disposition == ProspectCustomerTag.MemberDoesNotFeelComfortableAnsweringQuestions || disposition == ProspectCustomerTag.FollowUpCallEscalated || disposition == ProspectCustomerTag.MemberConfirmedChange
            //                                 || disposition == ProspectCustomerTag.NotInterested);

            bool setOtherCustomerStatus = !(disposition == ProspectCustomerTag.PatientConfirmed || disposition == ProspectCustomerTag.CancelAppointment || disposition == ProspectCustomerTag.ConfirmLanguageBarrier
                                         || disposition == ProspectCustomerTag.ConfirmedHRANotComplete);

            _callQueueCustomerRepository.UpdateCallqueueCustomerByCustomerId(editmodel, model.CustomerId, setOtherCustomerStatus);
            return true;
        }
        public void EndHealthPlanActiveCall(EndHealthPlanCallEditModel model, long orgRoleUserId)
        {
            var isCallQueueRequsted = false;
            var removeFromCallQueue = false;
            var callQueueCustomer = _callQueueCustomerRepository.GetById(model.CallQueueCustomerId);

            //update call status in CustomerCallQueueCallAttempt Table
            if (model.IsSkipped && model.AttemptId > 0)
            {
                var attempt = _customerCallQueueCallAttemptRepository.GetById(model.AttemptId);
                attempt.IsCallSkipped = true;

                if (!string.IsNullOrEmpty(model.SkipCallNote))
                {
                    attempt.SkipCallNote = model.SkipCallNote;
                }
                callQueueCustomer.Status = CallQueueStatus.Initial;
                callQueueCustomer.DateModified = DateTime.Now;
                callQueueCustomer.CallDate = DateTime.Now.AddDays(1);
                callQueueCustomer.ContactedDate = DateTime.Now;

                _customerCallQueueCallAttemptRepository.Save(attempt);
            }
            else if (model.CallId != 0)
            {
                Call callCenterCalll = null;
                if (model.CallId > 0)
                {
                    callCenterCalll = _callCenterCallRepository.GetById(model.CallId);
                    var tag = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), model.SelectedDisposition);
                    //  if (callCenterCalll != null && callCenterCalll.Status == (long)CallStatus.IncorrectPhoneNumber)
                    if (callCenterCalll != null && callCenterCalll.Status == (long)CallStatus.TalkedtoOtherPerson && tag == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers)
                    {
                        removeFromCallQueue = true;
                    }
                }
                if (!string.IsNullOrEmpty(model.SelectedDisposition))
                {
                    var tag = (ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), model.SelectedDisposition);
                    if (tag == ProspectCustomerTag.CallBackLater)
                    { isCallQueueRequsted = true; }
                    else if (tag == ProspectCustomerTag.BookedAppointment || tag == ProspectCustomerTag.HomeVisitRequested || tag == ProspectCustomerTag.MobilityIssue
                        || tag == ProspectCustomerTag.DoNotCall || tag == ProspectCustomerTag.Deceased || tag == ProspectCustomerTag.NoLongeronInsurancePlan
                        || tag == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther || tag == ProspectCustomerTag.DebilitatingDisease || tag == ProspectCustomerTag.InLongTermCareNursingHome)
                    {
                        removeFromCallQueue = true;
                    }

                    if (tag == ProspectCustomerTag.LanguageBarrier && callQueueCustomer.CustomerId.HasValue && callQueueCustomer.CustomerId.Value > 0)
                    {
                        _customerService.UpdateIsLanguageBarrier(callQueueCustomer.CustomerId.Value, true, orgRoleUserId);
                    }
                }

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
        }

        private long SaveDNCNotes(string prospectCustomerTag, long organizationRoleUserId)
        {
            Notes notes;
            notes = new Notes
            {
                Text = prospectCustomerTag,
                DataRecorderMetaData = new DataRecorderMetaData(organizationRoleUserId, DateTime.Now, null)
            };
            notes = _notesRepository.Save(notes);
            return notes.Id;
        }
    }
}
