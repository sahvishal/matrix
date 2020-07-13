using System;
using Falcon.Entity.Other;

namespace Falcon.Entity.CallCenter
{
    [Serializable]
    public class ECallCenter
    {
        private int m_iCallCenterID = 0;
        private string m_strBusinessName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private string m_strBusinessPhone = string.Empty;
        private string m_strBusinessFax = string.Empty;
        private EAddress m_objBusinessAddress;
        

        /// <summary>
        /// unique callcenter id
        /// </summary>
        public int CallCenterID
        {
            get
            {
                return m_iCallCenterID;
            }
            set
            {
                m_iCallCenterID = value;
            }
        }

        /// <summary>
        /// callcenter business name
        /// </summary>
        public string BusinessName
        {
            get
            {
                return m_strBusinessName;
            }
            set
            {
                m_strBusinessName = value;
            }
        }

        /// <summary>
        /// callsenter description
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
        /// callcenter status
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
        /// 
        /// </summary>
        public EAddress BusinessAddress
        {
            get { return m_objBusinessAddress; }
            set { m_objBusinessAddress = value; }
        }
	

        /// <summary>
        /// callcenter business phone
        /// </summary>
        public string BusinessPhone
        {
            get
            {
                return m_strBusinessPhone;
            }
            set
            {
                m_strBusinessPhone = value;
            }
        }

        /// <summary>
        /// callcenter business fax
        /// </summary>
        public string BusinessFax
        {
            get
            {
                return m_strBusinessFax;
            }
            set
            {
                m_strBusinessFax = value;
            }
        }
    }
}
