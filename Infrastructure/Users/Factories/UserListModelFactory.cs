using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class UserListModelFactory : IUserListModelFactory
    {
        private readonly IAddressFactory _addressFactory;
        public UserListModelFactory(IAddressFactory addressFactory)
        {
            _addressFactory = addressFactory;
        }

        public UserListModel Create(IEnumerable<OrganizationRoleUserEntity> entities, IEnumerable<AddressEntity> addresses, IEnumerable<OrganizationRoleUser> organizationRoleUsers, IEnumerable<Organization> organizations, IEnumerable<Role> roles)
        {
            var model = new UserListModel();
            var userBasicInfoModels =
                entities.Select(entity =>
                                Create(entity,
                                       addresses.Where(address => address.AddressId == entity.User.HomeAddressId).FirstOrDefault(),
                                       organizationRoleUsers.Where(oru => oru.UserId == entity.UserId).ToArray(),
                                       organizations, roles));

            model.Collection = userBasicInfoModels;
            return model;
        }

        private UserBasicInfoModel Create(OrganizationRoleUserEntity entity, AddressEntity address, IEnumerable<OrganizationRoleUser> organizationRoleUsers, IEnumerable<Organization> organizations, IEnumerable<Role> roles)
        {
            //TODO: Default role filtering is not great, so there is hack for now.
            var userBascibInfoModel = Create(entity, address);
            var availableRoles = (from organizationRoleUser in organizationRoleUsers
                                  let role = roles.Where(r => r.Id == organizationRoleUser.RoleId).Select(r => r.DisplayName).SingleOrDefault()
                                  let organization = organizations.Where(o => o.Id == organizationRoleUser.OrganizationId).Select(o => o.Name).SingleOrDefault()
                                  select role + " ( " + organization + " )").ToList();
            userBascibInfoModel.Roles = availableRoles;
            return userBascibInfoModel;

        }

        public UserListModel Create(IEnumerable<OrganizationRoleUserEntity> entities, IEnumerable<AddressEntity> addresses)
        {
            var model = new UserListModel();
            var userBasicInfoModels =
                entities.Select(entity => Create(entity, addresses.Where(address => address.AddressId == entity.User.HomeAddressId).FirstOrDefault()));

            model.Collection = userBasicInfoModels;
            return model;
        }

        private UserBasicInfoModel Create(OrganizationRoleUserEntity entity, AddressEntity address)
        {
            //TODO: Default role filtering is not great, so there is hack for now.
            return new UserBasicInfoModel
                       {
                           Id = entity.UserId,
                           OrganizationRoleUserId = entity.OrganizationRoleUserId,
                           OrganizationName =
                               entity.RoleId == entity.User.DefaultRoleId
                                   ? entity.Organization.Name
                                   : "not default",
                           Email = string.IsNullOrEmpty(entity.User.Email1)
                                       ? null
                                       : new Email(entity.User.Email1).ToString(),
                           Name =
                               new Name(entity.User.FirstName, entity.User.MiddleName,
                                        entity.User.LastName).ToString(),
                           Phone = GetPhoneNumber(entity),
                           Address = _addressFactory.CreateAddressDomain(address).ToString(),
                           DefaultRoleDisplayName =
                               entity.RoleId == entity.User.DefaultRoleId
                                   ? entity.Role.Name
                                   : ("Has:" + entity.Role.Name),
                           IsActive = entity.User.IsActive
                       };

        }

        private static string GetPhoneNumber(OrganizationRoleUserEntity organizationRoleUserEntity)
        {
            if (organizationRoleUserEntity.User.PhoneHome.Length > 0)
            {
                return organizationRoleUserEntity.User.PhoneHome + "(H)"; 
            }

            if (organizationRoleUserEntity.User.PhoneCell.Length > 0)
            {
                return organizationRoleUserEntity.User.PhoneCell + "(C)"; 
            }

            if (organizationRoleUserEntity.User.PhoneOffice.Length > 0)
            {
                return organizationRoleUserEntity.User.PhoneOffice + "(W)";
            }

            return "";
        }


    }
}
