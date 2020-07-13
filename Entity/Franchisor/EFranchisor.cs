      
using System;
using Falcon.Entity.Other;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class EFranchisor
    {
        private int m_iFranchisorID = 0;
        private string m_strFranchisorName = string.Empty;
        private string m_strDescription = string.Empty;
        private EAddress  m_iBusinessAddress = null;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique Franchisor ID
        /// </summary>
        public int FranchisorID
        {
            get
            {
                return m_iFranchisorID;
            }
            set
            {
                m_iFranchisorID = value;
            }
        }

        /// <summary>
        /// franchisor name
        /// </summary>
        public string FranchisorName
        {
            get
            {
                return m_strFranchisorName;
            }
            set
            {
                m_strFranchisorName = value;
            }
        }

        /// <summary>
        /// franchisor description
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
        ///  franchisor business address
        /// </summary>
        public EAddress BusinessAddress
        {
            get
            {
                return m_iBusinessAddress;
            }
            set
            {
                m_iBusinessAddress = value;
            }
        }

        /// <summary>
        /// franchisor status
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
