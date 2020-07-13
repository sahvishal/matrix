using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class EventAppointmentStatsService : IEventAppointmentStatsService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventSchedulingSlotRepository _slotRepository;
        //  private readonly IEventPodRoomRepository _eventPodRoomRepository;
        //  private readonly IEventPackageRepository _evenePackageRepository;

        public EventAppointmentStatsService(IEventRepository eventRepository, IAppointmentRepository appointmentRepository, IEventSchedulingSlotRepository slotRepository)
        //,IEventPodRoomRepository eventPodRoomRepository,IEventPackageRepository evenePackageRepository)
        {
            _eventRepository = eventRepository;
            _appointmentRepository = appointmentRepository;
            _slotRepository = slotRepository;
            // _eventPodRoomRepository = eventPodRoomRepository;
            //_evenePackageRepository = evenePackageRepository;
        }

        public EventAppointmentStatsModel Get(long eventId)
        {
            var eventData = _eventRepository.GetById(eventId);
            var appointments = _appointmentRepository.GetAllAppointmentsForEvent(eventId);
            var slots = _slotRepository.GetbyEventId(eventId);

            return new EventAppointmentStatsModel()
            {
                EventId = eventData.Id,
                IsDynamicScheduling = eventData.IsDynamicScheduling,
                TotalSlots = slots.Count(),
                FreeSlots = slots.Count(s => s.Status == AppointmentStatus.Free),
                TemporaryBookedSlots = slots.Count(s => s.Status == AppointmentStatus.TemporarilyBooked),
                BlockedSlots = slots.Count(s => s.Status == AppointmentStatus.Blocked),
                BookedSlots = appointments.Count(),
                FilledSlots = slots.Count(s => s.Status == AppointmentStatus.Booked)
            };
        }

        public IEnumerable<EventAppointmentStatsModel> Get(IEnumerable<long> eventIds)
        {
            if (eventIds.IsNullOrEmpty()) return null;

            var events = _eventRepository.GetEventswithPodbyIds(eventIds);

            return GetStats(events);
        }

        public IEnumerable<EventAppointmentStatsModel> GetStats(IEnumerable<Event> events)
        {
            if (events.IsNullOrEmpty()) return null;

            var eventIds = events.Select(e => e.Id).ToArray();
            var appointments = _appointmentRepository.GetAppointmentsForEvents(eventIds);
            var slots = _slotRepository.GetbyEventIds(eventIds);

            return events.Select(eventData => new EventAppointmentStatsModel
            {
                EventId = eventData.Id,
                IsDynamicScheduling = eventData.IsDynamicScheduling,

                TotalSlots = slots.Count(s => s.EventId == eventData.Id),
                FreeSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Free),
                TemporaryBookedSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.TemporarilyBooked),
                BlockedSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Blocked),
                BookedSlots = appointments.Count(a => a.EventId == eventData.Id),
                FilledSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Booked),

                MorningAvailableSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Free && s.StartTime < s.StartTime.Date.AddHours(12)),
                AfternoonAvailableSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Free && s.StartTime >= s.StartTime.Date.AddHours(12) && s.StartTime < s.StartTime.Date.AddHours(16)),
                EveningAvailableSlots = slots.Count(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Free && s.StartTime >= s.StartTime.Date.AddHours(16))

            }).ToList();

        }

        public IEnumerable<EventAppointmentStatsModel> Get(IEnumerable<Event> events)
        {
            if (events.IsNullOrEmpty()) return null;

            var eventIds = events.Select(e => e.Id).ToArray();
            var appointments = _appointmentRepository.GetAppointmentsForEvents(eventIds);
            var slots = _slotRepository.GetbyEventIds(eventIds);

            return events.Select(eventData => new EventAppointmentStatsModel
            {
                EventId = eventData.Id,
                IsDynamicScheduling = eventData.IsDynamicScheduling,
                TotalSlots = slots.Where(s => s.EventId == eventData.Id).Count(),
                FreeSlots = slots.Where(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Free).Count(),
                TemporaryBookedSlots = slots.Where(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.TemporarilyBooked).Count(),
                BlockedSlots = slots.Where(s => s.EventId == eventData.Id && s.Status == AppointmentStatus.Blocked).Count(),
                BookedSlots = appointments.Where(a => a.EventId == eventData.Id).Count(),
                Status = eventData.Status
            }).ToList();

        }

    }
}