namespace Falcon.Entity.MedicalVendor
{
    public class EMVMVUserCustomerPayRate
    {
        private int m_iCustomerPayRateID = 0;
        private decimal m_dOfferRate = 0;
        private bool m_bolActive = true;
        private int m_iMedicalVendorMVUserID = 0;
        private EMVCustomerPayRate m_objMVCustomerPayRate = null;
                
        public int MVMVUserCustomerPayRateID
        {
            get
            {
                return m_iCustomerPayRateID;
            }
            set
            {
                m_iCustomerPayRateID = value;
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
        
        public EMVCustomerPayRate MVCustomerPayRate
        {
            get
            {
                return m_objMVCustomerPayRate;
            }
            set
            {
                m_objMVCustomerPayRate = value;
            }
        }

    }
}

