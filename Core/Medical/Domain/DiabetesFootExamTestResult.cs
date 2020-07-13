using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class DiabetesFootExamTestResult : TestResult
    {
        public ResultReading<bool?> RightFootYes { get; set; }
        public ResultReading<bool?> RightFootNo { get; set; }
        public ResultReading<bool?> LeftFootYes { get; set; }
        public ResultReading<bool?> LeftFootNo { get; set; }

        public DiabetesFootExamTestResult() : this(0) { }

        public DiabetesFootExamTestResult(long id)
            : base(id)
        {
            TestType = TestType.DiabetesFootExam;
        }
    }
}