namespace Falcon.App.Core.Scheduling.Enum
{
    public sealed class CompletionStatus
    {
        public const string Completed = "Completed";
        public const string NoShow = "No Show";
        public const string Cancellation = "Cancellation";
        public const string FutureAppointment = "Future Appointment";
        public const string ScheduledForToday = "Scheduled for Today";
        public const string LeftWithoutScreening = "Left Without Screening";
    }
}