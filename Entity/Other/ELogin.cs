       
using System;

namespace Falcon.Entity.Other
{
    //TODO Remove this (Used in Customer Details)
    [Serializable]
    public class ELogin
    {
        private int m_iUserLoginID = 0;
        private string m_strUserName = string.Empty;
        private string m_strPassword = string.Empty;
        private bool m_bolActive = true;
        private bool m_bolLocked = false;
        private int m_iLoginAttempts = 0;
        private string m_strLastLogged = string.Empty;
        private string m_strBrowserSessionId = string.Empty;
        private ESecurityQuestion m_objSecurityQuestion;
        private bool m_bolUserVerified = false;
        private string m_strHintQuestion = string.Empty;
        private string m_strHintAnswer = string.Empty;
        private bool m_bolIsSecurityQuestionVerified = false;
        private int roleid = 0;
        private string strPageurl = string.Empty;
        /// <summary>
        /// unique UserLogin id
        /// </summary>
        
        public int UserLoginID
        {
            get
            {
                return m_iUserLoginID;
            }
            set
            {
                m_iUserLoginID = value;
            }
        }

        /// <summary>
        /// User name
        /// </summary>
        
        public string UserName
        {
            get
            {
                return m_strUserName;
            }
            set
            {
                m_strUserName = value;
            }
        }

        /// <summary>
        /// user Password
        /// </summary>
        
        public string Password
        {
            get
            {
                return m_strPassword;
            }
            set
            {
                m_strPassword = value;
            }
        }

        /// <summary>
        /// account status
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

        /// <summary>
        /// account status
        /// </summary>
        
        public bool Locked
        {
            get
            {
                return m_bolLocked;
            }
            set
            {
                m_bolLocked = value;
            }
        }
        /// <summary>
        /// number of login attemps failed
        /// </summary>
        
        public int LoginAttempts
        {
            get
            {
                return m_iLoginAttempts;
            }
            set
            {
                m_iLoginAttempts = value;
            }
        }

        /// <summary>
        /// last logged date of user 
        /// </summary>
        
        public string LastLogged
        {
            get
            {
                return m_strLastLogged;
            }
            set
            {
                m_strLastLogged = value;
            }
        }
        /// <summary>
        /// security question object for mapping user login detail with  security question
        /// </summary>
        
        public ESecurityQuestion SecurityQuestion
        {
            get
            {
                return m_objSecurityQuestion;
            }
            set
            {
                m_objSecurityQuestion = value;
            }
        }

        /// <summary>
        /// User Browser Session Id
        /// </summary>
        
        public string BrowserSessionId
        {
            get
            {
                return m_strBrowserSessionId;
            }
            set
            {
                m_strBrowserSessionId = value;
            }
        }

        /// <summary>
        /// account status
        /// </summary>
        
        public bool UserVerified
        {
            get
            {
                return m_bolUserVerified;
            }
            set
            {
                m_bolUserVerified = value;
            }
        }

        /// <summary>
        /// HintQuestion
        /// </summary>
        
        public string HintQuestion
        {
            get
            {
                return m_strHintQuestion;
            }
            set
            {
                m_strHintQuestion = value;
            }
        }

        /// <summary>
        /// HintAnswer
        /// </summary>
        
        public string HintAnswer
        {
            get
            {
                return m_strHintAnswer;
            }
            set
            {
                m_strHintAnswer = value;
            }
        }

        /// <summary>
        /// IsSecurityQuestionVerified
        /// </summary>
        
        public bool IsSecurityQuestionVerified
        {
            get
            {
                return m_bolIsSecurityQuestionVerified;
            }
            set
            {
                m_bolIsSecurityQuestionVerified = value;
            }
        }
        
        public int Roleid
        {
            get
            {
                return roleid;
            }
            set
            {
                roleid = value;
            }
        }
        
        public string PageUrl
        {
            get
            {
                return strPageurl;
            }
            set
            {
                strPageurl = value;
            }
        }
    }
}
