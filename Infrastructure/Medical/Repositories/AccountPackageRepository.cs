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
    public class AccountPackageRepository : PersistenceRepository, IAccountPackageRepository
    {
        public void Save(AccountPackage domainObject)
        {
            var entity = Mapper.Map<AccountPackage, AccountPackageEntity>(domainObject);

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
                adapter.DeleteEntitiesDirectly(typeof(AccountPackageEntity), new RelationPredicateBucket(AccountPackageFields.AccountId == accountId));
            }
        }

        public void Save(IEnumerable<AccountPackage> accountPackages, long accountId)
        {
            DeleteByAccountId(accountId);

            if (accountPackages.IsNullOrEmpty()) return;

            foreach (var corporateAccountPackage in accountPackages)
            {
                Save(corporateAccountPackage);
            }
        }

        public IEnumerable<AccountPackage> GetByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.AccountPackage.Where(x => x.AccountId == accountId);

                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<AccountPackageEntity>, IEnumerable<AccountPackage>>(entities);
            }
        }
    }
}
