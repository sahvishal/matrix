using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class VwGetTestPerformedReport
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public DateTime EventDate { get; set; }
        public string Pod { get; set; }
        public long AccountId { get; set; }
        public bool IsHealthPlan { get; set; }

        public long CustomerEventTestStateId { get; set; }
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
        public bool IsPdfGenerated { get; set; }

        //[IgnoreAudit]
        //public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}