      
using System;

namespace Falcon.Entity.Other
{
    
    public class EContract
    {
        private int m_iContractID = 0;
        private string m_strName = string.Empty;
        private string m_strContract = string.Empty;
        private string m_strDescription = string.Empty;
        private EState m_objState;
        private bool m_bolActive = true;
        private string m_strStartDate = string.Empty;
        private string m_strEndDate = string.Empty;

        /// <summary>
        /// unique contract id
        /// </summary>        
        public int ContractID
        {
            get
            {
                return m_iContractID;
            }
            set
            {
                m_iContractID = value;
            }
        }
        /// <summary>
        /// contract name
        /// </summary>       
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        /// <summary>
        /// contract description
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
        /// contract text
        /// </summary>        
        public string Contract
        {
            get { return m_strContract; }
            set { m_strContract = value; }
        }

        /// <summary>
        /// contract status
        /// </summary>        
        public Boolean Active
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
        /// state object for mapping contract with state
        /// </summary>        
        public EState State
        {
            get
            {
                return m_objState;
            }
            set
            {
                m_objState = value;
            }
        }

        /// <summary>
        /// StartDate
        /// </summary>       
        public string StartDate
        {
            get { return m_strStartDate; }
            set { m_strStartDate = value; }
        }

        /// <summary>
        /// StartDate
        /// </summary>        
        public string EndDate
        {
            get { return m_strEndDate; }
            set { m_strEndDate = value; }
        }
    }

}
