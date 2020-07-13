using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.UI.Users
{
    [TestFixture]
    public class UserControllerTester
    {
        
        public UserControllerTester()
        {
            DependencyRegistrar.RegisterDependencies();

        }

        
        [Test]
        public void CreateOnPostSavesCorrectly()
        {
            
        }

    }
}