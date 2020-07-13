        
using System;
using System.Collections.Generic;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{
    public class EAAATestResult
    {
        private int m_iAAATestID = 0;
        private int m_iEventCustomerID=0;
        private bool m_bolEvaluated = false;
        private float m_fArotaSize = 0;
        private List<string> m_strImages = null;
        private List<ETestParameter> m_objAAATestParameter = null;
        private ETestRecommendation m_objAAATestRecommendation = null;
        private ETest m_objTest = null;
        private int m_iEvaluationStatus=0;
        private List<EAAATestIncidentalFindings> m_objAAATestIncidentalFindings=null;
        private EAAATestFindings m_objAAATestFindings=null;
        private bool m_bolManual = true;
        private bool m_bolCritical = false;
        private List<Int64> m_objImageIDs = null;
        private bool? m_bolFusiForm = false;
        private bool? m_bolSaccular = false;
        private string m_strTechnicianNotes=string.Empty;
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
        /// Defines the criticality of the result
        /// </summary>        
        public bool? FusiForm
        {
            get { return m_bolFusiForm; }
            set { m_bolFusiForm = value; }
        }

        /// <summary>
        /// Defines the criticality of the result
        /// </summary>        
        public bool? Saccular
        {
            get { return m_bolSaccular; }
            set { m_bolSaccular = value; }
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
        /// EAAATestFindings object for mapping EAAATestResult with EAAATestFindings
        /// </summary>        
        public EAAATestFindings AAATestFindings
        {
            get { return m_objAAATestFindings; }
            set { m_objAAATestFindings = value; }
        }
	

        /// <summary>
        /// EAAATestIncidentalFindings object for mapping EAAATestResult with EAAATestIncidentalFindings
        /// </summary>        
        public List<EAAATestIncidentalFindings> AAATestIncidentalFindings
        {
            get { return m_objAAATestIncidentalFindings; }
            set { m_objAAATestIncidentalFindings = value; }
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
        public ETestRecommendation AAATestRecommendation
        {
            get { return m_objAAATestRecommendation; }
            set { m_objAAATestRecommendation = value; }
        }


        
        public List<string> TestImages
        {
            get { return m_strImages; }
            set { m_strImages = value; }
        }

        
        public int AAATestID
        {
            get
            {
                return m_iAAATestID;
            }
            set
            {
                m_iAAATestID = value;
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
        
        public float ArotaSize
        {
            get
            {
                return m_fArotaSize;
            }
            set
            {
                m_fArotaSize = value;
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

        /// <summary>
        /// 
        /// </summary>        
        public List<ETestParameter> AAATestParameter
        {
            get { return m_objAAATestParameter; }
            set { m_objAAATestParameter = value; }
        }

	
    }
}
