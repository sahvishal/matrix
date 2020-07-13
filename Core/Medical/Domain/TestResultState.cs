using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestResultState : DomainObjectBase
    {
        public bool TestNotPerformed { get; set; }
        public bool SelfPresent { get; set; }
        public bool IsPriorityInQueue { get; set; }
        public TestResultStatus Status { get; set; }
        public int StateNumber { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public TestResultState()
        { }

        public TestResultState(long resultStateId)
            : base(resultStateId)
        { }
    }
}