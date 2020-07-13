using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.Web.IntegrationTests.Fakes
{
    public class FakeSessionContext :  ISessionContext
    {
        public FakeSessionContext()
        {
            UserSession = new UserSessionModel
            {
                CurrentOrganizationRole = new OrganizationRoleUserModel
                {
                    OrganizationId = 1,
                    OrganizationRoleUserId = 1,
                    RoleId = 1,
                    UserId = 1
                },
                UserId = 1,
                FirstName = "Taazaa",
                LastName = "Support",
                UserName = "admin"
            };
        }

        public UserSessionModel UserSession { get; set; }

        public string LastLoggedInTime
        {
            get { return DateTime.Today.ToString(); }
            set { throw new NotImplementedException(); }
        }
    }
}