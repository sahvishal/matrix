using System;

namespace Falcon.Entity.Affiliate
{
    [Serializable]
    public class EMarketingMaterial
    {
        private int m_iMarketingMaterialId = 0;
        private int m_iEventId = 0;

        private int m_iMarketingMaterialTypeId = 0;
        private int m_iHeight = 0;
        private int m_iWidth = 0;
        private int m_iRecordStatus = 0;
        private EMarketingMaterialType m_objMarketingMaterialType = null;
        private bool m_boolActive = true;
        private bool m_boolIsEventSpecific = true;
        private bool m_boolIsInbound = true;
        private bool m_boolIsInternal = true;
        private int m_boolIsAssociated = 0;
        private string m_strTitle = string.Empty;
        private string m_strHeadingText = string.Empty;
        private string m_strLeadingInURL = string.Empty;
        private string m_strDisplayURL = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strImagePath = string.Empty;
        private string m_strThumbnailImagePath = string.Empty;
        private string m_strText = string.Empty;
        private string m_strHTMLText = string.Empty;
        private string m_strCommonSizeName = string.Empty;
        private string m_strCreatedDate = string.Empty;
        private string m_strAffiliateString = string.Empty;
        private string m_strOverallImpressionCount = string.Empty;
        private string m_strCTR = string.Empty;
        private bool m_boolInbound = true;
        private bool m_boolIsDefault = true;
        private string m_strMarketingOfferName = string.Empty;
        private Int64 m_iMarketingGroupId = 0;
        private Int64 m_iMarketingOfferId = 0;
        private int m_iBannerId = 0;
        private string m_strBannerSize = string.Empty;

        /// <summary>
        ///Unique MarketingMaterial ID 
        /// </summary>        
        public int MarketingMaterialId
        {
            get { return m_iMarketingMaterialId; }
            set { m_iMarketingMaterialId = value; }
        }
        
        public int EventId
        {
            get { return m_iEventId; }
            set { m_iEventId = value; }
        }
        
        public EMarketingMaterialType MarketingMaterialType
        {
            get { return m_objMarketingMaterialType; }
            set { m_objMarketingMaterialType = value; }
        }
        
        public int RecordStatus
        {
            get { return m_iRecordStatus; }
            set { m_iRecordStatus = value; }
        }
        
        /// <summary>
        ///MarketingMaterial ID 
        /// </summary>        
        public int MarketingMaterialTypeId
        {
            get { return m_iMarketingMaterialTypeId; }
            set { m_iMarketingMaterialTypeId = value; }
        }
        /// <summary>
        ///MarketingMaterial Height 
        /// </summary>        
        public int Height
        {
            get { return m_iHeight; }
            set { m_iHeight = value; }
        }
        /// <summary>
        ///MarketingMaterial Height 
        /// </summary>        
        public int Width
        {
            get { return m_iWidth; }
            set { m_iWidth = value; }
        }
        /// <summary>
        ///MarketingMaterial CommonSizeName 
        /// </summary>        
        public string CommonSizeName
        {
            get { return m_strCommonSizeName; }
            set { m_strCommonSizeName = value; }
        }
        /// <summary>
        ///MarketingMaterial Text 
        /// </summary>        
        public string Text
        {
            get { return m_strText; }
            set { m_strText = value; }
        }
        
        public string HeadingText
        {
            get { return m_strHeadingText; }
            set { m_strHeadingText = value; }
        }
        
        public string DisplayURL
        {
            get { return m_strDisplayURL; }
            set { m_strDisplayURL = value; }
        }
        
        public string LeadingInURL
        {
            get { return m_strLeadingInURL; }
            set { m_strLeadingInURL = value; }
        }
        /// <summary>
        ///MarketingMaterial HTMLText 
        /// </summary>        
        public string HTMLText
        {
            get { return m_strHTMLText; }
            set { m_strHTMLText = value; }
        }
        /// <summary>
        ///MarketingMaterial title 
        /// </summary>        
        public string Title
        {
            get { return m_strTitle; }
            set { m_strTitle = value; }
        }
        /// <summary>
        ///MarketingMaterial ImagePath 
        /// </summary>        
        public string ImagePath
        {
            get { return m_strImagePath; }
            set { m_strImagePath = value; }
        }
        /// <summary>
        /// Thumbnail Marketing Material Image Path 
        /// </summary>        
        public string ThumbnailImagePath
        {
            get { return m_strThumbnailImagePath; }
            set { m_strThumbnailImagePath = value; }
        }
        /// <summary>
        ///MarketingMaterial Description
        /// </summary>        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }
        
        public string CreatedDate
        {
            get { return m_strCreatedDate; }
            set { m_strCreatedDate = value; }
        }
        
        public string OverallImpressionCount
        {
            get { return m_strOverallImpressionCount; }
            set { m_strOverallImpressionCount = value; }
        }
        
        public string CTR
        {
            get { return m_strCTR; }
            set { m_strCTR = value; }
        }
        /// <summary>
        /// MarketingMaterial status
        /// </summary>        
        public Boolean Active
        {
            get { return m_boolActive; }
            set { m_boolActive = value; }
        }
        /// <summary>
        /// IsEventSpecific
        /// </summary>        
        public Boolean IsEventSpecific
        {
            get { return m_boolIsEventSpecific; }
            set { m_boolIsEventSpecific = value; }
        }
        /// <summary>
        /// Is Inbound
        /// </summary>        
        public Boolean IsInbound
        {
            get { return m_boolIsInbound; }
            set { m_boolIsInbound = value; }
        }
        /// <summary>
        /// IsEventSpecific
        /// </summary>        
        public int Association
        {
            get { return m_boolIsAssociated; }
            set { m_boolIsAssociated = value; }
        }
        /// <summary>
        /// IsEventSpecific
        /// </summary>        
        public Boolean IsInternal
        {
            get { return m_boolIsInternal; }
            set { m_boolIsInternal = value; }
        }

        /// <summary>
        ///MarketingMaterial user string used by Affiliate
        /// </summary>        
        public string AffiliateString
        {
            get { return m_strAffiliateString; }
            set { m_strAffiliateString = value; }
        }

        /// <summary>
        ///  Is inbound
        /// </summary>        
        public Boolean Inbound
        {
            get
            {

                return m_boolInbound;
            }
            set
            {
                m_boolInbound = value;
            }
        }

        /// <summary>
        ///  is Default
        /// </summary>        
        public Boolean IsDefault
        {
            get
            {

                return m_boolIsDefault;
            }
            set
            {
                m_boolIsDefault = value;
            }
        }
        
        public string MarketingOfferName
        {
            get { return m_strMarketingOfferName; }
            set { m_strMarketingOfferName = value; }
        }
        
        public Int64 MarketingMaterialGroupId
        {
            get { return m_iMarketingGroupId; }
            set { m_iMarketingGroupId = value; }
        }
        
        public Int64 MarketingOfferId
        {
            get { return m_iMarketingOfferId; }
            set { m_iMarketingOfferId = value; }
        }
        /// <summary>
        ///Banner ID 
        /// </summary>        
        public int BannerId
        {
            get { return m_iBannerId; }
            set { m_iBannerId = value; }
        }
        /// <summary>
        ///Banner Size
        /// </summary>        
        public string BannerSize
        {
            get { return m_strBannerSize; }
            set { m_strBannerSize = value; }
        }
    }
}
