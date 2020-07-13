namespace Falcon.Entity.Other
{    
    
    public class ETrackingMarketing
    {
        private int m_iTrackingMarketingID = 0;
        private string m_strSourceName = string.Empty;
        private bool m_bolActive = true;

        
        public int TrackingMarketingID
        {
            get
            {
                return m_iTrackingMarketingID;
            }
            set
            {
                m_iTrackingMarketingID = value;
            }
        }

        
        public string SourceName
        {
            get
            {
                return m_strSourceName;
            }
            set
            {
                m_strSourceName = value;
            }
        }

        
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
