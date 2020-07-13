namespace Falcon.Entity.Other
{
    
    public class ECustomerRegistrationNotes
    {
        private int m_CustomerRegistrationNotesID = 0;
        private ECustomers m_objCustomer = null;
        private int m_RoleID = 0;
        private int m_ShellID = 0;
        private string m_Notes = string.Empty;
        private string m_DateCreated = string.Empty;
        private string m_DateModified = string.Empty;
        private bool m_IsActive = false;
        private string action = string.Empty;

        /// <summary>
        /// CustomerRegistrationNotesID
        /// </summary>        
        public int CustomerRegistrationNotesID
        {
            get
            {
                return m_CustomerRegistrationNotesID;
            }
            set
            {
                m_CustomerRegistrationNotesID = value;
            }
        }

        /// <summary>
        /// customer object
        /// </summary>        
        public ECustomers Customer
        {
            get
            {
                return m_objCustomer;
            }
            set
            {
                m_objCustomer = value;
            }
        }

        /// <summary>
        /// RoleID
        /// </summary>        
        public int RoleID
        {
            get
            {
                return m_RoleID;
            }
            set
            {
                m_RoleID = value;
            }
        }

        /// <summary>
        /// ShellID
        /// </summary>        
        public int ShellID
        {
            get
            {
                return m_ShellID;
            }
            set
            {
                m_ShellID = value;
            }
        }

        /// <summary>
        /// Notes
        /// </summary>        
        public string Notes
        {
            get
            {
                return m_Notes;
            }
            set
            {
                m_Notes = value;
            }
        }

        /// <summary>
        /// DateCreated
        /// </summary>        
        public string DateCreated
        {
            get
            {
                return m_DateCreated;
            }
            set
            {
                m_DateCreated = value;
            }
        }

        /// <summary>
        /// DateModified
        /// </summary>        
        public string DateModified
        {
            get
            {
                return m_DateModified;
            }
            set
            {
                m_DateModified = value;
            }
        }

        /// <summary>
        /// IsActive
        /// </summary>        
        public bool IsActive
        {
            get
            {
                return m_IsActive;
            }
            set
            {
                m_IsActive = value;
            }
        }

        
        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
    }
}
