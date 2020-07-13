using System;
using System.Collections.Generic;

using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventSchedulingSlotService
    {
        Roles LoggedinUserRole { set; }
        Roles LoggedinUserParentRole { set; }

        IEnumerable<EventSchedulingSlot> GetSlots(long eventId, AppointmentStatus appointmentStatus);

        IEnumerable<SlotSelectionTimeFrameViewModel> GetAvailableTimeFrames(long eventId, int screeningTime, IEnumerable<long> selectedSlotIds, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null);

        IEnumerable<EventSchedulingSlot> GetSlotsforaGivenTimeRange(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, int numberofSlotstoOutput, long packageId, IEnumerable<long> testIds, out int totalSlots);
        IEnumerable<EventSchedulingSlot> GetSlotsforaGivenTimeRange(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null);

        bool IsSlotBooked(IEnumerable<long> ids);

        bool IsSlotTemporarilyBooked(IEnumerable<long> ids);

        EventSchedulingSlot GetHeadSlotintheChain(IEnumerable<long> ids);

        IEnumerable<EventSchedulingSlot> BookSlotTemporarily(long slotId, long screeningTime, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null, bool isChangePackageRequest = false);

        AppointmentSelectionEditModel GetAppointmentSelectionModel(long eventId, int screeningTime, IEnumerable<long> selectedSlotIds, long packageId, IEnumerable<long> testIds, IEnumerable<long> bookedSlotIds = null);

        AppointmentSlotListModel GetSlots(long eventId, DateTime fromTime, DateTime toTime, int screeningTime, int numberOfSlotstoShow, long packageId, IEnumerable<long> testIds, IEnumerable<EventSchedulingSlot> bookedSlots = null);

        IEnumerable<EventSchedulingSlot> AdjustAppointmentSlot(long eventId, int screeningTime, IEnumerable<long> slotIds, long packageId, IEnumerable<long> testIds, DateTime? lunchStartTime, int? lunchDuration);

        void SendEventFillingNotification(long eventId, long createdByOrgRoleUserId);

        void SaveEventSlot(long eventId, DateTime eventDate, DateTime eventStartTime, DateTime eventEndTime, DateTime? lunchStartTime, int? lunchDuration, IEnumerable<EventPodRoom> eventPodRooms);
        bool ShouldGetSlotsOnRoomBasis(long eventId);

        void AddEventSlots(long eventId, DateTime eventDate, DateTime eventStartTime, DateTime eventEndTime, DateTime? lunchStartTime, int? lunchDuration, IEnumerable<EventPodRoom> eventPodRooms);

        int GetScreeningTime(IEnumerable<long> testIds, long eventId, long packageId);
    }
}