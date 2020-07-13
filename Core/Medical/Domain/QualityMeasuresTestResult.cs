using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class QualityMeasuresTestResult : TestResult
    {
        public StandardFinding<int> FunctionalAssessmentScore { get; set; }
        public StandardFinding<int> PainAssessmentScore { get; set; }
        
        public ResultReading<int?> MemoryRecallScore { get; set; }
        public ResultReading<bool> ClockPass { get; set; }
        public ResultReading<bool> ClockFail { get; set; }
        public ResultReading<bool> GaitPass { get; set; }
        public ResultReading<bool> GaitFail { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public QualityMeasuresTestResult()
            : this(0)
        {

        }

        public QualityMeasuresTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.QualityMeasures;
        }
    }
}