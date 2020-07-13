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
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{

    [DefaultImplementation]
    public class CampaignAssignmentRepository : PersistenceRepository, ICampaignAssignmentRepository
    {
        private IEnumerable<CampaignAssignment> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CampaignAssignmentEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var campaignAssignment = Mapper.Map<IEnumerable<CampaignAssignmentEntity>, IEnumerable<CampaignAssignment>>(entities);

                return campaignAssignment.ToArray();
            }
        }
        public IEnumerable<CampaignAssignment> GetByCampaignId(long campaignId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignAssignmentFields.CampaignId == campaignId);

            return Get(relationPredicateBucket);
        }

        public bool DeleteByCampaignId(long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CampaignAssignmentEntity), new RelationPredicateBucket(CampaignAssignmentFields.CampaignId == campaignId));

                return true;
            }
        }

        public void Save(long campaignId, IEnumerable<long> assignedtoIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeleteByCampaignId(campaignId);

                var entities = new EntityCollection<CampaignAssignmentEntity>();

                foreach (var assignedtoId in assignedtoIds)
                {
                    entities.Add(new CampaignAssignmentEntity(campaignId, assignedtoId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<CampaignAssignment> GetByCampaignIds(long[] campaignIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cg in linqMetaData.CampaignAssignment where campaignIds.Contains(cg.CampaignId) select cg);

                return AutoMapper.Mapper.Map<IEnumerable<CampaignAssignmentEntity>, IEnumerable<CampaignAssignment>>(entities);
            }
        }
    }
}