using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointmentBasicInfoModel : ViewModelBase
    {
        public long AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string Reason { get; set; }
        public long? EventPodRoomId { get; set; }

        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string OrderPurchased { get; set; }

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public IEnumerable<OrderedPair<string, DateTime>> RoomSlots { get; set; }
        
    }
}
