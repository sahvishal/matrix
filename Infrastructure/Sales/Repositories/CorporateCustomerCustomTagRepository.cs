using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CorporateCustomerCustomTagRepository : PersistenceRepository, ICorporateCustomerCustomTagRepository
    {
        public CorporateCustomerCustomTag GetById(long id)
        {
            try
            {
                return Get(new RelationPredicateBucket(CustomerTagFields.CustomerTagId == id)).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<CorporateCustomerCustomTag>(id);
            }
        }

        private IEnumerable<CorporateCustomerCustomTag> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CustomerTagEntity>();

                expressionBucket.PredicateExpression.AddWithAnd(CustomerTagFields.IsActive == true);

                adapter.FetchEntityCollection(entities, expressionBucket);

                var cutomerTags = Mapper.Map<IEnumerable<CustomerTagEntity>, IEnumerable<CorporateCustomerCustomTag>>(entities);

                return cutomerTags.ToArray().OrderBy(ct => ct.Tag);
            }
        }

        public CorporateCustomerCustomTag GetByCustomerAndTag(long customerId, string tag)
        {
            var expresion = new RelationPredicateBucket(CustomerTagFields.CustomerId == customerId);
            expresion.PredicateExpression.AddWithAnd(CustomerTagFields.Tag == tag);

            return Get(expresion).SingleOrDefault();
        }

        public CorporateCustomerCustomTag Save(CorporateCustomerCustomTag corporateTag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CorporateCustomerCustomTag, CustomerTagEntity>(corporateTag);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CustomerTagEntity, CorporateCustomerCustomTag>(entity);
            }
        }

        public IEnumerable<CorporateCustomerCustomTag> GetByCustomerIds(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var expresion = new RelationPredicateBucket(CustomerTagFields.CustomerId == customerIds.ToArray());
            if (fromDate.HasValue)
                expresion.PredicateExpression.AddWithAnd(CustomerTagFields.DateCreated >= fromDate);
            if (toDate.HasValue)
                expresion.PredicateExpression.AddWithAnd(CustomerTagFields.DateCreated <= toDate);

            return Get(expresion);
        }

        public IEnumerable<CorporateCustomerCustomTag> GetByCustomerId(long customerId)
        {
            var expresion = new RelationPredicateBucket(CustomerTagFields.CustomerId == customerId);

            return Get(expresion);
        }

        public static IQueryable<long> GetCustomersHavingSingleCustomTags(LinqMetaData linqMetaData)
        {
            return (from ccct in linqMetaData.CustomerTag
                    where ccct.IsActive
                    group ccct by ccct.CustomerId
                        into grp_ccct
                        where grp_ccct.Count() == 1
                        select grp_ccct.Key);
        }

        public void UpdateCorporateCustomerTag(IEnumerable<long> tagId, bool isActive, long orgId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerTagEntity() { IsActive = isActive, ModifiedByOrgRoleUserId = orgId, DateModified = DateTime.Now };
                var relationPredicateBucket = new RelationPredicateBucket(CustomerTagFields.CustomerTagId == tagId.ToArray());

                adapter.UpdateEntitiesDirectly(entity, relationPredicateBucket);
            }
        }

        public IEnumerable<OrderedPair<string, long>> GetCustomerCountByTag(IEnumerable<string> tags)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = linqMetaData.CustomerTag.Where(x => x.IsActive && tags.Contains(x.Tag))
                                    .GroupBy(c => c.Tag)
                                    .Select(g => new
                                    {
                                        name = g.Key,
                                        count = g.Count(),
                                    }).OrderBy(m => m.name);

                return query.Select(x => new OrderedPair<string, long>(x.name, x.count)).ToArray();
            }
        }
    }
}
