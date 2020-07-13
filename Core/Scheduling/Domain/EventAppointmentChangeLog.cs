using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventAppointmentChangeLog : DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public long OldEventId { get; set; }
        public DateTime? OldAppointmentTime { get; set; }
        public long NewEventId { get; set; }
        public DateTime NewAppointmentTime { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public long? ReasonId { get; set; }
        public string Notes { get; set; }
        public long? SubReasonId { get; set; }
    }
}
