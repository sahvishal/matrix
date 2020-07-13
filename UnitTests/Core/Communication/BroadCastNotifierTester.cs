using Falcon.App.Core.Communication.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.UnitTests.Core.Communication
{
    [TestFixture]
    public class BroadcastNotifierTester
    {
        [SetUp]
        public void SetUp()
        {
            var notificationTypeRepository = MockRepository.GenerateMock<INotificationTypeRepository>();
            var notificationSubscriberRepository = MockRepository.GenerateMock<INotificationSubscriberRepository>();
            //var notificationSubscriberRepository = MockRepository.GenerateMock<INotificationSubscriberRepository>();

            //new Notifier(notificationRepository, )
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}