using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class PulmonaryFunctionTestResult : TestResult
    {
        public StandardFinding<int> Finding { get; set; }

        public ResultMedia ResultImage { get; set; }
        
        public PulmonaryFunctionTestResult()
            : this(0)
        {

        }

        public PulmonaryFunctionTestResult(long id)
            : base(id)
        {
            TestType = TestType.PulmonaryFunction;
        }
    }
}