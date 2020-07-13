 
using System;

namespace Falcon.Entity.Other
{
    public class EOsteoporisisTestIncidentalFindings
    {
        private int m_iOSTTestIncidentalFindingID = 0;
        private EIncidentalFindings m_objIncidentalFindings = null;
        private Int16 m_iLocation = 0;
        private string m_strSize = string.Empty;
        private Int16 m_iSonographicAppreance=0;
        private string m_strNotes = string.Empty;
        private bool m_bolFurtherEvaluation = true;
        private int m_iUserID = 0;
        private int m_iShellID = 0;
        private int m_iRoleID = 0;
        private bool m_bolActive;
        private string m_strBP = string.Empty;

        /// <summary>
        /// info about the BP
        /// </summary>
        
        public string ElevatedBloodPressure
        {
            get { return m_strBP; }
            set { m_strBP = value; }
        }

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
        /// further evaluation flag
        /// </summary>
        
        public bool FurtherEvaluation
        {
            get { return m_bolFurtherEvaluation; }
            set { m_bolFurtherEvaluation = value; }
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
        /// SonographicAppreance
        /// </summary>
        
        public Int16 SonographicAppreance
        {
            get { return m_iSonographicAppreance; }
            set { m_iSonographicAppreance = value; }
        }

        /// <summary>
        /// size
        /// </summary>
        
        public string Size
        {
            get { return m_strSize; }
            set { m_strSize = value; }
        }

        /// <summary>
        /// location of the person concerned
        /// </summary>
        
        public Int16 Location
        {
            get { return m_iLocation; }
            set { m_iLocation = value; }
        }

        /// <summary>
        /// EIncidentalFindings object for mapping EOsteoporisisTestIncidentalFindings with EIncidentalFindings
        /// </summary>
        
        public EIncidentalFindings IncidentalFindings
        {
            get { return m_objIncidentalFindings; }
            set { m_objIncidentalFindings = value; }
        }

        /// <summary>
        /// master id
        /// </summary>
        
        public int OsteoporisisTestIncidentalFindingID
        {
            get { return m_iOSTTestIncidentalFindingID; }
            set { m_iOSTTestIncidentalFindingID = value; }
        }
    }
}
