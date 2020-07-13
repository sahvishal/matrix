using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestosteroneTestResult : TestResult
    {
        public ResultReading<string> TESTSCRE { get; set; }

        public TestosteroneTestResult() : this(0) { }

        public TestosteroneTestResult(long id)
            : base(id)
        {
            TestType = TestType.Testosterone;
        }
    }
}
