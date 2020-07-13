namespace Falcon.Entity.MedicalVendor
{
    
    public class EMVUserSpecialization
    {
        private int m_iMVUserSpecializationID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique MVUserSpecialization id
        /// </summary>        
        public int MVUserSpecilaizationID
        {
            get
            {
                return m_iMVUserSpecializationID;
            }
            set
            {
                m_iMVUserSpecializationID = value;
            }
        }

        /// <summary>
        /// MVUserSpecialization name
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
        /// MVUserSpecialization description
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
        /// MVUserSpecialization status
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
