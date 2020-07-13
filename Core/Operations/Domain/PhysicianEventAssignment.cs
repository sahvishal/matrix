using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class PhysicianEventAssignment : DomainObjectBase
    {
        public long EventId { get; set; }
        public long PhysicianId { get; set; }
        public long? OverReadPhysicianId { get; set; }
        public string Notes { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
