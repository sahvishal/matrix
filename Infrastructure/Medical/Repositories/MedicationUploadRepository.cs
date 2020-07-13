using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    public class MedicationUploadRepository : PersistenceRepository, IMedicationUploadRepository
    {
        public MedicationUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from cu in linqMetaData.MedicationUpload where cu.Id == id select cu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<MedicationUpload>(id);

                return Mapper.Map<MedicationUploadEntity, MedicationUpload>(entity);
            }
        }

        public MedicationUpload Save(MedicationUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<MedicationUpload, MedicationUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Medication Upload ");

                return Mapper.Map<MedicationUploadEntity, MedicationUpload>(entity);
            }
        }

        public IEnumerable<MedicationUpload> GetFilesToParse()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cu in linqMetaData.MedicationUpload where cu.StatusId == (long)MedicationUploadStatus.Uploaded select cu).ToList();

                return Mapper.Map<IEnumerable<MedicationUploadEntity>, IEnumerable<MedicationUpload>>(entities);
            }
        }

        public IEnumerable<MedicationUploadViewModel> GetUploadList(int pageNumber, int pageSize, MedicationUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<MedicationUploadEntity> entities = (from cu in linqMetaData.MedicationUpload where cu.StatusId == (long)MedicationUploadStatus.Uploaded select cu).ToList();

                if (filter.IsEmpty())
                {
                    var query = (from cu in linqMetaData.MedicationUpload where cu.StatusId != (long)MedicationUploadStatus.UploadStarted select cu).OrderByDescending(x => x.UploadTime);

                    totalRecords = query.Count();
                    entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.File)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var query = (from cu in linqMetaData.MedicationUpload
                                 where cu.StatusId != (long)MedicationUploadStatus.UploadStarted
                                 && (filter.FromDate == null || filter.FromDate <= cu.UploadTime.Date)
                                 && (filter.ToDate == null || filter.ToDate >= cu.UploadTime.Date)
                                 && (filter.Status == null || (long)filter.Status == cu.StatusId)
                                 && (filter.Name == null || cu.File.Path.Contains(filter.Name))
                                 && (filter.UploadedBy == null || filter.UploadedBy == cu.UploadedBy)
                                 select cu).OrderByDescending(x => x.UploadTime);

                    totalRecords = query.Count();
                    entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.File)).TakePage(pageNumber, pageSize).ToList();
                }


                return Mapper.Map<IEnumerable<MedicationUploadEntity>, IEnumerable<MedicationUploadViewModel>>(entities);
            }
        }
    }
}
