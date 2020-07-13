using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface IEmailTemplateFormatter
    {
        EmailMessage FormatMessage<T>(EmailTemplate template, T model, string toEmail, string fromEmail, string fromName, long emailTemplateId);

        string FormatContent<T>(string content, T model, long emailTemplateId);
        string FormatContent<T>(string content, T model);
        EmailMessage FormatMessage<T>(EmailTemplate template, T model, long emailTemplateId);
    }
}