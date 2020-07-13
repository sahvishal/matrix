using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventCustomerAdjustOrderLogRepository : PersistenceRepository, IEventCustomerAdjustOrderLogRepository
    {
        public EventCustomerAdjustOrderLog GetByEventCustomerIdUploadId(long eventCustomerId, long uploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ecaol in linqMetaData.EventCustomerAdjustOrderLog where ecaol.EventCustomerId == eventCustomerId && ecaol.UploadId == uploadId select ecaol).SingleOrDefault();

                return AutoMapper.Mapper.Map<EventCustomerAdjustOrderLogEntity, EventCustomerAdjustOrderLog>(entity);
            }
        }

        public void Save(EventCustomerAdjustOrderLog model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<EventCustomerAdjustOrderLog, EventCustomerAdjustOrderLogEntity>(model);
                var domain = GetByEventCustomerIdUploadId(model.EventCustomerId, model.UploadId);

                if (domain == null)
                {
                    if (!adapter.SaveEntity(entity))
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }

        public void Update(EventCustomerAdjustOrderLog model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<EventCustomerAdjustOrderLog, EventCustomerAdjustOrderLogEntity>(model);
                entity.IsNew = false;

                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<EventCustomerAdjustOrderLog> GetEventCustomerToAdjustOrder()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ecaol in linqMetaData.EventCustomerAdjustOrderLog where ecaol.StatusId == (long)AdjustOrderStatus.AdjustOrder select ecaol);

                return AutoMapper.Mapper.Map<IEnumerable<EventCustomerAdjustOrderLogEntity>, IEnumerable<EventCustomerAdjustOrderLog>>(entities);
            }
        }
        
    }


}