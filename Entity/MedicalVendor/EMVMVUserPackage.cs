namespace Falcon.Entity.MedicalVendor
{    
    public class EMVMVUserPackage
    {
        private int m_iMVMVUserPackageID = 0;
        private decimal m_dOfferRate = 0;
        private bool m_bolActive = true;
        private int m_iMedicalVendorMVUserID = 0;
        private EMVPackage m_objMVPackage = null;
                
        public int MVMVUserPackageID
        {
            get
            {
                return m_iMVMVUserPackageID;
            }
            set
            {
                m_iMVMVUserPackageID = value;
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
        
        public EMVPackage MVPackage
        {
            get
            {
                return m_objMVPackage;
            }
            set
            {
                m_objMVPackage = value;
            }
        }

    }
}