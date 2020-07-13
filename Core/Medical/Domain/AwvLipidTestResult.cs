using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvLipidTestResult : TestResult
    {
        public CompoundResultReading<string> TotalCholestrol { get; set; }
        public CompoundResultReading<string> HDL { get; set; }
        
        public CompoundResultReading<int?> LDL { get; set; }
        public CompoundResultReading<string> TriGlycerides { get; set; }
        public CompoundResultReading<decimal?> TCHDLRatio { get; set; }
        

        public AwvLipidTestResult()
            : this(0)
        { }

        public AwvLipidTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.AwvLipid;
        }
    }
}
