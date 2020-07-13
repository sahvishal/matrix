using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class DiabeticNeuropathyTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public ResultReading<decimal?> Amplitude { get; set; }

        public ResultReading<decimal?> ConductionVelocity { get; set; }

        public ResultReading<bool?> RightLeg { get; set; }
        public ResultReading<bool?> LeftLeg { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public DiabeticNeuropathyTestResult()
            : this(0)
        { }

        public DiabeticNeuropathyTestResult(long id)
            : base(id)
        { TestType = TestType.DiabeticNeuropathy; }
    }
}
