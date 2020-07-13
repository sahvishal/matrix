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
    public class MailRoundCallQueueRepository : PersistenceRepository, IMailRoundCallQueueRepository
    {
        public MailRoundCallQueue Save(MailRoundCallQueue mailRoundCallQueueCustomer, bool refetch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<MailRoundCallQueue, MailRoundCallQueueEntity>(mailRoundCallQueueCustomer);

                if (!adapter.SaveEntity(entity, refetch))
                {
                    throw new PersistenceFailureException();
                }

                return refetch ? Mapper.Map<MailRoundCallQueueEntity, MailRoundCallQueue>(entity) : mailRoundCallQueueCustomer;
            }
        }
    }
}
