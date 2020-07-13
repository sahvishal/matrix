namespace Falcon.Entity.Other
{   
    
    public class EScheduleTemplateTime
    {
        private int m_iScheduleTemplateTimeID;
        private int m_iScheduleTemplateID;
        private string m_strStartTime = string.Empty;
        private short m_shtAppointmentCount;
	

        
        public int ScheduleTemplateTimeID
        {
            get { return m_iScheduleTemplateTimeID; }
            set { m_iScheduleTemplateTimeID = value; }
        }

        
        public int ScheduleTemplateID
        {
            get { return m_iScheduleTemplateID; }
            set { m_iScheduleTemplateID = value; }
        }

        
        public string StartTime
        {
            get { return m_strStartTime; }
            set { m_strStartTime = value; }
        }

        
        public short AppointmentCount
        {
            get { return m_shtAppointmentCount; }
            set { m_shtAppointmentCount = value; }
        }

    }
}
