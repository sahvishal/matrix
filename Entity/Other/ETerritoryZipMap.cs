namespace Falcon.Entity.Other
{   
      
    public class ETerritoryZipMap
    {
        private int m_iTerritoryZipMapID = 0;
        private int m_iTerritoryID = 0;
        private int m_iZipID = 0;
        private bool m_boolIsActive = false;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private string m_strZipDetail = string.Empty;

        /// <summary>
        /// TerritoryZipMapID
        /// </summary>
        
        public int TerritoryZipMapID
        {
            get
            {
                return m_iTerritoryZipMapID;
            }
            set
            {
                m_iTerritoryZipMapID = value;
            }
        }

        /// <summary>
        /// TerritoryID
        /// </summary>
        
        public int TerritoryID
        {
            get
            {
                return m_iTerritoryID;
            }
            set
            {
                m_iTerritoryID = value;
            }
        }

        /// <summary>
        /// ZipID
        /// </summary>
        
        public int ZipID
        {
            get
            {
                return m_iZipID;
            }
            set
            {
                m_iZipID = value;
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
        /// DateCreated
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
        /// DateModified
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
        /// ZipDetail
        /// </summary>
        
        public string ZipDetail
        {
            get
            {
                return m_strZipDetail;
            }
            set
            {
                m_strZipDetail = value;
            }
        }
    }
}
