using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum DateRangeType
    {
        Today = 1,
        Tomorrow,
        [Description("This Week")]
        ThisWeek,
        [Description("Last Week")]
        LastWeek
    }
}