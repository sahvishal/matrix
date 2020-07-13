using System.Collections;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{   
    
    public class EProspect
    {
        private bool m_bolActive = true;
        private string m_FranchiseeName = string.Empty;
        private int m_iNoOfCalls;
        private int m_iNoOfContacts;
        private int m_iNoOfMeetings;
        private EAddress m_objAddress;
        private EAddress m_objAddressMailing;
        private EContactCall m_objContactCall;

        private EContactMeeting m_objEContactMeeting;
        private ETask m_objEtask;
        private string m_strEMailID = string.Empty;
        private string m_strFirstName = string.Empty;
        private string m_strLastCallStatus = string.Empty;
        private string m_strLastName = string.Empty;
        private string m_strMiddleName = string.Empty;
        private string m_strNotes = string.Empty;
        private string m_strOrganizationName = string.Empty;
        private string m_strPhoneCell = string.Empty;
        private string m_strPhoneOffice = string.Empty;
        private string m_strPhoneOther = string.Empty;
        private string m_strProspectDate = string.Empty;
        private string m_strWebSite = string.Empty;

        public string CallCenterNotes { get; set; }
        public string TechnicianNotes { get; set; }

        public EProspect()
        {
            Title = string.Empty;
            FollowDate = string.Empty;
            ReasonWillCommunicate = string.Empty;
            Status = string.Empty;
            FranchiseeID = null;
            LastEventName = string.Empty;
            LastEventDate = string.Empty;
            CustomersPerEvent = 0;
        }

        
        public int Ranking { get; set; }

        
        public int TotalEvent { get; set; }

        
        public int TotalCustomer { get; set; }

        
        public int CustomersPerEvent { get; set; }

        
        public string LastEventDate { get; set; }

        
        public string LastEventName { get; set; }

        
        public string Status { get; set; }

        
        public ArrayList FranchiseeID { get; set; }

        
        public int AssignedStatus { get; set; }

        
        public List<EContact> Contact { get; set; }

        
        public int MethodObtainedID { get; set; }

        
        public int WillCommunicate { get; set; }

        
        public string ReasonWillCommunicate { get; set; }

        
        public decimal ActualMembership { get; set; }

        
        public decimal Attendance { get; set; }

        /// <summary>
        /// prospect's status
        /// </summary>
        
        public bool IsHost { get; set; }

        
        public string FollowDate { get; set; }

        
        public long SalesRepID { get; set; }

        /// <summary>
        /// unique prospect id
        /// </summary>
        
        public int ProspectID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public EProspectDetails ProspectDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public EProspectType ProspectType { get; set; }

        /// <summary>
        /// Prospect's title
        /// </summary>
        
        public string Title { get; set; }

        /// <summary>
        /// Prospect first name
        /// </summary>
        
        public string FirstName
        {
            get { return m_strFirstName; }
            set { m_strFirstName = value; }
        }

        /// <summary>
        /// Prospect middle name
        /// </summary>
        
        public string MiddleName
        {
            get { return m_strMiddleName; }
            set { m_strMiddleName = value; }
        }

        /// <summary>
        /// Prospect last name
        /// </summary>
        
        public string LastName
        {
            get { return m_strLastName; }
            set { m_strLastName = value; }
        }

        /// <summary>
        /// script notes
        /// </summary>
        
        public string Notes
        {
            get { return m_strNotes; }
            set { m_strNotes = value; }
        }

        /// <summary>
        /// Prospects email ID
        /// </summary>
        
        public string EMailID
        {
            get { return m_strEMailID; }
            set { m_strEMailID = value; }
        }

        /// <summary>
        /// Prospect office phone
        /// </summary>
        
        public string PhoneOffice
        {
            get { return m_strPhoneOffice; }
            set { m_strPhoneOffice = value; }
        }

        /// <summary>
        /// Prospect cell phone
        /// </summary>
        
        public string PhoneCell
        {
            get { return m_strPhoneCell; }
            set { m_strPhoneCell = value; }
        }

        /// <summary>
        /// Prospect other phone
        /// </summary>
        
        public string PhoneOther
        {
            get { return m_strPhoneOther; }
            set { m_strPhoneOther = value; }
        }

        /// <summary>
        /// Prospect's website
        /// </summary>
        
        public string WebSite
        {
            get { return m_strWebSite; }
            set { m_strWebSite = value; }
        }

        /// <summary>
        /// Prospect's Organization name
        /// </summary>
        
        public string OrganizationName
        {
            get { return m_strOrganizationName; }
            set { m_strOrganizationName = value; }
        }

        /// <summary>
        /// prospect's status
        /// </summary>
        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }

        /// <summary>
        /// Address object for mapping prospect with address 
        /// </summary>
        
        public EAddress Address
        {
            get { return m_objAddress; }
            set { m_objAddress = value; }
        }

        
        public string ProspectDate
        {
            get { return m_strProspectDate; }
            set { m_strProspectDate = value; }
        }

        /// <summary>
        /// Mailing Address object for mapping prospect with address 
        /// </summary>
        
        public EAddress AddressMailing
        {
            get { return m_objAddressMailing; }
            set { m_objAddressMailing = value; }
        }

        
        public string LastCallStatus
        {
            get { return m_strLastCallStatus; }
            set { m_strLastCallStatus = value; }
        }

        
        public EContactCall ContactCall
        {
            get { return m_objContactCall; }
            set { m_objContactCall = value; }
        }

        
        public int NoOfCalls
        {
            get { return m_iNoOfCalls; }
            set { m_iNoOfCalls = value; }
        }

        
        public int NoOfMeetings
        {
            get { return m_iNoOfMeetings; }
            set { m_iNoOfMeetings = value; }
        }

        
        public int NoOfContacts
        {
            get { return m_iNoOfContacts; }
            set { m_iNoOfContacts = value; }
        }

        
        public string FranchiseeName
        {
            get { return m_FranchiseeName; }
            set { m_FranchiseeName = value; }
        }

        
        public EContactMeeting ContactMeeting
        {
            get { return m_objEContactMeeting; }
            set { m_objEContactMeeting = value; }
        }

        
        public ETask Task
        {
            get { return m_objEtask; }
            set { m_objEtask = value; }
        }
        public string TaxIdNumber { get; set; }
        public string SalesRep { get; set; }

        public string Fax { get; set; }
    }
}