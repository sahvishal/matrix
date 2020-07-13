using Falcon.Entity.Franchisor;

namespace Falcon.Entity.MedicalVendor
{
    public class EMVTest
    {
        private int m_iMVTestID = 0;
        private ETest m_objTest=null;
        private decimal m_dOfferRate = 0;
        private bool m_bolActive = true;
        private int m_iMedicalVendorID = 0;
        
        public int MVTestID
        {
            get
            {
                return m_iMVTestID;
            }
            set
            {
                m_iMVTestID = value;
            }
        }

        
        public decimal OfferRate
        {
            get
            {
                return m_dOfferRate;
            }
            set
            {
                m_dOfferRate = value;
            }
        }

        
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

        
        public int MedicalVendorID
        {
            get
            {
                return m_iMedicalVendorID;
            }
            set
            {
                m_iMedicalVendorID = value;
            }
        }

        
        public ETest Test
        {
            get
            {
                return m_objTest;
            }
            set
            {
                m_objTest = value;
            }
        }
    }
}
