using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class RoomAppointmentSelectionViewModel
    {
        public IEnumerable<long> SelectedAppointmentIds { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}")]
        public DateTime AppointmentTime { get; set; }

        public int RoomNo { get; set; }

        public string ScreeningTests { get; set; }

        public IEnumerable<long> ScreeningTestIds { get; set; } 

        public IEnumerable<EventSchedulingSlot> Slots { get; set; }

        public double TotalWaitingTime { get; set; }

        public int Hours
        {
            get
            {
                if (TotalWaitingTime > 60)
                    return (int)TotalWaitingTime / 60;
                return 0;
            }
        }

        public int Minutes
        {
            get
            {
                if (TotalWaitingTime > 60)
                    return (int)TotalWaitingTime % 60;
                return (int)TotalWaitingTime;
            }
        }
    }
}
