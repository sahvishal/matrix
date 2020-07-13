using System;
using System.Collections.Generic;
using Falcon.Entity.Other;  

namespace Falcon.Entity.MedicalVendor
{
    public class EMVMVUser
    {
        private int m_iMedicalVendorMVUserID = 0;
        private EMedicalVendor m_objMedicalVendor;
        private EMVUser m_objMVUser;
        private ERole m_objRole;
        private EMedicalVendorApplication m_objMVApplication;
        private bool m_bolDefault;
        private bool m_bolActive;
        private string m_strNote=string.Empty;
        private List<EMVMVUserTest> m_objMVTest = null;
        private List<EMVMVUserPackage> m_objMVPackage = null;
        private EMVMVUserCustomerPayRate m_objCustomerPayRate = null;
        private string m_strCutOffDate = string.Empty;
        private List<EMVMVLicense> m_objMVLicense;
        private bool m_bolShowEarningAmount = false;
        public bool AuditRequired { get; set; }


        /// <summary>
        /// Authorizations allowed or not.
        /// </summary>        
        public bool IsAuthorizationsAllowed { get; set; }


        /// <summary>
        /// 
        /// </summary>        
        public List<Int32> ListPods { get; set; }
        

        /// <summary>
        /// 
        /// </summary>        
        public string CutOffDate 
        { 
            get { return m_strCutOffDate; } 
            set { m_strCutOffDate = value; } 
        }       
        
        public string Notes
        {
            get { return m_strNote; }
            set { m_strNote= value; }
        }
        
        public List<EMVMVUserTest> MVTest
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
                
        public List<EMVMVUserPackage> MVPackage
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
        
        public EMVMVUserCustomerPayRate MVCustomerPayRate
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
                
        public int MedicalVendorMVUserID
        {
            get
            {
                return m_iMedicalVendorMVUserID;
            }
            set
            {
                m_iMedicalVendorMVUserID = value;
            }
        }
                
        public EMedicalVendor MedicalVendor
        {
            get
            {
                return m_objMedicalVendor;
            }
            set
            {
                m_objMedicalVendor = value;
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
        
        public ERole Role
        {
            get
            {
                return m_objRole;
            }
            set
            {
                m_objRole = value;
            }
        }
        
        public EMedicalVendorApplication MedicalVendorApplication
        {
            get
            {
                return m_objMVApplication;
            }
            set
            {
                m_objMVApplication = value;
            }
        }
        
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

        
        public List<EMVMVLicense> MVLicense
        {
            get
            {
                return m_objMVLicense;
            }
            set
            {
                m_objMVLicense = value;
            }
        }

        
        public bool ShowEarningAmount
        {
            get
            {
                return m_bolShowEarningAmount;
            }
            set
            {
                m_bolShowEarningAmount = value;
            }
        }
    }
}
