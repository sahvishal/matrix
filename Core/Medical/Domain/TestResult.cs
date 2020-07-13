using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestResult : DomainObjectBase
    {
        public TestType TestType { get; set; }

        public TestResultState ResultStatus { get; set; }
        public List<UnableScreenReason> UnableScreenReason { get; set; }
        public List<IncidentalFinding> IncidentalFindings { get; set; }

        public PhysicianInterpretation PhysicianInterpretation { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long ConductedByOrgRoleUserId { get; set; }
        public long EvaluatedbyOrgRoleUserId { get; set; }

        public string TechnicianNotes { get; set; }
        public ReadingSource TechNotesSource { get; set; }
        public long? ResultInterpretation { get; set; }
        public long? PathwayRecommendation { get; set; }
        public TestNotPerformed TestNotPerformed { get; set; }
        public bool IsRetest { get; set; }
        public bool IsNewResultFlow { get; set; }

        public TestPerformedExternally TestPerformedExternally { get; set; }
       

        public TestResult()
        { }

        public TestResult(TestType testType)
        {
            TestType = testType;
        }

        public TestResult(TestType testType, long testResultId)
            : base(testResultId)
        {
            TestType = testType;
        }

        protected TestResult(long testResultId)
            : base(testResultId)
        { }

        public object Cast<T1>()
        {
            throw new System.NotImplementedException();
        }
    }
}