using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomAppointmentsBookedListModelFilter : ModelFilterBase
    {
        //For the registration date range
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long AccountId { get; set; }
        public string Tag { get; set; }

    }
}