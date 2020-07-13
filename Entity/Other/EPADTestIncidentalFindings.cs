namespace Falcon.Entity.Other
{   
    
    public class EPADTestIncidentalFindings
    {
        private int m_iPADTestIncidentalFindingID = 0;
        private EIncidentalFindings m_objIncidentalFindings = null;
        private string m_strNotes = string.Empty;
        private int m_iUserID = 0;
        private int m_iShellID = 0;
        private int m_iRoleID = 0;
        private bool m_bolActive;


        /// <summary>
        /// status of the record
        /// </summary>
        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }


        /// <summary>
        /// role id of the concerned person
        /// </summary>
        
        public int RoleID
        {
            get { return m_iRoleID; }
            set { m_iRoleID = value; }
        }

        /// <summary>
        /// shell id of the concerned person
        /// </summary>
        
        public int ShellID
        {
            get { return m_iShellID; }
            set { m_iShellID = value; }
        }

        /// <summary>
        /// userid of the concerned person
        /// </summary>
        
        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }


        /// <summary>
        /// extra info about the evaluation
        /// </summary>
        
        public string Notes
        {
            get { return m_strNotes; }
            set { m_strNotes = value; }
        }

        /// <summary>
        /// EIncidentalFindings object for mapping EPADTestIncidentalFindings with EIncidentalFindings
        /// </summary>
        
        public EIncidentalFindings IncidentalFindings
        {
            get { return m_objIncidentalFindings; }
            set { m_objIncidentalFindings = value; }
        }

        /// <summary>
        /// master id
        /// </summary>
        
        public int PADTestIncidentalFindingID
        {
            get { return m_iPADTestIncidentalFindingID; }
            set { m_iPADTestIncidentalFindingID = value; }
        }
    }
}
