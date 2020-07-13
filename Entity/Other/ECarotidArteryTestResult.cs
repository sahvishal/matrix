       
using System;
using System.Collections.Generic;

namespace Falcon.Entity.Other
{
    
    public class ECarotidArteryTestResult
    {
        private int m_iCarotidArteryTestID = 0;
        private int m_iEventCustomerID = 0;
        private bool m_bolEvaluated = false;
        private decimal m_iRICAPSV = 0;
        private decimal m_iRICAEDV = 0;
        private decimal m_iLICAPSV = 0;
        private decimal m_iLICAEDV = 0;
        private decimal m_iLCCAPSV = 0;
        private decimal m_iRCCAPSV = 0;
        private List<ETestParameter> m_objCarotidTestParameter = null;
        private ETestRecommendation m_objCarotidTestRecommendation = null;
        private List<ECarotidArteryTestIncidentalFindings> m_objCATTestIncidentalFindings = null;
        private ECarotidArteryTestFindings m_objRightCATTestFindings = null;
        private bool m_bolManual = true;
        private bool m_bolCritical = true;
        private ECarotidArteryTestFindings m_objLeftCATTestFindings = null;
        private List<string> m_objTestImages = null;
        private List<Int64> m_objImageIDs = null;
        private string m_strTechnicianNotes = string.Empty;
        private bool m_bolUnableToScreen = false;
        private List<EUnableScreenReason> m_objListUnableScreenReason = null;

        public bool TestNotPerformed { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public List<string> ListThumbnailImages { get; set; }


        /// <summary>
        /// 
        /// </summary>        
        public bool? IsPartial { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public List<EUnableScreenReason> ListUnableScreenReason
        {
            get { return m_objListUnableScreenReason; }
            set { m_objListUnableScreenReason = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public bool UnableToScreen
        {
            get { return m_bolUnableToScreen; }
            set { m_bolUnableToScreen = value; }
        }


        /// <summary>
        /// Technician notes
        /// </summary>        
        public string TechnicianRemarks
        {
            get { return m_strTechnicianNotes; }
            set { m_strTechnicianNotes = value; }
        }


        /// <summary>
        /// 
        /// </summary>        
        public List<Int64> ImageIDs
        {
            get { return m_objImageIDs; }
            set { m_objImageIDs = value; }
        }
	

        /// <summary>
        /// 
        /// 
        /// </summary>        
        public List<string> TestImages
        {
            get { return m_objTestImages; }
            set { m_objTestImages = value; }
        }
	


        /// <summary>
        /// 
        /// </summary>        
        public ECarotidArteryTestFindings LeftCATTestFindings
        {
            get { return m_objLeftCATTestFindings; }
            set { m_objLeftCATTestFindings = value; }
        }
	

        /// <summary>
        /// Defines the criticality of the result
        /// </summary>        
        public bool Critical
        {
            get { return m_bolCritical; }
            set { m_bolCritical = value; }
        }


        /// <summary>
        /// manual entry status of the record
        /// </summary>        
        public bool Manual
        {
            get { return m_bolManual; }
            set { m_bolManual = value; }
        }

        /// <summary>
        /// ECarotidArteryTestFindings object for mapping ECarotidArteryTestResult with ECarotidArteryTestFindings
        /// </summary>        
        public ECarotidArteryTestFindings RightCATTestFindings
        {
            get { return m_objRightCATTestFindings; }
            set { m_objRightCATTestFindings = value; }
        }


        /// <summary>
        /// ECarotidArteryTestIncidentalFindings object for mapping ECarotidArteryTestResult with ECarotidArteryTestIncidentalFindings
        /// </summary>        
        public List<ECarotidArteryTestIncidentalFindings> CATTestIncidentalFindings
        {
            get { return m_objCATTestIncidentalFindings; }
            set { m_objCATTestIncidentalFindings = value; }
        }

        private int m_iEvaluationStatus = 0;

        
        public int EvaluationStatus
        {
            get { return m_iEvaluationStatus; }
            set { m_iEvaluationStatus = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public ETestRecommendation CarotidTestRecommendation
        {
            get { return m_objCarotidTestRecommendation; }
            set { m_objCarotidTestRecommendation = value; }
        }

        
        public int CarotidArteryTestID
        {
            get
            {
                return m_iCarotidArteryTestID;
            }
            set
            {
                m_iCarotidArteryTestID = value;
            }
        }

        
        public int CustomerEventTestID
        {
            get
            {
                return m_iEventCustomerID;
            }
            set
            {
                m_iEventCustomerID = value;
            }
        }

        
        public bool Evaluated
        {
            get
            {
                return m_bolEvaluated;
            }
            set
            {
                m_bolEvaluated = value;
            }
        }


        
        public decimal RICAPSV
        {
            get
            {
                return m_iRICAPSV;
            }
            set
            {
                m_iRICAPSV = value;
            }
        }
        
        public decimal RICAEDV
        {
            get
            {
                return m_iRICAEDV;
            }
            set
            {
                m_iRICAEDV = value;
            }
        }
        
        public decimal LICAPSV
        {
            get
            {
                return m_iLICAPSV;
            }
            set
            {
                m_iLICAPSV = value;
            }
        }
        
        public decimal LICAEDV
        {
            get
            {
                return m_iLICAEDV;
            }
            set
            {
                m_iLICAEDV = value;
            }
        }

        
        public decimal LCCAPSV
        {
            get
            {
                return m_iLCCAPSV;
            }
            set
            {
                m_iLCCAPSV = value;
            }
        }
        
        public decimal RCCAPSV
        {
            get
            {
                return m_iRCCAPSV;
            }
            set
            {
                m_iRCCAPSV = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public List<ETestParameter> CarotidTestParameter
        {
            get { return m_objCarotidTestParameter; }
            set { m_objCarotidTestParameter = value; }
        }
    }
}
