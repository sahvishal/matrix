using System.Collections.Generic;

namespace Falcon.Entity.Other
{   
    
    public class EScheduleTemplate
    {
        private int m_iScheduleTemplateID;
        private string m_strName;
        private string m_strDescription;
        private bool m_bolGlobal;
        private bool m_bolCreatedByRole;
        private bool m_bolModifiedByRole;
        private long m_iCreateBy;
        private long m_iModifiedBy;
        private bool m_bolIsActive;
        private string m_DateCreated;
        private string m_DateModified;
        
        private List<EScheduleTemplateFranchiseeAccess> m_lstScheduleTemplateFranchiseeAccess = null;
        private List<EScheduleTemplateTime> m_lstScheduleTemplateTime = null;


        
        public int ScheduleTemplateID
        {
            get { return m_iScheduleTemplateID; }
            set { m_iScheduleTemplateID = value; }
        }

        
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }

        
        public bool Global
        {
            get { return m_bolGlobal; }
            set { m_bolGlobal = value; }
        }

        
        public bool CreatedByRole
        {
            get { return m_bolCreatedByRole; }
            set { m_bolCreatedByRole = value; }
        }

        
        public bool ModifiedByRole
        {
            get { return m_bolModifiedByRole; }
            set { m_bolModifiedByRole = value; }
        }

        
        public long CreateBy
        {
            get { return m_iCreateBy; }
            set { m_iCreateBy = value; }
        }

        
        public long ModifiedBy
        {
            get { return m_iModifiedBy; }
            set { m_iModifiedBy = value; }
        }

        
        public bool IsActive
        {
            get { return m_bolIsActive; }
            set { m_bolIsActive = value; }
        }

        
        public List<EScheduleTemplateFranchiseeAccess> ScheduleTemplateFranchiseeAccess
        {
            get { return m_lstScheduleTemplateFranchiseeAccess; }
            set { m_lstScheduleTemplateFranchiseeAccess = value; }
        }

        
        public List<EScheduleTemplateTime> ScheduleTemplateTime
        {
            get { return m_lstScheduleTemplateTime; }
            set { m_lstScheduleTemplateTime = value; }
        }

        
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


    }
}
