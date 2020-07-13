using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public List<ResultMedia> ResultImages { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public AwvTestResult()
            : this(0)
        {}

        public AwvTestResult(long id)
            : base(id)
        { this.TestType = TestType.AWV; }
    }
}
