namespace Falcon.Entity.Other
{
    public class EEventRole
    {
        private int m_iEventRoleID = 0;
        private int m_iRoleID = 0;
        private string m_strEventRoleName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        
        public string EventRoleName
        {
            get { return m_strEventRoleName; }
            set { m_strEventRoleName = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public int RoleID
        {
            get { return m_iRoleID; }
            set { m_iRoleID = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        public int EventRoleID
        {
            get { return m_iEventRoleID; }
            set { m_iEventRoleID = value; }
        }
	

    }
}
