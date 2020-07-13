using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class CustomerActivityTypeUploadRepository : PersistenceRepository, ICustomerActivityTypeUploadRepository
    {
        public CustomerActivityTypeUpload GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from eu in linqMetaData.CustomerActivityTypeUpload where eu.Id == id select eu).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<CustomerActivityTypeUpload>(id);

                return Mapper.Map<CustomerActivityTypeUploadEntity, CustomerActivityTypeUpload>(entity);
            }
        }

        public CustomerActivityTypeUpload Save(CustomerActivityTypeUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerActivityTypeUpload, CustomerActivityTypeUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save CustomerActivityTypeUpload");

                return Mapper.Map<CustomerActivityTypeUploadEntity, CustomerActivityTypeUpload>(entity);
            }
        }

        public IEnumerable<CustomerActivityTypeUpload> GetFilesToParse()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from eu in linqMetaData.CustomerActivityTypeUpload where eu.StatusId == (long)CallUploadStatus.Uploaded select eu);

                return Mapper.Map<IEnumerable<CustomerActivityTypeUploadEntity>, IEnumerable<CustomerActivityTypeUpload>>(entities);
            }
        }

        public IEnumerable<CustomerActivityTypeUpload> GetByFilter(int pageNumber, int pageSize, CustomerActivityTypeUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.CustomerActivityTypeUpload.Count();

                    var entities = linqMetaData.CustomerActivityTypeUpload.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return Mapper.Map<IEnumerable<CustomerActivityTypeUploadEntity>, IEnumerable<CustomerActivityTypeUpload>>(entities);
                }
                else
                {
                    var query = (from c in linqMetaData.CustomerActivityTypeUpload select c);

                    if (filter.FromUploadDate.HasValue)
                    {
                        query = (from c in query
                                 where c.UploadTime.Date >= filter.FromUploadDate.Value.Date
                                 select c);
                    }
                    if (filter.ToUploadDate.HasValue)
                    {
                        query = (from c in query
                                 where c.UploadTime.Date <= filter.ToUploadDate.Value.Date
                                 select c);
                    }

                    if (filter.UploadedBy.HasValue && filter.UploadedBy > 0)
                    {
                        query = (from c in query
                                 where c.UploadedBy == filter.UploadedBy
                                 select c);
                    }

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return Mapper.Map<IEnumerable<CustomerActivityTypeUploadEntity>, IEnumerable<CustomerActivityTypeUpload>>(entities);
                }
            }
        }
    }
}
