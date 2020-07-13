using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Impl
{
    public class UserSessionModelFactory : IUserSessionModelFactory
    {
        private readonly IOrganizationRoleUserModelFactory _organizationRoleUserModelFactory;

        public UserSessionModelFactory(IOrganizationRoleUserModelFactory organizationRoleUserModelFactory)
        {
            _organizationRoleUserModelFactory = organizationRoleUserModelFactory;
        }

        public UserSessionModel Create(User user, IEnumerable<OrganizationRoleUser> orgRoleUsers, IEnumerable<Organization> organizations, IEnumerable<Role> roles, IEnumerable<File> files, MediaLocation mediaLocation)
        {
            var userSessionModel = new UserSessionModel();

            userSessionModel.UserId = user.Id;
            userSessionModel.FirstName = user.Name.FirstName;
            userSessionModel.LastName = user.Name.LastName;
            userSessionModel.UserName = user.UserLogin.UserName;

            var organizationRoleUserModels = _organizationRoleUserModelFactory.CreateMulti(user, orgRoleUsers, organizations, roles, files, mediaLocation);

            userSessionModel.AvailableOrganizationRoles = organizationRoleUserModels.ToArray();            
            userSessionModel.CurrentOrganizationRole = organizationRoleUserModels.Where(x => x.IsDefault).FirstOrDefault();
            
            return userSessionModel;
        }

        
    }
}