        
using System;

namespace Falcon.Entity.Other
{
    [Serializable]
    public class ECountry
    {
        private Int32 m_iCountryID = 0;
        private string m_strCountryName = string.Empty;
        private string m_strCountryDescription = string.Empty;
        private Boolean m_bolActive = true;
        private string m_strCountryCode = string.Empty;
        private long m_intTest = 0;
        /// <summary>
        /// unique country id
        /// </summary>        
        public Int32 CountryID
        {
            get { return m_iCountryID; }
            set { m_iCountryID = value; }
        }
        /// <summary>
        /// country name
        /// </summary>        
        public string Name
        {
            get { return m_strCountryName; }
            set { m_strCountryName = value; }
        }
        /// <summary>
        /// country description
        /// </summary>        
        public string Description
        {
            get { return m_strCountryDescription; }
            set { m_strCountryDescription = value; }
        }

        /// <summary>
        /// country status
        /// </summary>       
        public Boolean Active
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
        
        public long test
        {
            get
            {

                return m_intTest;
            }
            set
            {
                m_intTest = value;
            }
        }
        
        public string CountryCode
        {
            get
            {
                return m_strCountryCode;
            }
            set
            {
                m_strCountryCode = value;
            }
        }
    }

}
