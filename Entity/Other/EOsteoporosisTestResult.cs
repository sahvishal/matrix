using System.Collections.Generic;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{  
    
    public class EOsteoporosisTestResult
    {
        private int m_iOsteoporosisTestID = 0;
        private int m_iEventCustomerID = 0;
        private bool m_bolEvaluated = false;
        private float m_fTScore = 0;
        private bool? m_bolTScoreRight = false;
        private List<ETestParameter> m_objOsteoporosisTestParameter = null;
        private ETestRecommendation m_objOsteoporosisTestRecommendation = null;
        private ETest m_objTest = null;
        private int m_iEvaluationStatus = 0;
        private List<EOsteoporisisTestIncidentalFindings> m_objOSTTestIncidentalFindings = null;
        private EOsteoporisisTestFindings m_objOSTTestFindings = null;
        private bool m_bolManual = true;
        private bool m_bolCritical = true;
        private string m_strTechnicianNotes = string.Empty;
        private bool m_bolUnableToScreen = false;
        private List<EUnableScreenReason> m_objListUnableScreenReason = null;

        public float? LeftHeel { get; set; }
        public float? RightHeel { get; set; }
        public bool TestNotPerformed { get; set; }

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
        /// EOsteoporisisTestFindings object for mapping EOsteoporosisTestResult with EOsteoporisisTestFindings
        /// </summary>
        
        public EOsteoporisisTestFindings OsteoTestFindings
        {
            get { return m_objOSTTestFindings; }
            set { m_objOSTTestFindings = value; }
        }


        /// <summary>
        /// EOsteoporisisTestIncidentalFindings object for mapping EOsteoporosisTestResult with EOsteoporisisTestIncidentalFindings
        /// </summary>
        
        public List<EOsteoporisisTestIncidentalFindings> OsteoTestIncidentalFindings
        {
            get { return m_objOSTTestIncidentalFindings; }
            set { m_objOSTTestIncidentalFindings = value; }
        }

        
        public int EvaluationStatus
        {
            get { return m_iEvaluationStatus; }
            set { m_iEvaluationStatus = value; }
        }

        
        public ETest Test
        {
            get
            {
                return m_objTest;
            }
            set
            {
                m_objTest = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        public ETestRecommendation OsteoporosisTestRecommendation
        {
            get { return m_objOsteoporosisTestRecommendation; }
            set { m_objOsteoporosisTestRecommendation = value; }
        }  

        
        public int OsteoporosisTestID
        {
            get
            {
                return m_iOsteoporosisTestID;
            }
            set
            {
                m_iOsteoporosisTestID = value;
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

        
        public float TScore
        {
            get
            {
                return m_fTScore;
            }
            set
            {
                m_fTScore = value;
            }
        }

        
        public bool? TScoreRight
        {
            get
            {
                return m_bolTScoreRight;
            }
            set
            {
                m_bolTScoreRight = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public List<ETestParameter> OsteoporosisTestParameter
        {
            get { return m_objOsteoporosisTestParameter; }
            set { m_objOsteoporosisTestParameter = value; }
        }
    }
}
