using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentEncounterFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public DateTime? EventFromDate { get; set; }
        public DateTime? EventToDate { get; set; }
        public long AccountId { get; set; }
        public string Tag { get; set; }
    }
}