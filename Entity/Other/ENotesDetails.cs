       
using System;

namespace Falcon.Entity.Other
{
    public class ENotesDetails
    {
        private Int64 m_iNoteID = 0;
        private string m_strNotes = string.Empty;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;

        /// <summary>
        /// unique notes id
        /// </summary>
        
        public Int64 NoteID
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
        /// Notes details
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
        /// Notes date created
        /// </summary>
        
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

        /// <summary>
        /// Notes date modified
        /// </summary>
        
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
    }
}
