using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ChlamydiaTestResult : TestResult
    {

        public StandardFinding<int> Finding { get; set; }

        public ResultMedia ResultImage { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public ChlamydiaTestResult()
            : this(0)
        { }

        public ChlamydiaTestResult(long id)
            : base(id)
        { this.TestType = TestType.Chlamydia; }
    }
}
