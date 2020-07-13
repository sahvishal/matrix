         
using System;
using Falcon.App.Core.Enum;

namespace Falcon.Entity.Other
{   
    
    public class ETestRecommendation
    {
        private EETest m_enTest = EETest.Abdominal_Aortic_Aneurysm;
        private Int64 m_lngTestRecommendationID = 0;
        private Int64 m_lngTestResultID = 0;
        private Boolean m_bolRoutineFollowUp;
        private Boolean m_bolSeePhysicanForFurtherEvaluation;
        private Boolean m_bolImmediateFollowupWithPhysician;
        private string m_strPhysicianRemarks = string.Empty;
        //private string m_strTechnicianRemarks = string.Empty;
        private Int16 m_enRiskEvaluation;
        private bool m_bCriticalSelf = false;
        private bool m_bCriticalImmediately = false;

        /// <summary>
        /// 
        /// </summary>
        
        public bool CriticalImmediately
        {
            get { return m_bCriticalImmediately; }
            set { m_bCriticalImmediately = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        
        public bool CriticalSelf
        {
            get { return m_bCriticalSelf; }
            set { m_bCriticalSelf = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public EETest Test
        {
            get { return m_enTest; }
            set { m_enTest = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Int64 TestRecommendationID
        {
            get { return m_lngTestRecommendationID; }
            set { m_lngTestRecommendationID = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Int64 TestResultID
        {
            get { return m_lngTestResultID; }
            set { m_lngTestResultID = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Boolean RoutineFollowUp
        {
            get { return m_bolRoutineFollowUp; }
            set { m_bolRoutineFollowUp = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Boolean SeePhysicanForFurtherEvaluation
        {
            get { return m_bolSeePhysicanForFurtherEvaluation; }
            set { m_bolSeePhysicanForFurtherEvaluation = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public Boolean ImmediateFollowupWithPhysician
        {
            get { return m_bolImmediateFollowupWithPhysician; }
            set { m_bolImmediateFollowupWithPhysician = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string PhysicianRemarks
        {
            get { return m_strPhysicianRemarks; }
            set { m_strPhysicianRemarks = value; }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //
        //public string TechnicianRemarks
        //{
        //    get { return m_strTechnicianRemarks; }
        //    set { m_strTechnicianRemarks = value; }
        //}
        
        /// <summary>
        /// 
        /// </summary>
        
        public Int16 RiskEvaluation
        {
            get { return m_enRiskEvaluation; }
            set { m_enRiskEvaluation = value; }
        }


	

    }
}
