using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users
{
    public interface IUserSessionModelFactory
    {
        UserSessionModel Create(User user, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<Organization> organizations, IEnumerable<Role> roles, IEnumerable<File> files, MediaLocation mediaLocation);
    }
}