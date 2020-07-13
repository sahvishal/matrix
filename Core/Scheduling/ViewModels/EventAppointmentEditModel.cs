using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointmentEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long EventId { get; set; }
        [UIHint("Hidden")]
        public long AppointmentId { get; set; }
        [UIHint("Hidden")]
        public DateTime StartTime { get; set; }
        [UIHint("Hidden")]
        public DateTime EndTime { get; set; }
        [UIHint("Hidden")]
        public DateTime EventDate { get; set; }

        public bool ViewSlotList { get; set; }

        [DisplayName("Room")]
        public long? EventPodRoomId { get; set; }
        
        public IEnumerable<long> EventPodRoomIds { get; set; }

        public EventAppointmentEditModel()
        {
            ViewSlotList = true;
        }
    }
}
