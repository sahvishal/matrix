using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IOrgRoleUserModelBinder
    {
        OrganizationRoleUser ToDomain(OrganizationRoleUserModel organizationRoleUserModel, long userId);
    }
}