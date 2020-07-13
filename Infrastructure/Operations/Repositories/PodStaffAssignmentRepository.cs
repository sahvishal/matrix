using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class PodStaffAssignmentRepository : UniqueItemRepository<PodStaff, PodDefaultTeamEntity>, IPodStaffAssignmentRepository
    {
        public PodStaffAssignmentRepository(IMapper<PodStaff, PodDefaultTeamEntity> mapper)
            : base(mapper)
        {

        }

        protected override EntityField2 EntityIdField
        {
            get { return PodDefaultTeamFields.PodTeamId; }
        }

        public IEnumerable<PodStaff> SaveMultiple(IEnumerable<PodStaff> podStaff, long podId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var collection = new EntityCollection<PodDefaultTeamEntity>();

                var staffIds = podStaff.Where(ps => ps.Id > 0).Select(ps => ps.Id).ToArray();

                var bucket = new RelationPredicateBucket(PodDefaultTeamFields.PodId == podId);
                bucket.PredicateExpression.AddWithAnd(PodDefaultTeamFields.PodTeamId != staffIds);

                adapter.FetchEntityCollection(collection, bucket);
                if (collection.Count > 0)
                {
                    adapter.DeleteEntityCollection(collection);
                }

                if (!podStaff.IsNullOrEmpty())
                {
                    EntityCollection<PodDefaultTeamEntity> entities = new EntityCollection<PodDefaultTeamEntity>();
                    entities.AddRange(Mapper.MapMultiple(podStaff));

                    if (adapter.SaveEntityCollection(entities, true, false) == 0)
                        throw new PersistenceFailureException();

                    return Mapper.MapMultiple(entities);
                }
            }
            return podStaff;
        }

        public IEnumerable<PodStaff> GetPodSatff(long podId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeta = new LinqMetaData(adapter);
                var podStaffEntities = linqMeta.PodDefaultTeam.Where(x => x.IsActive && x.PodId == podId);
                return Mapper.MapMultiple(podStaffEntities);
            }
        }

        public IEnumerable<PodStaff> GetPodStaffforMultiplePods(IEnumerable<long> podIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeta = new LinqMetaData(adapter);
                var podStaffEntities = linqMeta.PodDefaultTeam.Where(x => podIds.Contains(x.PodId) && x.IsActive);
                return Mapper.MapMultiple(podStaffEntities);
            }

        }
    }
}