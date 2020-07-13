using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class CholesterolTestResult : TestResult
    {
        public CompoundResultReading<string> TotalCholesterol { get; set; }
        public CompoundResultReading<string> HDL { get; set; }

        public CompoundResultReading<int?> LDL { get; set; }
        public CompoundResultReading<string> TriGlycerides { get; set; }
        public CompoundResultReading<decimal?> TCHDLRatio { get; set; }
        

        public CholesterolTestResult()
            : this(0)
        {

        }

        public CholesterolTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Cholesterol;
        }

    }
}
