using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class DiabetesTestResult : TestResult
    {
        public CompoundResultReading<int?> Glucose { get; set; }

        public DiabetesTestResult()
            : this(0)
        { }

        public DiabetesTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Diabetes;
        }
    }
}