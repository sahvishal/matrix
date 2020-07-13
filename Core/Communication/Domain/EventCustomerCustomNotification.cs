namespace Falcon.App.Core.Communication.Domain
{
    public class EventCustomerCustomNotification
    {
        public long CustomEventNotificationId { get; set; }
        public long EventCustomerId { get; set; }
        public string Message { get; set; }
    }
}
