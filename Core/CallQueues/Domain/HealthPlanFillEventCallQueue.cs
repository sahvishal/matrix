using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class HealthPlanFillEventCallQueue : DomainObjectBase
    {
        public long EventId { get; set; }
        public long CriteriaId { get; set; }
    }
}