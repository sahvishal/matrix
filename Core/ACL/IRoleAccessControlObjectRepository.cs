using System.Collections.Generic;
using Falcon.App.Core.ACL.Domain;

namespace Falcon.App.Core.ACL
{
    public interface IRoleAccessControlObjectRepository
    {
        IEnumerable<RoleAccessControlObject> GetRoleAccessControlObjectByRoleId(long roleId);
        IEnumerable<RoleAccessControlObject> GetRoleAccessControlObjectByParentRoleId(long parentRoleId);
        void DeleteRoleAccessControlObject(RoleAccessControlObject roleAccessControlObject);
        RoleAccessControlObject SaveRoleAccessControlObject(RoleAccessControlObject roleAccessControlObject);
    }
}
