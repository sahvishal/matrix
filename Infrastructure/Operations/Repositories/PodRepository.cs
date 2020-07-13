using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    public class PodRepository : UniqueItemRepository<Pod, PodDetailsEntity>, IPodRepository
    {

        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public PodRepository()
            : base(new PodMapper())
        {
            _organizationRoleUserRepository = new OrganizationRoleUserRepository();
        }

        protected override EntityField2 EntityIdField
        {
            get { return PodDetailsFields.PodId; }
        }

        public List<Pod> GetAllPods()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return Mapper.MapMultiple(linqMetaData.PodDetails.OrderBy(p => p.Name)).ToList();
            }
        }

        public List<Pod> GetAllPods(int pagenumber, int pageIze)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return Mapper.MapMultiple(linqMetaData.PodDetails.OrderBy(p => p.Name).TakePage(pagenumber, pageIze)).ToList();
            }
        }

        public List<Pod> GetPodsAssignedToFranchisee(long franchiseeId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return Mapper.MapMultiple(linqMetaData.PodDetails.
                    Where(pod => pod.OrganizationId == franchiseeId && pod.IsActive)).ToList();
            }
        }

        public List<Pod> GetPodsAssignedToSalesRep(long salesRepId)
        {
            List<PodDetailsEntity> podDetailsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                podDetailsEntities = linqMetaData.PodDetails.
                    Join(linqMetaData.SalesRepPodAssigments, p => p.PodId, srpa => srpa.PodId, (p, srpa) => new { p, srpa }).
                    Where(@a => @a.srpa.OrganizationRoleUserId == salesRepId).
                    Where(@a => @a.p.IsActive).
                    Select(@a => @a.p).ToList();
            }
            return Mapper.MapMultiple(podDetailsEntities).ToList();
        }

        public bool AssignPodToSalesRep(long podId, long salesRepId)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.GetOrganizationRoleUser(salesRepId).Id;
            var entityToInsert = new SalesRepPodAssigmentsEntity(organizationRoleUserId, podId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.SaveEntity(entityToInsert);
            }
        }

        public bool UnassignPodFromSalesRep(long podId, long salesRepId)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.GetOrganizationRoleUser(salesRepId).Id;
            var entityToDelete = new SalesRepPodAssigmentsEntity(organizationRoleUserId, podId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.DeleteEntity(entityToDelete);
            }
        }

        public List<Pod> GetSalesRepAssignedPodsAvailableForEvent(long salesRepId, DateTime eventDate)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.GetOrganizationRoleUser(salesRepId).Id;
            List<PodDetailsEntity> podDetailsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventPods = linqMetaData.PodDetails.
                    Join(linqMetaData.SalesRepPodAssigments, p => p.PodId, srpa => srpa.PodId, (p, srpa) => new { p, srpa }).
                    Join(linqMetaData.EventPod, @a => @a.p.PodId, ep => ep.PodId, (@a, ep) => new { @a, ep }).
                    Join(linqMetaData.Events, @t => @t.ep.EventId, e => e.EventId, (@t, e) => new { @t, e }).
                    Where(@a => @a.t.a.srpa.OrganizationRoleUserId == organizationRoleUserId).
                    Where(@a => @a.e.EventDate == eventDate && @a.t.ep.IsActive).
                    Select(@a => @a.t.a.p.PodId).ToList();

                podDetailsEntities = linqMetaData.PodDetails.
                    Join(linqMetaData.SalesRepPodAssigments, p => p.PodId, srpa => srpa.PodId, (p, srpa) => new { p, srpa }).
                    Where(@a => @a.srpa.OrganizationRoleUserId == organizationRoleUserId).
                    Where(@a => @a.p.IsActive).
                    Where(@a => !eventPods.Contains(@a.p.PodId)).
                    Select(@a => @a.p).ToList();
            }
            return Mapper.MapMultiple(podDetailsEntities).ToList();
        }
        
        public List<Pod> GetPodsAvailableForEvent(long franchiseeId, DateTime eventDate)
        {
            List<PodDetailsEntity> podDetailsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventPods = linqMetaData.EventPod.
                    Join(linqMetaData.Events, ep => ep.EventId, e => e.EventId, (ep, e) => new { ep, e }).
                    Where(@t => @t.e.EventDate == eventDate && @t.ep.IsActive).
                    Select(@a => @a.ep.PodId).ToList();

                podDetailsEntities = linqMetaData.PodDetails.
                    Where(p => p.IsActive && p.OrganizationId == franchiseeId).
                    Where(p => !eventPods.Contains(p.PodId)).
                    ToList();
            }
            return Mapper.MapMultiple(podDetailsEntities).ToList();
        }

        public List<Pod> GetPodsAssignedToSalesRepForEvent(long salesRepId)
        {
            List<Pod> podList = GetPodsAssignedToSalesRep(salesRepId);
            if (podList != null && podList.Count > 0)
            {
                return podList;
            }
            return GetAllPods();
        }

        public IEnumerable<Pod> GetPodsForEvent(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var pods =
                    linqMetaData.EventPod.Join(linqMetaData.PodDetails, ep => ep.PodId, pd => pd.PodId,
                                               (ep, pd) => new { ep.EventId, ep.IsActive, pd }).Where(@t => @t.EventId == eventId && @t.IsActive).
                        Select(@t => @t.pd).ToList();

                if (pods.IsEmpty())
                    return null;

                return Mapper.MapMultiple(pods);
            }
        }

        public IEnumerable<Pod> GetPodsForEvents(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var pods = (from ep in linqMetaData.EventPod
                         join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                         where eventIds.Contains(ep.EventId) && ep.IsActive
                         select p).ToArray();
                

                //var pods =
                //    linqMetaData.EventPod.Join(linqMetaData.PodDetails, ep => ep.PodId, pd => pd.PodId,
                //                               (ep, pd) => new { ep.EventId, pd }).Where(@t => eventIds.Contains(@t.EventId)).
                //        Select(@t => @t.pd).ToList();

                if (pods.IsEmpty())
                    return null;

                return Mapper.MapMultiple(pods);
            }
        }

        public List<Pod> GetUnallocatedPods()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var pods = linqMetaData.PodDetails.Where(pd => pd.OrganizationId == null && pd.IsActive).ToList();
                if (pods.IsEmpty())
                    return null;

                return Mapper.MapMultiple(pods).ToList();
            }
        }

        public bool AssignGivenPodstoaFranchisee(long[] podIds, long franchiseeId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var podEntity = new PodDetailsEntity { OrganizationId = null };
                IRelationPredicateBucket bucket = new RelationPredicateBucket(PodDetailsFields.OrganizationId == franchiseeId);
                myAdapter.UpdateEntitiesDirectly(podEntity, bucket);

                podEntity = new PodDetailsEntity { OrganizationId = franchiseeId };
                bucket = new RelationPredicateBucket();

                foreach (var podId in podIds)
                {
                    bucket.PredicateExpression.AddWithOr(PodDetailsFields.PodId == podId);
                }

                if (myAdapter.UpdateEntitiesDirectly(podEntity, bucket) == 0)
                {
                    throw new PersistenceFailureException();
                }

                return true;
            }
        }

        public List<Pod> GetPodsAvailableForEventByTerritoryId(long territoryId, DateTime eventDate)
        {
            List<PodDetailsEntity> podDetailsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventPods = linqMetaData.EventPod.
                    Join(linqMetaData.Events, ep => ep.EventId, e => e.EventId, (ep, e) => new { ep, e }).
                    Where(@t => @t.e.EventDate == eventDate && @t.ep.IsActive).
                    Select(@a => @a.ep.PodId).ToList();

                podDetailsEntities = (from pd in linqMetaData.PodDetails
                                      join pt in linqMetaData.PodTerritory on pd.PodId equals pt.PodId
                                      where !eventPods.Contains(pd.PodId) && pt.TerritoryId == territoryId
                                      select pd).ToList();
            }
            return Mapper.MapMultiple(podDetailsEntities).ToList();
        }

        public List<Pod> GetPodsAvailableForEventByTerritoryId(long territoryId)
        {
            List<PodDetailsEntity> podDetailsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                podDetailsEntities = (from pd in linqMetaData.PodDetails
                                      join pt in linqMetaData.PodTerritory on pd.PodId equals pt.PodId
                                      where pt.TerritoryId == territoryId
                                      select pd).ToList();
            }
            return Mapper.MapMultiple(podDetailsEntities).ToList();
        }

        public List<Pod> GetPodsAvailableForEvent(long franchiseeId)
        {
            List<PodDetailsEntity> podDetailsEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                podDetailsEntities = linqMetaData.PodDetails.
                    Where(p => p.IsActive && p.OrganizationId == franchiseeId).
                    ToList();
            }
            return Mapper.MapMultiple(podDetailsEntities).ToList();
        }

        public void SavePodTerritories(IEnumerable<long> territoryIds, long podId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<PodTerritoryEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(PodTerritoryFields.PodId == podId));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);

                if (territoryIds.IsNullOrEmpty()) return;

                collection = new EntityCollection<PodTerritoryEntity>();
                foreach (long territoryId in territoryIds)
                {
                    collection.Add(new PodTerritoryEntity(podId, territoryId));
                }
                
                adapter.SaveEntityCollection(collection);
            }
        }

        public List<OrderedPair<string, OrderedPair<string, string>>> GetPodBookedInformation(long podId, DateTime eventDate, long eventId=0)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from ep in linqMetaData.EventPod
                        join ev in linqMetaData.Events on ep.EventId equals ev.EventId
                        where ep.PodId == podId && ev.EventDate == eventDate && ep.IsActive && ev.EventId !=eventId
                        select
                            new OrderedPair<string, OrderedPair<string, string>>(ev.EventName,
                                                                                     new OrderedPair
                                                                                         <string, string>(
                                                                                         ev.TeamArrivalTime.Value.ToShortTimeString(),
                                                                                         ev.TeamDepartureTime.Value.ToShortTimeString()))).ToList();
            }


        }

        public long GetFirstImmediateEventPodId()
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var podId = (from e in linqMetaData.Events
                           join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                           where e.IsActive && e.EventDate > DateTime.Now.Date && ep.IsActive
                           select ep.PodId).FirstOrDefault();

                return podId;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetPodNamesforEventIds(IEnumerable<long> eventIds)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventPods = (from ep in linqMetaData.EventPod
                                 join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                 where eventIds.Contains(ep.EventId) && ep.IsActive
                                 select new {ep.EventId, p.Name}).ToArray();

                return (from ep in eventPods
                        group ep by ep.EventId
                        into grp
                        select
                            new OrderedPair<long, string>(grp.Key, string.Join(",", grp.Select(g => g.Name).ToArray())))
                    .ToArray();
            }
        }

    }
}