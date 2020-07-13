         
using System;
using Falcon.Entity.Other;
namespace Falcon.Entity.Franchisee
{
    [Serializable]
    
    public class EFranchiseeApplication
    {
        private int m_iFranchiseeApplicationID = 0;
        private EApplication m_objApplication;
        private int m_iWorkFlowStageActivityTriggerID = 0;

        private string m_strBusinessPhone = string.Empty;
        private string m_strBusinessFax = string.Empty;
        private int m_iBillingAddressID = 0;
        private EAddress m_objBillingAddress = null;
        private EWFStage m_objWFStage=null;
        private EWFStageTrigger m_objWFStageTrigger=null;
        private DateTime m_dtDateCreated;

        /// <summary>
        /// unique Application id
        /// </summary>        
        public int FranchiseeApplicationID
        {
            get
            {
                return m_iFranchiseeApplicationID;
            }
            set
            {
                m_iFranchiseeApplicationID = value;
            }
        }

        /// <summary>
        /// unique workflowstageactivitytrigger id
        /// </summary>        
        public int WorkFlowStageActivityTriggerID
        {
            get
            {
                return m_iWorkFlowStageActivityTriggerID;
            }
            set
            {
                m_iWorkFlowStageActivityTriggerID = value;
            }
        }

        /// <summary>
        /// 
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
        /// 
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
        public int BillingAddressID
        {
            get
            {
                return m_iBillingAddressID;
            }
            set
            {
                m_iBillingAddressID = value;
            }
        }

        /// <summary>
        /// generic application object
        /// </summary>        
        public EApplication Application
        {
            get
            {
                return m_objApplication;
            }
            set
            {
                m_objApplication = value;
            }
        }

        /// <summary>
        /// WFStages object for mapping franchisee application with WFStages 
        /// </summary>        
        public EWFStage WFStage
        {
            get { return m_objWFStage; }
            set { m_objWFStage = value; }
        }

        /// <summary>
        /// WFStageTrigger object for mapping franchisee application with WFStageTrigger 
        /// </summary>        
        public EWFStageTrigger WFStageTrigger
        {
            get { return m_objWFStageTrigger; }
            set { m_objWFStageTrigger = value; }
        }

        /// <summary>
        /// date of application first created
        /// </summary>        
        public DateTime DateCreated
        {
            get { return m_dtDateCreated; }
            set { m_dtDateCreated = value; }
        }

        /// <summary>
        /// address object 
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
    }
}
