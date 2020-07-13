namespace Falcon.Entity.Other
{
    public class EOrderType
    {
        private int m_iOrderTypeID = 0;
        private string m_strOrderType = string.Empty;

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
        /// OrderType
        /// </summary>
        
        public string OrderType
        {
            get
            {
                return m_strOrderType;
            }
            set
            {
                m_strOrderType = value;
            }
        }
    }
}
