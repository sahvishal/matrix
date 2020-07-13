using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CallCenterTeam : DomainObjectBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long TypeId { get; set; }

        public bool IsActive { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
