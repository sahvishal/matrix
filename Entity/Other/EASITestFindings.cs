namespace Falcon.Entity.Other
{
    public class EASITestFindings
    {
        private int m_iASITestFindingID = 0;
        private string m_strLabel = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private string m_strCritical = "0";

        /// <summary>
        /// Used for assisting comparison with the values in Input Boxes.
        /// </summary>        
        public string ComparisonLabel { get; set; }

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
        public int ASITestFindingID
        {
            get { return m_iASITestFindingID; }
            set { m_iASITestFindingID = value; }
        }
    }
}
