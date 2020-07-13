namespace Falcon.Entity.Other
{
    public class EInventoryItemTest
    {
        private int m_iInventoryItemTestID = 0;
        private int m_iInventoryItemID = 0;
        private int m_iTestID = 0;
        private bool m_bolActive = true;

        
        /// <summary>
        /// 
        /// </summary>
        public int InventoryItemTestID
        {
            get { return m_iInventoryItemTestID; }
            set { m_iInventoryItemTestID = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public int InventoryItemID
        {
            get { return m_iInventoryItemID; }
            set { m_iInventoryItemID = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public int TestID
        {
            get { return m_iTestID; }
            set { m_iTestID = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }

    }
}
