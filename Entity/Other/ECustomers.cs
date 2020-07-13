
using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    //TODO remove serializable
    [Serializable]
    public class ECustomers
    {
        private long m_iCustomerID = 0;
        private string m_strContactMethod = String.Empty;
        private EUser m_objUser = null;
        private string m_strMyPicture = string.Empty;
        private List<string> m_sarrOtherPictures = null;
        private EPrimaryCarePhysician m_objPrimaryCarePhysician = null;
        private string m_strCollectionMode = string.Empty;
        private bool m_boolMailingList = true;
        private bool m_bolDirectMail = true;
        private bool m_bolSpecialOffer = true;
        private List<EReferences> m_objReferences = null;
        private EAddress m_objBillingAddress = null;

        private string m_strHeight = string.Empty;
        private string m_strGender = string.Empty;
        private string m_strRace = string.Empty;
        private float m_sngWeight = 0.0F;
        private Int16 m_shtAge = 0;
        private float m_fTotalPayment = 0.0F;
        private string m_strLastLogged = string.Empty;
        private int m_iAddedBy = 0;
        private bool m_bolIsHistoryFilled = false;
        private int m_prevCustomerID = 0;
        private long m_nextCustomerID = 0;
        private bool m_bolIsResultsReady = false;
        private string m_strRegisteredBy = string.Empty;
        private int m_iRegisteredById = 0;

        private int m_iEventCount = 0;
        private string m_strUserCreationMode = "";

        /// <summary>
        /// 
        /// </summary>        
        public int EventCount { get { return m_iEventCount; } set { m_iEventCount = value; } }

        /// <summary>
        /// 
        /// </summary>        
        public string UserCreationMode { get { return m_strUserCreationMode; } set { m_strUserCreationMode = value; } }

        /// <summary>
        /// 
        /// </summary>        
        public bool IsHistoryFilled
        {
            get { return m_bolIsHistoryFilled; }
            set { m_bolIsHistoryFilled = value; }
        }

        public bool IsResultsReady
        {
            get { return m_bolIsResultsReady; }
            set { m_bolIsResultsReady = value; }
        }



        /// <summary>
        /// Age of the customer
        /// </summary>        
        public Int16 Age
        {
            get { return m_shtAge; }
            set { m_shtAge = value; }
        }



        /// <summary>
        /// 
        /// </summary>        
        public string Height
        {
            get { return m_strHeight; }
            set { m_strHeight = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string Gender
        {
            get { return m_strGender; }
            set { m_strGender = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string Race
        {
            get { return m_strRace; }
            set { m_strRace = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public float Weight
        {
            get { return m_sngWeight; }
            set { m_sngWeight = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public EAddress BillingAddress
        {
            get { return m_objBillingAddress; }
            set { m_objBillingAddress = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public EPrimaryCarePhysician PrimaryCarePhysician
        {
            get { return m_objPrimaryCarePhysician; }
            set { m_objPrimaryCarePhysician = value; }
        }


        /// <summary>
        /// Customer's other Picture
        /// </summary>        
        public List<string> OtherPictures
        {
            get { return m_sarrOtherPictures; }
            set { m_sarrOtherPictures = value; }
        }

        /// <summary>
        /// Customer's Picture
        /// </summary>        
        public string MyPicture
        {
            get { return m_strMyPicture; }
            set { m_strMyPicture = value; }
        }


        /// <summary>
        /// unique customer id
        /// </summary>        
        public long CustomerID
        {
            get
            {
                return m_iCustomerID;
            }
            set
            {
                m_iCustomerID = value;
            }
        }

        /// <summary>
        ///user object for mapping customer with user 
        /// </summary>        
        public EUser User
        {
            get { return m_objUser; }
            set { m_objUser = value; }
        }


        /// <summary>
        /// Way to contact customer
        /// </summary>        
        public string ContactMethod
        {
            get { return m_strContactMethod; }
            set { m_strContactMethod = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool MailingList
        {
            get
            {
                return m_boolMailingList;
            }
            set
            {
                m_boolMailingList = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool DirectMail
        {
            get
            {
                return m_bolDirectMail;
            }
            set
            {
                m_bolDirectMail = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool SpecialOffer
        {
            get
            {
                return m_bolSpecialOffer;
            }
            set
            {
                m_bolSpecialOffer = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string CollectionMode
        {
            get
            {
                return m_strCollectionMode;
            }
            set
            {
                m_strCollectionMode = value;
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
        /// Gives Mode of sign up to the site. 
        /// </summary>        
        public int AddedBy
        {
            get { return m_iAddedBy; }
            set { m_iAddedBy = value; }
        }


        /// <summary>
        /// Gives date and time customer last logged in.
        /// </summary>        
        public string LastLogged
        {
            get { return m_strLastLogged; }
            set { m_strLastLogged = value; }
        }


        /// <summary>
        /// Gives total amount procurred from the customer from all the events this customer has attended.
        /// </summary>        
        public float TotalPayment
        {
            get { return m_fTotalPayment; }
            set { m_fTotalPayment = value; }
        }

        /// <summary>
        /// Previous CustomerID
        /// </summary>        
        public int PrevCustomerID
        {
            get
            {
                return m_prevCustomerID;
            }
            set
            {
                m_prevCustomerID = value;
            }
        }

        /// <summary>
        /// Next CustomerID
        /// </summary>        
        public long NextCustomerID
        {
            get
            {
                return m_nextCustomerID;
            }
            set
            {
                m_nextCustomerID = value;
            }
        }

        /// <summary>
        /// RegisteredBy
        /// </summary>        
        public string RegisteredBy
        {
            get
            {
                return m_strRegisteredBy;
            }
            set
            {
                m_strRegisteredBy = value;
            }
        }

        /// <summary>
        /// RegisteredById
        /// </summary>        
        public int RegisteredById
        {
            get
            {
                return m_iRegisteredById;
            }
            set
            {
                m_iRegisteredById = value;
            }
        }

        public string Employer { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }

        public int DoNotContactReasonId { get; set; }

        public bool RequestForNewsLetter { get; set; }

        public string LastScreeningDate { get; set; }

        public string MemberId { get; set; }

        public string Hicn { get; set; }

        public string Tag { get; set; }
        public string Copay { get; set; }
        public string MedicarePlanName { get; set; }
        public bool? IsEligible { get; set; }

        public string CustomTag { get; set; }

        public string PreApprovedTest { get; set; }
        public long DoNotContactTypeId { get; set; }
        public long DoNotContactReasonNotesId { get; set; }
    }
}
