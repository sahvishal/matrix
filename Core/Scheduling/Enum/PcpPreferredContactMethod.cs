using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum PcpPreferredContactMethod
    {
        [Description("Phone")]
        Phone = 313,
        [Description("Email")]
        Email = 314,
        [Description("Text")]
        Text = 315,
        [Description("Regular Mail")]
        RegularMail = 316,
    }
}
