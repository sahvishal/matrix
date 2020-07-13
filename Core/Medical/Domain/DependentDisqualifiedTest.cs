using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class DependentDisqualifiedTest : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public long TestId { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }
        public long? EventCustomerId { get; set; }
    }
}
