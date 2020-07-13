using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{    
    public class EContact
    {
        private int m_iContactID = 0;
        private string m_strTitle = string.Empty;
        private string m_strFirstName = string.Empty;
        private string m_strMiddleName = string.Empty;
        private string m_strLastName = string.Empty;
        private EAddress m_objAddress = null;
        private string m_strPhoneCell = string.Empty;
        private string m_strPhoneHome = string.Empty;
        private string m_strPhoneOffice = string.Empty;
        private string m_strPhone1Extension = string.Empty;
        private string m_strPhone2Extension = string.Empty;
        private string m_strFax = string.Empty;
        private string m_strEMail = string.Empty;
        private string m_strCounty = string.Empty;
        private int m_iAddedBY = 0;
        private int m_iType = 0;
        private int m_iModifiedBY = 0;
        private bool ? m_bolGender = true;
        private string m_strWebSite = string.Empty;
        private string m_strOrganizationName = string.Empty;
        private string m_strProspectNotes = string.Empty;
        private List<EContactNotes> m_objNotes = null;
        private string m_strDesignationTitle = string.Empty;
        private bool m_bolDeleted = false;

        /// <summary>
        /// 
        /// </summary>        
        public Int64[] ArrayProspectIDs { get; set; }


        /// <summary>
        /// 
        /// </summary>        
        public List<EProspectContactRole> ListProspectContactRole { get; set; }
        
        /// <summary>
        /// 
        /// </summary>        
        public string EmailWork { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string DateOfBirth { get; set; }

        /// <summary>
        /// unique contact id
        /// </summary>        
        public int ContactID
        {
            get
            {
                return m_iContactID;
            }
            set
            {
                m_iContactID = value;
            }
        }

        
        public string Note
        {
            get
            {
                return m_strProspectNotes;
            }
            set
            {
                m_strProspectNotes = value;
            }
        }

        /// <summary>
        /// Address object for mapping prospect with address 
        /// </summary>        
        public EAddress Address
        {
            get { return m_objAddress; }
            set { m_objAddress = value; }
        }


        /// <summary>
        /// contact notes object for mapping contact with contact notes 
        /// </summary>        
        public List<EContactNotes> ContactNotes
        {
            get { return m_objNotes; }
            set { m_objNotes = value; }
        }

        /// <summary>
        /// first name
        /// </summary>        
        public string FirstName
        {
            get
            {
                return m_strFirstName;
            }
            set
            {
                m_strFirstName = value;
            }
        }

        /// <summary>
        /// middle name
        /// </summary>        
        public string MiddleName
        {
            get
            {
                return m_strMiddleName;
            }
            set
            {
                m_strMiddleName = value;
            }
        }

        /// <summary>
        /// last name
        /// </summary>        
        public string LastName
        {
            get
            {
                return m_strLastName;
            }
            set
            {
                m_strLastName = value;
            }
        }

        /// <summary>
        /// phone office
        /// </summary>        
        public string PhoneOffice
        {
            get
            {
                return m_strPhoneOffice;
            }
            set
            {
                m_strPhoneOffice = value;
            }
        }

       


        /// <summary>
        /// phone home
        /// </summary>        
        public string PhoneHome
        {
            get
            {
                return m_strPhoneHome;
            }
            set
            {
                m_strPhoneHome = value;
            }
        }

        /// <summary>
        /// phone cell
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
        /// phone extension
        /// </summary>        
        public string Phone1Extension
        {
            get
            {
                return m_strPhone1Extension;
            }
            set
            {
                m_strPhone1Extension = value;
            }
        }

        /// <summary>
        /// Fax
        /// </summary>        
        public string Fax
        {
            get
            {
                return m_strFax;
            }
            set
            {
                m_strFax = value;
            }
        }

        /// <summary>
        /// Email Address 
        /// </summary>        
        public string EMail
        {
            get
            {
                return m_strEMail;
            }
            set
            {
                m_strEMail = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int AddedBY
        {
            get
            {
                return m_iAddedBY;
            }
            set
            {
                m_iAddedBY = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int ModifiedBY
        {
            get
            {
                return m_iModifiedBY;
            }
            set
            {
                m_iModifiedBY = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int ContactType
        {
            get
            {
                return m_iType;
            }
            set
            {
                m_iType = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>        
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string County
        {
            get
            {
                return m_strCounty;
            }
            set
            {
                m_strCounty = value;
            }
        }

        /// <summary>
        /// flag for gender
        /// </summary>        
        public bool? Gender
        {
            get
            {
                return m_bolGender;
            }
            set
            {
                m_bolGender = value;
            }
        }

        /// <summary>
        /// website
        /// </summary>        
        public string WebSite
        {
            get
            {
                return m_strWebSite;
            }
            set
            {
                m_strWebSite = value;
            }
        }

        /// <summary>
        /// Organization name
        /// </summary>        
        public string OrganizationName
        {
            get
            {
                return m_strOrganizationName;
            }
            set
            {
                m_strOrganizationName = value;
            }
        }
        /// <summary>
        /// Designation Title
        /// </summary>        
        public string DesignationTitle
        {
            get
            {
                return m_strDesignationTitle;
            }
            set
            {
                m_strDesignationTitle = value;
            }
        }

        /// <summary>
        /// flag for mark deleted record
        /// </summary>        
        public bool IsDeleted
        {
            get
            {
                return m_bolDeleted;
            }
            set
            {
                m_bolDeleted = value;
            }
        }

        
    }
}
