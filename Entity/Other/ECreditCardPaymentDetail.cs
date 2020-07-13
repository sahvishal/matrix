namespace Falcon.Entity.Other
{

    public class ECreditCardPaymentDetail
    {
        private string m_strExpirationDate = string.Empty;
        private string m_strPaymentStatus = string.Empty;
        private int m_iPaymentID = 0;
        private string m_strCreditCardNumber = string.Empty;
        private int m_iCreditCardPaymentID = 0;
        private ECreditCardType m_objCreditCardType = null;
        private string m_strSecurityCode = string.Empty;
        private string m_strCardHolderName = string.Empty;
        private bool m_bolDrOrCr = false;

        private string m_strDesription = string.Empty;


        /// <summary>
        /// 
        /// </summary>        
        public bool DrOrCr
        {
            get { return m_bolDrOrCr; }
            set { m_bolDrOrCr = value; }
        }


        /// <summary>
        /// 
        /// </summary>       
        public string CardHolderName
        {
            get { return m_strCardHolderName; }
            set { m_strCardHolderName = value; }
        }      
        
        
        public string SecurityCode
        {
            get { return m_strSecurityCode; }
            set { m_strSecurityCode = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public ECreditCardType CreditCardType
        {
            get { return m_objCreditCardType; }
            set { m_objCreditCardType = value; }
        }
	

        /// <summary>
        /// 
        /// </summary>        
        public int CreditCardPaymentID
        {
            get { return m_iCreditCardPaymentID; }
            set { m_iCreditCardPaymentID = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string CreditCardNumber
        {
            get { return m_strCreditCardNumber; }
            set { m_strCreditCardNumber = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>          
        public int PaymentID
        {
            get { return m_iPaymentID; }
            set { m_iPaymentID = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string PaymentStatus
        {
            get { return m_strPaymentStatus; }
            set { m_strPaymentStatus = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>       
        public string ExpirationDate
        {
            get { return m_strExpirationDate; }
            set { m_strExpirationDate = value; }
        }

        /// <summary>
        /// Description
        /// </summary>        
        public string Description
        {
            get
            {
                return m_strDesription;
            }
            set
            {
                m_strDesription = value;
            }
        }
	
    }
}
