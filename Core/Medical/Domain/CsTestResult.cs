using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class CsTestResult : TestResult
    {
        public CsTestResult()
            : this(0)
        { }

        public CsTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Cs;
        }

        public ResultMedia ResultImage { get; set; }
    }
}
