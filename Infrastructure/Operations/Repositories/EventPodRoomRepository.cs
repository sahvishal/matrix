using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class EventPodRoomRepository : PersistenceRepository, IEventPodRoomRepository
    {
        public EventPodRoom Save(EventPodRoom domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from epr in linqMetaData.EventPodRoom where epr.EventPodId == domain.EventPodId && epr.RoomNo == domain.RoomNo select epr).SingleOrDefault();
                if (entity != null)
                    domain.Id = entity.EventPodRoomId;

                entity = Mapper.Map<EventPodRoom, EventPodRoomEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<EventPodRoomEntity, EventPodRoom>(entity);
            }
        }

        public void SaveEventPodRoomTests(IEnumerable<long> testIds, long eventPodRoomId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<EventPodRoomTestEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(EventPodRoomTestFields.EventPodRoomId == eventPodRoomId));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);

                if (testIds.IsNullOrEmpty()) return;

                collection = new EntityCollection<EventPodRoomTestEntity>();
                foreach (long testId in testIds)
                {
                    collection.Add(new EventPodRoomTestEntity(eventPodRoomId, testId));

                }

                adapter.SaveEntityCollection(collection);
            }
        }

        public void DeleteEventPodRooms(IEnumerable<long> eventPodRoomIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var roomTestcollection = new EntityCollection<EventPodRoomTestEntity>();
                adapter.FetchEntityCollection(roomTestcollection, new RelationPredicateBucket(EventPodRoomTestFields.EventPodRoomId == eventPodRoomIds.ToArray()));

                if (roomTestcollection.Count > 0)
                    adapter.DeleteEntityCollection(roomTestcollection);

                var collection = new EntityCollection<EventPodRoomEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(EventPodRoomFields.EventPodRoomId == eventPodRoomIds.ToArray()));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);
            }
        }

        public IEnumerable<EventPodRoom> GetByEventIdAndPodIds(long eventId, IEnumerable<long> podIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ep in linqMetaData.EventPod
                                join epr in linqMetaData.EventPodRoom on ep.EventPodId equals epr.EventPodId
                                where ep.EventId == eventId && podIds.Contains(ep.PodId) && ep.IsActive
                                select epr).ToArray();
                return Mapper.Map<IEnumerable<EventPodRoomEntity>, IEnumerable<EventPodRoom>>(entities);
            }
        }

        public IEnumerable<EventPodRoom> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ep in linqMetaData.EventPod
                                join epr in linqMetaData.EventPodRoom on ep.EventPodId equals epr.EventPodId
                                where ep.EventId == eventId && ep.IsActive
                                select epr).ToArray();
                return Mapper.Map<IEnumerable<EventPodRoomEntity>, IEnumerable<EventPodRoom>>(entities);
            }
        }

        public IEnumerable<EventPodRoomTest> GetEventPodRoomTestsByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ep in linqMetaData.EventPod
                                join epr in linqMetaData.EventPodRoom on ep.EventPodId equals epr.EventPodId
                                join eprt in linqMetaData.EventPodRoomTest on epr.EventPodRoomId equals eprt.EventPodRoomId
                                where ep.EventId == eventId && ep.IsActive
                                select eprt).ToArray();

                return Mapper.Map<IEnumerable<EventPodRoomTestEntity>, IEnumerable<EventPodRoomTest>>(entities);
            }
        }

        public IEnumerable<EventPodRoomTest> GetEventPodRoomTestsForPackageTimeOnlyByEventId(long eventId, long podRoomId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ep in linqMetaData.EventPod
                                //join epr in linqMetaData.EventPodRoom on ep.EventPodId equals epr.EventPodId
                                join epr in linqMetaData.EventPodRoom on ep.EventPodId equals epr.EventPodId
                                join pr in linqMetaData.PodRoom on epr.RoomNo equals pr.RoomNo
                                where pr.PodRoomId == podRoomId
                                join eprt in linqMetaData.EventPodRoomTest on epr.EventPodRoomId equals eprt.EventPodRoomId
                                where ep.EventId == eventId && ep.IsActive
                                select eprt).ToArray();

                return Mapper.Map<IEnumerable<EventPodRoomTestEntity>, IEnumerable<EventPodRoomTest>>(entities);
            }
        }

        public IEnumerable<EventPodRoomTest> GetEventPodRoomTestsByEventRoomIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from epr in linqMetaData.EventPodRoom
                                join eprt in linqMetaData.EventPodRoomTest on epr.EventPodRoomId equals eprt.EventPodRoomId
                                where ids.Contains(epr.EventPodRoomId)
                                select eprt).ToArray();

                return Mapper.Map<IEnumerable<EventPodRoomTestEntity>, IEnumerable<EventPodRoomTest>>(entities);
            }
        }

        public IEnumerable<EventPodRoom> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from epr in linqMetaData.EventPodRoom
                                where ids.Contains(epr.EventPodRoomId)
                                select epr).ToArray();
                return Mapper.Map<IEnumerable<EventPodRoomEntity>, IEnumerable<EventPodRoom>>(entities);
            }
        }

        public IEnumerable<EventPodRoom> GetByEventPodIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from epr in linqMetaData.EventPodRoom
                                where ids.Contains(epr.EventPodId)
                                select epr).ToArray();
                return Mapper.Map<IEnumerable<EventPodRoomEntity>, IEnumerable<EventPodRoom>>(entities);
            }
        }
    }
}
