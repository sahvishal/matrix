namespace Falcon.Entity.Other
{    
    
    public class EProspectType
    {
        private int m_iProspectTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique hosttype ID
        /// </summary>
        
        public int ProspectTypeID
        {
            get
            {
                return m_iProspectTypeID;
            }
            set
            {
                m_iProspectTypeID = value;
            }
        }

        /// <summary>
        /// hosttype name
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
        /// hosttype description
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
        /// hosttype status
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
