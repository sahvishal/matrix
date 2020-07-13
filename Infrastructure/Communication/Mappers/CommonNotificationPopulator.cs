using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Communication.Mappers
{
    [DefaultImplementation(Interface = typeof(IPopulator<NotificationEntity, Notification>))]
    public class CommonNotificationPopulator : IPopulator<NotificationEntity, Notification>
    {
        private readonly INotificationMediumRepository _notificationMediumRepository;
        private readonly INotificationTypeRepository _notificationTypeRepository;

        public CommonNotificationPopulator(INotificationMediumRepository notificationMediumRepository,
            INotificationTypeRepository notificationTypeRepository)
        {
            _notificationMediumRepository = notificationMediumRepository;
            _notificationTypeRepository = notificationTypeRepository;
        }

        public void Populate(NotificationEntity source, Notification destination)
        {
            destination.AttemptCount = source.AttemptCount;
            destination.Source = source.ClientLabel;
            destination.DateCreated = source.DateCreated.GetValueOrDefault();
            destination.Notes = source.Notes;
            destination.NotificationDate = source.NotificationDate;
            destination.NotificationType = _notificationTypeRepository.GetById(source.NotificationTypeId);
            destination.NotificationMedium = _notificationMediumRepository.GetById(source.NotificationMediumId);
            destination.Priority = source.Priority;
            destination.RequestedBy = source.RequestedByOrgRoleUserId.HasValue ? source.RequestedByOrgRoleUserId.Value : 0;
            destination.ServicedDate = source.ServicedDate;
            destination.ServiceStatus = (NotificationServiceStatus)(source.ServiceStatus ?? (byte)NotificationServiceStatus.Unserviced);
            destination.UserId = source.UserId;
        }
    }
}