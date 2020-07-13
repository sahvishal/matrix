using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ClinicalTestQualificationCriteria : DomainObjectBase
    {
        public Gender Gender { get; set; }
        public int? NumberOfQuestion { get; set; }
        public string Answer { get; set; }
        public bool? OnMedication { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public long? AgeCondition { get; set; }
        public long TemplateId { get; set; }
        public long TestId { get; set; }
        public bool IsPublished { get; set; }
        public long? MedicationQuestionId { get; set; }
        public long? DisqualifierQuestionId { get; set; }
        public string DisqualifierQuestionAnswer { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
