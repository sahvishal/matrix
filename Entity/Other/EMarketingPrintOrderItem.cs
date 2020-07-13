using System.Collections;
namespace Falcon.Entity.Other
{
    public class EMarketingPrintOrderItem
    {
        private int m_iOwnerID = 0;
        private string m_strOrderdate = string.Empty;
        private int m_iFranchiseeID = 0;

        private int m_iPrintVendorID = 0;
        private string m_strOrderStatus = string.Empty;
        private ArrayList m_EventList = null;

        private int m_iMarketingPrintOrderItemID = 0;
        private int m_iMarketingPrintOrderID = 0;
        private int m_iMarketingMaterialId = 0;

        private string m_strPhoneNumber = string.Empty;
        private string m_strSourceCode = string.Empty;
        private int m_iQuantity = 0;

        private string m_strShippingMethod = string.Empty;
        private string m_strLogo = string.Empty;

        private int m_iMarketingOrderShippingInfoID = 0;
        private bool m_bolActive = true;

        private EMarketingOrderShippingInfo m_objShippingInfo = null;
        private ArrayList m_ProspectList = null;
       

        /// <summary>
        /// Owner ID
        /// </summary>
        
        public int OwnerID
        {
            get { return m_iOwnerID; }
            set { m_iOwnerID = value; }
        }
        /// <summary>
        /// Source Code
        /// </summary>
        
        public string Orderdate
        {
            get { return m_strOrderdate; }
            set { m_strOrderdate = value; }
        }

        /// <summary>
        /// Franchisee ID
        /// </summary>
        
        public int FranchiseeID
        {
            get { return m_iFranchiseeID; }
            set { m_iFranchiseeID = value; }
        }

        /// <summary>
        /// Vendor ID
        /// </summary>
        
        public int PrintVendorID
        {
            get { return m_iPrintVendorID; }
            set { m_iPrintVendorID = value; }
        }

        /// <summary>
        /// Source Code
        /// </summary>
        
        public string strOrderStatus
        {
            get { return m_strOrderStatus; }
            set { m_strOrderStatus = value; }
        }

        /// <summary>
        /// Event List
        /// </summary>
        public ArrayList EventList
        {
            get
            {
                return m_EventList;
            }
            set
            {
                m_EventList = value;
            }
        }

        /// <summary>
        /// Marketing print Order Item Id
        /// </summary>
        
        public int MarketingPrintOrderItemID
        {
            get
            {
                return m_iMarketingPrintOrderItemID;
            }
            set
            {
                m_iMarketingPrintOrderItemID = value;
            }
        }

        /// <summary>
        /// Marketing print Order Id
        /// </summary>
        
        public int MarketingPrintOrderID
        {
            get
            {
                return m_iMarketingPrintOrderID;
            }
            set
            {
                m_iMarketingPrintOrderID = value;
            }
        }

        /// <summary>
        /// Marketing Material Id
        /// </summary>
        
        public int MarketingMaterialId
        {
            get
            {
                return m_iMarketingMaterialId;
            }
            set
            {
                m_iMarketingMaterialId = value;
            }
        }


        /// <summary>
        /// Phone number
        /// </summary>
        
        public string PhoneNumber
        {
            get { return m_strPhoneNumber; }
            set { m_strPhoneNumber = value; }
        }
        /// <summary>
        /// Source Code
        /// </summary>
        
        public string SourceCode
        {
            get { return m_strSourceCode; }
            set { m_strSourceCode = value; }
        }

        /// <summary>
        /// Quantity
        /// </summary>
        
        public int Quantity
        {
            get
            {
                return m_iQuantity;
            }
            set
            {
                m_iQuantity = value;
            }
        }


        /// <summary>
        /// Shipping Method
        /// </summary>
        
        public string ShippingMethod
        {
            get { return m_strShippingMethod; }
            set { m_strShippingMethod = value; }
        }
        /// <summary>
        /// Logo path
        /// </summary>
        
        public string Logo
        {
            get { return m_strLogo; }
            set { m_strLogo = value; }
        }

        //
        //public List<EContact> Contact
        //{
        //    get
        //    {
        //        return m_objContact;
        //    }
        //    set
        //    {
        //        m_objContact = value;
        //    }
        //}
        /// <summary>
        /// Shipping Info Id
        /// </summary>
        
        public int MarketingOrderShippingInfoID
        {
            get
            {
                return m_iMarketingOrderShippingInfoID;
            }
            set
            {
                m_iMarketingOrderShippingInfoID = value;
            }
        }
        
      
        /// <summary>
        /// prospect's status
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
        /// Prospect List
        /// </summary>
        public ArrayList ProspectList
        {
            get
            {
                return m_ProspectList;
            }
            set
            {
                m_ProspectList = value;
            }
        }

        public EMarketingOrderShippingInfo MarketingOrderShippingInfo
        {
            get
            {
                return m_objShippingInfo;
            }
            set
            {
                m_objShippingInfo = value;
            }
        }
       
    }
}
