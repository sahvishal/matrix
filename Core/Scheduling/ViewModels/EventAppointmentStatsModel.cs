using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointmentStatsModel
    {
        public long EventId { get; set; }
        public int TotalSlots { get; set; }
        public int FreeSlots { get; set; }
        public int TemporaryBookedSlots { get; set; }
        public int BlockedSlots { get; set; }
        public int BookedSlots { get; set; }
        public int FilledSlots { get; set; }
        public bool IsDynamicScheduling { get; set; }

        public long MorningAvailableSlots { get; set; }
        public long AfternoonAvailableSlots { get; set; }
        public long EveningAvailableSlots { get; set; }
        public EventStatus Status { get; set; }
    }
}
