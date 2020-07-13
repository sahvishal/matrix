       
using System;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class EFranchisorFranchisorUser
    {
        private int m_iFranchisorFranchisorUserID = 0;
        private EFranchisor m_objFranchisor;
        private EFranchisorUser m_objFranchisorUser;
        private bool m_bolActive = true;
        private bool m_bolDefault = true;


        /// <summary>
        /// Unique franchisorFranchisor user ID
        /// </summary>
        public int FranchisorFranchisorUserID
        {
            get
            {
                return m_iFranchisorFranchisorUserID;
            }
            set
            {
                m_iFranchisorFranchisorUserID = value;
            }
        }

        /// <summary>
        ///franchisor user object
        /// </summary>
        public EFranchisorUser FranchisorUser
        {
            get
            {
                return m_objFranchisorUser;
            }
            set
            {
                m_objFranchisorUser = value;
            }
        }

        /// <summary>
        ///franchisor object
        /// </summary>
        public EFranchisor Franchisor
        {
            get
            {
                return m_objFranchisor;
            }
            set
            {
                m_objFranchisor = value;
            }
        }

        /// <summary>
        /// FranchisorFranchisor user status
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
        /// FranchisorFranchisor user status
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

        
    }
}







