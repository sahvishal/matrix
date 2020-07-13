namespace Falcon.Entity.MedicalVendor
{    
    public class EHospitalPartner
    {
        private int m_iHospitalPartnerID = 0;
        private long m_iMedicalVendorID = 0;
        private string m_strAssociatedPhoneNumber = string.Empty;
        private int m_iAdvocateID = 0;
        private bool m_bolIsGlobal = false;
        private bool m_bolIsActive = true;
        private long m_iCreatedBy = 0;
        private string m_strDateCreated = string.Empty;
        private long m_iModifiedBy = 0;
        private string m_strDateModified = string.Empty;
        private int m_iTerritoryID = 0;

        
        public int HospitalPartnerID
        {
            get
            {
                return m_iHospitalPartnerID;
            }
            set
            {
                m_iHospitalPartnerID = value;
            }
        }

        
        public long MedicalVendorID
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

        
        public string AssociatedPhoneNumber
        {
            get
            {
                return m_strAssociatedPhoneNumber;
            }
            set
            {
                m_strAssociatedPhoneNumber = value;
            }
        }

        
        public int AdvocateID
        {
            get
            {
                return m_iAdvocateID;
            }
            set
            {
                m_iAdvocateID = value;
            }
        }

        
        public bool IsGlobal
        {
            get
            {
                return m_bolIsGlobal;
            }
            set
            {
                m_bolIsGlobal = value;
            }
        }

        
        public bool IsActive
        {
            get
            {
                return m_bolIsActive;
            }
            set
            {
                m_bolIsActive = value;
            }
        }

        
        public long CreatedBy
        {
            get
            {
                return m_iCreatedBy;
            }
            set
            {
                m_iCreatedBy = value;
            }
        }

        
        public long ModifiedBy
        {
            get
            {
                return m_iModifiedBy;
            }
            set
            {
                m_iModifiedBy = value;
            }
        }

        
        public string DateCreated
        {
            get
            {
                return m_strDateCreated;
            }
            set
            {
                m_strDateCreated = value;
            }
        }

        
        public string DateModified
        {
            get
            {
                return m_strDateModified;
            }
            set
            {
                m_strDateModified = value;
            }
        }

        
        public int TerritoryID
        {
            get
            {
                return m_iTerritoryID;
            }
            set
            {
                m_iTerritoryID = value;
            }
        }
    }
}
