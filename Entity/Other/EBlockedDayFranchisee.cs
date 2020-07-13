using Falcon.Entity.Franchisee;

namespace Falcon.Entity.Other
{    
    public class EBlockedDayFranchisee
    {
        private int m_iBlockedDayFranchiseeID = 0;
        private int m_iBlockedDayID = 0;
        private bool m_bolIsActive = true;
        // private int m_iFranchiseeID = 0;
        private EFranchisee m_objFranchisee = null;
        
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

        
        public int BlockedDayFranchiseeID
        {
            get
            {
                return m_iBlockedDayFranchiseeID;
            }
            set
            {
                m_iBlockedDayFranchiseeID = value;
            }
        }

        //
        //public int FranchiseeID
        //{
        //    get
        //    {
        //        return m_iFranchiseeID;
        //    }
        //    set
        //    {
        //        m_iFranchiseeID = value;
        //    }
        //}

        
        public EFranchisee Franchisee
        {
            get
            {
                return m_objFranchisee;
            }
            set
            {
                m_objFranchisee = value;
            }
        }

    }
}
