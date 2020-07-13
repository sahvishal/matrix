using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CustomerPhoneNumberUpdateUploadRepository : PersistenceRepository, ICustomerPhoneNumberUpdateUploadRepository
    {
        public CustomerPhoneNumberUpdateUpload Save(CustomerPhoneNumberUpdateUpload domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                CustomerPhoneNumberUpdateUploadEntity entity = Mapper.Map<CustomerPhoneNumberUpdateUpload, CustomerPhoneNumberUpdateUploadEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<CustomerPhoneNumberUpdateUploadEntity, CustomerPhoneNumberUpdateUpload>(entity);
            }
        }

        public IEnumerable<CustomerPhoneNumberUpdateUpload> GetByFilter(int pageNumber, int pageSize, CustomerPhoneNumberUpdateModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    var entities =
                        linqMetaData.CustomerPhoneNumberUpdateUpload.OrderByDescending(x => x.UploadTime)
                            .Where(x => x.StatusId != (long)PhoneNumberUploadStatus.InvalidFileFormat)
                            .TakePage(pageNumber, pageSize)
                            .Select(x => x)
                            .ToArray();
                    totalRecords = entities.Count();
                    return Mapper.Map<IEnumerable<CustomerPhoneNumberUpdateUploadEntity>, IEnumerable<CustomerPhoneNumberUpdateUpload>>(entities);
                }
                else
                {
                    var query = from cpnuu in linqMetaData.CustomerPhoneNumberUpdateUpload
                                where cpnuu.StatusId != (long)PhoneNumberUploadStatus.InvalidFileFormat
                                select cpnuu;

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
                                 where c.UploadedByOrgRoleUserId == filter.UploadedBy
                                 select c);
                    }

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return Mapper.Map<IEnumerable<CustomerPhoneNumberUpdateUploadEntity>, IEnumerable<CustomerPhoneNumberUpdateUpload>>(entities);
                }
            }
        }

        public IEnumerable<CustomerPhoneNumberUpdateUpload> GetUploadedFilesInfo()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cpnuu in linqMetaData.CustomerPhoneNumberUpdateUpload
                                where cpnuu.StatusId == (long)PhoneNumberUploadStatus.Uploaded
                                select cpnuu).ToArray();

                return Mapper.Map<IEnumerable<CustomerPhoneNumberUpdateUploadEntity>, IEnumerable<CustomerPhoneNumberUpdateUpload>>(entities);
            }
        }
    }
}
