using System.ComponentModel;

namespace Falcon.App.Core.Enum
{
    public enum RequirementStatusDescription
    {
        [Description("Client Requested Close")]
        PersonalReasons,

        [Description("Deceased")]
        DeceasedOrILL,

        [Description("Deceased")]
        Deceased,

        [Description("Do Not Call")]
        DoNotCall,

        [Description("Frequently Visiting Doctor")]
        RecentlySawDoc,

        [Description("No Reason Given")]
        NotInterested,

        [Description("In Nursing Home")]
        InLongTermCareNursingHome,

        [Description("Invalid Phone Number")]
        IncorrectPhoneNumber,

        [Description("Language Barrier")]
        LanguageBarrier,

        [Description("Member Called Max Attempts")]
        MemberCalledMaxAttempts,

        [Description("No Longer in Plan")]
        NoLongeronInsurancePlan,

        [Description("Out of Area")]
        DateTimeConflict,

        [Description("Too Time Consuming")]
        ScheduleConflict,

        [Description("Assessment Completed")]
        AssessmentCompleted,

        [Description("Call Attempt")]
        CallAttempt,

        [Description("Scheduled")]
        Scheduled,

        [Description("Booked Appointment")]
        BookedAppointment,

        [Description("No Show")]
        NoShow,

        [Description("Left Without Screening")]
        LeftWithoutScreening
    }
}
