using System.Collections.Generic;

namespace Falcon.Entity.Other
{   
    
    public class EProspectCustomer
    {
        private int m_iProspectCustomerID = 0;
        private string m_strFirstName = string.Empty;
        private string m_strLastName = string.Empty;
        private string m_strZipCode = string.Empty;
        private string m_strCallbackNo = string.Empty;
        private int m_iCustomerID = 0;
        private string m_strDateCreated = string.Empty;
        private string m_strAddress1 = string.Empty;
        private string m_strAddress2 = string.Empty;
        private string m_strCity = string.Empty;
        private string m_strState = string.Empty;
        private string m_strDOB = string.Empty;
        private string m_strEmail = string.Empty;
        private string m_strPhone2 = string.Empty;
        private string m_strDateConverted = string.Empty;
        private bool m_bolIsConverted = false;
        private string m_strSource = string.Empty;
        private string m_strTag = string.Empty;
        private string m_strMarketingSource = string.Empty;
        private string m_strSourceCode = string.Empty;
        private string m_strIncomingPhoneLine = string.Empty;

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// ProspectCustomerID
        /// </summary>
        
        public int ProspectCustomerID
        {
            get
            {
                return m_iProspectCustomerID;
            }
            set
            {
                m_iProspectCustomerID = value;
            }
        }

        /// <summary>
        /// FirstName
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
        /// LastName
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
        /// ZipCode
        /// </summary>
        
        public string ZipCode
        {
            get
            {
                return m_strZipCode;
            }
            set
            {
                m_strZipCode = value;
            }
        }

        /// <summary>
        /// CallbackNo
        /// </summary>
        
        public string CallbackNo
        {
            get
            {
                return m_strCallbackNo;
            }
            set
            {
                m_strCallbackNo = value;
            }
        }

        /// <summary>
        /// CustomerID
        /// </summary>
        
        public int CustomerID
        {
            get
            {
                return m_iCustomerID;
            }
            set
            {
                m_iCustomerID = value;
            }
        }

        /// <summary>
        /// DateCreated
        /// </summary>
        
        public string DateCreated
        {
            get
            {
                return m_strDateCreated;
            }
            set
            {
                m_strDateCreated = value;
            }
        }

        /// <summary>
        /// Address1
        /// </summary>
        
        public string Address1
        {
            get
            {
                return m_strAddress1;
            }
            set
            {
                m_strAddress1 = value;
            }
        }

        /// <summary>
        /// Address2
        /// </summary>
        
        public string Address2
        {
            get
            {
                return m_strAddress2;
            }
            set
            {
                m_strAddress2 = value;
            }
        }

        /// <summary>
        /// City
        /// </summary>
        
        public string City
        {
            get
            {
                return m_strCity;
            }
            set
            {
                m_strCity = value;
            }
        }

        /// <summary>
        /// State
        /// </summary>
        
        public string State
        {
            get
            {
                return m_strState;
            }
            set
            {
                m_strState = value;
            }
        }

        /// <summary>
        /// DOB
        /// </summary>
        
        public string DOB
        {
            get
            {
                return m_strDOB;
            }
            set
            {
                m_strDOB = value;
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        
        public string Email
        {
            get
            {
                return m_strEmail;
            }
            set
            {
                m_strEmail = value;
            }
        }

        /// <summary>
        /// Phone2
        /// </summary>
        
        public string Phone2
        {
            get
            {
                return m_strPhone2;
            }
            set
            {
                m_strPhone2 = value;
            }
        }

        /// <summary>
        /// IsConverted
        /// </summary>
        
        public bool IsConverted
        {
            get
            {
                return m_bolIsConverted;
            }
            set
            {
                m_bolIsConverted = value;
            }
        }

        
        public string DateConverted
        {
            get
            {
                return m_strDateConverted;
            }
            set
            {
                m_strDateConverted = value;
            }
        }

        /// <summary>
        /// Source
        /// </summary>
        
        public string Source
        {
            get
            {
                return m_strSource;
            }
            set
            {
                m_strSource = value;
            }
        }

        /// <summary>
        /// Tag
        /// </summary>
        
        public string Tag
        {
            get
            {
                return m_strTag;
            }
            set
            {
                m_strTag = value;
            }
        }

        
        public string MarketingSource
        {
            get
            {
                return m_strMarketingSource;
            }
            set
            {
                m_strMarketingSource = value;
            }
        }

        /// <summary>
        /// SourceCode
        /// </summary>
        
        public string SourceCode
        {
            get
            {
                return m_strSourceCode;
            }
            set
            {
                m_strSourceCode = value;
            }
        }

        /// <summary>
        /// IncomingPhoneLine
        /// </summary>
        
        public string IncomingPhoneLine
        {
            get
            {
                return m_strIncomingPhoneLine;
            }
            set
            {
                m_strIncomingPhoneLine = value;
            }
        }
        public List<EContactCall> CallDetails{get;set;}
    }
    
}
