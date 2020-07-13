using System;

namespace Falcon.Entity.Other
{    
    public class ECashPaymentDetail
    {
        private int m_iCashPaymentDetailID = 0;
        private decimal m_dCashAmount = 0;
        private string m_strdescription = string.Empty;
        private string m_strPaymentStatus = string.Empty;
        private Int32 m_iPaymentID = 0;
        private bool m_bolDrorCr;

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
        
        public int CashPaymentDetailID
        {
            get
            {
                return m_iCashPaymentDetailID;
            }
            set
            {
                m_iCashPaymentDetailID = value;
            }
        }

        
        public decimal CashAmount
        {
            get
            {
                return m_dCashAmount;
            }
            set
            {
                m_dCashAmount = value;
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

    }
}
