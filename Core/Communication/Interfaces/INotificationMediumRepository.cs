using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface INotificationMediumRepository : IUniqueItemRepository<NotificationMedium>
    {
        IEnumerable<NotificationMedium> GetAll();
    }
}