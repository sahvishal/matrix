using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class StaffEventScheduleUploadRepository : PersistenceRepository, IStaffEventScheduleUploadRepository
    {
        public StaffEventScheduleUpload Save(StaffEventScheduleUpload domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<StaffEventScheduleUpload, StaffEventScheduleUploadEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<StaffEventScheduleUploadEntity, StaffEventScheduleUpload>(entity);
            }
        }

        public IEnumerable<StaffEventScheduleUpload> GetByFilter(int pageNumber, int pageSize, StaffEventScheduleUploadModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    var entities =
                        linqMetaData.StaffEventScheduleUpload.OrderByDescending(x => x.UploadTime)
                            .Where(x => x.StatusId != (long)PhoneNumberUploadStatus.InvalidFileFormat)
                            .TakePage(pageNumber, pageSize)
                            .Select(x => x)
                            .ToArray();
                    totalRecords = entities.Count();
                    return Mapper.Map<IEnumerable<StaffEventScheduleUploadEntity>, IEnumerable<StaffEventScheduleUpload>>(entities);
                }
                else
                {
                    var query = from sesu in linqMetaData.StaffEventScheduleUpload
                                where sesu.StatusId != (long)StaffEventScheduleParseStatus.InvalidFileFormat
                                select sesu;

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
                    return Mapper.Map<IEnumerable<StaffEventScheduleUploadEntity>, IEnumerable<StaffEventScheduleUpload>>(entities);
                }
            }
        }

        public IEnumerable<StaffEventScheduleUpload> GetFilesToParse()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = from sesu in linqMetaData.StaffEventScheduleUpload where sesu.StatusId == (long)StaffEventScheduleParseStatus.Uploaded select sesu;
                return Mapper.Map<IEnumerable<StaffEventScheduleUploadEntity>, IEnumerable<StaffEventScheduleUpload>>(entities);
            }
        }
    }
}
