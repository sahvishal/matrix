using System;
using System.Collections.Generic;

using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class Appointment : DomainObjectBase
    {
        public long EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ScheduledById { get; set; }
        public DateTime? DateModified { get; set; }

        public IEnumerable<long> SlotIds { get; set; }

        public Appointment()
        { }

        public Appointment(long appointmentId)
            : base(appointmentId)
        { }
    }
}
