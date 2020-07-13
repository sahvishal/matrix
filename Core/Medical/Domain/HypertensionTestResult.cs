using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HypertensionTestResult : TestResult
    {

        public ResultReading<int?> Systolic { get; set; }
        public ResultReading<int?> Diastolic { get; set; }
        public ResultReading<int?> Pulse { get; set; }
        public ResultReading<bool> RightArmBpMeasurement { get; set; }
        public ResultReading<bool> BloodPressureElevated { get; set; }
        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public HypertensionTestResult()
            : this(0)
        { }

        public HypertensionTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Hypertension;
        }
    }
}