namespace Falcon.Entity.MedicalVendor
{
    public class EMVCustomerPayRate
    {
        private int m_iCustomerPayRateID = 0;
        private decimal m_dOfferRate = 0;
        private bool m_bolActive = true;
        private int m_iMedicalVendorID = 0;
        
        public int MVCustomerPayRateID
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

    }
}
