using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Communication.Factories
{
    [DefaultImplementation]
    public class EmailTemplateEditModelFactory : IEmailTemplateEditModelFactory
    {
        private ITemplateMacroRepository _templateMacroRepository;
        private IEmailTemplateRepository _emailTemplateRepository;

        public EmailTemplateEditModelFactory(ITemplateMacroRepository templateMacroRepository, IEmailTemplateRepository emailTemplateRepository)
        {
            _templateMacroRepository = templateMacroRepository;
            _emailTemplateRepository = emailTemplateRepository;
        }

        public EmailTemplateEditModel Edit(EmailTemplate template)
        {
            var templateMacros = _templateMacroRepository.GetbyEmailTemplateId(template.Id);

            var model = new EmailTemplateEditModel
                            {
                                Id = template.Id,
                                Alias = template.Alias,
                                Body = ReplaceCodeStringwithMacros(template.Body, templateMacros),
                                Subject = template.Subject,
                                TemplateMacros = templateMacros.Select(tm => tm.IdentifierName).OrderBy(t => t),
                                TemplateType = template.TemplateType,
                                NotificationTypeId = template.NotificationTypeId,
                                IsEditable = template.IsEditable
                            };

            return model;
        }

        public EmailTemplateEditModel Complete(EmailTemplateEditModel model)
        {
            var templateMacros = _templateMacroRepository.GetbyEmailTemplateId(model.Id);
            model.TemplateMacros = templateMacros.Select(tm => tm.IdentifierName).OrderBy(t => t);

            return model;
        }

        public string ReplaceCodeStringwithMacros(string body, long id)
        {
            var templateMacros = _templateMacroRepository.GetbyEmailTemplateId(id);

            return ReplaceCodeStringwithMacros(body, templateMacros);
        }

        public string ReplaceCodeStringwithMacroParameterValue(string body, long id)
        {
            var templateMacros = _templateMacroRepository.GetbyEmailTemplateId(id);

            return ReplaceCodeStringwithMacroParameterValue(body, templateMacros, id);
        }

        private static string ReplaceCodeStringwithMacros(string body, IEnumerable<TemplateMacro> templateMacros)
        {
            return templateMacros.Aggregate(body, (current, templateMacro) => current.Replace(templateMacro.CodeString, templateMacro.IdentifierUiString));
        }

        private string ReplaceCodeStringwithMacroParameterValue(string body, IEnumerable<TemplateMacro> templateMacros, long emailTemplateId)
        {
            var emailTemplate = _emailTemplateRepository.GetById(emailTemplateId);
            var model = Edit(emailTemplate);

            return templateMacros.Where(tm => model.Body.ToLower().Contains(tm.IdentifierUiString.ToLower()) && !string.IsNullOrEmpty(tm.ParameterValue))
                .Aggregate(body, (current, templateMacro) => current.Replace(templateMacro.CodeString, templateMacro.ParameterValue));
        }

        public EmailTemplate Edit(EmailTemplateEditModel model, EmailTemplate inDb, long modifiedByOrgRoleUserId)
        {
            inDb.Body = ReplaceMacroswithCodeString(model.Body, model.Id);
            inDb.Subject = model.Subject;
            inDb.DataRecorderMetaData.DateModified = DateTime.Now;
            inDb.DataRecorderMetaData.DataRecorderModifier = modifiedByOrgRoleUserId > 0 ? new OrganizationRoleUser(modifiedByOrgRoleUserId) : null;
            return inDb;
        }

        public string ReplaceMacroswithCodeString(string body, long id)
        {
            var templateMacros = _templateMacroRepository.GetbyEmailTemplateId(id);

            return templateMacros.Aggregate(body, (current, templateMacro) => current.Replace(templateMacro.IdentifierUiString, templateMacro.CodeString));
        }

        public EmailTemplate Create(EmailTemplateEditModel model, long orgRoleUserId, IEnumerable<TemplateMacro> templateMacros)
        {
            var emailTemplate = new EmailTemplate
            {
                Body = templateMacros.Aggregate(model.Body, (current, templateMacro) => current.Replace(templateMacro.IdentifierUiString, templateMacro.CodeString)),
                Subject = model.Subject,
                DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(orgRoleUserId), DateTime.Now, null),
                Alias = model.Subject.Replace(" ", ""),
                TemplateType = model.TemplateType,
                NotificationTypeId = model.NotificationTypeId,
                IsEditable = true
            };

            return emailTemplate;
        }

    }
}