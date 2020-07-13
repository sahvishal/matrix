       
using System;

namespace Falcon.Entity.Franchisee
{
      [Serializable]
    public class EFranchiseeFranchiseeUser
    {
        private int m_iFranchiseeFranchiseeUserID=0;
        private int m_iContactAddressID=0;
        private int m_iRoleID=0;
        private string m_strRoleGroup = string.Empty;
        private bool m_bolActive = true;
        private bool m_bolDefault = true;
        private string m_strStartDate = string.Empty;
        private string m_strTerminationDate = string.Empty;
        private float m_fSalaryAdded = 0;
        private int m_iWageType = 0;
        private bool m_bolBGCheck=true;
        private int m_iWageFrequency = 0;
        private string m_strRoleType = string.Empty;

        private EFranchisee m_objFranchisee;
        private EFranchiseeUser m_objFranchiseeUser;
        private int m_iEventRoleID = 0;
        private bool m_bolReport=false;
        private string m_strEventRoleName = "";

        private int m_iAdvocateSalesManagerID = 0;
        private string m_strAdvocateSalesManager = string.Empty;


        /// <summary>
        /// 
        /// </summary>        
        public string EventRoleName
        {
            get { return m_strEventRoleName; }
            set { m_strEventRoleName = value; }
        }
	
	

        /// <summary>
        /// this attribute 
        /// </summary>        
        public bool ShowOnReport
        {
            get { return m_bolReport; }
            set { m_bolReport = value; }
        }
	
        
        /// <summary>
        /// 
        /// </summary>        
        public int EventRoleID
        {
            get { return m_iEventRoleID; }
            set { m_iEventRoleID = value; }
        }
	

         /// <summary>
        /// unique FranchiseeFranchiseeUser id 
        /// </summary>        
        public int FranchiseeFranchiseeUserID
        {
            get
            {
                return m_iFranchiseeFranchiseeUserID;
            }
            set
            {
                m_iFranchiseeFranchiseeUserID = value;
            }
        }

        /// <summary>
        /// role id
        /// </summary>        
        public int RoleID
        {
            get
            {
                return m_iRoleID;
            }
            set
            {
                m_iRoleID = value;
            }
        }

        /// <summary>
        /// Role Group
        /// </summary>        
        public string RoleGroup
        {
            get
            {
                return m_strRoleGroup;
            }
            set
            {
                m_strRoleGroup = value;
            }
        }

        /// <summary>
        /// contact address id
        /// </summary>        
        public int ContactAddressID
        {
            get
            {
                return m_iContactAddressID;
            }
            set
            {
                m_iContactAddressID = value;
            }
        }

        /// <summary>
        /// status of callcentercallcenter user
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
        /// franchisee object for mapping FranchiseeFranchiseeUser with franchisee
        /// </summary>        
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

        /// <summary>
        /// franchisee user object for mappint FranchiseeFranchiseeUser with FranchiseeUser
        /// </summary>        
        public EFranchiseeUser FranchiseeUser
        {
            get
            {
                return m_objFranchiseeUser;
            }
            set
            {
                m_objFranchiseeUser = value;
            }
        }

        /// <summary>
        /// start date  for franchiseefranchisee user
        /// </summary>        
        public string StartDate
        {
            get
            {
                return m_strStartDate;
            }
            set
            {
                m_strStartDate = value;
            }
        }

        /// <summary>
        /// termination date for franchiseefranchisee user
        /// </summary>        
        public string TerminationDate
        {
            get
            {
                return m_strTerminationDate;
            }
            set
            {
                m_strTerminationDate = value;
            }
        }

        /// <summary>
        /// salary added for franchiseefranchisee user
        /// </summary>        
        public float SalaryAdded
        {
            get
            {
                return m_fSalaryAdded;
            }
            set
            {
                m_fSalaryAdded = value;
            }
        }

        /// <summary>
        /// wage type for franchiseefranchisee user
        /// </summary>        
        public int WageType
        {
            get
            {
                return m_iWageType;
            }
            set
            {
                m_iWageType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool BGCheck
        {
            get
            {
                return m_bolBGCheck;
            }
            set
            {
                m_bolBGCheck = value;
            }
        }

        /// <summary>
        /// wage frequency
        /// </summary>        
        public int WageFrequency
        {
            get
            {
                return m_iWageFrequency;
            }
            set
            {
                m_iWageFrequency = value;
            }
        }

        /// <summary>
        /// role type corresponding to role.
        /// </summary>        
        public string RoleType
        {
            get
            {
                return m_strRoleType;
            }
            set
            {
                m_strRoleType = value;
            }
        }

        /// <summary>
        /// ID of the Advocate sales manager, if the user is Sales Rep
        /// </summary>        
        public int AdvocateSalesManagerID
        {
            get
            {
                return m_iAdvocateSalesManagerID;
            }
            set
            {
                m_iAdvocateSalesManagerID = value;
            }
        }

        
        public string AdvocateSalesManager
        {
            get
            {
                return m_strAdvocateSalesManager;
            }
            set
            {
                m_strAdvocateSalesManager = value;
            }
        }
    }
}
