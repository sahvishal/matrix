namespace Falcon.Entity.Other
{   
    
    public class EWFStage
    {
        private int m_iWFStageID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique WFStage id
        /// </summary>
        
        public int WFStageID
        {
            get
            {
                return m_iWFStageID;
            }
            set
            {
                m_iWFStageID = value;
            }
        }
        /// <summary>
        /// WFStage name
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
        /// WFStage description
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
        /// WFStage status
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
