using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum LeftWithoutScreeningReason
    {
        [Description("Due To Wait")]
        DueToWait = 296,

        [Description("Changed Mind")]
        ChangedMind = 297,

        [Description("Upset With Service")]
        UpsetWithService = 298,

        /*[Description("Wait Time")]
        WaitTime = 357,*/

        [Description("Mobility")]
        Mobility = 358,

        [Description("Language Barrier")]
        LanguageBarrier = 359,

        [Description("Critical/EMS")]
        CriticalEms = 360,

        [Description("Refused to sign consent")]
        RefusedToSignConsent = 361,

        [Description("Other")]
        Other = 362,

        [Description("Red Flag")]
        RedFlag = 365,

        CVT = 366,

        NP = 367,

        [Description("No Show")]
        NoShow = 368,

        [Description("Equipment Malfunction")]
        EquipmentMalfunction = 414
    }
}
