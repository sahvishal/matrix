using System;
using System.Collections.Generic;
using Falcon.Entity.Other;

namespace Falcon.Entity.Franchisor
{
    [Serializable]
    public class EPackage
    {
        private int m_iPackageID = 0;
        private string m_strPackageName = string.Empty;
        private string m_strDescription = string.Empty;
        private bool m_bolActive = true;
        private float m_fMinimumPackagePrice = 0;
        private float m_fRecommendedPrice = 0;
        private List<ETest> m_objTest=null;
        private EAAATestResult m_objAAATest=null;
        private ECarotidArteryTestResult m_objCardioTest=null;
        private EASITestResult m_objASITest=null;
        private EOsteoporosisTestResult m_objOsteoporosisTest = null;
        private EPADTestResult m_objPADTest = null;
        private int m_iRelativeOrder = 0;
        private bool m_bolDescriptiononPublicWebsite;
        private bool m_bolIsSelectedByDefaultForEvent = false;

        /// <summary>
        /// Package will selected by default for event
        /// </summary>
        public bool IsSelectedByDefaultForEvent
        {
            get { return m_bolIsSelectedByDefaultForEvent; }
            set { m_bolIsSelectedByDefaultForEvent = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DescriptiononPublicWebsite
        {
            get { return m_bolDescriptiononPublicWebsite; }
            set { m_bolDescriptiononPublicWebsite = value; }
        }
        
        public EAAATestResult AAATestResult
        {
            get
            {
                return m_objAAATest;
            }
            set
            {
                m_objAAATest = value;
            }
        }
        
        public ECarotidArteryTestResult CardioTest
        {
            get
            {
                return m_objCardioTest;
            }
            set
            {
                m_objCardioTest = value;
            }
        }
        
        public EASITestResult ASITest
        {
            get
            {
                return m_objASITest;
            }
            set
            {
                m_objASITest = value;
            }
        }
        
        public EOsteoporosisTestResult OsteoporosisTest
        {
            get
            {
                return m_objOsteoporosisTest;
            }
            set
            {
                m_objOsteoporosisTest = value;
            }
        }
        
        public EPADTestResult PADTest
        {
            get
            {
                return m_objPADTest;
            }
            set
            {
                m_objPADTest = value;
            }
        }

        /// <summary>
        /// unique Package id
        /// </summary>
        public int PackageID
        {
            get
            {
                return m_iPackageID;
            }
            set
            {
                m_iPackageID = value;
            }
        }

        /// <summary>
        /// Package name
        /// </summary>        
        public string PackageName
        {
            get
            {
                return m_strPackageName;
            }
            set
            {
                m_strPackageName = value;
            }
        }

        /// <summary>
        /// Package description
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
        /// Package status
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
        /// min Package price
        /// </summary>        
        public float MinimumPackagePrice
        {
            get
            {
                return m_fMinimumPackagePrice;
            }
            set
            {
                m_fMinimumPackagePrice=value;
            }
        }

        /// <summary>
        /// Test object for mapping inventory item with Test
        /// </summary>        
        public List<ETest> Test
        {
            get { return m_objTest; }
            set { m_objTest = value; }
        }


        /// <summary>
        /// recommended Package price
        /// </summary>        
        public float RecommendedPrice
        {
            get
            {
                return m_fRecommendedPrice;
            }
            set
            {
                m_fRecommendedPrice = value;
            }
        }

        public decimal CostPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public int RelativeOrder
        {
            get { return m_iRelativeOrder; }
            set { m_iRelativeOrder = value; }
        }


    }
}
