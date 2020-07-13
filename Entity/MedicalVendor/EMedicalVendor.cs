using System.Collections.Generic;
using Falcon.Entity.Other;  
namespace Falcon.Entity.MedicalVendor
{
    public class EMedicalVendor
    {
        private int m_iMedicalVendorID = 0;
        private EMedicalVendorType m_iMedicalVendorType;
        private string m_strBusinessName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private EAddress m_objBusinessAddress;
        private EAddress m_objBillingAddress;
        private int m_iMedicalVendorWiringID = 0;
        private EContract m_objContract;
        private string m_strBusinessPhone = string.Empty;
        private string m_strBusinessFax = string.Empty;
        private string m_strTeamPicture = string.Empty;
        private string m_strNotes = string.Empty;
        
        private int m_iPaymentmode = 0;
        private string m_strBankName = string.Empty;
        private string m_strAccountType = string.Empty;
        private string m_strAccountHolder = string.Empty;
        private string m_strMemo = string.Empty;
        private string m_strRoutingNumber=string.Empty;
        private string m_strSpecialInstruction = string.Empty;
        private string m_strAccountNumber = string.Empty;
        private int m_iInterval = 0;
        private int m_iFrequencyID = 0;
        private string  m_strFrequency = string.Empty;
        private List<EMVTest> m_objMVTest = null;
        private List<EMVPackage> m_objMVPackage = null;
        private EMVCustomerPayRate m_objCustomerPayRate = null;
        private string m_strEvaluationMode = string.Empty;
        private List<EMVPermittedTest> m_objPermittedTest=null;
        private bool m_bolIsHospitalPartner = false;
        private EHospitalPartner m_objHospitalPartner = null;    

        /// <summary>
        /// EMVPermittedTest for mapping EMedicalVendor with EMVPermittedTest
        /// </summary>
        
        public List<EMVPermittedTest> MVPermittedTest
        {
            get { return m_objPermittedTest; }
            set { m_objPermittedTest = value; }
        }
        
        public EHospitalPartner HospitalPartner
        {
            get
            {
                return m_objHospitalPartner;
            }
            set
            {
                m_objHospitalPartner = value;
            }
        }
        
        public bool IsHospitalPartner
        {
            get
            {
                return m_bolIsHospitalPartner;
            }
            set
            {
                m_bolIsHospitalPartner = value;
            }
        }
        
        public int FrequencyID
        {
            get
            {
                return m_iFrequencyID;
            }
            set
            {
                m_iFrequencyID = value;
            }
        }
        
        public string Frequency
        {
            get
            {
                return m_strFrequency;
            }
            set
            {
                m_strFrequency = value;
            }
        }
        
        public List<EMVTest> MVTest
        {
            get
            {
                return m_objMVTest;
            }
            set
            {
                m_objMVTest = value;
            }
        }
        
        public List<EMVPackage> MVPackage
        {
            get
            {
                return m_objMVPackage;
            }
            set
            {
                m_objMVPackage = value;
            }
        }
        
        public EMVCustomerPayRate MVCustomerPayRate
        {
            get
            {
                return m_objCustomerPayRate;
            }
            set
            {
                m_objCustomerPayRate = value;
            }
        }
        
        public string EvaluationMode
        {
            get
            {
                return m_strEvaluationMode;
            }
            set
            {
                m_strEvaluationMode = value;
            }
        }
            
        private EMVUser m_objMVUser;

        
        public int PaymentMode
        {
            get
            {
                return m_iPaymentmode;
            }
            set
            {
                m_iPaymentmode = value;
            }
        }
        
        public int Interval
        {
            get
            {
                return m_iInterval;
            }
            set
            {
                m_iInterval = value;
            }
        }
        
        public string AccountNumber
        {
            get
            {
                return m_strAccountNumber;
            }
            set
            {
                m_strAccountNumber = value;
            }
        }
        
        public string AccountType
        {
            get
            {
                return m_strAccountType;
            }
            set
            {
                m_strAccountType = value;
            }
        }
        
        public string AccountHolder
        {
            get
            {
                return m_strAccountHolder;
            }
            set
            {
                m_strAccountHolder = value;
            }
        }
        
        public string BankName
        {
            get
            {
                return m_strBankName;
            }
            set
            {
                m_strBankName = value;
            }
        }
        
        public string Memo
        {
            get
            {
                return m_strMemo;
            }
            set
            {
                m_strMemo = value;
            }
        }
        
        public string RountingNumber
        {
            get
            {
                return m_strRoutingNumber;
            }
            set
            {
                m_strRoutingNumber = value;
            }
        }
        
        public string SpecialInstruction
        {
            get
            {
                return m_strSpecialInstruction;
            }
            set
            {
                m_strSpecialInstruction = value;
            }
        }
        
        public string TeamPicture
        {
            get
            {
                return m_strTeamPicture;
            }
            set
            {
                m_strTeamPicture = value;
            }
        }
        
        public string Note
        {
            get
            {
                return m_strNotes;
            }
            set
            {
                m_strNotes = value;
            }
        }
        
        public EContract Contract
        {
            get
            {
                return m_objContract;
            }
            set
            {
                m_objContract = value;
            }
        }               

        /// <summary>
        /// unique MedicalVendor id
        /// </summary>        
        public int MedicalVendorID
        {
            get
            {
                return m_iMedicalVendorID;
            }
            set
            {
                m_iMedicalVendorID = value;
            }
        }

        /// <summary>
        /// unique MedicalVendorType id
        /// </summary>        
        public EMedicalVendorType MedicalVendorType
        {
            get
            {
                return m_iMedicalVendorType;
            }
            set
            {
                m_iMedicalVendorType = value;
            }
        }
        /// <summary>
        /// MedicalVendor business name
        /// </summary>        
        public string BusinessName
        {
            get
            {
                return m_strBusinessName;
            }
            set
            {
                m_strBusinessName = value;
            }
        }
        /// <summary>
        /// MedicalVendor description
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
        /// MedicalVendor status
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
        /// MedicalVendor business address id 
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
        /// MedicalVendor business address id 
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
        /// MedicalVendor wiring id
        /// </summary>        
        public int MedicalVendorWiringID
        {
            get
            {
                return m_iMedicalVendorWiringID;
            }
            set
            {
                m_iMedicalVendorWiringID = value;
            }
        }


        /// <summary>
        /// MedicalVendor business phone
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
        /// MedicalVendor business fax
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

        
        public EMVUser MVUser
        {
            get
            {
                return m_objMVUser;
            }
            set
            {
                m_objMVUser = value;
            }
        }

    }
}
