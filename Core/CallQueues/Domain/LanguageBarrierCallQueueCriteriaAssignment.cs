using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class LanguageBarrierCallQueueCriteriaAssignment : DomainObjectBase
    {
        public long LanguageBarrierCallQueueId { get; set; }
        public long CriteriaId { get; set; }
    }
}