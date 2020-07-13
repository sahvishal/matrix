using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IUserService
    {
        long SaveDefaultUserforOrganization(long organizationId, OrganizationType type, User user);
        long SaveUserforOrganization(long organizationId, Roles role, User user, bool checkZipData = false);
        User GetDefaultUserforOrganization(long organizationId, OrganizationType type);
        User GetUser(long organizationRoleUserId);

        UserEditModel Save(UserEditModel userToSave);
        UserEditModel Get(long id);
        IEnumerable<OrderedPair<long, string>> GetRoleswithRegistrationEnabled();
    }
}
