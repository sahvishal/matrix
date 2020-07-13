using System;
using Falcon.Entity.Other;

namespace Falcon.Entity.Affiliate
{
    [Serializable]
    public class ECampaignReport
    {
        private int m_iCallId = 0;
        private int m_iEventCustomerId = 0;
        private string m_strPackageName = string.Empty;
        private string m_strAffiliateId = string.Empty;
        private string m_strSaleAmout = string.Empty;
        private string m_strCommission = string.Empty;
        private string m_strDiscounts = string.Empty;
        private string m_strImpressions = string.Empty;
        private string m_strClickCount = string.Empty;
        private string m_strCTR = string.Empty;
        private string m_strSignUpCount = string.Empty;
        private string m_strDate = string.Empty;
        private EEvent m_objEvent = null;
        private ECustomers m_objECustomers = null;
        private bool m_boolIsPaymentConfirm = false;
        
        public int EventCustomerId
        {
            get
            {
                return m_iEventCustomerId;
            }
            set
            {
                m_iEventCustomerId = value;
            }
        }
        
        public int CallId
        {
            get
            {
                return m_iCallId;
            }
            set
            {
                m_iCallId = value;
            }
        }
        
        public bool IsPaymentConfirm
        {
            get
            {
                return m_boolIsPaymentConfirm;
            }
            set
            {
                m_boolIsPaymentConfirm = value;
            }
        }
        
        public string SignUpCount
        {
            get
            {
                return m_strSignUpCount;
            }
            set
            {
                m_strSignUpCount = value;
            }
        }
        
        public string Impressions
        {
            get
            {
                return m_strImpressions;
            }
            set
            {
                m_strImpressions = value;
            }
        }
        
        public string ClickCount
        {
            get
            {
                return m_strClickCount;
            }
            set
            {
                m_strClickCount = value;
            }
        }
        
        public string CTR
        {
            get
            {
                return m_strCTR;
            }
            set
            {
                m_strCTR = value;
            }
        }
        
        public string PackageName
        {
            get
            {
                return m_strPackageName;
            }
            set
            {
                m_strPackageName = value;
            }
        }
        
        public string Date
        {
            get
            {
                return m_strDate;
            }
            set
            {
                m_strDate = value;
            }
        }
        
        public string SaleAmout
        {
            get
            {
                return m_strSaleAmout;
            }
            set
            {
                m_strSaleAmout = value;
            }
        }
        
        public string Commission
        {
            get
            {
                return m_strCommission;
            }
            set
            {
                m_strCommission = value;
            }
        }
        
        public string Discounts
        {
            get
            {
                return m_strDiscounts;
            }
            set
            {
                m_strDiscounts = value;
            }
        }
        
        public string AffiliateId
        {
            get
            {
                return m_strAffiliateId;
            }
            set
            {
                m_strAffiliateId = value;
            }
        }
        
        public EEvent Event
        {
            get
            {
                return m_objEvent;
            }
            set
            {
                m_objEvent = value;
            }
        }
        
        public ECustomers ECustomers
        {
            get
            {
                return m_objECustomers;
            }
            set
            {
                m_objECustomers = value;
            }
        }
        
    }
}
