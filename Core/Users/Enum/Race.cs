using System.ComponentModel;

namespace Falcon.App.Core.Users.Enum
{
    public enum Race
    {
        None = 0,
        Caucasian = 1,
        Asian,
        AfricanAmerican,
        Hispanic,
        NativeAmerican,
        Latino,
        [Description("Declines to report")]
        DeclinesToReport,
        Other

    }
}