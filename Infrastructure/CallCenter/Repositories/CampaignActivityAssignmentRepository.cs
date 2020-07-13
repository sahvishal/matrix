using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{

    [DefaultImplementation]
    public class CampaignActivityAssignmentRepository : PersistenceRepository, ICampaignActivityAssignmentRepository
    {
        private IEnumerable<CampaignActivityAssignment> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CampaignActivityAssignmentEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var campaignAssignment = Mapper.Map<IEnumerable<CampaignActivityAssignmentEntity>, IEnumerable<CampaignActivityAssignment>>(entities);

                return campaignAssignment.ToArray();
            }
        }
        public IEnumerable<CampaignActivityAssignment> GetByCampaignActivityId(long campaignActivityId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignActivityAssignmentFields.CampaignActivityId == campaignActivityId);

            return Get(relationPredicateBucket);
        }

        public IEnumerable<CampaignActivityAssignment> GetByCampaignId(long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from caa in linqMetaData.CampaignActivityAssignment
                                join activity in linqMetaData.CampaignActivity on caa.CampaignActivityId equals activity.Id
                                where activity.CampaignId == campaignId
                                select caa);

                return Mapper.Map<IEnumerable<CampaignActivityAssignmentEntity>, IEnumerable<CampaignActivityAssignment>>(entities);
            }
        }

        public bool DeleteByCampaignId(long campaignActivityId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CampaignActivityAssignmentEntity), new RelationPredicateBucket(CampaignActivityAssignmentFields.CampaignActivityId == campaignActivityId));

                return true;
            }
        }

        public void Save(long campaignActivityId, IEnumerable<long> assignedtoIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeleteByCampaignId(campaignActivityId);

                var entities = new EntityCollection<CampaignActivityAssignmentEntity>();

                foreach (var assignedtoId in assignedtoIds)
                {
                    entities.Add(new CampaignActivityAssignmentEntity(campaignActivityId, assignedtoId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<CampaignActivityAssignment> GetByCampaignActivityIds(long[] campaignActivityIds)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignActivityAssignmentFields.CampaignActivityId == campaignActivityIds);

            return Get(relationPredicateBucket);
        }
    }
}