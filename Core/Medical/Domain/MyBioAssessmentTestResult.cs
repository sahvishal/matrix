using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class MyBioAssessmentTestResult : TestResult
    {
        public CompoundResultReading<string> TotalCholestrol { get; set; }
        public CompoundResultReading<string> Hdl { get; set; }
        public CompoundResultReading<int?> Glucose { get; set; }
        public CompoundResultReading<int?> Ldl { get; set; }
        public CompoundResultReading<string> TriGlycerides { get; set; }
        public CompoundResultReading<decimal?> TcHdlRatio { get; set; }

        public ResultMedia ResultImage { get; set; }

        public MyBioAssessmentTestResult()
            : this(0)
        { }

        public MyBioAssessmentTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.MyBioCheckAssessment;
        }
    }
}