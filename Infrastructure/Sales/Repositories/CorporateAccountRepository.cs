using System;
using System.Collections.Generic;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    public class CorporateAccountRepository : UniqueItemRepository<CorporateAccount, AccountEntity>, ICorporateAccountRepository
    {
        public CorporateAccountRepository(IMapper<CorporateAccount, AccountEntity> mapper)
            : base(mapper)
        {
        }

        public CorporateAccountRepository(IPersistenceLayer persistenceLayer, IMapper<CorporateAccount, AccountEntity> mapper, RepositoryStrategySet<CorporateAccount> strategySet)
            : base(persistenceLayer, mapper, strategySet)
        {
        }

        protected override EntityField2 EntityIdField
        {
            get { return AccountFields.AccountId; }
        }

        private void SaveDefaultPackages(long accountId, IEnumerable<long> packageIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(AccountPackageEntity),
                                               new RelationPredicateBucket(AccountPackageFields.AccountId == accountId));
                if (packageIds.IsNullOrEmpty()) return;

                var entities = new EntityCollection<AccountPackageEntity>();
                foreach (long packageId in packageIds)
                {
                    entities.Add(new AccountPackageEntity(accountId, packageId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public new CorporateAccount Save(CorporateAccount domainObject)
        {
            using (var transactionScope = new TransactionScope())
            {
                if (domainObject == null)
                {
                    throw new ArgumentNullException("domainObject",
                        "The given object to persist cannot be null.");
                }

                AccountEntity entity = _mapper.Map(domainObject);

                try
                {
                    GetById(domainObject.Id);
                }
                catch (ObjectNotFoundInPersistenceException<CorporateAccount>)
                {
                    entity.IsNew = true;
                }   
                
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }

                var newDomainObject = _mapper.Map(entity);
              
                transactionScope.Complete();
                return newDomainObject;
            }
        }

        public CorporateAccount SaveAccount(CorporateAccount corporateAccount,  IEnumerable<long> packageIds)
        {
            var corporateaccount = Save(corporateAccount);
            SaveDefaultPackages(corporateaccount.Id, packageIds);
            return corporateaccount;
        }





    }
}