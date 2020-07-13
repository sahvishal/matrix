using System.Collections.Generic;

namespace Falcon.Entity.Other
{   
    
    public class ETerritory
    {
        private int m_iTerritoryID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private int m_iType = 0;
        private int m_iTerritoryFranchiseeID = 0;
        private int m_iTerritorySalesRepID = 0;
        private int m_iParentTerritoryID = 0;
        private bool m_boolIsActive = false;
        private string m_strDateCreated = string.Empty;
        private string m_strDateModified = string.Empty;
        private List<ETerritoryZipMap> objTerritoryZipMap = null;
        private string m_strFranchiseeName = string.Empty;
        private int m_iCreatedBy = 0;
        private int m_iTotalZipCount = 0;
        private int m_iAssignedZipCount = 0;
        private int m_iUnassignedZipCount = 0;

        /// <summary>
        /// TerritoryID
        /// </summary>
        
        public int TerritoryID
        {
            get
            {
                return m_iTerritoryID;
            }
            set
            {
                m_iTerritoryID = value;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        /// <summary>
        /// Description
        /// </summary>
        
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        
        public int Type
        {
            get
            {
                return m_iType;
            }
            set
            {
                m_iType = value;
            }
        }

        /// <summary>
        /// TerritoryFranchiseeID
        /// </summary>
        
        public int TerritoryFranchiseeID
        {
            get
            {
                return m_iTerritoryFranchiseeID;
            }
            set
            {
                m_iTerritoryFranchiseeID = value;
            }
        }

        /// <summary>
        /// TerritorySalesRepID
        /// </summary>
        
        public int TerritorySalesRepID
        {
            get
            {
                return m_iTerritorySalesRepID;
            }
            set
            {
                m_iTerritorySalesRepID = value;
            }
        }

        /// <summary>
        /// ParentTerritoryID
        /// </summary>
        
        public int ParentTerritoryID
        {
            get
            {
                return m_iParentTerritoryID;
            }
            set
            {
                m_iParentTerritoryID = value;
            }
        }

        /// <summary>
        /// IsActive
        /// </summary>
        
        public bool IsActive
        {
            get
            {
                return m_boolIsActive;
            }
            set
            {
                m_boolIsActive = value;
            }
        }

        /// <summary>
        /// DateCreated
        /// </summary>
        
        public string DateCreated
        {
            get
            {
                return m_strDateCreated;
            }
            set
            {
                m_strDateCreated = value;
            }
        }

        /// <summary>
        /// DateModified
        /// </summary>
        
        public string DateModified
        {
            get
            {
                return m_strDateModified;
            }
            set
            {
                m_strDateModified = value;
            }
        }

        /// <summary>
        /// TerritoryZipMap
        /// </summary>
        
        public List<ETerritoryZipMap> TerritoryZipMap
        {
            get
            {
                return objTerritoryZipMap;
            }
            set
            {
                objTerritoryZipMap = value;
            }
        }

        /// <summary>
        /// FranchiseeName
        /// </summary>
        
        public string FranchiseeName
        {
            get
            {
                return m_strFranchiseeName;
            }
            set
            {
                m_strFranchiseeName = value;
            }
        }

        /// <summary>
        /// CreatedBy
        /// </summary>
        
        public int CreatedBy
        {
            get
            {
                return m_iCreatedBy;
            }
            set
            {
                m_iCreatedBy = value;
            }
        }

        /// <summary>
        /// TotalZipCount
        /// </summary>
        
        public int TotalZipCount
        {
            get
            {
                return m_iTotalZipCount;
            }
            set
            {
                m_iTotalZipCount = value;
            }
        }

        /// <summary>
        /// AssignedZipCount
        /// </summary>
        
        public int AssignedZipCount
        {
            get
            {
                return m_iAssignedZipCount;
            }
            set
            {
                m_iAssignedZipCount = value;
            }
        }

        /// <summary>
        /// UnassignedZipCount
        /// </summary>
        
        public int UnassignedZipCount
        {
            get
            {
                return m_iUnassignedZipCount;
            }
            set
            {
                m_iUnassignedZipCount = value;
            }
        }
    }
}
