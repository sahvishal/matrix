namespace Falcon.Entity.Other
{
    public class EMarketingOrderShippingInfo
    {
        private int m_iMarketingOrderShippingInfoID = 0;
        private string m_strOrgName = string.Empty;
        private string m_strOrgUserFullname = string.Empty;
        private string m_strAddress1 = string.Empty;
        private string m_strAddress2 = string.Empty;
        private string m_strCity = string.Empty;


        private string m_strState = string.Empty;
        private string m_strZip = string.Empty;       
        private bool m_bolActive = true;

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _middleName = string.Empty;

        public string PhoneNumber { get; set; }
        /// <summary>
        /// Shipping Info ID
        /// </summary>
        
        public int MarketingOrderShippingInfoID
        {
            get
            {
                return m_iMarketingOrderShippingInfoID;
            }
            set
            {
                m_iMarketingOrderShippingInfoID = value;
            }
        }

        /// <summary>
        /// Organisation Name
        /// </summary>
        
        public string OrgName
        {
            get
            {
                return m_strOrgName;
            }
            set
            {
                m_strOrgName = value;
            }
        }
        /// <summary>
        /// Organisation user full name
        /// </summary>
        
        public string OrgUserFullname
        {
            get
            {
                return m_strOrgUserFullname;
            }
            set
            {
                m_strOrgUserFullname = value;
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
            get { return m_strState; }
            set { m_strState = value; }
        }

        /// <summary>
        /// Zip
        /// </summary>
        public string Zip
        {
            get
            {
                return m_strZip;
            }
            set
            {
                m_strZip = value;
            }
        }

        /// <summary>
        /// status of Item
        /// </summary>
        
        public bool Active
        {
            get
            {
                return m_bolActive;
            }
            set
            {
                m_bolActive = value;
            }
        }

        /// <summary>
        /// firstName
        /// </summary>
        public string FirstName
        {
            get{return _firstName;}
            set{_firstName = value;}
        }
        /// <summary>
        /// middleName
        /// </summary>
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        /// <summary>
        /// lastName
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

    }
}


