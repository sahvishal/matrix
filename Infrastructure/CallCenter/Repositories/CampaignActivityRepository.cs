using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallCenter.Repositories
{
    [DefaultImplementation]
    public class CampaignActivityRepository : PersistenceRepository, ICampaignActivityRepository
    {
        private IEnumerable<CampaignActivity> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CampaignActivityEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var campaignActivity = Mapper.Map<IEnumerable<CampaignActivityEntity>, IEnumerable<CampaignActivity>>(entities);

                return campaignActivity.OrderBy(x => x.Sequence).ToArray();
            }
        }

        public CampaignActivity GetById(long id)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignActivityFields.Id == id);

            return Get(relationPredicateBucket).SingleOrDefault();
        }

        public IEnumerable<CampaignActivity> GetByIds(long[] ids)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignActivityFields.Id == ids);

            return Get(relationPredicateBucket);
        }

        public IEnumerable<CampaignActivity> GetByCampaignId(long campaignId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignActivityFields.CampaignId == campaignId);

            return Get(relationPredicateBucket).ToArray();
        }

        public CampaignActivity Save(CampaignActivity domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CampaignActivity, CampaignActivityEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Call Upload ");

                return Mapper.Map<CampaignActivityEntity, CampaignActivity>(entity);
            }
        }

        public bool DeleteByCampaignActivityIds(long[] campaignActivities)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                adapter.DeleteEntitiesDirectly(typeof(CampaignActivityAssignmentEntity), new RelationPredicateBucket(CampaignActivityAssignmentFields.CampaignActivityId == campaignActivities));

                adapter.DeleteEntitiesDirectly(typeof(CampaignActivityEntity), new RelationPredicateBucket(CampaignActivityFields.Id == campaignActivities));
            }

            return true;
        }

        public IEnumerable<CampaignActivity> GetByCampaignIds(long[] campaignIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cga in linqMetaData.CampaignActivity
                                where campaignIds.Contains(cga.CampaignId)
                                select cga);

                return Mapper.Map<IEnumerable<CampaignActivityEntity>, IEnumerable<CampaignActivity>>(entities);
            }
        }

        public IEnumerable<CampaignActivity> GetActivitiesByDateTypeId(DateTime activityDate, long activityTypeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cga in linqMetaData.CampaignActivity
                                join campaign in linqMetaData.Campaign on cga.CampaignId equals campaign.Id
                                where campaign.IsPublished && cga.ActivityDate.Date == activityDate.Date && cga.TypeId == activityTypeId
                                select cga);

                return Mapper.Map<IEnumerable<CampaignActivityEntity>, IEnumerable<CampaignActivity>>(entities);
            }
        }

        public IEnumerable<DateTime> GetDirectMailActivityDates(long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var activityDates = (from cga in linqMetaData.CampaignActivity
                                     join campaign in linqMetaData.Campaign on cga.CampaignId equals campaign.Id
                                     where campaign.IsPublished && cga.TypeId == (long)CampaignActivityType.DirectMail && campaign.Id == campaignId
                                     orderby cga.ActivityDate descending
                                     select cga.ActivityDate).Distinct().ToList();

                return activityDates;
            }
        }

        public IEnumerable<CampaignActivity> GetDirectMailActivitiesByCampaignId(long campaignId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cga in linqMetaData.CampaignActivity
                                join campaign in linqMetaData.Campaign on cga.CampaignId equals campaign.Id
                                where campaign.IsPublished && cga.TypeId == (long)CampaignActivityType.DirectMail && campaign.Id == campaignId
                                orderby cga.ActivityDate
                                select cga).ToArray();

                return Mapper.Map<IEnumerable<CampaignActivityEntity>, IEnumerable<CampaignActivity>>(entities);
            }
        }

        public IEnumerable<CampaignActivity> GetDirectMailActivityByCampaignId(long campaignId)
        {
            var relationPredicateBucket = new RelationPredicateBucket(CampaignActivityFields.CampaignId == campaignId);
            relationPredicateBucket.PredicateExpression.AddWithAnd(CampaignActivityAssignmentFields.CampaignActivityId == (long)CampaignActivityType.DirectMail);

            return Get(relationPredicateBucket).ToArray();
        }

    }
}