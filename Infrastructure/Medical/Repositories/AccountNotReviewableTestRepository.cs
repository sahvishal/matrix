using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class AccountNotReviewableTestRepository : PersistenceRepository, IAccountNotReviewableTestRepository
    {
        public void Save(AccountNotReviewableTest domainObject)
        {
            var entity = Mapper.Map<AccountNotReviewableTest, AccountNotReviewableTestEntity>(domainObject);

            if (domainObject == null) return;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public void DeleteByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(AccountNotReviewableTestEntity), new RelationPredicateBucket(AccountNotReviewableTestFields.AccountId == accountId));
            }
        }

        public void Save(IEnumerable<AccountNotReviewableTest> accountTests, long accountId)
        {
            DeleteByAccountId(accountId);

            if (accountTests.IsNullOrEmpty()) return;

            foreach (var corporateAccountTest in accountTests)
            {
                Save(corporateAccountTest);
            }
        }

        public IEnumerable<AccountNotReviewableTest> GetByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.AccountNotReviewableTest.Where(x => x.AccountId == accountId);

                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<AccountNotReviewableTestEntity>, IEnumerable<AccountNotReviewableTest>>(entities);
            }
        }
    }
}