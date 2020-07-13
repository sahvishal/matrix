namespace Falcon.Entity.Other
{    
    public class ECreditCardType
    {
        private int m_iCreditCardTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive;

        /// <summary>
        /// 
        /// </summary>        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int CreditCardTypeID
        {
            get { return m_iCreditCardTypeID; }
            set { m_iCreditCardTypeID = value; }
        }
	


    }
}
