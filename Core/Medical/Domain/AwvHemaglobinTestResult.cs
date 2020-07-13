using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvHemaglobinTestResult : TestResult
    {
        public ResultReading<string> Hba1c { get; set; }

        public AwvHemaglobinTestResult() : this(0) { }

        public AwvHemaglobinTestResult(long id)
            : base(id)
        {
            TestType = TestType.AwvHBA1C;
        }
    }
}
