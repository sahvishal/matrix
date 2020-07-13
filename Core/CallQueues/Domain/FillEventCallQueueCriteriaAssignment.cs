using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class FillEventCallQueueCriteriaAssignment : DomainObjectBase
    {
        public long FillEventCallQueueId { get; set; }
        public long CriteriaId { get; set; }
    }
}