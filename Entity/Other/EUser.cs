       
using System;

namespace Falcon.Entity.Other
{   
    //TODO Remove this
    [Serializable]
    public class EUser
    {   
        
        private string m_strFirstName = string.Empty;
        private string m_strMiddleName = string.Empty;
        private string m_strLastName = string.Empty;
        private string m_strPhoneCell = string.Empty;
        private string m_strPhoneHome = string.Empty;
        private string m_strPhoneOffice = string.Empty;
        private string m_strEMail1 = string.Empty;
        private string m_strEMail2 = string.Empty;
        private string m_strSSN = string.Empty;
        private string m_strDOB = string.Empty;
        private string m_strDateCreated = string.Empty;
        private DateTime m_strDateApplied;
        private EAddress m_objHomeAddress;
        private string m_strUserName = string.Empty;
        private string m_strQuestion = string.Empty;
        private string m_strAnswer = string.Empty;
        private string m_strPassword = string.Empty;
        private string m_strTrackingMarketing = null;
        private string m_strGender = string.Empty;
        private ELogin m_objLogin;
        private int m_LeadCount = 0;
        private int m_SignUpCount = 0;

        public string DigitalSignatureImage { get; set; }
                
        /// <summary>
        /// unique user id
        /// </summary>
        
        public long UserID
        {
            get; set;
        }



        /// <summary>
        /// first name
        /// </summary>
        
        public string FirstName
        {
            get
            {
                return m_strFirstName;
            }
            set
            {
                m_strFirstName = value;
            }
        }

        /// <summary>
        /// middle name
        /// </summary>
        
        public string MiddleName
        {
            get
            {
                return m_strMiddleName;
            }
            set
            {
                m_strMiddleName = value;
            }
        }

        /// <summary>
        /// last name
        /// </summary>
        
        public string LastName
        {
            get
            {
                return m_strLastName;
            }
            set
            {
                m_strLastName = value;
            }
        }

        /// <summary>
        /// phone office
        /// </summary>
        
        public string PhoneOffice
        {
            get
            {
                return m_strPhoneOffice;
            }
            set
            {
                m_strPhoneOffice = PhoneFormat.FormatPhoneNumber(value);
            }
        }

        /// <summary>
        /// phone home
        /// </summary>
        
        public string PhoneHome
        {
            get
            {
                return m_strPhoneHome;
            }
            set
            {
                m_strPhoneHome = PhoneFormat.FormatPhoneNumber(value);
            }
        }

        /// <summary>
        /// phone cell
        /// </summary>
        
        public string PhoneCell
        {
            get
            {
                return m_strPhoneCell;
            }
            set
            {
                m_strPhoneCell = PhoneFormat.FormatPhoneNumber(value);
            }
        }

        /// <summary>
        /// Email(1) Address 
        /// </summary>
        
        public string EMail1
        {
            get
            {
                return m_strEMail1;
            }
            set
            {
                m_strEMail1 = value;
            }
        }

        /// <summary>
        /// EMail(2) address
        /// </summary>
        
        public string EMail2
        {
            get
            {
                return m_strEMail2;
            }
            set
            {
                m_strEMail2 = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public EAddress HomeAddress
        {
            get { return m_objHomeAddress; }
            set { m_objHomeAddress = value; }
        }

        /// <summary>
        /// SSN number of the  user
        /// </summary>
        
        public String SSN
        {
            get { return m_strSSN; }
            set { m_strSSN = value; }
        }
        /// <summary>
        /// Date of Birth of the  user
        /// </summary>
        
        public String DOB
        {
            get { return m_strDOB; }
            set { m_strDOB = value; }
        }

        /// <summary>
        /// Date of Birth of the  user
        /// </summary>
        
        public String DateCreated
        {
            get { return m_strDateCreated; }
            set { m_strDateCreated = value; }
        }
        /// <summary>
        /// Date of creation of the user
        /// </summary>
        
        public DateTime DateApplied
        {
            get { return m_strDateApplied; }
            set { m_strDateApplied = value; }
        }


        /// <summary>
        /// UserName for login (If Email is not spacefied)
        /// </summary>
        
        public string UserName
        {
            get
            {
                return m_strUserName;
            }
            set
            {
                m_strUserName = value;
            }
        }

        /// <summary>
        /// Security Question for Registration 
        /// </summary>
        
        public string Question
        {
            get
            {
                return m_strQuestion;
            }
            set
            {
                m_strQuestion = value;
            }
        }

        /// <summary>
        /// Security Answer for registration
        /// </summary>
        
        public string Answer
        {
            get
            {
                return m_strAnswer;
            }
            set
            {
                m_strAnswer = value;
            }
        }

        /// <summary>
        /// Security Answer for registration
        /// </summary>
        
        public string Password
        {
            get
            {
                return m_strPassword;
            }
            set
            {
                m_strPassword = value;
            }
        }

        
        public string TrackingMarketing
        {
            get { return m_strTrackingMarketing; }
            set { m_strTrackingMarketing = value; }
        }

        /// <summary>
        /// Gender
        /// </summary>
        
        public string Gender
        {
            get
            {
                return m_strGender;
            }
            set
            {
                m_strGender = value;
            }
        }

        /// <summary>
        /// Login Info
        /// </summary>

        
        public ELogin Login
        {
            get
            {
                return m_objLogin;
            }
            set
            {
                m_objLogin = value;
            }
        }

        /// <summary>
        /// Lead Count
        /// </summary>
        
        public int LeadCount
        {
            get
            {
                return m_LeadCount;
            }
            set
            {
                m_LeadCount = value;
            }
        }

        /// <summary>
        /// SignUp Count
        /// </summary>
        
        public int SignUpCount
        {
            get
            {
                return m_SignUpCount;
            }
            set
            {
                m_SignUpCount = value;
            }
        }

        public string PhoneOfficeExtension { get; set; }
    }
        
}
