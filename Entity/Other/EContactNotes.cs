namespace Falcon.Entity.Other
{    
    public class EContactNotes
    {
        private int m_iContactNoteID = 0;
        private int m_iContactID = 0;
        private string m_strNotes = string.Empty;
        private int m_iNotesSequence = 0;     

        
        public int ContactNoteID
        {
            get
            {
                return m_iContactNoteID;
            }
            set
            {
                m_iContactNoteID = value;
            }
        }
        
        
        public int ContactID
        {
            get
            {
                return m_iContactID;
            }
            set
            {
                m_iContactID = value;
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
