using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class OrganizationRoleUserRepositoryTester
    {
        private IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private const long VAILD_USER_ID = 1;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            _organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
        }


        [Test]
        public void GetOrganizationRoleUsersReturnsUsers()
        {
            var organizationRoleUserIds = new List<long> {1, 2, 3};
            List<OrganizationRoleUser> organizationRoleUsers = _organizationRoleUserRepository.
                GetOrganizationRoleUsers(organizationRoleUserIds);

            Assert.IsNotNull(organizationRoleUsers, "Null collection of Organization Role Users returned.");
            Assert.IsNotEmpty(organizationRoleUsers, "Empty collection of Organization Role Users returned.");
        }

        [Test]
        public void DeactivateAllOrganizationRolesForUser()
        {
            _organizationRoleUserRepository.DeactivateAllOrganizationRolesForUser(VAILD_USER_ID);

            var orgRoles = _organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(VAILD_USER_ID);

            Assert.AreEqual(0,orgRoles.Length);

        }
    }
}