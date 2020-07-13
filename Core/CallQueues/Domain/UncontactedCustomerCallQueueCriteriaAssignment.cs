using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallQueues.Domain
{
    public class UncontactedCustomerCallQueueCriteriaAssignment : DomainObjectBase
    {
        public long UncontactedCustomerId { get; set; }
        public long CriteriaId { get; set; }
    }
}