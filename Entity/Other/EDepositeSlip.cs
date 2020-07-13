using System;

namespace Falcon.Entity.Other
{
    public class EDepositeSlip
    {
        private Int64 m_SerialNo = 0;
        private string m_CustomerName = string.Empty;
        private string m_PaymentType = string.Empty;
        private double m_PaymentAmount = 0.0;
        private string m_TotalAmount = string.Empty;
        private string m_TotalAmountCash = string.Empty;
        private string m_TotalAmountCheck = string.Empty;
        private string m_ChequeNumber = string.Empty;
        private string m_RoutingNumber = string.Empty;
        private string m_AccountNumber = string.Empty;
        
        public Int64 SerialNo
        {
            get
            {
                return m_SerialNo;
            }
            set
            {
                m_SerialNo = value;
            }
        }
        
        public string ChequeNumber
        {
            get
            {
                return m_ChequeNumber;
            }
            set
            {
                m_ChequeNumber = value;
            }
        }
        
        public string RoutingNumber
        {
            get
            {
                return m_RoutingNumber;
            }
            set
            {
                m_RoutingNumber = value;
            }
        }
        
        public string AccountNumber
        {
            get
            {
                return m_AccountNumber;
            }
            set
            {
                m_AccountNumber = value;
            }
        }
        
        
        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                m_CustomerName = value;
            }
        }
        
        public string PaymentType
        {
            get
            {
                return m_PaymentType;
            }
            set
            {
                m_PaymentType = value;
            }
        }

        
        public double PaymentAmount
        {
            get
            {
                return m_PaymentAmount;
            }
            set
            {
                m_PaymentAmount = value;
            }
        }

        
        public string TotalAmount
        {
            get
            {
                return m_TotalAmount;
            }
            set
            {
                m_TotalAmount = value;
            }
        }
        
        public string TotalAmountCash
        {
            get
            {
                return m_TotalAmountCash;
            }
            set
            {
                m_TotalAmountCash = value;
            }
        }

        
        public string TotalAmountCheck
        {
            get
            {
                return m_TotalAmountCheck;
            }
            set
            {
                m_TotalAmountCheck = value;
            }
        }
    }
}
