using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class PneumococcalTestResult : TestResult
    {
        public ResultReading<string> Manufacturer { get; set; }
        public ResultReading<string> LotNumber { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public PneumococcalTestResult()
            : this(0)
        { }

        public PneumococcalTestResult(long id)
            : base(id)
        { this.TestType = TestType.Pneumococcal; }
    }
}