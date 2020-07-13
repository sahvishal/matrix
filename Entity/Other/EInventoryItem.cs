using System.Collections.Generic;
using Falcon.Entity.Franchisor;


namespace Falcon.Entity.Other
{
    public class EInventoryItem
    {
        private int m_iInventoryItemID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private EItemType m_objItemType;
        private List<EItem> m_objItem;
        private List<ETest> m_objTest;
        private bool m_bolActive = true;

        /// <summary>
        /// Unique InventoryItem ID
        /// </summary>
        
        public int InventoryItemID
        {
            get
            {
                return m_iInventoryItemID;
            }
            set
            {
                m_iInventoryItemID = value;
            }
        }

        /// <summary>
        /// InventoryItem Name
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
        /// InventoryItem description
        /// </summary>
        
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        /// <summary>
        /// ItemType object for mapping InventoryItem with ItemType
        /// </summary>
        
        public EItemType ItemType
        {
            get { return m_objItemType; }
            set { m_objItemType = value; }
        }

        /// <summary>
        /// Item object for mapping InventoryItem with Item
        /// </summary>
        
        public List<EItem> Item
        {
            get { return m_objItem; }
            set { m_objItem = value; }
        }

        
        /// <summary>
        /// Test object for mapping inventory item with Test
        /// </summary>
        public List<ETest> Test
        {
            get { return m_objTest; }
            set { m_objTest = value; }
        }

        /// <summary>
        /// status of InventoryItem
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
    }
}


