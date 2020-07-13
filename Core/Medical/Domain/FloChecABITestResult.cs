using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class FloChecABITestResult : TestResult
    {
        public ResultReading<bool> PencilDopplerUsed { get; set; }
        public FloChecABIReadings LeftResultReadings { get; set; }
        public FloChecABIReadings RightResultReadings { get; set; }

        public ResultMedia ResultImage { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }
        public StandardFinding<decimal> Finding { get; set; }

        public FloChecABITestResult()
            : this(0)
        { }

        public FloChecABITestResult(long id)
            : base(id)
        { this.TestType = TestType.FloChecABI; }
    }
}