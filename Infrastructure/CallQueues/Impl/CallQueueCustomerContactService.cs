using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallQueueCustomerContactService : ICallQueueCustomerContactService
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICallQueuePatientInfomationFactory _callQueuePatientInfomationFactory;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IHostRepository _hostRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventService _eventService;
        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IAddressService _addressService;
        private readonly IStateRepository _stateRepository;
        private readonly ICustomerService _customerService;
        private readonly ICallQueueCustomerLockRepository _callQueueCustomerLockRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IPrimaryCarePhysicianHelper _primaryCarePhysicianHelper;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerNotesService _customerNotesService;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly ICustomerAccountGlocomNumberService _customerAccountGlocomNumberService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly IProspectCustomerFactory _prospectCustomerFactory;
        private readonly ICallCenterRepository _callCenterRepository;
        private readonly ICallCenterRepProfileRepository _callCenterRepProfileRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICustomerWarmTransferRepository _customerWarmTransferRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly ISettings _settings;
        private readonly ITestResultService _testResultService;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;

        //private readonly IRequiredTestRepository _requiredTestRepository;

        public CallQueueCustomerContactService(ICallQueueCustomerRepository callQueueCustomerRepository, ICustomerRepository customerRepository,
            IProspectCustomerRepository prospectCustomerRepository, ICallQueuePatientInfomationFactory callQueuePatientInfomationFactory,
            ICallCenterCallRepository callCenterCallRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository, IHostRepository hostRepository,
            ITestRepository testRepository, IAddressService addressService, IStateRepository stateRepository,
            ICustomerService customerService, ICallQueueCustomerLockRepository callQueueCustomerLockRepository,
            ICallQueueRepository callQueueRepository, IPreApprovedTestRepository preApprovedTestRepository,
            IPrimaryCarePhysicianHelper primaryCarePhysicianHelper, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            ICorporateAccountRepository corporateAccountRepository, ICustomerNotesService customerNotesService,
            IAccountAdditionalFieldRepository accountAdditionalFieldRepository, ICallCenterNotesRepository callCenterNotesRepository,
            IPreApprovedPackageRepository preApprovedPackageRepository, IPackageRepository packageRepository,
            ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository, ICustomerAccountGlocomNumberService customerAccountGlocomNumberService,
            IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, IEventService eventService, IAppointmentRepository appointmentRepository, IOrganizationRepository organizationRepository,
            IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, IOutboundCallQueueService outboundCallQueueService, ICallQueueCustomerCallRepository callQueueCustomerCallRepository,
            IProspectCustomerFactory prospectCustomerFactory, ICallCenterRepository callCenterRepository, ISettings settings, ICallCenterRepProfileRepository callCenterRepProfileRepository,
            ICustomerEligibilityRepository customerEligibilityRepository, ICustomerWarmTransferRepository customerWarmTransferRepository, ITestResultService testResultService, IActivityTypeRepository activityTypeRepository,
            IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices
            //, IRequiredTestRepository requiredTestRepository
            )
        {
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _callQueuePatientInfomationFactory = callQueuePatientInfomationFactory;
            _callCenterCallRepository = callCenterCallRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _hostRepository = hostRepository;
            _testRepository = testRepository;
            _addressService = addressService;
            _stateRepository = stateRepository;
            _customerService = customerService;
            _callQueueCustomerLockRepository = callQueueCustomerLockRepository;
            _callQueueRepository = callQueueRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _primaryCarePhysicianHelper = primaryCarePhysicianHelper;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _customerNotesService = customerNotesService;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _packageRepository = packageRepository;
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _customerAccountGlocomNumberService = customerAccountGlocomNumberService;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _eventService = eventService;
            _appointmentRepository = appointmentRepository;
            _organizationRepository = organizationRepository;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _outboundCallQueueService = outboundCallQueueService;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _prospectCustomerFactory = prospectCustomerFactory;
            _callCenterRepository = callCenterRepository;
            _settings = settings;
            _callCenterRepProfileRepository = callCenterRepProfileRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _customerWarmTransferRepository = customerWarmTransferRepository;
            _testResultService = testResultService;
            _activityTypeRepository = activityTypeRepository;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;
            //_requiredTestRepository = requiredTestRepository;
        }

        public CustomerContactViewModel Get(long callQueueCustomerId, long callId, long orgRoleUserId)
        {
            if (callQueueCustomerId <= 0) return null;
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);

            var callQueue = _callQueueRepository.GetById(callQueueCustomer.CallQueueId);
            var criteria = callQueueCustomer.CallQueueCriteriaId.HasValue ? _healthPlanCallQueueCriteriaRepository.GetById(callQueueCustomer.CallQueueCriteriaId.Value) : null;

            var customer = callQueueCustomer.CustomerId.HasValue ? _customerRepository.GetCustomer(callQueueCustomer.CustomerId.Value) : null;

            var memberIdLabel = string.Empty;
            CorporateAccount corporateAccount = null;
            CustomerEligibility customerEligibility = null;

            if (customer != null)
            {
                customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);      //no need to check nullability of customerEligibility
                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);
                    memberIdLabel = corporateAccount != null ? corporateAccount.MemberIdLabel : string.Empty;
                }
            }

            //var prospectCustomer = callQueueCustomer.ProspectCustomerId.HasValue
            //    ? _prospectCustomerRepository.GetProspectCustomer(callQueueCustomer.ProspectCustomerId.Value)
            //    : (callQueueCustomer.CustomerId.HasValue ? _prospectCustomerRepository.GetProspectCustomerByCustomerId(callQueueCustomer.CustomerId.Value) : null);

            Falcon.App.Core.Medical.Domain.ActivityType activityType = null;
            if (customer.ActivityId.HasValue)
                activityType = _activityTypeRepository.GetById(customer.ActivityId.Value);

            var patientInfo = _callQueuePatientInfomationFactory.SetCustomerInfo(customer, customerEligibility, activityType);
            CriteriaInfoViewModel criteriaInfo = null;

            var additionalFileds = new List<OrderedPair<string, string>>();
            if (corporateAccount != null)
            {
                var accountAdditionalFields = _accountAdditionalFieldRepository.GetByAccountId(corporateAccount.Id);
                if (accountAdditionalFields.Any())
                {
                    additionalFileds.AddRange(accountAdditionalFields.Select(additionalField => new OrderedPair<string, string>(additionalField.DisplayName, GetCustomerAdditionalField(customer, additionalField.AdditionalFieldId))));
                }
                if (corporateAccount.ShowCallCenterScript && corporateAccount.CallCenterScriptFileId > 0)
                {
                    var callCenterScriptPdf = _fileRepository.GetById(corporateAccount.CallCenterScriptFileId);
                    var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                    patientInfo.CallCenterScriptUrl = mediaLocation.Url + callCenterScriptPdf.Path;
                }
                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                {
                    if (corporateAccount.ShowCallCenterScript && corporateAccount.ConfirmationScriptFileId > 0)
                    {
                        var confirmationScriptPdf = _fileRepository.GetById(corporateAccount.ConfirmationScriptFileId);
                        var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                        patientInfo.CallCenterScriptUrl = mediaLocation.Url + confirmationScriptPdf.Path;
                    }
                }

                var organization = _organizationRepository.GetOrganizationbyId(corporateAccount.Id);
                patientInfo.HealthPlan = organization.Name;

                criteriaInfo = new CriteriaInfoViewModel
                {
                    HealthPlan = organization.Name,
                    CallQueue = callQueue.Name,
                    Category = callQueue.Category,
                    Percentage = criteria != null ? criteria.Percentage : 0,
                    Days = criteria != null ? criteria.NoOfDays : 0
                };
                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                    criteriaInfo.Days = corporateAccount.EventConfirmationBeforeDays.HasValue ? corporateAccount.EventConfirmationBeforeDays.Value : 0;
            }


            if (customer != null && customer.Address != null && customer.Address.StateId > 0 && corporateAccount != null)
            {
                patientInfo.HealthPlanPhoneNumber = _customerAccountGlocomNumberService.GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customer.CustomerId, callId);
            }
            if (patientInfo.HealthPlanPhoneNumber == null)
            {
                patientInfo.HealthPlanPhoneNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
            }

            if (patientInfo.HealthPlanPhoneNumber != null)
            {
                string dialerUrl;
                var callCenterRepProfile = _callCenterRepProfileRepository.Get(orgRoleUserId);
                if (callCenterRepProfile != null && !string.IsNullOrEmpty(callCenterRepProfile.DialerUrl))
                {
                    dialerUrl = callCenterRepProfile.DialerUrl.ToLower().Replace(CallCenterAgentUrlKeywords.CallerId.ToLower(), (patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number))
                        .Replace(CallCenterAgentUrlKeywords.PatientId.ToLower(), patientInfo.CustomerId.ToString());
                }
                else
                {
                    dialerUrl = "Glocom://*65*" + patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number + "*1" + CallCenterAgentUrlKeywords.PatientContact.ToLower();
                }

                if (patientInfo.CallBackPhoneNumber != null)
                    patientInfo.CallBackPhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.CallBackPhoneNumber.AreaCode + patientInfo.CallBackPhoneNumber.Number));

                if (patientInfo.OfficePhoneNumber != null)
                    patientInfo.OfficePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.OfficePhoneNumber.AreaCode + patientInfo.OfficePhoneNumber.Number));

                if (patientInfo.MobilePhoneNumber != null && !string.IsNullOrEmpty(patientInfo.MobilePhoneNumber.Number))
                    patientInfo.MobilePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.MobilePhoneNumber.AreaCode + patientInfo.MobilePhoneNumber.Number));
            }

            var hasMammo = customer != null && _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customer.CustomerId, TestGroup.BreastCancer);

            patientInfo.HasMammo = hasMammo;

            patientInfo.MammoTestAsPreApproved = hasMammo;

            //if (callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
            //{
            //    patientInfo.HasMammo = false;
            //}

            patientInfo.CustomerId = callQueueCustomer.CustomerId;
            //patientInfo.ProspectCustomerId = callQueueCustomer.ProspectCustomerId;

            patientInfo.CallQueueCustomerId = callQueueCustomerId;

            //patientInfo = _callQueuePatientInfomationFactory.SetCustomerTagInfo(prospectCustomer, patientInfo);

            if (patientInfo != null && callQueue.IsHealthPlan)
            {
                patientInfo.PrimaryCarePhysician = _primaryCarePhysicianHelper.GetPrimaryCarePhysicianViewModel(callQueueCustomer.CustomerId.Value);
            }

            if (customer != null)
            {
                var customerCustomTags = _corporateCustomerCustomTagRepository.GetByCustomerId(customer.CustomerId);
                if (!customerCustomTags.IsNullOrEmpty())
                {
                    var customTags = customerCustomTags.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Select(x => x.Tag).ToArray();
                    patientInfo.CustomCorporateTags = customTags.IsNullOrEmpty() ? string.Empty : string.Join(",", customTags);
                }
            }

            IEnumerable<string> preApprovedTests = null;
            IEnumerable<string> preApprovedPackages = null;
            //var currentCall = _callCenterCallRepository.GetById(callId);

            if (callQueueCustomer.CustomerId.HasValue)
            {
                preApprovedTests = _preApprovedTestRepository.GetPreApprovedTests(callQueueCustomer.CustomerId.Value);
                preApprovedPackages = _preApprovedPackageRepository.GetPreApprovedPackageTest(callQueueCustomer.CustomerId.Value);
            }

            var warmTransfer = false;
            if (customer != null && corporateAccount != null && corporateAccount.WarmTransfer)
            {
                var customerWarmTransfer = _customerWarmTransferRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                warmTransfer = customerWarmTransfer != null && customerWarmTransfer.IsWarmTransfer.HasValue && customerWarmTransfer.IsWarmTransfer.Value;
            }

            var model = new CustomerContactViewModel
            {
                PatientInfomation = patientInfo,
                //CallHistory = callHistoryModel,
                PreApprovedTests = preApprovedTests,
                //ReadAndUnderstood = currentCall != null && currentCall.ReadAndUnderstood.HasValue && currentCall.ReadAndUnderstood.Value,
                AdditionalFields = additionalFileds,
                MemberIdLabel = memberIdLabel,
                //IsCallEnded = currentCall != null && currentCall.Status == (long)CallStatus.CallSkipped && currentCall.EndTime.HasValue,
                PreApprovedPackages = preApprovedPackages,
                CriteriaInfo = criteriaInfo,
                WarmTransfer = warmTransfer
            };

            return model;
        }

        public ScreeningInfoViewModel GetCustomerMedicalHistory(long customerId)
        {
            var previousAttendedEvent = _eventRepository.GetPreviousAttendedEvent(customerId);
            if (previousAttendedEvent == null) return null;
            var eventCustomer = _eventCustomerRepository.Get(previousAttendedEvent.Id, customerId);
            if (eventCustomer == null) return null;
            var host = _hostRepository.GetHostById(previousAttendedEvent.HostId);

            var eventCustomerResult = _eventCustomerResultRepository.GetById(eventCustomer.Id);
            var status = _eventCustomerResultRepository.GetTestResultStatusforEventCustomer(eventCustomer.EventId, eventCustomer.CustomerId);

            List<OrderedPair<string, string>> pairTestSummary = null;
            if (status != null && status.TestResults != null)
            {
                var testList = _testRepository.GetAll();
                var query = (from testResult in status.TestResults
                             where testResult.TestInterpretation.HasValue && ((ResultInterpretation)testResult.TestInterpretation.Value != ResultInterpretation.Normal)
                             select testResult);

                pairTestSummary = (from q in query
                                   where q.TestInterpretation.HasValue
                                   let test = testList.First(x => x.Id == q.TestId)
                                   select new OrderedPair<string, string>(test.Name, q.TestInterpretation.HasValue ? ((ResultInterpretation)q.TestInterpretation.Value).ToString() : "")).ToList();
            }

            var result = "Not Processed";

            if (eventCustomerResult != null)
            {
                result = eventCustomerResult.ResultSummary.HasValue ? ((ResultInterpretation)eventCustomerResult.ResultSummary.Value).GetDescription() : "Not Available";
            }

            var screeningInfoViewModel = new ScreeningInfoViewModel
            {
                ResultSummary = pairTestSummary,
                Result = result,
                HostName = host.OrganizationName,
                EventLocation = Mapper.Map<Address, AddressViewModel>(host.Address),
                LastScreeningDate = previousAttendedEvent.EventDate
            };

            return screeningInfoViewModel;
        }

        public bool UpdateCustomerData(CallQueueCustomerEditModel model, long createdByOrgRoleUserId)
        {
            if (model.CustomerId > 0)
            {
                var customer = _customerRepository.GetCustomer(model.CustomerId);
                var previousIncorrectPhoneNumberStatus = customer.IsIncorrectPhoneNumber;

                customer.Name.FirstName = model.FirstName;
                customer.Name.LastName = model.LastName;
                var address = _addressService.SaveAfterSanitizing(Mapper.Map<AddressEditModel, Address>(model.Address));

                if (customer.Address != null && customer.Address.Id > 0)
                {
                    address.Id = customer.Address.Id;
                }
                customer.Address = address;

                string officePhoneNumber = PhoneNumber.Create(model.OfficePhoneNumber, PhoneNumberType.Office).ToString();
                string mobilePhoneNumber = PhoneNumber.Create(model.MobilePhoneNumber, PhoneNumberType.Mobile).ToString();
                string homePhoneNumber = PhoneNumber.Create(model.CallBackPhoneNumber, PhoneNumberType.Home).ToString();

                if ((customer.OfficePhoneNumber != null && customer.OfficePhoneNumber.ToString() != officePhoneNumber) ||
                   (customer.MobilePhoneNumber != null && customer.MobilePhoneNumber.ToString() != mobilePhoneNumber) ||
                   (customer.HomePhoneNumber != null && customer.HomePhoneNumber.ToString() != homePhoneNumber))
                {
                    customer.IsIncorrectPhoneNumber = false;
                    customer.IncorrectPhoneNumberMarkedDate = null;
                }

                var currentIncorrectPhoneNumberStatus = customer.IsIncorrectPhoneNumber;

                customer.OfficePhoneNumber = PhoneNumber.Create(model.OfficePhoneNumber, PhoneNumberType.Office);
                customer.MobilePhoneNumber = PhoneNumber.Create(model.MobilePhoneNumber, PhoneNumberType.Mobile);
                customer.HomePhoneNumber = PhoneNumber.Create(model.CallBackPhoneNumber, PhoneNumberType.Home);

                customer.Hicn = model.Hicn;
                customer.Mbi = model.Mbi;

                customer.InsuranceId = model.MemberId;
                //customer.IsEligible = model.EligibleStatus;
                customer.ActivityId = model.ActivityId > 0 ? model.ActivityId : (long?)null;

                customer.Email = null;
                if (!string.IsNullOrEmpty(model.Email))
                {
                    customer.Email = new Email(model.Email);
                }

                //else if (!string.IsNullOrEmpty(customer.Email.ToString()) && string.IsNullOrEmpty(model.Email))
                //{
                //    customer.Email = null;
                //}

                customer.AlternateEmail = null;

                if (!string.IsNullOrEmpty(model.AlternateEmail))
                {
                    customer.AlternateEmail = new Email(model.AlternateEmail);
                }


                customer.DateOfBirth = model.DateOfBirth;

                customer.Gender = (Gender)model.Gender;
                customer.EnableEmail = model.EnableEmail;

                _customerService.SaveCustomer(customer, createdByOrgRoleUserId);

                if (previousIncorrectPhoneNumberStatus && !currentIncorrectPhoneNumberStatus)
                {
                    _customerNotesService.SavePhoneNumberUpdatedMessage(customer.CustomerId, createdByOrgRoleUserId);
                }
            }

            ProspectCustomer prospectCustomer = null;
            if (model.ProspectCustomerId > 0)
            {
                prospectCustomer = _prospectCustomerRepository.GetProspectCustomer(model.ProspectCustomerId);
            }
            else if (model.CustomerId > 0)
            {
                prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(model.CustomerId);
            }

            if (prospectCustomer == null) return true;

            prospectCustomer.FirstName = model.FirstName;
            prospectCustomer.LastName = model.LastName;

            if (model.Gender > 0)
            {
                prospectCustomer.Gender = (Gender)model.Gender;
            }
            prospectCustomer.BirthDate = model.DateOfBirth;

            prospectCustomer.Email = string.IsNullOrEmpty(model.Email) ? null : new Email(model.Email);

            prospectCustomer.CallBackPhoneNumber = PhoneNumber.Create(model.CallBackPhoneNumber, PhoneNumberType.Home);

            if (model.Address != null)
            {
                prospectCustomer.Address.StreetAddressLine1 = model.Address.StreetAddressLine1;
                prospectCustomer.Address.StreetAddressLine2 = model.Address.StreetAddressLine2;
                if (model.Address.StateId > 0)
                {
                    var state = _stateRepository.GetState(model.Address.StateId);
                    prospectCustomer.Address.State = state.Name;
                }

                if (!string.IsNullOrEmpty(model.Address.City))
                {
                    prospectCustomer.Address.City = model.Address.City;
                }
                prospectCustomer.Address.ZipCode = new ZipCode(model.Address.ZipCode);
            }

            ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);

            return true;
        }

        public bool EndActiveCall(CallQueueCustomer callQueueCustomer, long callId, bool isCallQueueRequsted, long orgainizationRoleId, bool isRemoveFromQueueRequested, long? callOutcomeId = null, string skipCallNotes = "")
        {
            using (var scope = new TransactionScope())
            {
                var callQueueStatus = CallQueueStatus.Initial;
                if (isRemoveFromQueueRequested)
                    callQueueStatus = CallQueueStatus.Removed;
                UpdateCallDetails(callId, callOutcomeId, skipCallNotes);
                if (callQueueCustomer != null)
                {
                    SetCallQueueCustomerStatus(callQueueCustomer, callQueueStatus, orgainizationRoleId, isCallQueueRequsted, callOutcomeId);
                    _callQueueCustomerLockRepository.RelaseCallQueueCustomerLock(callQueueCustomer.Id);
                }
                scope.Complete();
            }
            return true;
        }

        public bool SetCallQueueCustomerStatus(CallQueueCustomer callQueueCustomer, CallQueueStatus status, long orgainizationRoleId, bool isCallQueueRequsted, long? callOutcomeId, DateTime? callDate = null)
        {
            callQueueCustomer.Status = status;
            callQueueCustomer.DateModified = DateTime.Now;
            callQueueCustomer.CallDate = callOutcomeId.HasValue && callOutcomeId.Value == (long)CallStatus.CallSkipped ? DateTime.Now.AddDays(1) : callQueueCustomer.CallDate;
            callQueueCustomer.ContactedDate = callDate.HasValue ? callDate.Value : DateTime.Now;
            if (callOutcomeId.HasValue)
                callQueueCustomer.CallStatus = callOutcomeId.Value;

            var callQueue = _callQueueRepository.GetById(callQueueCustomer.CallQueueId);

            if (!callOutcomeId.HasValue || callOutcomeId != (long)CallStatus.CallSkipped)
            {
                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                {
                    callQueueCustomer.CallCount = callQueueCustomer.CallCount + 1;
                    if (isCallQueueRequsted)
                    {
                        callQueueCustomer.Attempts = callQueueCustomer.Attempts + 1 >= callQueue.Attempts ? callQueue.Attempts - 1 : callQueueCustomer.Attempts + 1;
                    }
                    else
                    {
                        callQueueCustomer.Attempts = callQueueCustomer.Attempts + 1;
                    }
                }
                else
                {
                    if (callOutcomeId == (long)CallStatus.Attended || callOutcomeId == (long)CallStatus.VoiceMessage || callOutcomeId == (long)CallStatus.LeftMessageWithOther)
                    {
                        callQueueCustomer.CallCount = callQueueCustomer.CallCount + 1;
                        if (isCallQueueRequsted)
                        {
                            callQueueCustomer.Attempts = callQueueCustomer.Attempts + 1 >= callQueue.Attempts ? callQueue.Attempts - 1 : callQueueCustomer.Attempts + 1;
                        }
                        else
                        {
                            callQueueCustomer.Attempts = callQueueCustomer.Attempts + 1;
                        }
                    }
                }
            }

            callQueueCustomer.ModifiedByOrgRoleUserId = orgainizationRoleId;

            _callQueueCustomerRepository.Save(callQueueCustomer);

            return true;
        }

        private bool UpdateCallDetails(long callId, long? callOutcomeId, string skipCallNotes)
        {
            var call = _callCenterCallRepository.GetById(callId);
            if (callOutcomeId.HasValue && callOutcomeId == (long)CallStatus.CallSkipped)
            {
                call.Status = callOutcomeId.Value;
                if (!string.IsNullOrEmpty(skipCallNotes))
                    SaveNotes(skipCallNotes, callId);
            }
            call.EndTime = DateTime.Now;
            call.DateModified = DateTime.Now;
            _callCenterCallRepository.Save(call);

            return true;
        }

        private void SaveNotes(string note, long callId)
        {
            var callCenterNotes = new CallCenterNotes
            {
                CallId = callId,
                Notes = note,
                IsActive = true,
                NotesSequence = 1
            };

            _callCenterNotesRepository.Save(callCenterNotes);
        }

        private string GetCustomerAdditionalField(Customer customer, long additionalField)
        {
            switch ((AdditionalFieldsEnum)additionalField)
            {
                case AdditionalFieldsEnum.AdditionalField1:
                    return string.IsNullOrEmpty(customer.AdditionalField1) ? "N/A" : customer.AdditionalField1;
                case AdditionalFieldsEnum.AdditionalField2:
                    return string.IsNullOrEmpty(customer.AdditionalField2) ? "N/A" : customer.AdditionalField2;
                case AdditionalFieldsEnum.AdditionalField3:
                    return string.IsNullOrEmpty(customer.AdditionalField3) ? "N/A" : customer.AdditionalField3;
                case AdditionalFieldsEnum.AdditionalField4:
                    return string.IsNullOrEmpty(customer.AdditionalField4) ? "N/A" : customer.AdditionalField4;
            }

            return string.Empty;
        }

        public CustomerContactViewModel GetCustomerContactViewModelByAttempt(long callQueueCustomerId, long attemptId, long orgRoleUserId)
        {
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            var attempt = _customerCallQueueCallAttemptRepository.GetById(attemptId);
            var callQueue = _callQueueRepository.GetById(callQueueCustomer.CallQueueId);
            var criteria = callQueueCustomer.CallQueueCriteriaId.HasValue ? _healthPlanCallQueueCriteriaRepository.GetById(callQueueCustomer.CallQueueCriteriaId.Value) : null;

            var customer = _customerRepository.GetCustomer(callQueueCustomer.CustomerId.Value);

            var memberIdLabel = string.Empty;
            CorporateAccount corporateAccount = null;
            CustomerEligibility customerEligibility = null;
            if (customer != null)
            {
                customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);
                    memberIdLabel = corporateAccount != null ? corporateAccount.MemberIdLabel : string.Empty;
                }
            }

            Falcon.App.Core.Medical.Domain.ActivityType activityType = null;
            if (customer.ActivityId.HasValue)
                activityType = _activityTypeRepository.GetById(customer.ActivityId.Value);

            var patientInfo = _callQueuePatientInfomationFactory.SetCustomerInfo(customer, customerEligibility, activityType);
            CriteriaInfoViewModel criteriaInfo = null;

            var additionalFileds = new List<OrderedPair<string, string>>();
            if (corporateAccount != null)
            {
                var accountAdditionalFields = _accountAdditionalFieldRepository.GetByAccountId(corporateAccount.Id);
                if (accountAdditionalFields.Any())
                {
                    additionalFileds.AddRange(accountAdditionalFields.Select(additionalField => new OrderedPair<string, string>(additionalField.DisplayName,
                                    GetCustomerAdditionalField(customer, additionalField.AdditionalFieldId))));
                }
                if (corporateAccount.ShowCallCenterScript && corporateAccount.CallCenterScriptFileId > 0)
                {
                    var callCenterScriptPdf = _fileRepository.GetById(corporateAccount.CallCenterScriptFileId);
                    var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                    patientInfo.CallCenterScriptUrl = mediaLocation.Url + callCenterScriptPdf.Path;
                }
                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                {
                    if (corporateAccount.ShowCallCenterScript && corporateAccount.ConfirmationScriptFileId > 0)
                    {
                        var confirmationScriptPdf = _fileRepository.GetById(corporateAccount.ConfirmationScriptFileId);
                        var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                        patientInfo.CallCenterScriptUrl = mediaLocation.Url + confirmationScriptPdf.Path;
                    }
                }

                var organization = _organizationRepository.GetOrganizationbyId(corporateAccount.Id);
                patientInfo.HealthPlan = organization.Name;

                criteriaInfo = new CriteriaInfoViewModel
                {
                    HealthPlan = organization.Name,
                    CallQueue = callQueue.Name,
                    Category = callQueue.Category,
                    Percentage = criteria != null ? criteria.Percentage : 0,
                    Days = criteria != null ? criteria.NoOfDays : 0
                };

                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                    criteriaInfo.Days = corporateAccount.EventConfirmationBeforeDays.HasValue ? corporateAccount.EventConfirmationBeforeDays.Value : 0;
            }

            //patientInfo.HasMammo = _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customer.CustomerId, TestGroup.BreastCancer) && (callQueue.Category != HealthPlanCallQueueCategory.FillEventsHealthPlan);
            var hasMammo = customer != null && _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customer.CustomerId, TestGroup.BreastCancer);

            patientInfo.HasMammo = hasMammo;

            patientInfo.MammoTestAsPreApproved = hasMammo;

            //if (callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
            //{
            //    patientInfo.HasMammo = false;
            //}


            patientInfo.CustomerId = customer.CustomerId;
            patientInfo.ProspectCustomerId = callQueueCustomer.ProspectCustomerId;

            patientInfo.CallQueueCustomerId = callQueueCustomer.Id;

            patientInfo.PrimaryCarePhysician = _primaryCarePhysicianHelper.GetPrimaryCarePhysicianViewModel(callQueueCustomer.CustomerId.Value);

            var customerCustomTags = _corporateCustomerCustomTagRepository.GetByCustomerId(customer.CustomerId);
            if (!customerCustomTags.IsNullOrEmpty())
            {
                var customTags = customerCustomTags.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Select(x => x.Tag).ToArray();
                patientInfo.CustomCorporateTags = customTags.IsNullOrEmpty() ? string.Empty : string.Join(",", customTags);
            }

            Call call = null;
            if (attempt != null && attempt.CallId.HasValue)
            {
                call = _callCenterCallRepository.GetById(attempt.CallId.Value);
            }

            IEnumerable<string> preApprovedTests = _preApprovedTestRepository.GetPreApprovedTests(customer.CustomerId);
            // IEnumerable<string> preApprovedPackages = _preApprovedPackageRepository.GetPreApprovedPackageTest(customer.CustomerId);
            //IEnumerable<string> requiredTests = _requiredTestRepository.GetRequiredTests(customer.CustomerId);

            IEnumerable<Package> preApprovedPackages = null;
            //var currentCall = _callCenterCallRepository.GetById(callId);

            if (callQueueCustomer.CustomerId.HasValue)
            {
                var preApprovedPackageList = _preApprovedPackageRepository.GetByCustomerId(callQueueCustomer.CustomerId.Value);
                var packageIds = preApprovedPackageList != null ? preApprovedPackageList.Select(x => x.PackageId) : null;
                if (packageIds != null)
                {
                    preApprovedPackages = _packageRepository.GetByIds(packageIds.ToList());
                }
            }

            if (customer != null && customer.Address != null && customer.Address.StateId > 0 && corporateAccount != null)
            {
                if (call != null)
                    patientInfo.HealthPlanPhoneNumber = _customerAccountGlocomNumberService.GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customer.CustomerId, call.Id);
                else
                    patientInfo.HealthPlanPhoneNumber = _customerAccountGlocomNumberService.GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customer.CustomerId);
            }

            if (patientInfo.HealthPlanPhoneNumber == null)
            {
                patientInfo.HealthPlanPhoneNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
            }

            if (patientInfo.HealthPlanPhoneNumber != null)
            {
                string dialerUrl;
                var callCenterRepProfile = _callCenterRepProfileRepository.Get(orgRoleUserId);
                if (callCenterRepProfile != null && !string.IsNullOrEmpty(callCenterRepProfile.DialerUrl))
                {
                    dialerUrl = callCenterRepProfile.DialerUrl.ToLower().Replace(CallCenterAgentUrlKeywords.CallerId.ToLower(), (patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number))
                        .Replace(CallCenterAgentUrlKeywords.PatientId.ToLower(), patientInfo.CustomerId.ToString());
                }
                else
                {
                    dialerUrl = "Glocom://*65*" + patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number + "*1" + CallCenterAgentUrlKeywords.PatientContact.ToLower();
                }

                if (patientInfo.CallBackPhoneNumber != null)
                    patientInfo.CallBackPhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.CallBackPhoneNumber.AreaCode + patientInfo.CallBackPhoneNumber.Number));

                if (patientInfo.OfficePhoneNumber != null)
                    patientInfo.OfficePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.OfficePhoneNumber.AreaCode + patientInfo.OfficePhoneNumber.Number));

                if (patientInfo.MobilePhoneNumber != null && !string.IsNullOrEmpty(patientInfo.MobilePhoneNumber.Number))
                    patientInfo.MobilePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.MobilePhoneNumber.AreaCode + patientInfo.MobilePhoneNumber.Number));
            }

            RegisteredEventViewModel registeredEventModel = null;
            var isCancelled = false;
            if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation && callQueueCustomer.EventId.HasValue)
            {
                var eventCustomer = _eventCustomerRepository.GetById(callQueueCustomer.EventCustomerId.Value);
                var isEawvPurchased = _testResultService.IsTestPurchasedByCustomer(eventCustomer.Id, (long)TestType.eAWV);
                Appointment appointment = null;
                if (eventCustomer.AppointmentId.HasValue)
                {
                    /*if (eventCustomer.EventId != callQueueCustomer.EventId)
                        registeredEventModel.IsRescheduled = true;
                    else
                    {
                        var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                        if (appointment.StartTime != callQueueCustomer.AppointmentDate)
                            registeredEventModel.IsRescheduled = true;
                    }*/
                    appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                }
                else
                {
                    isCancelled = true;
                }

                var theEvent = _eventService.GetById(eventCustomer.EventId);

                var hostAddress = new AddressViewModel
                {
                    StreetAddressLine1 = theEvent.StreetAddressLine1,
                    StreetAddressLine2 = theEvent.StreetAddressLine2,
                    City = theEvent.City,
                    State = theEvent.State,
                    ZipCode = theEvent.Zip
                };

                QuestionnaireType questionnaireType = QuestionnaireType.None;
                if (corporateAccount != null && corporateAccount.IsHealthPlan && theEvent != null)
                {
                    questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(corporateAccount.Id, theEvent.EventDate);
                }

                registeredEventModel = new RegisteredEventViewModel
                {
                    EventId = theEvent.EventId,
                    EventDate = theEvent.EventDate,
                    AppointmentTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                    HostName = theEvent.OrganizationName,
                    HostAddress = hostAddress.ToString(),
                    EventNotes = "",
                    EventCustomerId = callQueueCustomer.EventCustomerId.HasValue ? callQueueCustomer.EventCustomerId.Value : 0,
                    TimeZone = theEvent.EventTimeZone,
                    IsCanceled = isCancelled,
                    HraQuestionerAppUrl = _settings.HraQuestionerAppUrl,
                    OrganizationNameForHraQuestioner = _settings.OrganizationNameForHraQuestioner,
                    CorporateAccountTag = corporateAccount.Tag,
                    MedicareVisitId = eventCustomer.AwvVisitId.HasValue ? eventCustomer.AwvVisitId.Value : 0,
                    Pods = theEvent.Pods.IsNullOrEmpty() ? "" : theEvent.PodNames(),
                    ShowHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire ? true : false,
                    IsEawvPurchased = isEawvPurchased,
                    ShowChatQuestionnaire = questionnaireType == QuestionnaireType.ChatQuestionnaire ? true : false,
                    ChatQuestionerAppUrl = _settings.ChatQuestionerAppUrl,
                    CaptureHaf = corporateAccount != null && corporateAccount.CaptureHaf,
                };

                attempt.IsNotesReadAndUnderstood = true;
            }


            var warmTransfer = false;
            if (customer != null && corporateAccount != null && corporateAccount.WarmTransfer)
            {
                var customerWarmTransfer = _customerWarmTransferRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                warmTransfer = customerWarmTransfer != null && customerWarmTransfer.IsWarmTransfer.HasValue && customerWarmTransfer.IsWarmTransfer.Value;
            }

            var model = new CustomerContactViewModel
            {
                PatientInfomation = patientInfo,
                PreApprovedTests = preApprovedTests,
                CallQueueCustomerAttempt = attempt,
                AdditionalFields = additionalFileds,
                MemberIdLabel = memberIdLabel,
                IsCallEnded = attempt != null && attempt.IsCallSkipped && (call == null || call.EndTime.HasValue),
                PreApprovedPackages = !preApprovedPackages.IsNullOrEmpty() ? preApprovedPackages.Select(x => x.Name).ToList() : null,
                EventInformation = registeredEventModel,
                CriteriaInfo = criteriaInfo,
                CallQueueCategory = callQueue.Category,
                WarmTransfer = warmTransfer,
                //  RequiredTests = requiredTests,
            };
            return model;
        }

        public IEnumerable<CallQueueCustomer> GetSingleCustomerFromCallQueue(OutboundCallQueueFilter filter, int pageSizeForContactCustomer, CallQueue callQueue)
        {
            IEnumerable<CallQueueCustomer> callQueueCustomer = null;
            int totalRecords = 0;

            filter.GmsAccountIds = _settings.GmsAccountIds;

            if (callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
            {
                callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerForHealthPlanFillEvents
                    (filter, filter.PageNumber, pageSizeForContactCustomer, filter.CriteriaId, callQueue, out totalRecords, false);
            }
            else if (callQueue.Category == HealthPlanCallQueueCategory.MailRound)
            {
                callQueueCustomer = _callQueueCustomerRepository.GetMailRoundCallqueueCustomer(filter, filter.PageNumber,
                    pageSizeForContactCustomer, filter.CriteriaId, callQueue, out totalRecords, false);
            }
            else if (callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier)
            {
                callQueueCustomer = _callQueueCustomerRepository.GetLanguageBarrierCallQueueCustomer
                    (filter, filter.PageNumber, pageSizeForContactCustomer, filter.CriteriaId, callQueue, out totalRecords, false);
            }

            else if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
            {
                callQueueCustomer = _callQueueCustomerRepository.GetConfirmationCallQueueCustomer(filter, filter.PageNumber, pageSizeForContactCustomer, filter.CriteriaId, callQueue, out totalRecords, false);
            }

            filter.NoOfCustomersInCallQueue = totalRecords;
            if (callQueueCustomer != null && callQueueCustomer.Count() > 0)
                return callQueueCustomer;

            return null;
        }

        public CustomerContactViewModel GetByCustomerId(long customerId, long callId, long orgRoleUserId)
        {
            if (customerId <= 0) return null;

            var callQueueCustomerId = _callQueueCustomerCallRepository.GetCallQueueCustomerIdByCallId(callId);

            CallQueueCustomer callQueueCustomer = null;

            if (callQueueCustomerId > 0)
                callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            //else
            //    callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerByCustomerId(customerId, HealthPlanCallQueueCategory.MailRound);

            CallQueue callQueue = null;
            if (callQueueCustomer != null)
                callQueue = _callQueueRepository.GetById(callQueueCustomer.CallQueueId);

            var customer = _customerRepository.GetCustomer(customerId);

            //UpdateCall(callQueueCustomer, orgRoleUserId, customer, callId);

            var memberIdLabel = string.Empty;
            CorporateAccount corporateAccount = null;
            CustomerEligibility customerEligibility = null;
            if (customer != null)
            {
                customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);
                    memberIdLabel = corporateAccount != null ? corporateAccount.MemberIdLabel : string.Empty;
                }
            }

            var prospectCustomer = callQueueCustomer == null ? _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId) : (callQueueCustomer.ProspectCustomerId.HasValue
                ? _prospectCustomerRepository.GetProspectCustomer(callQueueCustomer.ProspectCustomerId.Value)
                : (callQueueCustomer.CustomerId.HasValue ? _prospectCustomerRepository.GetProspectCustomerByCustomerId(callQueueCustomer.CustomerId.Value) : null));

            CallQueuePatientInfomationViewModel patientInfo = null;

            if (customer != null)
            {
                Falcon.App.Core.Medical.Domain.ActivityType activityType = null;
                if (customer.ActivityId.HasValue)
                    activityType = _activityTypeRepository.GetById(customer.ActivityId.Value);

                patientInfo = _callQueuePatientInfomationFactory.SetCustomerInfo(customer, customerEligibility, activityType);
            }
            else
                patientInfo = _callQueuePatientInfomationFactory.SetProspectCustomerInfo(prospectCustomer);


            //if (customer != null && customer.Address != null && customer.Address.StateId > 0 && corporateAccount != null)
            //{
            //    patientInfo.HealthPlanPhoneNumber = GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customer.CustomerId, callId);
            //}

            if (patientInfo.HealthPlanPhoneNumber == null)
            {
                patientInfo.HealthPlanPhoneNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
            }
            var additionalFileds = new List<OrderedPair<string, string>>();

            if (corporateAccount != null)
            {
                var accountAdditionalFields = _accountAdditionalFieldRepository.GetByAccountId(corporateAccount.Id);
                if (accountAdditionalFields.Any())
                {
                    additionalFileds.AddRange(accountAdditionalFields.Select(additionalField => new OrderedPair<string, string>(additionalField.DisplayName,
                                    GetCustomerAdditionalField(customer, additionalField.AdditionalFieldId))));
                }
                if (corporateAccount.ShowCallCenterScript && corporateAccount.CallCenterScriptFileId > 0)
                {
                    var callCenterScriptPdf = _fileRepository.GetById(corporateAccount.CallCenterScriptFileId);
                    var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                    patientInfo.CallCenterScriptUrl = mediaLocation.Url + callCenterScriptPdf.Path;
                }
                if (callQueue != null && callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                {
                    if (corporateAccount.ShowCallCenterScript && corporateAccount.ConfirmationScriptFileId > 0)
                    {
                        var confirmationScriptPdf = _fileRepository.GetById(corporateAccount.ConfirmationScriptFileId);
                        var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                        patientInfo.CallCenterScriptUrl = mediaLocation.Url + confirmationScriptPdf.Path;
                    }
                }
            }

            //patientInfo.HasMammo = customer != null && _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customer.CustomerId, TestGroup.BreastCancer) && (callQueue.Category != HealthPlanCallQueueCategory.FillEventsHealthPlan);
            var hasMammo = customer != null && _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customer.CustomerId, TestGroup.BreastCancer);

            patientInfo.HasMammo = hasMammo;

            patientInfo.MammoTestAsPreApproved = hasMammo;

            //if (callQueue != null && callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan)
            //{
            //    patientInfo.HasMammo = false;
            //}


            patientInfo.CustomerId = customerId;
            patientInfo.ProspectCustomerId = callQueueCustomer != null ? callQueueCustomer.ProspectCustomerId : null;

            patientInfo.CallQueueCustomerId = callQueueCustomer != null ? callQueueCustomer.Id : 0;

            patientInfo = _callQueuePatientInfomationFactory.SetCustomerTagInfo(prospectCustomer, patientInfo);

            if (patientInfo != null && callQueue != null && callQueue.IsHealthPlan)
            {
                patientInfo.PrimaryCarePhysician = _primaryCarePhysicianHelper.GetPrimaryCarePhysicianViewModel(customerId);
            }

            if (customer != null)
            {
                var customerCustomTags = _corporateCustomerCustomTagRepository.GetByCustomerId(customer.CustomerId);
                if (!customerCustomTags.IsNullOrEmpty())
                {
                    var customTags = customerCustomTags.OrderByDescending(x => x.DataRecorderMetaData.DateCreated).Select(x => x.Tag).ToArray();
                    patientInfo.CustomCorporateTags = customTags.IsNullOrEmpty() ? string.Empty : string.Join(",", customTags);
                }
            }
            //   var currentCall = _callCenterCallRepository.GetById(callId);


            
            IEnumerable<string> preApprovedTests = null;
            var preApprovedTestsList = _preApprovedTestRepository.GetPreApprovedTests(customerId);
            if (preApprovedTestsList.Count() > 0)
            {
                preApprovedTests = preApprovedTestsList;
            }

            //IEnumerable<string> preApprovedPackages = _preApprovedPackageRepository.GetPreApprovedPackageTest(customerId);
            //IEnumerable<string> requiredTests = _requiredTestRepository.GetRequiredTests(customerId);

            IEnumerable<Package> preApprovedPackages = null;
            var preApprovedPackageList = _preApprovedPackageRepository.GetByCustomerId(customerId);
            var packageIds = preApprovedPackageList != null ? preApprovedPackageList.Select(x => x.PackageId) : null;
            if (packageIds != null)
            {
                preApprovedPackages = _packageRepository.GetByIds(packageIds.ToList());
            }

            if (customer != null && customer.Address != null && customer.Address.StateId > 0 && corporateAccount != null)
            {
                patientInfo.HealthPlanPhoneNumber = _customerAccountGlocomNumberService.GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customer.CustomerId, callId);
            }

            if (patientInfo.HealthPlanPhoneNumber == null)
            {
                patientInfo.HealthPlanPhoneNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
            }

            if (patientInfo.HealthPlanPhoneNumber != null)
            {
                string dialerUrl;
                var callCenterRepProfile = _callCenterRepProfileRepository.Get(orgRoleUserId);
                if (callCenterRepProfile != null && !string.IsNullOrEmpty(callCenterRepProfile.DialerUrl))
                {
                    dialerUrl = callCenterRepProfile.DialerUrl.ToLower().Replace(CallCenterAgentUrlKeywords.CallerId.ToLower(), (patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number))
                        .Replace(CallCenterAgentUrlKeywords.PatientId.ToLower(), patientInfo.CustomerId.ToString());
                }
                else
                {
                    dialerUrl = "Glocom://*65*" + patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number + "*1" + CallCenterAgentUrlKeywords.PatientContact.ToLower();
                }

                if (patientInfo.CallBackPhoneNumber != null)
                    patientInfo.CallBackPhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.CallBackPhoneNumber.AreaCode + patientInfo.CallBackPhoneNumber.Number));

                if (patientInfo.OfficePhoneNumber != null)
                    patientInfo.OfficePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.OfficePhoneNumber.AreaCode + patientInfo.OfficePhoneNumber.Number));

                if (patientInfo.MobilePhoneNumber != null && !string.IsNullOrEmpty(patientInfo.MobilePhoneNumber.Number))
                    patientInfo.MobilePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.MobilePhoneNumber.AreaCode + patientInfo.MobilePhoneNumber.Number));
            }

            var callQueueCustomerAttempt = _customerCallQueueCallAttemptRepository.GetByCallId(callId);

            RegisteredEventViewModel registeredEventModel = null;
            var isCancelled = false;
            if (callQueue != null && callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation && callQueueCustomer.EventId.HasValue)
            {
                var eventCustomer = _eventCustomerRepository.GetById(callQueueCustomer.EventCustomerId.Value);
                var isEawvPurchased = _testResultService.IsTestPurchasedByCustomer(eventCustomer.Id, (long)TestType.eAWV);
                Appointment appointment = null;
                if (eventCustomer.AppointmentId.HasValue)
                {
                    /*if (eventCustomer.EventId != callQueueCustomer.EventId)
                        registeredEventModel.IsRescheduled = true;
                    else
                    {
                        var appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                        if (appointment.StartTime != callQueueCustomer.AppointmentDate)
                            registeredEventModel.IsRescheduled = true;
                    }*/
                    appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                }
                else
                {
                    isCancelled = true;
                }

                var theEvent = _eventService.GetById(eventCustomer.EventId);

                var hostAddress = new AddressViewModel
                {
                    StreetAddressLine1 = theEvent.StreetAddressLine1,
                    StreetAddressLine2 = theEvent.StreetAddressLine2,
                    City = theEvent.City,
                    State = theEvent.State,
                    ZipCode = theEvent.Zip
                };

                QuestionnaireType questionnaireType = QuestionnaireType.None;
                if (corporateAccount != null && corporateAccount.IsHealthPlan && theEvent != null)
                {
                    questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(corporateAccount.Id, theEvent.EventDate);
                }

                registeredEventModel = new RegisteredEventViewModel
                {
                    EventId = theEvent.EventId,
                    EventDate = theEvent.EventDate,
                    AppointmentTime = appointment != null ? appointment.StartTime : (DateTime?)null,
                    HostName = theEvent.OrganizationName,
                    HostAddress = hostAddress.ToString(),
                    EventNotes = "",
                    EventCustomerId = callQueueCustomer.EventCustomerId.HasValue ? callQueueCustomer.EventCustomerId.Value : 0,
                    TimeZone = theEvent.EventTimeZone,
                    IsCanceled = isCancelled,
                    HraQuestionerAppUrl = _settings.HraQuestionerAppUrl,
                    OrganizationNameForHraQuestioner = _settings.OrganizationNameForHraQuestioner,
                    CorporateAccountTag = corporateAccount.Tag,
                    MedicareVisitId = eventCustomer.AwvVisitId.HasValue ? eventCustomer.AwvVisitId.Value : 0,
                    Pods = theEvent.Pods.IsNullOrEmpty() ? "" : theEvent.PodNames(),
                    ShowHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire ? true : false,
                    IsEawvPurchased = isEawvPurchased,

                    ShowChatQuestionnaire = questionnaireType == QuestionnaireType.ChatQuestionnaire ? true : false,
                    ChatQuestionerAppUrl = _settings.ChatQuestionerAppUrl,
                    AllowNonMammoPatients = theEvent.AllowNonMammoPatients,
                    CaptureHaf = corporateAccount != null && corporateAccount.CaptureHaf,
                };

                callQueueCustomerAttempt.IsNotesReadAndUnderstood = true;
            }
            if (corporateAccount != null)
            {
                var organization = _organizationRepository.GetOrganizationbyId(corporateAccount.Id);
                patientInfo.HealthPlan = organization.Name;
            }

            var warmTransfer = false;
            if (customer != null && corporateAccount != null && corporateAccount.WarmTransfer)
            {
                var customerWarmTransfer = _customerWarmTransferRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                warmTransfer = customerWarmTransfer != null && customerWarmTransfer.IsWarmTransfer.HasValue && customerWarmTransfer.IsWarmTransfer.Value;
            }

            var model = new CustomerContactViewModel
            {
                PatientInfomation = patientInfo,
                // CallHistory = callHistoryModel,
                PreApprovedTests = preApprovedTests,
                //    ReadAndUnderstood = currentCall != null && currentCall.ReadAndUnderstood.HasValue && currentCall.ReadAndUnderstood.Value,
                AdditionalFields = additionalFileds,
                MemberIdLabel = memberIdLabel,
                //  IsCallEnded = currentCall != null && currentCall.Status == (long)CallStatus.CallSkipped && currentCall.EndTime.HasValue,
                PreApprovedPackages = !preApprovedPackages.IsNullOrEmpty() ? preApprovedPackages.Select(x => x.Name).ToList() : null,
                CallId = callId,
                HealthPlanId = corporateAccount != null ? corporateAccount.Id : 0,
                CallQueueCustomerAttempt = callQueueCustomerAttempt ?? new CustomerCallQueueCallAttempt { IsNotesReadAndUnderstood = true },
                EventInformation = registeredEventModel,
                WarmTransfer = warmTransfer,
                // RequiredTests = requiredTests,
            };
            var isHealthPlanCallQueue = callQueueCustomer != null;
            var patientInfoEditModel = _callQueuePatientInfomationFactory.GetCallQueueCustomerEditModel(model, isHealthPlanCallQueue);
            model.PatientInfoEditModel = patientInfoEditModel;
            model.PatientInfoEditViewModel = patientInfoEditModel;
            return model;
        }

        public long StartCall(long orgRoleUserId, long customerId, long callId = 0)
        {
            long callQueueCustomerId = 0;
            if (callId > 0)
                callQueueCustomerId = _callQueueCustomerCallRepository.GetCallQueueCustomerIdByCallId(callId);

            CallQueueCustomer callQueueCustomer = null;

            if (callQueueCustomerId > 0)
                callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            else
                callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerByCustomerIdForGms(customerId, HealthPlanCallQueueCategory.MailRound);

            if (callQueueCustomer == null)
                return 0;

            var customer = _customerRepository.GetCustomer(customerId);

            return SaveCallQueueCustomerDetailAndGetCallId(callQueueCustomer, customer, HealthPlanCallQueueCategory.MailRound, orgRoleUserId, callId, (long)DialerType.Gms);
        }

        private bool UpdateContactedInfo(long prospectCustomerId, long callId, long orgRoleUserId)
        {
            _callCenterRepository.BindCallToProspectCustomerForCallQueue(callId, prospectCustomerId);
            return _prospectCustomerRepository.UpdateContactedStatus(prospectCustomerId, orgRoleUserId);
        }

        public long StartCallForDailer(long orgRoleUserId, long customerId, long callQueueId, long callId = 0)
        {
            var callQueue = _callQueueRepository.GetById(callQueueId);

            long callQueueCustomerId = 0;

            if (callId > 0)
            {
                callQueueCustomerId = _callQueueCustomerCallRepository.GetCallQueueCustomerIdByCallId(callId);
            }
            else
            {
                var customerCallQueueCallAttempt = _customerCallQueueCallAttemptRepository.GetCustomerCallQueueCallAttemptIfCustomerLockedforAgent(customerId, orgRoleUserId);
                if (customerCallQueueCallAttempt != null && customerCallQueueCallAttempt.CallId.HasValue)
                {
                    var callQueueCustomerLock = new CallQueueCustomerLock
                    {
                        CallQueueCustomerId = customerCallQueueCallAttempt.CallQueueCustomerId,
                        CreatedBy = orgRoleUserId,
                        CreatedOn = DateTime.Now,
                        CustomerId = customerId
                    };

                    _callQueueCustomerLockRepository.UpdateCallQueueCustomerLock(callQueueCustomerLock);

                    return customerCallQueueCallAttempt.CallId.Value;
                }

                if (customerCallQueueCallAttempt != null)
                {
                    callQueueCustomerId = customerCallQueueCallAttempt.CallQueueCustomerId;
                }
            }

            CallQueueCustomer callQueueCustomer = null;

            if (callQueueCustomerId > 0)
                callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            else
                callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerByCustomerId(customerId, callQueue.Category);

            if (callQueueCustomer == null)
                return 0;

            var customer = _customerRepository.GetCustomer(customerId);

            return SaveCallQueueCustomerDetailAndGetCallId(callQueueCustomer, customer, callQueue.Category, orgRoleUserId, callId, (long)DialerType.Vici);
        }

        private long SaveCallQueueCustomerDetailAndGetCallId(CallQueueCustomer callQueueCustomer, Customer customer, string callQueueCategory, long orgRoleUserId, long callId, long dialerType, long eventId = 0)
        {
            using (var scope = new TransactionScope())
            {
                //lock customer in call queue so that other agent not be able to call them;
                var domain = new CallQueueCustomerLock
                {
                    CallQueueCustomerId = callQueueCustomer.Id,
                    CustomerId = callQueueCustomer.CustomerId,
                    ProspectCustomerId = callQueueCustomer.ProspectCustomerId,
                    CreatedBy = orgRoleUserId,
                    CreatedOn = DateTime.Now
                };

                _callQueueCustomerLockRepository.SaveCallQueueCustomerLock(domain);
                var customerId = customer != null ? customer.CustomerId : 0;

                var prospectCustomerId = callQueueCustomer.ProspectCustomerId.HasValue ? callQueueCustomer.ProspectCustomerId.Value : 0;
                var organizationRoleUserId = orgRoleUserId;
                var callStatus = customerId > 0 ? CallType.Existing_Customer.ToString().Replace("_", " ") : CallType.Register_New_Customer.ToString().Replace("_", " ");

                PhoneNumber glocomNumber = null;
                if (customer != null && customer.Address != null && callQueueCustomer.HealthPlanId.HasValue)
                {
                    glocomNumber = _customerAccountGlocomNumberService.GetGlocomNumber(callQueueCustomer.HealthPlanId.Value, customer.Address.StateId, customerId);

                    if (glocomNumber == null)
                    {
                        var corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);
                        glocomNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
                    }
                }

                var incomingPhoneLine = glocomNumber != null ? glocomNumber.AreaCode + glocomNumber.Number : "";

                var patientPhoneNumber = callQueueCustomer.PhoneHome ?? (callQueueCustomer.PhoneOffice ?? callQueueCustomer.PhoneCell);
                var callerNumber = patientPhoneNumber != null ? patientPhoneNumber.AreaCode + patientPhoneNumber.Number : "";

                callId = _outboundCallQueueService.SetCallDetail(organizationRoleUserId, customerId, incomingPhoneLine, callerNumber, callStatus, callQueueCustomer.CampaignId,
                    callQueueCustomer.HealthPlanId, "", callQueueCustomer.CallQueueId, callId, true, dialerType: dialerType, callQueueCategory: callQueueCategory, eventId: eventId, ProductTypeId: customer.ProductTypeId);

                callQueueCustomer.Status = CallQueueStatus.InProcess;
                callQueueCustomer.DateModified = DateTime.Now;
                callQueueCustomer.ModifiedByOrgRoleUserId = orgRoleUserId;
                callQueueCustomer.CallStatus = (long)CallStatus.Initiated;
                callQueueCustomer.ContactedDate = DateTime.Now;

                _callQueueCustomerRepository.Save(callQueueCustomer, false);

                var callQueueCustomerCall = new CallQueueCustomerCall { CallQueueCustomerId = callQueueCustomer.Id, CallId = callId };
                _callQueueCustomerCallRepository.Save(callQueueCustomerCall, false);

                if (customerId == 0 && prospectCustomerId > 0)
                {
                    UpdateContactedInfo(prospectCustomerId, callId, orgRoleUserId);
                }
                else if (customerId > 0)
                {
                    //var callQueue = _callQueueRepository.GetById(callQueueCustomer.CallQueueId);
                    if (!(callQueueCategory == CallQueueCategory.Upsell || callQueueCategory == CallQueueCategory.Confirmation))
                    {
                        var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);

                        if (prospectCustomer == null && customer != null)
                        {
                            prospectCustomer = _prospectCustomerFactory.CreateProspectCustomerFromCustomer(customer, false);
                            prospectCustomer = ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);
                        }
                        if (prospectCustomer != null)
                        {
                            UpdateContactedInfo(prospectCustomer.Id, callId, orgRoleUserId);
                        }
                    }

                }

                var editmodel = new CallQueueCustomerCallDetailsEditModel
                {
                    CallQueueCustomerId = callQueueCustomer.Id,
                    Disposition = string.Empty,
                    CallStatusId = (long)CallStatus.Initiated,
                    IsCallSkipped = false,
                    ModifiedByOrgRoleUserId = orgRoleUserId,
                    Attempt = 0,
                    CallQueueStatus = (long)CallQueueStatus.Initial,
                    CallDate = DateTime.Today.AddDays(30),
                };

                _callQueueCustomerRepository.UpdateCallqueueCustomerByCustomerId(editmodel, customerId);

                var customerCallQueueCallAttempt = new CustomerCallQueueCallAttempt
                {
                    DateCreated = DateTime.Now,
                    IsCallSkipped = false,
                    IsNotesReadAndUnderstood = true,
                    CreatedBy = orgRoleUserId,
                    CustomerId = customerId,
                    CallId = callId,
                    CallQueueCustomerId = callQueueCustomer.Id,
                    NotInterestedReasonId = null
                };

                _customerCallQueueCallAttemptRepository.Save(customerCallQueueCallAttempt, false);

                if (glocomNumber != null)
                {
                    var customerAccountGlocomNumber = new CustomerAccountGlocomNumber
                    {
                        CallId = callId,
                        CustomerId = customerId,
                        GlocomNumber = glocomNumber.AreaCode + glocomNumber.Number,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };
                    _customerAccountGlocomNumberService.SaveAccountCheckoutPhoneNumber(customerAccountGlocomNumber);
                }

                scope.Complete();
                return callId;
            }
        }

        public long StartCallForAppointmentConfirmation(long orgRoleUserId, long customerId, long eventId, long callQueueId, long callId = 0)
        {
            var callQueue = _callQueueRepository.GetById(callQueueId);

            long callQueueCustomerId = 0;

            if (callId > 0)
            {
                callQueueCustomerId = _callQueueCustomerCallRepository.GetCallQueueCustomerIdByCallId(callId);
            }
            else
            {
                var customerCallQueueCallAttempt = _customerCallQueueCallAttemptRepository.GetCustomerCallQueueCallAttemptIfCustomerLockedforAgent(customerId, orgRoleUserId);
                if (customerCallQueueCallAttempt != null)
                {
                    var callQueueCustomerLock = new CallQueueCustomerLock
                    {
                        CallQueueCustomerId = customerCallQueueCallAttempt.CallQueueCustomerId,
                        CreatedBy = orgRoleUserId,
                        CreatedOn = DateTime.Now,
                        CustomerId = customerId
                    };

                    _callQueueCustomerLockRepository.UpdateCallQueueCustomerLock(callQueueCustomerLock);

                    if (customerCallQueueCallAttempt.CallId.HasValue)
                        return customerCallQueueCallAttempt.CallId.Value;

                    callQueueCustomerId = customerCallQueueCallAttempt.CallQueueCustomerId;
                }
            }

            CallQueueCustomer callQueueCustomer = null;

            if (callQueueCustomerId > 0)
                callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            else
                callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerByCustomerIdForAppointmentConfirmation(customerId, callQueueId, eventId);

            if (callQueueCustomer == null)
                return 0;

            var customer = _customerRepository.GetCustomer(customerId);

            return SaveCallQueueCustomerDetailAndGetCallId(callQueueCustomer, customer, callQueue.Category, orgRoleUserId, callId, (long)DialerType.Vici, eventId);
        }

        /// <summary>
        /// Use with caution , not a Generalised implementation , used only to get model after Phone number and consent update from Contact Detail page (angular)
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="callId"></param>
        /// <param name="orgRoleUserId"></param>
        /// <returns></returns>
        public CallQueuePatientInfomationViewModel PatientInfoPhoneModelForConsentUpdateCcRep(Customer customer, long callId, long orgRoleUserId)
        {
            Falcon.App.Core.Medical.Domain.ActivityType activityType = null;
            if (customer.ActivityId.HasValue)
                activityType = _activityTypeRepository.GetById(customer.ActivityId.Value);

            var patientInfo = _callQueuePatientInfomationFactory.SetCustomerInfo(customer, null, activityType);
            var corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);

            if (customer != null && customer.Address != null && customer.Address.StateId > 0 && corporateAccount != null)
            {
                patientInfo.HealthPlanPhoneNumber = _customerAccountGlocomNumberService.GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customer.CustomerId, callId);
            }
            if (patientInfo.HealthPlanPhoneNumber == null)
            {
                patientInfo.HealthPlanPhoneNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
            }

            if (patientInfo.HealthPlanPhoneNumber != null)
            {
                string dialerUrl;
                var callCenterRepProfile = _callCenterRepProfileRepository.Get(orgRoleUserId);
                if (callCenterRepProfile != null && !string.IsNullOrEmpty(callCenterRepProfile.DialerUrl))
                {
                    dialerUrl = callCenterRepProfile.DialerUrl.ToLower().Replace(CallCenterAgentUrlKeywords.CallerId.ToLower(), (patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number))
                        .Replace(CallCenterAgentUrlKeywords.PatientId.ToLower(), patientInfo.CustomerId.ToString());
                }
                else
                {
                    dialerUrl = "Glocom://*65*" + patientInfo.HealthPlanPhoneNumber.AreaCode + patientInfo.HealthPlanPhoneNumber.Number + "*1" + CallCenterAgentUrlKeywords.PatientContact.ToLower();
                }

                if (patientInfo.CallBackPhoneNumber != null)
                    patientInfo.CallBackPhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.CallBackPhoneNumber.AreaCode + patientInfo.CallBackPhoneNumber.Number));

                if (patientInfo.OfficePhoneNumber != null)
                    patientInfo.OfficePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.OfficePhoneNumber.AreaCode + patientInfo.OfficePhoneNumber.Number));

                if (patientInfo.MobilePhoneNumber != null && !string.IsNullOrEmpty(patientInfo.MobilePhoneNumber.Number))
                    patientInfo.MobilePhoneNumberUrl = dialerUrl.Replace(CallCenterAgentUrlKeywords.PatientContact.ToLower(), (patientInfo.MobilePhoneNumber.AreaCode + patientInfo.MobilePhoneNumber.Number));
            }

            if (corporateAccount != null)
            {
                var organization = _organizationRepository.GetOrganizationbyId(corporateAccount.Id);
                patientInfo.HealthPlan = organization.Name;
            }
            return patientInfo;
        }

        public long StartOutboundCallForCustomerNotInCallQueue(long customerId, long orgRoleUserId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            if (customer == null)
                return 0;

            var call = new Call
            {
                CreatedByOrgRoleUserId = orgRoleUserId,
                StartTime = DateTime.Now,
                IsIncoming = false,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CalledCustomerId = customerId,
                Status = (long)CallStatus.Initiated,
                DialerType = (long)DialerType.Vici,
                CallStatus = CallType.Existing_Customer.GetDescription(),
                ReadAndUnderstood = true,
                ProductTypeId=customer.ProductTypeId
            };

            if (!string.IsNullOrEmpty(customer.Tag))
            {
                var corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);
                PhoneNumber glocomNumber = null;
                if (customer.Address != null)
                {
                    glocomNumber = _customerAccountGlocomNumberService.GetGlocomNumber(corporateAccount.Id, customer.Address.StateId, customerId);

                    if (glocomNumber == null)
                    {
                        glocomNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
                    }
                }
                var patientPhoneNumber = customer.HomePhoneNumber ?? (customer.OfficePhoneNumber ?? customer.MobilePhoneNumber);
                var callerNumber = patientPhoneNumber != null ? patientPhoneNumber.AreaCode + patientPhoneNumber.Number : "";

                call.CallerNumber = callerNumber;
                call.CallBackNumber = callerNumber;
                call.CalledInNumber = glocomNumber != null ? glocomNumber.AreaCode + glocomNumber.Number : "";
            }


            call = _callCenterCallRepository.Save(call);
            return call != null ? call.Id : 0;
        }
    }
}