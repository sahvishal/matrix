namespace Falcon.Entity.Other
{
    public class EHostContacts
    {
        private int m_iContactID = 0;
        private string m_strTitle = string.Empty;
        private string m_strFirstName = string.Empty;
        private string m_strMiddleName = string.Empty;
        private string m_strLastName = string.Empty;
        private string m_strPhone1 = string.Empty;
        private string m_strPhone1Extension = string.Empty;
        private string m_strPhone2 = string.Empty;
        private string m_strPhone2Extension = string.Empty;
        private string m_strFax = string.Empty;
        private string m_strEMail = string.Empty;
        private int m_iAddedBY = 0;
        private int m_iModifiedBY = 0;
        private bool m_bolPrimary = false;

        /// <summary>
        /// unique contact id
        /// </summary>
        
        public int ContactID
        {
            get
            {
                return m_iContactID;
            }
            set
            {
                m_iContactID = value;
            }
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
        /// phone
        /// </summary>
        
        public string Phone1
        {
            get
            {
                return m_strPhone1;
            }
            set
            {
                m_strPhone1 = value;
            }
        }

        /// <summary>
        /// phone extension
        /// </summary>
        
        public string Phone1Extension
        {
            get
            {
                return m_strPhone1Extension;
            }
            set
            {
                m_strPhone1Extension = value;
            }
        }

        /// <summary>
        /// phone 2
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
        /// phone extension
        /// </summary>
        
        public string Phone2Extension
        {
            get
            {
                return m_strPhone2Extension;
            }
            set
            {
                m_strPhone2Extension = value;
            }
        }

        /// <summary>
        /// Fax
        /// </summary>
        
        public string Fax
        {
            get
            {
                return m_strFax;
            }
            set
            {
                m_strFax = value;
            }
        }

        /// <summary>
        /// Email Address 
        /// </summary>
        
        public string EMail
        {
            get
            {
                return m_strEMail;
            }
            set
            {
                m_strEMail = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public int AddedBY
        {
            get
            {
                return m_iAddedBY;
            }
            set
            {
                m_iAddedBY = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public int ModifiedBY
        {
            get
            {
                return m_iModifiedBY;
            }
            set
            {
                m_iModifiedBY = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;
            }
        }

        /// <summary>
        /// flag for primary contact
        /// </summary>
        
        public bool Primary
        {
            get
            {
                return m_bolPrimary;
            }
            set
            {
                m_bolPrimary = value;
            }
        }
    }
}
