namespace Falcon.Entity.Other
{   
    
    public class EResourceType
    {
        private int m_iResourceTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        /// <summary>
        /// unque ResourceType id
        /// </summary>
        
        public int ResourceTypeID
        {
            get
            {
                return m_iResourceTypeID;
            }
            set
            {
                m_iResourceTypeID = value;
            }
        }

        /// <summary>
        /// ResourceType name
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
        /// ResourceType description
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
        /// ResourceType status
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
