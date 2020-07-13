      
using System;

namespace Falcon.Entity.Other
{   
    [Serializable]
    public class ERole
    {
        private int m_iRoleID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique role id
        /// </summary>
        
        public int RoleID
        {
            get
            {
                return m_iRoleID;
            }
            set
            {
                m_iRoleID = value;
            }
        }

        /// <summary>
        /// role name
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
        /// role description
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
        /// role status
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
