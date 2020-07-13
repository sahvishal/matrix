namespace Falcon.Entity.Other
{
    public class EEventMarketingOffer
    {
        private int m_iEventMarketingOfferID = 0;
        private int m_iMarketingOfferID = 0;
        private int m_iNoOfTimeUsed = 0;
        private string m_dtDateCreated = string.Empty;
        private string m_dtDateModified = string.Empty;
        private bool m_bolActive = true;
        private EEvent m_objEvent = null;

        /// <summary>
        /// unique EventCoupon id
        /// </summary>
        
        public int EventMarketingOfferID
        {
            get { return m_iEventMarketingOfferID; }
            set { m_iEventMarketingOfferID = value; }
        }

       

        /// <summary>
        /// unique Coupon id
        /// </summary>
        
        public int MarketingOfferID
        {
            get { return m_iMarketingOfferID; }
            set { m_iMarketingOfferID = value; }
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
