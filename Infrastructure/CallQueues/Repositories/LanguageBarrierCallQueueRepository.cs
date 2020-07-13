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
    public class LanguageBarrierCallQueueRepository : PersistenceRepository, ILanguageBarrierCallQueueRepository
    {
        public LanguageBarrierCallQueue Save(LanguageBarrierCallQueue languageBarrierCallQueueCustomer, bool refetch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<LanguageBarrierCallQueue, LanguageBarrierCallQueueEntity>(languageBarrierCallQueueCustomer);

                if (!adapter.SaveEntity(entity, refetch))
                {
                    throw new PersistenceFailureException();
                }

                return refetch ? Mapper.Map<LanguageBarrierCallQueueEntity, LanguageBarrierCallQueue>(entity) : languageBarrierCallQueueCustomer;
            }
        }
    }
}
