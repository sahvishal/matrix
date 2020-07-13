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
    public class PreAssessmentCallQueueService : IPreAssessmentCallQueueService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;

        private readonly IPreAssessmentCallQueuePatientInfomationFactory _preAssessmentCallQueuePatientInfomationFactory;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IEventService _eventService;
        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IAddressService _addressService;
        private readonly IStateRepository _stateRepository;
        private readonly ICustomerService _customerService;

        private readonly IPreAssessmentCallQueueCustomerLockRepository _preAssessmentCallQueueCustomerLockRepository;
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

        private readonly IPreAssessmentCustomerCallQueueCallAttemptRepository _preAssessmentCustomerCallQueueCallAttemptRepository;
        private readonly ICustomerAccountGlocomNumberService _customerAccountGlocomNumberService;
        private readonly IOrganizationRepository _organizationRepository;

        private readonly IOutboundCallQueueService _outboundCallQueueService;

        private readonly IProspectCustomerFactory _prospectCustomerFactory;
        private readonly ICallCenterRepository _callCenterRepository;
        private readonly ICallCenterRepProfileRepository _callCenterRepProfileRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICustomerWarmTransferRepository _customerWarmTransferRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly ISettings _settings;
        private readonly ITestResultService _testResultService;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;

        public PreAssessmentCallQueueService(ICustomerRepository customerRepository,
            IProspectCustomerRepository prospectCustomerRepository, IPreAssessmentCallQueuePatientInfomationFactory preAssessmentCallQueuePatientInfomationFactory,
            ICallCenterCallRepository callCenterCallRepository,
            IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository,
             IAddressService addressService, IStateRepository stateRepository,
            ICustomerService customerService, IPreAssessmentCallQueueCustomerLockRepository preAssessmentCallQueueCustomerLockRepository,
            ICallQueueRepository callQueueRepository, IPreApprovedTestRepository preApprovedTestRepository,
            IPrimaryCarePhysicianHelper primaryCarePhysicianHelper, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            ICorporateAccountRepository corporateAccountRepository, ICustomerNotesService customerNotesService,
            IAccountAdditionalFieldRepository accountAdditionalFieldRepository, ICallCenterNotesRepository callCenterNotesRepository,
            IPreApprovedPackageRepository preApprovedPackageRepository, IPackageRepository packageRepository,
            IPreAssessmentCustomerCallQueueCallAttemptRepository preAssessmentCustomerCallQueueCallAttemptRepository, ICustomerAccountGlocomNumberService customerAccountGlocomNumberService,
            IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, IEventService eventService, IAppointmentRepository appointmentRepository, IOrganizationRepository organizationRepository,
            IOutboundCallQueueService outboundCallQueueService,
            IProspectCustomerFactory prospectCustomerFactory, ICallCenterRepository callCenterRepository, ISettings settings, ICallCenterRepProfileRepository callCenterRepProfileRepository,
            ICustomerEligibilityRepository customerEligibilityRepository, ICustomerWarmTransferRepository customerWarmTransferRepository, ITestResultService testResultService, IActivityTypeRepository activityTypeRepository,
            IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices
                      )
        {

            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _preAssessmentCallQueuePatientInfomationFactory = preAssessmentCallQueuePatientInfomationFactory;
            _callCenterCallRepository = callCenterCallRepository;
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _addressService = addressService;
            _stateRepository = stateRepository;
            _customerService = customerService;
            _preAssessmentCallQueueCustomerLockRepository = preAssessmentCallQueueCustomerLockRepository;
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
            _preAssessmentCustomerCallQueueCallAttemptRepository = preAssessmentCustomerCallQueueCallAttemptRepository;
            _customerAccountGlocomNumberService = customerAccountGlocomNumberService;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _eventService = eventService;
            _appointmentRepository = appointmentRepository;
            _organizationRepository = organizationRepository;

            _outboundCallQueueService = outboundCallQueueService;

            _prospectCustomerFactory = prospectCustomerFactory;
            _callCenterRepository = callCenterRepository;
            _settings = settings;
            _callCenterRepProfileRepository = callCenterRepProfileRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _customerWarmTransferRepository = customerWarmTransferRepository;
            _testResultService = testResultService;
            _activityTypeRepository = activityTypeRepository;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;

        }
        //public void GetDataFromAPI(PreAssessmentCallQueueModel preAssessmentCallQueueModel)
        //{

        //    try
        //    {


        //        var eventIds = preAssessmentCallQueueModel.Data.Select(x => x.EventID).Distinct();
        //        var eventDetails = _eventRepository.GetEvents(eventIds);
        //        var NotexistsEvents = eventIds.Except(eventDetails.Select(x=>x.Id));
        //        if (NotexistsEvents.Count() > default(long))
        //        {
        //            _logger.Info(string.Format("EventId : {0}   is not exists", string.Join(",", NotexistsEvents)));
        //        }

        //        foreach (var eventId in eventDetails)
        //        {


        //                var customers = preAssessmentCallQueueModel.Data.Where(x => x.EventID == eventId.Id);
        //                foreach (var customer in customers)
        //                {
        //                    var eventCustomer = _eventCustomerRepository.Get(eventId.Id, customer.CustomerId);
        //                    if (eventCustomer != null)
        //                    {

        //                        var flagupdate = _eventCustomerRepository.UpdateGeneratePreAssessmentCallQueueStatus(eventCustomer.Id, customer.IsAssessmentCompleted);
        //                    }
        //                    else
        //                    {
        //                        _logger.Info(string.Format("CustomerId : {0}   is not exists in this EventId: {1}", customer.CustomerId, eventId.Id));
        //                    }

        //                }


        //        }

        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        public long StartCallForPreAssessment(long orgRoleUserId, long customerId, long eventId, long callQueueId, long callId = 0)
        {
            var callQueue = _callQueueRepository.GetById(callQueueId);
            var preAssessmentCustomerCallQueueCallAttempt = _preAssessmentCustomerCallQueueCallAttemptRepository.GetCustomerCallQueueCallPreAssessmentAttemptIfCustomerLockedforAgent(customerId, orgRoleUserId, eventId);
            if (preAssessmentCustomerCallQueueCallAttempt != null)
            {
                var callQueueCustomerLock = new PreAssessmentCallQueueCustomerLock
                {
                    CreatedBy = orgRoleUserId,
                    CreatedOn = DateTime.Now,
                    CustomerId = customerId
                };

                _preAssessmentCallQueueCustomerLockRepository.UpdatePreAssessmentCallQueueCustomerLock(callQueueCustomerLock);

                if (preAssessmentCustomerCallQueueCallAttempt.CallId.HasValue)
                    return preAssessmentCustomerCallQueueCallAttempt.CallId.Value;
            }
            var eventCustomer = _eventCustomerRepository.GetRegisteredEventForUser(customerId, eventId);
            if (eventCustomer == null)
                return 0;
            var customer = _customerRepository.GetCustomer(customerId);
            return SaveCallQueueCustomerDetailAndGetCallId(customer, callQueue, orgRoleUserId, callId, (long)DialerType.Vici, eventId);
        }
        private long SaveCallQueueCustomerDetailAndGetCallId(Customer customer, CallQueue callQueue, long orgRoleUserId, long callId, long dialerType, long eventId = 0)
        {
            var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customer.CustomerId);

            var _event = _eventRepository.GetById(eventId);
            var HealthPlanId = _eventRepository.GetById(eventId) != null ? _eventRepository.GetById(eventId).AccountId : null;
            long? prospectCustomerId_ = null;
            if (prospectCustomer != null)
            {
                prospectCustomerId_ = prospectCustomer.Id;
            }

            using (var scope = new TransactionScope())
            {
                //lock customer in call queue so that other agent not be able to call them;
                var domain = new PreAssessmentCallQueueCustomerLock
                {

                    CustomerId = customer.CustomerId,
                    ProspectCustomerId = prospectCustomerId_,
                    CreatedBy = orgRoleUserId,
                    CreatedOn = DateTime.Now
                };
                _preAssessmentCallQueueCustomerLockRepository.SavePreAssessmentCallQueueCustomerLock(domain);
                var customerId = customer != null ? customer.CustomerId : 0;

                var prospectCustomerId = prospectCustomerId_ != null ? (long)prospectCustomerId_ : 0;
                var organizationRoleUserId = orgRoleUserId;
                var callStatus = customerId > 0 ? CallType.Existing_Customer.ToString().Replace("_", " ") : CallType.Register_New_Customer.ToString().Replace("_", " ");

                PhoneNumber glocomNumber = null;

                if (customer != null && customer.Address != null && HealthPlanId > 0)
                {
                    glocomNumber = _customerAccountGlocomNumberService.GetGlocomNumber((long)HealthPlanId, customer.Address.StateId, customerId);

                    if (glocomNumber == null)
                    {
                        var corporateAccount = _corporateAccountRepository.GetByTag(customer.Tag);
                        glocomNumber = corporateAccount != null ? corporateAccount.CheckoutPhoneNumber : null;
                    }
                }

                var incomingPhoneLine = glocomNumber != null ? glocomNumber.AreaCode + glocomNumber.Number : "";

                callId = _outboundCallQueueService.SetCallDetail(organizationRoleUserId, customerId, incomingPhoneLine, "", callStatus, null,
                    HealthPlanId, "", callQueue.Id, callId, true, dialerType: dialerType, callQueueCategory: callQueue.Category, eventId: eventId,ProductTypeId: customer.ProductTypeId);

                if (customerId == 0 && prospectCustomerId > 0)
                {
                    UpdateContactedInfo(prospectCustomerId, callId, orgRoleUserId);
                }
                else if (customerId > 0)
                {
                    if (!(callQueue.Category == CallQueueCategory.Upsell || callQueue.Category == CallQueueCategory.PreAssessmentCallQueue))
                    {
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
                var customerCallQueueCallAttempt = new PreAssessmentCustomerCallQueueCallAttempt
                {
                    DateCreated = DateTime.Now,
                    IsCallSkipped = false,
                    IsNotesReadAndUnderstood = true,
                    CreatedBy = orgRoleUserId,
                    CustomerId = customerId,
                    CallId = callId,
                    NotInterestedReasonId = null
                };

                _preAssessmentCustomerCallQueueCallAttemptRepository.Save(customerCallQueueCallAttempt, false);

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
        private bool UpdateContactedInfo(long prospectCustomerId, long callId, long orgRoleUserId)
        {
            _callCenterRepository.BindCallToProspectCustomerForCallQueue(callId, prospectCustomerId);
            return _prospectCustomerRepository.UpdateContactedStatus(prospectCustomerId, orgRoleUserId);
        }
        public PreAssessmentCustomerContactViewModel GetByCustomerId(long customerId, long callId, long orgRoleUserId)
        {
            if (customerId <= 0) return null;
            var call = _callCenterCallRepository.GetById(callId);
            var eventCustomer = _eventCustomerRepository.Get(call.EventId, customerId);
            CallQueue callQueue = null;
            if (call != null)
                callQueue = _callQueueRepository.GetById((long)call.CallQueueId);
            var customer = _customerRepository.GetCustomer(customerId);

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

            var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
            CallQueuePatientInfomationViewModel patientInfo = null;

            if (customer != null)
            {
                Falcon.App.Core.Medical.Domain.ActivityType activityType = null;
                if (customer.ActivityId.HasValue)
                    activityType = _activityTypeRepository.GetById(customer.ActivityId.Value);

                patientInfo = _preAssessmentCallQueuePatientInfomationFactory.SetCustomerInfo(customer, customerEligibility, activityType);
            }
            else
                patientInfo = _preAssessmentCallQueuePatientInfomationFactory.SetProspectCustomerInfo(prospectCustomer);


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
                if (callQueue != null && callQueue.Category == HealthPlanCallQueueCategory.PreAssessmentCallQueue)
                {
                    if (corporateAccount.ShowCallCenterScript && corporateAccount.ConfirmationScriptFileId > 0)
                    {
                        var confirmationScriptPdf = _fileRepository.GetById(corporateAccount.ConfirmationScriptFileId);
                        var mediaLocation = _mediaRepository.GetCallCenterScriptPdfFolderLocation();
                        patientInfo.CallCenterScriptUrl = mediaLocation.Url + confirmationScriptPdf.Path;
                    }
                }
            }
            var hasMammo = customer != null && _preApprovedTestRepository.CheckPreApprovedTestForCustomer(customer.CustomerId, TestGroup.BreastCancer);

            patientInfo.HasMammo = hasMammo;

            patientInfo.MammoTestAsPreApproved = hasMammo;

            patientInfo.CustomerId = customerId;
            patientInfo.ProspectCustomerId = prospectCustomer != null ? prospectCustomer.Id : 0;

            patientInfo = _preAssessmentCallQueuePatientInfomationFactory.SetCustomerTagInfo(prospectCustomer, patientInfo);

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

            IEnumerable<string> preApprovedTests = null;
            var preApprovedTestsList = _preApprovedTestRepository.GetPreApprovedTests(customerId);
            if (preApprovedTestsList.Count() > 0)
            {
                preApprovedTests = preApprovedTestsList;
            }

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

            var preAssessmentCustomerCallQueueCallAttempt = _preAssessmentCustomerCallQueueCallAttemptRepository.GetByCallId(callId);

            RegisteredEventViewModel registeredEventModel = null;
            var isCancelled = false;
            if (callQueue != null && callQueue.Category == HealthPlanCallQueueCategory.PreAssessmentCallQueue && call.EventId > 0)
            {

                var isEawvPurchased = _testResultService.IsTestPurchasedByCustomer(eventCustomer.Id, (long)TestType.eAWV);
                Appointment appointment = null;
                if (eventCustomer.AppointmentId.HasValue)
                {
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
                    EventCustomerId = eventCustomer.Id,
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

                preAssessmentCustomerCallQueueCallAttempt.IsNotesReadAndUnderstood = true;
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

            var model = new PreAssessmentCustomerContactViewModel
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
                CallQueueCustomerAttempt = preAssessmentCustomerCallQueueCallAttempt ?? new PreAssessmentCustomerCallQueueCallAttempt { IsNotesReadAndUnderstood = true },
                EventInformation = registeredEventModel,
                WarmTransfer = warmTransfer,
                // RequiredTests = requiredTests,
            };
            var isHealthPlanCallQueue = call != null;
            var patientInfoEditModel = _preAssessmentCallQueuePatientInfomationFactory.GetCallQueueCustomerEditModel(model, isHealthPlanCallQueue);
            model.PatientInfoEditModel = patientInfoEditModel;
            model.PatientInfoEditViewModel = patientInfoEditModel;
            return model;
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
        public bool EndActiveCall(long customerId, long callId, bool isCallQueueRequsted, long orgainizationRoleId, bool isRemoveFromQueueRequested, long? callOutcomeId = null, string skipCallNotes = "")
        {
            using (var scope = new TransactionScope())
            {

                UpdateCallDetails(callId, callOutcomeId, skipCallNotes);
                if (customerId > 0)
                {

                    _preAssessmentCallQueueCustomerLockRepository.RelasePreAssessmentCallQueueCustomerLock(customerId);
                }
                scope.Complete();
            }
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


    }
}
