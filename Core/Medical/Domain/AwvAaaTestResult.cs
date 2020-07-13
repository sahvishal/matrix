using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvAaaTestResult : TestResult
    {
        public ResultReading<decimal?> AortaSize { get; set; }

        public ResultReading<bool> AorticDissection { get; set; }
        public ResultReading<bool> Plaque { get; set; }
        public ResultReading<bool> Thrombus { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public StandardFinding<decimal?> Finding { get; set; }

        public List<StandardFinding<int>> AortaRangeSaggitalView { get; set; }

        public OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>> TransverseView { get; set; }
        public List<StandardFinding<int>> AortaRangeTransverseView { get; set; }

        public ResultReading<decimal?> PeakSystolicVelocity { get; set; }
        public List<StandardFinding<int>> PeakSystolicVelocityStandardFindings { get; set; }

        public OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>> ResidualLumenStandardFindings { get; set; }

        public List<ResultMedia> ResultImages { get; set; }

        public AwvAaaTestResult()
            : this(0)
        { }

        public AwvAaaTestResult(long id)
            : base(id)
        { TestType = TestType.AwvAAA; }
    }
}
