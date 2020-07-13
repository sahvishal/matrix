       
using System;

namespace Falcon.Entity.Other
{   
    
    public class EProspectDetails
    {
        private int m_iProspectListID = 0;
        private string m_strFileName = string.Empty;
        private bool m_bolActive = true;

        private Int64 m_iProspectDetailsID = 0;
        private Int64 m_iProspectID = 0;
        private string m_strFacilitiesFee = string.Empty;
        private string m_strPaymentMethod = string.Empty;
        private int m_iDepositsRequire = 0;
        private decimal m_dDepositsAmount = 0.0m;
        private int m_iViableHostSite=0;
        private int m_iHostedInPast = 0;
        private string m_strHostedInPastWith = string.Empty;
        private int m_iWillHost = 0;

        private string m_strReasonViableHostSite = string.Empty;
        private string m_strReasonHostedInPast = string.Empty;
        private string m_strReasonWillHost = string.Empty;
        private int m_iProspectListCount = 0;
        /// <summary>
        /// unique ProspectList id
        /// </summary>
        
        public int ProspectListID
        {
            get { return m_iProspectListID; }
            set { m_iProspectListID = value; }
        }
        /// <summary>
        ///File Name
        /// </summary>
        
        public string FileName
        {
            get { return m_strFileName; }
            set { m_strFileName = value; }
        }
        

        /// <summary>
        /// status
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
        /// Prospect Details ID
        /// </summary>
        
        public Int64 ProspectDetailID
        {
            get
            {

                return m_iProspectDetailsID;
            }
            set
            {
                m_iProspectDetailsID = value;
            }
        }

        /// <summary>
        /// Prospect ID
        /// </summary>
        
        public Int64 ProspectID
        {
            get
            {

                return m_iProspectID;
            }
            set
            {
                m_iProspectID = value;
            }
        }

        /// <summary>
        /// Facilities Fee
        /// </summary>
        
        public string FacilitiesFee
        {
            get
            {

                return m_strFacilitiesFee;
            }
            set
            {
                m_strFacilitiesFee = value;
            }
        }

        /// <summary>
        /// Payment Method
        /// </summary>
        
        public string PaymentMethod
        {
            get
            {

                return m_strPaymentMethod;
            }
            set
            {
                m_strPaymentMethod = value;
            }
        }
        /// <summary>
        /// Deposits Require
        /// </summary>
        
        public int DepositsRequire
        {
            get
            {

                return m_iDepositsRequire;
            }
            set
            {
                m_iDepositsRequire = value;
            }
        }

        /// <summary>
        /// Deposits Amount
        /// </summary>
        
        public decimal DepositsAmount
        {
            get
            {

                return m_dDepositsAmount;
            }
            set
            {
                m_dDepositsAmount = value;
            }
        }
        /// <summary>
        /// Viable Host Site
        /// </summary>
        
        public int ViableHostSite
        {
            get
            {

                return m_iViableHostSite;
            }
            set
            {
                m_iViableHostSite = value;
            }
        }

        /// <summary>
        /// Hosted In Past
        /// </summary>
        
        public int HostedInPast
        {
            get
            {

                return m_iHostedInPast;
            }
            set
            {
                m_iHostedInPast = value;
            }
        }

        /// <summary>
        /// Hosted In Past With
        /// </summary>
        
        public string HostedInPastWith
        {
            get
            {

                return m_strHostedInPastWith;
            }
            set
            {
                m_strHostedInPastWith = value;
            }
        }
        /// <summary>
        /// Will Host 
        /// </summary>
        
        public int WillHost
        {
            get
            {

                return m_iWillHost;
            }
            set
            {
                m_iWillHost = value;
            }
        }

        
        /// <summary>
        /// Viable Host Site Reason
        /// </summary>
        
        public string ReasonViableHostSite
        {
            get
            {

                return m_strReasonViableHostSite;
            }
            set
            {
                m_strReasonViableHostSite = value;
            }
        }

        /// <summary>
        /// Hosted In Past reason
        /// </summary>
        
        public string ReasonHostedInPast
        {
            get
            {

                return m_strReasonHostedInPast;
            }
            set
            {
                m_strReasonHostedInPast = value;
            }
        }
               
        /// <summary>
        /// Will Host Reason
        /// </summary>
        
        public string ReasonWillHost
        {
            get
            {

                return m_strReasonWillHost;
            }
            set
            {
                m_strReasonWillHost = value;
            }
        }

        /// <summary>
        /// no of prospects in list
        /// </summary>
        
        public int ProspectListCount
        {
            get { return m_iProspectListCount; }
            set { m_iProspectListCount = value; }
        }
    }

}
