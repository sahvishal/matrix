using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface IEmailTemplateRepository : IUniqueItemRepository<EmailTemplate>
    {
        EmailTemplate GetByAlias(string alias);
        IEnumerable<EmailTemplate> GetAll();
        IEnumerable<EmailTemplate> GetEmailTemplatesByNotificationAlias(string notificationTypeAlias, long coverLetterType);
        IEnumerable<EmailTemplate> GetEmailTemplates(string subject, long templateTypeId, long coverLetterTypeId);
    }
}