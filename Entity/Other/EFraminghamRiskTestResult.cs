namespace Falcon.Entity.Other
{
    public class EFraminghamRiskTestResult
    {
        
        public bool? IsPartial { get; set; }

        
        public long LipidTestId
        {
            get;
            set;
        }

        
        public long EventCustomerId
        {
            get;
            set;
        }

        
        public bool TestEvaluated
        {
            get;
            set;
        }

        
        public int EvaluationStatus
        {
            get;
            set;
        }

        
        public string TestUpdatedBy
        {
            get;
            set;
        }

        
        public bool UnableToScreen
        {
            get;
            set;
        }

        
        public string TechnicianRemarks
        {
            get;
            set;
        }
    }
}
