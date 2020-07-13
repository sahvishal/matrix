using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvFluShotTestResult : TestResult
    {
        public ResultReading<string> Manufacturer { get; set; }
        public ResultReading<string> LotNumber { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public AwvFluShotTestResult()
            : this(0)
        { }

        public AwvFluShotTestResult(long id)
            : base(id)
        { this.TestType = TestType.AwvFluShot; }
    }
}