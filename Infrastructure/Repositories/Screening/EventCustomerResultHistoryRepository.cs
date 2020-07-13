using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    [DefaultImplementation]
    public class EventCustomerResultHistoryRepository : PersistenceRepository, IEventCustomerResultHistoryRepository
    {

        public void Save(long eventCustomerResultId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (eventCustomerResultId > 0)
                {
                    var entity = (from ec in linqMetaData.EventCustomerResult
                                  where ec.EventCustomerResultId == eventCustomerResultId
                                  select ec).Single();

                    var historyEntity = Mapper.Map<EventCustomerResultEntity, EventCustomerResultHistoryEntity>(entity);

                    if (!adapter.SaveEntity(historyEntity, false))
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }
    }
}