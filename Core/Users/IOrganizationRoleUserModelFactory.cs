using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users
{
    public interface IOrganizationRoleUserModelFactory
    {
        OrganizationRoleUserModel Create(User user, OrganizationRoleUser orgRoleUser, Organization organization, Role role, File file, MediaLocation mediaLocation);
        IEnumerable<OrganizationRoleUserModel> CreateMulti(User user, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<Organization> organizations, IEnumerable<Role> roles, IEnumerable<File> files, MediaLocation mediaLocation);
    }
}