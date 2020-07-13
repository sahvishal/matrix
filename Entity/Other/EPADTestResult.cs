using System.Collections.Generic;
using Falcon.Entity.Franchisor;

namespace Falcon.Entity.Other
{   
    
    public class EPADTestResult
    {
        private int m_iPADTestID = 0;
        private int m_iEventCustomerID = 0;
        private bool m_bolEvaluated = false;
        private float m_fLeftABI = 0;
        private float m_fRightABI = 0;
        private int m_iSystolicRArm = 0;
        private int m_iSystolicRAnkle = 0;
        private int m_iSystolicLArm = 0;
        private int m_iSystolicLAnkle = 0;
        private int m_iSystolicBP = 0;
        private int m_iDiastolicBP = 0;
        private int m_iPulsePressure = 0;
        private int m_iPulse = 0;
        private List<ETestParameter> m_objPADTestParameter = null;
        private ETestRecommendation m_objPADTestRecommendation = null;
        private ETest m_objTest = null;
        private int m_iEvaluationStatus = 0;

        private List<EPADTestIncidentalFindings> m_objPADTestIncidentalFindings = null;
        private EPADTestFindings m_objPADTestFindings = null;
        private bool m_bolManual = true;
        private bool m_bolCritical = true;
        private string m_strTechnicianNotes = string.Empty;
        private bool m_bolUnableToScreen = false;
        private List<EUnableScreenReason> m_objListUnableScreenReason = null;

        
        public bool? PencilDopplerUsed { get; set; }
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
        /// EPADTestFindings object for mapping EPADTestResult with EPADTestFindings
        /// </summary>
        
        public EPADTestFindings PADTestFindings
        {
            get { return m_objPADTestFindings; }
            set { m_objPADTestFindings = value; }
        }


        /// <summary>
        /// EPADTestIncidentalFindings object for mapping EPADTestResult with EPADTestIncidentalFindings
        /// </summary>
        
        public List<EPADTestIncidentalFindings> PADTestIncidentalFindings
        {
            get { return m_objPADTestIncidentalFindings; }
            set { m_objPADTestIncidentalFindings = value; }
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
        
        public ETestRecommendation PADTestRecommendation
        {
            get { return m_objPADTestRecommendation; }
            set { m_objPADTestRecommendation = value; }
        }  

        
        public int PADTestID
        {
            get
            {
                return m_iPADTestID;
            }
            set
            {
                m_iPADTestID = value;
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

        
        public float LeftABI
        {
            get
            {
                return m_fLeftABI;
            }
            set
            {
                m_fLeftABI = value;
            }
        }

        
        public float RightABI
        {
            get
            {
                return m_fRightABI;
            }
            set
            {
                m_fRightABI = value;
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

        
        public int SystolicRArm
        {
            get
            {
                return m_iSystolicRArm;
            }
            set
            {
                m_iSystolicRArm = value;
            }
        }

        
        public int SystolicRAnkle
        {
            get
            {
                return m_iSystolicRAnkle;
            }
            set
            {
                m_iSystolicRAnkle = value;
            }
        }

        
        public int SystolicLArm
        {
            get
            {
                return m_iSystolicLArm;
            }
            set
            {
                m_iSystolicLArm = value;
            }
        }

        
        public int SystolicLAnkle
        {
            get
            {
                return m_iSystolicLAnkle;
            }
            set
            {
                m_iSystolicLAnkle = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public List<ETestParameter> PADTestParameter
        {
            get { return m_objPADTestParameter; }
            set { m_objPADTestParameter = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
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

        /// <summary>
        /// 
        /// </summary>
        
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

        /// <summary>
        /// 
        /// </summary>
        
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


        /// <summary>
        /// 
        /// </summary>
        
        public int Pulse
        {
            get { return m_iPulse; }
            set { m_iPulse = value; }
        }

    }
}
