using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CancelAppointmentFlagViewModel
    {
        public CancelAppointmentFlagViewModel()
        {
            Guid = System.Guid.NewGuid().ToString();
        }

        public string Guid { get; set; }
        public long CustomerId { get; set; }
        
        public bool HasFutureAppointment { get; set; }
        public DateTime? NextFutureAppointmentDate { get; set; }
        public DateTime CancelAppoinemtDate { get; set; }
    }
}