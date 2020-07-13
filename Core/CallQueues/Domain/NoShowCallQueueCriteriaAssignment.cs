using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class NoShowCallQueueCriteriaAssignment : DomainObjectBase
    {
        public long NoShowCallQueueId { get; set; }
        public long CriteriaId { get; set; }
    }
}