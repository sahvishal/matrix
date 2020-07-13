using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class Phq9TestResult : TestResult
    {
        public ResultReading<string> Phq9Score { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public Phq9TestResult() : this(0) { }

        public Phq9TestResult(long id)
            : base(id)
        {
            TestType = TestType.PHQ9;
        }
    }
}