using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class CrpTestResult : TestResult
    {
        public ResultReading<string> LCRP { get; set; }

        public CrpTestResult() : this(0) { }

        public CrpTestResult(long id)
            : base(id)
        {
            TestType = TestType.Crp;
        }
    }
}
