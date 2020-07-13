using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HcpCarotidTestResult : TestResult
    {
        public HcpCarotidTestReadings LeftResultReadings { get; set; }
        public HcpCarotidTestReadings RightResultReadings { get; set; }
        public List<ResultMedia> ResultImages { get; set; }
        public StandardFinding<int> LowVelocityLica { get; set; }
        public StandardFinding<int> LowVelocityRica { get; set; }
        public ResultReading<bool> VelocityElevatedOnRight { get; set; }
        public ResultReading<bool> VelocityElevatedOnLeft { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public HcpCarotidTestResult()
            : this(0)
        { }

        public HcpCarotidTestResult(long id)
            : base(id)
        { TestType = TestType.HCPCarotid; }
    }
}