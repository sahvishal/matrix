using System.Collections.Generic;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{
    public class EASITestResult
    {
        private int m_iASITestID = 0;
        private int m_iEventCustomerID = 0;
        private bool m_bolEvaluated = false;
        private int m_iSystolicBP = 0;
        private int m_iDiastolicBP = 0;
        private int m_iPulsePressure = 0;
        private int m_iASI = 0;
        private string m_strPattern=string.Empty;
        private List<ETestParameter> m_objASITestParameter = null;
        private ETestRecommendation m_objASITestRecommendation = null;
        private ETest m_objTest = null;
        private int m_iEvaluationStatus = 0;
        private List<EASITestIncidentalFindings> m_objASITestIncidentalFindings = null;
        private EASITestFindings m_objASITestFindings=null;
        private bool m_bolManual = true;
        private bool m_bolCritical = true;
        private int m_iPulse = 0;
        private string m_strTechnicianNotes = string.Empty;
        private bool m_bolUnableToScreen = false;
        private List<EUnableScreenReason> m_objListUnableScreenReason = null;

        public bool TestNotPerformed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> ASIRawReadingList { get; set; }


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
        public int Pulse
        {
            get { return m_iPulse; }
            set { m_iPulse = value; }
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
        /// EASITestFindings object for mapping EASITestResult with EASITestFindings
        /// </summary>        
        public EASITestFindings ASITestFindings
        {
            get { return m_objASITestFindings; }
            set { m_objASITestFindings = value; }
        }


        /// <summary>
        /// EASITestIncidentalFindings object for mapping EASITestResult with EASITestIncidentalFindings
        /// </summary>        
        public List<EASITestIncidentalFindings> ASITestIncidentalFindings
        {
            get { return m_objASITestIncidentalFindings; }
            set { m_objASITestIncidentalFindings = value; }
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
        public ETestRecommendation ASITestRecommendation
        {
            get { return m_objASITestRecommendation; }
            set { m_objASITestRecommendation = value; }
        }
        
        public int ASITestID
        {
            get
            {
                return m_iASITestID;
            }
            set
            {
                m_iASITestID = value;
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
        
        public int SystolicBP
        {
            get
            {
                return m_iSystolicBP;
            }
            set
            {
                m_iSystolicBP = value;
            }
        }
        
        public int DiastolicBP
        {
            get
            {
                return m_iDiastolicBP;
            }
            set
            {
                m_iDiastolicBP = value;
            }
        }
        
        public int PulsePressure
        {
            get
            {
                return m_iPulsePressure;
            }
            set
            {
                m_iPulsePressure = value;
            }
        }
        
        public int ASI
        {
            get
            {
                return m_iASI;
            }
            set
            {
                m_iASI = value;
            }
        }
        
        public string Pattern
        {
            get
            {
                return m_strPattern;
            }
            set
            {
                m_strPattern = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        public List<ETestParameter> ASITestParameter
        {
            get { return m_objASITestParameter; }
            set { m_objASITestParameter = value; }
        }
    }
}
