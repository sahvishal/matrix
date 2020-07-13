namespace Falcon.Entity.Other
{
    public class EEventLocalPublications
    {
        private int m_iEventPublicationID;
        private int m_iEventID;
        private string m_strPublicationName;
        private string m_strContactName;
        private string m_strContactInfo;
        private string m_strDescription;

        
        /// <summary>
        /// 
        /// </summary>
        
        public int EventPublicationID
        {
            get { return m_iEventPublicationID; }
            set { m_iEventPublicationID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public int EventID
        {
            get { return m_iEventID; }
            set { m_iEventID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string PublicationName
        {
            get { return m_strPublicationName; }
            set { m_strPublicationName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string ContactName
        {
            get { return m_strContactName; }
            set { m_strContactName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string ContactInfo
        {
            get { return m_strContactInfo; }
            set { m_strContactInfo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }
	
	
    }
}
