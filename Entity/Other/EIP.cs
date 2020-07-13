namespace Falcon.Entity.Other
{
    public class EIP
    {
        private int m_iIPID = 0;
        private string m_strDecsription = string.Empty;
        private string m_strIPAddress = string.Empty;
        private bool m_bolActive = true;
    
        /// <summary>
        /// Unique IP ID
        /// </summary>
        
        public int IPID
        {
            get
            {
                return m_iIPID;
            }
            set
            {
                m_iIPID = value;
            }
        }
        /// <summary>
        /// IP description
        /// </summary>
        
        public string Description
        {
            get
            {
                return m_strDecsription ;
            }
            set
            {
                m_strDecsription = value;
            }
        }

        /// <summary>
        /// IP address
        /// </summary>
        
        public string IPAddress
        {
            get
            {
                return m_strIPAddress;
            }
            set
            {
                m_strIPAddress = value;
            }
        }

        /// <summary>
        /// IP status
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
