using System.ComponentModel;

namespace Falcon.App.Core.Enum
{
    public enum EventSearchFilterType
    {
        [Description("All Events")]
        All,

        [Description("Mammo Events Only")]
        Mammo,

        [Description("Health Plan Events")]
        HealthPlan,

        [Description("Corporate Events")]
        Corporate
    }
}
