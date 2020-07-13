using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class HospitalPartnerService : IHospitalPartnerService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IHospitalPartnerCustomerViewModelFactory _hospitalPartnerCustomerViewModelFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly IHospitalPartnerCustomerRepository _hospitalPartnerCustomerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IHospitalPartnerEventListFactory _hospitalPartnerEventListFactory;
        private readonly IUniqueItemRepository<ShippingDetail> _shippingDetailRepository;
        private readonly IPodRepository _podRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly INotesRepository _notesRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IHospitalPartnerDashboardViewModelFactory _hospitalPartnerViewModelFactory;

        private readonly ICustomerCallNotesRepository _customerCallNotesRepository;
        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly ISettings _settings;
        private readonly ILanguageRepository _languageRepository;

        public HospitalPartnerService(IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, IEventPackageRepository eventPackageRepository,
            IEventTestRepository eventTestRepository, IHospitalPartnerCustomerViewModelFactory hospitalPartnerCustomerViewModelFactory, IEventCustomerResultRepository eventCustomerResultRepository, IHospitalPartnerRepository hospitalPartnerRepository,
            IHospitalPartnerCustomerRepository hospitalPartnerCustomerRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IEventRepository eventRepository, IPodRepository podRepository, IOrganizationRepository organizationRepository,
            IHostRepository hostRepository, IHospitalPartnerEventListFactory hospitalPartnerEventListFactory, IUniqueItemRepository<ShippingDetail> shippingDetailRepository, IShippingOptionRepository shippingOptionRepository,
            ICorporateAccountRepository corporateAccountRepository, INotesRepository notesRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IHealthAssessmentRepository healthAssessmentRepository,
            IHospitalPartnerDashboardViewModelFactory hospitalPartnerViewModelFactory, ICustomerCallNotesRepository customerCallNotesRepository, IEventCustomerNotificationRepository eventCustomerNotificationRepository,
            IHospitalFacilityRepository hospitalFacilityRepository, ISettings settings,ILanguageRepository languageRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _hospitalPartnerCustomerViewModelFactory = hospitalPartnerCustomerViewModelFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _hospitalPartnerCustomerRepository = hospitalPartnerCustomerRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _hospitalPartnerEventListFactory = hospitalPartnerEventListFactory;
            _shippingDetailRepository = shippingDetailRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _podRepository = podRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _notesRepository = notesRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _hospitalPartnerViewModelFactory = hospitalPartnerViewModelFactory;
            _customerCallNotesRepository = customerCallNotesRepository;
            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _settings = settings;
            _languageRepository = languageRepository;
        }

        public ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter> GetHospitalPartnerCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var normalValidityPeriod = 0;
                var abnormalValidityPeriod = 0;
                var criticalValidityPeriod = 0;
                var customerFilter = (filter as HospitalPartnerCustomerListModelFilter);

                HospitalPartner hospitalPartner = null;
                if (customerFilter != null)
                {
                    if (customerFilter.HospitalPartnerId > 0)
                    {
                        hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(customerFilter.HospitalPartnerId);
                        normalValidityPeriod = hospitalPartner.NormalResultValidityPeriod;
                        abnormalValidityPeriod = hospitalPartner.AbnormalResultValidityPeriod;
                        criticalValidityPeriod = hospitalPartner.CriticalResultValidityPeriod;
                    }
                    else if (customerFilter.HospitalFacilityId > 0)
                    {
                        var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(customerFilter.HospitalFacilityId);

                        if (hospitalPartnerId > 0)
                        {
                            hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                            normalValidityPeriod = hospitalPartner.NormalResultValidityPeriod;
                            abnormalValidityPeriod = hospitalPartner.AbnormalResultValidityPeriod;
                            criticalValidityPeriod = hospitalPartner.CriticalResultValidityPeriod;
                        }
                    }
                }
                var eventCustomers = _eventCustomerRepository.SearchCustomersForHospitalPartner(pageNumber, pageSize, filter as HospitalPartnerCustomerListModelFilter, out totalRecords, normalValidityPeriod, abnormalValidityPeriod, criticalValidityPeriod);
                var model = eventCustomers.IsNullOrEmpty() ? null : GetCustomers(eventCustomers, hospitalPartner);

                t.Complete();
                return model;
            }
        }

        public ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter> GetHospitalPartnerEventCustomers(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var normalValidityPeriod = 0;
                var abnormalValidityPeriod = 0;
                var criticalValidityPeriod = 0;
                var customerFilter = (filter as HospitalPartnerCustomerListModelFilter);

                HospitalPartner hospitalPartner = null;
                if (customerFilter != null)
                {
                    if (customerFilter.HospitalPartnerId > 0)
                    {
                        hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(customerFilter.HospitalPartnerId);
                        normalValidityPeriod = hospitalPartner.NormalResultValidityPeriod;
                        abnormalValidityPeriod = hospitalPartner.AbnormalResultValidityPeriod;
                        criticalValidityPeriod = hospitalPartner.CriticalResultValidityPeriod;
                    }
                    else if (customerFilter.HospitalFacilityId > 0)
                    {
                        var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(customerFilter.HospitalFacilityId);

                        if (hospitalPartnerId > 0)
                        {
                            hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                            normalValidityPeriod = hospitalPartner.NormalResultValidityPeriod;
                            abnormalValidityPeriod = hospitalPartner.AbnormalResultValidityPeriod;
                            criticalValidityPeriod = hospitalPartner.CriticalResultValidityPeriod;
                        }
                    }
                }
                var eventCustomers = _eventCustomerRepository.EventCustomersForHospitalPartner(pageNumber, pageSize, filter as HospitalPartnerCustomerListModelFilter, out totalRecords, normalValidityPeriod, abnormalValidityPeriod, criticalValidityPeriod);

                var model = eventCustomers.IsNullOrEmpty() ? null : GetCustomers(eventCustomers, hospitalPartner);

                t.Complete();
                return model;
            }
        }

        private HospitalPartnerCustomerListModel GetCustomers(IEnumerable<EventCustomer> eventCustomers, HospitalPartner hospitalPartner)
        {
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var eventIds = eventCustomers.Select(ec => ec.EventId).Distinct().ToArray();

            var customers = _customerRepository.GetCustomers(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var orders = _orderRepository.GetAllOrdersByEventCustomerIds(eventCustomerIds, true);
            var orderPackageIdNamePair = _eventPackageRepository.GetPackageNamesForOrder(orders.Select(o => o.Id).ToList());
            var orderTestIdNamePair = _eventTestRepository.GetTestNamesForOrders(orders.Select(o => o.Id).ToList());

            var hospitalPartnerCustomers = _hospitalPartnerCustomerRepository.GetHospitalPartnerCustomers(eventIds);

            var orgRoleUserIds = new List<long>();
            orgRoleUserIds.AddRange(hospitalPartnerCustomers.Select(hpc => hpc.CareCoordinatorOrgRoleUserId).ToArray());
            orgRoleUserIds.AddRange(hospitalPartnerCustomers.Select(hpc => hpc.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());
            orgRoleUserIds.AddRange(hospitalPartnerCustomers.Where(hpc => hpc.DataRecorderMetaData.DataRecorderModifier != null).Select(hpc => hpc.DataRecorderMetaData.DataRecorderModifier.Id).ToArray());
            orgRoleUserIds = orgRoleUserIds.Select(oru => oru).Distinct().ToList();

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerIds);
            eventCustomerResults = eventCustomerResults.Where(ecr => ecr.ResultState >= (long)TestResultStateNumber.Evaluated).ToArray();

            var pods = _podRepository.GetPodsForEvents(eventIds);

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var shippingDetailIds = orders.SelectMany(o => o.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId))).ToArray();

            var resultStatuses = _eventCustomerResultRepository.GetTestResultStatus(eventCustomerIds);

            var shippingDetails = _shippingDetailRepository.GetByIds(shippingDetailIds);
            var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);

            //var eventIdHospitalPartnerIdPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);

            var eventHospitalPartners = _hospitalPartnerRepository.GetEventHospitalPartnersByEventIds(eventIds).ToArray();

            var organizationIds = eventHospitalPartners.Select(ehp => ehp.HospitalPartnerId).Distinct().ToArray();
            var hospitalFacilityIds = eventCustomers.Where(ec => ec.HospitalFacilityId.HasValue && ec.HospitalFacilityId.Value > 0).Select(ec => ec.HospitalFacilityId.Value).ToArray();

            organizationIds = organizationIds.Concat(hospitalFacilityIds).ToArray();

            var organizations = _organizationRepository.GetOrganizations(organizationIds);
            var eventIdHospitalPartnerNamePairs = (from ehp in eventHospitalPartners
                                                   join org in organizations on ehp.HospitalPartnerId equals org.Id
                                                   select new OrderedPair<long, string>(ehp.EventId, org.Name)).ToArray();

            var eventIdCorporateAccounrNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var healthAssessmentQuestions = _healthAssessmentRepository.GetAllQuestions();

            var healthAssessmentAnswers = _healthAssessmentRepository.GetByCustomerIds(eventCustomers.Select(ec => ec.CustomerId).ToArray());

            var notes = _customerCallNotesRepository.GetNotes(eventCustomers.Select(ec => ec.CustomerId).ToArray(), CustomerRegistrationNotesType.PostScreeningFollowUpNotes);

            var eventCustomerNotifications = _eventCustomerNotificationRepository.GetByEventCustomerIds(eventCustomerIds, NotificationTypeAlias.CannedMessageNotification);

            var hospitalFacilities = hospitalFacilityIds.Any() ? _hospitalFacilityRepository.GetByIds(hospitalFacilityIds) : null;

            var eventCustomerIdHospitalFacilityNamePairs = (from ec in eventCustomers
                                                            join org in organizations on ec.HospitalFacilityId equals org.Id
                                                            select new OrderedPair<long, string>(ec.Id, org.Name)).ToArray();

            var showScannedDocumentHospitalPartnerIds = _settings.ShowScannedDocumentHospitalPartnerIds;

            var languages = _languageRepository.GetAll();

            return _hospitalPartnerCustomerViewModelFactory.Create(eventCustomers, orders, customers, orderPackageIdNamePair, orderTestIdNamePair, hospitalPartnerCustomers, idNamePairs, events, shippingDetails,
                                                                   resultStatuses, cdShippingOption, pods, eventIdHospitalPartnerNamePairs, eventIdCorporateAccounrNamePairs, primaryCarePhysicians,
                                                                   healthAssessmentQuestions, healthAssessmentAnswers, eventCustomerResults, hospitalPartner, notes, eventCustomerNotifications, eventHospitalPartners,
                                                                   eventCustomerIdHospitalFacilityNamePairs, hospitalFacilities, showScannedDocumentHospitalPartnerIds, languages);

        }

        public ListModelBase<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter> GetHospitalPartnerEvents(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var normalValidityPeriod = 0;
                var abnormalValidityPeriod = 0;
                var criticalValidityPeriod = 0;
                var eventFilter = (filter as HospitalPartnerEventListModelFilter);
                if (eventFilter != null && eventFilter.HospitalPartnerId > 0)
                {
                    var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(eventFilter.HospitalPartnerId);
                    normalValidityPeriod = hospitalPartner.NormalResultValidityPeriod;
                    abnormalValidityPeriod = hospitalPartner.AbnormalResultValidityPeriod;
                    criticalValidityPeriod = hospitalPartner.CriticalResultValidityPeriod;
                }

                var events = _eventRepository.GetEventsForHospitalPartner(pageNumber, pageSize, filter as HospitalPartnerEventListModelFilter, out totalRecords, normalValidityPeriod, abnormalValidityPeriod, criticalValidityPeriod);
                var eventIds = events.Select(e => e.Id).ToArray();

                var hosts = _hostRepository.GetEventHosts(eventIds);
                var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);

                var normalCustomers = _eventCustomerResultRepository.GetResultSummaryIEventIdCustomersCountForEventIds(eventIds, ResultInterpretation.Normal, true, normalValidityPeriod);
                var abnormalCustomers = _eventCustomerResultRepository.GetResultSummaryIEventIdCustomersCountForEventIds(eventIds, ResultInterpretation.Abnormal, true, abnormalValidityPeriod);
                var criticalCustomers = _eventCustomerResultRepository.GetCriticalEventIdCustomersCountForEventIds(eventIds, ResultInterpretation.Critical, true, criticalValidityPeriod);
                var urgentCustomers = _eventCustomerResultRepository.GetResultSummaryIEventIdCustomersCountForEventIds(eventIds, ResultInterpretation.Urgent, true, criticalValidityPeriod);

                var eventIdNotesIdPair = _hospitalPartnerRepository.GetEventIdNotesIdPair(eventIds);
                var notes = _notesRepository.Get(eventIdNotesIdPair.Select(ec => ec.SecondValue));

                var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(notes.Select(n => n.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());

                var model = new HospitalPartnerEventListModel();
                model.Collection = _hospitalPartnerEventListFactory.Create(events, hosts, customersAttended, criticalCustomers, abnormalCustomers, eventIdNotesIdPair, notes, urgentCustomers, normalCustomers, idNamePairs);
                t.Complete();
                return model;
            }
        }

        public ListModelBase<HospitalPartnerCustomerViewModel, HospitalPartnerCustomerListModelFilter> GetCustomerAggregateResultSummary(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var customerFilter = filter as HospitalPartnerCustomerListModelFilter;
                var eventCustomers = _eventCustomerRepository.GetEventCustomersForAggregateResultSummary(pageNumber, pageSize, customerFilter, out totalRecords);

                HospitalPartner hospitalPartner = null;
                if (customerFilter != null && customerFilter.HospitalPartnerId > 0)
                {
                    hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(customerFilter.HospitalPartnerId);
                }

                var model = eventCustomers.IsNullOrEmpty() ? null : GetCustomers(eventCustomers, hospitalPartner);

                t.Complete();
                return model;
            }
        }

        public IEnumerable<HospitalPartnerCustomerActivityViewModel> GetHospitalPartnerCustomerActivities(long eventId, long customerId)
        {
            var hospitalPartnerCustomers = _hospitalPartnerCustomerRepository.GetHospitalPartnerCustomers(eventId, customerId);

            var orgRoleUserIds = new List<long>();
            orgRoleUserIds.AddRange(hospitalPartnerCustomers.Select(hpc => hpc.CareCoordinatorOrgRoleUserId).ToArray());
            orgRoleUserIds.AddRange(hospitalPartnerCustomers.Select(hpc => hpc.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());
            orgRoleUserIds.AddRange(hospitalPartnerCustomers.Where(hpc => hpc.DataRecorderMetaData.DataRecorderModifier != null).Select(hpc => hpc.DataRecorderMetaData.DataRecorderModifier.Id).ToArray());
            orgRoleUserIds = orgRoleUserIds.Select(oru => oru).Distinct().ToList();

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds.ToArray());

            return _hospitalPartnerCustomerViewModelFactory.GetHospitalPartnerCustomerActivities(hospitalPartnerCustomers, idNamePairs);
        }

        public IEnumerable<NotesViewModel> GetEventNotes(long eventId)
        {
            var notes = _hospitalPartnerRepository.GetHospitalPartnerEventNotes(eventId);

            var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(notes.Select(n => n.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());

            return _hospitalPartnerEventListFactory.CreateNotesViewModel(notes, idNamePairs);
        }

        public HospitalPartnerCallStatusViewModel GetHospitalPartnerCallStatus(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                var eventIds = _hospitalPartnerRepository.GetEventIdsForHospitalPartner(hospitalPartnerId);
                if (eventIds.IsNullOrEmpty())
                    return null;

                var hospitalPartnerCustomers = new List<HospitalPartnerCustomer>();
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerId(hospitalPartnerId, ResultInterpretation.Abnormal, hospitalPartner.AbnormalResultValidityPeriod));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerIdForCritical(hospitalPartnerId, ResultInterpretation.Critical, hospitalPartner.CriticalResultValidityPeriod));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerId(hospitalPartnerId, ResultInterpretation.Urgent, hospitalPartner.CriticalResultValidityPeriod));

                t.Complete();
                return _hospitalPartnerViewModelFactory.CreateCallStatus(abnormalCustomers, criticalCustomers, urgentCustomers, hospitalPartnerCustomers);
            }
        }

        public HospitalPartnerScheduledOutcomeViewModel GetHospitalPartnerScheduledOutcome(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                var eventIds = _hospitalPartnerRepository.GetEventIdsForHospitalPartner(hospitalPartnerId);
                if (eventIds.IsNullOrEmpty())
                    return null;

                var hospitalPartnerCustomers = new List<HospitalPartnerCustomer>();
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerId(hospitalPartnerId, ResultInterpretation.Abnormal, hospitalPartner.AbnormalResultValidityPeriod));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerIdForCritical(hospitalPartnerId, ResultInterpretation.Critical, hospitalPartner.CriticalResultValidityPeriod));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerId(hospitalPartnerId, ResultInterpretation.Urgent, hospitalPartner.CriticalResultValidityPeriod));

                t.Complete();
                return _hospitalPartnerViewModelFactory.CreateScheduledOutcome(abnormalCustomers, criticalCustomers, urgentCustomers, hospitalPartnerCustomers);
            }
        }

        public HospitalPartnerNotScheduledOutcomeViewModel GetHospitalPartnerNotScheduledOutcome(long hospitalPartnerId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                var eventIds = _hospitalPartnerRepository.GetEventIdsForHospitalPartner(hospitalPartnerId);
                if (eventIds.IsNullOrEmpty())
                    return null;

                var hospitalPartnerCustomers = new List<HospitalPartnerCustomer>();
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerId(hospitalPartnerId, ResultInterpretation.Abnormal, hospitalPartner.AbnormalResultValidityPeriod));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerIdForCritical(hospitalPartnerId, ResultInterpretation.Critical, hospitalPartner.CriticalResultValidityPeriod));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalPartnerCustomersByHospitalPartnerId(hospitalPartnerId, ResultInterpretation.Urgent, hospitalPartner.CriticalResultValidityPeriod));

                t.Complete();
                return _hospitalPartnerViewModelFactory.CreateNotScheduledOutcome(abnormalCustomers, criticalCustomers, urgentCustomers, hospitalPartnerCustomers);
            }
        }

        public HospitalPartnerCallStatusViewModel GetHospitalFacilityCallStatus(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(hospitalFacilityId);

                HospitalPartner hospitalPartner = null;
                if (hospitalPartnerId > 0)
                    hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                var eventIds = _hospitalFacilityRepository.GetEventIdsForHospitalFacility(hospitalFacilityId);
                if (eventIds.IsNullOrEmpty())
                    return null;

                var hospitalPartnerCustomers = new List<HospitalPartnerCustomer>();
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityId(hospitalFacilityId, ResultInterpretation.Abnormal, hospitalPartner != null ? hospitalPartner.AbnormalResultValidityPeriod : 0));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityIdForCritical(hospitalFacilityId, ResultInterpretation.Critical, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityId(hospitalFacilityId, ResultInterpretation.Urgent, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0));

                t.Complete();
                return _hospitalPartnerViewModelFactory.CreateCallStatus(abnormalCustomers, criticalCustomers, urgentCustomers, hospitalPartnerCustomers);
            }
        }

        public HospitalPartnerScheduledOutcomeViewModel GetHospitalFacilityScheduledOutcome(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(hospitalFacilityId);

                HospitalPartner hospitalPartner = null;
                if (hospitalPartnerId > 0)
                    hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                var eventIds = _hospitalFacilityRepository.GetEventIdsForHospitalFacility(hospitalFacilityId);
                if (eventIds.IsNullOrEmpty())
                    return null;

                var hospitalPartnerCustomers = new List<HospitalPartnerCustomer>();
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityId(hospitalFacilityId, ResultInterpretation.Abnormal, hospitalPartner != null ? hospitalPartner.AbnormalResultValidityPeriod : 0));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityIdForCritical(hospitalFacilityId, ResultInterpretation.Critical, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityId(hospitalFacilityId, ResultInterpretation.Urgent, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0));

                t.Complete();
                return _hospitalPartnerViewModelFactory.CreateScheduledOutcome(abnormalCustomers, criticalCustomers, urgentCustomers, hospitalPartnerCustomers);
            }
        }

        public HospitalPartnerNotScheduledOutcomeViewModel GetHospitalFacilityNotScheduledOutcome(long hospitalFacilityId, int abnormalCustomers, int criticalCustomers, int urgentCustomers)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(hospitalFacilityId);

                HospitalPartner hospitalPartner = null;
                if (hospitalPartnerId > 0)
                    hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                var eventIds = _hospitalFacilityRepository.GetEventIdsForHospitalFacility(hospitalFacilityId);
                if (eventIds.IsNullOrEmpty())
                    return null;

                var hospitalPartnerCustomers = new List<HospitalPartnerCustomer>();
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityId(hospitalFacilityId, ResultInterpretation.Abnormal, hospitalPartner != null ? hospitalPartner.AbnormalResultValidityPeriod : 0));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityIdForCritical(hospitalFacilityId, ResultInterpretation.Critical, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0));
                hospitalPartnerCustomers.AddRange(_hospitalPartnerCustomerRepository.GetHospitalFacilityCustomersByHospitalFacilityId(hospitalFacilityId, ResultInterpretation.Urgent, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0));

                t.Complete();
                return _hospitalPartnerViewModelFactory.CreateNotScheduledOutcome(abnormalCustomers, criticalCustomers, urgentCustomers, hospitalPartnerCustomers);
            }
        }

        public ListModelBase<HospitalPartnerEventViewModel, HospitalPartnerEventListModelFilter> GetHospitalFacilityEvents(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var normalValidityPeriod = 0;
                var abnormalValidityPeriod = 0;
                var criticalValidityPeriod = 0;
                var eventFilter = (filter as HospitalPartnerEventListModelFilter);
                if (eventFilter != null && eventFilter.HospitalFacilityId > 0)
                {
                    var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(eventFilter.HospitalFacilityId);

                    if (hospitalPartnerId > 0)
                    {
                        var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

                        normalValidityPeriod = hospitalPartner.NormalResultValidityPeriod;
                        abnormalValidityPeriod = hospitalPartner.AbnormalResultValidityPeriod;
                        criticalValidityPeriod = hospitalPartner.CriticalResultValidityPeriod;
                    }
                }

                var events = _eventRepository.GetEventsForHospitalFacility(pageNumber, pageSize, filter as HospitalPartnerEventListModelFilter, out totalRecords, normalValidityPeriod, abnormalValidityPeriod, criticalValidityPeriod);
                if (events.IsNullOrEmpty())
                {
                    t.Complete();
                    return null;
                }
                var eventIds = events.Select(e => e.Id).ToArray();

                var hosts = _hostRepository.GetEventHosts(eventIds);
                var customersAttended = _eventRepository.GetAttendedCustomersByEventIdsAndHospitalFacilityId(eventIds, eventFilter.HospitalFacilityId);

                var normalCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForEventIdsAndHospitalFacility(eventIds, ResultInterpretation.Normal, eventFilter.HospitalFacilityId, true, normalValidityPeriod);
                var abnormalCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForEventIdsAndHospitalFacility(eventIds, ResultInterpretation.Abnormal, eventFilter.HospitalFacilityId, true, abnormalValidityPeriod);
                var criticalCustomers = _eventCustomerResultRepository.GetCriticalEventIdCustomersCountForEventIdsAndHospitalFacility(eventIds, ResultInterpretation.Critical, eventFilter.HospitalFacilityId, true, criticalValidityPeriod);
                var urgentCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForEventIdsAndHospitalFacility(eventIds, ResultInterpretation.Urgent, eventFilter.HospitalFacilityId, true, criticalValidityPeriod);

                var eventIdNotesIdPair = _hospitalPartnerRepository.GetEventIdNotesIdPair(eventIds);
                var notes = _notesRepository.Get(eventIdNotesIdPair.Select(ec => ec.SecondValue));

                var idNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(notes.Select(n => n.DataRecorderMetaData.DataRecorderCreator.Id).ToArray());

                var model = new HospitalPartnerEventListModel();
                model.Collection = _hospitalPartnerEventListFactory.Create(events, hosts, customersAttended, criticalCustomers, abnormalCustomers, eventIdNotesIdPair, notes, urgentCustomers, normalCustomers, idNamePairs);
                t.Complete();
                return model;
            }
        }
    }
}
