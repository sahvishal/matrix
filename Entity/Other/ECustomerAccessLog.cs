namespace Falcon.Entity.Other
{
    
    public class ECustomerAccessLog
    {
        private int m_iCustomerAccessLogID = 0;
        private int m_iMedicalVendorUsedID = 0;
        private int m_iCustomerID = 0;
        private int m_iEventid = 0;

        /// <summary>
        /// CustomerAccessLogID
        /// </summary>       
        public int CustomerAccessLogID
        {
            get
            {
                return m_iCustomerAccessLogID;
            }
            set
            {
                m_iCustomerAccessLogID = value;
            }
        }

        /// <summary>
        /// MedicalVendorUsedID
        /// </summary>        
        public int MedicalVendorUsedID
        {
            get
            {
                return m_iMedicalVendorUsedID;
            }
            set
            {
                m_iMedicalVendorUsedID = value;
            }
        }

        /// <summary>
        /// CustomerID
        /// </summary>        
        public int CustomerID
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
        /// EventID
        /// </summary>        
        public int EventID
        {
            get
            {
                return m_iEventid;
            }
            set
            {
                m_iEventid = value;
            }
        }
    }
}
