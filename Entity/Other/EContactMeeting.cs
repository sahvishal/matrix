using System;

namespace Falcon.Entity.Other
{   
    public class EContactMeeting
    {

        private int m_iContactmeetingID = 0;
        private string m_strSubject = string.Empty;
        private string m_strdescription = string.Empty;       
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

        private string m_strVenue = string.Empty;

        private EContact m_objContact;
        private ECallStatus m_objCallStatus;
        private User.EUserShellModuleRole m_objeusershellmodulerole = null;

        private string m_strFollowUpDate = string.Empty;
        private int m_iMeetingType = 0;
        private Int64 m_iProspectID = 0;
        private string strProspect = string.Empty;

        /// <summary>
        /// Unique ContactMeetingID
        /// </summary>       
        public int ContactMeetingID
        {
            get
            {
                return m_iContactmeetingID;
            }
            set
            {
                m_iContactmeetingID = value;
            }
        }
        /// <summary>
        /// Subject of meeting
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
        /// Description Of meeting
        /// </summary>        
        public string Description
        {
            get
            {
                return m_strdescription;
            }
            set
            {
                m_strdescription = value;

            }
        }       
       
        /// <summary>
        /// Start date Of meeting
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
        /// Start time of meeting
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
        /// duration of the meeting
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
        /// userid of assigned Person
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
        /// UserId Of person who Created meeting
        /// </summary>        
        public int CreatedByUserId
        {
            get
            {
                return m_icreatedByUserid; ;
            }
            set
            {
                m_icreatedByUserid = value;
            }
        }
        /// <summary>
        /// ShellId Of person who Created meeting
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
        /// RoleId Of person who Created meeting
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
        
        public string Venue
        {
            get
            {
                return m_strVenue;

            }
            set
            {
                m_strVenue = value;
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

        
        public string FollowUpDate
        {
            get
            {
                return m_strFollowUpDate;
            }
            set
            {
                m_strFollowUpDate = value;
            }
        }
        
        public int MeetingType
        {
            get
            {
                return m_iMeetingType;
            }
            set
            {
                m_iMeetingType = value;
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
        /// Prospect Name
        /// </summary>        
        public string ProspectName
        {
            get
            {
                return strProspect;
            }
            set
            {
                strProspect = value;
            }
        }
        
    }

}

    
