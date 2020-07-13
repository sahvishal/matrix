using System;

namespace Falcon.Entity.Other
{
    public class EIncidentalFindings
    {
        private int m_iIncidentalFindingsID = 0;
        private Falcon.Entity.Franchisor.ETest m_objTest = null;
        private string m_strLabel;
        private string m_strDescription;
        private bool m_bolIsActive = true;
        private string m_strUCName = null;
        private Int16 m_shtLocationCount = 0;

        /// <summary>
        /// 
        /// </summary>
        
        public Int16 Sequence { get; set; }

        /// <summary>
        /// It assists in UI, by informing which IF to be opened as default.
        /// </summary>
        
        public bool IsDefault { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        
        public Int16 LocationCount
        {
            get { return m_shtLocationCount; }
            set { m_shtLocationCount = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public string UCName
        {
            get { return m_strUCName; }
            set { m_strUCName = value; }
        }
	

        /// <summary>
        /// 
        /// </summary>
        
        public bool IsActive
        {
            get { return m_bolIsActive; }
            set { m_bolIsActive = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public string Label
        {
            get { return m_strLabel; }
            set { m_strLabel = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public Falcon.Entity.Franchisor.ETest Test
        {
            get { return m_objTest; }
            set { m_objTest = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public int IncidentalFindingsID
        {
            get { return m_iIncidentalFindingsID; }
            set { m_iIncidentalFindingsID = value; }
        }
	
    }
}
