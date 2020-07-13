namespace Falcon.Entity.Other
{
    public class ECarotidArteryTestFindings
    {
        private int m_iCATTestFindingID = 0;
        private string m_strLabel = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private string m_strCritical = "0";

        /// <summary>
        /// 
        /// </summary>        
        public string Critical
        {
            get { return m_strCritical; }
            set { m_strCritical = value; }
        }


        /// <summary>
        /// status of the object
        /// </summary>        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }

        /// <summary>
        /// descption about he findings
        /// </summary>        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }

        /// <summary>
        /// name of the finding
        /// </summary>        
        public string Label
        {
            get { return m_strLabel; }
            set { m_strLabel = value; }
        }


        /// <summary>
        /// master id
        /// </summary>        
        public int CATTestFindingID
        {
            get { return m_iCATTestFindingID; }
            set { m_iCATTestFindingID = value; }
        }
    }
}
