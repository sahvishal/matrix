using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvBoneMassTestResult : TestResult
    {
        public CompoundResultReading<decimal?> EstimatedTScore { get; set; }

        public ResultMedia ResultImage { get; set; }

        public AwvBoneMassTestResult()
            : this(0)
        {}

        public AwvBoneMassTestResult(long id)
            : base(id)
        { this.TestType = TestType.AwvBoneMass; }
    }
}
