namespace Falcon.Entity.Other
{
    public class EItemType
    {
        private int m_iItemTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private bool m_bolTestAssociated = true;

        /// <summary>
        /// Unique itemtype ID
        /// </summary>
        
        public int ItemTypeID
        {
            get
            {
                return m_iItemTypeID;
            }
            set
            {
                m_iItemTypeID=value;
            }
        }

        /// <summary>
        /// itemtype Name
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
        /// itemtype description
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
        /// status of itemtype
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
        /// Test Associated with itemtype
        /// </summary>
        
        public bool TestAssociated
        {
            get
            {
                return m_bolTestAssociated;
            }
            set
            {
                m_bolTestAssociated = value;
            }
        }

    }
}


