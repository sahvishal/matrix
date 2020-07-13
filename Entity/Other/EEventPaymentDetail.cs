using System;

namespace Falcon.Entity.Other
{
    public class EEventPaymentDetail
    {
        private int m_iEventPaymentID = 0;
        private EPaymentDetail m_objPaymentDetail;
        private int m_iPayRecieverUserID = 0;
        private Boolean m_bolOnsite;
        /// <summary>
        /// Payment made onsite or at reg. time.
        /// </summary>
        
        public Boolean Onsite
        {
            get { return m_bolOnsite; }
            set { m_bolOnsite = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        
        public int PayRecieverUserID
        {
            get { return m_iPayRecieverUserID; }
            set { m_iPayRecieverUserID = value; }
        }
        /// <summary>
        /// Payment Detail Object
        /// </summary>
        
        public EPaymentDetail PaymentDetail
        {
            get { return m_objPaymentDetail; }
            set { m_objPaymentDetail = value; }
        }
        /// <summary>
        /// unique field
        /// </summary>
        
        public int EventPaymentID
        {
            get { return m_iEventPaymentID; }
            set { m_iEventPaymentID = value; }
        }
	

    }
}
