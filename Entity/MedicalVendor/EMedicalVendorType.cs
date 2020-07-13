namespace Falcon.Entity.MedicalVendor
{
    public class EMedicalVendorType
    {
        private int m_iMedicalVendorTypeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique MedicalVendorType id
        /// </summary>        
        public int MedicalVendorTypeID
        {
            get
            {
                return m_iMedicalVendorTypeID;
            }
            set
            {
                m_iMedicalVendorTypeID=value;
            }
        }
        /// <summary>
        /// MedicalVendorType name
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
        /// MedicalVendorType description
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
        /// MedicalVendorType status
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
    }
}
