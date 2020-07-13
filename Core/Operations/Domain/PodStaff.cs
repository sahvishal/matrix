using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class PodStaff : DomainObjectBase
    {
        public long PodId { get; set; }

        public long OrganizationRoleUserId { get; set; }

        public long EventRoleId { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public PodStaff ()
        {}

        public PodStaff(long podTeamId)
            : base(podTeamId)
        {}
    }
}