using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class MergeCustomerUploadRepository : PersistenceRepository, IMergeCustomerUploadRepository
    {
        public MergeCustomerUpload Save(MergeCustomerUpload domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<MergeCustomerUpload, MergeCustomerUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Call Upload ");

                return AutoMapper.Mapper.Map<MergeCustomerUploadEntity, MergeCustomerUpload>(entity);
            }
        }

        public IEnumerable<MergeCustomerUpload> GetByFilter(int pageNumber, int pageSize, MergeCustomerUploadListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.MergeCustomerUpload.Count();

                    var entities = linqMetaData.MergeCustomerUpload.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return AutoMapper.Mapper.Map<IEnumerable<MergeCustomerUploadEntity>, IEnumerable<MergeCustomerUpload>>(entities);
                }
                else
                {
                    var query = (from c in linqMetaData.MergeCustomerUpload select c);

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
                    return AutoMapper.Mapper.Map<IEnumerable<MergeCustomerUploadEntity>, IEnumerable<MergeCustomerUpload>>(entities);
                }
            }
        }

        public IEnumerable<MergeCustomerUpload> GetMergeCustomerUploadsForMerging()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from mcu in linqMetaData.MergeCustomerUpload
                                where mcu.StatusId == (long)MergeCustomerUploadStatus.Uploaded || mcu.StatusId == (long)MergeCustomerUploadStatus.Parsing
                                orderby mcu.UploadTime
                                select mcu).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<MergeCustomerUploadEntity>, IEnumerable<MergeCustomerUpload>>(entities);
            }
        }
    }
}
