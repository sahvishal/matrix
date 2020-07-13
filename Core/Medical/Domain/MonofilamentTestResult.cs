using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class MonofilamentTestResult : TestResult
    {
        public ResultReading<bool?> RightPositive { get; set; }
        public ResultReading<bool?> RightNegative { get; set; }
        public ResultReading<bool?> LeftPositive { get; set; }
        public ResultReading<bool?> LeftNegative { get; set; }

        public MonofilamentTestResult() : this(0) { }

        public MonofilamentTestResult(long id)
            : base(id)
        {
            TestType = TestType.Monofilament;
        }
    }
}