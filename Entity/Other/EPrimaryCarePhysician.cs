using System;

namespace Falcon.Entity.Other
{   
    //TODO Remove this.
    [Serializable]
    public class EPrimaryCarePhysician
    {
        private Int64 m_iPrimaryCarePhysicianID;
        private Int64 m_iCustomerID;
        private string m_strFirstName = string.Empty;
        private string m_strMiddleName = string.Empty;
        private string m_strLastName = string.Empty;
        private EAddress m_objPCPAddress;
        //private Int64 m_iPCPAddress;
        private string m_strPhoneNumber = string.Empty;
        private string m_strEmail = string.Empty;
        private bool m_bolSendEmail;

        private string m_strPhoneOther = string.Empty;
        private string m_strEmailOther = string.Empty;
        private string m_strWebsite = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        
        public bool SendEmail
        {
            get { return m_bolSendEmail; }
            set { m_bolSendEmail = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string Email
        {
            get { return m_strEmail; }
            set { m_strEmail = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string PhoneNumber
        {
            get { return m_strPhoneNumber; }
            set { m_strPhoneNumber = PhoneFormat.FormatPhoneNumber(value);}
        }
        
                
        /// <summary>
        /// 
        /// </summary>
        
        public EAddress PCPAddress
        {
            get { return m_objPCPAddress; }
            set { m_objPCPAddress = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string LastName
        {
            get { return m_strLastName; }
            set { m_strLastName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string MiddleName
        {
            get { return m_strMiddleName; }
            set { m_strMiddleName = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public string FirstName
        {
            get { return m_strFirstName; }
            set { m_strFirstName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public Int64 CustomerID
        {
            get { return m_iCustomerID; }
            set { m_iCustomerID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public Int64 PrimaryCarePhysicianID
        {
            get { return m_iPrimaryCarePhysicianID; }
            set { m_iPrimaryCarePhysicianID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string PhoneOther
        {
            get { return m_strPhoneOther; }
            set { m_strPhoneOther = PhoneFormat.FormatPhoneNumber(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string EmailOther
        {
            get { return m_strEmailOther; }
            set { m_strEmailOther = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Website
        {
            get { return m_strWebsite; }
            set { m_strWebsite = value; }
        }

        public string Fax { get; set; }
    }
}
