using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HemoglobinTestResult : TestResult
    {
        public CompoundResultReading<decimal?> Hemoglobin { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public HemoglobinTestResult()
            : this(0)
        { }

        public HemoglobinTestResult(long id)
            : base(id)
        { this.TestType = TestType.Hemoglobin; }
    }
}
