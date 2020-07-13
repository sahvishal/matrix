using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Domain
{
    public class NotificationPhone : Notification
    {
        public NotificationPhone(long id)
            : base(id)
        { }

        public NotificationPhone() { }

        public PhoneNumber PhoneCell { get; set; }
        public string Message { get; set; }
        public long? ServicedBy { get; set; }

    }
}