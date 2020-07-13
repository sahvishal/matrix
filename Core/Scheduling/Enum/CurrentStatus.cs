using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.Enum
{
    public sealed class CurrentStatus
    {
        public const string Exhausted = "Exhausted";
        public const string InProgress = "In Progress";
        public const string InvalidData = "Invalid Data";
        public const string Refusal = "Refusal";
        public const string ScheduledFutureAppointment = "Scheduled - Future Appointment";
        public const string ScheduledTestingComplete = "Scheduled - Testing Complete";
        public const string ScheduledCancelled = "Scheduled - Cancelled";
        public const string UnableToSchedule = "Unable To Schedule";
        public const string NoShow = "Scheduled - No Show";
    }
}
