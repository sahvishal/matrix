using System;

namespace Falcon.Entity.Other
{
    
    public class EChequePaymentDetail
    {
        private int m_iChequePaymentDetailID = 0;
        private string m_strChequeNumber = string.Empty;
        private string m_strRoutingNumber = string.Empty;
        private string m_strBankName = string.Empty;
        private string m_strdescription = string.Empty;
        private string m_strAccountNumber = string.Empty;
        private string m_strPaymentStatus = string.Empty;
        private Int32 m_iPaymentID = 0;
        private bool m_bolDrorCr;
        private string m_strAccountType = string.Empty;
        private string m_strAccountHolder = string.Empty;

        /// <summary>
        /// 
        /// </summary>        
        public bool DrorCr
        {
            get { return m_bolDrorCr; }
            set { m_bolDrorCr = value; }
        }
	


        /// <summary>
        /// 
        /// </summary>        
        public Int32 PaymentID
        {
            get { return m_iPaymentID; }
            set { m_iPaymentID = value; }
        }      

        
        public int ChequePaymentDetailID
        {
            get
            {
                return m_iChequePaymentDetailID;
            }
            set
            {
                m_iChequePaymentDetailID = value;
            }
        }
        
        public string ChequeNumber
        {
            get
            {
                return m_strChequeNumber;
            }
            set
            {
                m_strChequeNumber = value;
            }
        }

        
        public string RoutingNumber
        {
            get
            {
                return m_strRoutingNumber;
            }
            set
            {
                m_strRoutingNumber = value;
            }
        }
        
        public string BankName
        {
            get
            {
                return m_strBankName;
            }
            set
            {
                m_strBankName = value;
            }
        }
        
        public string AccountNumber
        {
            get
            {
                return m_strAccountNumber;
            }
            set
            {
                m_strAccountNumber = value;
            }
        }
        
        public string PaymentStatus
        {
            get
            {
                return m_strPaymentStatus;
            }
            set
            {
                m_strPaymentStatus = value;
            }
        }        
        
        public string Description
        {
            get
            {
                return m_strdescription;
            }
            set
            {
                m_strdescription = value;
            }
        }
        
        public string AccountType
        {
            get
            {
                return m_strAccountType;
            }
            set
            {
                m_strAccountType = value;
            }
        }

        
        public string AccountHolder
        {
            get
            {
                return m_strAccountHolder;
            }
            set
            {
                m_strAccountHolder = value;
            }
        }
      
    }
}
