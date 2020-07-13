using System;
using Falcon.Entity.Other;  

namespace Falcon.Entity.MedicalVendor
{
    public class EHospitalFacility
    {
        private Int64 m_iHospitalFacilityId = 0;
        private Int64 m_iHospitalPartnerId= 0;
        private string m_strFacilityName = string.Empty;
        private string m_strEmail = string.Empty;
        private string m_strPhoneCell= string.Empty;
        private EAddress m_objFacilityAddress;
        private string m_strMedicalVendor = string.Empty;
        
        /// <summary>
        /// HospitalFacilityID
        /// </summary>        
        public Int64 HospitalFacilityID
        {
            get
            {
                return m_iHospitalFacilityId;
            }
            set
            {
                m_iHospitalFacilityId = value;
            }
        }
        /// <summary>
        /// HospitalPartnerId
        /// </summary>        
        public Int64 HospitalPartnerId
        {
            get
            {
                return m_iHospitalPartnerId;
            }
            set
            {
                m_iHospitalPartnerId = value;
            }
        }
        /// <summary>
        /// FacilityName
        /// </summary>        
        public string FacilityName
        {
            get
            {
                return m_strFacilityName;
            }
            set
            {
                m_strFacilityName = value;
            }
        }
        /// <summary>
        /// Email
        /// </summary>        
        public string Email
        {
            get
            {
                return m_strEmail;
            }
            set
            {
                m_strEmail = value;
            }
        }

        /// <summary>
        /// PhoneCell
        /// </summary>        
        public string PhoneCell
        {
            get
            {
                return m_strPhoneCell;
            }
            set
            {
                m_strPhoneCell = value;
            }
        }
        /// <summary>
        /// Facility Address
        /// </summary>        
        public EAddress Address
        {
            get
            {
                return m_objFacilityAddress ;
            }
            set
            {
                m_objFacilityAddress = value;
            }
        }

        
        public string MedicalVendor
        {
            get
            {
                return m_strMedicalVendor;
            }
            set
            {
                m_strMedicalVendor = value;
            }
        }

    }
}
