namespace Falcon.Entity.Other
{
    /// <summary>
    /// Used to retrieve the value for key-value pair
    /// </summary>
    
    public class EKeyValuepair
    {
        private string m_Value = string.Empty;
        private int m_key = 0;

        /// <summary>
        /// Value
        /// </summary>
        
        public string Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

        /// <summary>
        /// InventoryItem ID
        /// </summary>
        
        public int Key
        {
            get { return m_key; }
            set { m_key = value; }
        }
    }
}
