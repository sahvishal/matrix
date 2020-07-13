using System.ComponentModel;

namespace Falcon.App.Core.CallQueues.Enum
{
    public enum SuppressionFilterType
    {
        [Description("Max Contact")]
        MaxAttempt = 1,

        [Description("Not Eligible")]
        NotEligible = 2,

        [Description("Do Not Contact")]
        DoNotContact = 3,

        [Description("Do Not Call Activity")]
        DoNotCallActivity = 4,

        [Description("Language Barrier")]
        LanguageBarrier = 5,

        [Description("Incorrect Phone Number")]
        IncorrectPhone = 6,

        [Description("No Phone")]
        NoPhone = 7,

        [Description("Appointment Booked")]
        AppointmentBooked = 8,

        [Description("Deceased/Dead")]
        Deceased = 9,

        [Description("Home Visit Requested")]
        HomeVisitRequested = 10,

        [Description("Mobility Issue: No Home Visit Requested")]
        MobilityIssue = 11,

        [Description("In Long Term Care/Nursing Home")]
        InLongTermCareNursingHome = 12,

        [Description("Mobility Issues: Left Message With Other")]
        MobilityIssues_LeftMessageWithOther = 13,

        [Description("No Longer On Insurance Plan")]
        NoLongeronInsurancePlan = 14,

        [Description("Debilitating Disease")]
        DebilitatingDisease = 15,

        [Description("Call Back Later")]
        CallBackLater = 16,

        [Description("No Events In Area")]
        NoEventsInArea = 17,

        [Description("Left Voice Message")]
        LeftVoiceMessage = 18,

        [Description("Not Interested")]
        NotInterested = 19,

        [Description("Recently Saw Doc")]
        RecentlySawDoc = 20,

        [Description("Transportation Issue")]
        TransportationIssue = 21,

        [Description("Appointment Cancellation")]
        AppointmentCancelledDate = 22,

        [Description("Call Skipped")]
        CallSkipped = 23,

        [Description("Call Initiated")]
        CallInitiated = 24,

        [Description("Moved Relocated")]
        MovedRelocated = 25,

        [Description("Will Speak With Physician")]
        WillSpeakWithPhysician = 26,

        [Description("Date Time Conflict")]
        DateTimeConflict = 27,

        [Description("No Answer")]
        NoAnswer = 28,

        [Description("Outcome - No Events In Area")]
        NoEventsInAreaCallStatus = 29,

        [Description("Left Message With Others")]
        LeftMessageWithOthers = 30,

        [Description("No Show")]
        NoShowMarkDate = 31,

        [Description("Invalid Number")]
        InvalidNumber = 32,

        [Description("Declined- Member not mammo available, no events in area")]
        DeclinedMemberNotMammoAvailableNoEventsInArea = 33,

        [Description("Declined Mammo - Not interested in Mammogram")]
        DeclinedMammoNotinterestedInMammogram = 34,

        [Description("Non-Targeted")]
        NonTargeted = 35

    }
}
