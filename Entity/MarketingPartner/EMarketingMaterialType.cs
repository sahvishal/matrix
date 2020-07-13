using System;

namespace Falcon.Entity.Affiliate
{
    [Serializable]
    public class EMarketingMaterialType
    {
        private int m_iMarketingMaterialTypeID = 0;
        private string m_strTitle = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strTag = string.Empty;
        private bool m_bolActive = true;
        private int m_iMarketingMaterialGroupID = 0;
        private string m_strMMGroupTitle = string.Empty;
        
        /// <summary>
        /// unique MarketingMaterialType id
        /// </summary>        
        public int MarketingMaterialTypeID
        {
            get
            {
                return m_iMarketingMaterialTypeID;
            }
            set
            {
                m_iMarketingMaterialTypeID = value;
            }
        }

        /// <summary>
        /// MarketingMaterialType name
        /// </summary>        
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;
            }
        }
        /// <summary>
        /// MarketingMaterialType name
        /// </summary>        
        public string Tag
        {
            get
            {
                return m_strTag;
            }
            set
            {
                m_strTag = value;
            }
        }
        /// <summary>
        /// MarketingMaterialType description
        /// </summary>        
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        /// <summary>
        /// MarketingMaterialType status
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
        ///  Marketing Material Group id
        /// </summary>        
        public int MarketingMaterialGroupID
        {
            get
            {
                return m_iMarketingMaterialGroupID;
            }
            set
            {
                m_iMarketingMaterialGroupID = value;
            }
        }

        /// <summary>
        /// Group Title 
        /// </summary>        
        public string MMGroupTitle
        {
            get
            {
                return m_strMMGroupTitle;
            }
            set
            {
                m_strMMGroupTitle = value;
            }
        }
    }
}
