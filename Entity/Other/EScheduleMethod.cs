namespace Falcon.Entity.Other
{   
    
    public class EScheduleMethod
    {
        private int m_iScheduleMethodID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique schedule method id
        /// </summary>
        
        public int ScheduleMethodID
        {
            get
            {
                return m_iScheduleMethodID;
            }
            set
            {
                m_iScheduleMethodID=value;
            }
        }

        /// <summary>
        /// schedulemethod name
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
        /// schedulemethod description
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
        /// schedulemethod status
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
