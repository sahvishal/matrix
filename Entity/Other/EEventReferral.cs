namespace Falcon.Entity.Other
{
    public class EEventReferral
    {
        private int m_iEventReferralID = 0;
        private int m_iEventID=0;
        private string m_strOrganizationName = string.Empty;
        private string m_strContactPerson = string.Empty;
        private string m_strPhoneNumber = string.Empty;
        private bool m_bolUsed = true;
       
        public int EventReferralID
        {
            get
            {
                return m_iEventReferralID;
            }
            set
            {
                m_iEventReferralID = value;
            }
        }

       
        public int EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }
        }

        
        public string OrganizationName
        {
            get
            {
                return m_strOrganizationName;
            }
            set
            {
                m_strOrganizationName = value;
            }
        }

        
        public string ContactPerson
        {
            get
            {
                return m_strContactPerson;
            }
            set
            {
                m_strContactPerson = value;
            }
        }

        
        public string PhoneNumber
        {
            get
            {
                return m_strPhoneNumber;
            }
            set
            {
                m_strPhoneNumber = value;
            }
        }

        
        public bool Used
        {
            get
            {
                return m_bolUsed;
            }
            set
            {
                m_bolUsed = value;
            }
        }
    }
}
