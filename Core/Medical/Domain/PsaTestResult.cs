using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class PsaTestResult : TestResult
    {
        public ResultReading<string> PSASCR { get; set; }

        public PsaTestResult() : this(0) { }

        public PsaTestResult(long id)
            : base(id)
        {
            TestType = TestType.Psa;
        }
    }
}
