using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface INotificationEmailSender
    {
        void SendEmail(EmailMessage emailMessage);
    }
}