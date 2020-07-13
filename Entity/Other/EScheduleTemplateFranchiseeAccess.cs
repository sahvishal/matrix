namespace Falcon.Entity.Other
{   
    
    public class EScheduleTemplateFranchiseeAccess
    {
        private int m_iScheduleTemplateFranchiseeAccessID;
        private int m_iScheduleTemplateID;
        private long m_iFranchiseeID;
        private bool m_bolIsActive;


        
        public int ScheduleTemplateFranchiseeAccessID
        {
            get { return m_iScheduleTemplateFranchiseeAccessID; }
            set { m_iScheduleTemplateFranchiseeAccessID = value; }
        }

        
        public int ScheduleTemplateID
        {
            get { return m_iScheduleTemplateID; }
            set { m_iScheduleTemplateID = value; }
        }

        
        public long FranchiseeID
        {
            get { return m_iFranchiseeID; }
            set { m_iFranchiseeID = value; }
        }

        
        public bool IsActive
        {
            get { return m_bolIsActive; }
            set { m_bolIsActive = value; }
        }
	
            
    }
}
