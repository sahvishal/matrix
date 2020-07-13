        
using System;
using System.Collections.Generic;
using Falcon.Entity.Other;
namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class EFranchisorUser
    {
        private int m_iFranchisorUserID = 0;
        private bool m_bolActive = true;
        private EAddress m_objAddress;
        private EUser m_objUser;
        private List<string> m_objOtherPictures;
        private string m_strTeamPicture;
        private string m_strMyPicture;

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
        /// Unique franchisor user ID
        /// </summary>
        public int FranchisorUserID
        {
            get
            {
                return m_iFranchisorUserID;
            }
            set
            {
                m_iFranchisorUserID = value;
            }
        }


        /// <summary>
        /// franchisor user status
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

      

    }
}


