using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class RinneWeberHearingTestResult : TestResult
    {
        public ResultReading<bool?> WeberNormal { get; set; }
        public ResultReading<bool?> WeberAbnormal { get; set; }
        public ResultReading<bool?> RinneNormal { get; set; }
        public ResultReading<bool?> RinneAbnormal { get; set; }

        public RinneWeberHearingTestResult() : this(0) { }

        public RinneWeberHearingTestResult(long id)
            : base(id)
        {
            TestType = TestType.RinneWeberHearing;
        }
    }
}