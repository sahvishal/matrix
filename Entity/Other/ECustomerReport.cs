using System;

namespace Falcon.Entity.Other
{
   
    public class ECustomerReport
    {
        private int m_iCustomerEventTestID = 0;
        private ECustomers m_objCustomer = null;
        private EEventPackage m_objEventPakage = null;
        private Int32 m_iEventID;
        private bool m_bolInterpreted = true;
        private int m_iTechnicianID = 0;
        private bool m_bolLocked = true;   
   
        private bool m_bolPaid;       
      
        private DateTime m_dtDate = DateTime.Now;
        
        /// <summary>
        /// unique id
        /// </summary>        
        public int CustomerEventTestID
        {
            get
            {
                return m_iCustomerEventTestID;
            }
            set
            {
                m_iCustomerEventTestID = value;
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
        /// event package id 
        /// </summary>        
        public EEventPackage EventPackage
        {
            get
            {
                return m_objEventPakage;
            }
            set
            {
                m_objEventPakage = value;
            }
        }

        /// <summary>
        /// event object
        /// </summary>        
        public Int32 EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public int TechnicianID
        {
            get
            {
                return m_iTechnicianID;
            }
            set
            {
                m_iTechnicianID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool Interpreted
        {
            get
            {
                return m_bolInterpreted;
            }
            set
            {
                m_bolInterpreted = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool Locked
        {
            get
            {
                return m_bolLocked;
            }
            set
            {
                m_bolLocked = value;
            }
        }   

    

        /// <summary>
        /// 
        /// </summary>        
        public bool Paid
        {
            get
            {
                return m_bolPaid;
            }
            set
            {
                m_bolPaid = value;
            }
        }
   
        
        public DateTime DateCreated
        {
            get
            {
                return m_dtDate;
            }
            set
            {
                m_dtDate = value;
            }
        }
    }
}
