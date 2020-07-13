using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users.Impl
{    
    public class OrgRoleUserModelBinder : IOrgRoleUserModelBinder 
    {
        public OrganizationRoleUser ToDomain(OrganizationRoleUserModel organizationRoleUserModel, long userId)
        {
            return new OrganizationRoleUser
                       {
                           UserId = userId,
                           Id = organizationRoleUserModel.OrganizationRoleUserId,
                           OrganizationId = organizationRoleUserModel.OrganizationId,
                           RoleId = organizationRoleUserModel.RoleId
                       };
        }
    }
}