       
using System;

namespace Falcon.Entity.Other
{   
    //TODO Remove serializable (Used in Customer Details)
    [Serializable]
    public class EReferences
    {
        private int m_iReferenceID = 0;
        private int m_iUserID = 0;
        private string m_strName = string.Empty;
        private string m_strEMail = string.Empty;
     

        /// <summary>
        /// unique Reference id
        /// </summary>
        
        public int ReferenceID
        {
            get
            {
                return m_iReferenceID;
            }
            set
            {
                m_iReferenceID = value;
            }
        }
        /// <summary>
        /// User id
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
        /// Reference name
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
        /// Reference Email
        /// </summary>
        
        public string EMail
        {
            get
            {
                return m_strEMail;
            }
            set
            {
                m_strEMail = value;
            }
        }
        
    }
}
