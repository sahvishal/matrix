using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class PADTestResult : TestResult
    {
        public ResultReading<bool> PencilDopplerUsed { get; set; }
        public PadTestReadings LeftResultReadings { get; set; }
        public PadTestReadings RightResultReadings { get; set; }
        public CardiovisionPressureReadings PressureReadings { get; set; }
        public ResultReading<int?> SystolicHighestArm { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public StandardFinding<decimal> Finding { get; set; }

        public PADTestResult()
            : this(0)
        {}

        public PADTestResult(long id)
            : base(id)
        { this.TestType = TestType.PAD; }
    }
}