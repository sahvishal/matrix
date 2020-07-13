namespace Falcon.Entity.Other
{    
    public class ECouponType
    {
        private int m_iCouponTypeID = 0;
        private string m_strCouponTypeName = string.Empty;
        private string m_strCouponTypeDescription = string.Empty;
        private bool m_bolEventCoupon = true;
        private bool m_bolActive = true;
        

        /// <summary>
        /// unique CouponType id
        /// </summary>        
        public int CouponTypeID
        {
            get { return m_iCouponTypeID; }
            set { m_iCouponTypeID = value; }
        }
       /// <summary>
        /// CouponType name
       /// </summary>       
        public string Name
        {
            get { return m_strCouponTypeName; }
            set { m_strCouponTypeName = value; }
        }
        /// <summary>
        /// CouponType description
        /// </summary>       
        public string Description
        {
            get { return m_strCouponTypeDescription; }
            set { m_strCouponTypeDescription = value; }
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
        /// CouponType status
        /// </summary>        
        public bool EventCoupon
        {
            get
            {

                return m_bolEventCoupon;
            }
            set
            {
                m_bolEventCoupon = value;
            }
        }
        
    }
}
