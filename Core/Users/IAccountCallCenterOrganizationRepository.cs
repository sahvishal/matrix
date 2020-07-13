using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountCallCenterOrganizationRepository
    {
        IEnumerable<AccountCallCenterOrganization> GetByAccountId(long accountId);
        void Save(IEnumerable<AccountCallCenterOrganization> domainObjectList);
        void MarkAsDeletedByAccountId(long accountId, long orgRoleUserId);
        void MarkAsDeletedByIds(IEnumerable<long> ids, long orgRoleUserId);
    }
}
