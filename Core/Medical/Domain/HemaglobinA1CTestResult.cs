using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HemaglobinA1CTestResult : TestResult
    {
        public ResultReading<string> Hba1c { get; set; }

        public HemaglobinA1CTestResult() : this(0) { }

        public HemaglobinA1CTestResult(long id) : base(id)
        {
            TestType = TestType.A1C;
        }
    }
}