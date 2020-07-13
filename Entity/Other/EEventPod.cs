namespace Falcon.Entity.Other
{
    public class EEventPod
    {
        private int m_iEventPodID = 0;
        private int m_iEventID=0;
        private EPod m_objPod=null;
        private bool m_bolActive = true;

        /// <summary>
        /// unique id
        /// </summary>
        
        public int EventPodID
        {
            get
            {
                return m_iEventPodID;
            }
            set
            {
                m_iEventPodID = value;
            }
        }

        /// <summary>
        /// pod object for mappint eventpod with pod
        /// </summary>
        
        public EPod Pod
        {
            get
            {
                return m_objPod;
            }
            set
            {
                m_objPod = value;            
            }
        }

        /// <summary>
        ///  EventID for mapping eventpod with EEvent
        /// </summary>
        
        public int EventID
        {
            get
            {
                return m_iEventID;
            }
            set
            {
                m_iEventID = value;
            }
        }

        /// <summary>
        /// status of the EEventPod
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
