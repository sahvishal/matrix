using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HPyloriTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public HPyloriTestResult()
            : this(0)
        { }

        public HPyloriTestResult(long id)
            : base(id)
        { this.TestType = TestType.HPylori; }
    }
}