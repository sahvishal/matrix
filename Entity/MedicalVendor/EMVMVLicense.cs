using System;

namespace Falcon.Entity.MedicalVendor
{
    public class EMVMVLicense
    {
        private Int64  m_iLicenseID = 0;
        private Int64 m_iMVMVUserID = 0;
        private Int64 m_iStateID = 0;

        private string m_strLicenseNo = string.Empty;
        private int m_iRowState = 0;
        
        public Int64 LicenseID
        {
            get
            {
                return m_iLicenseID;
            }
            set
            {
                m_iLicenseID = value;
            }
        }   
                
        public Int64 MVMVUserID
        {
            get
            {
                return m_iMVMVUserID;
            }
            set
            {
                m_iMVMVUserID = value;
            }
        }
        
        public Int64 StateID
        {
            get
            {
                return m_iStateID;
            }
            set
            {
                m_iStateID = value;
            }
        }
        
        public string LicenseNo
        {
            get { return m_strLicenseNo; }
            set { m_strLicenseNo = value; }
        }
                
        public int RowState
        {
            get
            {
                return m_iRowState;
            }
            set
            {
                m_iRowState = value;
            }
        }

    }
}
