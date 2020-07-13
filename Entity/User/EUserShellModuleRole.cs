namespace Falcon.Entity.User
{
    //TODO:[Obsolete("Use Core.UserSessionModel")   ]
    public class EUserShellModuleRole
    {
        private string userID;
        private string shellID;
        private string roleID;
        private string shellname;
        private string shelltype;
        private string rolename;
        private bool isdefault;
        private string defaultgage;
        private int m_iRoleShellID;
        private string m_strUserName;
        private bool isdefaultRole;
        private string email;
        private bool isactive;
        private string loginname;
        private string m_strHintQuestion;
        private string m_strHintAnswer;
        private bool islocked=false;

        /// <summary>
        /// Name of the user logged in
        /// </summary>
        
        public string UserName
        {
            get { return m_strUserName; }
            set { m_strUserName = value; }
        }
	
        /// <summary>
        /// Role Shell ID of the user
        /// </summary>
        
        public int RoleShellID
        {
            get { return m_iRoleShellID; }
            set { m_iRoleShellID = value; }
        }
	

        /// <summary>
        /// This will hold the 
        /// user id.
        /// </summary>
        
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        /// <summary>
        /// This will hold 
        /// the Shell ID
        /// </summary>
        
        public string ShellID
        {
            get { return shellID; }
            set { shellID = value; }
        }
        /// <summary>
        /// This will hold the roleID
        /// </summary>
        
        public string RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }
        /// <summary>
        /// This will hold the shelltype like 'franchisor,franchisee etc.'
        /// </summary>
        
        public string ShellType
        {
            get { return shelltype; }
            set { shelltype = value; }
        }

        /// <summary>
        /// To store the shell name/business name
        /// </summary>
        
        public string ShellName
        {
            get { return shellname; }
            set { shellname = value; }
        }

        /// <summary>
        /// To store the name of the role
        /// </summary>
        
        public string RoleName
        {
            get { return rolename; }
            set { rolename = value; }
        }
        
        /// <summary>
        /// To identify the default 
        /// </summary>
        
        public bool IsDefault
        {
            get { return isdefault; }
            set { isdefault = value; }
        }
        
        /// <summary>
        /// To store the default page for this shell type
        /// </summary>
        
        public string DefaultPage
        {
            get { return defaultgage; }
            set { defaultgage = value; }
        }

        /// <summary>
        /// To identify the default 
        /// </summary>
        
        public bool IsDefaultRole
        {
            get { return isdefaultRole; }
            set { isdefaultRole = value; }
        }

        /// <summary>
        /// To store the email for user
        /// </summary>
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// To identify the active 
        /// </summary>
        
        public bool IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        /// <summary>
        /// user login name
        /// </summary>
        
        public string LoginName
        {
            get { return loginname; }
            set { loginname = value; }
        }

        /// <summary>
        /// User Login HintQuestion
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
        /// User Login HintAnswer
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
        /// To identify the locked account 
        /// </summary>
        
        public bool IsLocked
        {
            get { return islocked; }
            set { islocked = value; }
        }
    }
}
