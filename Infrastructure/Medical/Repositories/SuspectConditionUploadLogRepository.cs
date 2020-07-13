using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class SuspectConditionUploadLogRepository : PersistenceRepository, ISuspectConditionUploadLogRepository
    {
        public SuspectConditionUploadLog GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from scul in linqMetaData.SuspectConditionUploadLog where scul.Id == id select scul).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<SuspectConditionUploadLog>(id);

                return AutoMapper.Mapper.Map<SuspectConditionUploadLogEntity, SuspectConditionUploadLog>(entity);
            }
        }

        public IEnumerable<SuspectConditionUploadLog> GetBySuspectConditionUploadId(long suspectConditionUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from scul in linqMetaData.SuspectConditionUploadLog where scul.SuspectConditionUploadId == suspectConditionUploadId select scul);

                return AutoMapper.Mapper.Map<IEnumerable<SuspectConditionUploadLogEntity>, IEnumerable<SuspectConditionUploadLog>>(entities);
            }
        }

        public SuspectConditionUploadLog SaveSuspectConditionUploadLog(SuspectConditionUploadLog domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<SuspectConditionUploadLog, SuspectConditionUploadLogEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Suspect Condition Upload ");

                return AutoMapper.Mapper.Map<SuspectConditionUploadLogEntity, SuspectConditionUploadLog>(entity);
            }
        }

        public void BulkSaveSuspectConditionUploadLog(IEnumerable<SuspectConditionUploadLog> domainObjectCollection)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityCollection = new EntityCollection<SuspectConditionUploadLogEntity>();
                var mappedEntities = AutoMapper.Mapper.Map<IEnumerable<SuspectConditionUploadLog>, IEnumerable<SuspectConditionUploadLogEntity>>(domainObjectCollection);

                foreach (var entity in mappedEntities)
                {
                    entityCollection.Add(entity);
                }
                if (adapter.SaveEntityCollection(entityCollection) == 0)
                    throw new PersistenceFailureException("Could not save Suspect Condition Upload ");

                return;
            }
        }

        public int GetUploadFailedCount(long suspectConditionUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.SuspectConditionUploadLog.Where(x => x.SuspectConditionUploadId == suspectConditionUploadId && !x.IsSuccessFull).Count();
            }
        }
    }
}
