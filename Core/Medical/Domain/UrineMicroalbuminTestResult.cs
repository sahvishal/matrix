using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class UrineMicroalbuminTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }
        public ResultMedia ResultImage { get; set; }
        public ResultReading<string> SerialKey { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }
        public ResultReading<string> MicroalbuminValue { get; set; }
 
        public UrineMicroalbuminTestResult()
            : this(0)
        { }

        public UrineMicroalbuminTestResult(long id)
            : base(id)
        { TestType = TestType.UrineMicroalbumin; }
    }
}
