namespace Falcon.Entity.Other
{   
    
    public class ESecurityQuestion
    {
        private int m_iSecurityQuestionID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique SecurityQuestion id
        /// </summary>
        
        public int SecurityQuestionID
        {
            get
            {
                return m_iSecurityQuestionID;
            }
            set
            {
                m_iSecurityQuestionID = value;
            }
        }
        /// <summary>
        /// SecurityQuestion name
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
        /// SecurityQuestion description
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
        /// SecurityQuestion status
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
