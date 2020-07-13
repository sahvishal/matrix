using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class CheckListTemplateQuestion : DomainObjectBase
    {
        public long TemplateId { get; set; }
        public long QuestionId { get; set; }
        public long GroupQuestionId { get; set; }
    }
}