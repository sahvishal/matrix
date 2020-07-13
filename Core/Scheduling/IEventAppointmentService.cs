using System;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventAppointmentService
    {
        EventAppointmentListModel GetAppointmentSlotsByEventId(long eventid);
        EventAppointSlotSummaryViewModel GetEventAppointmentSlotSummary(long eventId);
        EventAppointSlotSummaryViewModel GetEventAppointmentSlotSummary(long eventId, bool isDynamicScheduling);
        Appointment CreateAppointment(IEnumerable<long> slotIds, long orgRoleUserId);
        void DeleteAppointment(long appointmentId);
        Appointment AdjustAppointment(long eventCustomerId, int screeningTime, IEnumerable<long> temporaryBookedSlotIds, bool isNewAppointmentSelected = false);
        void SaveChangeAppointmentLog(long eventCustomerId, long oldEventId, long oldAppointmentId, long newEventId, long newAppointmentId, long createdByOrgRoleUserId, long reasonId, string notes, long? subReasonId);
        IEnumerable<OrderedPair<string, DateTime>> GetRoomSlots(IEnumerable<EventSchedulingSlot> slots, Appointment bookedAppointment, IEnumerable<EventPodRoom> eventPodRooms);
    }
}
