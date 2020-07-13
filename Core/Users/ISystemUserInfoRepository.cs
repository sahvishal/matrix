using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ISystemUserInfoRepository
    {
        SystemUserInfo Get(long userId);
        bool IsEmployeeExist(long userId, string employeeId);
        void Save(SystemUserInfo systemUserInfo);
        IEnumerable<OrderedPair<long, string>> GetIdEmployeeIdPairofUsers(long[] orgRoleUserIds);
    }
}
