using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HourlyAppointmentsBookedListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long AccountId { get; set; }
        public bool ShowCustomersWithAppointment { get; set; }
    }
}