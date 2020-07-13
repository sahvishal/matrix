using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class QuantaFloABITestResult : TestResult
    {
        public ResultMedia ResultImage { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }
        public StandardFinding<int> Finding { get; set; }

        public QuantaFloABITestResult()
            : this(0)
        { }

        public QuantaFloABITestResult(long id)
            : base(id)
        { this.TestType = TestType.QuantaFloABI; }
    }
}