using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Domain
{
    public class NotificationEmail : Notification
    {
        public NotificationEmail(long id) : base(id)
        { }

        public NotificationEmail() { }

        public Email ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Email FromEmail { get; set; }
        public string FromName { get; set; }
        public DateTime? OpenedDate { get; set; }
        public int OpenCount { get; set; }
        public string AttachmentPath { get; set; }
    }
}