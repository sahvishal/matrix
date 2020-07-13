using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestResultStatusViewModel
    {
        public long TestId { get; set; }
        public string Label { get; set; }
        public string Alias { get; set; }
        public int ResultState { get; set; }
        public TestResultStateLabel State { get; set; }

        public string ConductedBy { get; set; }
        public string EvaluatedBy { get; set; }
        public bool IsPartial { get; set; }
        public bool IsCritical { get; set; }
        public long? TestInterpretation { get; set; }

        public bool CriticalMarkedByPhysician { get; set; }
        public string PhysicianRemarks { get; set; }

        public bool IsPriorityInQueue { get; set; }

    }
}