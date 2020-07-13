namespace Falcon.Entity.Other
{    
    public class ECity
    {
        private int m_iCityID = 0;
        private string m_strCityName = string.Empty;
        private string m_strCityDescription = string.Empty;
        private ECountry m_objCountry;
        private EState m_objState;
        private bool m_bolActive = true;
        private EZip m_objZip;


        /// <summary>
        /// unique city id
        /// </summary>        
        public int CityID
        {
            get { return m_iCityID; }
            set { m_iCityID = value; }
        }
        /// <summary>
        /// city name
        /// </summary>        
        public string Name
        {
            get { return m_strCityName; }
            set { m_strCityName = value; }
        }
        /// <summary>
        /// city description
        /// </summary>        
        public string Description
        {
            get { return m_strCityDescription; }
            set { m_strCityDescription = value; }
        }

        /// <summary>
        /// city status
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
        /// country object for mapping city with country
        /// </summary>        
        public ECountry Country
        {
            get { return m_objCountry; }
            set { m_objCountry = value; }
        }

        /// <summary>
        /// state object for mapping city with state
        /// </summary>        
        public EState State
        {
            get { return m_objState; }
            set { m_objState = value; }
        }

        /// <summary>
        /// zip object for mapping zip with city
        /// </summary>        
        public EZip Zipcode
        {
            get { return m_objZip; }
            set { m_objZip = value; }
        }

    }
}
