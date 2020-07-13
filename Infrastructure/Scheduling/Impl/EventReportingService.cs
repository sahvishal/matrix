using System;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Operations;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Users;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventReportingService : IEventReportingService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IPodRepository _podRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventVolumeFactory _eventVolumeFactory;
        private readonly IDetailOpenOrderModelFactory _detailOpenOrderModelFactory;
        private readonly IDailyRecapModelFactory _dailyRecapModelFactory;
        private readonly IPhysicianEventAssignmentRepository _physicianEventAssignmentRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IEventAppointmentStatsService _eventAppointmentStatsService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventCancellationModelFactory _eventCancellationModelFactory;
        private readonly IDailyVolumeFactory _dailyVolumeFactory;
        private readonly IEventAppointmentChangeLogRepository _eventAppointmentChangeLogRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IEventScheduleReportFactory _eventScheduleReportFactory;

        public EventReportingService(IEventRepository eventRepository, IHostRepository hostRepository, IPodRepository podRepository, IEventVolumeFactory eventVolumeFactory,
            IOrderRepository orderRepository, IDetailOpenOrderModelFactory detailOpenOrderModelFactory, IDailyRecapModelFactory dailyRecapModelFactory,
            IPhysicianEventAssignmentRepository physicianEventAssignmentRepository, IHospitalPartnerRepository hospitalPartnerRepository, IOrganizationRepository organizationRepository,
            IEventAppointmentStatsService eventAppointmentStatsService, ICorporateAccountRepository corporateAccountRepository, IEventStaffAssignmentRepository eventStaffAssignmentRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IEventCancellationModelFactory eventCancellationModelFactory, IDailyVolumeFactory dailyVolumeFactory,
            IEventAppointmentChangeLogRepository eventAppointmentChangeLogRepository, IEventTestRepository eventTestRepository, IEventScheduleReportFactory eventScheduleReportFactory)
        {
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _eventVolumeFactory = eventVolumeFactory;
            _podRepository = podRepository;
            _orderRepository = orderRepository;
            _detailOpenOrderModelFactory = detailOpenOrderModelFactory;
            _dailyRecapModelFactory = dailyRecapModelFactory;
            _physicianEventAssignmentRepository = physicianEventAssignmentRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _eventAppointmentStatsService = eventAppointmentStatsService;
            _corporateAccountRepository = corporateAccountRepository;
            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventCancellationModelFactory = eventCancellationModelFactory;
            _dailyVolumeFactory = dailyVolumeFactory;
            _eventAppointmentChangeLogRepository = eventAppointmentChangeLogRepository;
            _eventTestRepository = eventTestRepository;
            _eventScheduleReportFactory = eventScheduleReportFactory;
        }

        public ListModelBase<EventVolumeModel, EventVolumeListModelFilter> GetEventVolumeForPublicPatients(int pageNumber, int pageSize, ModelFilterBase eventVolumeModelFilter, out int totalRecords)
        {
            var events = _eventRepository.GetRetailEvents(pageNumber, pageSize, eventVolumeModelFilter as EventVolumeListModelFilter, out totalRecords);
            return GetEventVolumeModel(events);
        }

        public ListModelBase<EventVolumeModel, EventVolumeListModelFilter> GetEventVolumeForCorporatePatients(int pageNumber, int pageSize, ModelFilterBase eventVolumeModelFilter, out int totalRecords)
        {
            var events = _eventRepository.GetCorporteEvents(pageNumber, pageSize, eventVolumeModelFilter as EventVolumeListModelFilter, out totalRecords);
            return GetEventVolumeModel(events);
        }

        public EventVolumeListModel GetEventVolumeModel(long[] eventIds)
        {
            var events = _eventRepository.GetEventswithPodbyIds(eventIds);
            return GetEventVolumeModel(events);
        }

        //Should this method be part of IEventReportingService.
        private EventVolumeListModel GetEventVolumeModel(IEnumerable<Event> events)
        {
            if (events.IsNullOrEmpty()) return null;
            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events);

            var pods = _podRepository.GetPodsForEvents(eventIds);

            var primaryPhysicians = _physicianEventAssignmentRepository.GetPrimaryPhysicianForEvents(eventIds);
            var overReadPhysicians = _physicianEventAssignmentRepository.GetOverReadPhysicianForEvents(eventIds);

            var eventIdHospitalPartnerIdPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);
            //var eventIdCorporateAccountPairs = _corporateAccountRepository.GetEventIdCorporateAccountPairForSponsoredBy(eventIds);

            var organizationIds = new List<long>();
            organizationIds.AddRange(eventIdHospitalPartnerIdPairs.Select(ehp => ehp.SecondValue).Distinct().ToArray());
            //organizationIds.AddRange(eventIdCorporateAccountPairs.Select(ehp => ehp.SecondValue).Distinct().ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.ToArray());

            var eventIdHospitalPartnerNamePairs = (from ehp in eventIdHospitalPartnerIdPairs
                                                   join org in organizations on ehp.SecondValue equals org.Id
                                                   select new OrderedPair<long, string>(ehp.FirstValue, org.Name)).ToArray();

            var eventIdCorporateNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);

            var eventStaffCollection = _eventStaffAssignmentRepository.GetForEvents(eventIds);

            IEnumerable<OrderedPair<long, string>> staffIdNamePairs = null;

            if (eventStaffCollection != null && eventStaffCollection.Any())
            {
                var orgRoleUserIds = eventStaffCollection.Select(esc => (esc.ActualStaffOrgRoleUserId != null ? esc.ActualStaffOrgRoleUserId.Value : esc.ScheduledStaffOrgRoleUserId)).ToArray();
                staffIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);
            }

            return _eventVolumeFactory.Create(events, hosts, pods, eventAppointmentStatsModels, primaryPhysicians, overReadPhysicians, eventIdHospitalPartnerNamePairs, customersAttended,
                eventIdCorporateNamePairs, eventStaffCollection, staffIdNamePairs);
        }

        public ListModelBase<DetailOpenOrdersModel, DetailOpenOrderModelFilter> GetDetailOpenOrderModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetEventsforDetailOpenOrder(pageNumber, pageSize, filter as DetailOpenOrderModelFilter, out totalRecords);
            if (events.IsNullOrEmpty()) return null;
            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var bookedSlots = _eventRepository.GetBookedAppointmentSlots(eventIds);
            var unservicedAppts = _eventRepository.GetUnServicedAppointments(eventIds);
            var noShowCustomers = _eventRepository.GetNoShowAppointmentsForOpenOrder(eventIds);
            var cancelledCustomers = _eventRepository.GetCancelledAppointmentsForOpenOrder(eventIds);

            var pods = _podRepository.GetPodsForEvents(eventIds);
            var eventIdOpenOrderTotalPairs = _orderRepository.GetOpenOrderTotalForEventIds(eventIds.ToArray());
            var eventIdTotalOutstandingRevenuePairs = _orderRepository.GetOutstandingRevenueForEventIds(eventIds.ToArray());
            var eventIdNoshowOutstandingRevenuePairs = _orderRepository.GetNoshowOutstandingRevenueForEventIds(eventIds.ToArray());
            var eventIdCancelledOutstandingRevenuePairs = _orderRepository.GetCancelledOutstandingRevenueForEventIds(eventIds.ToArray());

            return _detailOpenOrderModelFactory.Create(events, hosts, pods, bookedSlots, unservicedAppts, noShowCustomers, cancelledCustomers, eventIdOpenOrderTotalPairs, eventIdTotalOutstandingRevenuePairs,
                eventIdNoshowOutstandingRevenuePairs, eventIdCancelledOutstandingRevenuePairs);
        }

        public ListModelBase<DailyRecapModel, DailyRecapModelFilter> GetDailyRecapModel(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetEventsForDailyRecap(pageNumber, pageSize, filter as DailyRecapModelFilter,
                                                                out totalRecords);
            if (events.IsNullOrEmpty()) return null;
            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var pods = _podRepository.GetPodsForEvents(eventIds);
            var orderIdAmountPair = _orderRepository.GetOrderSumforEventIds(eventIds.ToArray());

            var totalRegistrations = _eventRepository.GetTotalRegistration(eventIds);
            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);
            var noShowCustomers = _eventRepository.GetNoShowCustomers(eventIds);
            var cancelledCustomers = _eventRepository.GetCancelledCustomers(eventIds);
            var leftWithoutScreeningCustomerCount = _eventRepository.GetLeftWithoutScreeningCustomers(eventIds);

            var totalGcIssued = _eventRepository.GetGcIssuedCountByEventIds(eventIds);

            return _dailyRecapModelFactory.Create(events, hosts, pods, totalRegistrations, customersAttended, noShowCustomers, cancelledCustomers, orderIdAmountPair, leftWithoutScreeningCustomerCount, totalGcIssued);
        }
        public ListModelBase<EventCancellationModel, EventCancellationModelFilter> GetCancelledEventsList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetCancelledEvents(pageNumber, pageSize, filter as EventCancellationModelFilter, out totalRecords);
            if (events == null || !events.Any()) return null;

            return _eventCancellationModelFactory.Create(events);
        }

        public ListModelBase<ClientEventVolumeModel, ClientEventVolumeListModelFilter> GetEventVolumeForHealthPlanPatients(int pageNumber, int pageSize, ModelFilterBase eventVolumeModelFilter, out int totalRecords)
        {
            IEnumerable<Event> events = _eventRepository.GetHealthPlanEvents(pageNumber, pageSize, eventVolumeModelFilter as ClientEventVolumeListModelFilter, out totalRecords);
            return GetClientEventVolumeModel(events);
        }

        private ClientEventVolumeListModel GetClientEventVolumeModel(IEnumerable<Event> events)
        {
            if (events.IsNullOrEmpty()) return null;
            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events);

            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventIdHospitalPartnerIdPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);

            var organizationIds = new List<long>();
            organizationIds.AddRange(eventIdHospitalPartnerIdPairs.Select(ehp => ehp.SecondValue).Distinct().ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.ToArray());

            var eventIdHospitalPartnerNamePairs = (from ehp in eventIdHospitalPartnerIdPairs
                                                   join org in organizations on ehp.SecondValue equals org.Id
                                                   select new OrderedPair<long, string>(ehp.FirstValue, org.Name)).ToArray();

            var eventIdCorporateNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);

            var eventStaffCollection = _eventStaffAssignmentRepository.GetForEvents(eventIds);

            IEnumerable<OrderedPair<long, string>> staffIdNamePairs = null;

            if (eventStaffCollection != null && eventStaffCollection.Any())
            {
                var orgRoleUserIds = eventStaffCollection.Select(esc => (esc.ActualStaffOrgRoleUserId != null ? esc.ActualStaffOrgRoleUserId.Value : esc.ScheduledStaffOrgRoleUserId)).ToArray();
                staffIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);
            }

            return _eventVolumeFactory.Create(events, hosts, pods, eventAppointmentStatsModels, eventIdHospitalPartnerNamePairs, customersAttended, eventIdCorporateNamePairs, eventStaffCollection, staffIdNamePairs);
        }

        public ListModelBase<DailyVolumeModel, DailyVolumeListModelFilter> GetDailyVolumeReport(int pageNumber, int pageSize, ModelFilterBase dailyVolumeListModelFilter, out int totalRecords)
        {
            var events = _eventRepository.GetEventsforDailyVolumeReport(pageNumber, pageSize, dailyVolumeListModelFilter as DailyVolumeListModelFilter, out totalRecords);
            return GetDailyVolumeModel(events);
        }

        private DailyVolumeListModel GetDailyVolumeModel(IEnumerable<Event> events)
        {
            if (events.IsNullOrEmpty()) return null;

            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events);

            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventIdCorporateNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var noShowCustomers = _eventRepository.GetNoShowCustomers(eventIds);
            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);

            var cancellationOnDayofEvent = _eventRepository.GetCustomersCancelledOnDayOfEvent(eventIds);

            var movedOutEventCustomerCountPair = _eventAppointmentChangeLogRepository.GetCustomerMovedOutEventOnDayOfEvent(eventIds);

            var leftWithoutScreeningCustomers = _eventRepository.GetLeftWithoutScreeningCustomers(eventIds);

            return _dailyVolumeFactory.Create(events, hosts, pods, eventAppointmentStatsModels, eventIdCorporateNamePairs, noShowCustomers, customersAttended, cancellationOnDayofEvent, movedOutEventCustomerCountPair, leftWithoutScreeningCustomers);
        }

        public ListModelBase<EventListGmsModel, EventListGmsModelFilter> GetEventListForGmsReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var events = _eventRepository.GetActiveHealthPlanEventsForGmsEventList(filter as EventListGmsModelFilter, pageNumber, pageSize, out totalRecords);
            return GetEventListGmsModel(events);
        }

        private EventListGmsListModel GetEventListGmsModel(IEnumerable<Event> eventList)
        {
            if (eventList.IsNullOrEmpty()) return null;

            var listModel = new EventListGmsListModel();
            var dataModel = new List<EventListGmsModel>();
            var eventIds = eventList.Select(x => x.Id);
            var hosts = _hostRepository.GetEventHosts(eventIds);
            var eventIdCorporateNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var eventAppointmentStats = _eventAppointmentStatsService.GetStats(eventList);

            foreach (var @event in eventList)
            {
                var eventListGmsModel = new EventListGmsModel();
                Address eventAddress = new Address();
                var eventId = @event.Id;

                //var slotsForCurrentEvent = eventSchedulingSlots.Where(x => x.EventId == eventId);
                //var availableSlots = slotsForCurrentEvent.Count(x => x.Status != AppointmentStatus.Blocked && x.Status != AppointmentStatus.Booked);

                var appointmentStats = eventAppointmentStats.FirstOrDefault(x => x.EventId == eventId);
                var availableSlots = 0;
                if (appointmentStats == null) continue;

                availableSlots = appointmentStats.FreeSlots;

                var host = hosts.SingleOrDefault(x => x.Id == @event.HostId);

                if (availableSlots == 0)
                {
                    continue;
                }
                if (host == null)
                {
                    continue;
                }
                eventAddress = host.Address;

                eventListGmsModel.EventId = @event.Id;
                eventListGmsModel.EventDate = @event.EventDate.ToString("MM/dd/yyyy");
                eventListGmsModel.HealthPlanName = eventIdCorporateNamePairs.Where(x => x.FirstValue == @event.Id).Select(x => x.SecondValue).Single();
                eventListGmsModel.TotalSlots = appointmentStats.TotalSlots;
                eventListGmsModel.AvailableSlots = availableSlots;

                eventListGmsModel.EventAddressStreet12 = eventAddress.StreetAddressLine1 + "" + eventAddress.StreetAddressLine2;
                eventListGmsModel.EventCity = eventAddress.City;
                eventListGmsModel.EventStateName = eventAddress.State;
                eventListGmsModel.EventZipCode = eventAddress.ZipCode.ToString();
                eventListGmsModel.HostId = host.Id;

                //eventListGmsModel.EventLocation = eventAddress.ToString();
                dataModel.Add(eventListGmsModel);
            }
            listModel.Collection = dataModel;
            return listModel;
        }

        public IEnumerable<EventListGmsModel> GetFutureHealthPlanEvents(long healthPlanId, DateTime today)
        {
            var events = _eventRepository.GetFutureEventsForHealthPlan(healthPlanId, DateTime.Today);
            return GetEventListGmsModel(events).Collection;
        }

        public EventScheduleListModel GetEventScheduleReport(int pageNumber, int pageSize, ModelFilterBase eventScheduleListModelFilter, out int totalRecords)
        {

            var filter = eventScheduleListModelFilter as EventScheduleListModelFilter;
            if (filter == null)
            {
                totalRecords = 0;
                return null;

            }

            var events = _eventRepository.GetEventScheduleListModel(pageNumber, pageSize, filter, out totalRecords);
            var eventIds = events.Select(x => x.Id).ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events);

            var pods = _podRepository.GetPodsForEvents(eventIds);
            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);
            var noShowCustomes = _eventRepository.GetNoShowCustomers(eventIds);

            var mammoEnableEventIds = _eventTestRepository.GetMammoEnableEventIds(eventIds);

            return _eventScheduleReportFactory.Create(events, hosts, pods, eventAppointmentStatsModels, customersAttended, noShowCustomes, mammoEnableEventIds);

        }
        
    }

}