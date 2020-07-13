namespace Falcon.Entity.Other
{
    
    public class ECollateralType
    {
        private int m_iCollateralTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique collateraltype id
        /// </summary>        
        public int CollateralTypeID
        {
            get
            {
                return m_iCollateralTypeID;
            }
            set
            {
                m_iCollateralTypeID = value;
            }
        }

        /// <summary>
        /// collateraltype name
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
        /// collateraltype description
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
        /// collateraltype status
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
