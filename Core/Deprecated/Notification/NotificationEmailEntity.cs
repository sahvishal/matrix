using System;

namespace Falcon.App.Core.Deprecated.Notification
{
    public class NotificationEmailEntity
    {
        private Int64 _NotificationEmailID=0;
        private Int64 _NotificationID=0;
        private string _ToEmail=string.Empty;
        private string _Subject=string.Empty;
        private string _Body=string.Empty;
        private string _FromEmail=string.Empty;
        private string _FromName=string.Empty;
        private DateTime _OpenedDate;
        private int _OpenCount=0;
        private string _AttachmentPath = string.Empty;

        public Int64 NotificationEmailID
        {
            get { return _NotificationEmailID; }
            set { _NotificationEmailID = value; }
        }
        public Int64 NotificationID
        {
            get { return _NotificationID; }
            set { _NotificationID = value; }
        }
        public string ToEmail
        {
            get { return _ToEmail; }
            set { _ToEmail = value; }
        }
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        public string FromEmail
        {
            get { return _FromEmail; }
            set { _FromEmail = value; }
        }
        public string FromName
        {
            get { return _FromName; }
            set { _FromName = value; }
        }
        public DateTime OpenedDate
        {
            get { return _OpenedDate; }
            set { _OpenedDate = value; }
        }
        public int OpenCount
        {
            get { return _OpenCount; }
            set { _OpenCount = value; }
        }
        public string AttachmentPath 
        {
            get { return _AttachmentPath; }
            set { _AttachmentPath = value; }
        }
        
        
    }
}
