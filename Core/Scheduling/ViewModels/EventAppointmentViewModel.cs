using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventAppointmentViewModel
    {
        public long AppointmentId { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime AppointmentTime { get; set; }

        [Display(Name = "Check-In")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? CheckInTime { get; set; }

        [Display(Name = "Check-Out")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? CheckOutTime { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public string Reason { get; set; }

        public IEnumerable<OrderedPair<string, DateTime>> RoomSlots { get; set; }
    }
}