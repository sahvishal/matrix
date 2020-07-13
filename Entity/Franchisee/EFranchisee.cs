using System;
using System.Collections.Generic;
using Falcon.Entity.Other;

namespace Falcon.Entity.Franchisee
{
    [Serializable]
    public class EFranchisee
    {
        private int m_iFranchiseeID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private string m_strAboutMyself = string.Empty;
        private string m_strBusinessPhone = string.Empty;
        private string m_strBusinessFax = string.Empty;
        private Double m_iFranchiseeFee = 0.0;
        private Double m_iMonthlyFee = 0.0;
        private List<string> m_objOtherPictures;
        private string m_strTeamPicture;
        private string m_strMyPicture;
        private EFranchiseeApplication m_objFranchiseeApplication;
        private EAddress m_objBillingAddress;
        private EAddress m_objBusinessAddress;
        private EAddress m_objContactAddress;
        private EContract m_objContract;
        private EFranchiseeUser m_objFranchiseeUser;
        private List<EReferences> m_objReferences = null;
        private List<EPod> m_objPod = null;
        private ENote m_objNote;
        private int m_iHasPod = 0;

        /// <summary>
        /// Unique franchisee ID
        /// </summary>        
        public int FranchiseeID
        {
            get
            {
                return m_iFranchiseeID;
            }
            set
            {
                m_iFranchiseeID = value;
            }
        }

        /// <summary>
        /// franchisee name
        /// </summary>
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        /// <summary>
        /// franchisee description
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
        ///  about franchisee 
        /// </summary>
        public string AboutMyself
        {
            get
            {
                return m_strAboutMyself;
            }
            set
            {
                m_strAboutMyself = value;
            }
        }


        /// <summary>
        /// franchisee status
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
        /// franchisee business address ID
        /// </summary>        
        public EAddress BusinessAddress
        {
            get
            {
                return m_objBusinessAddress;
            }
            set
            {
                m_objBusinessAddress = value;
            }
        }

        /// <summary>
        /// franchisee billing address id
        /// </summary>        
        public EAddress BillingAddress
        {
            get
            {
                return m_objBillingAddress;
            }
            set
            {
                m_objBillingAddress = value;
            }
        }

        /// <summary>
        /// franchisee contact address id
        /// </summary>        
        public EAddress ContactAddress
        {
            get
            {
                return m_objContactAddress;
            }
            set
            {
                m_objContactAddress = value;
            }
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
        /// franchisee application object for mapping franchisee with franchisee application 
        /// </summary>        
        public EFranchiseeApplication FranchiseeApplication
        {
            get { return m_objFranchiseeApplication; }
            set { m_objFranchiseeApplication = value; }
        }
        

        /// <summary>
        ///  contract object for mapping franchisee with contract
        /// </summary>        
        public EContract Contract
        {
            get { return m_objContract; }
            set { m_objContract = value; }
        }


        /// <summary>
        /// franchisee business phone
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
        /// franchisee business fax
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

        /// <summary>
        /// 
        /// </summary>        
        public Double MonthlyFee
        {
            get
            {
                return m_iMonthlyFee;
            }
            set
            {
                m_iMonthlyFee = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>        
        public Double FranchiseeFee
        {
            get
            {
                return m_iFranchiseeFee;
            }
            set
            {
                m_iFranchiseeFee = value;
            }
        }
        /// <summary>
        /// 
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
        /// 
        /// </summary>        
        public ENote Note
        {
            get
            {
                return m_objNote;
            }
            set
            {
                m_objNote = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>        
        public List<EPod> Pod
        {
            get
            {
                return m_objPod;
            }
            set
            {
                m_objPod = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>        
        public List<EReferences> References
        {
            get
            {
                return m_objReferences;
            }
            set
            {
                m_objReferences = value;
            }
        }

        /// <summary>
        /// indicates wherther pod is attached to franchisee or not
        /// </summary>        
        public int HasPod
        {
            get
            {
                return m_iHasPod;
            }
            set
            {
                m_iHasPod = value;
            }
        }
    }
}
