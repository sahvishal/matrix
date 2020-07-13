using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IUserListModelFactory
    {
        UserListModel Create(IEnumerable<OrganizationRoleUserEntity> entities, IEnumerable<AddressEntity> addresses);
        UserListModel Create(IEnumerable<OrganizationRoleUserEntity> entities, IEnumerable<AddressEntity> addresses,
                             IEnumerable<OrganizationRoleUser> organizationRoleUsers,
                             IEnumerable<Organization> organizations, IEnumerable<Role> roles);
    }
}