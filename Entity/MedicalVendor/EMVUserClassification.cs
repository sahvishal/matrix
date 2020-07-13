namespace Falcon.Entity.MedicalVendor
{    
    public class EMVUserClassification
    {
        private int m_iMVUserClassificationID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique MVUserClassification id
        /// </summary>        
        public int MVUserClassificationID
        {
            get
            {
                return m_iMVUserClassificationID;
            }
            set
            {
                m_iMVUserClassificationID = value;
            }
        }

        /// <summary>
        /// MVUserClassification name
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
        /// MVUserClassification description
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
        /// MVUserClassification status
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
