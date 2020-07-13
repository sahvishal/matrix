using System;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class FillEventCallQueue : DomainObjectBase
    {
        public long HealthPlanId { get; set; }
        public long CustomerId { get; set; }
        public CallQueueStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime CallDate { get; set; }
        public string EventIds { get; set; }
    }
}