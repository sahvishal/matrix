using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication.NotificationRepositoryTests
{
    [TestFixture]
    public class GetTester
    {
        [Test]
        [Ignore("Should not depend on the existence of email notification with Id of 1")]
        public void GetNotificationEmailByIdTester()
        {
            DependencyRegistrar.RegisterDependencies();
            var emailTemplate = IoC.Resolve<INotificationRepository>().GetEmailNotificationById(1);

            Assert.IsNotEmpty(emailTemplate.Body);
        }

    }
}