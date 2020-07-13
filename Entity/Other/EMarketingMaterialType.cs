namespace Falcon.Entity.Other
{
    public class EMarketingMaterialType
    {
        private int m_iMarketingMaterialTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strTag = string.Empty;
        private bool m_bolActive = true;
        
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
        
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
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

    }
}
