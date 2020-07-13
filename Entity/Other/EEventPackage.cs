using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{
    public class EEventPackage
    {
        private int m_iEventPackageID = 0;
        private int m_iEventID;
        private EPackage m_objPackage = null;
        private float m_fPackagePrice = 0;

        /// <summary>
        /// unique event package id
        /// </summary>

        public int EventPackageID
        {
            get
            {
                return m_iEventPackageID;
            }
            set
            {
                m_iEventPackageID = value;
            }
        }

        /// <summary>
        /// event id
        /// </summary>

        public int EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }

        }

        /// <summary>
        /// package object for mapping event package with package
        /// </summary>

        public EPackage Package
        {
            get
            {
                return m_objPackage;
            }
            set
            {
                m_objPackage = value;
            }
        }

        /// <summary>
        /// package price
        /// </summary>

        public float PackagePrice
        {
            get
            {
                return m_fPackagePrice;
            }
            set
            {
                m_fPackagePrice = value;
            }

        }

        public int ScreeningTime { get; set; }

        public long Gender { get; set; }

        public bool IsRecommended { get; set; }

        public bool MostPopular { get; set; }

        public bool BestValue { get; set; }

        public long? PodRoomID { get; set; }
    }
}

