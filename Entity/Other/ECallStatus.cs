namespace Falcon.Entity.Other
{    
    public class ECallStatus
    {
        private int m_iCallStatusID = 0;
        private bool m_bolcallStatus = true;
        private string m_strStatus = string.Empty;
        private string m_Duration = string.Empty;
        private string m_Notes = string.Empty;

        /// <summary>
        /// 
        /// </summary>        
        public int CallStatusID
        {
            get
            {
                return m_iCallStatusID;
            }
            set
            {
                m_iCallStatusID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>        
        public bool CallActive
        {
            get
            {
                return m_bolcallStatus;
            }
            set
            {
                m_bolcallStatus = value;
            }
        }
        
        public string Status
        {
            get
            {
                return m_strStatus;
            }
            set
            {
                m_strStatus = value;
            }
        }
        
        public string Duration
        {
            get
            {
                return m_Duration;
            }
            set
            {
                m_Duration = value;
            }
        }

        
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

    }
}
