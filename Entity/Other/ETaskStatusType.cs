namespace Falcon.Entity.Other
{   
    
    public class ETaskStatusType
    {
        private int m_iTaskStatusTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique TaskStatustype ID
        /// </summary>
        
        public int TaskStatusTypeID
        {
            get
            {
                return m_iTaskStatusTypeID;
            }
            set
            {
                m_iTaskStatusTypeID = value;
            }
        }

        /// <summary>
        /// TaskStatustype Name
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
        /// TaskStatustype description
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
        /// status of TaskStatustype
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


