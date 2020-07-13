namespace Falcon.Entity.Other
{
    public class EMessageSendType
    {
        private int m_iMessageSendTypeID = 0;
        private string m_strSendOption = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique MessageSendType ID
        /// </summary>
        
        public int MessageSendTypeID
        {
            get
            {
                return m_iMessageSendTypeID;
            }
            set
            {
                m_iMessageSendTypeID = value;
            }
        }

        /// <summary>
        /// Send option
        /// </summary>
        
        public string SendOption
        {
            get
            {
                return m_strSendOption;
            }
            set
            {
                m_strSendOption = value;
            }
        }

        /// <summary>
        /// MessageSendType description
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
        /// status of MessageSendType
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


