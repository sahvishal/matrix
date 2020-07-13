
using System;
using System.Collections.Generic;
using Falcon.Entity.Other;
namespace Falcon.Entity.Franchisee
{
     [Serializable]
    public class EFranchiseeUser
    {
        private int m_iFranchiseeUserID = 0;
        private bool m_bolActive = true;
        private EFranchiseeApplication m_objFranchiseeApplication;
        private EAddress m_objAddress;
        private EUser m_objUser;
        private List<string> m_objOtherPictures;
        private string m_strTeamPicture;
        private string m_strMyPicture;
        private string m_strCreateDate;

        private string m_strShellDescription;


        /// <summary>
        /// 
        /// </summary>        
        public string ShellDescription
        {
            get { return m_strShellDescription; }
            set { m_strShellDescription = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>        
        public List<string> OtherPictures
        {
            get { return m_objOtherPictures; }
            set { m_objOtherPictures = value; }
        }
        /// <summary>
        /// 
        /// </summary>        
        public string MyPicture
        {
            get { return m_strMyPicture; }
            set { m_strMyPicture = value; }
        }
        /// <summary>
        /// 
        /// </summary>        
        public string TeamPicture
        {
            get { return m_strTeamPicture; }
            set { m_strTeamPicture = value; }
        }

        /// <summary>
        /// Franchisee user applied date
        /// </summary>        
        public string CreateDate
        {
            get { return m_strCreateDate; }
            set { m_strCreateDate = value; }
        }
        /// <summary>
        /// Unique franchisee user ID
        /// </summary>        
        public int FranchiseeUserID
        {
            get
            {
                return m_iFranchiseeUserID;
            }
            set
            {
                m_iFranchiseeUserID = value;
            }
        }

        
        /// <summary>
        /// franchisee user status
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
        /// address object for mapping franchisoruser with address
        /// </summary>        
        public EAddress Address
        {
            get
            {
                return m_objAddress;
            }
            set
            {
                m_objAddress = value;
            }
        }

        /// <summary>
        ///user object for mapping franchisor user with user 
        /// </summary>        
        public Other.EUser User
        {
            get { return m_objUser; }
            set { m_objUser = value; }
        }

        
        /// <summary>
        /// franchisee application object for mapping franchisee user with franchisee application 
        /// </summary>        
        public EFranchiseeApplication FranchiseeApplication
        {
            get { return m_objFranchiseeApplication; }
            set { m_objFranchiseeApplication = value; }
        }

       
    }
}
