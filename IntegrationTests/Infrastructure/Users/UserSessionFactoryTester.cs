using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using NUnit.Framework;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class UserSessionFactoryTester
    {
        [Test]
        public void UserSessionCreateSavesDataCorrectly()
        {
            var userSessionFactory = IoC.Resolve<IUserSessionModelFactory>();
            //long validUserID = 1058;
            //long validRoldId = 1;

            //execution
            UserSessionModel actualUserSession = null; //userSessionFactory.Create(validUserID, validRoldId); // TODO: Need to correct this.


            //assert or test
            Assert.AreEqual("yasirdrabu",actualUserSession.UserName);
            Assert.AreEqual(51, actualUserSession.UserName);

        }
    }
}