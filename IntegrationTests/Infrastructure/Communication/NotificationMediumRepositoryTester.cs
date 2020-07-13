using System.Linq;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication
{
    [TestFixture]
    public class NotificationMediumRepositoryTester
    {
        [Test]
        public void DoesNotReturnNullRecords()
        {
            DependencyRegistrar.RegisterDependencies();

            var notificationMediumRepository = IoC.Resolve<INotificationMediumRepository>();

            var notificationMediums = notificationMediumRepository.GetAll();

            Assert.IsFalse(notificationMediums.Any(x => string.IsNullOrEmpty(x.Medium)));
        }
    }
}