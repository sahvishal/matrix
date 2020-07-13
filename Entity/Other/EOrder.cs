namespace Falcon.Entity.Other
{
    public class EOrder
    {
        private int m_iOrderID = 0;
        private int m_iCustomerID = 0;
        private string m_strCreatedDate = string.Empty;
        private int m_iOrderTypeID = 0;
        private bool m_boolIsPaid = false;
        private int m_iStatus = 0;
        private int m_iCreatedBy = 0;
        private int m_iCreatedByRole = 0;
        private string m_strDateCreated = string.Empty;
        private int m_iModifiedBy = 0;
        private int m_iModifiedByRole = 0;
        private string m_strDateModified = string.Empty;
        private int m_iResultCatalogID = 0;
        private int m_iOrderShippingInformationID = 0;
        private int m_iShippingAddressID = 0;
        private int m_iEventID = 0;

        /// <summary>
        /// OrderID
        /// </summary>
        
        public int OrderID
        {
            get
            {
                return m_iOrderID;
            }
            set
            {
                m_iOrderID = value;
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
        /// OrderTypeID
        /// </summary>
        
        public int OrderTypeID
        {
            get
            {
                return m_iOrderTypeID;
            }
            set
            {
                m_iOrderTypeID = value;
            }
        }

        /// <summary>
        /// IsPaid
        /// </summary>
        
        public bool IsPaid
        {
            get
            {
                return m_boolIsPaid;
            }
            set
            {
                m_boolIsPaid = value;
            }
        }


        /// <summary>
        /// Status
        /// </summary>
        
        public int Status
        {
            get
            {
                return m_iStatus;
            }
            set
            {
                m_iStatus = value;
            }
        }

        /// <summary>
        /// CreatedBy
        /// </summary>
        
        public int CreatedBy
        {
            get
            {
                return m_iCreatedBy;
            }
            set
            {
                m_iCreatedBy = value;
            }
        }

        /// <summary>
        /// CreatedByRole
        /// </summary>
        
        public int CreatedByRole
        {
            get
            {
                return m_iCreatedByRole;
            }
            set
            {
                m_iCreatedByRole = value;
            }
        }

        /// <summary>
        /// DateCreated
        /// </summary>
        
        public string DateCreated
        {
            get
            {
                return m_strDateCreated;
            }
            set
            {
                m_strDateCreated = value;
            }
        }

        /// <summary>
        /// ModifiedBy
        /// </summary>
        
        public int ModifiedBy
        {
            get
            {
                return m_iModifiedBy;
            }
            set
            {
                m_iModifiedBy = value;
            }
        }

        /// <summary>
        /// ModifiedByRole
        /// </summary>
        
        public int ModifiedByRole
        {
            get
            {
                return m_iModifiedByRole;
            }
            set
            {
                m_iModifiedByRole = value;
            }
        }

        /// <summary>
        /// DateModified
        /// </summary>
        
        public string DateModified
        {
            get
            {
                return m_strDateModified;
            }
            set
            {
                m_strDateModified = value;
            }
        }

        /// <summary>
        /// ResultCatalogID
        /// </summary>
        
        public int ResultCatalogID
        {
            get
            {
                return m_iResultCatalogID;
            }
            set
            {
                m_iResultCatalogID = value;
            }
        }

        /// <summary>
        /// OrderShippingInformationID
        /// </summary>
        
        public int OrderShippingInformationID
        {
            get
            {
                return m_iOrderShippingInformationID;
            }
            set
            {
                m_iOrderShippingInformationID = value;
            }
        }

        /// <summary>
        /// ShippingAddressID
        /// </summary>
        
        public int ShippingAddressID
        {
            get
            {
                return m_iShippingAddressID;
            }
            set
            {
                m_iShippingAddressID = value;
            }
        }

        /// <summary>
        /// EventID
        /// </summary>
        
        public int EventID
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
        
    }
}
