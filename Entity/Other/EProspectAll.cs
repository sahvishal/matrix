using System.Collections.Generic;

namespace Falcon.Entity.Other
{   
    
    public class EProspectAll
    {
        // prospect
        private EProspect m_Prospect=null;        
        // calls
        private List<EContactCall> m_Calls=null;
        // tasks
        private List<ETask> m_Task=null;
        // meetings
        private List<EContactMeeting> m_Meeting=null;
        // notes
        private List<ENotesDetails> m_NotesDetails=null;
        // All
        private List<EContactCall> m_All = null;

        /// <summary>
        /// prospect details
        /// </summary>
        
        public EProspect Prospect
        {
            get
            {
                return m_Prospect;
            }
            set
            {
                m_Prospect = value;
            }
        }

        /// <summary>
        /// calls list
        /// </summary>
        
        public List<EContactCall> Calls
        {
            get
            {
                return m_Calls;
            }
            set
            {
                m_Calls = value;
            }
        }

        /// <summary>
        /// task list
        /// </summary>
        
        public List<ETask> Tasks
        {
            get
            {
                return m_Task;
            }
            set
            {
                m_Task = value;
            }
        }
        /// <summary>
        /// meeting list
        /// </summary>
        
        public List<EContactMeeting> Meetings
        {
            get
            {
                return m_Meeting;
            }
            set
            {
                m_Meeting = value;
            }
        }

        /// <summary>
        /// prospect notes list
        /// </summary>
        
        public List<ENotesDetails> Notes
        {
            get
            {
                return m_NotesDetails;
            }
            set
            {
                m_NotesDetails = value;
            }
        }

        /// <summary>
        /// call,meeting and task
        /// </summary>
        
        public List<EContactCall> CallMeetingTask
        {
            get
            {
                return m_All;
            }
            set
            {
                m_All = value;
            }
        }
        
    }
}
