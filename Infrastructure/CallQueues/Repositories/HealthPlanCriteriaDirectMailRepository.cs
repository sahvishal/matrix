using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class HealthPlanCriteriaDirectMailRepository : PersistenceRepository, IHealthPlanCriteriaDirectMailRepository
    {
        public IEnumerable<HealthPlanCriteriaDirectMail> GetByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from acqs in linqMetaData.HealthPlanCriteriaDirectMail
                                where acqs.CriteriaId == criteriaId
                                select acqs).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCriteriaDirectMailEntity>, IEnumerable<HealthPlanCriteriaDirectMail>>(entities);
            }
        }

        public IEnumerable<HealthPlanCriteriaDirectMail> GetByCampaignId(long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from acqs in linqMetaData.HealthPlanCriteriaDirectMail
                                join hpcqc in linqMetaData.HealthPlanCallQueueCriteria on acqs.CriteriaId equals hpcqc.Id
                                where hpcqc.CampaignId == campaignId
                                select acqs).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCriteriaDirectMailEntity>, IEnumerable<HealthPlanCriteriaDirectMail>>(entities);
            }
        }

        public bool Save(IEnumerable<long> activityIds, long criteriaId)
        {
            if (criteriaId > 0)
                DeleteByCriteriaId(criteriaId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entities = new EntityCollection<HealthPlanCriteriaDirectMailEntity>();

                foreach (var activityId in activityIds)
                {
                    entities.Add(new HealthPlanCriteriaDirectMailEntity(criteriaId, activityId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }

            return true;
        }

        private bool DeleteByCriteriaId(long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HealthPlanCriteriaDirectMailFields.CriteriaId == criteriaId);
                adapter.DeleteEntitiesDirectly(typeof(HealthPlanCriteriaDirectMailEntity), relationPredicateBucket);
            }
            return true;
        }

        public IEnumerable<HealthPlanCriteriaDirectMail> GetByCriteriaIds(long[] criteriaIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from acqs in linqMetaData.HealthPlanCriteriaDirectMail
                                where criteriaIds.Contains(acqs.CriteriaId)
                                select acqs).ToArray();

                return Mapper.Map<IEnumerable<HealthPlanCriteriaDirectMailEntity>, IEnumerable<HealthPlanCriteriaDirectMail>>(entities);
            }
        }
    }
}
