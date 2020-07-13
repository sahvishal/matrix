using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class Pod : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long VanId { get; set; }
        public int ProcessingCapacity { get; set; }
        public long AssignedToFranchiseeid { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public bool EnableKynIntegration { get; set; }
        public bool IsBloodworkFormAttached { get; set; }

        public Pod()
        {}

        public Pod(long podId)
            : base(podId)
        {}
    }
}