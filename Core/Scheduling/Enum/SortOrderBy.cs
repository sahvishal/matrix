using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum SortOrderBy
    {
        [Description(" Earliest event first ")]
        EventDate,
        [Description(" Nearest location first ")]
        Distance
    }
}