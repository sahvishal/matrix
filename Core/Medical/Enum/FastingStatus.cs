using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum FastingStatus
    {
        Fasting = 167,
        [Description("Non-Fasting")]
        NonFasting = 168,
        Unknown = 169
    }
    public enum SmokerStatus
    {
        Smoker = 167,
        [Description("Non-smoker")]
        Nonsmoker = 168,
        Unknown = 169
    }
}
