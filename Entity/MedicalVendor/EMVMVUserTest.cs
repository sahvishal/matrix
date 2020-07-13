namespace Falcon.Entity.MedicalVendor
{
    public class EMVMVUserTest
    {
        private int m_iMVMVUserTestID = 0;
        private decimal m_dOfferRate = 0;
        private bool m_bolActive = true;
        private int m_iMedicalVendorMVUserID = 0;
        private EMVTest m_objMVTest = null;
                
        public int MVMVUserTestID
        {
            get
            {
                return m_iMVMVUserTestID;
            }
            set
            {
                m_iMVMVUserTestID = value;
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

        
        public int MedicalVendorMVUserID
        {
            get
            {
                return m_iMedicalVendorMVUserID;
            }
            set
            {
                m_iMedicalVendorMVUserID = value;
            }
        }

        
        public EMVTest MVTest
        {
            get
            {
                return m_objMVTest;
            }
            set
            {
                m_objMVTest = value;
            }
        }

    }
}