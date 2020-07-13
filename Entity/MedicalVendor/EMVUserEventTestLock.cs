using Falcon.Entity.Franchisor;

namespace Falcon.Entity.MedicalVendor
{
    
    public class EMVUserEventTestLock
    {
        private int m_iMVUserEventTestLockID=0;
        private int m_iCustomerEventTestID=0;
        private EMVMVUser m_objMVMVUser=null;
        private ETest m_objTest=null;
        private bool m_bolActive=true;
        private bool m_bolAlert=true;

        /// <summary>
        /// Alert Status
        /// </summary>        
        public bool AlertSent
        {
            get { return m_bolAlert; }
            set { m_bolAlert = value; }
        }

        /// <summary>
        /// status of object
        /// </summary>        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }

        /// <summary>
        /// Test object for mapping MVUserEventTestLock with Test
        /// </summary>        
        public ETest Test
        {
            get { return m_objTest; }
            set { m_objTest = value; }
        }

	
        /// <summary>
        /// MVMVUser object for mapping MVUserEventTestLock with MVMVUser
        /// </summary>        
        public EMVMVUser MVMVUser
        {
            get { return m_objMVMVUser; }
            set { m_objMVMVUser = value; }
        }

        /// <summary>
        /// Id of the concerned customer  
        /// </summary>        
        public int CustomerEventTestID
        {
            get { return m_iCustomerEventTestID; }
            set { m_iCustomerEventTestID = value; }

        }

        /// <summary>
        /// MVUserEventTestLockID of the concerned customer  
        /// </summary>        
        public int MVUserEventTestLockID
        {
            get { return m_iMVUserEventTestLockID; }
            set { m_iMVUserEventTestLockID = value; }
        }
	
    }
}
