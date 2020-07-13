namespace Falcon.Entity.Other
{

    public class EProspectList
    {
        private int m_iProspectListID = 0;
        private string m_strFileName = string.Empty;
        private bool m_bolActive = true;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private string m_strListName = string.Empty;
        private string m_strListSource = string.Empty;
        private int m_iListType = 0;
        private string m_strLogList = string.Empty;
        // Stats. fields not the real fields
        private string m_strNoOfProspect = string.Empty;
        private string m_strNoOfProspectFailure = string.Empty;
        private string m_strProspectStatus = string.Empty;
        private string m_strUsername = string.Empty;
        private string m_strRole = string.Empty;
        private int m_iRoleId = 0;
        private string m_strFileSize = string.Empty;
        private string m_strUploadTime = string.Empty;
        
        private bool m_blnAssigned = false;

        /// <summary>
        /// ProspectListID 
        /// </summary>

        public int ProspectListID
        {
            get { return m_iProspectListID; }
            set { m_iProspectListID = value; }
        }
        /// <summary>
        ///File Name
        /// </summary>

        public string FileName
        {
            get { return m_strFileName; }
            set { m_strFileName = value; }
        }
        /// <summary>
        ///File Name
        /// </summary>

        public bool IsActive
        {
            get { return m_bolActive; }
            set { m_bolActive = value; }
        }

        /// <summary>
        ///DateCreated
        /// </summary>

        public string DateCreated
        {
            get { return m_strDateCreated; }
            set { m_strDateCreated = value; }
        }

        /// <summary>
        ///DateModified
        /// </summary>

        public string DateModified
        {
            get { return m_strDateModified; }
            set { m_strDateModified = value; }
        }

        /// <summary>
        /// ListName
        /// </summary>

        public string ListName
        {
            get { return m_strListName; }
            set { m_strListName = value; }
        }

        /// <summary>
        /// ListType
        /// </summary>

        public int ListType
        {
            get { return m_iListType; }
            set { m_iListType = value; }
        }

        /// <summary>
        /// ListSource
        /// </summary>

        public string ListSource
        {
            get { return m_strListSource; }
            set { m_strListSource = value; }
        }
        /// <summary>
        /// ListSource
        /// </summary>

        public string LogList
        {
            get { return m_strLogList; }
            set { m_strLogList = value; }
        }

        /// <summary>
        /// NoOfProspect
        /// </summary>

        public string NoOfProspect
        {
            get { return m_strNoOfProspect; }
            set { m_strNoOfProspect = value; }
        }

        /// <summary>
        /// NoOfProspectFailure
        /// </summary>

        public string NoOfProspectFailure
        {
            get { return m_strNoOfProspectFailure; }
            set { m_strNoOfProspectFailure = value; }
        }

        /// <summary>
        /// ProspectListUploadStatus
        /// </summary>

        public string ProspectListUploadStatus
        {
            get { return m_strProspectStatus; }
            set { m_strProspectStatus = value; }
        }

        /// <summary>
        /// m_strUsername
        /// </summary>

        public string Username
        {
            get { return m_strUsername; }
            set { m_strUsername = value; }
        }

        /// <summary>
        /// UserRole
        /// </summary>

        public string UserRole
        {
            get { return m_strRole; }
            set { m_strRole = value; }
        }

        /// <summary>
        /// User Role ID
        /// </summary>

        public int RoleID
        {
            get { return m_iRoleId; }
            set { m_iRoleId = value; }
        }

        /// <summary>
        /// File size
        /// </summary>

        public string FileSize
        {
            get { return m_strFileSize; }
            set { m_strFileSize = value; }
        }

        /// <summary>
        /// Upload Time
        /// </summary>

        public string UploadTime
        {
            get { return m_strUploadTime; }
            set { m_strUploadTime = value; }
        }

        /// <summary>
        /// Franchiess ID
        /// </summary>

        public long FranchiseeID
        {
            get;
            set;
        }

        /// <summary>
        /// Assigned prospect list
        /// </summary>

        public bool Assigned
        {
            get { return m_blnAssigned; }
            set { m_blnAssigned = value; }
        }

    }
}
