using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ImtTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }
        public ResultReading<int> VascularAge { get; set; }
        public ResultReading<int> QimtLeft { get; set; }
        public ResultReading<int> QimtRight { get; set; }
        public ResultReading<int> ExpectedQimt { get; set; }
        public IEnumerable<ResultMedia> ResultMedia { get; set; }

        public ImtTestResult()
            : this(0)
        {

        }

        public ImtTestResult(long id)
            : base(id)
        {
            TestType = TestType.IMT;
        }
    }
}