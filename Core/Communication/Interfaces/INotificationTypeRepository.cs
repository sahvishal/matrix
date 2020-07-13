using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.ViewModels;

namespace Falcon.App.Core.Communication.Interfaces
{

    public interface INotificationTypeRepository : IUniqueItemRepository<NotificationType>
    {
        IEnumerable<NotificationType> GetAll();
        NotificationType GetByAlias(string notificationTypeAlias);
        IEnumerable<NotificationType> GetbyFilter(NotificationTypeListFilter filter, int pageNumber, int pageSize, out int totalRecords);
        NotificationType GetByNotificationId(long id);
        void UpdateNotificationData(long notificationId, bool isServicingEnabled, bool isQueuingEnabled, int numberOfAttempts, long updatedByOrgRoleUserId);
        IEnumerable<NotificationType> GetNotificationTypeForTemplate();

    }
}