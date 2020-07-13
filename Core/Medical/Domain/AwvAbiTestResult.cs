using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvAbiTestResult : TestResult
    {
        public PadTestReadings LeftResultReadings { get; set; }
        public PadTestReadings RightResultReadings { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public StandardFinding<decimal> Finding { get; set; }

        public AwvAbiTestResult()
            : this(0)
        {}

        public AwvAbiTestResult(long id)
            : base(id)
        { this.TestType = TestType.AwvABI; }
    }
}
