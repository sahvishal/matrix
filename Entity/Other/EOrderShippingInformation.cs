namespace Falcon.Entity.Other
{
    public class EOrderShippingInformation
    {
        private int m_iOrderShippingInformationID = 0;
        private int m_iCarrier = 0;
        private string m_strCarrierTransactionNumber = string.Empty;
        private int m_iShippingAddressID = 0;
        private string m_strTrackingNumber = string.Empty;
        private string m_strShippingDate = string.Empty;
        private string m_strShippingNotes = string.Empty;
        private int m_iCreatedBy = 0;
        private string m_strDateCreated = string.Empty;
        private int m_iLastModifiedBy = 0;
        private int m_iLastModifiedByRole = 0;
        private string m_strDateModified = string.Empty;
        private string m_strCreatedDate = string.Empty;
        private EAddress m_objShippingAddress = null;

        /// <summary>
        /// ShippingID
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
        /// Carrier
        /// </summary>
        
        public int Carrier
        {
            get
            {
                return m_iCarrier;
            }
            set
            {
                m_iCarrier = value;
            }
        }

        /// <summary>
        /// CarrierTransactionNumber
        /// </summary>
        
        public string CarrierTransactionNumber
        {
            get
            {
                return m_strCarrierTransactionNumber;
            }
            set
            {
                m_strCarrierTransactionNumber = value;
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
        /// TrackingNumber
        /// </summary>
        
        public string TrackingNumber
        {
            get
            {
                return m_strTrackingNumber;
            }
            set
            {
                m_strTrackingNumber = value;
            }
        }

        /// <summary>
        /// ShippingDate
        /// </summary>
        
        public string ShippingDate
        {
            get
            {
                return m_strShippingDate;
            }
            set
            {
                m_strShippingDate=value;
            }
        }

        /// <summary>
        /// ShippingNotes
        /// </summary>
        
        public string ShippingNotes
        {
            get
            {
                return m_strShippingNotes;
            }
            set
            {
                m_strShippingNotes = value;
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
        /// LastModifiedBy
        /// </summary>
        
        public int LastModifiedBy
        {
            get
            {
                return m_iLastModifiedBy;
            }
            set
            {
                m_iLastModifiedBy = value;
            }
        }

        /// <summary>
        /// LastModifiedByRole
        /// </summary>
        
        public int LastModifiedByRole
        {
            get
            {
                return m_iLastModifiedByRole;
            }
            set
            {
                m_iLastModifiedByRole = value;
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
        /// ShippingAddress
        /// </summary>
        
        public EAddress ShippingAddress
        {
            get 
            { 
                return m_objShippingAddress; 
            }
            set 
            { 
                m_objShippingAddress = value; 
            }
        }

    }
}
