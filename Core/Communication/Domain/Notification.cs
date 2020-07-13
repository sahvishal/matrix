using System;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class Notification : DomainObjectBase
    {
        public Notification() { }

        public Notification(long id) : base(id)
        { }

        public long RequestedBy { get; set; }
        public long UserId { get; set; }
        
        public DateTime NotificationDate { get; set; }
        public NotificationMedium NotificationMedium { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Source { get; set; }
        public int Priority { get; set; }
        public int AttemptCount { get; set; }
        public NotificationServiceStatus ServiceStatus { get; set; }
        public DateTime? ServicedDate { get; set; }
        public DateTime DateCreated { get; set; }
        public string Notes { get; set; }
    }
}