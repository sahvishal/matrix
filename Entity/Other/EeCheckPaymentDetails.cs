using System;

namespace Falcon.Entity.Other
{
    public class EECheckPaymentDetails
    {
        private int m_iECheckPaymentDetailID = 0;
        private string m_strRoutingNumber = string.Empty;
        private string m_strAccountNumber = string.Empty;
        private string m_strAccountType = string.Empty;
        private string m_strEChequeNumber = string.Empty;
        private string m_strBankName = string.Empty;
        private string m_strAccountHolder = string.Empty;
        private Int32 m_iPaymentID = 0;
        private string m_strPaymentStatus = string.Empty;
        private string m_strStatus = string.Empty;
        private bool m_bolDrorCr;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private string m_strTransactionID = string.Empty;

        
        public int EChequePaymentDetailID
        {
            get
            {
                return m_iECheckPaymentDetailID;
            }
            set
            {
                m_iECheckPaymentDetailID = value;
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

        
        public string EChequeNumber
        {
            get
            {
                return m_strEChequeNumber;
            }
            set
            {
                m_strEChequeNumber = value;
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

        /// <summary>
        /// 
        /// </summary>        
        public Int32 PaymentID
        {
            get { return m_iPaymentID; }
            set { m_iPaymentID = value; }
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

        
        public string Status
        {
            get
            {
                return m_strStatus;
            }
            set
            {
                m_strStatus = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool DrorCr
        {
            get { return m_bolDrorCr; }
            set { m_bolDrorCr = value; }
        }

        
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

        
        public string DateModified
        {
            get
            {
                return m_strDateModified;
            }
            set
            {
                m_strDateModified = value;
            }
        }

        
        public string TransactionID
        {
            get
            {
                return m_strTransactionID;
            }
            set
            {
                m_strTransactionID = value;
            }
        }
    }
}
