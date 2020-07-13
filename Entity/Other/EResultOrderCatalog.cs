namespace Falcon.Entity.Other
{   
    
    public class EResultOrderCatalog
    {
        private int m_iResultOrderCatalogID=0;
        private string m_strTitle = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strDateCreated = string.Empty;
        private float m_fSalePrice = 0.00F;
        private float m_fCostPrice = 0.00F;
        private string m_strDateModified = string.Empty;
        private bool m_boolIsActive = true;
        private string m_strDisclaimer = string.Empty;
        
        /// <summary>
        /// ResultOrderCatalogID
        /// </summary>
        
        public int ResultOrderCatalogID
        {
            get
            {
                return m_iResultOrderCatalogID;
            }
            set
            {
                m_iResultOrderCatalogID = value;
            }
        }

        /// <summary>
        /// Title
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
        /// Description
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
        /// SalePrice
        /// </summary>
        
        public float SalePrice
        {
            get
            {
                return m_fSalePrice;
            }
            set
            {
                m_fSalePrice = value;
            }
        }

        /// <summary>
        /// CostPrice
        /// </summary>
        
        public float CostPrice
        {
            get
            {
                return m_fCostPrice;
            }
            set
            {
                m_fCostPrice = value;
            }
        }

        /// <summary>
        /// IsActive
        /// </summary>
        
        public bool IsActive
        {
            get
            {
                return m_boolIsActive;
            }
            set
            {
                m_boolIsActive = value;
            }
        }

        /// <summary>
        /// CreatedDate
        /// </summary>
        
        public string DateCreated
        {
            get
            {
                return m_strDateCreated;
            }
            set
            {
                m_strDateCreated = value;
            }
        }

        /// <summary>
        /// LastModifiedDate
        /// </summary>
        
        public string DateModified
        {
            get
            {
                return m_strDateModified;
            }
            set
            {
                m_strDateModified = value;
            }
        }

        /// <summary>
        /// Disclaimer
        /// </summary>
        
        public string Disclaimer
        {
            get
            {
                return m_strDisclaimer;
            }
            set
            {
                m_strDisclaimer = value;
            }
        }
    }
}
