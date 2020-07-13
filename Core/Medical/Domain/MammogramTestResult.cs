using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class MammogramTestResult:TestResult
    {
        public ResultMedia ResultImage { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public StandardFinding<int> Finding { get; set; }

        public MammogramTestResult()
            : this(0)
        { }

        public MammogramTestResult(long id)
            : base(id)
        { TestType = TestType.Mammogram; }
    }
}
