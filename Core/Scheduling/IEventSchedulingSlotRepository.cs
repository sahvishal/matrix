using System;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventSchedulingSlotRepository
    {
        EventSchedulingSlot GetbyId(long id);
        IEnumerable<EventSchedulingSlot> GetbyIds(IEnumerable<long> ids);
        IEnumerable<EventSchedulingSlot> GetbyEventIds(IEnumerable<long> eventIds);
        IEnumerable<EventSchedulingSlot> GetbyEventId(long eventId);
        EventSchedulingSlot Save(EventSchedulingSlot slot);
        bool Delete(EventSchedulingSlot slot);

        void ReleaseAllTemporarySlotsPastExpiryTime();
        void ReleaseSlots(IEnumerable<long> ids);
        void ReleaseBookedSlots(IEnumerable<long> ids);
        TimeSpan? GetAppointmentTimeExpirationTime(long id);
        void ExtendTemporarilyBookAppointmentExpiryTime(long id);
        void DeleteByEventId(long eventId);
        void DeleteByEventPodRoomIds(IEnumerable<long> eventPodRoomIds);
        void SaveSlots(IEnumerable<EventSchedulingSlot> slots);
    }
}