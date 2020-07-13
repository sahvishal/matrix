using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
   public class PcpAppointmentListModelFilter : ModelFilterBase
    {
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

        [DisplayName("Tag")]
        public string Tag { get; set; }

        [DisplayName("Custom Tag(s)")]
        public string[] CustomTags { get; set; }
        public int DateType { get; set; }
    }
}
