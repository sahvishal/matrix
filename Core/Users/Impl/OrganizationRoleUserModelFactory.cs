using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Impl
{
    public class OrganizationRoleUserModelFactory : IOrganizationRoleUserModelFactory
    {
        public IEnumerable<OrganizationRoleUserModel> CreateMulti(User user, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<Organization> organizations, IEnumerable<Role> roles, IEnumerable<File> files, MediaLocation mediaLocation)
        {
            return (from orgRoleUser in orgRoleUsers
                    let organization = organizations.Where(o => o.Id == orgRoleUser.OrganizationId).FirstOrDefault()
                    let role = roles.Where(r => r.Id == orgRoleUser.RoleId).FirstOrDefault()
                    let file = files != null ? files.Where(f => f.Id == organization.LogoImageId).FirstOrDefault() : null
                    select Create(user, orgRoleUser, organization, role, file, mediaLocation)).ToList();
        }

        public OrganizationRoleUserModel Create(User user, OrganizationRoleUser orgRoleUser, Organization organization, Role role, File file, MediaLocation mediaLocation)
        {
            return new OrganizationRoleUserModel
                    {
                        UserId = user.Id,
                        OrganizationRoleUserId = orgRoleUser.Id,
                        OrganizationId = orgRoleUser.OrganizationId,
                        OrganizationName = organization != null ? organization.Name : string.Empty,
                        RoleId = orgRoleUser.RoleId,
                        ParentRoleId = role != null ? (role.ParentId ?? 0) : 0,
                        RoleAlias = role != null ? role.Alias : string.Empty,
                        RoleDisplayName = role != null ? role.DisplayName : string.Empty,
                        IsDefault = (user.DefaultRole == (Roles) orgRoleUser.RoleId),
                        LogoFilePathUrl = file != null ? mediaLocation.Url + file.Path : string.Empty
                    };
        }
    }
}