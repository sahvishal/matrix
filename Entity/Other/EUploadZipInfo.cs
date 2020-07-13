
using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{   
    
    public class EUploadZipInfo
    {
        private int m_iUploadZipInfoID;
        private string m_strFileName = string.Empty;
        private string m_strFileSize = string.Empty;
        private int m_iTestCount;
        private bool m_bolUploadSuccessful;
        private bool m_bolParseSuccessful;
        private Int16 m_shtFailureCount = 0;
        private string m_strUploadStartTime = string.Empty;
        private string m_strUploadEndTime = string.Empty;
        private string m_strParseStartTime = string.Empty;
        private string m_strParseEndTime = string.Empty;
        private List<EUploadTestInfo> m_objUploadTestInfo = null;
        private EEvent m_objEvent = null;
        private int m_iUploadTime = 0;
        private int m_iParseTime = 0;
        private Int16 m_shtTotalCount = 0;
        private string m_strLogFilePath = null;
        private Int16 m_shtRecordsNotFoundCount = 0;
        private Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser m_objUploadedBy = null;
        private bool m_bolPreviousFileDiscarded = false;

        /// <summary>
        /// 
        /// </summary>
        
        public bool PreviousFileDiscarded
        {
            get { return m_bolPreviousFileDiscarded; }
            set { m_bolPreviousFileDiscarded = value; }
        }
	

        /// <summary>
        /// 
        /// </summary>
        
        public Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser UploadedBy
        {
            get { return m_objUploadedBy; }
            set { m_objUploadedBy = value; }
        }
	

        /// <summary>
        /// 
        /// </summary>
        
        public Int16 RecordsNotFoundCount
        {
            get { return m_shtRecordsNotFoundCount; }
            set { m_shtRecordsNotFoundCount = value; }
        }
	

        /// <summary>
        /// 
        /// </summary>
        
        public string LogFilePath
        {
            get { return m_strLogFilePath; }
            set { m_strLogFilePath = value; }
        }

	


        /// <summary>
        /// 
        /// </summary>
        
        public Int16 TotalCount
        {
            get { return m_shtTotalCount; }
            set { m_shtTotalCount = value; }
        }
	

        /// <summary>
        /// 
        /// </summary>
        
        public int ParseTime
        {
            get { return m_iParseTime; }
            set { m_iParseTime = value; }
        }
	
        /// <summary>
        /// 
        /// </summary>
        
        public int UploadTime
        {
            get { return m_iUploadTime; }
            set { m_iUploadTime = value; }
        }
	
        ///// <summary>
        ///// 
        ///// </summary>
        //
        //public Int32 UploadedByRole
        //{
        //    get { return m_iUploadedByRole; }
        //    set { m_iUploadedByRole = value; }
        //}
	
        ///// <summary>
        ///// 
        ///// </summary>
        //[DataMember (IsRequired= true)]
        //public Int64 UploadedBy
        //{
        //    get { return m_lngUploadedBy; }
        //    set { m_lngUploadedBy = value; }
        //}
	
        /// <summary>
        /// 
        /// </summary>
        
        public EEvent Event
        {
            get { return m_objEvent; }
            set { m_objEvent = value; }
        }
	
        

        /// <summary>
        /// 
        /// </summary>
        
	    public int UploadZipInfoID
	    {
		    get { return m_iUploadZipInfoID;}
		    set { m_iUploadZipInfoID = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
	    public string FileName
	    {
		    get { return m_strFileName;}
		    set { m_strFileName = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
        public string FileSize
	    {
		    get { return m_strFileSize;}
		    set { m_strFileSize = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
        public int TestCount
	    {
		    get { return m_iTestCount;}
		    set { m_iTestCount = value;}
	    }
        
        /// <summary>
        /// 
        /// </summary>
        
        public bool UploadSuccessful
	    {
		    get { return m_bolUploadSuccessful;}
		    set { m_bolUploadSuccessful = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
        public bool ParseSuccessful
	    {
		    get { return m_bolParseSuccessful;}
		    set { m_bolParseSuccessful = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
        public Int16 FailureCount
	    {
		    get { return m_shtFailureCount;}
		    set { m_shtFailureCount = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
        public string UploadStartTime
	    {
		    get { return m_strUploadStartTime;}
		    set { m_strUploadStartTime = value;}
	    }

        /// <summary>
        /// 
        /// </summary>
        
        public string UploadEndTime
        {
            get { return m_strUploadEndTime; }
            set { m_strUploadEndTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string ParseStartTime
        {
            get { return m_strParseStartTime; }
            set { m_strParseStartTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public string ParseEndTime
        {
            get { return m_strParseEndTime; }
            set { m_strParseEndTime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public List<EUploadTestInfo> UploadTestInfo
        {
            get { return m_objUploadTestInfo; }
            set { m_objUploadTestInfo = value; }
        }
	
    }
}
