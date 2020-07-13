using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class CustomerClinicalQuestionAnswer : DomainObjectBase
    {
        public string Guid { get; set; }
        public long ClinicalQuestionTemplateId { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public long ClinicalHealthQuestionId { get; set; }
        public string HealthQuestionAnswer { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public CustomerClinicalQuestionAnswer()
        { }

        public CustomerClinicalQuestionAnswer(long id)
            : base(id)
        { }
    }
}
