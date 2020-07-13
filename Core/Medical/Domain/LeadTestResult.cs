using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class LeadTestResult : TestResult
    {
        public LeadTestReadings LeftResultReadings { get; set; }
        public LeadTestReadings RightResultReadings { get; set; }
        public List<ResultMedia> ResultImages { get; set; }
        public StandardFinding<int> LowVelocityLeft { get; set; }
        public StandardFinding<int> LowVelocityRight { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public ResultReading<string> DiagnosisCode { get; set; }

        public LeadTestResult()
            : this(0)
        { }

        public LeadTestResult(long id)
            : base(id)
        { this.TestType = TestType.Lead; }
    }
}
