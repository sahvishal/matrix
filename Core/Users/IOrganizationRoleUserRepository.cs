using System;
using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IOrganizationRoleUserRepository
    {
        List<long> GetUserIds(List<long> organizationRoleUserIds);
        OrganizationRoleUser GetOrganizationRoleUser<T>(T data, Func<T, long> organizationRoleUserId);
        OrganizationRoleUser GetOrganizationRoleUser(long organizationRoleUserId);
        List<OrganizationRoleUser> GetOrganizationRoleUsers(IEnumerable<long> organizationRoleUserIds);
        OrderedPair<long, long> GetSalesRepUser(OrganizationRoleUser organizationRoleUser);
        OrganizationRoleUser GetOrganizationRoleUser(long userId, Roles role, long organizationId);

        OrganizationRoleUser SaveOrganizationRoleUser(OrganizationRoleUser organizationRoleUser);
        OrganizationRoleUser[] GetOrganizationRoleUserCollectionforaUser(long userId);

        //Will go obselete
        OrganizationRoleUser GetDefaultOrgRoleUserforOrganization(long organizationId, long roleId);
        bool DeactivateOrganizationRoleUser(long organizationRoleUserId);
        void DeactivateAllOrganizationRolesForUser(long userId);

        bool DeactivateAllOrganizationRoleUserForOrganization(long organizationid);

        IEnumerable<OrderedPair<long, string>> GetNameIdPairofUsers(long[] orgRoleUserIds);
        IEnumerable<OrderedPair<long, string>> GetNameIdPairofUsersByEventDate(long[] orgRoleUserIds, DateTime? eventDate);

        List<long> GetOrganizationRoleUserIdsForRole(long roleId);
        List<long> GetOrganizationRoleUserIdsByParentRole(long roleId);
        IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsersByRole(Roles role);
        IEnumerable<OrderedPair<long, string>> GetAllIdNamePairofUsersByRole(Roles role);
        IEnumerable<OrganizationRoleUser> GetOrganizationRoleUserByUserIds(IEnumerable<long> userIds);
        void ActivateAllOrganizationRolesForUser(long userId);
        IEnumerable<OrganizationRoleUser> GetOrganizationRoleUsersByOrganizationId(long organizationId);
        IEnumerable<OrganizationRoleUser> GetOrganizationRoleUsersByOrganizationIdAndRoleId(long organizationId, long roleId);

        IEnumerable<OrderedPair<long, string>> GetNameIdPairofOrgRoleIdByUserNames(IEnumerable<string> userNames, long roleId);
        IEnumerable<OrderedPair<long, string>> GetNameIdPairofOrgRoleIdByEmail(IEnumerable<string> emails, long roleId);
        IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsersByRoles(long[] roles);

        IEnumerable<OrderedPair<long, string>> GetIdNamePairofAllUsersByRole(Roles role);

        OrganizationRoleUserModel GetOrganizationRoleUsermodel(long userid, long roleId);
        IEnumerable<OrderedPair<long, string>> GetActiveOruIdEmployeeIdPairByEmployeeIdAndRole(IEnumerable<string> employeeIds, long roleId);
        OrganizationRoleUser GetByUserNameAndRoleAlias(string username, string roleAlias);
        OrganizationRoleUser GetOrganizationRoleUserByEmployeeIdandRoleId(string employeeId, long roleId);
        OrganizationRoleUser GetOrganizationRoleUserByUserIdAndRoleId(long userId, long roleId);
    }
}