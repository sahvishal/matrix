using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class CallRoundCallQueueCriteriaAssignment : DomainObjectBase
    {
        public long CallRoundCallQueueId { get; set; }
        public long CriteriaId { get; set; }
    }
}