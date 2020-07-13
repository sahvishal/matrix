namespace Falcon.Entity.Other
{
    public class ELoginLog
    {
        private int m_iUserLoginLogID = 0;
        private int m_iUserID = 0;
        private string m_strLoginDatetime = string.Empty;
        private string m_strLogoutDatetime = string.Empty;
        private string m_strBrowserSessionID = string.Empty;
        private string m_strBrowserType = string.Empty;
        private string m_strSessionIP = string.Empty;
        private string m_strReferredlUrl = string.Empty;

        /// <summary>
        /// UserLoginLogID
        /// </summary>
        
        public int UserLoginLogID
        {
            get
            {
                return m_iUserLoginLogID;
            }
            set
            {
                m_iUserLoginLogID = value;
            }
        }

        /// <summary>
        /// UserID
        /// </summary>
        
        public int UserID
        {
            get
            {
                return m_iUserID;
            }
            set
            {
                m_iUserID = value;
            }
        }

        /// <summary>
        /// LoginDatetime
        /// </summary>
        
        public string LoginDatetime
        {
            get
            {
                return m_strLoginDatetime;
            }
            set
            {
                m_strLoginDatetime = value;
            }
        }

        /// <summary>
        /// LogoutDatetime
        /// </summary>
        
        public string LogoutDatetime
        {
            get
            {
                return m_strLogoutDatetime;
            }
            set
            {
                m_strLogoutDatetime = value;
            }
        }

        /// <summary>
        /// BrowserSessionID
        /// </summary>
        
        public string BrowserSessionID
        {
            get
            {
                return m_strBrowserSessionID;
            }
            set
            {
                m_strBrowserSessionID = value;
            }
        }
        /// <summary>
        /// BrowserType
        /// </summary>
        
        public string BrowserType
        {
            get
            {
                return m_strBrowserType;
            }
            set
            {
                m_strBrowserType = value;
            }
        }

        /// <summary>
        /// SessionIP
        /// </summary>
        
        public string SessionIP
        {
            get
            {
                return m_strSessionIP;
            }
            set
            {
                m_strSessionIP = value;
            }
        }

        /// <summary>
        /// ReferredlUrl
        /// </summary>
        
        public string ReferredlUrl
        {
            get
            {
                return m_strReferredlUrl;
            }
            set
            {
                m_strReferredlUrl = value;
            }
        }
    }
}
