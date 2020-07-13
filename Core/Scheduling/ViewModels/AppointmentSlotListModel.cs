using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentSlotListModel
    {
        public IEnumerable<AppointmentSlotViewModel> Slots { get; set; }

        public int ScreeningTime { get; set; }

        public int TotalSlots { get; set; }

        public SlotSelectionTimeFrameViewModel TimeFrame { get; set; }

        public long PackageId { get; set; }
        public IEnumerable<long> AddOnTestIds { get; set; } 
    }
}