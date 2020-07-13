using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using Falcon.Data.EntityClasses;
using AutoMapper;
using Falcon.App.Core.Application.Exceptions;
using Falcon.Data.Linq;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class AccountCallCenterOrganizationRepository : PersistenceRepository, IAccountCallCenterOrganizationRepository
    {
        public IEnumerable<AccountCallCenterOrganization> GetByAccountId(long accountId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from acco in linqMetaData.AccountCallCenterOrganization
                                where acco.AccountId == accountId && acco.IsDeleted == false
                                select acco).ToArray();

                return Mapper.Map<IEnumerable<AccountCallCenterOrganizationEntity>, IEnumerable<AccountCallCenterOrganization>>(entities);
            }
        }

        public void Save(IEnumerable<AccountCallCenterOrganization> domainObjectList)
        {
            if (domainObjectList == null) return;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<AccountCallCenterOrganization>, IEnumerable<AccountCallCenterOrganizationEntity>>(domainObjectList);
                foreach (var entity in entities)
                {
                    if (!adapter.SaveEntity(entity))
                        throw new PersistenceFailureException();
                }
            }
        }

        public void MarkAsDeletedByAccountId(long accountId, long orgRoleUserId)
        {
            if (accountId <= 0) return;

            var relationPredicate = new RelationPredicateBucket(AccountCallCenterOrganizationFields.AccountId == accountId);
            relationPredicate.PredicateExpression.AddWithAnd(AccountCallCenterOrganizationFields.IsDeleted == false);
            MarkAsDeleted(relationPredicate, orgRoleUserId);
        }

        public void MarkAsDeletedByIds(IEnumerable<long> ids, long orgRoleUserId)
        {
            if (ids.IsNullOrEmpty()) return;

            var relationPredicate = new RelationPredicateBucket(AccountCallCenterOrganizationFields.Id == ids.ToArray());
            MarkAsDeleted(relationPredicate, orgRoleUserId);
        }

        private void MarkAsDeleted(RelationPredicateBucket relationPredicateBucket, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new AccountCallCenterOrganizationEntity { IsDeleted = true, ModifiedBy = orgRoleUserId, DateModified = DateTime.Now }, relationPredicateBucket);
            }
        }
    }
}
