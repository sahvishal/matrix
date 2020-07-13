using Falcon.Entity.Franchisor;

namespace Falcon.Entity.MedicalVendor
{
    public class EMVPermittedTest
    {
        private int m_objMVPermittedTestID=0;
        private int m_iMedicalVendorID=0;
        private ETest m_objTest=null;
        private string m_strDescription=string.Empty;
        private bool m_bolActive=true;

        /// <summary>
        /// status of the object
        /// </summary>        
        public bool Active
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }
	
        /// <summary>
        /// Test description if any
        /// </summary>        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }
	
        /// <summary>
        /// ETest object for mapping EMVPermittedTest with test
        /// </summary>        
        public ETest Test
        {
            get { return m_objTest; }
            set { m_objTest = value; }
        }
	
        /// <summary>
        /// ID of the concerned medical vendor
        /// </summary>        
        public int MedicalVendorID
        {
            get { return m_iMedicalVendorID; }
            set { m_iMedicalVendorID = value; }
        }
	
        /// <summary>
        /// Master ID
        /// </summary>        
        public int MVPermittedTestID
        {
            get { return m_objMVPermittedTestID; }
            set { m_objMVPermittedTestID = value; }
        }
	
    }
}
