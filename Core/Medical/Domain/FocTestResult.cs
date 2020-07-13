using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class FocTestResult : TestResult
    {
        public FocTestResult()
            : this(0)
        { }

        public FocTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Foc;
        }

        public ResultMedia ResultImage { get; set; }
    }
}
