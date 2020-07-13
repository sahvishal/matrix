using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<EmailTemplate, EmailTemplateEntity>))]
    public class EmailTemplateMapper : Mapper<EmailTemplate, EmailTemplateEntity>
    {
        public override EmailTemplate Map(EmailTemplateEntity objectToMap)
        {
            return new EmailTemplate(objectToMap.EmailTemplateId)
                       {
                           Alias = objectToMap.EmailTitle,
                           Body = objectToMap.EmailBody,
                           DataRecorderMetaData =
                               new DataRecorderMetaData(null, objectToMap.DateCreated, objectToMap.DateModified)
                                   {
                                       DataRecorderModifier =
                                           objectToMap.ModifiedByOrgRoleUserId.HasValue
                                               ? new OrganizationRoleUser(objectToMap.ModifiedByOrgRoleUserId.Value)
                                               : null
                                   },
                           Subject = objectToMap.EmailSubject,
                           TemplateType = objectToMap.TemplateType,
                           NotificationTypeId = objectToMap.NotificationTypeId,
                           IsEditable = objectToMap.IsEditable,
                           CoverLetterTypeLookupId = objectToMap.CoverLetterTypeLookupId
                       };
        }

        public override EmailTemplateEntity Map(EmailTemplate objectToMap)
        {
            var entity = new EmailTemplateEntity((int)objectToMap.Id)
            {
                EmailTitle = objectToMap.Alias,
                EmailBody = objectToMap.Body,
                EmailSubject = objectToMap.Subject,
                NotificationTypeId = (int)objectToMap.NotificationTypeId,
                TemplateType = objectToMap.TemplateType,
                IsEditable = objectToMap.IsEditable,
                IsNew = objectToMap.Id == 0,
                CoverLetterTypeLookupId = objectToMap.CoverLetterTypeLookupId,
            };

            if (objectToMap.DataRecorderMetaData != null)
            {
                entity.ModifiedByOrgRoleUserId = objectToMap.DataRecorderMetaData.DataRecorderModifier == null ? null : (long?)objectToMap.DataRecorderMetaData.DataRecorderModifier.Id;
                entity.DateCreated = objectToMap.DataRecorderMetaData.DateCreated;
                entity.DateModified = objectToMap.DataRecorderMetaData.DateModified;
            }

            entity.Fields["CoverLetterTypeLookupId"].IsChanged = true;
            return entity;
        }
    }
}