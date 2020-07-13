using System;
using System.Collections.Generic;
using System.Linq;
using AuthorizeNet;
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

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class RapsUploadRepository : PersistenceRepository, IRapsUploadRepository
    {
        public RapsUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from cu in linqMetaData.RapsUpload where cu.Id == id select cu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<RapsUpload>(id);

                return AutoMapper.Mapper.Map<RapsUploadEntity, RapsUpload>(entity);
            }
        }

        public RapsUpload Save(RapsUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<RapsUpload, RapsUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Raps Upload ");

                return AutoMapper.Mapper.Map<RapsUploadEntity, RapsUpload>(entity);
            }
        }

        public IEnumerable<RapsUpload> GetFilesToParse()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cu in linqMetaData.RapsUpload where cu.StatusId == (long)RapsUploadStatus.Uploaded select cu).ToList();

                return AutoMapper.Mapper.Map<IEnumerable<RapsUploadEntity>, IEnumerable<RapsUpload>>(entities);
            }
        }

        public IEnumerable<RapsUploadModel> GetUploadList(int pageNumber, int pageSize, RapsUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<RapsUploadEntity> entities = (from cu in linqMetaData.RapsUpload where cu.StatusId == (long)RapsUploadStatus.Uploaded select cu).ToList();

                if (filter.IsEmpty())
                {
                    var query = (from cu in linqMetaData.RapsUpload where cu.StatusId != (long)RapsUploadStatus.UploadStarted select cu).OrderByDescending(x => x.UploadTime);

                    totalRecords = query.Count();
                    entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.File)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var query = (from cu in linqMetaData.RapsUpload
                                 where cu.StatusId != (long)RapsUploadStatus.UploadStarted
                                 && (filter.FromDate == null || filter.FromDate <= cu.UploadTime.Date)
                                 && (filter.ToDate == null || filter.ToDate >= cu.UploadTime.Date)
                                 && (filter.Status == null || (long)filter.Status == cu.StatusId)
                                 && (filter.Name == null || cu.File.Path.Contains(filter.Name))
                                 && (filter.UploadedBy == null || filter.UploadedBy == cu.UploadedBy)
                                 select cu).OrderByDescending(x => x.UploadTime);

                    totalRecords = query.Count();
                    entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.File)).TakePage(pageNumber, pageSize).ToList();
                }


                return AutoMapper.Mapper.Map<IEnumerable<RapsUploadEntity>, IEnumerable<RapsUploadModel>>(entities);
            }
        }
    }
}
