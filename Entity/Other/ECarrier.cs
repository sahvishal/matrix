namespace Falcon.Entity.Other
{    
    public class ECarrier
    {
        private int m_iCarrierID = 0;
        private string m_strCarrier = string.Empty;

        /// <summary>
        /// CarrierID
        /// </summary>        
        public int CarrierID
        {
            get
            {
                return m_iCarrierID;
            }
            set
            {
                m_iCarrierID = value;
            }
        }

        /// <summary>
        /// Carrier
        /// </summary>        
        public string Carrier
        {
            get
            {
                return m_strCarrier;
            }
            set
            {
                m_strCarrier = value;
            }
        }
    }
}
