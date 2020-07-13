using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PreQualificationTemplateDependentTest : DomainObjectBase
    {
        public long TemplateId { get; set; }
        public long TestId { get; set; }
        public bool IsActive { get; set; }
    }
}
