using System;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.Entity.Other
{   
    public class EContactCall
    {
        private int m_iContactcallID = 0;
        private string m_strSubject = string.Empty;
        private string m_strNotes = string.Empty;
        private bool m_bolIsinbound = true;
        private string m_strStartDate = string.Empty;
        private string m_strStartTime = string.Empty;
        private decimal m_strDuration = 0;
       

        private int m_iAssignedtoUserid = 0;
        private int m_iAssignedToShellid = 0;
        private int m_iAssignedToRoleid = 0;

        private int m_icreatedByUserid = 0;
        private int m_icreatedByShellid = 0;
        private int m_icreatedByRoleid = 0;

        private bool m_bolReminder = true;
        private bool m_bolActive = true;

      

        private EContact m_objContact;
        private ECallStatus m_objCallStatus;
        private User.EUserShellModuleRole m_objeusershellmodulerole = null;

        private int m_iCallResult = 0;
        private int m_iFutureAction= 0;
        private Int64 m_iProspectID = 0;
        private string m_strType = string.Empty;

        private string m_strProspectName = string.Empty;

       
        /// <summary>
        /// Unique ContactCallID
        /// </summary>        
        public int ContactCallID
        {
            get
            {
                return m_iContactcallID;
            }
            set
            {
                m_iContactcallID = value;
            }
        }
        /// <summary>
        /// Subject of Call
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
        /// Notes regarding call
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
        public bool IsInbound
        {
            get
            {
                return m_bolIsinbound;
            }
            set
            {
                m_bolIsinbound = value;
            }
        }
        /// <summary>
        /// Start date Of call
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
        /// Start time of Call
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
        /// duration of the call
        /// </summary>        
        public decimal Duration
        {
            get
            {
                return m_strDuration;
            }
            set
            {
                m_strDuration = value;
            }
        }
        /// <summary>
        /// userid to assigned Person
        /// </summary>        
        public int AssignedToUserId
        {
            get
            {
                return m_iAssignedtoUserid;
            }
            set
            {
                m_iAssignedtoUserid = value;
            }
        }
        /// <summary>
        /// shellid of assigned person
        /// </summary>        
        public int AssignedToShellID
        {
            get
            {
                return m_iAssignedToShellid;
            }
            set
            {
                m_iAssignedToShellid = value;
            }
        }
        /// <summary>
        /// roleid of assigned person
        /// </summary>        
        public int AssignedToRoleID
        {
            get
            {
                return m_iAssignedToRoleid;
            }
            set
            {
                m_iAssignedToRoleid = value;
            }
        }
        /// <summary>
        /// Reminder 
        /// </summary>        
        public bool Reminder
        {
            get
            {
                return m_bolReminder;
            }
            set
            {
                m_bolReminder = value;
            }
        }
        /// <summary>
        /// UserId Of person who Created Call
        /// </summary>        
        public int CreatedByUserId
        {
            get
            {
                return m_icreatedByUserid; 
            }
            set
            {
                m_icreatedByUserid = value;
            }
        }
        /// <summary>
        /// ShellId Of person who Created Call
        /// </summary>        
        public int CreatedByShellID
        {
            get
            {
                return m_icreatedByShellid;
            }
            set
            {
                m_icreatedByShellid = value;
            }
        }
        /// <summary>
        /// RoleId Of person who Created Call
        /// </summary>        
        public int CreatedByRoleID
        {
            get
            {
                return m_icreatedByRoleid;
            }
            set
            {
                m_icreatedByRoleid = value;
            }
        }
        /// <summary>
        /// Call is Active Or not 
        /// </summary>        
        public bool IsActive
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
        /// To mapping with Contact
        /// </summary>        
        public EContact Contact
        {
            get
            {
                return m_objContact;
            }
            set
            {
                m_objContact = value;
            }
        }


        
        /// <summary>
        /// To mapping with CallStatus
        /// </summary>        
        public ECallStatus CallStatus
        {
            get
            {
                return m_objCallStatus;
            }
            set
            {
                m_objCallStatus = value;
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
        ///  New Added Field Call Result
        /// </summary>        
        public int CallResult
        {
            get
            {
                return m_iCallResult;
            }
            set
            {
                m_iCallResult = value;
            }
        }

        /// <summary>
        ///  New Added Field Future Action
        /// </summary>        
        public int FutureAction
        {
            get
            {
                return m_iFutureAction;
            }
            set
            {
                m_iFutureAction = value;
            }
        }

        /// <summary>
        ///  Prospect ID
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
        /// Type - Call Meeting Task
        /// </summary>        
        public string Type
        {
            get
            {
                return m_strType ;
            }
            set
            {
                m_strType = value;

            }
        }
        /// <summary>
        /// Prospect Name for call
        /// </summary>        
        public string ProspectName
        {
            get
            {
                return m_strProspectName;
            }
            set
            {
                m_strProspectName = value;

            }
        }
        public CallStatus? CurrentCallStatus { get; set; }
    }

}