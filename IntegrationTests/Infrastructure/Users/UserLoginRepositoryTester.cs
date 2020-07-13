using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class UserLoginRepositoryTester
    {
       

        [Test]
        public void GetRolesForUser()
        {
            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            var roles = userLoginRepository.GetRolesForUser("nitintikkha");
            var roles1 = userLoginRepository.GetRolesForUser("nitintikkha1");
        }

       
    }
}