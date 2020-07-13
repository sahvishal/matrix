using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class ETest
    {
        private int m_iTestID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private float m_fMinimumPrice = 0;
        private float m_fRecommendedPrice = 0;
        private Int16 m_iVersion = 0;

        public bool IsTestDefaultSelected { get; set; }
        /// <summary>
        /// unique test id
        /// </summary>
        public int TestID
        {
            get
            {
                return m_iTestID;
            }
            set
            {
                m_iTestID = value;
            }
        }
        /// <summary>
        /// test name
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
        /// teat description
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
        /// test status
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
        /// minimum test price
        /// </summary>
        public float MinimumPrice
        {
            get
            {
                return m_fMinimumPrice;
            }
            set
            {
                m_fMinimumPrice = value;
            }
        }


        /// <summary>
        /// recommended price
        /// </summary>
        public float RecommendedPrice
        {
            get
            {
                return m_fRecommendedPrice;
            }
            set
            {
                m_fRecommendedPrice = value;
            }
        }
        
        public Int16 Version
        {
            get
            {
                return m_iVersion;
            }
            set
            {
                m_iVersion = value;
            }
        }

        public bool ShowInAlaCarte { get; set; }

        public int ScreeningTime { get; set; }

        public decimal WithPackagePrice { get; set; }
    }
}
