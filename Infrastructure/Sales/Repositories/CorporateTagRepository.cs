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
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.Data.Linq;
using Falcon.App.Core.Application;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CorporateTagRepository : PersistenceRepository, ICorporateTagRepository
    {

        public CorporateTag GetById(long id)
        {
            try
            {
                var expresion = new RelationPredicateBucket(CorporateTagFields.CorporateTagId == id);
                expresion.PredicateExpression.AddWithAnd(CorporateTagFields.IsActive == true);

                return Get(expresion).Single();
            }
            catch (InvalidOperationException)
            {
                throw new ObjectNotFoundInPersistenceException<CorporateTag>(id);
            }
        }

        private IEnumerable<CorporateTag> Get(IRelationPredicateBucket expressionBucket)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CorporateTagEntity>();

                adapter.FetchEntityCollection(entities, expressionBucket);

                var corporateTags = Mapper.Map<IEnumerable<CorporateTagEntity>, IEnumerable<CorporateTag>>(entities);

                return corporateTags.ToArray();
            }
        }

        public IEnumerable<CorporateTag> GetByCorporateId(long corporateId, bool includeDisabled = true)
        {
            var expresion = new RelationPredicateBucket(CorporateTagFields.CorporateId == corporateId);
            expresion.PredicateExpression.AddWithAnd(CorporateTagFields.IsActive == true);

            if (!includeDisabled)
                expresion.PredicateExpression.AddWithAnd(CorporateTagFields.IsDisabled == false);

            return Get(expresion);
        }

        public CorporateTag Save(CorporateTag corporateTag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CorporateTag, CorporateTagEntity>(corporateTag);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();

                }

                return Mapper.Map<CorporateTagEntity, CorporateTag>(entity);
            }
        }

        public IEnumerable<CorporateTag> GetAll()
        {
            var expresion = new RelationPredicateBucket(CorporateTagFields.IsActive == true);

            return Get(expresion);
        }
        public IEnumerable<CorporateTag> GetByCorporateAcccountIds(IEnumerable<long> corpoateAccountId)
        {
            var expresion = new RelationPredicateBucket(CorporateTagFields.CorporateId == corpoateAccountId.ToArray());

            expresion.PredicateExpression.AddWithAnd(CorporateTagFields.IsActive == true);
            expresion.PredicateExpression.AddWithAnd(CorporateTagFields.IsDisabled == false);

            return Get(expresion);
        }

        public IEnumerable<CorporateTag> GetCorporateTagByFilter(CustomTagListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter = filter ?? new CustomTagListModelFilter();

                var query = (from ct in linqMetaData.CorporateTag where ct.IsActive select ct);

                if (!string.IsNullOrEmpty(filter.CustomTag))
                {
                    query = (from q in query where q.Tag == filter.CustomTag select q);
                }

                if (filter.CorporateId > 0)
                {
                    query = (from q in query where q.CorporateId == filter.CorporateId select q);
                }

                if (filter.DisabledTag)
                {
                    query = (from q in query where q.IsDisabled select q);
                }

                if (filter.EnabledTag)
                {
                    query = (from q in query where q.IsDisabled == false select q);
                }

                query = (from q in query orderby q.DateCreated descending select q);

                totalRecords = query.Count();

                var entities = query.TakePage(pageNumber, pageSize).ToList();

                return Mapper.Map<IEnumerable<CorporateTagEntity>, IEnumerable<CorporateTag>>(entities);
            }
        }

        public bool DeleteCustomTags(string customTag, long orgId, bool isActive)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var corporateTag = new CorporateTagEntity() { IsActive = isActive, ModifiedOn = DateTime.Now, ModifiedBy = orgId };
                var corporateRelationPredicateBucket = new RelationPredicateBucket(CorporateTagFields.Tag == customTag);

                adapter.UpdateEntitiesDirectly(corporateTag, corporateRelationPredicateBucket);

                var entity = new CustomerTagEntity() { IsActive = isActive, ModifiedByOrgRoleUserId = orgId, DateModified = DateTime.Now };
                var relationPredicateBucket = new RelationPredicateBucket(CustomerTagFields.Tag == customTag);

                adapter.UpdateEntitiesDirectly(entity, relationPredicateBucket);
            }

            return true;
        }

        public bool DisableCustomTag(long corporateTagId, bool isdisabled, long orgId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var corporateTag = new CorporateTagEntity() { IsDisabled = isdisabled, ModifiedOn = DateTime.Now, ModifiedBy = orgId };
                var corporateRelationPredicateBucket = new RelationPredicateBucket(CorporateTagFields.CorporateTagId == corporateTagId);

                adapter.UpdateEntitiesDirectly(corporateTag, corporateRelationPredicateBucket);
            }

            return true;
        }

        public IEnumerable<CorporateTag> GetAllForHealthPlans()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ct in linqMetaData.CorporateTag
                                join a in linqMetaData.Account on ct.CorporateId equals a.AccountId
                                where a.IsHealthPlan && ct.IsActive
                                select ct);

                return Mapper.Map<IEnumerable<CorporateTagEntity>, IEnumerable<CorporateTag>>(entities);
            }
        }

        public bool Update(CorporateTag corporateTag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var corporateTagEntity = new CorporateTagEntity(corporateTag.Id) { EndDate = corporateTag.EndDate, StartDate = corporateTag.StartDate };
                var bucket = new RelationPredicateBucket(CorporateTagFields.CorporateTagId == corporateTag.Id);
                return (adapter.UpdateEntitiesDirectly(corporateTagEntity, bucket) > 0);
            }
        }
        public bool CustomTagIsUnique(string tagName)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var corporateTag = (from ct in linqMetaData.CorporateTag
                                    where ct.Tag.ToLower().Trim() == tagName.ToLower().Trim()
                                    select ct).FirstOrDefault();

                if (corporateTag != null)
                    return false;
                else
                    return true;
            }
        }
        public void DisableCustomTagAfterExpiryDate()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var corporateTag = new CorporateTagEntity() { IsDisabled = true, ModifiedOn = DateTime.Now, ModifiedBy = 1 };

                var corporateRelationPredicateBucket = new RelationPredicateBucket(CorporateTagFields.EndDate <= DateTime.Today.AddDays(-1));

                myAdapter.UpdateEntitiesDirectly(corporateTag, corporateRelationPredicateBucket);
            }
        }

        public CorporateTag GetByTag(string corporateTag)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var entity = (from ct in linqMetaData.CorporateTag
                              where ct.Tag.ToLower().Trim() == corporateTag.ToLower().Trim()
                              select ct).FirstOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<CorporateTagEntity, CorporateTag>(entity);
            }
        }

        public IEnumerable<CorporateTag> CorporateTagForHealthplanResticted(long agentOrganizationId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var assignedAccountIds = (from acco in linqMetaData.AccountCallCenterOrganization
                                          where acco.OrganizationId == agentOrganizationId && acco.IsDeleted == false
                                          select acco.AccountId);

                var accountIds = (from a in linqMetaData.Account
                                  where (a.RestrictHealthPlanData == false || assignedAccountIds.Contains(a.AccountId))
                                  select a.AccountId);

                var entities = (from ct in linqMetaData.CorporateTag
                                where ct.IsActive
                                      && accountIds.Contains(ct.CorporateId)
                                select ct).ToArray();

                var corporateTags = Mapper.Map<IEnumerable<CorporateTagEntity>, IEnumerable<CorporateTag>>(entities);

                return corporateTags.ToArray();
            }
        }

        public IEnumerable<CorporateTag> GetByCustomTags(IEnumerable<string> corporateTag)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var entities = (from ct in linqMetaData.CorporateTag
                              where corporateTag.Contains(ct.Tag.ToLower().Trim())
                              select ct).ToArray();

                var corporateTags = Mapper.Map<IEnumerable<CorporateTagEntity>, IEnumerable<CorporateTag>>(entities);

                return corporateTags.ToArray(); 
            }
        }
    }
}
