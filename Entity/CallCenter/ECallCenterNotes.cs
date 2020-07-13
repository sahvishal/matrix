using System;

namespace Falcon.Entity.CallCenter
{
    [Serializable]
    public class ECallCenterNotes
    {
        private int m_iCallCenterNotesID = 0;
        private long m_CallID = 0;
        private string m_Notes = string.Empty;
        private string m_DateCreated = string.Empty;
        private string m_DateModified = string.Empty;
        private bool m_IsActive = true;

        ///<summary>
        ///CallCenterNotes Id
        ///</summary>
        public int CallCenterNotesID
        {
            get
            {
                return m_iCallCenterNotesID;
            }
            set
            {
                m_iCallCenterNotesID = value;
            }
        }
        ///<summary>
        ///Call Id
        ///</summary>
        public long CallID
        {
            get
            {
                return m_CallID;
            }
            set
            {
                m_CallID = value;
            }
        }
        ///<summary>
        ///Notes 
        ///</summary>
        public string Notes
        {
            get
            {
                return m_Notes;
            }
            set
            {
                m_Notes = value;
            }
        }
        ///<summary>
        ///Date Created
        ///</summary>
        public string DateCreated
        {
            get
            {
                return m_DateCreated;
            }
            set
            {
                m_DateCreated = value;
            }
        }
        ///<summary>
        ///Date Modified
        ///</summary>
        public string DateModified
        {
            get
            {
                return m_DateModified;
            }
            set
            {
                m_DateModified = value;
            }
        }
        ///<summary>
        ///IsActive
        ///</summary>
        public bool IsActive
        {
            get
            {
                return m_IsActive;
            }
            set
            {
                m_IsActive = value;
            }
        }
        
    }
}
