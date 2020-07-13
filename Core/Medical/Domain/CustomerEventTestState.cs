using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class CustomerEventTestState : DomainObjectBase
    {
        public long CustomerEventScreeningTestId { get; set; }
        public int EvaluationState { get; set; }
        public bool IsPartial { get; set; }
        public bool IsCritical { get; set; }
        public bool SelfPresent { get; set; }
        public bool IsTestNotPerformed { get; set; }
        public long? ConductedByOrgRoleUserId { get; set; }
        public long? EvaluatedByOrgRoleUserId { get; set; }
        public string TechnicianNotes { get; set; }
        public bool? IsNoteManualEntered { get; set; }
        public long? TestSummary { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
