using System;

namespace Falcon.Entity.Other
{   
    
    public class EPodInventory
    {
        private Int64 m_iPodInventoryID;
        
        public Int64 PodInventoryID
        {
            get { return m_iPodInventoryID; }
            set { m_iPodInventoryID = value; }
        }

        private EItem m_objItem;
        
        public EItem Item
        {
            get { return m_objItem; }
            set { m_objItem = value; }
        }
        
        private EPod m_objPod;
        
        public EPod Pod
        {
            get { return m_objPod; }
            set { m_objPod = value; }
        }

        private bool m_bolActive;
        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }
	
        
    }
}
