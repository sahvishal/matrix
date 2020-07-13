using System;

namespace Falcon.Entity.CallCenter
{
    [Serializable]
    public class EScript
    {
        private int m_iScriptID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private string m_strScriptText = string.Empty;
        private bool m_bolDefault = true;
        private bool m_bolActive = true;
        private EScriptType m_objScriptType;

        /// <summary>
        /// unique script id
        /// </summary>
        public int ScriptID
        {
            get
            {
                return m_iScriptID;
            }
            set
            {
                m_iScriptID = value;
            }
        }

        /// <summary>
        /// script name
        /// </summary>
        public string Name
        {
            get
            {
                return m_strName;
            }
            set 
            {
                m_strName = value;
            }
        }

        /// <summary>
        /// script description
        /// </summary>
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        /// <summary>
        /// script text
        /// </summary>
        public string ScriptText
        {
            get
            {
                return m_strScriptText;
            }
            set
            {
                m_strScriptText = value;
            }
        }
       /// <summary>
       /// default script
       /// </summary>
        public bool Default
        {
            get
            {

                return m_bolDefault;
            }
            set
            {
                m_bolDefault = value;
            }
        }

        /// <summary>
        /// script status
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
        /// <summary>
        /// ScriptType object for mapping script with ScriptType 
        /// </summary>
        public EScriptType ScriptType
        {
            get { return m_objScriptType; }
            set { m_objScriptType = value; }
        }

    }
}
