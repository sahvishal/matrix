using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class RapsUploadLogRepository : PersistenceRepository, IRapsUploadLogRepository
    {
        public RapsUploadLog GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ul in linqMetaData.RapsUploadLog where ul.Id == id select ul).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<RapsUploadLog>(id);

                return AutoMapper.Mapper.Map<RapsUploadLogEntity, RapsUploadLog>(entity);
            }
        }

        public IEnumerable<RapsUploadLog> GetByRapsUploadId(long rapsUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ul in linqMetaData.RapsUploadLog where ul.RapsUploadId == rapsUploadId select ul);

                return AutoMapper.Mapper.Map<IEnumerable<RapsUploadLogEntity>, IEnumerable<RapsUploadLog>>(entities);
            }
        }

        public RapsUploadLog SaveRapsUploadLog(RapsUploadLog domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<RapsUploadLog, RapsUploadLogEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Raps Upload ");

                return AutoMapper.Mapper.Map<RapsUploadLogEntity, RapsUploadLog>(entity);
            }
        }
    }
}
