using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class CallUploadLogRepository : PersistenceRepository, ICallUploadLogRepository
    {

        public CallUploadLog GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ul in linqMetaData.CallUploadLog where ul.Id == id select ul).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<CallUploadLog>(id);

                return AutoMapper.Mapper.Map<CallUploadLogEntity, CallUploadLog>(entity);
            }
        }
        public IEnumerable<CallUploadLog> GetByCallUploadId(long callUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ul in linqMetaData.CallUploadLog where ul.CallUploadId == callUploadId select ul);

                return AutoMapper.Mapper.Map<IEnumerable<CallUploadLogEntity>, IEnumerable<CallUploadLog>>(entities);
            }
        }

        public CallUploadLog SaveCallUploadLog(CallUploadLog domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<CallUploadLog, CallUploadLogEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Call Upload ");

                return AutoMapper.Mapper.Map<CallUploadLogEntity, CallUploadLog>(entity);
            }
        }

        public IEnumerable<CallUploadLog> GetCustomerForApplyRule(string outReachType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ul in linqMetaData.CallUploadLog where ul.OutreachType == outReachType && ul.IsSuccessFull == true && ul.IsRuleApplied == false select ul);

                return AutoMapper.Mapper.Map<IEnumerable<CallUploadLogEntity>, IEnumerable<CallUploadLog>>(entities);
            }
        }
    }
}
