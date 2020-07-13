using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation(Interface = typeof(IResultArchiveUploadLogRepository))]
    public class ResultArchiveUploadLogRepository : PersistenceRepository, IResultArchiveUploadLogRepository
    {
        public ResultArchiveUploadLogRepository()
        {

        }

        public ResultArchiveLog Get(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ul in linqMetaData.ResultArchiveUploadLog where ul.ResultArchiveUploadLogId == id select ul).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<ResultArchiveLog>(id);

                return AutoMapper.Mapper.Map<ResultArchiveUploadLogEntity, ResultArchiveLog>(entity);
            }
        }


        public IEnumerable<ResultArchiveLog> GetbyResultArchiveId(long resultArchiveId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ul in linqMetaData.ResultArchiveUploadLog where ul.ResultArchiveUploadId == resultArchiveId select ul);

                if (entities.Count() < 1)
                    return null;

                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadLogEntity>, IEnumerable<ResultArchiveLog>>(entities);
            }
        }

        public IEnumerable<ResultArchiveLog> GetbyEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var uFileIds =
                    (from u in linqMetaData.ResultArchiveUpload where u.EventId == eventId select u.ResultArchiveUploadId).ToArray();

                var entities = (from ul in linqMetaData.ResultArchiveUploadLog where uFileIds.Contains(ul.ResultArchiveUploadId) select ul);

                if (entities.Count() < 1)
                    return null;

                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadLogEntity>, IEnumerable<ResultArchiveLog>>(entities);
            }
        }

        public ResultArchiveLog Save(ResultArchiveLog domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var loginDb =
                    linqMetaData.ResultArchiveUploadLog.Where(
                        rl =>
                        rl.CustomerId == domainObject.CustomerId && rl.TestId == (long) domainObject.TestId &&
                        rl.ResultArchiveUploadId == domainObject.ResultArchiveId).SingleOrDefault();

                if (loginDb != null) domainObject.Id = loginDb.ResultArchiveUploadLogId;

                var entity = AutoMapper.Mapper.Map<ResultArchiveLog, ResultArchiveUploadLogEntity>(domainObject);

                if(!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException(string.Format("Not Saved for Customer Id [{0}], Test Id [{1}]", domainObject.CustomerId, (long)domainObject.TestId));
                }

                return AutoMapper.Mapper.Map<ResultArchiveUploadLogEntity, ResultArchiveLog>(entity);
            }
        }

        public void Delete(ResultArchiveLog domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ResultArchiveLog> domainObjects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultArchiveLog> GetbyEventIdCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var uFileIds =
                    (from u in linqMetaData.ResultArchiveUpload where u.EventId == eventId select u.ResultArchiveUploadId).ToArray();

                var entities = (from ul in linqMetaData.ResultArchiveUploadLog where ul.CustomerId==customerId && uFileIds.Contains(ul.ResultArchiveUploadId) select ul);

                if (entities.Count() < 1)
                    return null;

                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadLogEntity>, IEnumerable<ResultArchiveLog>>(entities);
            }
        }
    }
}
