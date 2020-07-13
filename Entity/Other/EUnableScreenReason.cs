
using System;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{   
    
    public class EUnableScreenReason
    {
        private string m_strLabel;
        private Int16 m_shtUnableScreenReasonID;
        private ETest m_objTest = null;
        
        public bool IsNotesRequired { get; set; }
                
        
        /// <summary>
        /// 
        /// </summary>
        
        public string Notes { get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        
        public ETest Test
        {
            get { return m_objTest; }
            set { m_objTest = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public Int16 UnableScreenReasonID
        {
            get { return m_shtUnableScreenReasonID; }
            set { m_shtUnableScreenReasonID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Label
        {
            get { return m_strLabel; }
            set { m_strLabel = value; }
        }
	
    }
}
