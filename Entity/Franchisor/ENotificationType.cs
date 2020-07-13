using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class ENotificationType
    {
        private Int64 _iNotificationTypeID = 0;
        private string _strNotificationTypeName = string.Empty;
        private string _strNotificationTypeNameAlias = string.Empty;
        private string _strDescription = string.Empty;
        private bool _bolIsStarted=false;
        private DateTime _dteDateCreated;
        private DateTime _dteDateModified;
        private bool _bolIsActive = false;
        private string _LastStatusChangedDate=string.Empty;
        private Int64 _iTotal;
        private Int64 _iServiced;
        private Int64 _iNotServiced;
        private string _strServiceStatus;
        private bool _bolEscalateToPhone=false;
        private int _iNoOfAttempts = 0;

        /// <summary>
        /// Unique Notification Type ID
        /// </summary>
        public Int64 NotificationTypeID
        {
            get
            {
                return _iNotificationTypeID;
            }
            set
            {
                _iNotificationTypeID = value;
            }
        }

        /// <summary>
        /// Notification Type Name
        /// </summary>
        public string NotificationTypeName
        {
            get
            {
                return _strNotificationTypeName;
            }
            set
            {
                _strNotificationTypeName = value;
            }
        }

        /// <summary>
        /// Notification Alias Type Name
        /// </summary>
        public string NotificationTypeNameAlias
        {
            get
            {
                return _strNotificationTypeNameAlias;
            }
            set
            {
                _strNotificationTypeNameAlias = value;
            }
        }

        /// <summary>
        ///  Notification Description
        /// </summary>
        public string Description
        {
            get
            {
                return _strDescription;
            }
            set
            {
                _strDescription = value;
            }
        }

        /// <summary>
        /// Notification Started Flag
        /// </summary>
        public bool IsStarted
        {
            get
            {
                return _bolIsStarted;
            }
            set
            {
                _bolIsStarted = value;
            }
        }
        /// <summary>
        /// Notification DateCreated
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                return _dteDateCreated;
            }
            set
            {
                _dteDateCreated = value;
            }
        }

        /// <summary>
        /// Notification DateModified
        /// </summary>
        public DateTime DateModified
        {
            get
            {
                return _dteDateModified;
            }
            set
            {
                _dteDateModified = value;
            }
        }

        /// <summary>
        /// Notification Record Active Status
        /// </summary>
        public bool IsActive
        {
            get
            {
                return _bolIsActive;
            }
            set
            {
                _bolIsActive = value;
            }
        }

        /// <summary>
        /// Notification Last Changes Status Date 
        /// </summary>
        public string LastStatusChangedDate
        {
            get
            {
                return _LastStatusChangedDate;
            }
            set
            {
                _LastStatusChangedDate = value;
            }
        }
        /// <summary>
        /// No. Of Notifications received by this service
        /// </summary>
        public Int64 Total
        {
            get
            {
                return _iTotal;
            }
            set
            {
                _iTotal = value;
            }
        }

        /// <summary>
        /// Serviced Notification 
        /// </summary>
        public Int64 Serviced
        {
            get
            {
                return _iServiced;
            }
            set
            {
                _iServiced = value;
            }
        }
        /// <summary>
        /// Not Serviced Notification 
        /// </summary>
        public Int64 NotServiced
        {
            get
            {
                return _iNotServiced;
            }
            set
            {
                _iNotServiced = value;
            }
        }

        /// <summary>
        /// Notification Service Status
        /// </summary>
        public string ServiceStatus
        {
            get
            {
                return _strServiceStatus;
            }
            set
            {
                _strServiceStatus = value;
            }
        }

        /// <summary>
        /// Esclate to Phone
        /// </summary>
        public bool EscalateToPhone
        {
            get
            {
                return _bolEscalateToPhone;
            }
            set
            {
                _bolEscalateToPhone = value;
            }
        }

        /// <summary>
        /// Esclate to Phone
        /// </summary>
        public int NoOfAttempts
        {
            get
            {
                return _iNoOfAttempts;
            }
            set
            {
                _iNoOfAttempts = value;
            }
        }

    }
}

