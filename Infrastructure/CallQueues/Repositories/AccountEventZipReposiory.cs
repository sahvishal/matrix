using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class AccountEventZipReposiory : PersistenceRepository, IAccountEventZipReposiory
    {
        public void Delete(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(AccountEventZipFields.AccountId == accountId);
                adapter.DeleteEntitiesDirectly(typeof(AccountEventZipEntity), relationPredicateBucket);
            }
        }

        public void Save(long accountId, IEnumerable<long> zipIds)
        {
            Delete(accountId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {


                var entities = new EntityCollection<AccountEventZipEntity>();
                foreach (var zipId in zipIds)
                {
                    entities.Add(new AccountEventZipEntity(accountId, zipId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void DeleteFromSubstitute(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(AccountEventZipSubstituteFields.AccountId == accountId);
                adapter.DeleteEntitiesDirectly(typeof(AccountEventZipSubstituteEntity), relationPredicateBucket);
            }
        }

        public void SaveSubstitute(long accountId, IEnumerable<long> zipIds)
        {
            DeleteFromSubstitute(accountId);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {


                var entities = new EntityCollection<AccountEventZipSubstituteEntity>();
                foreach (var zipId in zipIds)
                {
                    entities.Add(new AccountEventZipSubstituteEntity(accountId, zipId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }
    }
}