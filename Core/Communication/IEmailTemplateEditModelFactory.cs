using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.ViewModels;

namespace Falcon.App.Core.Communication
{
    public interface IEmailTemplateEditModelFactory
    {
        EmailTemplateEditModel Edit(EmailTemplate template);
        string ReplaceCodeStringwithMacros(string body, long id);
        EmailTemplate Edit(EmailTemplateEditModel model, EmailTemplate inDb, long modifiedByOrgRoleUserId);
        string ReplaceMacroswithCodeString(string body, long id);

        EmailTemplateEditModel Complete(EmailTemplateEditModel model);
        string ReplaceCodeStringwithMacroParameterValue(string body, long id);
        EmailTemplate Create(EmailTemplateEditModel model, long orgRoleUserId, IEnumerable<TemplateMacro> templateMacros);
    }
}