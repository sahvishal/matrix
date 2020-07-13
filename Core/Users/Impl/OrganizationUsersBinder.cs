using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users.Impl
{
    public class OrganizationUsersBinder
    {
        public UserBasicInfoModel ToModel(Organization organization, User user, OrganizationRoleUser organizationRoleUser)
        {
            return new UserBasicInfoModel()
                       {
                           OrganizationName = organization.Name,
                           Email = (user.Email ?? user.AlternateEmail).ToString(),
                           Address = user.Address.ToString(),
                           Name = user.NameAsString,
                           OrganizationRoleUserId = organizationRoleUser.Id,
                           Phone = (user.HomePhoneNumber ?? user.MobilePhoneNumber).ToString()
                       };
        }
    }
}