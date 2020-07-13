using System;

namespace Falcon.App.Core.Deprecated.Notification
{
    public class NotificationEntity
    {
        private Int64 _NotificationID=0;
        private Int64 _RequestedBy=0;
        private Int64 _UserID;
        private DateTime _NotificationDate;
        private int _NotificationMediumID = 0;
        private int _NotificationTypeID = 0;
        private string _NotificationMedium = string.Empty;
        private string _NotificationType = string.Empty;
        private string _ClientLabel = string.Empty;
        private int _Priority = 0;
        private int _AttemptCount = 0;
        private short _ServiceStatus = 0;
        private DateTime _ServicedDate;
        private DateTime _DateCreated ;
        private string _Notes = string.Empty;
        private NotificationEmailEntity objNotificationEmailEntity =new NotificationEmailEntity();

        public NotificationEntity()
        {
        }

        public Int64 NotificationID
        {
            get { return _NotificationID; }
            set { _NotificationID = value; }
        }

        public Int64 RequestedBy
        {
            get { return _RequestedBy; }
            set { _RequestedBy = value; }
        }

        public Int64 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public DateTime NotificationDate
        {
            get { return _NotificationDate; }
            set { _NotificationDate = value; }
        }
        public int NotificationMediumID
        {
            get { return _NotificationMediumID; }
            set { _NotificationMediumID = value; }
        }
        public int NotificationTypeID
        {
            get { return _NotificationTypeID; }
            set { _NotificationTypeID = value; }
        }
        public string NotificationMedium
        {
            get { return _NotificationMedium; }
            set { _NotificationMedium = value; }
        }
        public string NotificationType
        {
            get { return _NotificationType; }
            set { _NotificationType = value; }
        }

        public string ClientLabel
        {
            get { return _ClientLabel; }
            set { _ClientLabel = value; }
        }
        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        public int AttemptCount
        {
            get { return _AttemptCount; }
            set { _AttemptCount = value; }
        }
        public short ServiceStatus
        {
            get { return _ServiceStatus; }
            set { _ServiceStatus = value; }
        }
        public DateTime ServicedDate
        {
            get { return _ServicedDate; }
            set { _ServicedDate = value; }
        }
        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public NotificationEmailEntity NotificationEmail
        {
            get { return objNotificationEmailEntity; }
            set { objNotificationEmailEntity = value; }
        }
                
        
    }
}
