using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum RescheduleAppointmentReason
    {
        Cancellation = 160,

        [Description("No Show")]
        NoShow = 161,

        [Description("Personal Reasons")]
        PersonalReasons = 205,

        [Description("Schedule Conflict")]
        ScheduleConflict = 206,

        [Description("Event Move")]
        EventMove = 207,

        [Description("Physician Recommendation")]
        PhysicianRecommendation = 208,

        [Description("Deceased or ILL")]
        DeceasedOrILL = 229,

        [Description("Emergency")]
        Emergency = 230,

        [Description("Agent Mistake/Training")]
        AgentMistakeTraining = 231,

        [Description("Matrix Medical Network Reason")]
        HealthFairReason = 232,

        [Description("Field/Event Issue")]
        FieldEventIssue = 233,

        Other = 162,

        [Description("Event to far")]
        EventToFar = 369,

        [Description("Mobility Issue")]
        MobilityIssue = 370,

        [Description("SICK/ILL")]
        SICKILL = 371,

        [Description("Transportation Issue")]
        TransportationIssue = 372,

        [Description("UNAWARE OF APPOINTMENT")]
        UNAWAREOFAPPOINTMENT = 373,
    }
}
