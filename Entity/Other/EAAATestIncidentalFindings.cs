using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    public class EAAATestIncidentalFindings
    {
        private int m_iAAATestIncidentalFindingID=0;
        private EIncidentalFindings m_objIncidentalFindings = null;
        private int m_iUserID=0;
        private int m_iShellID=0;
        private int m_iRoleID=0;
        private bool m_bolActive;
        private List<EAAALocationWiseData> m_objAAALocationWiseData = null;

        /// <summary>
        /// 
        /// </summary>        
        public List<EAAALocationWiseData> AAALocationWiseData
        {
            get { return m_objAAALocationWiseData; }
            set { m_objAAALocationWiseData = value; }
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
        /// EIncidentalFindings object for mapping EAAATestIncidentalFindings with EIncidentalFindings
        /// </summary>        
        public EIncidentalFindings IncidentalFindings
        {
            get { return m_objIncidentalFindings; }
            set { m_objIncidentalFindings = value; }
        }
	
        /// <summary>
        /// master id
        /// </summary>       
        public int AAATestIncidentalFindingID
        {
            get { return m_iAAATestIncidentalFindingID; }
            set { m_iAAATestIncidentalFindingID = value; }
        }

    }
}
