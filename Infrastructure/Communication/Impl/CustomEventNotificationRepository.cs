using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class CustomEventNotificationRepository : PersistenceRepository, ICustomEventNotificationRepository
    {
        public IEnumerable<CustomEventNotification> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from cen in linqMetaData.CustomEventNotification where cen.EventId == eventId select cen);

                return Mapper.Map<IEnumerable<CustomEventNotificationEntity>, IEnumerable<CustomEventNotification>>(enetities);
            }
        }

        public IEnumerable<CustomEventNotification> GetNotificationByStatus(long serviceStatus)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from cen in linqMetaData.CustomEventNotification where cen.ServiceStatus == serviceStatus select cen);

                return Mapper.Map<IEnumerable<CustomEventNotificationEntity>, IEnumerable<CustomEventNotification>>(enetities);
            }
        }

        public bool SaveNotification(CustomEventNotification notification)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomEventNotification, CustomEventNotificationEntity>(notification);

                adapter.SaveEntity(entity, true);
            }

            return true;
        }
    }
}
