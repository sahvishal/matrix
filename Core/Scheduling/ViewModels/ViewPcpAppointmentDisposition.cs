using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class ViewPcpAppointmentDisposition
    {
        public long EventCustomerId { get; set; }
        public DateTime PcpAppointment { get; set; }
        public DateTime PcpAppointmentLastModified { get; set; }
        public long PcpDispositionId { get; set; }
        public DateTime PcpDispositionLastModified { get; set; }
        public DateTime LastModified { get; set; }
    }
}
