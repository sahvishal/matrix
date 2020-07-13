using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvGlucoseTestResult : TestResult
    {
        public CompoundResultReading<int?> Glucose { get; set; }

        public AwvGlucoseTestResult()
            : this(0)
        { }

        public AwvGlucoseTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.AwvGlucose;
        }
    }
}
