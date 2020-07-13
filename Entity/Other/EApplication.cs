namespace Falcon.Entity.Other
{    
    public class EApplication
    {
        private string businessname = string.Empty;
        private EAddress businessaddress=null;
        private EAddress contactaddress=null;
        private string firstname = string.Empty;
        private string middlename = string.Empty;
        private string lastname = string.Empty;
        private string phonecell = string.Empty;
        private string phonehome = string.Empty;
        private string phoneoffice = string.Empty;
        private string email1 = string.Empty;
        private string email2=string.Empty;
        private string referencename1=string.Empty;
        private string referenceemail1=string.Empty;
        private string referencename2=string.Empty;
        private string referenceemail2=string.Empty;
        private string referencename3=string.Empty;
        private string referenceemail3=string.Empty;
        private string m_strDOB = string.Empty;
        private string m_strSSN = string.Empty;

        
        public string SSN
        {
            get { return m_strSSN; }
            set { m_strSSN = value; }
        }
        
        public string BusinessName
        {
            get { return businessname; }
            set { businessname = value; }
        }
        
        public EAddress BusinessAddress
        {
            get { return businessaddress; }
            set { businessaddress = value; }
        }
        
        public EAddress  ContactAddress
        {
            get { return contactaddress; }
            set { contactaddress = value; }
        }
        
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        
        public string MiddleName
        {
            get { return middlename; }
            set { middlename = value; }
        }
        
        public string DOB
        {
            get { return m_strDOB; }
            set { m_strDOB = value; }
        }
        
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        
        public string PhoneCell
        {
            get { return phonecell; }
            set { phonecell = value; }
        }
        
        public string PhoneHome
        {
            get { return phonehome; }
            set { phonehome = value; }
        }
        
        public string PhoneOffice
        {
            get { return phoneoffice; }
            set { phoneoffice = value; }
        }
        
        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }
        
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        
        public string ReferenceName1
        {
            get { return referencename1; }
            set { referencename1 = value; }
        }
        
        public string ReferenceEmail1
        {
            get { return referenceemail1; }
            set { referenceemail1 = value; }
        }
        
        public string ReferenceName2
        {
            get { return referencename2; }
            set { referencename2 = value; }
        }
        
        public string ReferenceEmail2
        {
            get { return referenceemail2; }
            set { referenceemail2 = value; }
        }


        
        public string ReferenceName3
        {
            get { return referencename3; }
            set { referencename3 = value; }
        }

        
        public string ReferenceEmail3
        {
            get { return referenceemail3; }
            set { referenceemail3 = value; }
        }

 




    }
}
