using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class LiverTestResult : TestResult
    {
        public CompoundResultReading<int?> ALT { get; set; }
        public CompoundResultReading<int?> AST { get; set; }

        public LiverTestResult()
            : this(0)
        { }

        public LiverTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Liver;
        }
    }
}
