using System.ComponentModel;

namespace Falcon.App.Core.Sales.Enum
{
    public enum HospitalPartnerCustomerStatus
    {
        [Description("Not Called")]
        NotCalled=97,
        [Description("Talked To Person")]
        TalkedToPerson=99,
        [Description("Left Voice Mail")]
        LeftVoiceMail = 98,
        [Description("Left Voice Mail2")]
        LeftVoiceMail2 = 129,
        [Description("Left Voice Mail3")]
        LeftVoiceMail3 = 130,
        [Description("Left Voice Mail4")]
        LeftVoiceMail4 = 131,
        [Description("Voicemail 5")]
        Voicemail5=134,
        [Description("Voicemail 6")]
        Voicemail6 = 135,
        [Description("Mailed / Emailed")]
        MailedEmailed = 136,
        Unreachable=118

    }
}
