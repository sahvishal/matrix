using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class ENotificationOther
    {
        private Int64 _NotificationID = 0;
        private Int64 _NotificationPhoneID = 0;
        private Int64 _UserID = 0;
        private Int64 _CustomerID = 0;
        private string _CustomerName = string.Empty;
        private string _Email = string.Empty;
        private Int64 _AttemptCount = 0;
        private string _ServicedBy = string.Empty;
        private string _Gender = string.Empty;
        private string _Dob = string.Empty;
        private string _Username = string.Empty;
        private string _Address = string.Empty;
        private string _PhoneNo = string.Empty;
        private string _PhoneOffice = string.Empty;
        private string _PhoneCell = string.Empty;
        private string _PhoneHome = string.Empty;
        private string _SignUpDate = string.Empty;
        private string _LastLoginDate = string.Empty;
        private string _NotificationDate = string.Empty;
        private string _NotificationType = string.Empty;
        private string _NotificationMedium = string.Empty;
        private string _ServiceStatus = string.Empty;
        private string _MailSubject = string.Empty;
        private string _MailBody = string.Empty;
        private string _ImagePath = string.Empty;
        private string _Source = string.Empty;
        private string _CCRep = string.Empty;
        private string _CallType = string.Empty;
        private string _CallDuration = string.Empty;
        private Int64 _CallId = 0;

        public Int64 SalesRepId { get; set; }
        public string SalesRep { get; set; }

        public string Notes { get; set; }
        public bool? IsInvalidAddress { get; set; }
        public string IsCallQueueCall { get; set; }

        /// <summary>
        /// ProspectCustomerID
        /// </summary>
        public int ProspectCustomerId { get; set; }

        /// <summary>
        /// Prospect Customer Tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Unique Notification Type ID
        /// </summary>
        public Int64 NotificationID
        {
            get
            {
                return _NotificationID;
            }
            set
            {
                _NotificationID = value;
            }
        }

        /// <summary>
        /// Unique Notification PhoneID
        /// </summary>
        public Int64 NotificationPhoneID
        {
            get
            {
                return _NotificationPhoneID;
            }
            set
            {
                _NotificationPhoneID = value;
            }
        }

        /// <summary>
        /// User ID
        /// </summary>
        public Int64 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        /// <summary>
        /// Customer ID 
        /// </summary>
        public Int64 CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        /// <summary>
        ///  Customer Name
        /// </summary>
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }

        /// <summary>
        /// Customer Email Address
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
        /// Attempt Count 
        /// </summary>
        public Int64 AttemptCount
        {
            get
            {
                return _AttemptCount;
            }
            set
            {
                _AttemptCount = value;
            }
        }

        /// <summary>
        /// Notification Serviced By
        /// </summary>
        public string ServicedBy
        {
            get
            {
                return _ServicedBy;
            }
            set
            {
                _ServicedBy = value;
            }
        }

        /// <summary>
        /// Customer Gender
        /// </summary>
        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        /// <summary>
        /// Customer Date Of Brith
        /// </summary>
        public string Dob
        {
            get
            {
                return _Dob;
            }
            set
            {
                _Dob = value;
            }
        }
        /// <summary>
        /// User Name 
        /// </summary>
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        /// <summary>
        /// Customer Address
        /// </summary>
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        /// <summary>
        /// Customer Phone Number 
        /// </summary>
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }
        /// <summary>
        /// Customer Phone Cell
        /// </summary>
        public string PhoneCell
        {
            get
            {
                return _PhoneCell;
            }
            set
            {
                _PhoneCell = value;
            }
        }

        /// <summary>
        /// Customer Phone Office
        /// </summary>
        public string PhoneOffice
        {
            get
            {
                return _PhoneOffice;
            }
            set
            {
                _PhoneOffice = value;
            }
        }

        /// <summary>
        /// Customer Phone home
        /// </summary>
        public string PhoneHome
        {
            get
            {
                return _PhoneHome;
            }
            set
            {
                _PhoneHome = value;
            }
        }


        /// <summary>
        /// Customer SignUp Date
        /// </summary>
        public string SignUpDate
        {
            get
            {
                return _SignUpDate;
            }
            set
            {
                _SignUpDate = value;
            }
        }

        /// <summary>
        /// Customer Last Login Date
        /// </summary>
        public string LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                _LastLoginDate = value;
            }
        }

        /// <summary>
        /// Notification Date 
        /// </summary>
        public string NotificationDate
        {
            get
            {
                return _NotificationDate;
            }
            set
            {
                _NotificationDate = value;
            }
        }
        /// <summary>
        /// Notification Type 
        /// </summary>
        public string NotificationType
        {
            get
            {
                return _NotificationType;
            }
            set
            {
                _NotificationType = value;
            }
        }
        /// <summary>
        /// Notification Medium
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
        /// Service Status
        /// </summary>
        public string ServiceStatus
        {
            get
            {
                return _ServiceStatus;
            }
            set
            {
                _ServiceStatus = value;
            }
        }

        /// <summary>
        /// Notification Email Subject
        /// </summary>
        public string MailSubject
        {
            get
            {
                return _MailSubject;
            }
            set
            {
                _MailSubject = value;
            }
        }
        /// <summary>
        /// Notification Email Body
        /// </summary>
        public string MailBody
        {
            get
            {
                return _MailBody;
            }
            set
            {
                _MailBody = value;
            }
        }
        /// <summary>
        /// Customer Image Path
        /// </summary>
        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                _ImagePath = value;
            }
        }

        /// <summary>
        /// CallNotes
        /// </summary>
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }

        /// <summary>
        /// CCRep
        /// </summary>
        public string CCRep
        {
            get
            {
                return _CCRep;
            }
            set
            {
                _CCRep = value;
            }
        }

        /// <summary>
        /// CallType
        /// </summary>
        public string CallType
        {
            get
            {
                return _CallType;
            }
            set
            {
                _CallType = value;
            }
        }

        /// <summary>
        /// CallDuration
        /// </summary>
        public string CallDuration
        {
            get
            {
                return _CallDuration;
            }
            set
            {
                _CallDuration = value;
            }
        }

        public long CallOutcome { get; set; }
        public string Disposition { get; set; }

        public long NotInterestedReasonId { get; set; }
        public Int64 CallId
        {
            get
            {
                return _CallId;
            }
            set
            {
                _CallId = value;
            }
        }
    }
}

