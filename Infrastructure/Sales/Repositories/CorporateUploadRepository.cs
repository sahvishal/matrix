using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Users.Enum;


namespace Falcon.App.Infrastructure.Sales.Repositories
{

    [DefaultImplementation]
    public class CorporateUploadRepository : PersistenceRepository, ICorporateUploadRepository
    {

        public CorporateUpload GetById(long corporateUploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cu in linqMetaData.CorporateUpload
                              where cu.Id == corporateUploadId
                              select cu).SingleOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map<CorporateUploadEntity, CorporateUpload>(entity);
            }
        }

        public CorporateUpload Save(CorporateUpload domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CorporateUpload, CorporateUploadEntity>(domain);

                adapter.SaveEntity(entity, true);

                return Mapper.Map<CorporateUploadEntity, CorporateUpload>(entity);
            }
        }

        public bool IsFileUpladedBetweenDateTime(DateTime startDateTime, DateTime endDateTime)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var count = (from cu in linqMetaData.CorporateUpload
                             where startDateTime >= cu.UploadTime && cu.UploadTime <= endDateTime
                             select cu).Count();

                return count > 0;
            }
        }

        public IEnumerable<CorporateUpload> GetByFilter(int pageNumber, int pageSize, MemberUploadDetailsListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.CorporateUpload.Count();

                    var entities = linqMetaData.CorporateUpload.Where(x => x.SourceId == filter.SourceId).OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return Mapper.Map<IEnumerable<CorporateUploadEntity>, IEnumerable<CorporateUpload>>(entities);
                }
                else
                {
                    var query = (from c in linqMetaData.CorporateUpload where c.SourceId == filter.SourceId select c);

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

                    totalRecords = query.Count();
                    var entities = query.OrderByDescending(p => p.UploadTime).TakePage(pageNumber, pageSize).Select(x => x).ToArray();
                    return Mapper.Map<IEnumerable<CorporateUploadEntity>, IEnumerable<CorporateUpload>>(entities);
                }
            }
        }

        public IEnumerable<CorporateUpload> GetByParseStatus(int parseStatus)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cu in linqMetaData.CorporateUpload
                                where cu.ParseStatus.HasValue && cu.ParseStatus == (int)MemberUploadParseStatus.Start
                                select cu);
                if (entities == null)
                    return null;

                return Mapper.Map<IEnumerable<CorporateUploadEntity>, IEnumerable<CorporateUpload>>(entities);
            }
        }
    }
}