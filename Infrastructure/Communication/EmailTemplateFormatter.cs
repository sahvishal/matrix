using System.Collections.Generic;
using System.Dynamic;
using System.Web.Routing;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;

namespace Falcon.App.Infrastructure.Communication
{
    [DefaultImplementation(Interface = typeof(IEmailTemplateFormatter))]
    public class EmailTemplateFormatter : IEmailTemplateFormatter
    {
        private readonly IEmailTemplateEditModelFactory _emailTemplateEditModelFactory;

        public EmailTemplateFormatter(IEmailTemplateEditModelFactory emailTemplateEditModelFactory)
        {
            _emailTemplateEditModelFactory = emailTemplateEditModelFactory;
        }

        public static ExpandoObject ToExpando(object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = new RouteValueDictionary(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }

        public EmailMessage FormatMessage<T>(EmailTemplate template, T model, string toEmail, string fromEmail, string fromName, long emailTemplateId)
        {
            //dynamic expandoModel = ToExpando(model);

            string bodyText = FormatContent(template.Body, model, emailTemplateId);
            string subjectText = FormatContent(template.Subject, model, emailTemplateId);

            return new EmailMessage
            {
                Body = bodyText,
                Subject = subjectText,
                ToEmail = toEmail,
                FromEmail = fromEmail,
                FromName = fromName
            };
        }

        public EmailMessage FormatMessage<T>(EmailTemplate template, T model, long emailTemplateId)
        {
            //dynamic expandoModel = ToExpando(model);

            string bodyText = FormatContent(template.Body, model, emailTemplateId);
            string subjectText = FormatContent(template.Subject, model, emailTemplateId);

            return new EmailMessage
            {
                Body = bodyText,
                Subject = subjectText
            };
        }

        public string FormatContent<T>(string content, T model, long emailTemplateId)
        {
            content = ReplaceCodeStringwithMacroParameterValue(content, emailTemplateId);
            return FormatContent(content, model);
        }

        public string FormatContent<T>(string content, T model)
        {
            return RazorEngine.Razor.Parse(content, model);
        }

        public string ReplaceCodeStringwithMacroParameterValue(string body, long emailTemplateId)
        {
            return _emailTemplateEditModelFactory.ReplaceCodeStringwithMacroParameterValue(body, emailTemplateId);
        }
    }
}