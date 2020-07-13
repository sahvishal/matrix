using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.ViewModels;

namespace Falcon.App.Core.Communication
{
    public interface IEmailTemplateService
    {
        EmailTemplateEditModel GetModel(long id);
        EmailTemplateEditModel Save(EmailTemplateEditModel model, long orgRoleUserId);
        bool IsEmailTemplateValid(long emailTemplateId, string body,long notificationTypeId);
        EmailTemplateEditModel CompleteModel(EmailTemplateEditModel model);

        string ReplaceMacroswithCodeString(string body, long emailTemplateId);

      //  string ReplaceCodeStringwithMacroParameterValue(string body, long emailTemplateId);

        EmailTemplateEditModel SaveNewTemplate(EmailTemplateEditModel model, long orgRoleUserId);
        EmailTemplateEditModel CreateNewTemplate(long notificationtypeId);
        IEnumerable<TemplateMacro> GetMacrosForNotificationTypeId(long notificationTypeId);
        string ReplaceCodeStringwithMacroParameterValueForNotificationTypeId(string body, long notificationTypeId);
        string LoadTemplate(string emailTemplateAlias, long notificationTypeId, string body = null);
    }
}