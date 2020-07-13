using System.Collections.Generic;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IOrganizationRepository
    {
        long SaveOrganization(Organization organization);
        Organization GetOrganizationbyId(long organizationId);
        IEnumerable<Organization> GetOrganizations(long[] ids);
        List<Organization> GetAllOrganizationsforUser(long userId);
        IEnumerable<Organization> GetOrganizationCollection(OrganizationType type);
        IEnumerable<Organization> GetOrganizationCollection(OrganizationType type, string searchText);
        IEnumerable<OrderedPair<string, long>> GetOrganizationIdNamePairs(OrganizationType type);
        IEnumerable<OrderedPair<string, long>> GetAllOrganizationIdNamePairs();
        bool Deactivate(long id);
        //Todo:Do we need a role repository?? - yasir
        IEnumerable<OrderedPair<string, long>> GetOrganizationRoles(OrganizationType organizationType);
        IEnumerable<OrderedPair<string, long>> GetOrganizationTypes();
        IEnumerable<MedicareSiteModel> GetMedicareSites();
        IEnumerable<RoleDropdownListModel> GetRolesByOrganizationType(OrganizationType organizationType);
        bool IsActiveOrganizationbyId(long organizationId);
    }
}