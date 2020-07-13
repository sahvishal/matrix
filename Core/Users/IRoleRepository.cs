using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IRoleRepository 
    {
        IEnumerable<Role> GetAll();
        IEnumerable<Role> GetRolesByName(string name);
        Role GetByRoleId(long roleId);
        IEnumerable<Role> GetRolesByParentId(long parentId);
        int GetRoleCount(long roleId);
        Role Save(Role role);
        IEnumerable<Role> GetAllSystemRoles();
        bool OverRideIsTwoFactorAuthRequired(long roleId);
        IEnumerable<Role> GetRolesByExactName(string name);
        List<Role> GetByRoleIds(List<long> roleIds);
        IEnumerable<Role> GetRolesByAlias(string alias);
    }
}