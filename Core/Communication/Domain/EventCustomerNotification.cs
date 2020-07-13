namespace Falcon.App.Core.Communication.Domain
{
    public class EventCustomerNotification
    {
        public long EventCustomerId { get; set; }
        public long NotificationId { get; set; }
        public long NotificationTypeId { get; set; }
    }

}
