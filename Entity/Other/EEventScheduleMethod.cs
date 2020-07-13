namespace Falcon.Entity.Other
{
    public class EEventScheduleMethod
    {
        private int m_iEventScheduleMethodID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique Eventschedule method id
        /// </summary>        
        public int EventScheduleMethodID
        {
            get
            {
                return m_iEventScheduleMethodID;
            }
            set
            {
                m_iEventScheduleMethodID = value;
            }
        }

        /// <summary>
        ///Event schedulemethod name
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
        /// Eventschedulemethod description
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
        /// Eventschedulemethod status
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

