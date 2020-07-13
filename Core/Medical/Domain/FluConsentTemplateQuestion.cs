using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class FluConsentTemplateQuestion : DomainObjectBase
    {
        public long TemplateId { get; set; }
        
        public long QuestionId { get; set; }
    }
}
