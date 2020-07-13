using System.ComponentModel;

namespace Falcon.App.Core.CallCenter.Enum
{
    public enum CallStatus
    {
        [Description("No Answer")]
        NoAnswer = 32,
        [Description("Left Voice Mail")]
        VoiceMessage = 33,
        [Description("Talked To Patient")]
        Attended = 34,
        Initiated = 35,
        [Description("Left Message With Other")]
        LeftMessageWithOther = 242,
        [Description("Incorrect Phone Number")]
        IncorrectPhoneNumber = 243,

        [Description("No Events In Area")]
        NoEventsInArea = 280,

        [Description("Call Skipped")]
        CallSkipped = 325,

        [Description("Talked to Other Person")]
        TalkedtoOtherPerson = 408,

        [Description("Invalid Number")]
        InvalidNumber = 409
    }
}