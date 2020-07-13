using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<NotificationType, NotificationTypeEntity>))]
    public class NotificationTypeMapper : Mapper<NotificationType, NotificationTypeEntity>
    {
        private readonly INotificationMediumRepository _notificationMediumRepository;

        //private readonly IEnumerable<NotificationMedium> _notificationMedia;
        public NotificationTypeMapper(INotificationMediumRepository notificationMediumRepository)
        {
            _notificationMediumRepository = notificationMediumRepository;
           // _notificationMedia = notificationMediumRepository.GetAll().ToList();
        }

        public override NotificationType Map(NotificationTypeEntity objectToMap)
        {
            var notificationMedia = _notificationMediumRepository.GetAll().ToList();
            NotificationMedium notificationMedium = notificationMedia.FirstOrDefault(nm => nm.Id == objectToMap.NotificationMediumId);
            return new NotificationType(objectToMap.NotificationTypeId)
                       {
                           DataRecorderMetaData =
                               new DataRecorderMetaData(0, objectToMap.DateCreated, objectToMap.DateModified)
                                   {
                                       DataRecorderModifier =
                                           objectToMap.ModifiedByOrgRoleUserId != null
                                               ? new OrganizationRoleUser(objectToMap.ModifiedByOrgRoleUserId.Value)
                                               : null
                                   },
                           Description = objectToMap.Description,
                           IsServiceEnabled = objectToMap.IsServiceEnabled,
                           IsQueuingEnabled = objectToMap.IsQueuingEnabled,
                           NotificationTypeAlias = objectToMap.NotificationTypeNameAlias,
                           NotificationTypeName = objectToMap.NotificationTypeName,
                           NumberOfAttempts = objectToMap.NoOfAttempts,
                           IsActive = objectToMap.IsActive,
                           NotificationMedium = notificationMedium,
                           AllowTemplateCreation =objectToMap.AllowTemplateCreation
                       };
        }

        public override NotificationTypeEntity Map(NotificationType objectToMap)
        {
            return new NotificationTypeEntity
            {
                NotificationTypeId = (int)objectToMap.Id,
                DateCreated = objectToMap.DataRecorderMetaData.DateCreated,
                DateModified = objectToMap.DataRecorderMetaData.DateModified,
                ModifiedByOrgRoleUserId = objectToMap.DataRecorderMetaData.DataRecorderModifier != null ? (long?)objectToMap.DataRecorderMetaData.DataRecorderModifier.Id : null,
                Description = objectToMap.Description,
                IsServiceEnabled = objectToMap.IsServiceEnabled,
                IsQueuingEnabled = objectToMap.IsQueuingEnabled,
                NotificationTypeNameAlias = objectToMap.NotificationTypeAlias,
                NotificationTypeName = objectToMap.NotificationTypeName,
                NoOfAttempts = objectToMap.NumberOfAttempts,
                IsActive = objectToMap.IsActive,
                IsNew = objectToMap.Id == 0,
                NotificationMediumId = (int)objectToMap.NotificationMedium.Id,
                AllowTemplateCreation = objectToMap.AllowTemplateCreation
            };
        }
    }
}