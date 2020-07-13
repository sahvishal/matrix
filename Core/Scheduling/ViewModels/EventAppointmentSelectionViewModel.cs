using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentSlotViewModel : ViewModelBase
    {
        public long AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        
        public bool IsSelected { get; set; }

        public bool InEarliestPart { get; set; }
        public bool InLatestPart { get; set; }
    }
}