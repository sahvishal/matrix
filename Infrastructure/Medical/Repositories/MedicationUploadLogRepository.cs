using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class MedicationUploadLogRepository : PersistenceRepository, IMedicationUploadLogRepository
    {
        public MedicationUploadLog GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ul in linqMetaData.MedicationUploadLog where ul.Id == id select ul).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<MedicationUploadLog>(id);

                return AutoMapper.Mapper.Map<MedicationUploadLogEntity, MedicationUploadLog>(entity);
            }
        }

        public IEnumerable<MedicationUploadLog> GetByMedicationUploadId(long medicationUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ul in linqMetaData.MedicationUploadLog where ul.MedicationUploadId == medicationUploadId select ul);

                return AutoMapper.Mapper.Map<IEnumerable<MedicationUploadLogEntity>, IEnumerable<MedicationUploadLog>>(entities);
            }
        }

        public MedicationUploadLog SaveMedicationUploadLog(MedicationUploadLog domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<MedicationUploadLog, MedicationUploadLogEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Medication Upload ");

                return AutoMapper.Mapper.Map<MedicationUploadLogEntity, MedicationUploadLog>(entity);
            }
        }

        public void BulkSaveMedicationUploadLog(IEnumerable<MedicationUploadLog> domainObjectCollection)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityCollection = new EntityCollection<MedicationUploadLogEntity>();
                var mappedEntities = AutoMapper.Mapper.Map<IEnumerable<MedicationUploadLog>, IEnumerable<MedicationUploadLogEntity>>(domainObjectCollection);

                foreach (var entity in mappedEntities)
                {
                    entityCollection.Add(entity);
                }
                if (adapter.SaveEntityCollection(entityCollection) == 0)
                    throw new PersistenceFailureException("Could not save Medication Upload ");
                
                return;
            }
        }
    }
}
