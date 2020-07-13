using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentSelectionEditModel
    {
        public long EventId { get; set; }
        public IEnumerable<long> SelectedAppointmentIds { get; set; }

        [DisplayFormat(DataFormatString = "{0:h:mm tt}")]
        public DateTime AppointmentTime { get; set; }

        public SlotSelectionTimeFrameViewModel[] TimeFrames { get; set; }

        public int MaxNumberofSlots { get; set; }

        public int ScreeningTime { get; set; }

        public long PackageId { get; set; }
        public IEnumerable<long> AddOnTestIds { get; set; } 

        public IEnumerable<RoomAppointmentSelectionViewModel> RoomAppointments { get; set; }

        public double TotalWaitingTime { get; set; }

        public int Hours
        {
            get
            {
                if (TotalWaitingTime > 60)
                    return (int)TotalWaitingTime/60;
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