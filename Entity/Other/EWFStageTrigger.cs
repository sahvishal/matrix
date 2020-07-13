namespace Falcon.Entity.Other
{    
    
    public class EWFStageTrigger
    {
        private int m_iWFStageTriggerID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique WFStageTrigger id
        /// </summary>
        
        public int WFStageTriggerID
        {
            get
            {
                return m_iWFStageTriggerID;
            }
            set
            {
                m_iWFStageTriggerID = value;
            }
        }
        /// <summary>
        /// WFStageTrigger name
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
        /// WFStageTrigger description
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
        /// WFStageTrigger status
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
