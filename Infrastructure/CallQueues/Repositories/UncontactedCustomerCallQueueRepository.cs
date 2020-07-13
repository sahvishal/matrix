using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class UncontactedCustomerCallQueueRepository : PersistenceRepository, IUncontactedCustomerCallQueueRepository
    {
        public UncontactedCustomerCallQueue Save(UncontactedCustomerCallQueue uncontactedCustomerCallQueueCustomer, bool refetch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<UncontactedCustomerCallQueue, UncontactedCustomerCallQueueEntity>(uncontactedCustomerCallQueueCustomer);

                if (!adapter.SaveEntity(entity, refetch))
                {
                    throw new PersistenceFailureException();
                }

                return refetch ? Mapper.Map<UncontactedCustomerCallQueueEntity, UncontactedCustomerCallQueue>(entity) : uncontactedCustomerCallQueueCustomer;
            }
        }
    }
}
