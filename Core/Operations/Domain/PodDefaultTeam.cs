using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class PodDefaultTeam : DomainObjectBase
    {
        public long PodId { get; set; }

        public long OrganizationRoleUserId { get; set; }

        public long EventRoleId { get; set; }

        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public PodDefaultTeam ()
        {}

        public PodDefaultTeam(long podTeamId)
            : base(podTeamId)
        {}
    }
}