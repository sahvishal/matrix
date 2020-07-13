using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class FutureAppointmentFlagViewModel
    {
        public FutureAppointmentFlagViewModel()
        {
            Guid = System.Guid.NewGuid().ToString();
        }

        public string Guid { get; set; }
        public long CustomerId { get; set; }
        public bool HasFutureAppointment { get; set; }
        public DateTime? FutureAppointmentDate { get; set; }
    }
}