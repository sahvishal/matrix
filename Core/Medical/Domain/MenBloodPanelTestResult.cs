using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class MenBloodPanelTestResult : TestResult
    {
        public ResultReading<string> PSASCR { get; set; }

        public ResultReading<string> LCRP { get; set; }

        public ResultReading<string> TESTSCRE { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public MenBloodPanelTestResult() : this(0) { }

        public MenBloodPanelTestResult(long id)
            : base(id)
        {
            TestType = TestType.MenBloodPanel;
        }
    }
}