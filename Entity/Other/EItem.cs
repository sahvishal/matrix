namespace Falcon.Entity.Other
{
    public class EItem
    {
        private int m_iItemID = 0;
        private string m_strItemCode = string.Empty;
        private string m_strSKUCode = string.Empty;
        private string m_strManufacturerName = string.Empty;
        private string m_strManufacturerID = string.Empty;
        private string m_strNotes = string.Empty;
        private int  m_iInventoryItemID = 0;
        private bool m_bolActive = true;
        private bool m_bolAllocated = true;

        /// <summary>
        /// Unique Item ID
        /// </summary>
        
        public int ItemID
        {
            get
            {
                return m_iItemID;
            }
            set
            {
                m_iItemID = value;
            }
        }

        /// <summary>
        /// Item Code
        /// </summary>
        
        public string ItemCode
        {
            get
            {
                return m_strItemCode;
            }
            set
            {
                m_strItemCode = value;
            }
        }
        /// <summary>
        /// item SKU Code
        /// </summary>
        
        public string SKUCode
        {
            get
            {
                return m_strSKUCode;
            }
            set
            {
                m_strSKUCode = value;
            }
        }
        /// <summary>
        /// ManufacturerName of item
        /// </summary>

        
        public string ManufacturerName
        {
            get
            {
                return m_strManufacturerName;
            }
            set
            {
                m_strManufacturerName = value;
            }
        }
        /// <summary>
        /// id of manufacturer
        /// </summary>
        
        public string ManufacturerID
        {
            get
            {
                return m_strManufacturerID;
            }
            set
            {
                m_strManufacturerID = value;
            }
        }
        /// <summary>
        /// Item description
        /// </summary>
        
        public string Notes
        {
            get
            {
                return m_strNotes;
            }
            set
            {
                m_strNotes = value;
            }
        }

        /// <summary>
        /// InventoryItem ID
        /// </summary>
        
        public int InventoryItemID
        {
            get { return m_iInventoryItemID; }
            set { m_iInventoryItemID = value; }
        }

        /// <summary>
        /// status of Item
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
        /// availability of item
        /// </summary>
        
        public bool Allocated
        {
            get
            {
                return m_bolAllocated;
            }
            set
            {
                m_bolAllocated = value;
            }
        }
    }
}


