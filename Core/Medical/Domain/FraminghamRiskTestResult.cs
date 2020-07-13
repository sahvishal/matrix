using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class FraminghamRiskTestResult : TestResult
    {
        public ResultReading<int?> TotalCholestrol { get; set; }
        public ResultReading<int?> HDL { get; set; }
        public ResultReading<int?> LDL { get; set; }
        public ResultReading<bool?> Smoker { get; set; }
        public ResultReading<bool?> Diabetic { get; set; }
        public ResultReading<int?> Systolic { get; set; }
        public ResultReading<int?> Diastolic { get; set; }
        public ResultReading<int?> Age { get; set; }
        public ResultReading<Gender> Gender { get; set; }
        public ResultReading<decimal?> FraminghamRisk { get; set; }


        public FraminghamRiskTestResult()
            : this(0)
        { }

        public FraminghamRiskTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.FraminghamRisk;
        }
    }
}
