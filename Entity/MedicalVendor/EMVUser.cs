using System.Collections.Generic;
using Falcon.Entity.Other;

namespace Falcon.Entity.MedicalVendor
{
    
    public class EMVUser
    {
        private int m_iMVUserID = 0;
        private string m_strContract = string.Empty;
        private bool m_bolActive = true;
        private string m_strDigitalSignature;
        private string m_strResume = string.Empty;
        private EAddress m_objAddress;
        private List<EReferences> m_objReference;
        private Other.EUser m_objUser;
        private EMVUserClassification m_objMVUserClassification;
        private EMVUserSpecialization m_objMVUserSpecialization;
        private List<EMVTestPayRate> m_objMVTestPayRate;
        private List<string> m_objOtherPictures;
        private string m_strTeamPicture;
        private string m_strMyPicture;

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
        /// unique MVUser id
        /// </summary>        
        public int MVUserID
        {
            get
            {
                return m_iMVUserID;
            }
            set
            {
                m_iMVUserID = value;
            }
        }

         /// <summary>
        /// MVUser contract
        /// </summary>        
        public string Contract
        {
            get
            {
                return m_strContract;
            }
            set
            {
                m_strContract = value;
            }
        }

        /// <summary>
        /// MVUser status
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

        
        public string DigitalSignature
        {
            get
            {
                return m_strDigitalSignature;
            }
            set
            {
                m_strDigitalSignature = value;
            }
        }

        /// <summary>
        /// user object for mapping mvuser with user 
        /// </summary>        
        public Other.EUser User
        {
            get
            {
                return m_objUser;
            }
            set
            {
                m_objUser = value;
            }
        }

        /// <summary>
        /// MVUserClassification object for mapping mvuser with MVUserClassification 
        /// </summary>        
        public EMVUserClassification MVUserClassification
        {
            get
            {
                return m_objMVUserClassification;
            }
            set
            {
               m_objMVUserClassification = value;
            }
        }

        /// <summary>
        /// MVUserSpecialization object for mapping mvuser with MVUserSpecialization 
        /// </summary>        
        public EMVUserSpecialization MVUserSpecialization
        {
            get
            {
                return m_objMVUserSpecialization;
            }
            set
            {
                m_objMVUserSpecialization = value;
            }
        }

        /// <summary>
        /// references object for mapping mvuser with references 
        /// </summary>        
        public List<EReferences> References
        {
            get
            {
                return m_objReference;
            }
            set
            {
                m_objReference= value;
            }
        }

        /// <summary>
        /// address object for mapping mvuser with address 
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
        /// path of resume file of mv user
        /// </summary>        
        public string Resume
        {
            get
            {
                return m_strResume;
            }
            set
            {
                m_strResume = value;
            }
        }

        
        public List<EMVTestPayRate> MVTestPayRate
        {
            get
            {
                return m_objMVTestPayRate;
            }
            set
            {
                m_objMVTestPayRate = value;
            }
        }
    }
}
