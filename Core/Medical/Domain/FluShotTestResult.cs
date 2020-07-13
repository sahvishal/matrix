using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class FluShotTestResult : TestResult
    {
        public ResultReading<string> Manufacturer { get; set; }
        public ResultReading<string> LotNumber { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public FluShotTestResult()
            : this(0)
        { }

        public FluShotTestResult(long id)
            : base(id)
        { this.TestType = TestType.FluShot; }
    }
}