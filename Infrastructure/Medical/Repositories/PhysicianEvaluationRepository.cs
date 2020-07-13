using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Medical.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;


namespace Falcon.App.Infrastructure.Medical.Repositories
{
    public class PhysicianEvaluationRepository : PersistenceRepository, IPhysicianEvaluationRepository
    {
        private readonly IMapper<PhysicianEvaluation, PhysicianEvaluationEntity> _mapper;

        public PhysicianEvaluationRepository()
            : this(new SqlPersistenceLayer(), new PhysicianEvaluationMapper())
        { }

        public PhysicianEvaluationRepository(IPersistenceLayer persistenceLayer, IMapper<PhysicianEvaluation, PhysicianEvaluationEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public PhysicianEvaluation Save(PhysicianEvaluation physicianEvaluation)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityToSave = _mapper.Map(physicianEvaluation);

                if (!adapter.SaveEntity(entityToSave, true))
                    throw new PersistenceFailureException();

                return _mapper.Map(entityToSave);
            }
        }

        public void Delete(long eventCustomerId, long physicianId)
        {
            var physicianEvaluation = GetPhysicianEvaluationinTransaction(eventCustomerId, physicianId);
            if (physicianEvaluation != null)
                Delete(physicianEvaluation.Id);
        }

        public void Delete(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("PhysicianEvaluationEntity", new RelationPredicateBucket(PhysicianEvaluationFields.PhysicianEvaluationId == id));
            }
        }

        public PhysicianEvaluation GetPhysicianEvaluationinTransaction(long eventCustomerId, long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from pe in linqMetaData.PhysicianEvaluation
                              where pe.EventCustomerId == eventCustomerId && pe.PhysicianId == physicianId && pe.EvaluationEndTime == null
                              orderby pe.PhysicianEvaluationId descending
                              select pe).FirstOrDefault();

                if (entity == null)
                    return null;

                return _mapper.Map(entity);
            }
        }

        public IEnumerable<PhysicianEvaluation> GetPhysicianEvaluation(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pe in linqMetaData.PhysicianEvaluation
                                where pe.EventCustomerId == eventCustomerId
                                select pe).ToArray();

                if (entities.Length < 1)
                    return null;

                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<PhysicianEvaluation> GetPhysicianEvaluationbyPhysician(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pe in linqMetaData.PhysicianEvaluation
                                where pe.PhysicianId == physicianId
                                select pe).ToArray();

                if (entities.Length < 1)
                    return null;

                return _mapper.MapMultiple(entities);
            }
        }

        public void SaveCustomerforReviewSkip(long eventCustomerId, long physicianId, long orgRoleUserId, bool isSkipEvaluation)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity =
                    (from rev in linqMetaData.CustomerSkipReview where rev.EventCustomerId == eventCustomerId select rev)
                        .SingleOrDefault();

                if (entity == null)
                {
                    entity = new CustomerSkipReviewEntity
                                 {
                                     EventCustomerId = eventCustomerId,
                                     DefaultPhysicianId = physicianId > 0 ? (long?)physicianId : null,
                                     CreatedByOrgRoleUserId = orgRoleUserId,
                                     DateCreated = DateTime.Now,
                                     IsSkipEvaluation = isSkipEvaluation,
                                     IsActive = true,
                                     IsNew = true
                                 };
                }
                else
                {
                    entity.DateCreated = DateTime.Now;
                    entity.DefaultPhysicianId = physicianId;
                    entity.IsSkipEvaluation = isSkipEvaluation;
                    entity.IsActive = true;
                }

                adapter.SaveEntity(entity);
            }
        }

        public bool AccquirePhysicianEvaluationLock(long eventCustomerId, long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var ec =
                    (from ecl in linqMetaData.EventCustomerEvaluationLock
                     where ecl.EventCustomerId == eventCustomerId
                     select ecl).SingleOrDefault();

                if (ec != null)
                {
                    if (ec.DateCreated > DateTime.Now.AddHours(-1))
                        return false;

                    ReleasePhysicianEvaluationLock(eventCustomerId);
                }

                var eventCustomerEvaluationLockEntity = new EventCustomerEvaluationLockEntity()
                {
                    EventCustomerId = eventCustomerId,
                    PhysicianId = physicianId,
                    DateCreated = DateTime.Now
                };

                if (!adapter.SaveEntity(eventCustomerEvaluationLockEntity))
                    throw new PersistenceFailureException();
                return true;
            }
        }

        public void ReleasePhysicianEvaluationOldLocks()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventCustomers = linqMetaData.EventCustomerEvaluationLock.ToArray();

                foreach (var entity in eventCustomers)
                {
                    if (entity.DateCreated > DateTime.Now.AddHours(-1))
                        continue;

                    ReleasePhysicianEvaluationLock(entity.EventCustomerId);
                }
            }
        }

        public bool ReleasePhysicianEvaluationLock(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomerEvaluationLockEntity = new EventCustomerEvaluationLockEntity(eventCustomerId);

                if (!adapter.DeleteEntity(eventCustomerEvaluationLockEntity))
                    throw new PersistenceFailureException();
                return true;
            }
        }

        public bool IsMarkedReviewSkip(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity =
                    (from rev in linqMetaData.CustomerSkipReview where rev.EventCustomerId == eventCustomerId && rev.IsActive select rev)
                        .SingleOrDefault();

                return entity != null;
            }
        }

        public void DeleteSkipReviewRecord(long eventCustomerId)
        {
            var skipRecordExists = IsMarkedReviewSkip(eventCustomerId);
            if (skipRecordExists)
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    adapter.UpdateEntitiesDirectly(new CustomerSkipReviewEntity() { IsActive = false },
                                                   new RelationPredicateBucket(CustomerSkipReviewFields.EventCustomerId == eventCustomerId));
                }
            }
        }

        public IEnumerable<long> GetPhysicianIds(int pageNumber, int pageSize, PhysicianReviewSummaryListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    filter = new PhysicianReviewSummaryListModelFilter();
                }

                IQueryable<long> queryPhysicianIds;

                if (filter.IsBlank())
                {
                    queryPhysicianIds = from p in linqMetaData.PhysicianProfile select p.PhysicianId;
                }
                else
                {
                    var query = (from pe in linqMetaData.PhysicianEvaluation
                                 join ec in linqMetaData.EventCustomers on pe.EventCustomerId equals
                                     ec.EventCustomerId
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where pe.EvaluationEndTime.HasValue
                                 select new { pe, e });


                    if (filter.EventId > 0)
                    {
                        query = query.Where(q => q.e.EventId == filter.EventId);
                    }
                    else
                    {
                        if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(a => a.e.EventDate >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query =
                                    query.Where(
                                        a => a.e.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }
                        else if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EvaluationDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(a => a.pe.EvaluationStartTime >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query =
                                    query.Where(
                                        a => a.pe.EvaluationStartTime < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }

                        if (filter.PodId > 0)
                        {
                            var eventIds = (from ep in linqMetaData.EventPod
                                            where ep.PodId == filter.PodId && ep.IsActive
                                            select ep.EventId);
                            query = query.Where(q => eventIds.Contains(q.e.EventId));
                        }

                        if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => !eventIds.Contains(q.e.EventId));
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => eventIds.Contains(q.e.EventId));
                        }

                        if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Public);
                        else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Private);
                    }

                    queryPhysicianIds = (from q in query orderby q.pe.PhysicianId select q.pe.PhysicianId);
                }

                totalRecords = queryPhysicianIds.Distinct().Count();
                return queryPhysicianIds.Distinct().TakePage(pageNumber, pageSize).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, double>> GetPhysicianIdAverageReviewTimePair(IEnumerable<long> physicianIds, PhysicianReviewSummaryListModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from pe in linqMetaData.PhysicianEvaluation
                             join ecr in linqMetaData.EventCustomerResult on pe.EventCustomerId equals
                                 ecr.EventCustomerResultId
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where physicianIds.Contains(pe.PhysicianId)
                                   && pe.EvaluationEndTime.HasValue
                             select
                                 new
                                     {
                                         pe.PhysicianId,
                                         pe.EvaluationStartTime,
                                         pe.EvaluationEndTime,
                                         e.EventDate,
                                         e.EventId,
                                         e.EventTypeId
                                     });
                if (filter == null)
                {
                    var resultquery = (from q in query
                                       select
                                           new
                                               {
                                                   q.PhysicianId,
                                                   q.EvaluationStartTime,
                                                   q.EvaluationEndTime
                                               }).ToList();

                    return (from q in resultquery
                            group q by q.PhysicianId
                                into g
                                select new OrderedPair<long, double>(g.Key, g.Average(q => q.EvaluationEndTime.Value.Subtract(q.EvaluationStartTime).TotalSeconds))).ToList();

                }
                else
                {
                    if (filter.EventId > 0)
                    {
                        query = query.Where(q => q.EventId == filter.EventId);
                    }
                    else
                    {
                        if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(a => a.EventDate >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query = query.Where(a => a.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }
                        else
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(a => a.EvaluationStartTime >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query = query.Where(a => a.EvaluationStartTime < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }

                        if (filter.PodId > 0)
                        {
                            var eventIds = (from ep in linqMetaData.EventPod
                                            where ep.PodId == filter.PodId && ep.IsActive
                                            select ep.EventId);
                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }

                        if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => !eventIds.Contains(q.EventId));
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }

                        if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            query = query.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                        else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            query = query.Where(q => q.EventTypeId == (long)RegistrationMode.Private);
                    }

                    var resultquery = (from q in query
                                       select
                                           new
                                           {
                                               q.PhysicianId,
                                               q.EvaluationStartTime,
                                               q.EvaluationEndTime
                                           }).ToList();

                    return (from q in resultquery
                            group q by q.PhysicianId
                                into g
                                select new OrderedPair<long, double>(g.Key, g.Average(q => q.EvaluationEndTime.Value.Subtract(q.EvaluationStartTime).TotalSeconds))).ToList();
                }
            }
        }

        public IEnumerable<PhysicianEvaluation> GetEvaluations(int pageNumber, int pageSize, PhysicianReviewListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<PhysicianEvaluationEntity> entities;
                if (filter == null)
                {
                    var query = (from pe in linqMetaData.PhysicianEvaluation
                                 where pe.EvaluationEndTime.HasValue
                                 orderby pe.EvaluationStartTime descending
                                 select pe);
                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var query = (from pe in linqMetaData.PhysicianEvaluation
                                 join ecr in linqMetaData.EventCustomerResult on pe.EventCustomerId equals
                                     ecr.EventCustomerResultId
                                 join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                 where pe.EvaluationEndTime.HasValue
                                 select new { pe, e });

                    if (filter.PhysicianId > 0)
                    {
                        query = query.Where(q => q.pe.PhysicianId == filter.PhysicianId);
                    }

                    if (filter.EventId > 0)
                    {
                        query = query.Where(q => q.e.EventId == filter.EventId);
                    }
                    else
                    {
                        if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(q => q.e.EventDate >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query = query.Where(q => q.e.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }
                        else if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EvaluationDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(q => q.pe.EvaluationStartTime >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query = query.Where(q => q.pe.EvaluationStartTime < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }

                        if (filter.PodId > 0)
                        {
                            var eventIds = (from ep in linqMetaData.EventPod
                                            where ep.PodId == filter.PodId && ep.IsActive
                                            select ep.EventId);
                            query = query.Where(q => eventIds.Contains(q.e.EventId));
                        }

                        if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => !eventIds.Contains(q.e.EventId));
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => eventIds.Contains(q.e.EventId));
                        }

                        if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Public);
                        else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Private);
                    }

                    var evaluationQuery = (from q in query
                                           orderby q.pe.EvaluationStartTime descending
                                           select q.pe);
                    totalRecords = evaluationQuery.Count();
                    entities = evaluationQuery.TakePage(pageNumber, pageSize).ToList();
                }

                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetPhysicianIdsForTestReviewed(int pageNumber, int pageSize, PhysicianTestReviewListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    filter = new PhysicianTestReviewListModelFilter();
                }

                IQueryable<long> queryPhysicianIds;

                if (filter.IsBlank())
                {
                    queryPhysicianIds = from p in linqMetaData.PhysicianProfile select p.PhysicianId;
                }
                else
                {
                    var query = (from pe in linqMetaData.PhysicianEvaluation
                                 join ec in linqMetaData.EventCustomers on pe.EventCustomerId equals
                                     ec.EventCustomerId
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where pe.EvaluationEndTime.HasValue
                                 select new { pe, e });

                    if (filter.PhysicianId > 0)
                    {
                        query = query.Where(q => q.pe.PhysicianId == filter.PhysicianId);
                    }

                    if (filter.EventId > 0)
                    {
                        query = query.Where(q => q.e.EventId == filter.EventId);
                    }
                    else
                    {
                        if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(a => a.e.EventDate >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query =
                                    query.Where(
                                        a => a.e.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }
                        else if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EvaluationDate)
                        {
                            if (filter.FromDate.HasValue)
                                query = query.Where(a => a.pe.EvaluationStartTime >= filter.FromDate.Value);

                            if (filter.ToDate.HasValue)
                                query =
                                    query.Where(
                                        a => a.pe.EvaluationStartTime < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                        }

                        if (filter.PodId > 0)
                        {
                            var eventIds = (from ep in linqMetaData.EventPod
                                            where ep.PodId == filter.PodId && ep.IsActive
                                            select ep.EventId);
                            query = query.Where(q => eventIds.Contains(q.e.EventId));
                        }

                        if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => !eventIds.Contains(q.e.EventId));
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount
                                            select ea.EventId);
                            query = query.Where(q => eventIds.Contains(q.e.EventId));
                        }

                        if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Public);
                        else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Private);
                    }

                    queryPhysicianIds = (from q in query orderby q.pe.PhysicianId select q.pe.PhysicianId);
                }

                totalRecords = queryPhysicianIds.Distinct().Count();
                return queryPhysicianIds.Distinct().TakePage(pageNumber, pageSize).ToArray();
            }
        }

        public IEnumerable<long> GetEventCustomerIdsForHalfStudy(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from q in
                            (from pe in linqMetaData.PhysicianEvaluation
                             where eventCustomerIds.Contains(pe.EventCustomerId)
                             && pe.EvaluationEndTime.HasValue
                             group pe by pe.EventCustomerId
                                 into g
                                 select new { EventCustomerId = g.Key, Primary = g.Max(pe => pe.PhysicianId), OverRead = g.Min(pe => pe.PhysicianId) }
                            )
                        where q.Primary != q.OverRead
                        select q.EventCustomerId).Distinct().ToArray();
            }
        }

        public PhysicianEvaluation GetPhysicianEvaluationbyEventIdCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from pe in linqMetaData.PhysicianEvaluation
                              join eventCustomers in linqMetaData.EventCustomers on pe.EventCustomerId equals eventCustomers.EventCustomerId
                              where eventCustomers.EventId == eventId && eventCustomers.CustomerId == customerId
                              select pe).FirstOrDefault();

                if (entity == null)
                    return null;

                return _mapper.Map(entity);
            }
        }

        public IEnumerable<PhysicianEvaluation> GetPhysicianEvaluation(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from pe in linqMetaData.PhysicianEvaluation
                                where eventCustomerIds.Contains(pe.EventCustomerId)
                                select pe).ToArray();

                if (entities.Length < 1)
                    return null;

                return _mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<CustomerSkipReview> GetCustomerSkipReviews(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from csr in linqMetaData.CustomerSkipReview
                                where eventCustomerIds.Contains(csr.EventCustomerId) && csr.IsActive
                                select csr).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<CustomerSkipReviewEntity>, IEnumerable<CustomerSkipReview>>(entities);
            }
        }

    }
}
