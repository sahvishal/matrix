using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class PcpAppointment : DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public DateTime AppointmentOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? PreferredContactMethod { get; set; }
        
    }
}