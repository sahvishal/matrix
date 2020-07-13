using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.Data.EntityClasses;
//using Falcon.Data.EntityClasses.NotificationEntity;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<Notification, NotificationEntity>))]
    public class NotificationMapper : Mapper<Notification, NotificationEntity>
    {
        private readonly INotificationMediumRepository _notificationMediumRepository;
        private readonly IPopulator<NotificationEntity, Notification> _notificationPopulator;
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public NotificationMapper(INotificationMediumRepository notificationMediumRepository,
            IPopulator<NotificationEntity, Notification> notificationPopulator, IPhoneNumberFactory phoneNumberFactory)
        {
            _notificationMediumRepository = notificationMediumRepository;
            _notificationPopulator = notificationPopulator;
            _phoneNumberFactory = phoneNumberFactory;
        }

        public override Notification Map(NotificationEntity objectToMap)
        {
            var notificationMedia = _notificationMediumRepository.GetAll().ToList();
            NotificationMedium notificationMedium = notificationMedia.FirstOrDefault(nm => nm.Id == objectToMap.NotificationMediumId);

            if (notificationMedium != null)
            {
                switch (notificationMedium.Medium)
                {
                    case NotificationMediumType.EmailNotification:
                        return MapNotificationEmail(objectToMap);
                    case NotificationMediumType.PhoneNotification:
                    case NotificationMediumType.SmsNotification:
                    case NotificationMediumType.FaxNotification:
                        return MapNotificationPhone(objectToMap);
                }
            }
            else
            {
                throw new NotSupportedException();
                // Log that the notification medium was not found...
            }
            var notification = new Notification(objectToMap.NotificationId);
            _notificationPopulator.Populate(objectToMap, notification);
            return notification;
        }

        private NotificationPhone MapNotificationPhone(NotificationEntity objectToMap)
        {
            var notificationPhone = new NotificationPhone(objectToMap.NotificationId);
            _notificationPopulator.Populate(objectToMap, notificationPhone);

            var entity = objectToMap.NotificationPhone;
            notificationPhone.Message = entity.Message;
            notificationPhone.PhoneCell = string.IsNullOrEmpty(entity.PhoneCell) ? null : _phoneNumberFactory.CreatePhoneNumber(entity.PhoneCell, PhoneNumberType.Mobile);
            // TODO: this does not truly belong here...
            notificationPhone.ServicedBy = entity.ServicedBy;

            return notificationPhone;
        }

        private NotificationEmail MapNotificationEmail(NotificationEntity objectToMap)
        {
            var notificationEmail = new NotificationEmail(objectToMap.NotificationId);
            _notificationPopulator.Populate(objectToMap, notificationEmail);

            NotificationEmailEntity notificationEmailEntity = objectToMap.NotificationEmail;
            notificationEmail.Body = notificationEmailEntity.Body;
            notificationEmail.FromName = notificationEmailEntity.FromName;
            try
            {
                notificationEmail.FromEmail = new Email(notificationEmailEntity.FromEmail);
            }
            catch
            {
                // no from email?
            }
            try
            {
                notificationEmail.ToEmail = new Email(notificationEmailEntity.ToEmail);
            }
            catch
            {
                // no to email?
            }
            notificationEmail.Subject = notificationEmailEntity.Subject;

            return notificationEmail;
        }

        public override NotificationEntity Map(Notification objectToMap)
        {
            return new NotificationEntity(objectToMap.Id)
            {
                AttemptCount = objectToMap.AttemptCount,
                DateCreated = objectToMap.DateCreated,
                Notes = objectToMap.Notes,
                NotificationMediumId = (int)objectToMap.NotificationMedium.Id,
                NotificationTypeId = (int)objectToMap.NotificationType.Id,
                UserId = objectToMap.UserId,
                ClientLabel = objectToMap.Source,
                Priority = objectToMap.Priority,
                ServiceStatus = (byte?)objectToMap.ServiceStatus,
                ServicedDate = objectToMap.ServicedDate,
                RequestedByOrgRoleUserId = objectToMap.RequestedBy,
                NotificationDate = objectToMap.NotificationDate,
                NotificationId = objectToMap.Id,
                IsNew = objectToMap.Id == 0
            };
        }
    }
}