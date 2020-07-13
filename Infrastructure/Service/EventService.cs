using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Service
{
    public class EventService : IEventService
    {
        private const int RECORD_COUNT = 50;
        private const int Page_Number = 1;

        private readonly IHostRepository _hostRepository;
        private readonly IHostFacilityRankingService _hostFacilityRankingService;
        private readonly IEventStaffAssignmentService _eventStaffAssignmentService;

        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUniqueItemRepository<Event> _uniqueItemRepository;
        private readonly IEventHostViewDataFactory _eventHostViewDataFactory;
        private readonly IPodRepository _podRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICdContentGeneratorTrackingRepository _cdContentGenerator;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICorporateAccountEventListFactory _corporateAccountEventListFactory;
        private readonly IOnlineSchedulingEventListModelFactory _onlineSchedulingEventListModelFactory;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventAppointmentStatsService _eventAppointmentStatsService;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IEventAppointmentService _eventAppointmentService;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly ISystemGeneratedCallQueueCriteriaService _fillEventsQueueCriteriaService;
        private readonly IFillEventsCallQueueHelper _fillEventsCallQueueHelper;
        private readonly IEventBasicInfoListHelper _eventBasicInfoListHelper;
        private readonly IEventNoteRepository _eventNoteRepository;
        private readonly IAddEventNoteFactory _addEventNoteFactory;
        private readonly IMapEventListModelFactory _mapEventListModelFactory;
        private readonly ICustomEventNotificationRepository _customEventNotificationRepository;
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly IEventRoleRepository _eventRoleRepository;
        private readonly IPodStaffAssignmentRepository _podStaffAssignmentRepository;
        private readonly ISettings _settings;
        private readonly IZipRadiusDistanceRepository _zipRadiusDistanceRepository;
        public EventService(IEventHostViewDataFactory eventHostViewDataFactory, IZipCodeRepository zipCodeRepository, IOrganizationRepository organizationRepository,
            IEventRepository eventRepository, IHostRepository hostRepository, IUniqueItemRepository<Event> uniqueItemRepository, IAppointmentRepository appointmentRepository, IHospitalPartnerRepository hospitalPartnerRepository,
            IPodRepository podRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, ICdContentGeneratorTrackingRepository cdContentGenerator, IEventTestRepository eventTestRepository, IUniqueItemRepository<File> fileRepository,
            IEventCustomerResultRepository eventCustomerResultRepository, ICorporateAccountEventListFactory corporateAccountEventListFactory, IOnlineSchedulingEventListModelFactory onlineSchedulingEventListModelFactory,
            IMediaRepository mediaRepository, ICorporateAccountRepository corporateAccountRepository, IHostFacilityRankingService hostFacilityRankingService, IEventStaffAssignmentService eventStaffAssignmentService,
            IEventCustomerRepository eventCustomerRepository, IEventAppointmentStatsService eventAppointmentStatsService, IEventSchedulingSlotRepository eventSchedulingSlotRepository, IEventAppointmentService eventAppointmentService,
            IHospitalFacilityRepository hospitalFacilityRepository, IEventPodRepository eventPodRepository, ISystemGeneratedCallQueueCriteriaService fillEventsQueueCriteriaService, IFillEventsCallQueueHelper fillEventsCallQueueHelper,
            IEventBasicInfoListHelper eventBasicInfoListHelper, IEventNoteRepository eventNoteRepository, IAddEventNoteFactory addEventNoteFactory, IMapEventListModelFactory mapEventListModelFactory,
            ICustomEventNotificationRepository customEventNotificationRepository, IEventStaffAssignmentRepository eventStaffAssignmentRepository, IEventRoleRepository eventRoleRepository, IPodStaffAssignmentRepository podStaffAssignmentRepository,
            ISettings settings, IZipRadiusDistanceRepository zipRadiusDistanceRepository)
        {
            _zipCodeRepository = zipCodeRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _uniqueItemRepository = uniqueItemRepository;
            _eventHostViewDataFactory = eventHostViewDataFactory;
            _podRepository = podRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _appointmentRepository = appointmentRepository;
            _cdContentGenerator = cdContentGenerator;
            _eventTestRepository = eventTestRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _corporateAccountEventListFactory = corporateAccountEventListFactory;
            _onlineSchedulingEventListModelFactory = onlineSchedulingEventListModelFactory;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _hostFacilityRankingService = hostFacilityRankingService;
            _corporateAccountRepository = corporateAccountRepository;
            _eventStaffAssignmentService = eventStaffAssignmentService;
            _eventCustomerRepository = eventCustomerRepository;
            _eventAppointmentStatsService = eventAppointmentStatsService;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _eventAppointmentService = eventAppointmentService;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _eventPodRepository = eventPodRepository;
            _fillEventsQueueCriteriaService = fillEventsQueueCriteriaService;
            _fillEventsCallQueueHelper = fillEventsCallQueueHelper;
            _eventBasicInfoListHelper = eventBasicInfoListHelper;
            _eventNoteRepository = eventNoteRepository;
            _addEventNoteFactory = addEventNoteFactory;
            _mapEventListModelFactory = mapEventListModelFactory;
            _customEventNotificationRepository = customEventNotificationRepository;
            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _eventRoleRepository = eventRoleRepository;
            _podStaffAssignmentRepository = podStaffAssignmentRepository;
            _settings = settings;
            _zipRadiusDistanceRepository = zipRadiusDistanceRepository;
        }

        public EventHostViewData GetById(long eventId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var host = _hostRepository.GetHostForEvent(eventId);
            var pods = _podRepository.GetPodsForEvent(eventId);
            return new EventHostViewData(eventData, host, pods);
        }

        public List<EventHostViewData> GetEventHostViewData(ViewType viewType, string stateName, string cityName, string invitationCode, string zipCode, int zipRange, DateTime? fromDate, DateTime? toDate, long corporateId = 0,
            bool enableForCallcenter = false, long excludeEventId = 0, string tag = "", bool hasMammo = false, bool allEvents = false, long? ProductType = null) //, long customerId = 0
        {
            switch (viewType)
            {
                case ViewType.Technician:
                    return GetEventHostViewData(stateName, cityName, zipCode, zipRange, fromDate, toDate, invitationCode, enableForCallcenter, excludeEventId, tag, hasMammo, allEvents, ProductType); //, customerId
                case ViewType.CallCenterRep:
                    return GetEventHostViewData(stateName, cityName, zipCode, zipRange, fromDate, toDate, invitationCode, enableForCallcenter, excludeEventId, tag, hasMammo, allEvents, ProductType); //, customerId
                case ViewType.CustomerPortal:
                    return GetEventHostViewData(stateName, cityName, zipCode, zipRange, fromDate, toDate, invitationCode, enableForCallcenter, excludeEventId, tag, hasMammo, allEvents, ProductType); //, customerId
                default:
                    return null;
            }
        }

        private List<EventHostViewData> GetEventHostViewData(string stateName, string cityName, string zipCode, int zipRange, DateTime? fromDate, DateTime? toDate, string invitationCode, bool enableForCallcenter = false, long excludeEventId = 0,
            string tag = "", bool hasMammo = false, bool allEvents = false,long? ProductType=null) //, long customerId = 0
        {
            //TODO:Since there can be multiple zip entry with same zip code 
            //TODO:but it should be handled on ui to ask user the specific state and city in which the zipcode lies.
            ZipCode originalZipCode = null;
            if (!string.IsNullOrEmpty(zipCode))
            {
                try
                {
                    originalZipCode = _zipCodeRepository.GetZipCode(zipCode).FirstOrDefault();
                }
                catch (ObjectNotFoundInPersistenceException<ZipCode>)
                {
                    return null;
                }
            }

            var events = _eventRepository.GetEventsByFilters(zipCode, zipRange == 0 ? null : (int?)zipRange, stateName, cityName, fromDate, toDate, invitationCode, Page_Number, RECORD_COUNT, enableForCallcenter, excludeEventId, tag, hasMammo, zipCodeId: (originalZipCode != null ? originalZipCode.Id : 0), allEvents: allEvents, ProductType: ProductType); //, customerId: customerId

            var pods = _podRepository.GetPodsForEvents(events.Select(e => e.Id).ToArray());
            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events.Select(e => e.Id).ToArray());


            var eventIds = events.Select(x => x.Id).ToArray();
            var corporateAccountNames = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);
            var hospitalPartnerNames = _hospitalPartnerRepository.GetEventIdHospitalPartnerNamePair(eventIds);
            var zipRadiusDistance = originalZipCode == null ? null : _zipRadiusDistanceRepository.GetBySourceZipId(originalZipCode.Id);
            var eventHostViewDatas = _eventHostViewDataFactory.Create(events, pods, originalZipCode, eventAppointmentStatsModels, corporateAccountNames, hospitalPartnerNames, zipRadiusDistances: zipRadiusDistance);

            return OrderEventHostViewData(eventHostViewDatas);
        }

        private static List<EventHostViewData> OrderEventHostViewData(List<EventHostViewData> eventHostViewDatas)
        {
            //eventHostViewDatas = eventHostViewDatas.OrderBy(e => e.EventDate).ToList();

            //eventHostViewDatas =
            //    eventHostViewDatas.GroupBy(e => e.DistanceFromZip).OrderBy(group => group.Key).Select(
            //        group => group.OrderBy(g => g.EventDate).Select(g => g)).SelectMany(g => g).Take(RECORD_COUNT).ToList();

            eventHostViewDatas = eventHostViewDatas.OrderBy(x => x.EventDate).Take(RECORD_COUNT).ToList();

            return eventHostViewDatas;
        }

        public List<EventHostViewData> GetEventByInvitataionCd(string pInvitationCode)
        {
            var events = _eventRepository.GetEventByInvitataionCd(pInvitationCode);
            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events.Select(e => e.Id).ToArray());
            var eventHostViewDatas = _eventHostViewDataFactory.Create(events, null, null, eventAppointmentStatsModels);

            eventHostViewDatas =
                eventHostViewDatas.GroupBy(e => e.DistanceGroup).OrderBy(group => group.Key).Select(
                    group => group.OrderBy(g => g.EventDate).Select(g => g)).SelectMany(g => g).ToList();

            return eventHostViewDatas;

        }

        public EventBasicInfoViewModel GetEventBasicInfoFor(long eventId)
        {
            var theEvent = _uniqueItemRepository.GetById(eventId);
            var host = _hostRepository.GetHostForEvent(theEvent.Id);
            var pods = _podRepository.GetPodsForEvent(theEvent.Id);

            var eventModel = new EventBasicInfoViewModel();
            eventModel = Mapper.Map<Event, EventBasicInfoViewModel>(theEvent);
            eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
            eventModel.HostName = host.OrganizationName;
            eventModel.Pods = pods != null ? pods.Select(p => new OrderedPair<long, string>(p.Id, p.Name)) : null;

            return eventModel;
        }

        public EventBasicInfoListModel GetEventBasicInfo(EventBasicInfoViewModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var events = _eventRepository.GetEventsbyFilters(filter, pageNumber, pageSize, out totalRecords);
            if (events == null || !events.Any()) return null;

            return EventBasicInfoListModel(events);
        }

        public OnlineSchedulingEventViewModel GetSelectedEvent(long eventId)
        {
            var theEvent = _eventRepository.GetById(eventId);
            if (theEvent == null || theEvent.EventDate < DateTime.Now.Date || theEvent.Status != EventStatus.Active) return null;

            var host = _hostRepository.GetHostForEvent(eventId);

            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);

            File file = null;
            if (hospitalPartnerId > 0)
            {
                var org = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                file = org != null && org.LogoImageId > 0 ? _fileRepository.GetById(org.LogoImageId) : null;
            }
            else
            {
                var corprateAccount = _corporateAccountRepository.GetbyEventId(eventId);
                if (corprateAccount != null)
                {
                    var org = _organizationRepository.GetOrganizationbyId(corprateAccount.Id);
                    file = org != null && org.LogoImageId > 0 ? _fileRepository.GetById(org.LogoImageId) : null;
                }
            }
            if (file != null)
            {
                var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                file.Path = location.Url + file.Path;
            }
            var model = _onlineSchedulingEventListModelFactory.Create(theEvent, host, null, file);

            model.EventAppointSlotSummaryViewModel = _eventAppointmentService.GetEventAppointmentSlotSummary(eventId);
            return model;
        }

        public OnlineSchedulingEventListModel GetOnlineSchedulingEventCollection(OnlineSchedulingEventListModelFilter filter, SortOrderBy sortOrderBy, SortOrderType sortOrderType, int maxNumberofRecordstoFetch, int pageNumber, int pageSize, out int totalRecords)
        {
            var events = _eventRepository.GetEventsbyFilters(filter, out totalRecords);
            if (events == null || events.Count() < 1) return null;

            var todayEventIds = events.Where(e => e.EventDate < DateTime.Now.Date.AddDays(1)).Select(e => e.Id);
            var todaySlots = _eventSchedulingSlotRepository.GetbyEventIds(todayEventIds);

            var eventIds = events.Select(e => e.Id).Distinct().ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            var totalSlotCounts = eventAppointmentStatsModels.Select(easm => new OrderedPair<long, int>(easm.EventId, easm.TotalSlots - easm.BlockedSlots));
            var availableSlotCount = eventAppointmentStatsModels.Select(easm => new OrderedPair<long, int>(easm.EventId, easm.FreeSlots));

            ZipCode zipCode = null;
            try
            {
                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                }
            }
            catch (ObjectNotFoundInPersistenceException<ZipCode>)
            {
                zipCode = null;
            }

            var model = _onlineSchedulingEventListModelFactory.Create(events, hosts, totalSlotCounts, availableSlotCount, zipCode, todaySlots, filter.EventId, filter.CutOffHourstoMarkEventforOnlineSelection,
                sortOrderBy, sortOrderType, maxNumberofRecordstoFetch, pageNumber, pageSize, out totalRecords);

            eventIds = model.Events.Select(e => e.EventId).Distinct().ToArray();

            foreach (var theEvent in model.Events)
            {
                var eventTest = _eventTestRepository.GetByEventAndTestIds(theEvent.EventId, TestGroup.BreastCancer);
                theEvent.HasBreastCancer = eventTest != null && eventTest.Any();
            }

            var appointments = _appointmentRepository.GetAppointmentsForEvents(eventIds);
            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);
            var eventCorporateAccountPairs = _corporateAccountRepository.GetEventIdCorporateAccountPairForSponsoredBy(eventIds);
            model = _onlineSchedulingEventListModelFactory.ManipulateSlotAvilabilityDisplay(model, appointments);

            var organizations = eventCorporateAccountPairs == null || eventCorporateAccountPairs.Count() < 1 ? null : _organizationRepository.GetOrganizations(eventCorporateAccountPairs.Select(m => m.SecondValue).Distinct().ToArray());
            var fileIds = organizations != null ? organizations.Where(o => o.LogoImageId > 0).Select(o => o.LogoImageId).ToArray() : null;
            var files = fileIds == null ? null : _fileRepository.GetByIds(fileIds);
            if (files != null)
            {
                var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                files = files.Select(f =>
                {
                    f.Path = location.Url + f.Path;
                    return f;
                }).ToArray();

                model = _onlineSchedulingEventListModelFactory.ManageSponsoredByLogo(model, eventCorporateAccountPairs, organizations, files);
            }

            organizations = eventHpPairs == null || eventHpPairs.Count() < 1 ? null : _organizationRepository.GetOrganizations(eventHpPairs.Select(m => m.SecondValue).Distinct().ToArray());
            fileIds = organizations != null ? organizations.Where(o => o.LogoImageId > 0).Select(o => o.LogoImageId).ToArray() : null;
            files = fileIds == null ? null : _fileRepository.GetByIds(fileIds);
            if (files != null)
            {
                var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                files = files.Select(f =>
                {
                    f.Path = location.Url + f.Path;
                    return f;
                }).ToArray();

                model = _onlineSchedulingEventListModelFactory.ManageSponsoredByLogo(model, eventHpPairs, organizations, files);
            }

            return model;
        }

        public EventNotes GetAllEventNotes(long eventId)
        {
            var callcenterNotes = new NotesViewModel() { Note = _eventRepository.GetCallCenterNotes(eventId) };
            var technicianNotes = new NotesViewModel() { Note = _eventRepository.GetTechnicianNotes(eventId) };
            return new EventNotes() { CallCenterNotes = callcenterNotes, TechnicianNotes = technicianNotes };
        }

        public EventNotes GetCallCenterEventNotes(long eventId)
        {
            var callcenterNotes = new NotesViewModel() { Note = _eventRepository.GetCallCenterNotes(eventId) };
            return new EventNotes() { CallCenterNotes = callcenterNotes, TechnicianNotes = null };
        }

        public EventNotes GetTechnicianEventNotes(long eventId)
        {
            var technicianNotes = new NotesViewModel() { Note = _eventRepository.GetTechnicianNotes(eventId) };
            return new EventNotes() { CallCenterNotes = null, TechnicianNotes = technicianNotes };
        }

        public IEnumerable<EventBasicInfoViewModel> GetEventBasicInfoFor(EventStaffAssignmentListModelFilter filter, bool isForExport = false)
        {
            var events = _eventRepository.GetForStaffCalendar(filter, isForExport);
            if (events == null || !events.Any())
                return null;
            var eventIds = events.Select(x => x.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            var totalSlotCounts = eventAppointmentStatsModels.Select(easm => new OrderedPair<long, int>(easm.EventId, easm.TotalSlots - easm.BlockedSlots));
            var filledSlotCount = eventAppointmentStatsModels.Select(easm => new OrderedPair<long, int>(easm.EventId, easm.BookedSlots));

            var eventModels = new List<EventBasicInfoViewModel>();
            foreach (var @event in events)
            {
                var eventModel = new EventBasicInfoViewModel();
                var host = hosts.Where(h => h.Id == @event.HostId).First();
                eventModel = Mapper.Map<Event, EventBasicInfoViewModel>(@event);
                eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
                eventModel.HostName = host.OrganizationName;
                eventModel.Pods = pods.Where(p => @event.PodIds.Contains(p.Id)).Select(p => new OrderedPair<long, string>(p.Id, p.Name)).ToArray();

                var totalSlotCountPair = totalSlotCounts.Where(p => p.FirstValue == @event.Id).FirstOrDefault();
                eventModel.TotalAppointmentSlots = totalSlotCountPair == null ? 0 : totalSlotCountPair.SecondValue;

                var filledSlotCountPair = filledSlotCount.Where(p => p.FirstValue == @event.Id).FirstOrDefault();
                eventModel.FilledAppintmentSlots = filledSlotCountPair == null ? 0 : filledSlotCountPair.SecondValue;

                eventModels.Add(eventModel);
            }

            return eventModels;
        }

        public EventStaffAssignmentListModel GetEventStaff(EventStaffAssignmentListModelFilter filter, bool isForExport = false)
        {
            var staffAssignments = new List<EventStaffAssignmentViewModel>();
            var events = GetEventBasicInfoFor(filter, isForExport);

            if (events != null && events.Any())
            {
                var eventIds = events.Select(x => x.Id).ToArray();
                var eventStaffAssignments = _eventStaffAssignmentRepository.GetForEvents(eventIds);
                var eventRoles = _eventRoleRepository.GetAll();
                var podIds = events.SelectMany(e => e.Pods.Select(x => x.FirstValue)).Distinct().ToArray();
                var podsStaffs = _podStaffAssignmentRepository.GetPodStaffforMultiplePods(podIds);
                foreach (var eventBasicInfoViewModel in events)
                {
                    bool isDefault;
                    var theEventStaffAssignments = eventStaffAssignments.Where(x => x.EventId == eventBasicInfoViewModel.Id).Select(x => x).ToArray();
                    var eventStaff = _eventStaffAssignmentService.GetEventStaffBasicInfoModel(eventBasicInfoViewModel.Id, eventBasicInfoViewModel.Pods, theEventStaffAssignments, eventRoles, podsStaffs, out isDefault);

                    staffAssignments.Add(new EventStaffAssignmentViewModel
                    {
                        Event = eventBasicInfoViewModel,
                        AssignedStaff = eventStaff,
                        IsDefaultStaffAssignment = isDefault
                    });
                }
            }

            var staffScheduleEditModel = new EventStaffAssignmentListModel
            {
                Filter = filter,
                StaffEventAssignments = staffAssignments
            };
            return staffScheduleEditModel;
        }

        public EventStaffAssignmentEditModel GetEventStaff(long eventId)
        {

            var theEvent = GetEventBasicInfoFor(eventId);
            var eventStaffAssignments = _eventStaffAssignmentRepository.GetForEvent(eventId);
            var eventRoles = _eventRoleRepository.GetAll();
            var podIds = theEvent.Pods.Select(x => x.FirstValue).Distinct().ToArray();
            var podsStaffs = _podStaffAssignmentRepository.GetPodStaffforMultiplePods(podIds);
            bool isDefault;
            var eventStaff = _eventStaffAssignmentService.GetEventStaffBasicInfoModel(theEvent.Id, theEvent.Pods, eventStaffAssignments, eventRoles, podsStaffs, out isDefault);

            return new EventStaffAssignmentEditModel
            {
                Event = theEvent,
                EventStaffAssignements = eventStaff,
                IsDefaultStaffAssignment = isDefault
            };
        }

        public EventSummaryViewModel GetEventSummary(long eventId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var host = _hostRepository.GetHostForEvent(eventId);
            var eventIds = new[] { eventData.Id };
            var totalCustomers = _eventRepository.GetTotalRegistration(eventIds);
            var screenedCustomers = _eventRepository.GetAttendedCustomers(eventIds);
            var noShowCustomers = _eventRepository.GetNoShowCustomers(eventIds);
            var cancelledCustomers = _eventRepository.GetCancelledCustomers(eventIds);

            var model = new EventSummaryViewModel
                            {
                                EventId = eventData.Id,
                                EventDate = eventData.EventDate,
                                HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address),
                                TotalCustomers = totalCustomers.First().SecondValue,
                                ScreenedCustomers = screenedCustomers.First().SecondValue,
                                NoShowCustomers = noShowCustomers.First().SecondValue,
                                CancelledCustomers = cancelledCustomers.First().SecondValue
                            };
            return model;
        }

        public ListModelBase<CorporateAccountEventViewModel, CorporateAccountEventListModelFilter> GetCorporateAccountEvents(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetEventsForCorporateAccount(pageNumber, pageSize, filter as CorporateAccountEventListModelFilter, out totalRecords);
            var hosts = _hostRepository.GetEventHosts(events.Select(e => e.Id).ToArray());

            var customersAttended = _eventRepository.GetAttendedCustomers(events.Select(e => e.Id).ToArray());

            var normalCustomers = _eventCustomerResultRepository.GetResultSummaryIEventIdCustomersCountForEventIds(events.Select(e => e.Id).ToArray(), ResultInterpretation.Normal);

            var criticalCustomers = _eventCustomerResultRepository.GetResultSummaryIEventIdCustomersCountForEventIds(events.Select(e => e.Id).ToArray(), ResultInterpretation.Critical);

            var abnormalCustomers = _eventCustomerResultRepository.GetResultSummaryIEventIdCustomersCountForEventIds(events.Select(e => e.Id).ToArray(), ResultInterpretation.Abnormal);

            var model = new CorporateAccountEventListModel();
            model.Collection = _corporateAccountEventListFactory.Create(events, hosts, customersAttended, normalCustomers, criticalCustomers, abnormalCustomers);
            return model;
        }

        public EventCustomerListModel GetEventInfoforEventCustomerListModel(long eventId, CorporateAccount account)
        {
            var theEvent = _eventRepository.GetEventWithEventTypeAndHostEventById(eventId);
            var host = _hostRepository.GetHostForEvent(eventId);
            var pods = _podRepository.GetPodsForEvent(eventId);
            var hostFacility = _hostFacilityRankingService.GetHostFacilityRankingByHSC(host.Id);
            bool isDefault;
            var eventStaffAssignments = _eventStaffAssignmentRepository.GetForEvent(eventId);
            var eventRoles = _eventRoleRepository.GetAll();
            var podsStaffs = _podStaffAssignmentRepository.GetPodStaffforMultiplePods(pods.Select(x => x.Id));
            var staff = _eventStaffAssignmentService.GetEventStaffBasicInfoModel(eventId, pods.Select(p => new OrderedPair<long, string>(p.Id, p.Name)), eventStaffAssignments, eventRoles, podsStaffs, out isDefault);
            var emrNotes = _eventRepository.GetEmrNotes(eventId);

            var sponsor = string.Empty;
            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);

            if (hospitalPartnerId > 0)
            {
                sponsor = _organizationRepository.GetOrganizationbyId(hospitalPartnerId).Name;
            }
            else if (theEvent.AccountId.HasValue && theEvent.AccountId.Value > 0)
            {
                sponsor = _organizationRepository.GetOrganizationbyId(theEvent.AccountId.Value).Name;
            }

            var eventNotes = _eventNoteRepository.GetByEventIds(new[] { eventId });
            var note = string.Join("\n", eventNotes.Where(x => x.IsPublished).Select(x => x.Note));
            var showCheckListForm = false;
            if (theEvent.EventDate < _settings.ChecklistChangeDate)
                showCheckListForm = (account != null && account.PrintCheckList);
            var model = new EventCustomerListModel
                            {
                                AddressVerifiedBy = host.Address.VerificationOrgRoleUserId.HasValue ? _organizationRoleUserRepository.GetNameIdPairofUsers(new[] { host.Address.VerificationOrgRoleUserId.Value }).Single().SecondValue : "",
                                EventDate = theEvent.EventDate,
                                EventId = theEvent.Id,
                                EventStaff = staff,
                                HostAddress = host.Address,
                                HostContact = (((host.OfficePhoneNumber ?? host.MobilePhoneNumber) ?? host.OtherPhoneNumber) ?? new PhoneNumber()).ToString(),
                                HostFacility = hostFacility,
                                HostId = host.Id,
                                HostName = host.OrganizationName,
                                Pods = pods,
                                EmrNotes = emrNotes != null ? emrNotes.ToString() : "",
                                TechnicianNotes = !string.IsNullOrEmpty(theEvent.TechnicianNotes) ? theEvent.TechnicianNotes + "\n" + note : note,
                                AssignedToUserName = _organizationRoleUserRepository.GetNameIdPairofUsers(new[] { theEvent.AssignedtoOrgRoleUserId }).Single().SecondValue,
                                IsDynamicScheduling = theEvent.IsDynamicScheduling,
                                EventType = theEvent.EventType,
                                CaptureInsuranceId = theEvent.CaptureInsuranceId,
                                Sponsor = sponsor,
                                HospitalFacilities = _hospitalFacilityRepository.GetByEventId(eventId),
                                IsKynIntegrationEnabled = _eventPodRepository.IsKynIntegrationEnabled(eventId),
                                IsHospitalPartnerEvent = hospitalPartnerId > 0,
                                CaptureAbnStatus = account != null && account.CaptureAbnStatus,
                                CapturePcpStatus = account != null && account.CapturePcpConsent,
                                IsBloodworkFormAttached = _eventPodRepository.IsBloodworkFormAttached(eventId),
                                CaptureHaf = (account == null || account.CaptureHaf),
                                BloodPackageTracking = theEvent.BloodPackageTracking,
                                RecordsPackageTracking = theEvent.RecordsPackageTracking,
                                BookPcpAppointment = (account != null && account.BookPcpAppointment),
                                PrintScreeningInfo = (account == null || account.ScreeningInfo),
                                PrintPatientWorkSheet = (account == null || account.PatientWorkSheet),
                                ShowBarrier = (account == null || account.ShowBarrier),
                                ShowCheckListForm = showCheckListForm,
                                ShowIFOBTForm = (account != null && account.PrintIFOBTForm),
                                ShowMicroalbuminForm = (account != null && account.PrintMicroalbuminForm),
                                ShowChaperonForm = (account != null && account.ShowChaperonForm)
                            };

            return model;
        }

        public IEnumerable<Event> GetEventsByCustomerId(long customerId)
        {
            var eventCustomers = _eventCustomerRepository.GetbyCustomerId(customerId);
            if (!eventCustomers.IsNullOrEmpty())
            {
                var eventIds = eventCustomers.Where(ec => ec.AppointmentId.HasValue && ec.AppointmentId.Value > 0).Select(ec => ec.EventId).ToArray();
                var events = _eventRepository.GetEventswithPodbyIds(eventIds);
                return events;
            }
            return null;
        }

        public EventCdContentStatusViewModel GetEventCdContentStatus(long eventId)
        {
            var eventCustomers = _eventCustomerRepository.GetEventCustomersWithCdPurchaseByEventId(eventId);
            if (eventCustomers.IsNullOrEmpty())
                return null;
            var eventCustomerIds = eventCustomers.Select(ec => ec.Id).ToArray();
            var eventCustomerResults = _eventCustomerResultRepository.GetByIds(eventCustomerIds);
            var cdContentTrackingList = _cdContentGenerator.GetCdContentGeneratedforEventCustomerIds(eventCustomerIds);

            var totalCdPurchased = eventCustomers.Count();
            var cdContentGenerated = cdContentTrackingList.Count();
            var inQueue = eventCustomerResults.Where(ecr => ecr.IsClinicalFormGenerated && ecr.IsResultPdfGenerated && !cdContentTrackingList.Select(cct => cct.EventCustomerResultId).Contains(ecr.Id)).Count();

            return new EventCdContentStatusViewModel()
                       {
                           EventId = eventId,
                           Generated = cdContentGenerated,
                           InQueue = inQueue,
                           ResultNotGenerated = totalCdPurchased - cdContentGenerated - inQueue
                       };
        }

        public EventCustomerBrifListModel GetEventCustomerBrifListModel(long eventId)
        {
            var theEvent = _eventRepository.GetById(eventId);

            var account = _corporateAccountRepository.GetbyEventId(eventId);
            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);

            var model = new EventCustomerBrifListModel
            {
                EventDate = theEvent.EventDate,
                EventId = theEvent.Id,
                CapturePcpConsent = account != null && account.CapturePcpConsent,
                IsHospitalPartnerEvent = hospitalPartnerId > 0,
                EventType = theEvent.EventType,
                CaptureAbnStatus = account != null && account.CaptureAbnStatus
            };

            return model;
        }

        public IEnumerable<ShortEventInfoViewModel> GetEventBasicInfoForStaff(EventSearchModelFilter filter)
        {
            var events = _eventRepository.GetEventsForStaff(filter);

            if (events == null || !events.Any()) return null;

            return GetShortEventInfoList(events);
        }

        private EventBasicInfoListModel EventBasicInfoListModel(IEnumerable<Event> events)
        {
            var eventIds = events.Select(e => e.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            var assignedToIds = events.Select(e => e.AssignedtoOrgRoleUserId).Distinct();
            var assignedToUsers = _organizationRoleUserRepository.GetNameIdPairofUsers(assignedToIds.ToArray());

            var cdContentGeneratedEventIds = _cdContentGenerator.GetCdContentGeneratedEventIds(eventIds);
            var resultPacketGeneratedEventIds = _eventCustomerResultRepository.GetClinicalFormGeneratedEventIds(eventIds);

            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);


            var organizationIds = new List<long>();
            if (eventHpPairs != null && eventHpPairs.Any())
                organizationIds.AddRange(eventHpPairs.Select(o => o.SecondValue).ToArray());

            organizationIds.AddRange(
                events.Where(e => e.AccountId.HasValue && e.AccountId.Value > 0).Select(e => e.AccountId.Value).ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.Distinct().ToArray());

            var eventModels = new List<EventBasicInfoViewModel>();

            var corporateAccounts = _corporateAccountRepository.GetByIds(organizationIds.Distinct().ToArray());

            foreach (var @event in events) // Should go inside a mapper
            {

                var eventModel = _eventBasicInfoListHelper.EventBasicInfoViewModel(hosts, @event, pods, eventAppointmentStatsModels, eventHpPairs, organizations);
                //var eventModel = new EventBasicInfoViewModel();
                //var host = hosts.Where(h => h.Id == @event.HostId).First();
                //eventModel = Mapper.Map<Event, EventBasicInfoViewModel>(@event);
                //eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
                //eventModel.HostName = host.OrganizationName;
                //eventModel.Pods = pods != null
                //    ? pods.Where(p => @event.PodIds.Contains(p.Id)).Select(
                //        p => new OrderedPair<long, string>(p.Id, p.Name)).ToArray()
                //    : null;

                //var eventAppointmentStatsModel =
                //    eventAppointmentStatsModels.Where(easm => easm.EventId == @event.Id).Select(easm => easm).Single();

                //eventModel.TotalAppointmentSlots = eventAppointmentStatsModel.TotalSlots -
                //                                   eventAppointmentStatsModel.BlockedSlots;

                //eventModel.FilledAppintmentSlots = eventAppointmentStatsModel.BookedSlots;

                //eventModel.IsDynamicScheduling = eventAppointmentStatsModel.IsDynamicScheduling;

                var assignedToFullName =
                    assignedToUsers.FirstOrDefault(u => u.FirstValue == @event.AssignedtoOrgRoleUserId);
                eventModel.AssignedtoFullName = assignedToFullName != null ? assignedToFullName.SecondValue : "Not Assigned!";

                eventModel.IsCdContentGenerated = cdContentGeneratedEventIds.Contains(@event.Id);
                eventModel.IsResultPacketGenetated = resultPacketGeneratedEventIds.Contains(@event.Id);
                eventModel.GenerateHealthAssesmentForm = @event.GenerateHealthAssesmentForm;
                //var sponsor = string.Empty;
                //if (eventHpPairs != null && eventHpPairs.Any())
                //{
                //    var hospitalPartnerId =
                //        eventHpPairs.Where(o => o.FirstValue == @event.Id).Select(o => o.SecondValue).FirstOrDefault();
                //    if (hospitalPartnerId > 0)
                //        sponsor = organizations.Where(o => o.Id == hospitalPartnerId).Select(o => o.Name).First();
                //}

                //if (string.IsNullOrEmpty(sponsor))
                //{
                //    if (@event.AccountId.HasValue && @event.AccountId.Value > 0)
                //        sponsor = organizations.Where(o => o.Id == @event.AccountId.Value).Select(o => o.Name).First();
                //}

                //eventModel.Sponsor = sponsor;
                eventModel.CaptureHealthAssessmentForm = true;

                if (!corporateAccounts.IsNullOrEmpty() && @event.AccountId.HasValue)
                {
                    var account = corporateAccounts.FirstOrDefault(x => x.Id == @event.AccountId.Value);

                    if (account != null)
                    {
                        eventModel.CaptureHealthAssessmentForm = account.CaptureHaf;
                        eventModel.IsSmsEnabled = account.EnableSms && @event.EventDate >= DateTime.Today && @event.Status == EventStatus.Active && eventModel.BookedSlots > 0;
                    }

                    eventModel.GenerateBatchLabel = account != null && account.GenerateBatchLabel;
                }



                eventModels.Add(eventModel);
            }
            return new EventBasicInfoListModel() { Events = eventModels };
        }

        public IEnumerable<EventBasicInfoViewModel> GetEventBasicInfoEventIds(IEnumerable<long> eventIds)
        {
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventModels = new List<EventBasicInfoViewModel>();

            foreach (var eventData in events)
            {
                var eventModel = new EventBasicInfoViewModel();
                var host = hosts.First(h => h.Id == eventData.HostId);
                eventModel = Mapper.Map<Event, EventBasicInfoViewModel>(eventData);
                eventModel.HostAddress = Mapper.Map<Address, AddressViewModel>(host.Address);
                eventModel.HostName = host.OrganizationName;
                eventModel.Pods = pods != null
                    ? pods.Where(p => eventData.PodIds.Contains(p.Id)).Select(
                        p => new OrderedPair<long, string>(p.Id, p.Name)).ToArray()
                    : null;

                eventModels.Add(eventModel);
            }

            return eventModels;
        }

        public EventBasicInfoListModel GetEventBasicInfoForCallQueue(FillEventsCallQueueFilter filter, int pageSize, out int totalRecords)
        {
            var criteria = _fillEventsQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(filter.CallQueueId, filter.AssignedToOrgRoleUserId);
            if (criteria != null && criteria.IsQueueGenerated == false)
                throw new Exception("Please wait for 10 minutes(max) after you have changed the criteria so that the queue is regenerated.");
            var events = _eventRepository.GetEventsForCallQueue(filter, criteria.Id);

            if (events == null || !events.Any())
            {
                totalRecords = 0;
                return null;
            }

            var endDate = DateTime.Today.AddDays(criteria.NoOfDays);

            events = events.Where(x => x.EventDate.Date <= endDate.Date);

            events = _fillEventsCallQueueHelper.GetAllTheEventFilledUnderPecentage(events, criteria.Percentage);
            totalRecords = events.Count();
            events = events.OrderBy(ev => ev.EventDate).Skip((filter.PageNumber - 1) * pageSize).Take(pageSize);

            return _eventBasicInfoListHelper.EventBasicInfoListForCallQueue(events);
        }

        public IEnumerable<EventHostViewData> SearchEventForCallCenter(EventSearchFilterCallQueueCustomer filter, out int totalCount)
        {
            ZipCode originalZipCode = null;
            if (!string.IsNullOrWhiteSpace(filter.CustomerZipCode))
            {
                try
                {
                    originalZipCode = _zipCodeRepository.GetZipCode(filter.CustomerZipCode).FirstOrDefault();
                }
                catch (ObjectNotFoundInPersistenceException<ZipCode>)
                {
                    totalCount = 0;
                    return null;
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.ZipCode) && filter.Radius > 0)
            {
                try
                {
                    var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                    if (zipCode != null)
                        filter.ZipCodeId = zipCode.Id;
                }
                catch (ObjectNotFoundInPersistenceException<ZipCode>)
                {
                    totalCount = 0;
                    return null;
                }
            }

            filter.Radius = filter.Radius.HasValue && filter.Radius.Value == 0 ? null : filter.Radius;
            var events = _eventRepository.GetEventsByFiltersForCallQueue(filter);

            var pods = _podRepository.GetPodsForEvents(events.Select(e => e.Id).ToArray());
            var eventAppointmentStatsModels = _eventAppointmentStatsService.GetStats(events);
            var zipRadiusDistance = originalZipCode == null ? null : _zipRadiusDistanceRepository.GetBySourceZipId(originalZipCode.Id);
            var eventHostViewDatas = _eventHostViewDataFactory.Create(events, pods, originalZipCode, eventAppointmentStatsModels, zipRadiusDistances: zipRadiusDistance)
                .Where(x => x.AvailableAppointmentSlots > 0 || (x.IsDynamicScheduling.HasValue && x.IsDynamicScheduling.Value)).ToList();

            totalCount = eventHostViewDatas.Count();

            return OrderEventHostViewDataPageWise(eventHostViewDatas, filter.PageNumber, filter.PageSize, filter.ToBeFilledEventId, filter.SortByOrder, filter.SortOrderType);
        }

        private IEnumerable<EventHostViewData> OrderEventHostViewDataPageWise(List<EventHostViewData> eventHostViewDatas, int pageNumber, int pageSize, long tobeFilledEventId, CallQueueSortOrderBy sortOrderBy, SortOrderType sortOrderType)
        {
            var eventHostViewDatasPage = eventHostViewDatas;
            if (sortOrderBy == CallQueueSortOrderBy.Distance)
            {
                if (sortOrderType == SortOrderType.Ascending)
                {
                    eventHostViewDatasPage =
                        eventHostViewDatas.GroupBy(e => e.DistanceFromZip)
                            .OrderBy(group => group.Key)
                            .Select(group => group.OrderBy(g => g.EventDate).ThenBy(x => x.AvailableAppointmentSlots).ThenBy(x => x.Name).Select(g => g))
                            .SelectMany(g => g).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                    //logic to reorder the tobefilledEventId to top position
                    if (tobeFilledEventId == 0)
                        return eventHostViewDatasPage;

                    var preferedEvent = eventHostViewDatas.FirstOrDefault(x => x.EventId == tobeFilledEventId);
                    if (preferedEvent == null)
                        return eventHostViewDatasPage;

                    /*var existingInReturningPage =
                        eventHostViewDatasPage.FirstOrDefault(x => x.EventId == tobeFilledEventId);

                    if (existingInReturningPage != null)
                    {
                        var eventHostViewDatasPage1 = new List<EventHostViewData> { preferedEvent };

                        var restEventsInPage1 = eventHostViewDatasPage.Where(x => x.EventId != tobeFilledEventId);
                        eventHostViewDatasPage1.AddRange(restEventsInPage1);
                        return eventHostViewDatasPage1;
                    }*/

                    eventHostViewDatasPage = new List<EventHostViewData> { preferedEvent };
                    var restEventsInPage = eventHostViewDatas.Where(x => x.EventId != tobeFilledEventId)
                        .GroupBy(e => e.DistanceFromZip).OrderBy(group => @group.Key).Select(
                            group => @group.OrderBy(g => g.EventDate).ThenBy(x => x.AvailableAppointmentSlots).ThenBy(x => x.Name).Select(g => g))
                            .SelectMany(g => g).ToList();
                    eventHostViewDatasPage.AddRange(restEventsInPage);
                }
                else
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.DistanceFromZip)
                           .OrderByDescending(group => group.Key)
                           .Select(group => group.OrderByDescending(g => g.EventDate).ThenByDescending(x => x.AvailableAppointmentSlots).ThenByDescending(x => x.Name).Select(g => g))
                           .SelectMany(g => g).ToList();
                }
            }
            else if (sortOrderBy == CallQueueSortOrderBy.EventDate)
            {
                if (sortOrderType == SortOrderType.Ascending)
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.EventDate)
                        .OrderBy(group => @group.Key)
                        .Select(group => @group.OrderBy(g => g.DistanceFromZip).ThenBy(x => x.AvailableAppointmentSlots).ThenBy(x => x.Name).Select(g => g))
                        .SelectMany(g => g)
                        .ToList();
                }
                else
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.EventDate)
                        .OrderByDescending(group => @group.Key)
                        .Select(group => @group.OrderByDescending(g => g.DistanceFromZip).ThenByDescending(x => x.AvailableAppointmentSlots).ThenByDescending(x => x.Name).Select(g => g))
                        .SelectMany(g => g)
                        .ToList();
                }

            }
            else if (sortOrderBy == CallQueueSortOrderBy.EventName)
            {
                if (sortOrderType == SortOrderType.Ascending)
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.Name)
                        .OrderBy(group => @group.Key)
                        .Select(group => @group.OrderBy(g => g.DistanceFromZip).ThenBy(x => x.EventDate).ThenBy(x => x.AvailableAppointmentSlots).Select(g => g))
                        .SelectMany(g => g)
                        .ToList();
                }
                else
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.Name)
                    .OrderByDescending(group => @group.Key)
                    .Select(group => @group.OrderByDescending(g => g.DistanceFromZip).ThenByDescending(x => x.EventDate).ThenByDescending(x => x.AvailableAppointmentSlots).Select(g => g))
                    .SelectMany(g => g)
                    .ToList();
                }

            }
            else if (sortOrderBy == CallQueueSortOrderBy.AvailableAppointmentSlots)
            {
                if (sortOrderType == SortOrderType.Ascending)
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.AvailableAppointmentSlots)
                        .OrderBy(group => @group.Key)
                        .Select(group => @group.OrderBy(g => g.DistanceFromZip).ThenBy(x => x.EventDate).ThenBy(x => x.Name).Select(g => g))
                        .SelectMany(g => g)
                        .ToList();
                }
                else
                {
                    eventHostViewDatasPage = eventHostViewDatas.GroupBy(e => e.AvailableAppointmentSlots)
                    .OrderByDescending(group => @group.Key)
                    .Select(group => @group.OrderByDescending(g => g.DistanceFromZip).ThenByDescending(x => x.EventDate).ThenByDescending(x => x.Name).Select(g => g))
                    .SelectMany(g => g)
                    .ToList();
                }
            }

            return eventHostViewDatasPage.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public ListModelBase<HealthPlanEventViewModel, EventBasicInfoViewModelFilter> GetHealthPlanEvents(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new EventBasicInfoViewModelFilter();

            var events = _eventRepository.GetEventsbyFilters(filter as EventBasicInfoViewModelFilter, pageNumber, pageSize, out totalRecords);

            var eventList = HealthPlanEvents(events);

            var eventIds = events.Select(x => x.Id).ToArray();

            var eventCustomerList = _eventCustomerRepository.GetByEventIds(eventIds);
            var appointmentIds = eventCustomerList.Select(x => x.AppointmentId != null ? x.AppointmentId.Value : 0).Distinct().ToArray();

            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            foreach (var eventBasicInfoViewModel in eventList)
            {
                var eventCustomers = eventCustomerList.Where(x => x.EventId == eventBasicInfoViewModel.Id);
                var eventAppointments = appointments.Where(x => eventCustomers.Select(ec => ec.AppointmentId).Contains(x.Id));
                eventBasicInfoViewModel.ScreenedCustomers = eventAppointments.Count(x => x.CheckInTime.HasValue && x.CheckOutTime.HasValue);
            }

            return new HealthPlanEventListModel
            {
                Collection = eventList
            };
        }

        private IEnumerable<HealthPlanEventViewModel> HealthPlanEvents(IEnumerable<Event> events)
        {
            var eventIds = events.Select(e => e.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);

            var organizationIds = new List<long>();
            if (eventHpPairs != null && eventHpPairs.Any())
                organizationIds.AddRange(eventHpPairs.Select(o => o.SecondValue).ToArray());

            organizationIds.AddRange(events.Where(e => e.AccountId.HasValue && e.AccountId.Value > 0).Select(e => e.AccountId.Value).ToArray());

            return events.Select(@event => _eventBasicInfoListHelper.HealthPlanEventViewModel(hosts, @event, pods, eventAppointmentStatsModels)).ToList();
        }

        public AddNotesListModel GetEventForAddNotes(AddNotesModelFilter filter, long eventNoteId)
        {
            var id = eventNoteId > 0 ? eventNoteId : filter != null ? filter.Id : 0;
            var eventNote = id > 0 ? _eventNoteRepository.GetById(id) : null;
            filter = (eventNoteId > 0 && eventNote != null) ? new AddNotesModelFilter
            {
                Id = id,
                HealthPlanId = eventNote.HealthPlanId.HasValue ? eventNote.HealthPlanId.Value : 0,
                EventDateFrom = eventNote.EventDateFrom < DateTime.Today.AddDays(1) ? DateTime.Today.AddDays(1) : eventNote.EventDateFrom,
                EventDateTo = eventNote.EventDateTo < DateTime.Today.AddDays(1) ? DateTime.Today.AddDays(1) : eventNote.EventDateTo,
                PodId = eventNote.PodId.HasValue ? eventNote.PodId.Value : 0
            } : filter;


            var eventIds = _eventRepository.GetForAddNotes(filter);

            if (!eventIds.Any()) return null;

            var events = GetEventBasicInfoEventIds(eventIds).OrderBy(x => x.EventDate);

            var eventNotesLogs = id > 0 ? _eventNoteRepository.GetEventNoteLogByIds(new[] { id }) : null;

            var eventIdCorporateAccountNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var model = _addEventNoteFactory.Create(events, eventNote, eventNotesLogs, eventIdCorporateAccountNamePairs);

            model.Filter = filter;

            return model;
        }

        public AddNotesListModel SaveEventNotes(AddNotesListModel model, long createdBy)
        {
            var eventNote = model.Filter.Id > 0 ? _eventNoteRepository.GetById(model.Filter.Id) : null;
            if (eventNote == null)
            {
                eventNote = new EventNote
                {
                    DateCreated = DateTime.Now,
                    CreatedBy = createdBy
                };
            }
            else
            {
                eventNote.DateModified = DateTime.Now;
                eventNote.ModifiedBy = createdBy;
            }
            eventNote.Note = model.Note;
            eventNote.IsPublished = model.IsPublish;
            eventNote.HealthPlanId = model.Filter.HealthPlanId > 0 ? model.Filter.HealthPlanId : (long?)null;
            eventNote.EventDateFrom = model.Filter.EventDateFrom;
            eventNote.EventDateTo = model.Filter.EventDateTo;
            eventNote.PodId = model.Filter.PodId > 0 ? model.Filter.PodId : (long?)null;

            eventNote = _eventNoteRepository.Save(eventNote);
            _eventNoteRepository.DeleteEventNotesLog(eventNote.Id);

            var eventIds = model.EventIds.Split(',').Select(x => Convert.ToInt64(x.Trim()));

            foreach (var eventId in eventIds)
            {
                _eventNoteRepository.SaveEventNotesLog(new EventNotesLog { EventNoteId = eventNote.Id, EventId = eventId });
            }

            return model;
        }

        public ListModelBase<EventNotesViewModel, EventNotesModelFilter> GetEventNotes(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new EventNotesModelFilter();

            var eventNotes = _eventNoteRepository.GetEventNotes(pageNumber, pageSize, filter as EventNotesModelFilter, out totalRecords);
            if (!eventNotes.Any()) return null;

            var eventNoteIds = eventNotes.Select(x => x.Id).ToArray();
            var eventNotesLogs = _eventNoteRepository.GetEventNoteLogByIds(eventNoteIds);

            var orgRoleUserIds = eventNotes.Select(x => x.CreatedBy).ToArray();
            var modifiedByIds = eventNotes.Where(x => x.ModifiedBy.HasValue).Select(x => x.ModifiedBy.Value);
            orgRoleUserIds = orgRoleUserIds.Concat(modifiedByIds).Distinct().ToArray();

            var organizationRoleUsers = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            return _addEventNoteFactory.CreateListModel(eventNotes, eventNotesLogs, organizationRoleUsers);
        }

        public MapEventListModel GetActiveEvents(EventsDateRangeType duration)
        {
            var events = _eventRepository.GetActiveEvents(duration).ToArray();
            if (!events.Any()) return null;

            var basicEventInfo = EventBasicInfoListModel(events).Events.ToArray();

            var zipCodelist = basicEventInfo.Select(x => x.HostAddress.ZipCode).ToList();

            var zipCodes = _zipCodeRepository.GetAllExistingZipCodes(zipCodelist).ToArray();

            var accountIds = events.Where(x => x.AccountId.HasValue).Select(x => x.AccountId.Value).ToArray();

            var corporateAccounts = _corporateAccountRepository.GetByIds(accountIds);

            return _mapEventListModelFactory.Create(events, basicEventInfo, zipCodes, corporateAccounts);
        }

        public void SaveCustomEventNotification(CustomEventNotificationEditModel model, CorporateAccount account, long createdBy)
        {
            var domain = new CustomEventNotification
            {
                EventId = model.EventId,
                AccountId = account.Id,
                Body = model.Message,
                CreatedDate = DateTime.Now,
                CreatedBy = createdBy,
                ServiceStatus = (long)CustomNotificationServiceStatus.Unserviced
            };

            _customEventNotificationRepository.SaveNotification(domain);
        }

        public IEnumerable<ShortEventInfoViewModel> GetShortEventInfoList(IEnumerable<Event> events)
        {
            var eventIds = events.Select(e => e.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);


            var organizationIds = new List<long>();
            if (eventHpPairs != null && eventHpPairs.Any())
                organizationIds.AddRange(eventHpPairs.Select(o => o.SecondValue).ToArray());

            organizationIds.AddRange(events.Where(e => e.AccountId.HasValue && e.AccountId.Value > 0).Select(e => e.AccountId.Value).ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.Distinct().ToArray());

            var eventModels = new List<ShortEventInfoViewModel>();

            var corporateAccounts = _corporateAccountRepository.GetByIds(organizationIds.Distinct().ToArray());

            var eventCustomers = _eventCustomerRepository.GetByEventIds(eventIds);

            var appointmentIds = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.AppointmentId.Value);
            var appointments = _appointmentRepository.GetByIds(appointmentIds);

            var checkInAppointmentIds = appointments.Where(x => x.CheckInTime.HasValue).Select(x => x.Id);

            foreach (var @event in events) // Should go inside a mapper
            {

                var eventModel = _eventBasicInfoListHelper.ShortEventInfoViewModel(hosts, @event, pods, eventAppointmentStatsModels, eventHpPairs, organizations);

                eventModel.GenerateHealthAssesmentForm = @event.GenerateHealthAssesmentForm;

                eventModel.CaptureHealthAssessmentForm = true;

                if (!corporateAccounts.IsNullOrEmpty() && @event.AccountId.HasValue)
                {
                    var account = corporateAccounts.FirstOrDefault(x => x.Id == @event.AccountId.Value);

                    var eventTests = _eventTestRepository.GetTestsForEvent(@event.Id);
                    bool isFlushotTestAttachedWithEvent = eventTests.Any(x => TestGroup.FluShotTestIds.Contains(x.TestId));

                    if (account != null)
                    {
                        eventModel.CaptureHealthAssessmentForm = account.CaptureHaf;
                        eventModel.ShowGiftCard = account.AttachGiftCard;
                        eventModel.GiftCardAmount = account.GiftCardAmount.HasValue ? account.GiftCardAmount.Value : 0;
                        eventModel.ShowMatrixConsent = account.AttachParicipantConsentForm;
                        eventModel.ShowFluVaccineConsent = isFlushotTestAttachedWithEvent && account.GenerateFluPneuConsentForm;
                        eventModel.ShowSurvey = account.CaptureSurvey;
                        eventModel.ShowChaperoneConsent = account.ShowChaperonForm;
                        eventModel.ShowPcpConsent = account.CapturePcpConsent;
                    }
                    else
                    {
                        eventModel.ShowFluVaccineConsent = isFlushotTestAttachedWithEvent;
                    }
                }

                eventModel.HipaaSignedCount = eventCustomers.Count(x => x.EventId == @event.Id && x.HIPAAStatus == RegulatoryState.Signed
                                              && x.AppointmentId.HasValue && checkInAppointmentIds.Contains(x.AppointmentId.Value));

                eventModel.HipaaUnSignedCount = eventCustomers.Count(x => x.EventId == @event.Id && x.HIPAAStatus == RegulatoryState.Not_Signed
                                              && x.AppointmentId.HasValue && checkInAppointmentIds.Contains(x.AppointmentId.Value));

                eventModels.Add(eventModel);
            }
            return eventModels;
        }

        public ShortEventInfoViewModel GetEventBasicDetailsForStaff(EventSearchModelFilter filter)
        {
            var events = _eventRepository.GetEventsForStaff(filter);

            if (events == null || !events.Any()) return null;

            var eventDetails = GetShortEventInfoList(events).FirstOrDefault();
            return eventDetails;
        }
    }
}
