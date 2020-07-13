using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class OsteoporosisTestResult : TestResult
    {
        public CompoundResultReading<decimal?> EstimatedTScore { get; set; }
        public ResultReading<decimal?> RightHeelTScore { get; set; }
        public ResultReading<decimal?> LeftHeelTScore { get; set; }
        public ResultMedia ResultImage { get; set; }
        public OsteoporosisTestResult()
            : this(0)
        {}

        public OsteoporosisTestResult(long id)
            : base(id)
        { this.TestType = TestType.Osteoporosis; }
    }
}