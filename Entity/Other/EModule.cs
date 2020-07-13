using Falcon.App.Core.Enum;

namespace Falcon.Entity.Other
{
    public class EModule
    {
        #region Private Variables
        private int m_iModuleID;
        private string m_strName;
        private string m_strDescription;
        private int m_iParentModuleID; 
        private bool m_bolTopModule;
        private bool m_bolActive;
        private EAccessType m_objAccessType;
        private string m_strTargeturl;
        private int m_iMenuOrder;
        #endregion

        #region Properties
        /// <summary>
        /// Unique Module ID
        /// </summary>
        
        public int ModuleID
        {
            get { return m_iModuleID; }
            set { m_iModuleID = value; }
        }

        /// <summary>
        /// Module Name
        /// </summary>
        
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        /// <summary>
        /// Module Description
        /// </summary>
        
        public string Description
        {
            get { return m_strDescription; }
            set { m_strDescription = value; }
        }

        /// <summary>
        /// This will specify the id of the 
        /// Parent module. This will be 
        /// instrumental in creating a parent 
        /// Child Relationship.
        /// </summary>
        
        public int ParentModuleID
        {
            get { return m_iParentModuleID; }
            set { m_iParentModuleID = value; }
        }

        /// <summary>
        /// This will specify if the current 
        /// module is a top level module
        /// </summary>
        
        public bool IsTopModule
        {
            get { return m_bolTopModule; }
            set { m_bolTopModule = value; }
        }

        
        public  EAccessType AccessType
        {
            get { return m_objAccessType; }
            set { m_objAccessType = value; }
        }
        /// <summary>
        /// this string define the path of the screen (ASPX page)
        /// </summary>
        
        public string TargetURL
        {
            get { return m_strTargeturl; }
            set { m_strTargeturl = value; }
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

        /// <summary>
        /// To sort the menu
        /// </summary>
        
        public int MenuOrder
        {
            get { return m_iMenuOrder; }
            set { m_iMenuOrder = value; }
        }
        #endregion
    }
}
