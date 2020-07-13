using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class StrokeTestResult : TestResult
    {
        public StrokeTestReadings LeftResultReadings { get; set; }
        public StrokeTestReadings RightResultReadings { get; set; }
        public List<ResultMedia> ResultImages { get; set; }
        public StandardFinding<int> LowVelocityLica { get; set; }
        public StandardFinding<int> LowVelocityRica { get; set; }
        public ResultReading<bool> VelocityElevatedOnRight { get; set; }
        public ResultReading<bool> VelocityElevatedOnLeft { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public ResultReading<bool> ConsiderOtherModalities { get; set; }
        public ResultReading<bool> AdditionalImagesNeeded { get; set; }

        public StrokeTestResult()
            : this(0)
        { }

        public StrokeTestResult(long id)
            : base(id)
        { this.TestType = TestType.Stroke; }
    }
}