namespace Falcon.Entity.Other
{
    public class ELocation
    {
        private int m_iLocationID = 0;
        private string m_strLocationName = string.Empty;
        private int m_iLocationType = 0;
        private bool m_bolActive = true;
        private ELocation m_objLocation;

        /// <summary>
        /// Unique Location id
        /// </summary>
        
        public int LocationID
        {
            get
            {
                return m_iLocationID;
            }
            set
            {
                m_iLocationID = value;
            }
        }

        /// <summary>
        /// location name
        /// </summary>
        
        public string LocationName
        {
            get
            {
                return m_strLocationName;
            }
            set
            {
                m_strLocationName = value;
            }
        }

        /// <summary>
        /// location type
        /// </summary>
        
        public int LocationType
        {
            get
            {
                return m_iLocationType;
            }
            set
            {
                m_iLocationType = value;
            }
        }

        /// <summary>
        /// location object.
        /// </summary>
        
        public ELocation Location
        {
            get
            {
                return m_objLocation;
            }
            set
            {
                m_objLocation = value;
            }
        }

        /// <summary>
        /// status of location
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
