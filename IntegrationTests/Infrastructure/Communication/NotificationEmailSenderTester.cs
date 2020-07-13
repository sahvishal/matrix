using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Communication;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication
{
    [TestFixture]
    public class NotificationEmailSenderTester
    {
        [Test]
       public void SendsOneEmail()
        {

            //DependencyRegistrar.RegisterDependencies();
            IoC.Register<ISmtpCredentials, FakeSmtpCredentials>();
            IoC.Register<INotificationEmailSender, NotificationEmailSender>();
            var notificationEmailSender = IoC.Resolve<INotificationEmailSender>();

            var emailMessage = new EmailMessage
            {
                Body = "Hello",
                FromEmail = "support@taazaa.com",
                FromName = "Support",
                Subject = "Test Message",
                ToEmail = "Bidhan_Baruah@hotmail.com"
            };
            notificationEmailSender.SendEmail(emailMessage);
        }
    }
}