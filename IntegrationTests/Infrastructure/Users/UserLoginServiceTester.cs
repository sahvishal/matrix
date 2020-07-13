using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class UserLoginServiceTester
    {
        private const string VALID_USER_NAME = "admin";
        private const string INVALID_USER_NAME = "baltar_888";
        private const int SWITCH_TO_ROLE = 1;
        private const int SWITCH_TO_ORG = 1;

        private  IUserLoginService _userLoginService;

        public UserLoginServiceTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _userLoginService = IoC.Resolve<IUserLoginService>();
        }
        
        
        [Test]
        public void Get_DoesNotReturnNullForValidUserName()
        {
            
                        
            var actualUserSession = _userLoginService.GetUserSessionModel(VALID_USER_NAME);

            //test
            Assert.IsNotNull(actualUserSession);
        }

        [Test]
        public void Get_ReturnsValidSessionForValidUserName()
        {

            var actualUserSession = _userLoginService.GetUserSessionModel(VALID_USER_NAME);
            //test
            Assert.AreEqual(1,actualUserSession.CurrentOrganizationRole.RoleId);            
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<UserSessionModel>))]        
        public void Get_ReturnValidExceptionForUnknownUser()
        {

            var actualUserSession = _userLoginService.GetUserSessionModel(INVALID_USER_NAME);

            //test
            Assert.IsNull(actualUserSession);
        }

        [Test]
        public void SwitchRole_ReturnsCorrectCurrentRole()
        {
            // It should be in the Unit Test
            //Set Up data
            var currentSession = new UserSessionModel
                                     {
                                         CurrentOrganizationRole = new OrganizationRoleUserModel
                                                                       {
                                                                           OrganizationId = 6,
                                                                           OrganizationName = "ABC Corporation6",
                                                                           OrganizationRoleUserId = 66,
                                                                           RoleAlias = "Aliase7",
                                                                           RoleDisplayName = "Display6",
                                                                           RoleId = 6
                                                                       },
                                         FirstName = "John",
                                         LastName = "Doe",
                                         UserId = 11,
                                         UserName = "John.Doe",
                                         AvailableOrganizationRoles = new OrganizationRoleUserModel[5]
                                     };



            for(var fillOrg = 0 ; fillOrg <5;fillOrg++ )
            {
                currentSession.AvailableOrganizationRoles[fillOrg] = new OrganizationRoleUserModel
                                                                         {
                                                                             OrganizationId = fillOrg,
                                                                             OrganizationName = "ABC Corporation" + fillOrg,
                                                                             OrganizationRoleUserId = fillOrg + fillOrg,
                                                                             RoleAlias = "Aliase" + fillOrg,
                                                                             RoleDisplayName = "Display" + fillOrg,
                                                                             RoleId = fillOrg
                                                                         };
                ;
            }

            

                      
            currentSession  = _userLoginService.SwitchOrganizationRole(currentSession, SWITCH_TO_ROLE, SWITCH_TO_ORG);

            //Test
            Assert.AreEqual(currentSession.CurrentOrganizationRole.RoleId,SWITCH_TO_ROLE );

        }

    }
}