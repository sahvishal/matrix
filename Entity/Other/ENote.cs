namespace Falcon.Entity.Other
{
    public class ENote
    {
        private int m_iNoteID = 0;
        private EApplication m_objApplication = null;
        private string m_strNotes = string.Empty;
        private int m_iNotesSequence = 0;
        private int m_iApplicationID = 0;

        
        public int FranchiseeNotesID
        {
            get
            {
                return m_iNoteID;
            }
            set
            {
                m_iNoteID = value;
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

        
        public EApplication Application
        {
            get
            {
                return m_objApplication;
            }
            set
            {
                m_objApplication = value;
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

        
        public int NotesSequence
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
    }
}
