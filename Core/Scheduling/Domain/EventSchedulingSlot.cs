using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventSchedulingSlot : DomainObjectBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public long EventId { get; set; }
        public string Reason { get; set; }

        public string StartTimeString { get { return StartTime.ToShortTimeString(); } }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public long? EventPodRoomId { get; set; }
    }
}