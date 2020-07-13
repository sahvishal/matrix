using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class AccountCallCenterOrganization : DomainObjectBase
    {
        public long AccountId { get; set; }
        public long OrganizationId { get; set; }
        public bool IsDeleted { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
