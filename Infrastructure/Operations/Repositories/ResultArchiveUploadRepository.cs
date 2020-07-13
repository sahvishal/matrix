using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Medical.Enum;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation(Interface = typeof(IResultArchiveUploadRepository))]
    public class ResultArchiveUploadRepository : PersistenceRepository, IResultArchiveUploadRepository
    {
        public ResultArchiveUploadRepository()
        {

        }

        public ResultArchive GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity =
                    (from ul in linqMetaData.ResultArchiveUpload where ul.ResultArchiveUploadId == id select ul).SingleOrDefault();

                if (entity == null)
                    throw new ObjectNotFoundInPersistenceException<ResultArchive>(id);

                return AutoMapper.Mapper.Map<ResultArchiveUploadEntity, ResultArchive>(entity);
            }
        }

        public IEnumerable<ResultArchive> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    (from ul in linqMetaData.ResultArchiveUpload where ul.EventId == eventId select ul).ToArray();

                if (entities.Count() < 1)
                    return null;

                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadEntity>, IEnumerable<ResultArchive>>(entities);
            }
        }

        public IEnumerable<ResultArchive> GetByFilter(ResultArchiveUploadListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<ResultArchiveUploadEntity> entities = null;

                if (filter == null)
                {
                    totalRecords = linqMetaData.ResultArchiveUpload.Count();
                    entities =
                        linqMetaData.ResultArchiveUpload.OrderByDescending(ul => ul.ResultArchiveUploadId).TakePage(
                            pageNumber, pageSize).ToArray();
                }
                else
                {
                    if (filter.EventId > 0)
                    {
                        var query = linqMetaData.ResultArchiveUpload.Where(ul => ul.EventId == filter.EventId);
                        totalRecords = query.Count();
                        entities = query.OrderByDescending(ul => ul.ResultArchiveUploadId).TakePage(pageNumber, pageSize).ToArray();
                    }
                    else
                    {
                        var query = from ul in linqMetaData.ResultArchiveUpload select ul;
                        if (filter.FromUploadDate.HasValue || filter.ToUploadDate.HasValue || filter.UploadedBy > 0 || filter.ResultArchiveUploadStatus > 0)
                        {
                            var fromDate = filter.FromUploadDate.HasValue ? filter.FromUploadDate.Value.Date : DateTime.Now;
                            var toDate = filter.ToUploadDate.HasValue ? filter.ToUploadDate.Value.AddDays(1).Date : DateTime.Now;

                            query = from ul in linqMetaData.ResultArchiveUpload
                                    where (filter.FromUploadDate != null ? ul.UploadStartTime >= fromDate : true)
                                    && (filter.ToUploadDate != null ? ul.UploadStartTime < toDate : true)
                                    && (filter.UploadedBy > 0 ? ul.UploadedByOrgRoleUserId == filter.UploadedBy : true)
                                    && (filter.ResultArchiveUploadStatus > 0 ? ul.Status == filter.ResultArchiveUploadStatus : true)
                                    select ul;
                        }

                        if (filter.FromEventDate.HasValue || filter.ToEventDate.HasValue)
                        {
                            var fromDate = filter.FromEventDate.HasValue ? filter.FromEventDate.Value.Date : DateTime.Now;
                            var toDate = filter.ToEventDate.HasValue ? filter.ToEventDate.Value.AddDays(1).Date : DateTime.Now;

                            query = from ul in query
                                    join e in linqMetaData.Events on ul.EventId equals e.EventId
                                    where (filter.FromEventDate.HasValue ? e.EventDate >= fromDate : true)
                                          && (filter.ToEventDate.HasValue ? e.EventDate < toDate : true)
                                    select ul;
                        }

                        if (filter.IsArchived.HasValue && filter.IsArchived.Value)
                        {
                            query = from ul in query join f in linqMetaData.File on ul.FileId equals f.FileId where !f.IsArchived select ul;
                        }

                        if (!string.IsNullOrEmpty(filter.Pod))
                        {
                            query = from ul in query
                                    join ep in linqMetaData.EventPod on ul.EventId equals ep.EventId
                                    join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                    where ep.IsActive && p.Name.Contains(filter.Pod)
                                    select ul;
                        }

                        totalRecords = query.Count();
                        entities = query.OrderByDescending(ul => ul.ResultArchiveUploadId).TakePage(pageNumber, pageSize).ToArray();
                    }
                }

                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadEntity>, IEnumerable<ResultArchive>>(entities);
            }
        }

        public IEnumerable<ResultArchive> Get(ResultArchiveUploadStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from r in linqMetaData.ResultArchiveUpload where r.Status == (int)status select r).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadEntity>, IEnumerable<ResultArchive>>(entities);
            }
        }

        public ResultArchive Save(ResultArchive domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<ResultArchive, ResultArchiveUploadEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Result Archive Record for Event Id: " + domainObject.EventId);

                return AutoMapper.Mapper.Map<ResultArchiveUploadEntity, ResultArchive>(entity);
            }
        }

        public void Delete(ResultArchive domainObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ResultArchive> domainObjects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetEventIdsForStatus(IEnumerable<long> eventIds, ResultArchiveUploadStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from rau in linqMetaData.ResultArchiveUpload
                        join rauGroup in
                            (from rau in linqMetaData.ResultArchiveUpload
                             group rau by rau.EventId
                                 into g
                                 select
                                     new
                                         {
                                             EventId = g.Key,
                                             ResultArchiveUploadId = g.Max(rau => rau.ResultArchiveUploadId)
                                         }
                            ) on rau.ResultArchiveUploadId equals rauGroup.ResultArchiveUploadId
                        where rau.Status >= (int)status
                        select rau.EventId).ToList();

            }
        }

        public IEnumerable<ResultArchive> GetForEventArchiveStatsReport(EventArchiveStatsFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from rau in linqMetaData.ResultArchiveUpload
                             select rau);

                if (filter != null)
                {
                    if (filter.EventId > 0)
                    {
                        query = query.Where(q => q.EventId == filter.EventId);
                    }
                    else
                    {
                        if (filter.UploadDateFrom != null)
                        {
                            query = query.Where(q => q.UploadStartTime >= filter.UploadDateFrom);
                        }

                        if (filter.UploadDateTo != null)
                        {
                            query = query.Where(q => q.UploadStartTime < filter.UploadDateTo.Value.AddDays(1));
                        }

                        if (filter.UploadedBy > 0)
                        {
                            query = query.Where(q => q.UploadedByOrgRoleUserId == filter.UploadedBy);
                        }

                        if (filter.UploadStatus > 0)
                        {
                            if (filter.UploadStatus == (long)ResultArchiveUploadStatus.Uploading || filter.UploadStatus == (long)ResultArchiveUploadStatus.UploadFailed)
                            {
                                query = query.Where(q => q.Status == filter.UploadStatus);
                            }
                            else
                            {
                                query = query.Where(q => q.Status != (long)ResultArchiveUploadStatus.Uploading && q.Status != (long)ResultArchiveUploadStatus.UploadFailed);
                            }
                        }
                        if (filter.PodId > 0)
                        {
                            var eventIds = (from e in linqMetaData.Events
                                            join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                            join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                            where p.PodId == filter.PodId
                                            select e.EventId);

                            query = (from q in query where eventIds.Contains(q.EventId) select q);
                        }
                    }
                }

                totalRecords = query.Count();

                var result = query.OrderByDescending(ul => ul.ResultArchiveUploadId).TakePage(pageNumber, pageSize).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadEntity>, IEnumerable<ResultArchive>>(result);
            }
        }

        public IEnumerable<ResultArchive> GetResultArchiveUploadingAfterHours(int markFailedAfterHours)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from r in linqMetaData.ResultArchiveUpload where r.Status == (int)ResultArchiveUploadStatus.Uploading && r.UploadStartTime < DateTime.Now.AddHours(-markFailedAfterHours) select r).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<ResultArchiveUploadEntity>, IEnumerable<ResultArchive>>(entities);
            }
        }
    }
}
