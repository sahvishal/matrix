namespace Falcon.Entity.Other
{   
    
    public class EProspectListType
    {
        private int m_iProspectListTypeID = 0;
        private string m_strProspectListName = string.Empty;
        private string m_strDateCreated= string.Empty;

        /// <summary>
        /// ProspectListTypeID 
        /// </summary>
        
        public int ProspectListTypeID
        {
            get { return m_iProspectListTypeID; }
            set { m_iProspectListTypeID = value; }
        }
        /// <summary>
        ///Prospect List Name
        /// </summary>
        
        public string ProspectListName
        {
            get { return m_strProspectListName; }
            set { m_strProspectListName = value; }
        }
        /// <summary>
        ///Date Created
        /// </summary>
        
        public string DateCreated
        {
            get { return m_strDateCreated; }
            set { m_strDateCreated = value; }
        }        
    }
}
