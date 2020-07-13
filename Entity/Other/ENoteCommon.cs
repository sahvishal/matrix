namespace Falcon.Entity.Other
{
    public class ENoteCommon
    {
        private int m_iNoteID = 0;
        private string m_strNotes = string.Empty;
        private int m_iNotesSequence = 0;
        private int m_iUserID;

        /// <summary>
        /// unique id
        /// </summary>
        
        public int NotesID
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

        /// <summary>
        /// notes for the entity
        /// </summary>
        
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

        /// <summary>
        /// 
        /// </summary>
        
        public int NoteSequence
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

        
        public int UserID
        {
            get
            {
                return m_iUserID;
            }
            set
            {
                m_iUserID = value;
            }
        }
    }
}
