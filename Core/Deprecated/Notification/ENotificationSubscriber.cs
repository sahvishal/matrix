using System;

namespace Falcon.App.Core.Deprecated.Notification
{
    public class ENotificationSubscriber
    {
        private Int64 _NotificationSubscriberID = 0;
        private int _NotificationTypeID = 0;
        private string _Name = string.Empty;
        private string _Email = string.Empty;
        private string _Phone = string.Empty;
        private Int64 _userid = 0;
        private int _iTotalRecord = 0;

        public Int64 NotificationSubscriberID
        {
            get
            {
                return _NotificationSubscriberID;
            }
            set
            {
                _NotificationSubscriberID = value;
            }
        }

        
        public int NotificationTypeID
        {
            get
            {
                return _NotificationTypeID;
            }
            set
            {
                _NotificationTypeID = value;
            }
        }

        
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name= value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone= value;
            }
        }

        public Int64 UserId
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        
        public int TotalRecord
        {
            get
            {
                return _iTotalRecord;
            }
            set
            {
                _iTotalRecord = value;
            }
        }
        
    }


}
