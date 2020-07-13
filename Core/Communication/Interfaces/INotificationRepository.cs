using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface INotificationRepository : IUniqueItemRepository<Notification>
    {
        IEnumerable<Notification> GetNotificationsAfter(DateTime inclusiveStartTime);
        IEnumerable<Notification> GetNotificationsToService(long[] mediumIds);
        NotificationEmail GetEmailNotificationById(long id);
        void SaveProspectCustomerNotification(long prospectCustomerId, long notificationId);

        IEnumerable<Notification> GetFaxNotificationByNotificationTypeId(long mediumId, long notificationTypeId);
        Notification GetLatestNotificationByPhone(string phoneNumber);
    }
}