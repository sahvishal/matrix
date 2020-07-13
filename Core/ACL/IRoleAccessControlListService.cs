using Falcon.App.Core.ACL.ViewModel;

namespace Falcon.App.Core.ACL
{
    public interface IRoleAccessControlListService
    {
        RoleAccessControlObjectEditModel Get(long roleId);
        void Save(RoleAccessControlObjectEditModel model);
        void CreateAccessPermissionsBasedonParentRole(long parentRoleId, long roleId);
    }
}