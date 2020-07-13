using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class WomenBloodPanelTestResult : TestResult
    {
        public ResultReading<string> LCRP { get; set; }

        public ResultReading<string> TSHSCR { get; set; }

        public ResultReading<string> VitD { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }

        public ResultReading<bool> RepeatStudy { get; set; }

        public WomenBloodPanelTestResult() : this(0) { }

        public WomenBloodPanelTestResult(long id)
            : base(id)
        {
            TestType = TestType.WomenBloodPanel;
        }
    }
}