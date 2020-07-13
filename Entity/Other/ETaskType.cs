namespace Falcon.Entity.Other
{   
    
    public class ETaskType
    {
        private int m_iTaskTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique TaskType id
        /// </summary>
        
        public int TaskTypeID
        {
            get
            {
                return m_iTaskTypeID;
            }
            set
            {
                m_iTaskTypeID = value;
            }
        }

        /// <summary>
        /// TaskType name
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
        /// TaskType description
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
        /// TaskType status
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