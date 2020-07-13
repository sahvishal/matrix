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
    public class CallRoundCallQueueRepository : PersistenceRepository, ICallRoundCallQueueRepository
    {
        public CallRoundCallQueue Save(CallRoundCallQueue callRoundCallQueueCustomer, bool refetch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallRoundCallQueue, CallRoundCallQueueEntity>(callRoundCallQueueCustomer);

                if (!adapter.SaveEntity(entity, refetch))
                {
                    throw new PersistenceFailureException();
                }

                return refetch ? Mapper.Map<CallRoundCallQueueEntity, CallRoundCallQueue>(entity) : callRoundCallQueueCustomer;
            }
        }
    }
}
