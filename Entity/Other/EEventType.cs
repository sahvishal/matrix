namespace Falcon.Entity.Other
{
    public class EEventType
    {
        private int m_iEventTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique eventtype ID
        /// </summary>
        
        public int EventTypeID
        {
            get
            {
                return m_iEventTypeID;
            }
            set
            {
                m_iEventTypeID = value;
            }
        }

        /// <summary>
        /// event name
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
        /// event description
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
        /// eventtype status
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
