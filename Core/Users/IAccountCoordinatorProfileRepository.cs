using Falcon.App.Core.Users.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountCoordinatorProfileRepository
    {
        AccountCoordinatorProfile GetAccountCoordinatorProfile(long accountCoordinatorId);
        IEnumerable<long> GetCriticalCoordinator(IEnumerable<long> organizationRoleUserIds);
    }
}
