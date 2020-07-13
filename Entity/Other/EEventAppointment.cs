namespace Falcon.Entity.Other
{
    public class EEventAppointment
    {
        private long m_iAppointmentID = 0;
        private int m_iEventID = 0;
        private int m_iScheduleByID = 0;
        private string m_strStartDate = string.Empty;
        private string m_strStartTime = string.Empty;
        private string m_strEndDate = string.Empty;
        private string m_strEndTime = string.Empty;
        private string m_strSubject = string.Empty;
        private string m_strReason = string.Empty;
        private string m_strCheckInTime = string.Empty;
        private string m_strCheckOutTime = string.Empty;
        private EUser m_objUser = null;
        private EEventPackage m_objEventPackage = null;
        private int m_iSlotType = 0;

        
        public long AppointmentID
        {
            get
            {
                return m_iAppointmentID;
            }
            set
            {
                m_iAppointmentID = value;
            }
        }

        
        public int EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }
        }

        
        public int ScheduleByID
        {
            get
            {
                return m_iScheduleByID;
            }
            set
            {
                m_iScheduleByID = value;
            }

        }

        
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

        
        public string EndTime
        {
            get
            {
                return m_strEndTime;
            }
            set
            {
                m_strEndTime = value;
            }
        }

        
        public string EndDate
        {
            get
            {
                return m_strEndDate;
            }
            set
            {
                m_strEndDate = value;
            }
        }

        
        public string Reason
        {
            get
            {
                return m_strReason;
            }
            set
            {
                m_strReason = value;
            }
        }

        
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
        
        
        public string CheckInTime
        {
            get { return m_strCheckInTime; }
            set { m_strCheckInTime = value; }
        }

        
        public string CheckOutTime
        {
            get { return m_strCheckOutTime; }
            set { m_strCheckOutTime = value; }
        }
        
        public EUser User
        {
            get
            {
                return m_objUser;
            }
            set
            {
                m_objUser = value;
            }
        }
        
        public EEventPackage EventPackage
        {
            get
            {
                return m_objEventPackage;
            }
            set
            {
                m_objEventPackage = value;
            }
        }
        /// <summary>
        /// Booked,Prefered and Non Prefered Slots.
        /// </summary>        
        public int SlotType
        {
            get
            {
                return m_iSlotType;
            }
            set
            {
                m_iSlotType = value;
            }
        }

	    
	
    
    }
}
