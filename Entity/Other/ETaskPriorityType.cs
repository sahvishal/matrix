namespace Falcon.Entity.Other
{   
    
    public class ETaskPriorityType
    {
        private int m_iTaskPriorityTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique TaskPrioritytype ID
        /// </summary>
        
        public int TaskPriorityTypeID
        {
            get
            {
                return m_iTaskPriorityTypeID;
            }
            set
            {
                m_iTaskPriorityTypeID = value;
            }
        }

        /// <summary>
        /// TaskPrioritytype Name
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
        /// TaskPrioritytype description
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
        /// status of TaskPrioritytype
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


