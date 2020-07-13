using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    public class EHost
    {
        private int m_iHostID = 0;
        private string m_strName = string.Empty;
        private string m_strWebAddress = string.Empty;
        private string m_strStatus =string.Empty;
        private string m_strMap = string.Empty;
        private int m_iMethodObtainedID =0;
        private int m_iHostSize = 0;
        private bool m_bolActive = true;
        private string m_strPhoneCell = string.Empty;
        private string m_strPhoneHome = string.Empty;
        private string m_strPhoneOffice = string.Empty;
        private string m_strEMail1 = string.Empty;
        private string m_strEMail2 = string.Empty;

        private EAddress m_objAddress;
        private EHostContacts m_objHostContacts1;
        private EHostContacts m_objHostContacts2;
        private EHostType m_objHostType;
        private EProspect m_objProspect=null;
        private List<ENoteCommon> m_objNoteCommon;
        /// <summary>
        /// Unique HostID
        /// </summary>
        
        public int HostID
        {
            get
            {
                return m_iHostID;
            }
            set
            {
                m_iHostID = value;
            }
        }
        /// <summary>
        /// host name
        /// </summary>
        
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }
        /// <summary>
        /// host's web address
        /// </summary>
        
        public string WebAddress
        {
            get
            {
                return m_strWebAddress;
            }
            set
            {
               m_strWebAddress = value;
            }
        }
        /// <summary>
        /// location map
        /// </summary>
        
        public string Map
        {
            get
            {
                return m_strMap;
            }
            set
            {
                m_strMap = value;
            }
        }

        /// <summary>
        /// status of host
       /// </summary>
        
        public string Status
        {
            get
            {
                return m_strStatus;
            }
            set
            {
                m_strStatus = value;
            }
        }

        /// <summary>
        /// mehod obtained id of host
        /// </summary>
        
        public int MethodObtainedID
        {
            get
            {
                return m_iMethodObtainedID;
            }
            set
            {
                m_iMethodObtainedID = value;
            }
        }

        /// <summary>
        /// size of host
        /// </summary>
        
        public int HostSize
        {
            get
            {
                return m_iHostSize;
            }
            set
            {
                m_iHostSize = value;
            }
        }

        /// <summary>
        /// host status
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
        /// address object for mapping host with address 
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
        /// hosttype object for mapping host with hosttype 
        /// </summary>
        
        public EHostType HostType
        {
            get
            {
                return m_objHostType;
            }
            set
            {
                m_objHostType = value;
            }
        }

        /// <summary>
        /// hostcontacts  object for mapping host with hostcontact 
        /// </summary>
        
        public EHostContacts HostContacts
        {
            get
            {
                return m_objHostContacts1;
            }
            set
            {
                m_objHostContacts1 = value;
            }
        }

        /// <summary>
        /// hostcontacts  object for mapping host with hostcontact 
        /// </summary>
        
        public EHostContacts PrimaryContact
        {
            get
            {
                return m_objHostContacts2;
            }
            set
            {
                m_objHostContacts2 = value;
            }
        }

        /// <summary>
        /// prospect object for mapping host with prospect 
        /// </summary>
        
        public EProspect Prospect
        {
            get
            {
               return m_objProspect;
            }
            set
            {
                m_objProspect = value;
            }
        }

        /// <summary>
        /// note object 
        /// </summary>
        
        public List<ENoteCommon> NoteCommon
        {
            get
            {
                return m_objNoteCommon;
            }
            set
            {
                m_objNoteCommon = value;
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
        /// Email(1) Address 
        /// </summary>
        
        public string EMail1
        {
            get
            {
                return m_strEMail1;
            }
            set
            {
                m_strEMail1 = value;
            }
        }

        /// <summary>
        /// EMail(2) address
        /// </summary>
        
        public string EMail2
        {
            get
            {
                return m_strEMail2;
            }
            set
            {
                m_strEMail2 = value;
            }
        }
        public string TaxIdNumber { get; set; }

    }
}