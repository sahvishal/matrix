using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    public class EBlockedDay
    {
        private int m_iBlockedDayID = 0;
        private bool m_bolIsActive = true;
        private string m_strBlockedDate = string.Empty;
        private string m_strBlockedReason = string.Empty;
        private List<EBlockedDayFranchisee> m_objBFranchisee = null;
        private bool m_bolGlobal = false;
        
        public int BlockedDayID
        {
            get
            {
                return m_iBlockedDayID;
            }
            set
            {
                m_iBlockedDayID = value;
            }
        }

        
        public bool IsActive
        {
            get
            {
                return m_bolIsActive;
            }
            set
            {
                m_bolIsActive = value;
            }
        }

        
        public string BlockedDate
        {
            get
            {
                return m_strBlockedDate;
            }
            set
            {
                m_strBlockedDate = value;
            }
        }

        
        public string BlockedReason
        {
            get
            {
                return m_strBlockedReason;
            }
            set
            {
                m_strBlockedReason = value;
            }
        }

        
        public List<EBlockedDayFranchisee> BlockDayFranchisee
        {
            get
            {
                return m_objBFranchisee;
            }
            set
            {
                m_objBFranchisee = value;
            }
        }


        /// <summary>
        /// IsGlobal status
        /// </summary>        
        public bool IsGlobal
        {
            get
            {

                return m_bolGlobal;
            }
            set
            {
                m_bolGlobal = value;
            }
        }
    }
}
