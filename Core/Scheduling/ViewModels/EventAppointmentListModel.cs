using System;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointmentListModel
    {
        public IEnumerable<EventAppointmentBasicInfoModel> EventAppointmentViewModel { get; set; }
        public string EventName { get; set; }
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public IEnumerable<EventPodRoom> EventPodRooms { get; set; }
    }
}
