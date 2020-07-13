namespace Falcon.Entity.Other
{
    public class EMarketingSource
    {
        private int m_MarketingSourceID = 0;
        private string m_Label = string.Empty;
        private string m_Notes = string.Empty;
        private string m_DateCreated = string.Empty;
        private string m_DateModified = string.Empty;
        private bool m_IsActive = true;

        /// <summary>
        /// MarketingSourceID
        /// </summary>
        
        public int MarketingSourceID
        {
            get
            {
                return m_MarketingSourceID;
            }
            set
            {
                m_MarketingSourceID = value;
            }
        }
        /// <summary>
        /// Label
        /// </summary>
        
        public string Label
        {
            get
            {
                return m_Label;
            }
            set
            {
                m_Label = value;
            }
        }

        /// <summary>
        /// Notes
        /// </summary>
        
        public string Notes
        {
            get
            {
                return m_Notes;
            }
            set
            {
                m_Notes = value;
            }
        }

        /// <summary>
        /// DateCreated
        /// </summary>
        
        public string DateCreated
        {
            get
            {
                return m_DateCreated;
            }
            set
            {
                m_DateCreated = value;
            }
        }

        /// <summary>
        /// DateModified
        /// </summary>
        
        public string DateModified
        {
            get
            {
                return m_DateModified;
            }
            set
            {
                m_DateModified = value;
            }
        }

        /// <summary>
        /// IsActive
        /// </summary>
        
        public bool IsActive
        {
            get
            {
                return m_IsActive;
            }
            set
            {
                m_IsActive = value;
            }
        }
    }
}
