using System;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.MedicalVendor
{    
    public class EMVTestPayRate
    {
        private int m_iMVUserTestPayRateID = 0;
        private ETest m_objTest;
        private decimal m_iPayRate;
        private Boolean m_boolActive;
        
        public int MVUserTestPayRateID
        {
            get
            {
                return m_iMVUserTestPayRateID;
            }
            set
            {
                m_iMVUserTestPayRateID = value;
            }
        }
        
        public ETest Test
        {
            get
            {
                return m_objTest;
            }
            set
            {
                m_objTest = value;
            }
        }
        
        public decimal PayRate
        {
            get
            {
                return m_iPayRate;
            }
            set
            {
                m_iPayRate = value;
            }
        }
        
        public Boolean Active
        {
            get
            {
                return m_boolActive;
            }
            set
            {
                m_boolActive = value;
            }
        }
    }
}

