using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ASITestResult : TestResult
    {
        public List<ResultReading<int>> RawASI { get; set; }
        public CompoundResultReading<int?> ASI { get; set; }
        public CardiovisionPressureReadings PressureReadings { get; set; }
        public ResultReading<string> Pattern { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }
        [IgnoreAudit]
        public int AverageASI
        {
            get { return (RawASI != null ? (int)RawASI.Select(asi => asi.Reading).Average() : 0); }
        }

        public ASITestResult()
            : this(0)
        {}

        public ASITestResult(long id)
            : base(id)
        { TestType = TestType.ASI; }

    }
}