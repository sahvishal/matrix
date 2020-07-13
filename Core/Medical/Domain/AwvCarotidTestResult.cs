using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvCarotidTestResult : TestResult
    {
        public AwvCarotidTestReadings LeftResultReadings { get; set; }
        public AwvCarotidTestReadings RightResultReadings { get; set; }
        public List<ResultMedia> ResultImages { get; set; }
        public StandardFinding<int> LowVelocityLica { get; set; }
        public StandardFinding<int> LowVelocityRica { get; set; }
        
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public AwvCarotidTestResult()
            : this(0)
        { }

        public AwvCarotidTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.AwvCarotid;
        }
    }
}
