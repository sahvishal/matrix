using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation(Interface = typeof(INotificationSubscriberRepository))]
    public class NotificationSubscriberRepository : UniqueItemRepository<NotificationSubscriber, NotificationSubscribersEntity>, INotificationSubscriberRepository
    {
        public NotificationSubscriberRepository(IMapper<NotificationSubscriber, NotificationSubscribersEntity> mapper) : base(mapper)
        { }

        public IEnumerable<NotificationSubscriber> GetForNotificationType(long notificationTypeId)
        {
            
            using (var context = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(context);
                var subscribers = linqMetaData.NotificationSubscribers.Where(ns => ns.IsActive && ns.NotificationTypeId == notificationTypeId);
                return Mapper.MapMultiple(subscribers);
            }
        }

        protected override EntityField2 EntityIdField
        {
            get { return NotificationSubscribersFields.NotificationSubscriberId; }
        }
    }
}