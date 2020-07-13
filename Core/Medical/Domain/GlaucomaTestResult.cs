using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class GlaucomaTestResult : TestResult
    {
        public ResultReading<bool?> AmslerRightEye { get; set; }
        public ResultReading<bool?> AmslerLeftEye { get; set; }

        public ResultReading<int?> RightEyePressure { get; set; }
        public ResultReading<int?> LeftEyePressure { get; set; }
        public GlaucomaTestResult() : this(0) { }

        public GlaucomaTestResult(long id)
            : base(id)
        {
            TestType = TestType.Glaucoma;
        }
    }
}
