using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum PcpAppointmentDisposition
    {
        [Description("Scheduled  - Matrix Medical Network Booked PCP Appointment")]
        ScheduledHealthFairBooked = 251,
        [Description("Scheduled - Patient Booked PCP Appointment")]
        ScheduledPatientBooked = 252,
        [Description("No Answer")]
        NoAnswer = 253,
        [Description("Left Voice Mail")]
        LeftVoiceMail = 254,
        [Description("Wrong Phone Number")]
        WrongPhoneNumber = 255,
        [Description("Denied - Not a Current Patient")]
        DeniedNotCurrentPatient = 256,
        [Description("Denied - Requires Patient to Call Directly")]
        DeniedRequiresPatientCallDirectly = 257,
        [Description("Denied - PCP Refuses To Review Matrix Medical Network Results")]
        DeniedRefusesToReviewHealthFairResults = 258
    }
}
