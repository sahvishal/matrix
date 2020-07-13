using System;

namespace Falcon.Entity.Other
{
    [Serializable]
    public class EState
    {
        
        private int m_iStateID = 0;
        private string m_strStateName = string.Empty;
        private string m_strStateDescription = string.Empty;
        private ECountry m_objCountry;
        private bool m_bolActive = true;
        private string m_strStateCode = string.Empty;

        /// <summary>
        /// unique state id
        /// </summary>
        
        public int StateID
        {
            get { return m_iStateID; }
            set { m_iStateID = value; }
        }

        /// <summary>
        /// state name
        /// </summary>
        
        public string Name
        {
            get { return m_strStateName; }
            set { m_strStateName = value; }
        }

        /// <summary>
        /// state description
        /// </summary>
        
        public string Description
        {
            get { return m_strStateDescription; }
            set { m_strStateDescription = value; }
        }
        /// <summary>
        /// country object for mapping state with country 
        /// </summary>
        
        public ECountry Country
        {
            get { return m_objCountry; }
            set { m_objCountry = value; }
        }
        /// <summary>
        /// state status
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

        
        public string StateCode
        {
            get
            {
                return m_strStateCode;
            }
            set
            {
                m_strStateCode = value;
            }
        }
    }
}
