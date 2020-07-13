using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class EmailTemplate : DomainObjectBase
    {
        public EmailTemplate()
        { }

        public EmailTemplate(long emailTemplateId)
            : base(emailTemplateId)
        { }

        public string Alias { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long TemplateType { get; set; }
        public long NotificationTypeId { get; set; }
        public bool IsEditable { get; set; }
        public long? CoverLetterTypeLookupId { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}