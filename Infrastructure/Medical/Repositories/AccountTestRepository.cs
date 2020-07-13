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
    public class AccountTestRepository : PersistenceRepository, IAccountTestRepository
    {
        public void Save(AccountTest domainObject)
        {
            var entity = Mapper.Map<AccountTest, AccountTestEntity>(domainObject);

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
                adapter.DeleteEntitiesDirectly(typeof(AccountTestEntity), new RelationPredicateBucket(AccountTestFields.AccountId == accountId));
            }
        }

        public void Save(IEnumerable<AccountTest> accountTests, long accountId)
        {
            DeleteByAccountId(accountId);

            if (accountTests.IsNullOrEmpty()) return;

            foreach (var corporateAccountTest in accountTests)
            {
                Save(corporateAccountTest);
            }
        }

        public IEnumerable<AccountTest> GetByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.AccountTest.Where(x => x.AccountId == accountId);

                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<AccountTestEntity>, IEnumerable<AccountTest>>(entities);
            }
        }
    }
}
