using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountCallCenterOrganizationFactory
    {
        IEnumerable<AccountCallCenterOrganizationEditModel> CreateEditModel(IEnumerable<AccountCallCenterOrganization> accountCallCenterOrganizations, IEnumerable<Organization> organizations);
        IEnumerable<AccountCallCenterOrganization> CreateDomain(IEnumerable<AccountCallCenterOrganizationEditModel> modelList, long accountId, long orgRoleUserId);
    }
}
