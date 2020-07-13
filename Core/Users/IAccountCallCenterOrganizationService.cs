using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IAccountCallCenterOrganizationService
    {
        void Save(IEnumerable<AccountCallCenterOrganizationEditModel> accountCallCenterOrganizations, long accountId, long OrgRoleUserId, bool restrictHealthPlanData);
        IEnumerable<AccountCallCenterOrganizationEditModel> GetEditModel(IEnumerable<AccountCallCenterOrganization> accountCallCenterOrganization);
    }
}
