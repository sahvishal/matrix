using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class LipidTestResult : TestResult
    {
        public CompoundResultReading<string> TotalCholestrol { get; set; }
        public CompoundResultReading<string> HDL { get; set; }
        public CompoundResultReading<int?> Glucose { get; set; }
        public CompoundResultReading<int?> LDL { get; set; }
        public CompoundResultReading<string> TriGlycerides { get; set; }
        public CompoundResultReading<decimal?> TCHDLRatio { get; set; }
        public CompoundResultReading<int?> ALT { get; set; }
        public CompoundResultReading<int?> AST { get; set; }
        public ResultReading<decimal?> HbA1c { get; set; }
     
        public ResultReading<bool?> Smoker { get; set; }
        public ResultReading<bool?> Diabetic { get; set; }


        public LipidTestResult()
            : this(0)
        { }

        public LipidTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Lipid;
        }
    }
}
