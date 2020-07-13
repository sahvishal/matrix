using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(ITestResultService))]
    public class TestResultService : ITestResultService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IResultArchiveUploadRepository _fileUploadLogRepository;
        private readonly IResultArchiveUploadLogRepository _resultFileParsingRepository;
        private readonly IEventCustomerResultStatusListFactory _eventCustomerResultStatusListFactory;
        private readonly IEventResultStatusListFactory _eventResultStatusListFactory;
        private readonly ITestResultRepository _testResultRepository;
        private readonly ICommunicationRepository _communicationRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPhysicianAssignmentService _physicianAssignmentService;
        private readonly IPhysicianCustomerAssignmentRepository _physicianCustomerAssignmentRepository;
        private readonly IPodRepository _podRepository;
        private readonly IUnableToScreenStatusRepository _unableToScreenStatusRepository;
        private readonly ITechnicalLimitedScreeningCustomerFactory _technicalLimitedScreeningCustomerFactory;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICustomerCriticalDataRepository _customerCriticalDataRepository;
        private readonly ICustomerEventCriticalTestDataFactory _customerEventCriticalTestDataFactory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IUniqueItemRepository<Test> _uniqueitemTestRepository;
        private readonly ICustomerEventCriticalDataFactory _customerEventCriticalDataFactory;
        private readonly ITestRepository _testRepository;
        private readonly INotesRepository _notesRepository;
        private readonly ITestPerformedListModelFactory _testPerformedListModelFactory;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPriorityInQueueRepository _priorityInQueueRepository;
        private readonly ICustomerEventPriorityInQueueDataRepository _customerEventPriorityInQueueDataRepository;
        private readonly IEventCustomerPreApprovedTestRepository _eventCustomerPreApprovedTestRepository;
        private readonly IPhysicianEventAssignmentRepository _physicianEventAssignmentRepository;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepository;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;
        private readonly IEventCustomerRetestRepository _eventCustomerRetestRepository;
        private readonly ISettings _settings;
        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly ITestNotPerformedRepository _testNotPerformedRepository;
        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;

        public TestResultService(ICustomerRepository customerRepository, IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IResultArchiveUploadRepository fileUploadLogRepository, IResultArchiveUploadLogRepository resultFileParsingRepository, IHostRepository hostRepository, IEventCustomerResultStatusListFactory eventCustomerResultStatusListFactory,
            IEventResultStatusListFactory eventResultStatusListFactory, IEventPackageRepository eventPackageRepository, ICommunicationRepository communicationRepository, IOrderRepository orderRepository, IEventTestRepository eventTestRepository,
            IPhysicianAssignmentService physicianAssignmentService, IPodRepository podRepository, IUnableToScreenStatusRepository unableToScreenStatusRepository, ITechnicalLimitedScreeningCustomerFactory technicalLimitedScreeningCustomerFactory,
            ICustomerCriticalDataRepository customerCriticalDataRepository, ICustomerEventCriticalTestDataFactory customerEventCriticalTestDataFactory, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IUniqueItemRepository<Test> uniqueitemTestRepository, IPhysicianCustomerAssignmentRepository physicianCustomerAssignmentRepository,
            ICustomerEventCriticalDataFactory customerEventCriticalDataFactory, ITestRepository testRepository, INotesRepository notesRepository, ITestPerformedListModelFactory testPerformedListModelFactory,
            IHospitalPartnerRepository hospitalPartnerRepository, IOrganizationRepository organizationRepository, IHospitalFacilityRepository hospitalFacilityRepository, IEventPodRepository eventPodRepository,
            ICorporateAccountRepository corporateAccountRepository, IPriorityInQueueRepository priorityInQueueRepository, ICustomerEventPriorityInQueueDataRepository customerEventPriorityInQueueDataRepository,
            IEventCustomerPreApprovedTestRepository eventCustomerPreApprovedTestRepository, IPhysicianEventAssignmentRepository physicianEventAssignmentRepository,
            IPhysicianEvaluationRepository physicianEvaluationRepository, IAccountAdditionalFieldRepository accountAdditionalFieldRepository,
            IEventCustomerRetestRepository eventCustomerRetestRepository, ISettings settings, IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService, ITestNotPerformedRepository testNotPerformedRepository,
            IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices
            )
        {
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _fileUploadLogRepository = fileUploadLogRepository;
            _resultFileParsingRepository = resultFileParsingRepository;
            _hostRepository = hostRepository;
            _eventCustomerResultStatusListFactory = eventCustomerResultStatusListFactory;
            _eventResultStatusListFactory = eventResultStatusListFactory;
            _testResultRepository = new TestResultRepository();
            _communicationRepository = communicationRepository;
            _eventPackageRepository = eventPackageRepository;
            _orderRepository = orderRepository;
            _eventTestRepository = eventTestRepository;
            _physicianAssignmentService = physicianAssignmentService;
            _podRepository = podRepository;
            _unableToScreenStatusRepository = unableToScreenStatusRepository;
            _technicalLimitedScreeningCustomerFactory = technicalLimitedScreeningCustomerFactory;
            _customerCriticalDataRepository = customerCriticalDataRepository;
            _customerEventCriticalTestDataFactory = customerEventCriticalTestDataFactory;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _uniqueitemTestRepository = uniqueitemTestRepository;
            _physicianCustomerAssignmentRepository = physicianCustomerAssignmentRepository;
            _customerEventCriticalDataFactory = customerEventCriticalDataFactory;
            _testRepository = testRepository;
            _notesRepository = notesRepository;
            _testPerformedListModelFactory = testPerformedListModelFactory;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _eventPodRepository = eventPodRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _priorityInQueueRepository = priorityInQueueRepository;
            _customerEventPriorityInQueueDataRepository = customerEventPriorityInQueueDataRepository;
            _eventCustomerPreApprovedTestRepository = eventCustomerPreApprovedTestRepository;
            _physicianEventAssignmentRepository = physicianEventAssignmentRepository;
            _physicianEvaluationRepository = physicianEvaluationRepository;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;
            _eventCustomerRetestRepository = eventCustomerRetestRepository;
            _settings = settings;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _testNotPerformedRepository = testNotPerformedRepository;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;
        }

        public EventCustomerResultStatusListModel GetEventCustomerResultStatusList(EventCustomerResultStatusListModelFilter filter, long accountId)
        {
            Event theEvent = null;

            if (filter.EventId > 0)
            {
                theEvent = _eventRepository.GetById(filter.EventId);
            }
            else if (filter.CustomerId.HasValue && filter.CustomerId.Value > 0 && filter.EventId <= 0)
            {
                return null;
            }
            else if (filter.EventDate.HasValue && !string.IsNullOrEmpty(filter.Host))
            {
                theEvent = _eventRepository.GetEventbyHostName(filter.Host, filter.EventDate);
                if (accountId > 0)
                {
                    var isValidEvent = _eventRepository.ValidateEventForAccount(theEvent.Id, accountId);
                    if (!isValidEvent) return null;
                }
            }

            else
            {
                return null;
            }

            if (theEvent == null || theEvent.Status != EventStatus.Active) return null;
            var host = _hostRepository.GetHostForEvent(theEvent.Id);

            var eventTests = _eventTestRepository.GetTestsForEvent(theEvent.Id);
            var eventPackages = _eventPackageRepository.GetPackagesForEvent(theEvent.Id);

            var eventCustomers = _eventCustomerRepository.GetbyEventId(theEvent.Id);

            if (eventCustomers.IsNullOrEmpty())
            {
                return null;
            }

            if (filter.CustomerId.HasValue && filter.CustomerId.Value > 0)
                eventCustomers = eventCustomers.Where(ec => !ec.NoShow && ec.AppointmentId.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue && ec.CustomerId == filter.CustomerId).ToArray();
            else
                eventCustomers = eventCustomers.Where(ec => !ec.NoShow && ec.AppointmentId.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue).ToArray();


            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var orderIdEventCustomerIdPairs = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerIds);
            var orderIds = orderIdEventCustomerIdPairs.Select(p => p.FirstValue).ToArray();

            var orders = _orderRepository.GetByIds(orderIds);

            var orderIdTestIdPairs = _eventTestRepository.GetEventTestIdForOrders(orderIds);
            var orderIdpackageIdPairs = _eventPackageRepository.GetEventPackageIdsForOrder(orderIds);

            var ecIdTestIdPairs = (from ec in orderIdEventCustomerIdPairs join ot in orderIdTestIdPairs on ec.FirstValue equals ot.FirstValue select new OrderedPair<long, long>(ec.SecondValue, ot.SecondValue)).ToArray();
            var ecIdpackageIdPairs = (from ec in orderIdEventCustomerIdPairs join op in orderIdpackageIdPairs on ec.FirstValue equals op.FirstValue select new OrderedPair<long, long>(ec.SecondValue, op.SecondValue)).ToArray();

            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerIds);
            var physicianComments = _communicationRepository.GetPhysicianCommentsforgivenEventCustomers(eventCustomerIds);

            var customerResults = _eventCustomerResultRepository.GetTestResultStatusforEvent(theEvent.Id);

            var fileUploads = _fileUploadLogRepository.GetByEventId(theEvent.Id);
            var parsingResults = _resultFileParsingRepository.GetbyEventId(theEvent.Id);
            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var emrNotes = _eventRepository.GetEmrNotes(theEvent.Id);
            var physicianAssignments = _physicianAssignmentService.GetPhysicianAssignments(theEvent.Id, eventCustomerIds);


            var account = _corporateAccountRepository.GetbyEventId(theEvent.Id);
            //var awvTests = _eventTestRepository.GetByEventAndTestIds(theEvent.Id, new[] { (long)TestType.AWV, (long)TestType.Medicare, (long)TestType.AwvSubsequent });
            //var isAwvEvent = awvTests != null && awvTests.Any();

            var priorityInQueues = _priorityInQueueRepository.GetByEventId(theEvent.Id);



            IEnumerable<PrimaryCarePhysician> primaryCarePhysicians = null;
            if (account != null && account.CapturePcpConsent)
                primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            var printCheckList = false;

            if (theEvent.EventDate < _settings.ChecklistChangeDate)
                printCheckList = (account != null && account.PrintCheckList);

            var eventCustomerResultIdTestIdNotPerformedPairs = _testNotPerformedRepository.GetEventCusromerResultIdTestIdPairs(eventCustomerIds);

            bool isNewResultFlow = theEvent.EventDate >= _settings.ResultFlowChangeDate;

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (account != null && theEvent != null)
            {
                questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
            }



            var model = _eventCustomerResultStatusListFactory.Create(theEvent, host, eventTests, eventCustomers, customers, eventPackages,
                                                 ecIdpackageIdPairs, ecIdTestIdPairs, fileUploads, parsingResults,
                                                 customerResults != null ? customerResults.ToList() : null, eventCustomerResults, physicianComments, emrNotes, physicianAssignments, orders, account, primaryCarePhysicians,
                                                 priorityInQueues, printCheckList, isNewResultFlow, eventCustomerResultIdTestIdNotPerformedPairs, questionnaireType);

            model.HospitalFacilities = _hospitalFacilityRepository.GetByEventId(theEvent.Id);
            model.IsKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(theEvent.Id);

            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(theEvent.Id);
            model.IsHospitalPartnerEvent = hospitalPartnerId > 0;
            return model;
        }

        public ListModelBase<EventResultStatusViewModel, EventResultStatusViewModelFilter> GetEventResultStatusList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetEventsForEventResultStatus(pageNumber, pageSize,
                                                                        filter as EventResultStatusViewModelFilter,
                                                                        out totalRecords);

            if (events.IsNullOrEmpty()) return null;

            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var totalCustomers = _eventRepository.GetAttendedCustomers(eventIds);
            var resultsUploadedEventIds = _fileUploadLogRepository.GetEventIdsForStatus(eventIds, ResultArchiveUploadStatus.Uploaded);
            var resultsParsedEventIds = _fileUploadLogRepository.GetEventIdsForStatus(eventIds, ResultArchiveUploadStatus.Parsed);
            var missingResultCount =
                _eventCustomerResultRepository.GetEventIdMissingCustomerResultCountPairForEventIds(eventIds);

            var unStableStateCount = _eventCustomerResultRepository.GetEventIdUnStableStateCountPairForEventIds(eventIds);

            var preAuditPendingCount = _eventCustomerResultRepository.GetEventIdPreAuditPendingCountPairForEventIds(eventIds);

            var reviewPendingCount = _eventCustomerResultRepository.GetEventIdReviewPendingCountPairForEventIds(eventIds);

            var postAuditPendingCount =
                _eventCustomerResultRepository.GetEventIdPostAuditPendingCountPairForEventIds(eventIds);

            var resultsDelivered = _eventCustomerResultRepository.GetEventIdResultsDeliveredCountPairForEventIds(eventIds);

            var pods = _podRepository.GetPodsForEvents(eventIds);
            return _eventResultStatusListFactory.Create(events, hosts, totalCustomers, missingResultCount, preAuditPendingCount,
                                                 reviewPendingCount, postAuditPendingCount, resultsDelivered,
                                                 resultsUploadedEventIds, resultsParsedEventIds, unStableStateCount, pods);
        }

        public void UndoPreAudit(long eventId, long customerId, long updatedBy, bool isNewResultFlow)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            var customerTests = _eventCustomerResultRepository.GetCustomerTests(eventCustomerResult.Id);

            var testResultState = (isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryCompleted : (int)TestResultStateNumber.ManualEntry);
            var customerEventScreeningTestIds = _testResultRepository.GetCustomerEventScreeningTestIds(eventId, customerId);

            using (var scope = new TransactionScope())
            {
                _testResultRepository.SetResultstoState(testResultState, false, updatedBy, customerEventScreeningTestIds);
                _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.Id, customerTests);
                scope.Complete();
            }
        }

        public void UndoEvaluation(long eventId, long customerId, long updatedBy)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            var customerTests = _eventCustomerResultRepository.GetCustomerTests(eventCustomerResult.Id);
            var customerEventScreeningTestIds = _testResultRepository.GetCustomerEventScreeningTestIds(eventId, customerId);

            using (var scope = new TransactionScope())
            {
                _testResultRepository.SetResultstoState((int)TestResultStateNumber.PreAudit, false, updatedBy, customerEventScreeningTestIds);
                _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.Id, customerTests);
                scope.Complete();
            }
        }

        public void SetResultstoState(long eventId, long customerId, int number, bool isPartial, long updatedBy, bool isChartSignedOff = true)
        {
            var customerEventScreeningTestIds = _testResultRepository.GetCustomerEventScreeningTestIds(eventId, customerId);

            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            var customerTests = _eventCustomerResultRepository.GetCustomerTests(eventCustomerResult.Id);

            using (var scope = new TransactionScope())
            {
                _testResultRepository.SetResultstoState(number, isPartial, updatedBy, customerEventScreeningTestIds);
                _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.Id, customerTests);
                scope.Complete();
            }
        }

        public IEnumerable<EventCustomerResultStatusListModel> GetCustomerResultStatus(long customerId)
        {
            var eventCustomers = _eventCustomerRepository.GetbyCustomerId(customerId);
            if (eventCustomers == null || eventCustomers.Count() < 1)
            {
                return null;
            }

            eventCustomers = eventCustomers.Where(ec => !ec.NoShow && ec.AppointmentId.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue).ToArray();

            if (eventCustomers.IsNullOrEmpty())
            {
                return null;
            }

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var orderIdEventCustomerIdPairs = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerIds);
            var orderIds = orderIdEventCustomerIdPairs.Select(p => p.FirstValue).ToArray();

            var orderIdTestIdPairs = _eventTestRepository.GetEventTestIdForOrders(orderIds);
            var orderIdpackageIdPairs = _eventPackageRepository.GetEventPackageIdsForOrder(orderIds);

            var ecIdTestIdPairs = (from ec in orderIdEventCustomerIdPairs join ot in orderIdTestIdPairs on ec.FirstValue equals ot.FirstValue select new OrderedPair<long, long>(ec.SecondValue, ot.SecondValue)).ToArray();
            var ecIdpackageIdPairs = (from ec in orderIdEventCustomerIdPairs join op in orderIdpackageIdPairs on ec.FirstValue equals op.FirstValue select new OrderedPair<long, long>(ec.SecondValue, op.SecondValue)).ToArray();

            var eventPackages = _eventPackageRepository.GetByIds(ecIdpackageIdPairs.Select(ec => ec.SecondValue).ToArray());
            var customer = _customerRepository.GetCustomer(eventCustomers.First().CustomerId);

            return (from eventCustomer in eventCustomers
                    let theEvent = _eventRepository.GetById(eventCustomer.EventId)
                    let eventTests = _eventTestRepository.GetTestsForEvent(theEvent.Id)
                    let host = _hostRepository.GetHostForEvent(theEvent.Id)
                    let eventCustomerResult = _eventCustomerResultRepository.GetById(eventCustomer.Id)
                    let customerResult = _eventCustomerResultRepository.GetTestResultStatusforEventCustomer(eventCustomer.EventId, eventCustomer.CustomerId)
                    let parsingResults = _resultFileParsingRepository.GetbyEventIdCustomerId(eventCustomer.EventId, eventCustomer.CustomerId)
                    //let customer = _customerRepository.GetCustomer(eventCustomer.CustomerId)
                    let account = _corporateAccountRepository.GetbyEventId(theEvent.Id)
                    let questionnaireType = account == null ? QuestionnaireType.None : _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate)

                    select _eventCustomerResultStatusListFactory.Create(theEvent, host, eventTests, eventCustomer, customer, eventPackages, ecIdpackageIdPairs, ecIdTestIdPairs, parsingResults, customerResult, eventCustomerResult, theEvent.EventDate >= _settings.ResultFlowChangeDate, account, questionnaireType
                    ))
                         .OrderByDescending(m => m.EventDate).ToList();
        }

        public ListModelBase<TechnicalLimitedScreeningCustomerViewModel, TechnicalLimitedScreeningCustomerListModelFilter> GetCustomerwithTechnicallimitedScreening(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var reportFilter = filter as TechnicalLimitedScreeningCustomerListModelFilter;
            var eventCustomerResults = _eventCustomerResultRepository.GetbyFilter(reportFilter, pageNumber, pageSize, out totalRecords);
            if (eventCustomerResults == null || eventCustomerResults.Count() < 1) return null;

            var events = _eventRepository.GetEventswithPodbyIds(eventCustomerResults.Select(ecr => ecr.EventId).Distinct().ToArray());
            var pods = ((IUniqueItemRepository<Pod>)_podRepository).GetByIds(events.SelectMany(e => e.PodIds).Distinct());
            var customers = _customerRepository.GetCustomers(eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray());

            var eventCustomerResultIds = eventCustomerResults.Select(ecr => ecr.Id).ToArray();
            var orderEventCustomerIdPair =
                _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerResultIds);
            var orderIds = orderEventCustomerIdPair.Select(o => o.FirstValue).ToArray();

            var orderAndeventPackagepairs = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderAndTestpairs = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var ecAndPackagePairs = (from p in orderEventCustomerIdPair
                                     join oep in orderAndeventPackagepairs on p.FirstValue equals oep.FirstValue
                                     select new OrderedPair<long, string>(p.SecondValue, oep.SecondValue)).ToArray();


            var ecAndTestPairs = (from p in orderEventCustomerIdPair
                                  join oet in orderAndTestpairs on p.FirstValue equals oet.FirstValue
                                  select new OrderedPair<long, string>(p.SecondValue, oet.SecondValue)).ToArray();

            var unableToScreenViewModel = _unableToScreenStatusRepository.GetUnabletoScreenView(eventCustomerResultIds);
            return _technicalLimitedScreeningCustomerFactory.Create(eventCustomerResults, events, pods, customers, ecAndPackagePairs, ecAndTestPairs, unableToScreenViewModel, reportFilter.IsNewResultStateFlow);
        }

        public CustomerEventCriticalTestDataEditModel GetModel(long eventId, long customerId, long testId)
        {
            var customerCriticalData = _customerCriticalDataRepository.Get(eventId, customerId, testId);
            var customer = _customerRepository.GetCustomer(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);


            var physiciansAssigned = _physicianAssignmentService.GetPhysicianIdsAssignedtoaCustomer(eventId, customerId);

            IEnumerable<OrderedPair<long, string>> idNamePairs = null;

            if (physiciansAssigned != null && physiciansAssigned.Any())
                idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(physiciansAssigned.ToArray());

            var primaryCarePhysician = _primaryCarePhysicianRepository.Get(customerId);
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

            return _customerEventCriticalTestDataFactory.Create(eventId, testId, customer, customerCriticalData, eventCustomer, idNamePairs, primaryCarePhysician, eventCustomerResult);
        }

        public void SaveModel(long eventId, long customerId, CustomerEventCriticalTestDataEditModel model, long updatorOrgRoleUserId)
        {
            var obj = _customerEventCriticalTestDataFactory.Create(model);
            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            if (!string.IsNullOrEmpty(model.PrimaryCarePhysicianName))
            {
                if (pcp == null)
                {
                    pcp = new PrimaryCarePhysician
                              {
                                  CustomerId = customerId,
                                  Name = new Name(model.PrimaryCarePhysicianName),
                                  Primary = model.PrimaryCarePhysicianPhoneNumber,
                                  DataRecorderMetaData =
                                      new DataRecorderMetaData(updatorOrgRoleUserId, DateTime.Now, null)
                              };
                }
                else
                {
                    pcp.Name = new Name(model.PrimaryCarePhysicianName);
                    pcp.Primary = model.PrimaryCarePhysicianPhoneNumber;
                }

                _primaryCarePhysicianRepository.Save(pcp);
            }
            else if (pcp != null)
            {
                _primaryCarePhysicianRepository.Delete(pcp);
            }

            ((IRepository<CustomerCriticalData>)_customerCriticalDataRepository).Save(obj);
        }

        public CustomerEventCriticalTestDataViewModel GetCustomerEventCriticalDataViewModel(long eventId, long customerId, long testId)
        {
            var customerCriticalData = _customerCriticalDataRepository.Get(eventId, customerId, testId);
            var customer = _customerRepository.GetCustomer(customerId);
            var primaryCarePhysician = _primaryCarePhysicianRepository.Get(customerId);

            var orgRoleUserIds = new long[] { customerCriticalData.TechnicianId, customerCriticalData.ValidatingTechnicianId };

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            var test = _uniqueitemTestRepository.GetById(testId);
            var testName = test != null ? test.Name : "";

            return _customerEventCriticalTestDataFactory.Create(customerCriticalData, customer, primaryCarePhysician, idNamePairs, testName);
        }

        public ListModelBase<CustomerEventCriticalDataViewModel, CustomerEventCriticalDataListModelFilter> GetCustomerwithCriticalData(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomerResults = _eventCustomerResultRepository.GetByCriticalDataFilter(filter as CustomerEventCriticalDataListModelFilter, pageNumber, pageSize, out totalRecords);

            if (eventCustomerResults == null || eventCustomerResults.Count() < 1) return null;

            var eventIds = eventCustomerResults.Select(ecr => ecr.EventId).Distinct().ToArray();

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            var pods = ((IUniqueItemRepository<Pod>)_podRepository).GetByIds(events.SelectMany(e => e.PodIds).Distinct());

            var customers = _customerRepository.GetCustomers(eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray());

            var eventCustomerResultIds = eventCustomerResults.Select(ecr => ecr.Id).ToArray();
            var orderEventCustomerIdPair =
                _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomerResultIds);
            var orderIds = orderEventCustomerIdPair.Select(o => o.FirstValue).ToArray();

            var orderAndeventPackagepairs = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderAndTestpairs = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var ecAndPackagePairs = (from p in orderEventCustomerIdPair
                                     join oep in orderAndeventPackagepairs on p.FirstValue equals oep.FirstValue
                                     select new OrderedPair<long, string>(p.SecondValue, oep.SecondValue)).ToArray();


            var ecAndTestPairs = (from p in orderEventCustomerIdPair
                                  join oet in orderAndTestpairs on p.FirstValue equals oet.FirstValue
                                  select new OrderedPair<long, string>(p.SecondValue, oet.SecondValue)).ToArray();

            var criticalData = _customerCriticalDataRepository.GetByEventCustomerIds(eventCustomerResultIds);

            var orgRoleUserIds = criticalData.Select(cd => cd.TechnicianId).ToList();
            orgRoleUserIds.AddRange(criticalData.Select(cd => cd.ValidatingTechnicianId).ToList());

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray());

            var physicianAssignments = _physicianAssignmentService.GetPhysicianAssignmentsByEventcustomerIds(eventCustomerResultIds);

            var testResults = _eventCustomerResultRepository.GetTestResultStatus(eventCustomerResultIds);
            var tests = _testRepository.GetAll();

            var eventCustomerResultIdNotesIdPairs = _customerCriticalDataRepository.GetEventCustomerResultIdNotesIdPair(eventCustomerResultIds);
            var notes = _notesRepository.Get(eventCustomerResultIdNotesIdPairs.Select(ec => ec.SecondValue));

            var eventIdHospitalPartnerIdPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);
            var organizations = _organizationRepository.GetOrganizations(eventIdHospitalPartnerIdPairs.Select(ehp => ehp.SecondValue).Distinct().ToArray());
            var eventIdHospitalPartnerNamePairs = (from ehp in eventIdHospitalPartnerIdPairs
                                                   join org in organizations on ehp.SecondValue equals org.Id
                                                   select new OrderedPair<long, string>(ehp.FirstValue, org.Name)).ToArray();

            return _customerEventCriticalDataFactory.Create(eventCustomerResults, events, customers, ecAndPackagePairs, ecAndTestPairs, criticalData, primaryCarePhysicians, physicianAssignments, testResults, tests,
                                                            eventCustomerResultIdNotesIdPairs, notes, idNamePairs, pods, eventIdHospitalPartnerNamePairs);
        }

        public ListModelBase<TestPerformedViewModel, TestPerformedListModelFilter> GetTestPerformed(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var customerEventTestStates = _eventCustomerResultRepository.GetTestPerformed(filter as TestPerformedListModelFilter, pageNumber, pageSize, out totalRecords);
            if (customerEventTestStates == null || customerEventTestStates.Count() < 1)
                return null;

            var customerEventScreeningTests = _eventCustomerResultRepository.GetCustomerEventScreeningTestsByIds(customerEventTestStates.Select(cets => cets.CustomerEventScreeningTestId).ToArray());

            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(customerEventScreeningTests.Select(ces => ces.EventCustomerResultId).Distinct().ToArray());

            var events = _eventRepository.GetEventswithPodbyIds(eventCustomerResults.Select(ecr => ecr.EventId).Distinct().ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomerResults.Select(ecr => ecr.CustomerId).Distinct().ToArray());

            var tests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(customerEventScreeningTests.Select(ces => ces.TestId).Distinct().ToArray());

            var orgRoleUserIds = customerEventTestStates.Where(cets => cets.ConductedByOrgRoleUserId.HasValue).Select(cets => cets.ConductedByOrgRoleUserId.Value).Distinct().ToArray();
            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            var pods = ((IUniqueItemRepository<Pod>)_podRepository).GetByIds(events.SelectMany(e => e.PodIds).Distinct());

            var hosts = _hostRepository.GetEventHosts(events.Select(x => x.Id));

            var customersPreApprovedTests = _eventCustomerPreApprovedTestRepository.GetPreApprovedTestIdsByCustomerIds(eventCustomerResults.Select(x => x.Id));

            //var tags = customers.Select(x => x.Tag).Distinct().ToArray();

            //var corporateAccount = _corporateAccountRepository.GetByTags(tags);

            var accountIds = events.Where(x => x.AccountId.HasValue && x.AccountId > 0).Select(x => x.AccountId.Value).Distinct().ToArray();

            var corporateAccount = _corporateAccountRepository.GetByIds(accountIds);

            if (corporateAccount != null && corporateAccount.Any())
                corporateAccount = corporateAccount.Where(x => x.IsHealthPlan);

            var eventsPhysicians = _physicianEventAssignmentRepository.GetAssignedPhysiciansByEventIds(events.Select(m => m.Id).Distinct().ToArray());
            var skipedcustomer = _physicianEvaluationRepository.GetCustomerSkipReviews(eventCustomerResults.Select(x => x.Id).Distinct().ToArray());

            var customerPhysicians = _physicianCustomerAssignmentRepository.GetCustomerAssignmentbyEventCustomerIds(eventCustomerResults.Select(x => x.Id).Distinct().ToArray());
            var orgRolePhysicianIds = customerPhysicians.Select(x => x.PhysicianId).Distinct().ToList();
            orgRolePhysicianIds.AddRange(customerPhysicians.Where(x => x.OverReadPhysicianId.HasValue).Select(x => x.OverReadPhysicianId.Value).Distinct().ToList());
            orgRolePhysicianIds.AddRange(eventsPhysicians.Select(m => m.PhysicianId).Distinct().ToList());
            orgRolePhysicianIds.AddRange(eventsPhysicians.Where(m => m.OverReadPhysicianId.HasValue).Select(m => m.OverReadPhysicianId.Value).Distinct().ToList());
            var physicianIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRolePhysicianIds.ToArray());


            var corporateAccountIds = corporateAccount.Select(x => x.Id).ToArray();
            var accountAdditionalField = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsByAccountIds(corporateAccountIds);

            var retests = _eventCustomerRetestRepository.GetByEventCustomerIds(eventCustomerResults.Select(x => x.Id));

            var eventCustomers = _eventCustomerRepository.GetByIds(customerEventScreeningTests.Select(ces => ces.EventCustomerResultId).Distinct().ToArray());

            return _testPerformedListModelFactory.Create(customerEventTestStates, customerEventScreeningTests, eventCustomerResults, events, customers, tests, idNamePairs, pods, customersPreApprovedTests, corporateAccount, physicianIdNamePairs
                , customerPhysicians, eventsPhysicians, skipedcustomer, hosts, corporateAccount, accountAdditionalField, retests, eventCustomers);
        }


        public PriorityInQueueTestEditModel GetPriorityInQueueTestEditModel(long eventId, long customerId, long testId)
        {
            var customerPiqData = _customerEventPriorityInQueueDataRepository.Get(eventId, customerId, testId);
            if (customerPiqData == null)
                return new PriorityInQueueTestEditModel();
            return new PriorityInQueueTestEditModel() { CustomerEventScreeningTestId = customerPiqData.CustomerEventScreeningTestID, Note = customerPiqData.Note };
        }
        public void SavePriorityInQueueTestEditModel(long eventId, long customerId, long testId, PriorityInQueueTestEditModel model, long updatorOrgRoleUserId)
        {
            var obj = _customerEventPriorityInQueueDataRepository.GetByCustomerEventScreeningTestId(model.CustomerEventScreeningTestId);
            if (obj != null)
            {
                obj.Note = model.Note;
                obj.DateModified = DateTime.Now;
                obj.ModifiedByOrgRoleUserId = updatorOrgRoleUserId;
            }
            else
            {
                obj = new CustomerEventPriorityInQueueData();
                obj.Note = model.Note;
                obj.DateCreated = obj.DateModified = DateTime.Now;
                obj.ModifiedByOrgRoleUserId = obj.CreatedByOrgRoleUserId = updatorOrgRoleUserId;
                obj.IsActive = true;
            }
            _customerEventPriorityInQueueDataRepository.Save(obj, eventId, customerId, testId, updatorOrgRoleUserId);
        }

        public bool SaveCustomerResultSigned(MedicareCustomerResultSignedNPViewModel model, OrganizationRoleUser orgRoleUser)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(model.CustomerId, model.EventId);
            eventCustomerResult = eventCustomerResult ??
                                  new EventCustomerResult { EventId = model.EventId, CustomerId = model.CustomerId, ResultState = (int)NewTestResultStateNumber.NoResults };

            if (eventCustomerResult.ResultState >= (int)NewTestResultStateNumber.PreAudit) return false;

            if (eventCustomerResult.DataRecorderMetaData == null)
            {
                eventCustomerResult.DataRecorderMetaData = new DataRecorderMetaData(orgRoleUser, DateTime.Now, null);
            }
            else
            {
                eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = orgRoleUser;
                eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;
            }

            if (model.IsSigned)
            {
                eventCustomerResult.SignedOffBy = orgRoleUser.Id;
                eventCustomerResult.SignedOffOn = DateTime.Now;
            }
            else
            {
                eventCustomerResult.SignedOffBy = null;
                eventCustomerResult.SignedOffOn = null;
            }

            _eventCustomerResultRepository.Save(eventCustomerResult);

            return true;
        }

        public bool SaveCustomerResultAfterNpReview(MedicareCustomerResultVerifiedViewModel model, OrganizationRoleUser orgRoleUser)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(model.CustomerId, model.EventId);
            if (eventCustomerResult != null)
            {

                var customerTests = _eventCustomerResultRepository.GetCustomerTests(eventCustomerResult.Id);
                var customerEventScreeningTestIds = _testResultRepository.GetCustomerEventScreeningTestIds(model.EventId, model.CustomerId);

                using (var scope = new TransactionScope())
                {
                    eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = orgRoleUser;
                    eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;

                    eventCustomerResult.VerifiedBy = orgRoleUser.Id;
                    eventCustomerResult.VerifiedOn = DateTime.Now;

                    _eventCustomerResultRepository.Save(eventCustomerResult);

                    _testResultRepository.SetResultstoState((int)NewTestResultStateNumber.NpSigned, true, orgRoleUser.Id, customerEventScreeningTestIds);

                    _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.Id, customerTests);

                    scope.Complete();
                }
                return true;
            }

            return false;
        }

        public bool IsTestPurchasedByCustomer(long eventcustomerId, long testId)
        {

            var tests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByEventCustomerId(eventcustomerId);

            return tests != null && tests.Any(t => t.Id == testId);
        }

        public void SaveCustomerResultCoded(MedicareCustomerResultCodedViewModel model, OrganizationRoleUser orgRoleUser)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(model.CustomerId, model.EventId);

            if (eventCustomerResult.ResultState != (int)NewTestResultStateNumber.NpSigned || eventCustomerResult.IsPartial)
                throw new Exception("Result state is not Ready for coding");

            var isTestPurchased = IsTestPurchasedByCustomer(eventCustomerResult.Id, (long)TestType.eAWV);

            var setResultState = (int)NewTestResultStateNumber.ArtifactSynced;
            var account = _corporateAccountRepository.GetbyEventId(model.EventId);

            var theEvent = _eventRepository.GetById(model.EventId);

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (account != null && theEvent != null)
            {
                questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
            }

            if (model.IsCoded)
            {
                if (isTestPurchased && (questionnaireType == QuestionnaireType.HraQuestionnaire))
                {
                    var eawvTestRepository = new EAwvTestRepository();
                    var testResult = eawvTestRepository.GetTestResults(model.CustomerId, model.EventId, true);
                    var eawvTestResult = testResult as EAwvTestResult;

                    if (eawvTestResult != null && (eawvTestResult.TestNotPerformed == null || eawvTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && (eawvTestResult.UnableScreenReason == null || eawvTestResult.UnableScreenReason.Count < 1))
                    {
                        if (CheckMediaNotCompleted(eawvTestResult.ResultImages))
                        {
                            setResultState = (int)NewTestResultStateNumber.CodingCompleted;
                        }
                    }
                }
                var customerEventScreeningTestIds = _testResultRepository.GetCustomerEventScreeningTestIds(model.EventId, model.CustomerId);
                var customerTests = _eventCustomerResultRepository.GetCustomerTests(eventCustomerResult.Id);

                using (var scope = new TransactionScope())
                {
                    eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = orgRoleUser;
                    eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;
                    eventCustomerResult.CodedBy = orgRoleUser.Id;
                    eventCustomerResult.CodedOn = DateTime.Now;

                    _eventCustomerResultRepository.Save(eventCustomerResult);

                    _testResultRepository.SetResultstoState(setResultState, false, orgRoleUser.Id, customerEventScreeningTestIds);
                    _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.Id, customerTests);

                    scope.Complete();
                }
            }
        }

        private bool CheckMediaNotCompleted(IEnumerable<ResultMedia> resultImages)
        {
            if (resultImages.IsNullOrEmpty()) return true;
            var containSnapshot = resultImages.Any(item => item.ReadingSource.HasValue && item.ReadingSource.Value == ReadingSource.Manual && item.File.Path.StartsWith(TestType.eAWV + "_" + AwvFileTypes.SnapShot));
            var containPreventionPlan = resultImages.Any(item => item.ReadingSource.HasValue && item.ReadingSource.Value == ReadingSource.Manual && item.File.Path.StartsWith(TestType.eAWV + "_" + AwvFileTypes.PreventionPlan));
            var containResultExport = resultImages.Any(item => item.ReadingSource.HasValue && item.ReadingSource.Value == ReadingSource.Manual && item.File.Path.StartsWith(TestType.eAWV + "_" + AwvFileTypes.ResultExport));
            if (containSnapshot && containPreventionPlan && containResultExport) return false;

            return true;
        }

        public bool SaveCustomerResultAcesApprovedOn(MedicareEventCustomerModel model, OrganizationRoleUser oru)
        {
            return UpdateInvoiceInformation(model.InvoiceDate, oru.Id, model.CustomerId, model.EventId);
        }

        private bool UpdateInvoiceInformation(DateTime approvedOn, long approvedby, long customerId, long eventId)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult != null)
            {
                eventCustomerResult.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(approvedby);
                eventCustomerResult.DataRecorderMetaData.DateModified = DateTime.Now;

                eventCustomerResult.AcesApprovedOn = approvedOn;
                eventCustomerResult.InvoiceDateUpdatedBy = approvedby;

                _eventCustomerResultRepository.Save(eventCustomerResult);

                //using (var scope = new TransactionScope())
                //{
                //    eventCustomerResult.AcesApprovedOn = approvedOn;
                //    eventCustomerResult.InvoiceDateUpdatedBy = approvedby;
                //    _eventCustomerResultRepository.Save(eventCustomerResult);

                //    var updateResultState = eventCustomerResult.ResultState == (int)NewTestResultStateNumber.PdfGenerated && (approvedOn.Date <= DateTime.Now.Date);
                //    if (updateResultState)
                //    {
                //        SetResultstoState(eventId, customerId, (int)NewTestResultStateNumber.ResultDelivered, false, eventCustomerResult.DataRecorderMetaData.DataRecorderModifier.Id);
                //    }
                //    scope.Complete();
                //}


                return true;
            }

            return false;
        }


        public EventCustomerStatusForResultEntryAndPreAudit GetEventCustomerStatusForEntryAndAudit(long customerId, long eventId, bool isNewResultFlow)
        {
            var eventCustomers = _eventCustomerRepository.Get(eventId, customerId);

            var eventCustomerStatus = new EventCustomerStatusForResultEntryAndPreAudit
            {
                IsMarkedNoShowAndLeftWithoutScreening = eventCustomers.NoShow || eventCustomers.LeftWithoutScreeningReasonId.HasValue,
                IsNewResultFlow = isNewResultFlow,
                IsChartSignedOff = isNewResultFlow
            };

            if (isNewResultFlow)
            {
                var purchasedTest = TestPurchasedByCustomer(eventCustomers.Id);

                var isTestPurchased = !purchasedTest.IsNullOrEmpty() ? purchasedTest.Any(x => x.Id == (long)TestType.eAWV) : false;
                //IsTestPurchasedByCustomer(eventCustomers.Id, (long)TestType.eAWV);

                var isQVTestPurchased = !purchasedTest.IsNullOrEmpty() ? purchasedTest.Any(x => x.Id == (long)TestType.Qv) : false;

                var account = _corporateAccountRepository.GetbyEventId(eventId);

                var theEvent = _eventRepository.GetById(eventId);

                QuestionnaireType questionnaireType = QuestionnaireType.None;
                if (account != null && theEvent != null)
                {
                    questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                }

                var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (questionnaireType == QuestionnaireType.ChatQuestionnaire)
                {
                    eventCustomerStatus.IsChartSignedOff = isQVTestPurchased || (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue);
                }
                else
                {
                    if (isTestPurchased && account != null && (questionnaireType == QuestionnaireType.HraQuestionnaire))
                    {

                        var isEawvTestNotPerformed = _testNotPerformedRepository.IsTestNotPerformed(eventCustomers.Id, (int)TestType.eAWV);
                        eventCustomerStatus.IsChartSignedOff = (eventCustomerResult != null && eventCustomerResult.SignedOffBy.HasValue) || isEawvTestNotPerformed;
                    }
                }
            }

            return eventCustomerStatus;
        }

        public ResultInvoiceEditModel UpdateInvoiceInformationDetail(ResultInvoiceEditModel model, long orgRoleId)
        {
            var invoiceSaved = UpdateInvoiceInformation(model.InvoiceDate, orgRoleId, model.CustomerId, model.EventId);
            model.SyncedSuccess = invoiceSaved;

            //if (invoiceSaved)
            //{
            //    var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(model.CustomerId, model.EventId);
            //    model.SyncedSuccess = true;

            //    if ((NewTestResultStateNumber)eventCustomerResult.ResultState == NewTestResultStateNumber.ResultDelivered)
            //    {
            //        model.CurrentResultState = ((NewTestResultStateNumber)eventCustomerResult.ResultState).ToString();
            //        model.CurrentResultStateDescription = ((NewTestResultStateNumber)eventCustomerResult.ResultState).GetNewPresentationfromResultState(eventCustomerResult.IsPartial, true).GetDescription();
            //        model.CurrentRestultStateNumber = eventCustomerResult.ResultState;
            //    }
            //}

            return model;
        }

        public IEnumerable<Test> TestPurchasedByCustomer(long eventcustomerId)
        {
            var tests = _eventCustomerPackageTestDetailService.GetTestsPurchasedByEventCustomerId(eventcustomerId);
            return tests;
        }
    }
}
