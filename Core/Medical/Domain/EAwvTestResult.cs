using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class EAwvTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public List<ResultMedia> ResultImages { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public EAwvTestResult()
            : this(0)
        {}

        public EAwvTestResult(long id)
            : base(id)
        { TestType = TestType.eAWV; }
    }
}
