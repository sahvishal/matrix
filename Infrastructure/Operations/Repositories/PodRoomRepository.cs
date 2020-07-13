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
    public class PodRoomRepository : PersistenceRepository, IPodRoomRepository
    {
        public PodRoom Save(PodRoom domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PodRoom, PodRoomEntity>(domain);
                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<PodRoomEntity, PodRoom>(entity);
            }
        }

        public void SavePodRoomTests(IEnumerable<long> testIds, long podRoomId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<PodRoomTestEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(PodRoomTestFields.PodRoomId == podRoomId));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);

                if (testIds.IsNullOrEmpty()) return;

                collection = new EntityCollection<PodRoomTestEntity>();
                foreach (long testId in testIds)
                {
                    collection.Add(new PodRoomTestEntity(podRoomId, testId));
                }

                adapter.SaveEntityCollection(collection);
            }
        }

        public void DeletePodRooms(IEnumerable<long> podRoomIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var roomTestcollection = new EntityCollection<PodRoomTestEntity>();
                adapter.FetchEntityCollection(roomTestcollection, new RelationPredicateBucket(PodRoomTestFields.PodRoomId == podRoomIds.ToArray()));

                if (roomTestcollection.Count > 0)
                    adapter.DeleteEntityCollection(roomTestcollection);

                var collection = new EntityCollection<PodRoomEntity>();
                adapter.FetchEntityCollection(collection, new RelationPredicateBucket(PodRoomFields.PodRoomId == podRoomIds.ToArray()));

                if (collection.Count > 0)
                    adapter.DeleteEntityCollection(collection);
            }
        }

        public IEnumerable<PodRoom> GetByPodId(long podId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from pr in linqMetaData.PodRoom
                                where pr.PodId == podId
                                select pr).ToArray();
                return Mapper.Map<IEnumerable<PodRoomEntity>, IEnumerable<PodRoom>>(entities);
            }
        }

        public IEnumerable<PodRoomTest> GetPodRoomTestsByPodId(long podId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from prt in linqMetaData.PodRoomTest
                                join pr in linqMetaData.PodRoom on prt.PodRoomId equals pr.PodRoomId
                                where pr.PodId == podId
                                select prt).ToArray();

                return Mapper.Map<IEnumerable<PodRoomTestEntity>, IEnumerable<PodRoomTest>>(entities);
            }
        }
    }
}
