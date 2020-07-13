using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PreQualificationTemplateQuestion : DomainObjectBase
    {
        public long QuestionId { get; set; }
        public long TemplateId { get; set; }

    }
}
