using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.CallCenter.ViewModels;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{

    [DefaultImplementation]
    public class CallUploadRepository : PersistenceRepository, ICallUploadRepository
    {
        public CallUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from cu in linqMetaData.CallUpload where cu.Id == id select cu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<CallUpload>(id);

                return AutoMapper.Mapper.Map<CallUploadEntity, CallUpload>(entity);
            }
        }

        public CallUpload Save(CallUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<CallUpload, CallUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Call Upload ");

                return AutoMapper.Mapper.Map<CallUploadEntity, CallUpload>(entity);
            }
        }

        public IEnumerable<CallUpload> GetFilesToParse()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cu in linqMetaData.CallUpload where cu.StatusId == (long)CallUploadStatus.Uploaded select cu);

                return AutoMapper.Mapper.Map<IEnumerable<CallUploadEntity>, IEnumerable<CallUpload>>(entities);
            }
        }

        public IEnumerable<CallUpload> GetByFilter(int pageNumber, int pageSize, CallUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.CallUpload.Count();

                    var entities = linqMetaData.CallUpload.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return AutoMapper.Mapper.Map<IEnumerable<CallUploadEntity>, IEnumerable<CallUpload>>(entities);
                }
                else
                {
                    var query = (from c in linqMetaData.CallUpload select c);

                    if (filter.FromUploadDate != null)
                    {
                        query = (from c in query
                                 where c.UploadTime.Date >= filter.FromUploadDate.Value.Date
                                 select c);
                    }
                    if (filter.ToUploadDate != null)
                    {
                        query = (from c in query
                                 where c.UploadTime.Date <= filter.ToUploadDate.Value.Date
                                 select c);
                    }

                    if (filter.UploadedBy != null && filter.UploadedBy > 0)
                    {
                        query = (from c in query
                                 where c.UploadedBy == filter.UploadedBy
                                 select c);
                    }

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return AutoMapper.Mapper.Map<IEnumerable<CallUploadEntity>, IEnumerable<CallUpload>>(entities);
                }
            }
        }
    }
}
