namespace Falcon.Entity.Other
{   
    
    public class EPaymentFrequency
    {
        private int m_iPaymentFrequencyID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strPayDate = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique PaymentFrequency id
        /// </summary>
        
        public int PaymentFrequencyID
        {
            get
            {
                return m_iPaymentFrequencyID;
            }
            set
            {
                m_iPaymentFrequencyID = value;
            }
        }
        /// <summary>
        /// Payment name
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
        /// PaymentFrequency description
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
        /// Payment Date
        /// </summary>
        
        public string PayDate
        {
            get
            {
                return m_strPayDate;
            }
            set
            {
                m_strPayDate = value;
            }
        }
        /// <summary>
        /// PaymentFrequency status
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
