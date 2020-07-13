using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class ENotificationMedium
    {
        private int _NotificationMediumID=0;
        private string _NotificationMedium=string.Empty;
        private string _Description=string.Empty;
        private DateTime _DateCreated;
        private DateTime _DateModified;


        /// <summary>
        /// Unique Notification Medium ID
        /// </summary>        
        public Int32 NotificationMediumID
        {
            get
            {
                return _NotificationMediumID;
            }
            set
            {
                _NotificationMediumID = value;
            }
        }

        /// <summary>
        /// Notification NotificationMedium Name 
        /// </summary>
        public string NotificationMedium
        {
            get
            {
                return _NotificationMedium;
            }
            set
            {
                _NotificationMedium = value;
            }
        }

        /// <summary>
        /// Notification Medium Description
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        ///  Notification Medium DateCreated
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                _DateCreated = value;
            }
        }

        /// <summary>
        ///  Notification Medium Date Modified
        /// </summary>
        public DateTime DateModified
        {
            get
            {
                return _DateModified;
            }
            set
            {
                _DateModified = value;
            }
        }
    }
}

