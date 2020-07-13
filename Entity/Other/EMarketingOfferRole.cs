using System;

namespace Falcon.Entity.Other
{
    public class EMarketingOfferRole
    {
        private Int64 m_iMarketingOfferID = 0;
        private Int64 m_iRoleID = 0;
        private string  m_strRoleName =string.Empty;
        private int m_iRowState = 0;

        /// <summary>
        /// marketing offer id
        /// </summary>
        
        public Int64 MarketingOfferID
        {
            get { return m_iMarketingOfferID; }
            set { m_iMarketingOfferID = value; }
        }
        /// <summary>
        /// Role id
        /// </summary>
        
        public Int64 RoleID
        {
            get { return m_iRoleID; }
            set { m_iRoleID = value; }
        }
        /// <summary>
        /// Role Name
        /// </summary>
        
        public string RoleName
        {
            get
            {
                return m_strRoleName;
            }
            set
            {
                m_strRoleName = value;
            }
        }
        /// <summary>
        /// Rowstate
        /// </summary>
        
        public int RowState
        {
            get { return m_iRowState; }
            set { m_iRowState = value; }
        }  
    }
}
