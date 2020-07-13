
using System;

namespace Falcon.Entity.Other
{   
    
    public class EUploadTestInfo
    {
        private Int64 m_lngUploadTestInfoID;
        private Int64 m_lngUploadZipInfoID;
        private int m_iTestID;
        private int m_iPatientID;
        private bool m_bolIsSuccessful;
        private string m_strGeneralReasonFailure = string.Empty;
        private string m_strActualReasonFailure = string.Empty;
        private string m_strFailedRecordInfo = string.Empty;
        

        /// <summary>
        /// 
        /// </summary>
        
        public Int64 UploadTestInfoID
        {
            get { return m_lngUploadTestInfoID; }
            set { m_lngUploadTestInfoID = value; }
        }
                

        /// <summary>
        /// 
        /// </summary>
        
        public Int64 UploadZipInfoID
        {
            get { return m_lngUploadZipInfoID; }
            set { m_lngUploadZipInfoID = value; }
        }
               

        /// <summary>
        /// 
        /// </summary>
        
        public int TestID
        {
            get { return m_iTestID; }
            set { m_iTestID = value; }
        }
                

        /// <summary>
        /// 
        /// </summary>
        
        public int PatientID
        {
            get { return m_iPatientID; }
            set { m_iPatientID = value; }
        }
        

        /// <summary>
        /// 
        /// </summary>
        
        public bool IsSuccessful
        {
            get { return m_bolIsSuccessful; }
            set { m_bolIsSuccessful = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        
        public string GeneralReasonFailure
        {
            get { return m_strGeneralReasonFailure; }
            set { m_strGeneralReasonFailure = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        
        public string ActualReasonFailure
        {
            get { return m_strActualReasonFailure; }
            set { m_strActualReasonFailure = value; }
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        
        public string FailedRecordInfo
        {
            get { return m_strFailedRecordInfo; }
            set { m_strFailedRecordInfo = value; }
        }
	
	
    }
}
