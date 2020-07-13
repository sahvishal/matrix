using System.Collections.Generic;
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
    [DefaultImplementation(Interface = typeof(INotificationMediumRepository))]
    public class NotificationMediumRepository : UniqueItemRepository<NotificationMedium, NotificationMediumEntity>, INotificationMediumRepository
    {
        public NotificationMediumRepository(IMapper<NotificationMedium, NotificationMediumEntity> mapper) : base(mapper)
        {
        }

        protected override EntityField2 EntityIdField
        {
            get { return NotificationMediumFields.NotificationMediumId; }
        }

        public IEnumerable<NotificationMedium> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return Mapper.MapMultiple(linqMetaData.NotificationMedium);
            }
        }
    }
}