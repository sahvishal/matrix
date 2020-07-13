using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IRoleService
    {
        RoleEditModel Get(long roleId);
        RoleEditModel Save(RoleEditModel model);
        RoleListModel Get(RoleListModelFilter filter);
        IEnumerable<RoleSelectItemModel> GetRoles(Roles parentRole);
    }
}