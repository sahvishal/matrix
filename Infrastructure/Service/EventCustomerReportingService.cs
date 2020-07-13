using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users.Domain;
using Product = Falcon.App.Core.Enum.Product;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Service
{

    //TODO: Need Refactoring, Might be needed to divide into three differnet Services. For Event, EvenctCustomer and Order, need to have a seperate basic model and service.
    [DefaultImplementation]
    public class EventCustomerReportingService : IEventCustomerReportingService
    {
        //Repositories
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IUniqueItemRepository<Appointment> _appointmentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IElectronicProductRepository _productRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICustomerCallNotesRepository _customerNotesRepository;
        private readonly IRefundRequestRepository _refundRequestRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IScreeningAuthorizationRepository _screeningAuthorizationRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IEventAppointmentChangeLogRepository _eventAppointmentChangeLogRepository;
        private readonly IUniqueItemRepository<Event> _eventRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IMedicareQuestionRepository _medicareQuestionRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILabRepository _labRepository;
        private readonly ICorporateCustomerCustomTagRepository _customTagRepository;
        private readonly IPodRepository _podRepository;
        private readonly IEventPackageRepository _eventPackageDetailsRepository;
        private readonly ITestNotPerformedRepository _testNotPerformedRepository;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;
        private readonly IEventCustomerPreApprovedTestRepository _eventCustomerPreApprovedTestRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly ICustomerCallNotesRepository _customerCallNotesRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICustomerTargetedRepository _customerTargetedRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IEventCustomerPreApprovedPackageTestRepository _eventCustomerPreApprovedPackageTestRepository;
        private readonly IParticipationConsentSignatureRepository _participationConsentSignatureRepository;
        private readonly IFluConsentSignatureRepository _fluConsentSignatureRepository;
        private readonly IPhysicianRecordRequestSignatureRepository _physicianRecordRequestSignatureRepository;

        //Factories
        private readonly ICustomerScheduleModelFactory _customerScheduleModelFactory;
        private readonly IAppointmentsBookedModelFactory _appointmentsBookedModelFactory;
        private readonly INoShowCustomerModelFactory _noShowCustomerModelFactory;
        private readonly IEventCustomerSummaryModelFactory _eventCustomerSummaryModelFactory;
        private readonly ICancelledCustomerModelFactory _cancelledCustomerModelFactory;
        private readonly IEventCustomerListModelFactory _eventCustomerListModelFactory;
        private readonly ICustomerExportModelFactory _customerExportModelFactory;
        private readonly IRescheduleApplointmentModelFactory _rescheduleAppointmentModelFactory;
        private readonly ITestsBookedModelFactory _testsBookedModelFactory;
        private readonly ITestRepository _testRepository;
        private readonly IEventAppointmentCancellationLogRepository _eventAppointmentCancellationLogRepository;
        private readonly INotesRepository _notesRepository;
        private readonly IPcpAppointmentViewModelFactory _pcpAppointmentViewModelFactory;
        private readonly IPcpAppointmentRepository _pcpAppointmentRepository;
        private readonly IPcpDispositionRepository _pcpDispositionRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IMemberStatusModelFactory _memberStatusModelFactory;
        private readonly IDirectMailRepository _directMailRepository;
        private readonly ICustomerLeftWithoutScreeningModelFactory _customerLeftWithoutScreeningModelFactory;
        private readonly IVoiceMailReminderModelFactory _voiceMailReminderModelFactory;
        private readonly ITextReminderModelFactory _textReminderModelFactory;
        private readonly IGapsClosureModelFactory _gapsClosureModelFactory;
        private readonly ICorporateEventCustomerFactory _corporateEventCustomerFactory;
        private readonly ICustomerPredictedZipRespository _customerPredictedZipRespository;

        //Services
        private readonly IEventReportingService _eventReportingService;
        private readonly IEventService _eventService;
        private readonly IPhysicianAssignmentService _physicianAssignmentService;
        private readonly IEventAppointmentService _eventAppointmentService;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IRelationshipRepository _relationshipRepository;

        private readonly IChaperoneSignatureRepository _chaperoneSignatureRepository;

        private readonly IAccountHraChatQuestionnaireHistoryServices _accountHraChatQuestionnaireHistoryServices;

        public EventCustomerReportingService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUniqueItemRepository<Appointment> appointmentRepository, IShippingDetailRepository shippingDetailRepository, IEventCustomerSummaryModelFactory eventCustomerSummaryModelFactory,
            IEventTestRepository eventTestRepository, IOrderRepository orderRepository, IEventReportingService eventReportingService, ICustomerScheduleModelFactory customerScheduleModelFactory, IEventService eventService,
            IAppointmentsBookedModelFactory appointmentsBookedModelFactory, INoShowCustomerModelFactory noShowCustomerModelFactory, IElectronicProductRepository productRepository, ISourceCodeRepository sourceCodeRepository,
            IChargeCardRepository chargeCardRepository, IRoleRepository roleRepository, ICallCenterCallRepository callCenterCallRepository, IEventPackageRepository eventPackageRepository, IPhysicianAssignmentService physicianAssignmentService,
            ICancelledCustomerModelFactory cancelledCustomerModelFactory, ICustomerCallNotesRepository customerNotesRepository, IRefundRequestRepository refundRequestRepository, IShippingOptionRepository shippingOptionRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, IScreeningAuthorizationRepository screeningAuthorizationRepository, IEventCustomerListModelFactory eventCustomerListModelFactory,
            IHealthAssessmentRepository healthAssessmentRepository, IEventAppointmentService eventAppointmentService, ICustomerExportModelFactory customerExportModelFactory, IEventAppointmentChangeLogRepository eventAppointmentChangeLogRepository,
            IUniqueItemRepository<Event> eventRepository, IRescheduleApplointmentModelFactory rescheduleAppointmentModelFactory, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ICorporateAccountRepository corporateAccountRepository,
            IMedicareQuestionRepository medicareQuestionRepository, ILanguageRepository languageRepository, ILabRepository labRepository, ICorporateCustomerCustomTagRepository customTagRepository, IPodRepository podRepository,
            ITestsBookedModelFactory testsBookedModelFactory, ITestRepository testRepository, IEventAppointmentCancellationLogRepository eventAppointmentCancellationLogRepository, INotesRepository notesRepository,
            IPcpAppointmentViewModelFactory pcpAppointmentViewModelFactory, IPcpAppointmentRepository pcpAppointmentRepository, IPcpDispositionRepository pcpDispositionRepository,
            IPreApprovedTestRepository preApprovedTestRepository, IPreApprovedPackageRepository preApprovedPackageRepository, IMemberStatusModelFactory memberStatusModelFactory, IDirectMailRepository directMailRepository,
            ICustomerLeftWithoutScreeningModelFactory customerLeftWithoutScreeningModelFactory, IVoiceMailReminderModelFactory voiceMailReminderModelFactory, IEventPackageRepository eventPackageDetailsRepository, ITextReminderModelFactory textReminderModelFactory,
            ITestNotPerformedRepository testNotPerformedRepository, IGapsClosureModelFactory gapsClosureModelFactory, IAccountAdditionalFieldRepository accountAdditionalFieldRepository,
            IEventCustomerPreApprovedTestRepository eventCustomerPreApprovedTestRepository, IPackageRepository packageRepository, ICorporateEventCustomerFactory corporateEventCustomerFactory,
            ICustomerCallNotesRepository customerCallNotesRepository, IProspectCustomerRepository prospectCustomerRepository, ICustomerPredictedZipRespository customerPredictedZipRespository, ICustomerEligibilityRepository customerEligibilityRepository,
            ICustomerTargetedRepository customerTargetedRepository, IChaseOutboundRepository chaseOutboundRepository, IRelationshipRepository relationshipRepository, IActivityTypeRepository activityTypeRepository,
            IAccountHraChatQuestionnaireHistoryServices accountHraChatQuestionnaireHistoryServices, IHostRepository hostRepository, IEventCustomerPreApprovedPackageTestRepository eventCustomerPreApprovedPackageTestRepository,
            IParticipationConsentSignatureRepository participationConsentSignatureRepository, IFluConsentSignatureRepository fluConsentSignatureRepository, IPhysicianRecordRequestSignatureRepository physicianRecordRequestSignatureRepository,
            IChaperoneSignatureRepository chaperoneSignatureRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerRepository = customerRepository;
            _eventTestRepository = eventTestRepository;
            _orderRepository = orderRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _appointmentRepository = appointmentRepository;
            _productRepository = productRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _chargeCardRepository = chargeCardRepository;
            _roleRepository = roleRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _eventPackageRepository = eventPackageRepository;
            _customerNotesRepository = customerNotesRepository;
            _refundRequestRepository = refundRequestRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _screeningAuthorizationRepository = screeningAuthorizationRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _eventAppointmentChangeLogRepository = eventAppointmentChangeLogRepository;
            _eventRepository = eventRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _medicareQuestionRepository = medicareQuestionRepository;
            _languageRepository = languageRepository;
            _labRepository = labRepository;
            _customTagRepository = customTagRepository;
            _podRepository = podRepository;
            _testsBookedModelFactory = testsBookedModelFactory;
            _testRepository = testRepository;
            _eventAppointmentCancellationLogRepository = eventAppointmentCancellationLogRepository;
            _notesRepository = notesRepository;
            _testNotPerformedRepository = testNotPerformedRepository;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;
            _eventCustomerPreApprovedTestRepository = eventCustomerPreApprovedTestRepository;
            _packageRepository = packageRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _customerPredictedZipRespository = customerPredictedZipRespository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _customerTargetedRepository = customerTargetedRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _relationshipRepository = relationshipRepository;

            _cancelledCustomerModelFactory = cancelledCustomerModelFactory;
            _eventCustomerSummaryModelFactory = eventCustomerSummaryModelFactory;
            _customerScheduleModelFactory = customerScheduleModelFactory;
            _appointmentsBookedModelFactory = appointmentsBookedModelFactory;
            _noShowCustomerModelFactory = noShowCustomerModelFactory;
            _eventCustomerListModelFactory = eventCustomerListModelFactory;
            _customerExportModelFactory = customerExportModelFactory;
            _rescheduleAppointmentModelFactory = rescheduleAppointmentModelFactory;
            _pcpAppointmentViewModelFactory = pcpAppointmentViewModelFactory;
            _pcpAppointmentRepository = pcpAppointmentRepository;
            _pcpDispositionRepository = pcpDispositionRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _memberStatusModelFactory = memberStatusModelFactory;
            _directMailRepository = directMailRepository;
            _gapsClosureModelFactory = gapsClosureModelFactory;
            _corporateEventCustomerFactory = corporateEventCustomerFactory;
            _customerCallNotesRepository = customerCallNotesRepository;

            _physicianAssignmentService = physicianAssignmentService;
            _eventReportingService = eventReportingService;
            _eventService = eventService;
            _eventAppointmentService = eventAppointmentService;
            _customerLeftWithoutScreeningModelFactory = customerLeftWithoutScreeningModelFactory;
            _voiceMailReminderModelFactory = voiceMailReminderModelFactory;
            _eventPackageDetailsRepository = eventPackageDetailsRepository;
            _textReminderModelFactory = textReminderModelFactory;
            _activityTypeRepository = activityTypeRepository;
            _accountHraChatQuestionnaireHistoryServices = accountHraChatQuestionnaireHistoryServices;
            _hostRepository = hostRepository;
            _eventCustomerPreApprovedPackageTestRepository = eventCustomerPreApprovedPackageTestRepository;
            _participationConsentSignatureRepository = participationConsentSignatureRepository;
            _fluConsentSignatureRepository = fluConsentSignatureRepository;
            _physicianRecordRequestSignatureRepository = physicianRecordRequestSignatureRepository;

            _chaperoneSignatureRepository = chaperoneSignatureRepository;
        }

        public ListModelBase<EventCustomerScheduleModel, CustomerScheduleModelFilter> GetCustomerScheduleModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersforPatientSchedule(pageNumber, pageSize,
                                                                                              filter as CustomerScheduleModelFilter, out totalRecords);

            if (eventCustomers.IsNullOrEmpty()) return null;
            var appointments =
                _appointmentRepository.GetByIds(
                    eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToList());

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var orderItemProductNamePair = _productRepository.GetProductNameForOrderItems(orders.SelectMany(o => o.OrderDetails.Select(od => od.OrderItemId)).ToArray());

            return _customerScheduleModelFactory.Create(eventCustomers, appointments, orders, model, customers,
                                                        orderPackageIdNamePair, orderTestIdNamePair, orderItemProductNamePair);
        }

        public EventCustomerScheduleModel GetCustomerScheduleModel(long eventId)
        {
            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

            if (eventCustomers.IsNullOrEmpty()) return null;
            var appointments =
                _appointmentRepository.GetByIds(
                    eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToList());

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var orderItemProductNamePair = _productRepository.GetProductNameForOrderItems(orders.SelectMany(o => o.OrderDetails.Select(od => od.OrderItemId)).ToArray());

            return _customerScheduleModelFactory.Create(eventCustomers, appointments, orders, model.Collection.FirstOrDefault(), customers,
                                                        orderPackageIdNamePair, orderTestIdNamePair, orderItemProductNamePair);
        }

        public ListModelBase<AppointmentsBookedModel, AppointmentsBookedListModelFilter> GetAppointmentsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyRegisterationDate(pageNumber, pageSize, filter as AppointmentsBookedListModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();
            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).Distinct().ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var customerIds = customers.Select(x => x.CustomerId);
            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray(), true);

            var eventPackages = _eventPackageRepository.GetbyEventIds(eventIds);
            var eventTests = _eventTestRepository.GetByEventIds(eventIds);

            // var orderIds = orders.Select(o => o.Id).ToArray();
            // var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            //  var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var sourceCodes = _sourceCodeRepository.GetSourceCodeByIds(orders.SelectMany(o => o.OrderDetails.Where(od => od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive)
                .Select(od => od.SourceCodeOrderDetail.SourceCodeId)).Distinct().ToArray());

            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();

            var eventAppointmentChangeLogs = _eventAppointmentChangeLogRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray()).ToArray();

            orgRoleUserIds.AddRange(eventAppointmentChangeLogs.Select(eacl => eacl.CreatedByOrgRoleUserId));

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);

            var roles = _roleRepository.GetAll();

            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            var callDetails = _callCenterCallRepository.GetCallDetails(customers);

            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();
            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
            var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);
            var shippingOptions = _shippingOptionRepository.GetAllShippingOptions();

            var customTags = _customTagRepository.GetByCustomerIds(customerIds);

            var tagNames = customers.Where(x => !string.IsNullOrEmpty(x.Tag)).Select(x => x.Tag).ToArray();
            var corporateAccount = _corporateAccountRepository.GetByTags(tagNames);
            var corporateAccountIds = corporateAccount.Select(x => x.Id).ToArray();
            var accountAdditionalField = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsByAccountIds(corporateAccountIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());
            var languages = _languageRepository.GetAll();
            var pcpAppointments = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            var currentDate = DateTime.Today;
            var fromDate = new DateTime(currentDate.Year, 1, 1);
            var toDate = new DateTime(currentDate.Year, 12, 31);
            var customerPredictedZips = _customerPredictedZipRespository.GetByCustomerIdAndDate(customerIds, fromDate, toDate);

            var confirmedByAgentIds = eventCustomers.Where(x => x.ConfirmedBy.HasValue).Select(x => x.ConfirmedBy.Value);
            var confirmedByAgentNameIdPairs = _organizationRoleUserRepository.GetNameIdPairofUsers(confirmedByAgentIds.ToArray()).ToArray();

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            if (customerEligibilities.IsNullOrEmpty())
                customerEligibilities = new List<CustomerEligibility>();

            return _appointmentsBookedModelFactory.Create(eventCustomers, appointments, orders, model, customers, registeredbyAgent, roles, registeredbyAgentNameIdPair, sourceCodes, callDetails,
                shippingDetails, cdShippingOption, shippingOptions, eventAppointmentChangeLogs, primaryCarePhysicians, eventPackages, eventTests, languages, customTags, corporateAccount,
                accountAdditionalField, pcpAppointments, customerPredictedZips, confirmedByAgentNameIdPairs, customerEligibilities);
        }

        public ListModelBase<NoShowCustomerModel, NoShowCustomerModelFilter> GetNoShowCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetNoShowEventCustomers(pageNumber, pageSize,
                                                                                  filter as NoShowCustomerModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;
            var appointments =
                _appointmentRepository.GetByIds(
                    eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var pcpAppointments = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToList());

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var orgRoleUserIds = new List<long>();

            orgRoleUserIds.AddRange(eventCustomers.Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());
            orgRoleUserIds = orgRoleUserIds.Select(oru => oru).Distinct().ToList();
            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(
                    eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id));

            var roles = _roleRepository.GetAll();


            return _noShowCustomerModelFactory.Create(eventCustomers, appointments, orders, model, customers, orderPackageIdNamePair, orderTestIdNamePair, idNamePairs, registeredbyAgent, roles, pcpAppointments);
        }

        //TODO: To move it from here.
        public EventCustomerSummaryModel GetEventCustomerSummary(long eventId, long customerId)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            if (eventCustomer == null) return null;
            DateTime? appointmentTime = null;
            if (eventCustomer.AppointmentId.HasValue)
            {
                appointmentTime = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value).StartTime;
            }

            var order = _orderRepository.GetOrder(customerId, eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var eventBasicInfo = _eventService.GetEventBasicInfoFor(eventId);

            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(new[] { order.Id });
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(new[] { order.Id });
            var orderItemProductNamePair = _productRepository.GetProductNameForOrderItems(order.OrderDetails
                .Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).Select(od => od.OrderItemId).ToArray());

            var sourceCodes =
                _sourceCodeRepository.GetSourceCodeByIds(order.OrderDetails
                    .Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive)
                    .Select(od => od.SourceCodeOrderDetail.SourceCodeId).Distinct().ToArray());

            var shippingDetailOrderDetails =
                order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess)
                .SelectMany(od => od.ShippingDetailOrderDetails);

            IEnumerable<ChargeCard> cards = null;
            if (order.PaymentsApplied != null && order.PaymentsApplied.Count() > 0 && order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard).Count() > 0)
            {
                cards = _chargeCardRepository.GetByIds(
                    order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard)
                    .Select(pa => ((ChargeCardPayment)pa).ChargeCardId));
            }

            var shippingDetails = new List<ShippingDetail>();
            if (shippingDetailOrderDetails.Count() > 0)
            {
                shippingDetailOrderDetails.All(sd =>
                                                   {
                                                       shippingDetails.Add(
                                                           _shippingDetailRepository.GetById(sd.ShippingDetailId));
                                                       return true;
                                                   });
            }

            return _eventCustomerSummaryModelFactory.Create(eventCustomer, order, eventBasicInfo, customer, appointmentTime, orderPackageIdNamePair, orderTestIdNamePair, orderItemProductNamePair, shippingDetails, sourceCodes, cards);
        }

        public ListModelBase<CancelledCustomerModel, CancelledCustomerModelFilter> GetCancelledCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetCancelledEventCustomers(pageNumber, pageSize, filter as CancelledCustomerModelFilter, out  totalRecords);

            if (eventCustomers.IsNullOrEmpty()) return null;

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orderIdEventCustomerIdPairs = _orderRepository.GetOrderEventCustomerIdPairforEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            var notes = _customerNotesRepository.GetNotes(eventCustomers.Select(ec => ec.CustomerId).ToArray(), CustomerRegistrationNotesType.CancellationNote);

            var refundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orderIdEventCustomerIdPairs.Select(oec => oec.FirstValue).ToArray(), RefundRequestType.CustomerCancellation);

            var orders = _orderRepository.GetByIds(orderIdEventCustomerIdPairs.Select(oe => oe.FirstValue).ToList());

            var appointmentCancellationLogs = _eventAppointmentCancellationLogRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            var orgRoleUserIds = new List<long>();

            orgRoleUserIds.AddRange(eventCustomers.Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());

            var requestedByOrgRoleUserIds = refundRequests.Select(r => r.RequestedByOrgRoleUserId).Distinct().ToArray();
            if (requestedByOrgRoleUserIds.Count() > 0)
                orgRoleUserIds.AddRange(requestedByOrgRoleUserIds);

            foreach (var order in orders)
            {
                if (!order.OrderDetails.Where(od => od.IsCompleted).Any())
                {
                    var orderDetail = order.OrderDetails.OrderByDescending(od => od.Id).First();
                    orgRoleUserIds.Add(orderDetail.DataRecorderMetaData.DataRecorderCreator.Id);
                }
            }

            orgRoleUserIds = orgRoleUserIds.Select(oru => oru).Distinct().ToList();

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(
                    eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id));


            var roles = _roleRepository.GetAll();

            return _cancelledCustomerModelFactory.Create(eventCustomers, model, customers, orderIdEventCustomerIdPairs, notes, refundRequests, orders, idNamePairs, registeredbyAgent, roles, appointmentCancellationLogs);
        }

        public EventCustomerListModel GetEventCustomerList(long eventId, EventCustomerListModelFilter filter)
        {
            var corporateAccount = _corporateAccountRepository.GetbyEventId(eventId);

            var model = _eventService.GetEventInfoforEventCustomerListModel(eventId, corporateAccount);

            var eventAppointmentSlotSummary = _eventAppointmentService.GetEventAppointmentSlotSummary(eventId, model.IsDynamicScheduling);

            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

            var customerIds = eventCustomers == null || eventCustomers.Count() < 1 ? new long[0] : eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

            var eventCustomerIds = eventCustomers == null ? new long[0] : eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.Id).Distinct().ToArray();

            var customers = customerIds.Count() > 0 ? _customerRepository.GetCustomers(customerIds) : null;

            var orders = _orderRepository.GetAllOrdersForEvent(eventId);

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);

            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var physicianAssignments = _physicianAssignmentService.GetPhysicianAssignments(eventId, eventCustomerIds);

            var customerNotes = _customerNotesRepository.GetCustomerNotes(eventId, customerIds);

            var orgRoleUserIds = customerNotes.Where(x => x.DataRecorderMetaData != null && x.DataRecorderMetaData.DataRecorderCreator != null).Select(x => x.DataRecorderMetaData.DataRecorderCreator.Id).ToArray();

            var marekedByorgRoleUsers = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            var leftWithoutScreeningNotes = customerNotes.Where(x => x.NotesType == CustomerRegistrationNotesType.LeftWithoutScreeningNotes);

            if (!leftWithoutScreeningNotes.IsNullOrEmpty())
            {
                foreach (var patientLeftNote in leftWithoutScreeningNotes)
                {
                    patientLeftNote.ReasonName = patientLeftNote.ReasonId.HasValue ? ((LeftWithoutScreeningReason)patientLeftNote.ReasonId.Value).GetDescription() : "";
                    var createdBy = patientLeftNote.DataRecorderMetaData != null && patientLeftNote.DataRecorderMetaData.DataRecorderCreator != null ?
                        marekedByorgRoleUsers.FirstOrDefault(x => x.FirstValue == patientLeftNote.DataRecorderMetaData.DataRecorderCreator.Id) : null;
                    patientLeftNote.CreatedBy = createdBy != null ? createdBy.SecondValue : string.Empty;
                }
            }

            var eventCustomerResults = _eventCustomerResultRepository.GetByEventId(eventId);

            var sourceCodeIds = orders != null && orders.Count() > 0 ? orders.SelectMany(o => o.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.SourceCodeOrderDetail != null)
                                                                        .Select(od => od.SourceCodeOrderDetail.SourceCodeId).ToArray()).ToArray() : new long[0];

            var authorizedEventCustomerIds = _screeningAuthorizationRepository.GetEventCustomersAuthorizedforanEvent(eventId);

            var customersPreApprovedTest = _eventCustomerPreApprovedTestRepository.GetCustomerIdPreApprovedTests(eventCustomerIds).ToList();

            var customersPreApprovedPackageTests = _eventCustomerPreApprovedPackageTestRepository.GetCustomerIdPreApprovedPackageTests(eventCustomerIds).ToList();
            if (customersPreApprovedPackageTests.Any())
            {
                customersPreApprovedTest.AddRange(customersPreApprovedPackageTests);
            }

            /*var customersPreApprovedPackage = _preApprovedPackageRepository.GetIdByCustomerIds(customerIds).ToArray();

            var packageIds = customersPreApprovedPackage.Select(x => x.SecondValue);
            if (customersPreApprovedPackage.Any())
            {
                var packagesForCustomers = _packageRepository.GetByIds(packageIds).ToArray();

                foreach (var orderedPair in customersPreApprovedPackage)
                {
                    var packageId = orderedPair.SecondValue;
                    var package = packagesForCustomers.FirstOrDefault(x => x.Id == packageId);
                    if (package != null)
                    {
                        var customersTests =
                            customersPreApprovedTest.Where(x => x.FirstValue == orderedPair.FirstValue).ToArray();
                        if (customersTests.Any())
                        {
                            foreach (var test in package.Tests)
                            {
                                if (!customersTests.Any(x => x.SecondValue == test.Name))
                                {
                                    customersPreApprovedTest.Add(new OrderedPair<long, string>(orderedPair.FirstValue, test.Name));
                                }
                            }
                        }
                        else
                        {
                            foreach (var test in package.Tests)
                            {
                                customersPreApprovedTest.Add(new OrderedPair<long, string>(orderedPair.FirstValue, test.Name));

                            }
                        }
                    }
                }
            }*/


            IEnumerable<long> unProcessedShippingCustomers = null;
            var cdShippingDetails = new List<ShippingDetail>();

            if (orders != null)
            {
                unProcessedShippingCustomers = (from item in orders
                                                let activeOrderDetail = item.OrderDetails.SingleOrDefault(od => (od.DetailType == OrderItemType.EventPackageItem || od.DetailType == OrderItemType.EventTestItem) && od.EventCustomerOrderDetail != null && od.EventCustomerOrderDetail.IsActive && od.IsCompleted)
                                                where activeOrderDetail != null
                                                let shippings = _shippingDetailRepository.GetShippingDetailsForCancellation(activeOrderDetail.Id)
                                                where shippings.Where(sd => sd.Status == ShipmentStatus.Processing).Any()//sd.ActualPrice > 0 && 
                                                select item.CustomerId).ToArray();

                var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();
                var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
                var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);
                if (cdShippingOption != null)
                    cdShippingDetails = shippingDetails.Where(sd => sd.ShippingOption.Id == cdShippingOption.Id).Select(sd => sd).ToList();

            }

            var filledHealthAssesmentForms =
                _healthAssessmentRepository.GetCustomerIdsforFilledHealthAssmtFormbyEventId(eventId);

            var sourceCodes = _sourceCodeRepository.GetSourceCodeByIds(sourceCodeIds);

            var products = _productRepository.GetAllProductsForEvent(eventId);

            var orgRoleUsers = orders == null || orders.Count() < 1
                                   ? null
                                   : _organizationRoleUserRepository.GetOrganizationRoleUsers(orders.Select(o => o.DataRecorderMetaData.DataRecorderCreator.Id).Distinct());

            var refundRequests = new List<RefundRequest>();
            if (orders != null)
            {
                var productRefundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orders.Select(o => o.Id), RefundRequestType.CDRemoval);
                var shippingRefundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orders.Select(o => o.Id), RefundRequestType.CancelShipping);
                refundRequests.AddRange(productRefundRequests);
                refundRequests.AddRange(shippingRefundRequests);
            }
            IEnumerable<PrimaryCarePhysician> primaryCarePhysicians = null;
            if (model.CapturePcpStatus)
                primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            var answeredMedicareQuestionsOrderdPair = _medicareQuestionRepository.GetEvenetCustomerMedicareSavedDatePair(eventId);

            var patientLeftNotes = customerNotes.Where(x => x.NotesType == CustomerRegistrationNotesType.LeftWithoutScreeningNotes);

            var eawvMarkedTestnotPerforemd = _eventCustomerResultRepository.GetEawvTestNotPerformedReason(eventCustomers.Select(x => x.Id));

            var eventCustomerListModel = _eventCustomerListModelFactory.Create(model, eventCustomers, eventCustomerResults, customerNotes, physicianAssignments, eventAppointmentSlotSummary.AppointmentSlots, customers, orders,
                                                         sourceCodes, authorizedEventCustomerIds, unProcessedShippingCustomers, filledHealthAssesmentForms, eventPackages, eventTests, products, filter,
                                                         orgRoleUsers, refundRequests, cdShippingDetails, primaryCarePhysicians, answeredMedicareQuestionsOrderdPair, corporateAccount, customersPreApprovedTest,
                                                         patientLeftNotes, eawvMarkedTestnotPerforemd);

            QuestionnaireType questionnaireType = QuestionnaireType.None;
            if (corporateAccount != null)
            {
                questionnaireType = _accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(corporateAccount.Id, model.EventDate);

                eventCustomerListModel.CorporateAccountTag = corporateAccount.Tag;
                eventCustomerListModel.IsHealthPlanEvent = corporateAccount.IsHealthPlan;
                eventCustomerListModel.ShowHraQuestionnaire = questionnaireType == QuestionnaireType.HraQuestionnaire ? true : false;
                eventCustomerListModel.ShowChatQuestionnaire = questionnaireType == QuestionnaireType.ChatQuestionnaire ? true : false; ;
            }

            return eventCustomerListModel;

        }

        public ListModelBase<CustomerExportModel, CustomerExportListModelFilter> GetCustomersForExport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            //using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            //{
            var customers = _customerRepository.GetCustomerForExport(pageNumber, pageSize, filter as CustomerExportListModelFilter, out totalRecords);
            if (customers.IsNullOrEmpty())
            {
                //scope.Complete();
                return null;
            }

            var customerIds = customers.Select(c => c.CustomerId).ToArray();

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            var eventCustomers = _eventCustomerRepository.GetForCustomerExport(customerIds, filter as CustomerExportListModelFilter);
            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds);

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var sourceCodes = _sourceCodeRepository.GetSourceCodeByIds(orders.SelectMany(o => o.OrderDetails.Where(od => od.SourceCodeOrderDetail != null && od.SourceCodeOrderDetail.IsActive)
                            .Select(od => od.SourceCodeOrderDetail.SourceCodeId)).Distinct().ToArray());

            var roles = _roleRepository.GetAll();

            var callDetails = _callCenterCallRepository.GetCallDetails(customers);

            var languages = _languageRepository.GetAll();
            var labs = _labRepository.GetAll();
            var customTags = _customTagRepository.GetByCustomerIds(customerIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            var notesids = customers.Where(x => x.DoNotContactReasonNotesId.HasValue).Select(x => x.DoNotContactReasonNotesId.Value).ToList();

            var donotContactNotes = _notesRepository.Get(notesids);

            var customersPreApprovedTest = _preApprovedTestRepository.GetPreApprovedTests(customerIds);
            var customersPreApprovedPackage = _preApprovedPackageRepository.GetByCustomerIds(customerIds);

            var corporateTags = customers.Select(x => x.Tag).Distinct().ToArray();
            var corporateAccounts = _corporateAccountRepository.GetByTags(corporateTags);

            var accountIds = corporateAccounts.Select(x => x.Id).ToArray();
            var additionalFields = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsByAccountIds(accountIds);

            var currentDate = DateTime.Today;
            var fromDate = new DateTime(currentDate.Year, 1, 1);
            var toDate = new DateTime(currentDate.Year, 12, 31);
            var customerPredictedZips = _customerPredictedZipRespository.GetByCustomerIdAndDate(customerIds, fromDate, toDate);

            var chaseOutbounds = _chaseOutboundRepository.GetByCustomerIds(customerIds);
            var relationships = _relationshipRepository.GetAll();

            var activityTypes = _activityTypeRepository.GetByIds(customers.Where(x => x.ActivityId.HasValue).Select(x => x.ActivityId.Value).ToArray());

            //scope.Complete();
            return _customerExportModelFactory.Create(customers, eventCustomers, model, orders, orderPackageIdNamePair, orderTestIdNamePair, roles, sourceCodes, callDetails, languages, labs,
                customTags, primaryCarePhysicians, donotContactNotes, customersPreApprovedTest, customersPreApprovedPackage, appointments, corporateAccounts, additionalFields, customerPredictedZips,
                customerEligibilities, chaseOutbounds, relationships, activityTypes);
            //}
        }

        public ListModelBase<RescheduleApplointmentModel, RescheduleApplointmentListModelFilter> GetRescheduleAppointments(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var rescheduledAppointments = _eventAppointmentChangeLogRepository.GetRescheduledAppointment(pageNumber, pageSize, filter as RescheduleApplointmentListModelFilter, out totalRecords);
            if (rescheduledAppointments.IsNullOrEmpty()) return null;

            var eventCustomers = _eventCustomerRepository.GetByIds(rescheduledAppointments.Select(ra => ra.EventCustomerId).Distinct().ToArray()).ToArray();

            var eventIds = rescheduledAppointments.Select(ra => ra.OldEventId).ToList();
            eventIds.AddRange(rescheduledAppointments.Select(ra => ra.NewEventId));

            var eventsVolumeWithSponsoredBy = _eventReportingService.GetEventVolumeModel(eventIds.Distinct().ToArray());

            var events = _eventRepository.GetByIds(eventIds.Distinct());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            var agents = _organizationRoleUserRepository.GetOrganizationRoleUsers(rescheduledAppointments.Select(ra => ra.CreatedByOrgRoleUserId).Distinct().ToArray());

            var roles = _roleRepository.GetAll();

            var agentIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(rescheduledAppointments.Select(ra => ra.CreatedByOrgRoleUserId).Distinct().ToArray()).ToArray();

            return _rescheduleAppointmentModelFactory.Create(rescheduledAppointments, eventCustomers, customers, events, agents, roles, agentIdNamePairs, eventsVolumeWithSponsoredBy);
        }

        public EventCustomerBrifListModel GetEventCustomerBriefList(long eventId, EventCustomerListModelFilter filter)
        {
            var model = _eventService.GetEventCustomerBrifListModel(eventId);

            var account = _corporateAccountRepository.GetbyEventId(eventId);

            var eventAppointmentSlotSummary = _eventAppointmentService.GetEventAppointmentSlotSummary(eventId);

            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

            var customerIds = eventCustomers == null || !eventCustomers.Any() ? new long[0] : eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

            var customers = customerIds.Count() > 0 ? _customerRepository.GetCustomers(customerIds) : null;

            var orders = _orderRepository.GetAllOrdersForEvent(eventId);


            var shippingDetails = new List<ShippingDetail>();

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);

            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var filledHealthAssesmentForms =
                _healthAssessmentRepository.GetCustomerIdsforFilledHealthAssmtFormbyEventId(eventId);


            var products = _productRepository.GetAllProductsForEvent(eventId);

            var orgRoleUsers = orders == null || orders.Count() < 1
                                   ? null
                                   : _organizationRoleUserRepository.GetOrganizationRoleUsers(orders.Select(o => o.DataRecorderMetaData.DataRecorderCreator.Id).Distinct());

            var refundRequests = new List<RefundRequest>();
            if (orders != null)
            {
                var productRefundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orders.Select(o => o.Id), RefundRequestType.CDRemoval);
                var shippingRefundRequests = _refundRequestRepository.GeRefundRequestByOrderIds(orders.Select(o => o.Id), RefundRequestType.CancelShipping);
                refundRequests.AddRange(productRefundRequests);
                refundRequests.AddRange(shippingRefundRequests);

                var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Where(sdod => sdod.IsActive).Select(sdod => sdod.ShippingDetailId))).ToArray();
                shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds).ToList();

            }

            var sourceCodeIds = orders != null && orders.Any() ? orders.SelectMany(o => o.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.SourceCodeOrderDetail != null)
                                                                        .Select(od => od.SourceCodeOrderDetail.SourceCodeId).ToArray()).ToArray() : new long[0];
            var sourceCodes = _sourceCodeRepository.GetSourceCodeByIds(sourceCodeIds);

            IEnumerable<PrimaryCarePhysician> primaryCarePhysicians = null;
            if (model.CapturePcpConsent)
                primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            return _eventCustomerListModelFactory.CreateBrifListModel(model, eventCustomers, eventAppointmentSlotSummary.AppointmentSlots, customers, orders,
                                                            filledHealthAssesmentForms, products, filter, eventPackages, eventTests, orgRoleUsers, shippingDetails, sourceCodes, account, primaryCarePhysicians);


        }

        public bool IsCustomerScreeningTestResultExists(long eventCustomerResultId)
        {
            return _eventCustomerResultRepository.IsCustomerScreeningTestResultExists(eventCustomerResultId);
        }

        public ListModelBase<TestsBookedModel, TestsBookedListModelFilter> GetTestsBooked(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomerTestsPair = _eventCustomerRepository.GetTestBooked(pageNumber, pageSize, filter as TestsBookedListModelFilter, out totalRecords);
            if (eventCustomerTestsPair.IsNullOrEmpty()) return null;

            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerTestsPair.ToList().Select(ec => ec.FirstValue).Distinct().ToArray());
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();


            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            var tests = _testRepository.GetAll();
            var pods = _podRepository.GetPodsForEvents(eventIds);
            var events = ((IEventRepository)_eventRepository).GetEventswithPodbyIds(eventIds);

            return _testsBookedModelFactory.Create(eventCustomerTestsPair, eventCustomers, events, customers, pods, tests);
        }

        public ListModelBase<PcpAppointmentViewModel, PcpAppointmentListModelFilter> GetPcpAppointment(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var pcpAppointmentModel = _eventCustomerRepository.GetEventCustomersForPcpAppointmentReporting(filter as PcpAppointmentListModelFilter, pageNumber, pageSize, out totalRecords);
            if (pcpAppointmentModel == null || !pcpAppointmentModel.Any()) return null;

            var eventCustomers = _eventCustomerRepository.GetByIds(pcpAppointmentModel.Select(ra => ra.EventCustomerId).Distinct().ToArray()).ToArray();

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

            var customerEligibilities = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, DateTime.Today.Year);

            var customers = _customerRepository.GetCustomers(customerIds);

            var customTags = _customTagRepository.GetByCustomerIds(customerIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            var eventVolumeListModel = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());
            var eventCustomerIds = eventCustomers.Select(x => x.Id).Distinct();

            var pcpAppointments = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomerIds);
            var pcpDisposition = _pcpDispositionRepository.GetByEventCustomerIds(eventCustomerIds);

            var agentIds = new List<long>();

            if (!pcpAppointments.IsNullOrEmpty())
            {
                agentIds.AddRange(pcpAppointments.Where(x => x.ModifiedBy.HasValue).Select(x => x.ModifiedBy.Value));
                agentIds.AddRange(pcpAppointments.Where(x => x.CreatedBy.HasValue).Select(x => x.CreatedBy.Value));
            }

            if (!pcpDisposition.IsNullOrEmpty())
            {
                agentIds.AddRange(pcpDisposition.Select(x => x.DataRecorderMetaData.DataRecorderCreator.Id));
            }

            var agents = _organizationRoleUserRepository.GetNameIdPairofUsers(agentIds.Distinct().ToArray());

            var collection = _pcpAppointmentViewModelFactory.Create(pcpAppointmentModel, eventCustomers, customers, customTags, primaryCarePhysicians, agents, eventVolumeListModel,
                pcpAppointments, pcpDisposition, customerEligibilities);

            return new PcpAppointmentListModel { Collection = collection };
        }

        public IEnumerable<EventRescheduleAppointmentViewModel> GetRescheduleAppointmentsForEvent(long eventId)
        {
            var eventCustomerIds = _eventAppointmentChangeLogRepository.GetEventCustomerIdByEventId(eventId);
            if (eventCustomerIds == null || !eventCustomerIds.Any())
                return null;

            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds).ToArray();

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray());

            return _rescheduleAppointmentModelFactory.CreateEventRescheduleAppointment(eventCustomers, customers);
        }

        public ListModelBase<MemberStatusModel, MemberStatusListModelFilter> GetMemberStatusReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {

            var modelFilter = (MemberStatusListModelFilter)filter;
            modelFilter = modelFilter ?? new MemberStatusListModelFilter();

            var customers = _customerRepository.GetMemberForReport(pageNumber, pageSize, modelFilter, out totalRecords);
            if (customers.IsNullOrEmpty())
            {
                return null;
            }

            var customerIds = customers.Select(c => c.CustomerId).ToArray();
            var customerEligibilityList = _customerEligibilityRepository.GetCustomerEligibilityByCustomerIdsAndYear(customerIds, modelFilter.FromDate.Year);

            var customerTargetedList = _customerTargetedRepository.GetCustomerTargetedByCustomerIdsAndYear(customerIds, modelFilter.FromDate.Year);

            var eventCustomers = _eventCustomerRepository.GetByCustomerIdEventDate(customerIds, modelFilter.FromDate, modelFilter.ToDate);
            var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);

            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            var directMails = _directMailRepository.GetByCustomerIds(customerIds, modelFilter.FromDate, modelFilter.ToDate);

            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var prospectCustoemrs = _prospectCustomerRepository.GetProspectCustomersByCustomerIds(customerIds);

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();
            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
            var shippingDetailIdEventCustomerIdPairs = _shippingDetailRepository.GetShippingDetailIdEventCustomerIdPairs(shippingDetails.Select(sd => sd.Id));

            var customerShipping = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();

            var pcpShipingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages, true);

            var callDetails = _callCenterCallRepository.GetCallsByCustomerIds(customerIds, modelFilter.FromDate, modelFilter.ToDate, callAttemptFilter: modelFilter.CallAttemptFilter);

            var customTags = _customTagRepository.GetByCustomerIds(customerIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            var notesids = customers.Where(x => x.DoNotContactReasonNotesId.HasValue).Select(x => x.DoNotContactReasonNotesId.Value).ToArray();

            var donotContactNotes = _notesRepository.Get(notesids);

            var customersPreApprovedTest = _preApprovedTestRepository.GetPreApprovedTests(customerIds);
            var customersPreApprovedPackage = _preApprovedPackageRepository.GetByCustomerIds(customerIds);

            var tagNames = customers.Where(x => !string.IsNullOrEmpty(x.Tag)).Select(x => x.Tag).ToArray();
            var corporateAccount = _corporateAccountRepository.GetByTags(tagNames);
            var corporateAccountIds = corporateAccount.Select(x => x.Id).ToArray();
            var accountAdditionalField = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsByAccountIds(corporateAccountIds);
            var customerPredictedZips = _customerPredictedZipRespository.GetByCustomerIdAndDate(customerIds, modelFilter.FromDate, modelFilter.ToDate);

            var activityTypes = _activityTypeRepository.GetByIds(customers.Where(x => x.ActivityId.HasValue).Select(x => x.ActivityId.Value).ToArray());

            return _memberStatusModelFactory.Create(customers, eventCustomers, model, orders, orderPackageIdNamePair, orderTestIdNamePair, callDetails, customTags, primaryCarePhysicians, donotContactNotes,
                customersPreApprovedTest, customersPreApprovedPackage, directMails, appointments, shippingDetails, shippingDetailIdEventCustomerIdPairs, customerShipping, pcpShipingOption, corporateAccount,
                accountAdditionalField, modelFilter.FromDate, modelFilter.ToDate, prospectCustoemrs, customerPredictedZips, customerEligibilityList, customerTargetedList, activityTypes);
        }

        public ListModelBase<CustomerLeftWithoutScreeningModel, CustomerLeftWithoutScreeningModelFilter> GetCustomerLeftWithoutScreening(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetCustomerLeftWithoutScreening(pageNumber, pageSize,
                                                                                  filter as CustomerLeftWithoutScreeningModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;
            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var pcpAppointments = _pcpAppointmentRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToList());

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var orgRoleUserIds = new List<long>();

            orgRoleUserIds.AddRange(eventCustomers.Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());
            orgRoleUserIds = orgRoleUserIds.Select(oru => oru).Distinct().ToList();
            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(
                    eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id));

            var roles = _roleRepository.GetAll();

            var tags = customers.Where(x => !string.IsNullOrEmpty(x.Tag)).Select(x => x.Tag).ToArray();

            var corporateAccount = _corporateAccountRepository.GetByTags(tags);

            var patientLeftNotes = _customerCallNotesRepository.GetNotes(customers.Select(x => x.CustomerId), CustomerRegistrationNotesType.LeftWithoutScreeningNotes);

            return _customerLeftWithoutScreeningModelFactory.Create(eventCustomers, appointments, orders, model, customers, orderPackageIdNamePair, orderTestIdNamePair, idNamePairs, registeredbyAgent, roles, pcpAppointments, patientLeftNotes, corporateAccount);
        }

        public ListModelBase<VoiceMailReminderModel, VoiceMailReminderModelFilter> GetVoiceMailReminderReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetVoiceMailReminderReport(pageNumber, pageSize,
                                                                                     filter as VoiceMailReminderModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToList());

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            return _voiceMailReminderModelFactory.Create(eventCustomers, model, customers, orderPackageIdNamePair, appointments, orders, orderTestIdNamePair);
        }

        public ListModelBase<TextReminderViewModel, TextReminderModelFilter> GetTextReminderReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetTextReminderReport(pageNumber, pageSize,
                                                                                   filter as TextReminderModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orgRoleUserIds = eventCustomers.Where(ec => ec.DataRecorderMetaData != null && ec.DataRecorderMetaData.DataRecorderCreator != null).Select(ec => ec.DataRecorderMetaData.DataRecorderCreator.Id).ToList();

            var eventAppointmentChangeLogs = _eventAppointmentChangeLogRepository.GetByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToArray()).ToArray();

            orgRoleUserIds.AddRange(eventAppointmentChangeLogs.Select(eacl => eacl.CreatedByOrgRoleUserId));

            var registeredbyAgent = _organizationRoleUserRepository.GetOrganizationRoleUsers(orgRoleUserIds);

            var roles = _roleRepository.GetAll();

            var registeredbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray()).ToArray();

            return _textReminderModelFactory.Create(eventCustomers, model, customers, registeredbyAgent, roles, registeredbyAgentNameIdPair);
        }

        public ListModelBase<GapsClosureModel, GapsClosureModelFilter> GetGapsClosureReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventcustomerPreApprovedTest = _eventCustomerPreApprovedTestRepository.GetEventCustomerResultForGapsClosure(pageNumber, pageSize, filter as GapsClosureModelFilter, out totalRecords);

            if (eventcustomerPreApprovedTest == null || !eventcustomerPreApprovedTest.Any())
            {
                return null;
            }
            var eventCustomerIds = eventcustomerPreApprovedTest.Select(x => x.EventCustomerId).Distinct();

            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);

            var customerIds = eventCustomers.Select(x => x.CustomerId).ToArray();

            var customers = _customerRepository.GetCustomers(customerIds);

            var events = ((IEventRepository)_eventRepository).GetEventswithPodbyIds(eventCustomers.Select(x => x.EventId).ToArray());

            var eventCustomerResultIds = eventCustomers.Select(x => x.Id).ToArray();

            var resultStatuses = _eventCustomerResultRepository.GetTestResultStatus(eventCustomerResultIds);

            var testNotPerformedCollection = _testNotPerformedRepository.GetEventCustomerResultTestNotPerformed(eventCustomerResultIds);

            var tests = _testRepository.GetAll();

            var pods = _podRepository.GetPodsForEvents(eventCustomers.Select(x => x.EventId).ToArray());

            var tags = customers.Select(x => x.Tag).ToArray();

            var corporateAccount = _corporateAccountRepository.GetByTags(tags);

            return _gapsClosureModelFactory.Create(eventcustomerPreApprovedTest, eventCustomers, customers, events, resultStatuses, testNotPerformedCollection, tests, pods, corporateAccount);
        }



        public CorporateEventCustomerViewModel GetCorporateEventCustomerViewModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var model = new CorporateEventCustomerViewModel();

            var eventCustomers = _eventCustomerRepository.GetCorporateEventCustomerbyEventId(pageNumber, pageSize, filter as CorporateEventCustomerModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var eventVolumeModel = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());
            model.EventData = _corporateEventCustomerFactory.Create(eventVolumeModel.Collection.FirstOrDefault());
            totalRecords = 0;
            var customerList = new List<CorporateEventCustomersModel>();
            var corporateEventCustomerListModel = new CorporateEventCustomerListModel();
            corporateEventCustomerListModel.Collection = GetEventCustomerListModel(pageNumber, pageSize, filter, out totalRecords).Collection.ToList();
            model.CorporateEventCustomerListModel = corporateEventCustomerListModel;
            return model;
        }

        public ListModelBase<CorporateEventCustomersModel, CorporateEventCustomerModelFilter> GetEventCustomerListModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetCorporateEventCustomerbyEventId(pageNumber, pageSize, filter as CorporateEventCustomerModelFilter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;
            var appointments = _appointmentRepository.GetByIds(eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value).ToList());

            var model = _eventReportingService.GetEventVolumeModel(eventCustomers.Select(ec => ec.EventId).ToArray());

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomers.Select(ec => ec.Id).ToList());

            var orderIds = orders.Select(o => o.Id).ToArray();
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orderIds);
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orderIds);

            var orderItemProductNamePair = _productRepository.GetProductNameForOrderItems(orders.SelectMany(o => o.OrderDetails.Select(od => od.OrderItemId)).ToArray());
            var eventFilter = filter as CorporateEventCustomerModelFilter;

            return _corporateEventCustomerFactory.CreateCustomerScheduleModelforEvent(eventCustomers, appointments, orders, eventFilter.EventId, customers, orderPackageIdNamePair, orderTestIdNamePair);
        }

        public bool CanMarkedAsLeftWithoutScreening(long eventCustomerId)
        {
            var eventCustomerResult = _eventCustomerResultRepository.GetById(eventCustomerId);

            return (eventCustomerResult == null || eventCustomerResult.ResultState < (long)TestResultStateNumber.PreAudit);
        }

        public ListModelBase<HealthPlanGiftCertificateReportViewModel, HealthPlanGiftCertificateReportFilter> GetForHealthPlanGiftCertificateReport(int pageNumber, int pageSize, HealthPlanGiftCertificateReportFilter filter, out int totalRecords)
        {
            var eventCustomers = _eventCustomerRepository.GetForHealthPlanGiftCertificateReport(pageNumber, pageSize, filter, out totalRecords);
            if (eventCustomers.IsNullOrEmpty()) return null;

            var customerIds = eventCustomers.Select(ec => ec.CustomerId).ToArray();
            var customers = _customerRepository.GetCustomers(customerIds);

            var collection = new List<HealthPlanGiftCertificateReportViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == eventCustomer.CustomerId);
                if (customer == null) continue;

                var model = new HealthPlanGiftCertificateReportViewModel
                {
                    DollarAmount = 50m,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    MiddleInitial = !string.IsNullOrEmpty(customer.Name.MiddleName) ? customer.Name.MiddleName.Substring(0, 1) : string.Empty,
                    ShipToLine1 = customer.Address != null ? customer.Address.StreetAddressLine1 : string.Empty,
                    ShipToLine2 = customer.Address != null ? customer.Address.StreetAddressLine2 : string.Empty,
                    City = customer.Address != null ? customer.Address.City : string.Empty,
                    State = customer.Address != null ? customer.Address.StateCode : string.Empty,
                    Zip = customer.Address != null ? customer.Address.ZipCode.Zip : string.Empty,
                    CountryCode = 840,
                    Message1 = "8473254330-01",
                    Message2 = "574671-326632-157553",
                    ProductId = 11496,
                    ClientId = 1084,
                    ProgramId = "484224474",
                    CardLife = 12,
                    CarrierMessage2 = "Thanks for caring about your health and",
                    CarrierMessage3 = "having a checkup with Matrix Medical Network."
                };

                collection.Add(model);
            }

            return new HealthPlanGiftCertificateReportListModel
            {
                Collection = collection,
                Filter = filter
            };
        }

        public IEnumerable<ShortPatientInfoViewModel> GetCustomerAppointmentList(long eventId, EventCustomerListModelFilter filter)
        {
            var eventAppointmentSlotSummary = _eventAppointmentService.GetEventAppointmentSlotSummary(eventId);

            var eventCustomers = _eventCustomerRepository.GetbyEventId(eventId);

            var customerIds = eventCustomers == null || !eventCustomers.Any() ? new long[0] : eventCustomers.Select(ec => ec.CustomerId).Distinct().ToArray();

            var customers = customerIds.Count() > 0 ? _customerRepository.GetCustomers(customerIds) : null;

            var orders = _orderRepository.GetAllOrdersForEvent(eventId);

            var orgRoleUsers = orders.IsNullOrEmpty() ? null : _organizationRoleUserRepository.GetOrganizationRoleUsers(orders.Select(o => o.DataRecorderMetaData.DataRecorderCreator.Id).Distinct());

            var host = _hostRepository.GetHostForEvent(eventId);

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(eventId);

            var eventTests = _eventTestRepository.GetTestsForEvent(eventId);

            var eventCustomerIds = eventCustomers.Select(x => x.Id);

            var participationConsentSignatures = _participationConsentSignatureRepository.GetByEventCustomerIds(eventCustomerIds);
            var fluConsentSignatures = _fluConsentSignatureRepository.GetByEventCustomerIds(eventCustomerIds);
            var physicianRecordRequestSignatures = _physicianRecordRequestSignatureRepository.GetByEventCustomerIds(eventCustomerIds);
            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(customerIds);

            var chaperoneSignature = _chaperoneSignatureRepository.GetByEventCustomerIds(eventCustomerIds).Distinct();
           
            
            return _eventCustomerListModelFactory.CreateCustomerAppointmentList(eventCustomers, eventAppointmentSlotSummary.AppointmentSlots, customers,
                orders, filter, orgRoleUsers, host, eventPackages, eventTests, participationConsentSignatures, fluConsentSignatures, physicianRecordRequestSignatures, primaryCarePhysicians, chaperoneSignature);


        }
    }
}
