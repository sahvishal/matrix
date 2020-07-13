using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointSlotSummaryViewModel
    {
        public bool IsDynamicScheduling { get; set; }
        public IEnumerable<EventAppointmentBasicInfoModel> AppointmentSlots { get; set; }
        public IEnumerable<EventPodRoom> EventPodRooms { get; set; }
    }
}
