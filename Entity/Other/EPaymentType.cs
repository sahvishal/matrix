namespace Falcon.Entity.Other
{   
    
    public class EPaymentType
    {
        private int m_iPaymentTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique PaymentType id
        /// </summary>
        
        public int PaymentTypeID
        {
            get
            {
                return m_iPaymentTypeID;
            }
            set
            {
                m_iPaymentTypeID = value;
            }
        }

        /// <summary>
        /// PaymentType name
        /// </summary>
        
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        /// <summary>
        /// PaymentType description
        /// </summary>
        
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        /// <summary>
        /// PaymentType status
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
    }
}
