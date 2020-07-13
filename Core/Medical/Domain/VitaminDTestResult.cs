using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class VitaminDTestResult : TestResult
    {
        public ResultReading<string> VitD { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public VitaminDTestResult() : this(0) { }

        public VitaminDTestResult(long id)
            : base(id)
        {
            TestType = TestType.VitaminD;
        }
    }
}