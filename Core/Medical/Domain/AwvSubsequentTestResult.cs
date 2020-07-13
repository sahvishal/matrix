using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvSubsequentTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }
        public List<ResultMedia> ResultImages { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public AwvSubsequentTestResult()
            : this(0)
        {}

        public AwvSubsequentTestResult(long id)
            : base(id)
        { this.TestType = TestType.AwvSubsequent; }
    }
}
