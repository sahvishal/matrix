using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation(Interface = typeof(IEmailTemplateRepository))]
    public class EmailTemplateRepository : UniqueItemRepository<EmailTemplate, EmailTemplateEntity>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(IPersistenceLayer persistenceLayer, IMapper<EmailTemplate, EmailTemplateEntity> mapper)
            : base(persistenceLayer, mapper, new RepositoryStrategySet<EmailTemplate>())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return EmailTemplateFields.EmailTemplateId; }
        }

        public EmailTemplate GetByAlias(string alias)
        {
            using (var context = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(context);
                EmailTemplateEntity emailTemplateEntity = linqMetaData.EmailTemplate.Single(et => et.EmailTitle == alias);
                return Mapper.Map(emailTemplateEntity);
            }
        }

        public IEnumerable<EmailTemplate> GetAll()
        {
            using (var context = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(context);
                var entities = (from et in linqMetaData.EmailTemplate select et).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EmailTemplate> GetEmailTemplatesByNotificationAlias(string notificationTypeAlias, long coverLetterType)
        {
            using (var context = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(context);
                var entities = (from et in linqMetaData.EmailTemplate
                                join nt in linqMetaData.NotificationType on et.NotificationTypeId equals nt.NotificationTypeId
                                where nt.NotificationTypeNameAlias == notificationTypeAlias
                                select et);
                if (coverLetterType > 0)
                    entities = entities.Where(x => x.CoverLetterTypeLookupId.HasValue && x.CoverLetterTypeLookupId == coverLetterType);

                return Mapper.MapMultiple(entities.ToArray());
            }
        }

        public IEnumerable<EmailTemplate> GetEmailTemplates(string subject, long templateTypeId, long coverLetterTypeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from et in linqMetaData.EmailTemplate where et.IsEditable select et);

                if (!string.IsNullOrEmpty(subject))
                    query = query.Where(q => q.EmailSubject.Contains(subject));
                if (templateTypeId > 0)
                    query = query.Where(q => q.TemplateType == templateTypeId);
                if (coverLetterTypeId > 0)
                    query = query.Where(q => q.CoverLetterTypeLookupId.HasValue && q.CoverLetterTypeLookupId == coverLetterTypeId);

                return Mapper.MapMultiple(query.ToArray());
            }
        }
    }
}