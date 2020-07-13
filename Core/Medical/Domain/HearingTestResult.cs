using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HearingTestResult : TestResult
    {
        public ResultReading<bool?> HearingSummary { get; set; }

        public ResultReading<int?> RightEar500Hz { get; set; }
        public ResultReading<int?> LeftEar500Hz { get; set; }
        public ResultReading<int?> RightEar1000Hz { get; set; }
        public ResultReading<int?> LeftEar1000Hz { get; set; }
        public ResultReading<int?> RightEar2000Hz { get; set; }
        public ResultReading<int?> LeftEar2000Hz { get; set; }
        public ResultReading<int?> RightEar3000Hz { get; set; }
        public ResultReading<int?> LeftEar3000Hz { get; set; }
        public ResultReading<int?> RightEar4000Hz { get; set; }
        public ResultReading<int?> LeftEar4000Hz { get; set; }
        public ResultReading<int?> RightEar6000Hz { get; set; }
        public ResultReading<int?> LeftEar6000Hz { get; set; }
        public ResultReading<int?> RightEar8000Hz { get; set; }
        public ResultReading<int?> LeftEar8000Hz { get; set; }

        public HearingTestResult() : this(0) { }

        public HearingTestResult(long id)
            : base(id)
        {
            TestType = TestType.Hearing;
        }
    }
}
