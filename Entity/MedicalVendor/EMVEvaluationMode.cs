namespace Falcon.Entity.MedicalVendor
{
    public class EMVEvaluationMode
    {
        private int m_iMVEvaluationModeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strUserFriendlyText = string.Empty;
        private bool m_bolActive = true;
        
        public int MVEvaluationModeID
        {
            get
            {
                return m_iMVEvaluationModeID;
            }
            set
            {
                m_iMVEvaluationModeID = value;
            }
        }
        
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

        
        public string UserFriendlyText
        {
            get
            {
                return m_strUserFriendlyText;
            }
            set
            {
                m_strUserFriendlyText = value;
            }
        }

        
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
    }
}
