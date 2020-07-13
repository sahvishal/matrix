        
using System;


namespace Falcon.Entity.Other
{   
    
    public class ETask
    {
        private int m_iTaskID = 0;
        private string m_strSubject = string.Empty;
        private string m_strNotes = string.Empty;
        private string m_strStartDate = string.Empty;
        private string m_strStartTime = string.Empty;
        private string m_strEndDate = string.Empty;
        private string m_strDueDate = string.Empty;
        private string m_strDuetime = string.Empty;
        private string m_strContact = string.Empty;

        private bool m_bolActive = true;
        private int m_iCreatedBY = 0;
        private int m_iModifiedBY = 0;

        
        //private bool m_bolComplete = true;

        private ETaskPriorityType m_objTaskPriorityType;
        private ETaskType m_objTaskType;
        private ETaskStatusType m_objTaskStatusType;
        private User.EUserShellModuleRole m_objeusershellmodulerole=null;
        private Int64 m_iProspectID = 0;
        private Int64 m_iContactID = 0;

        /// <summary>
        /// Unique Task ID
        /// </summary>
        
        public int TaskID
        {
            get
            {
                return m_iTaskID;
            }
            set
            {
                m_iTaskID = value;
            }
        }

        /// <summary>
        /// Task Subject
        /// </summary>
        
        public string Subject
        {
            get
            {
                return m_strSubject;
            }
            set
            {
                m_strSubject = value;
            }
        }
        /// <summary>
        /// Task Contact
        /// </summary>
        
        public string Contact
        {
            get
            {
                return m_strContact;
            }
            set
            {
                m_strContact = value;
            }
        }

       

        /// <summary>
        /// Start Date of task
        /// </summary>
        
        public string StartDate
        {
            get
            {
                return m_strStartDate;
            }
            set
            {
                m_strStartDate = value;
            }
        }

        /// <summary>
        /// Start Time of task
        /// </summary>
        
        public string StartTime
        {
            get
            {
                return m_strStartTime;
            }
            set
            {
                m_strStartTime = value;
            }
        }
        /// <summary>
        /// End Date of task
        /// </summary>
        
        public string EndDate
        {
            get
            {
                 return m_strEndDate ;
            }
            set
            {
                m_strEndDate = value;
            }
        }

        /// <summary>
        /// Due Date
        /// </summary>
        
        public string DueDate
        {
            get
            {
                return m_strDueDate;
            }
            set
            {
                m_strDueDate = value;
            }
        }

        /// <summary>
        /// Due Date
        /// </summary>
        
        public string DueTime
        {
            get
            {
                return m_strDuetime;
            }
            set
            {
                m_strDuetime = value;
            }
        }


        /// <summary>
        /// Task Notes
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
        /// status of Task
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

        /// <summary>
        /// status of Task
        /// </summary>
        //
        //public bool Complete
        //{
        //    get
        //    {
        //        return m_bolComplete;
        //    }
        //    set
        //    {
        //        m_bolComplete = value;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        
        public int CreatedBY
        {
            get
            {
                return m_iCreatedBY;
            }
            set
            {
                m_iCreatedBY = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public int ModifiedBY
        {
            get
            {
                return m_iModifiedBY;
            }
            set
            {
                m_iModifiedBY = value;
            }
        }
        /// <summary>
        /// TaskPriorityType object for mapping task with TaskPriorityType
        /// </summary>

        
        public ETaskPriorityType TaskPriorityType
        {
            get
            {
                return m_objTaskPriorityType;
            }
            set
            {
                m_objTaskPriorityType = value;
            }
        }
        /// <summary>
        /// TaskStatusType object for mapping task with TaskStatusType
        /// </summary>
        
        public ETaskStatusType TaskStatusType
        {
            get
            {
                return m_objTaskStatusType;
            }
            set
            {
                m_objTaskStatusType = value;
            }
        }
        /// <summary>
        /// TaskType object for mapping task with TaskType
        /// </summary>
        
        public ETaskType TaskType
        {
            get
            {
                return m_objTaskType;
            }
            set
            {
                m_objTaskType = value;
            }
        }

        
        public User.EUserShellModuleRole UserShellModule
        {
            get
            {
                return m_objeusershellmodulerole;
            }
            set
            {
                m_objeusershellmodulerole = value;
            }

        }
        /// <summary>
        /// Prospect ID
        /// </summary>
        
        public Int64 ProspectID
        {
            get
            {
                return m_iProspectID;
            }
            set
            {
                m_iProspectID = value;
            }
        }

        /// <summary>
        /// Contact ID
        /// </summary>
        
        public Int64 ContactID
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

        #region Added w\ Calendar Enhancement

        
        public string EventName
        {
            get;
            set;
        }

        
        public long EventID
        {
            get;
            set;
        }

        
        public string EventDate
        {
            get;
            set;
        }

        
        public string HostOrgName
        {
            get;
            set;
        }

        
        public string HostAddress
        {
            get;
            set;
        }

        
        public string OwnerName
        {
            get;
            set;
        }

        #endregion

    }
}


