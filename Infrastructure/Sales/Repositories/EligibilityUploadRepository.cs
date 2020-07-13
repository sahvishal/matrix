using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class EligibilityUploadRepository : PersistenceRepository, IEligibilityUploadRepository
    {
        public EligibilityUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from eu in linqMetaData.EligibilityUpload where eu.Id == id select eu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<EligibilityUpload>(id);

                return Mapper.Map<EligibilityUploadEntity, EligibilityUpload>(entity);
            }
        }

        public EligibilityUpload Save(EligibilityUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EligibilityUpload, EligibilityUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Eligibility Upload ");

                return Mapper.Map<EligibilityUploadEntity, EligibilityUpload>(entity);
            }
        }

        public IEnumerable<EligibilityUpload> GetFilesToParse()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from eu in linqMetaData.EligibilityUpload where eu.StatusId == (long)EligibilityUploadStatus.Uploaded select eu);

                return Mapper.Map<IEnumerable<EligibilityUploadEntity>, IEnumerable<EligibilityUpload>>(entities);
            }
        }

        public IEnumerable<EligibilityUpload> GetByFilter(int pageNumber, int pageSize, EligibilityUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.EligibilityUpload.Count();

                    var entities = linqMetaData.EligibilityUpload.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return Mapper.Map<IEnumerable<EligibilityUploadEntity>, IEnumerable<EligibilityUpload>>(entities);
                }
                else
                {
                    var query = (from c in linqMetaData.EligibilityUpload select c);

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
                    return Mapper.Map<IEnumerable<EligibilityUploadEntity>, IEnumerable<EligibilityUpload>>(entities);
                }
            }
        }

    }
}
