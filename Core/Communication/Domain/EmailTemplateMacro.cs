using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class EmailTemplateMacro : DomainObjectBase
    {
        public EmailTemplateMacro()
        { }

        public EmailTemplateMacro(long emailTemplateId)
            : base(emailTemplateId)
        { }

        public int EmailTemplateId { get; set; }
        public long TemplateMacroId { get; set; }
        public int Sequence { get; set; }
        public string ParameterValue { get; set; }
    }
}