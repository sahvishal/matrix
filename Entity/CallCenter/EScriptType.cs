using System;

namespace Falcon.Entity.CallCenter
{
    [Serializable]
    public class EScriptType
    {
        private int m_iScriptTypeID = 0;
        private string m_strScriptName = string.Empty;
        private string m_strScriptDescription = string.Empty;
        private bool m_bolActive = true;

        /// <summary>
        /// unique scriptype id
        /// </summary>

        public int ScriptTypeID
        {
            get 
            {
                return m_iScriptTypeID; 
            }
            set
            {
                m_iScriptTypeID = value; 
            }
        }
        /// <summary>
        /// scriptype name
        /// </summary>
        public string ScriptName
        {
            get
            { 
                return m_strScriptName; 
            }
            set
            { 
                m_strScriptName = value; 
            }
        }
        /// <summary>
        /// scriptype description
        /// </summary>
        
        public string Description
        {
            get
            { 
                return m_strScriptDescription; 
            }
            set
            {
                m_strScriptDescription = value; 
            }
        }
       
        /// <summary>
        /// scriptype status
        /// </summary>
        
        public bool Active
        {
            get
            {

                return m_bolActive;
            }
            set
            {
                m_bolActive = value;
            }
        }

    }
}
