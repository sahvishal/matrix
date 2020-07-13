using Falcon.Entity.Franchisor;

namespace Falcon.Entity.MedicalVendor
{
    public class EMVPackage
    {
        private int m_iMVPackageID = 0;
        private EPackage m_objPackage = null;
        private decimal m_dOfferRate = 0;
        private bool m_bolActive = true;
        private int m_iMedicalVendorID = 0;
                
        public int MVPackageID
        {
            get
            {
                return m_iMVPackageID;
            }
            set
            {
                m_iMVPackageID = value;
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
    }
}
