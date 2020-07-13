using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<NotificationMedium, NotificationMediumEntity>))]
    public class NotificationMediumMapper : Mapper<NotificationMedium, NotificationMediumEntity>
    {
        public override NotificationMedium Map(NotificationMediumEntity objectToMap)
        {
            return new NotificationMedium(objectToMap.NotificationMediumId)
            {
                DateCreated = objectToMap.DateCreated,
                DateModified = objectToMap.DateModified,
                Description = objectToMap.Description,
                Medium = objectToMap.NotificationMedium
            };
        }

        public override NotificationMediumEntity Map(NotificationMedium objectToMap)
        {
            return new NotificationMediumEntity((int) objectToMap.Id)
            {
                DateCreated = objectToMap.DateCreated,
                DateModified = objectToMap.DateModified,
                Description = objectToMap.Description,
                NotificationMedium = objectToMap.Medium,
                IsNew = objectToMap.Id == 0
            };
        }
    }
}