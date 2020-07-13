using System;
using System.ComponentModel.DataAnnotations;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentSlotViewModel
    {
        public long AppointmentId { get; set; }

        [DisplayFormat(DataFormatString = "{0: h:mm tt}")]
        public DateTime StartTime { get; set; }

        public bool IsSelected { get; set; }
    }
}