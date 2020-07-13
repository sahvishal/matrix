using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class UserListModelRepositoryTester
    {
        private IUsersListModelRepository _organizationUsersModelRepository;
        private const Roles VALID_ROLE_Type = Roles.CallCenterRep;

        private const Roles INVALID_ROLE_Type = (Roles) 123;

        
        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            _organizationUsersModelRepository = IoC.Resolve<IUsersListModelRepository>();
        }


        [Test]       
        public void GetUserListModelByRoleReturnsNotNullForValidRole()
        {                        

            var users = _organizationUsersModelRepository.GetUserListModelByRole(VALID_ROLE_Type);
            Assert.IsNotNull(users.Collection);
        }

        [Test]
        public void GetUserListModelByRoleReturns1UserForValidRole()
        {
            const string expectedValue = "Bidhan";

            var users = _organizationUsersModelRepository.GetUserListModelByRole(VALID_ROLE_Type);
            
            Assert.AreEqual(expectedValue,users.Collection.ToList().First().Name);
        }

        [Test]
        public void GetUsersBasedonValidOrgTypeAndSearchCondition()
        {
            
            var users = _organizationUsersModelRepository.GetUserListModelByRole(VALID_ROLE_Type, "Bidhan");

            Assert.IsNotNull(users);
        }

        [Test]
        public void GetUsersBasedonInValidOrgType()
        {                        
            var users = _organizationUsersModelRepository.GetUserListModelByRole(INVALID_ROLE_Type);

            Assert.IsNull(users.Collection);
        }    
    }
}