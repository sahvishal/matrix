using Falcon.App.Core.Communication.ViewModels;

namespace Falcon.App.Core.Communication
{
    public interface ISmsReceivedNotificationService
    {
        void SmsReceivedNotification(TwillioMessageResponse message);
    }
}
