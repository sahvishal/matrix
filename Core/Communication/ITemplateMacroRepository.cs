using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface ITemplateMacroRepository
    {
        IEnumerable<TemplateMacro> GetbyEmailTemplateId(long emailTemplateId);
        IEnumerable<TemplateMacro> GetbyEmailTemplateNotificationTypeId(long notificationTypeId);
    }
}