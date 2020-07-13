using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class IFOBTTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public ResultReading<string> SerialKey { get; set; }

        public ResultMedia ResultImage { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public IFOBTTestResult()
            : this(0)
        { }

        public IFOBTTestResult(long id)
            : base(id)
        { this.TestType = TestType.IFOBT; }
    }
}
