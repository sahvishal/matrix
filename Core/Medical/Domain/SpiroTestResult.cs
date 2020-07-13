using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class SpiroTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public ResultMedia ResultImage { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public ResultReading<bool> PoorEffort { get; set; }
        public ResultReading<bool> Restrictive { get; set; }
        public ResultReading<bool> Obstructive { get; set; }

        public SpiroTestResult()
            : this(0)
        {}

        public SpiroTestResult(long id)
            : base(id)
        { this.TestType = TestType.Spiro; }
    }
}
