using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class SuspectConditionUploadRepository : PersistenceRepository, ISuspectConditionUploadRepository
    {
        public SuspectConditionUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from scu in linqMetaData.SuspectConditionUpload where scu.Id == id select scu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<SuspectConditionUpload>(id);

                return AutoMapper.Mapper.Map<SuspectConditionUploadEntity, SuspectConditionUpload>(entity);
            }
        }

        public SuspectConditionUpload Save(SuspectConditionUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<SuspectConditionUpload, SuspectConditionUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Suspect Condition Upload ");

                return AutoMapper.Mapper.Map<SuspectConditionUploadEntity, SuspectConditionUpload>(entity);
            }
        }

        public IEnumerable<SuspectConditionUploadModel> GetUploadList(int pageNumber, int pageSize, SuspectConditionUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<SuspectConditionUploadEntity> entities = (from scu in linqMetaData.SuspectConditionUpload where scu.StatusId == (long)SuspectConditionUploadStatus.Uploaded select scu).ToList();

                if (filter.IsEmpty())
                {
                    var query = (from scu in linqMetaData.SuspectConditionUpload where scu.StatusId != (long)SuspectConditionUploadStatus.UploadStarted select scu).OrderByDescending(x => x.UploadTime);

                    totalRecords = query.Count();
                    entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.File)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var query = (from scu in linqMetaData.SuspectConditionUpload
                                 where scu.StatusId != (long)SuspectConditionUploadStatus.UploadStarted
                                 && (filter.FromDate == null || filter.FromDate <= scu.UploadTime.Date)
                                 && (filter.ToDate == null || filter.ToDate >= scu.UploadTime.Date)
                                 && (filter.Status == null || (long)filter.Status == scu.StatusId)
                                 && (filter.Name == null || scu.File.Path.Contains(filter.Name))
                                 && (filter.UploadedBy == null || filter.UploadedBy == scu.UploadedBy)
                                 select scu).OrderByDescending(x => x.UploadTime);

                    totalRecords = query.Count();
                    entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.File)).TakePage(pageNumber, pageSize).ToList();
                }

                return AutoMapper.Mapper.Map<IEnumerable<SuspectConditionUploadEntity>, IEnumerable<SuspectConditionUploadModel>>(entities);
            }
        }
    }
}
