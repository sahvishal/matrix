using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventAppointmentCancellationLog : DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public long EventId { get; set; }
        public long ReasonId { get; set; }
        public long? NoteId { get; set; }
        public long? RefundRequestId { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public long? SubReasonId { get; set; }
    }
}