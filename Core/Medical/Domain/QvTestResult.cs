using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class QvTestResult : TestResult
    {
        public QvTestResult()
            : this(0)
        { }

        public QvTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.Qv;
        }

        public ResultMedia ResultImage { get; set; }
    }
}
