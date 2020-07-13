using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class FocAttestationTestResult : TestResult
    {
        public ResultMedia ResultImage { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public FocAttestationTestResult()
            : this(0)
        { }

        public FocAttestationTestResult(long id)
            : base(id)
        { TestType = TestType.FocAttestation; }
    }
}