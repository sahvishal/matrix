using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ThyroidTestResult : TestResult
    {
        public ResultReading<string> TSHSCR { get; set; }

        public IEnumerable<ResultMedia> ResultMedia { get; set; }

        public ThyroidTestResult()
            : this(0)
        { }

        public ThyroidTestResult(long id)
            : base(id)
        {
            TestType = TestType.Thyroid;
        }
    }
}