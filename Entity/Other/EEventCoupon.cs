namespace Falcon.Entity.Other
{
    public class EEventCoupon
    {
        private int m_iEventCouponID = 0;
        private int m_iCouponID = 0;
        private int m_iNoOfTimeUsed = 0;
        private string m_dtDateCreated = string.Empty;
        private string m_dtDateModified = string.Empty;
        private bool m_bolActive = true;
        private EEvent m_objEvent = null;

        /// <summary>
        /// unique EventCoupon id
        /// </summary>        
        public int EventCouponID
        {
            get { return m_iEventCouponID; }
            set { m_iEventCouponID = value; }
        }

       

        /// <summary>
        /// unique Coupon id
        /// </summary>        
        public int CouponID
        {
            get { return m_iCouponID; }
            set { m_iCouponID = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int NoOfTimeUsed
        {
            get { return m_iNoOfTimeUsed; }
            set { m_iNoOfTimeUsed = value; }
        }

        /// <summary>
        /// CouponType status
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
        /// <summary>
        /// 
        /// </summary>        
        public EEvent Event
        {
            get { return m_objEvent; }
            set { m_objEvent = value; }
        }
    }
}
