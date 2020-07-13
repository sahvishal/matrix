namespace Falcon.Entity.Other
{
    
    public class ECommunicationMode
    {
        private int m_iCommunicationModeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        
        /// <summary>
        /// unique communicationmode ID
        /// </summary>        
        public int CommunicationModeID
        {
            get
            {
                return m_iCommunicationModeID;
            }
            set
            {
                m_iCommunicationModeID = value;
            }
        }

        /// <summary>
        /// communicationmode name
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
        /// communicationmode description
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
        /// communicationmode status
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
