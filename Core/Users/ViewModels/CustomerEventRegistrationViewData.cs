using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CustomerEventRegistrationViewData : EventCustomerViewData
    {
        public string HostOrganizationName { get; set; }

        public decimal SourceCodeDiscount { get { return SourceCodeAmount; } }
        public string FranchiseeName { get; set; }

        //public TestResultStateNumber? AAATestEvaluationState { get; set; }
        //public TestResultStateNumber? ASITestEvaluationState { get; set; }
        //public TestResultStateNumber? CarotidTestEvaluationState { get; set; }
        //public TestResultStateNumber? OsteoTestEvaluationState { get; set; }
        //public TestResultStateNumber? PADTestEvaluationState { get; set; }
        //public TestResultStateNumber? EKGTestEvaluationState { get; set; }
        //public TestResultStateNumber? LipidTestEvaluationState { get; set; }
        //public TestResultStateNumber? LiverTestEvaluationState { get; set; }
        //public TestResultStateNumber? FraminghamTestEvaluationState { get; set; }

        //public bool IsAAAPartial { get; set; }
        //public bool IsASIPartial { get; set; }
        //public bool IsCarotidPartial { get; set; }
        //public bool IsOsteoPartial { get; set; }
        //public bool IsPADPartial { get; set; }
        //public bool IsEKGPartial { get; set; }
        //public bool IsLipidPartial { get; set; }
        //public bool IsLiverPartial { get; set; }
        //public bool IsFraminghamPartial { get; set; }

    }
}