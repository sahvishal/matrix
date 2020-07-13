using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class ENotificationSubscriber
    {
        private Int64 _NotificationSubscriberID = 0;
        private int _NotificationTypeID = 0;
        private string _Name = string.Empty;
        private string _Email = string.Empty;
        private string _Phone = string.Empty;
        private Int64 _userid = 0;
        private int _iTotalRecord = 0;

        /// <summary>
        /// Unique Notification Subscriber ID
        /// </summary>
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

        /// <summary>
        /// Notification Type ID
        /// </summary>
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

        /// <summary>
        /// Subscriber Name
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Subscriber Email
        /// </summary>
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

        /// <summary>
        /// Subscriber Phone
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }

        /// <summary>
        /// User ID 
        /// </summary>
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
        /// <summary>
        /// TotalRecord
        /// </summary>
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