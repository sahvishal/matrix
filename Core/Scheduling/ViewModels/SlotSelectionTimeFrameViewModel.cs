using System;
using System.ComponentModel.DataAnnotations;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class SlotSelectionTimeFrameViewModel
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime FromTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTime ToTime { get; set; }

        public bool IsSelected { get; set; }

        public SlotSelectionTimeFrameViewModel(DateTime fromTime, DateTime toTime)
        {
            FromTime = fromTime;
            ToTime = toTime;
        }

        public override string ToString()
        {
            return string.Concat(FromTime.ToString("h:mm"), " - ", ToTime.ToString("h:mm"));
        }
    }
}