using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum PcpAppointmentDispositionFilterDateType
    {
        [Description("Event Date")]
        EventDate = 1,
        [Description("Appointment Date")]
        AppointmentDate = 2
    }
}
