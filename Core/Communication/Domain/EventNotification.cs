namespace Falcon.App.Core.Communication.Domain
{
    public class EventNotification
    {
        public long EventId { get; set; }
        public long NotificationId { get; set; }
        public bool IsForCorporateAccount { get; set; }
    }
}
