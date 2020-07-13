using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum CallQueueSortOrderBy
    {
        [Description(" Earliest event first ")]
        EventDate,
        [Description(" Nearest location first ")]
        Distance,
        [Description("By Event Host Name ")]
        EventName,
        [Description("Available Appointment Slots")]
        AvailableAppointmentSlots
    }
}