namespace Falcon.Entity.MedicalVendor
{
    public class EMVMVUserNotes
    {
        private int m_iMVUserNotesID = 0;
        private int m_iMedicalVendorID = 0;
        private int m_iMVMVUserID = 0;
        private int m_iApplicationID = 0;
        private string m_strNotes = string.Empty;
        private int m_iNotesSequence = 0;
                
        public int MVUserNotesID
        {
            get
            {
                return m_iMVUserNotesID;
            }
            set 
            {
                m_iMVUserNotesID = value;
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
        
        public int MedicalVendorMVUserID
        {
            get
            {
                return m_iMVMVUserID;
            }
            set
            {
                m_iMVMVUserID = value; 
            }
        }
        
        public int Sequence
        {
            get
            {
                return m_iNotesSequence;
            }
            set
            {
                m_iNotesSequence = value; 
            }
        }
        
        public string Notes
        {
            get
            {
                return m_strNotes;
            }
            set
            {
                m_strNotes = value;
            }
        }

        
        public int ApplicationID
        {
            get
            {
                return m_iApplicationID;
            }
            set
            {
                m_iApplicationID = value;
            }
        }
    }
}
