using System.Collections.Generic;
using Falcon.Entity.Franchisee;
namespace Falcon.Entity.Other
{   
    
    public class EPod
    {
        private int m_iPodID = 0;
        private string m_strName = string.Empty;
        private string m_strDescription = string.Empty;
        private List<EItem> m_objItemList;
        private List<EFranchiseeFranchiseeUser> m_objTeamIDList;
        private bool m_bolActive = true;
        private EVan m_objVan;
        private int m_iFranchiseeID = 0;
        private int m_iPodProcessingCapacity = 0;
        private bool m_bolDefault = false;
        //private BMSEntity.Franchisee.Franchisee m_objFranchisee;

        /// <summary>
        /// unique pod id
        /// </summary>
        
        public int PodID
        {
            get
            {
                return m_iPodID;
            }
            set
            {
                m_iPodID = value;
            }
        }

        /// <summary>
        /// Franchisee ID related to the Pod
        /// </summary>
        
        public int FranchiseeID
        {
            get
            {
                return m_iFranchiseeID;
            }
            set
            {
                m_iFranchiseeID = value;
            }
        }

        /// <summary>
        /// pod name
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
        /// pod description
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
        /// list of items associated with pod
        /// </summary>
        
        public List<EItem> ItemList
        {
            get
            {
                return m_objItemList;
            }
            set
            {
                m_objItemList = value;
            }
        }

        /// <summary>
        /// list of team IDs associated with pod
        /// </summary>
        
        public List<EFranchiseeFranchiseeUser> TeamIDList
        {
            get
            {
                return m_objTeamIDList;
            }
            set
            {
                m_objTeamIDList = value;
            }
        }

        /// <summary>
        /// PodProcessingCapacity of the pod
        /// </summary>
        
        public int PodProcessingCapacity
        {
            get { return m_iPodProcessingCapacity; }
            set { m_iPodProcessingCapacity = value; }
        }
        

        /// <summary>
        /// pod status
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
        /// <summary>
        /// van object for mapping pod with van 
        /// </summary>
        
        public EVan Van
        {
            get { return m_objVan; }
            set { m_objVan = value; }
        }

        ///// <summary>
        ///// franchisee object for mapping pod with franchisee 
        ///// </summary>
        //
        //public BMSEntity.Franchisee.Franchisee Franchisee
        //{
        //    get { return m_objFranchisee; }
        //    set { m_objFranchisee = value; }
        //}

        
        public bool Default
        {
            get
            {

                return m_bolDefault;
            }
            set
            {
                m_bolDefault = value;
            }
        }
    
    }
}
