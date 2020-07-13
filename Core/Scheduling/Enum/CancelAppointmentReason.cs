using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum CancelAppointmentReason
    {
        [Description("Personal Reasons")]
        PersonalReasons = 209,

        [Description("Schedule Conflict")]
        ScheduleConflict = 210,

        [Description("Event Move")]
        EventMove = 211,

        [Description("Physician Recommendation")]
        PhysicianRecommendation = 212,

        [Description("Unable to Reschedule")]
        UnableToReschedule = 213,

        [Description("Changed Insurance")]
        ChangedInsurance = 214,

        [Description("Not Eligible")]
        NotEligible = 215,

        [Description("Prefers PCP Office Visit")]
        PrefersPcpOfficeVisit = 221,

        [Description("Deceased or ILL")]
        DeceasedOrILL = 234,

        [Description("Emergency")]
        Emergency = 235,

        [Description("Agent Mistake/Training")]
        AgentMistakeTraining = 236,

        [Description("Matrix Medical Network Reason")]
        HealthFairReason = 237,

        [Description("Field/Event Issue")]
        FieldEventIssue = 238,

        [Description("Requested By Plan")]
        HealthPlanRequested = 239,

        [Description("Home Visit Preferred")]
        HomeVisitPreferred = 240,

        [Description("No Show")]
        NoShow = 241,

        Deceased = 374,

        [Description("Event to far")]
        EventToFar = 375,

        Healthplan = 376,

        [Description("Mobility Issue")]
        MobilityIssue = 377,

        Other = 378,

        [Description("SICK/ILL")]
        SICKILL = 379,

        [Description("Transportation Issue")]
        TransportationIssue = 380,

        [Description("UNAWARE OF APPOINTMENT")]
        UNAWAREOFAPPOINTMENT = 381,

    }
}