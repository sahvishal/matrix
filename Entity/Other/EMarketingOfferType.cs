namespace Falcon.Entity.Other
{
    public class EMarketingOfferType
    {
        private int m_iMarketingOfferTypeID = 0;
        private string m_strMarketingOfferTypeName = string.Empty;
        private string m_strMarketingOfferTypeDescription = string.Empty;
        private bool m_bolEventMarketingOffer = true;
        private bool m_bolActive = true;
        

        /// <summary>
        /// unique CouponType id
        /// </summary>
        
        public int MarketingOfferTypeID
        {
            get { return m_iMarketingOfferTypeID; }
            set { m_iMarketingOfferTypeID = value; }
        }
       /// <summary>
        /// CouponType name
       /// </summary>
        
        public string Name
        {
            get { return m_strMarketingOfferTypeName; }
            set { m_strMarketingOfferTypeName = value; }
        }
        /// <summary>
        /// CouponType description
        /// </summary>
        
        public string Description
        {
            get { return m_strMarketingOfferTypeDescription; }
            set { m_strMarketingOfferTypeDescription = value; }
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
        
        public bool EventMarketingOffer
        {
            get
            {

                return m_bolEventMarketingOffer;
            }
            set
            {
                m_bolEventMarketingOffer = value;
            }
        }
        
    }
}
