using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation]
    public class CustomerUnsubscribedSmsNotificationRepository : PersistenceRepository,  ICustomerUnsubscribedSmsNotificationRepository
    {
        public void SaveUnsubscribedSmsStatus(CustomerUnsubscribedSmsNotification smsReceived)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerUnsubscribedSmsNotification, CustomerUnsubscribedSmsNotificationEntity>(smsReceived);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<CustomerUnsubscribedSmsNotification> GetSmsReceived(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cusn in linqMetaData.CustomerUnsubscribedSmsNotification where cusn.CustomerId == customerId select cusn).ToArray();

                return Mapper.Map<IEnumerable<CustomerUnsubscribedSmsNotificationEntity>, IEnumerable<CustomerUnsubscribedSmsNotification>>(entities);
            }
        }
    }
}