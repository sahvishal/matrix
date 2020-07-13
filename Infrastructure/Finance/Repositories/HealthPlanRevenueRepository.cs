using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Linq;
using System.Linq;
using AutoMapper;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;
using System;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    [DefaultImplementation]
    public class HealthPlanRevenueRepository : PersistenceRepository, IHealthPlanRevenueRepository
    {
        public HealthPlanRevenue GetHealthPlanRevenueId(long healthPlanId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from hpr in linqMetaData.HealthPlanRevenue
                                where hpr.AccountId == healthPlanId && !hpr.DateTo.HasValue
                                orderby hpr.CreatedDate descending
                                select hpr).FirstOrDefault();
                return Mapper.Map<HealthPlanRevenueEntity, HealthPlanRevenue>(entities);
            }
        }

        public IEnumerable<HealthPlanRevenue> GetHealthPlanRevenuesId(long healthPlanId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from hpr in linqMetaData.HealthPlanRevenue
                                where hpr.AccountId == healthPlanId
                                orderby hpr.CreatedDate descending
                                select hpr);

                return Mapper.Map<IEnumerable<HealthPlanRevenueEntity>, IEnumerable<HealthPlanRevenue>>(entities);
            }
        }

        public HealthPlanRevenue Save(HealthPlanRevenue domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<HealthPlanRevenue, HealthPlanRevenueEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save revenue");

                return Mapper.Map<HealthPlanRevenueEntity, HealthPlanRevenue>(entity);
            }

        }

        public IEnumerable<HealthPlanRevenue> GetByHealthPlanIds(IEnumerable<long> healthPlanIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from hpr in linqMetaData.HealthPlanRevenue where healthPlanIds.Contains(hpr.AccountId) select hpr);

                return Mapper.Map<IEnumerable<HealthPlanRevenueEntity>, IEnumerable<HealthPlanRevenue>>(query);
            }
        }

        public bool UpdatePreviousHealthPlanRevenue(DateTime dateTo, long healthPlanRevenueId)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var healthPlanRevenueEntity = new HealthPlanRevenueEntity(healthPlanRevenueId) { DateTo = dateTo };
                var bucket = new RelationPredicateBucket(HealthPlanRevenueFields.Id == healthPlanRevenueId);
                return (myAdapter.UpdateEntitiesDirectly(healthPlanRevenueEntity, bucket) > 0);
            }
        }

        public IEnumerable<HealthPlanRevenue> GetListByHealthPlanId(long healthPlanId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from hpr in linqMetaData.HealthPlanRevenue
                                where hpr.AccountId == healthPlanId
                                orderby hpr.CreatedDate descending
                                select hpr).ToArray();
                return Mapper.Map<IEnumerable<HealthPlanRevenueEntity>, IEnumerable<HealthPlanRevenue>>(entities);
            }
        }

        public HealthPlanRevenue GetHealthPlanRevenueForEventListing(long healthPlanId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from hpr in linqMetaData.HealthPlanRevenue
                                where hpr.AccountId == healthPlanId orderby hpr.DateFrom
                                select hpr).FirstOrDefault();
                if (entities == null)
                    return null;

                return Mapper.Map<HealthPlanRevenueEntity, HealthPlanRevenue>(entities);
            }
        }

        public bool DeleteRevenue(long revenueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(HealthPlanRevenueItemFields.HealthPlanRevenueId == revenueId);

                adapter.DeleteEntitiesDirectly(typeof(HealthPlanRevenueItemEntity), bucket);

                bucket = new RelationPredicateBucket(HealthPlanRevenueFields.Id == revenueId);

                return (adapter.DeleteEntitiesDirectly(typeof(HealthPlanRevenueEntity), bucket) > 0) ? true : false;
            }
        }
    }
}
