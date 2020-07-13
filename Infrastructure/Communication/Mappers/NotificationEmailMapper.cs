using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<NotificationEmail, NotificationEmailEntity>))]
    public class NotificationEmailMapper : Mapper<NotificationEmail, NotificationEmailEntity>
    {
        public override NotificationEmail Map(NotificationEmailEntity objectToMap)
        {
            return new NotificationEmail(objectToMap.NotificationEmailId)
            {
                Body = objectToMap.Body,
                ToEmail = !string.IsNullOrWhiteSpace(objectToMap.ToEmail) ? new Email(objectToMap.ToEmail) : null,
                FromEmail = !string.IsNullOrWhiteSpace(objectToMap.FromEmail) ? new Email(objectToMap.FromEmail) : null,
                FromName = objectToMap.FromName,
                Subject = objectToMap.Subject,
                OpenedDate = objectToMap.OpenedDate,
                OpenCount = objectToMap.OpenCount.HasValue ? objectToMap.OpenCount.Value : 0,
                AttachmentPath = objectToMap.AttachmentPath
            };
        }

        public override NotificationEmailEntity Map(NotificationEmail objectToMap)
        {
            return new NotificationEmailEntity(objectToMap.Id)
            {
                Body = objectToMap.Body,
                ToEmail = objectToMap.ToEmail.ToString(),
                FromEmail = objectToMap.FromEmail.ToString(),
                FromName = objectToMap.FromName,
                Subject = objectToMap.Subject,
                OpenedDate = objectToMap.OpenedDate,
                OpenCount = objectToMap.OpenCount,
                AttachmentPath = objectToMap.AttachmentPath
            };
        }
    }
}