using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Extensions;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.Application.Exceptions;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class AccountCheckoutPhoneNumberRepository : PersistenceRepository, IAccountCheckoutPhoneNumberRepository
    {
        public IEnumerable<AccountCheckoutPhoneNumber> GetByAccountId(long accountId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from acpn in linqMetaData.AccountCheckoutPhoneNumber
                                where acpn.AccountId == accountId
                                select acpn).ToArray();

                return Mapper.Map<IEnumerable<AccountCheckoutPhoneNumberEntity>, IEnumerable<AccountCheckoutPhoneNumber>>(entities);
            }
        }

        private void DeleteByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(AccountCheckoutPhoneNumberEntity), new RelationPredicateBucket(AccountCheckoutPhoneNumberFields.AccountId == accountId));
            }
        }

        private void Save(AccountCheckoutPhoneNumber domainObject)
        {
            var entity = Mapper.Map<AccountCheckoutPhoneNumber, AccountCheckoutPhoneNumberEntity>(domainObject);

            if (domainObject == null) return;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public void Save(IEnumerable<AccountCheckoutPhoneNumber> accountCheckoutPhoneNumbers, long accountId)
        {
            DeleteByAccountId(accountId);

            if (accountCheckoutPhoneNumbers.IsNullOrEmpty()) return;

            foreach (var accountCheckoutPhoneNumber in accountCheckoutPhoneNumbers)
            {
                Save(accountCheckoutPhoneNumber);
            }
        }

        public IEnumerable<AccountCheckoutPhoneNumber> GetAccountCheckoutPhoneNumberByStateID(long accouontId, long stateId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from acpn in linqMetaData.AccountCheckoutPhoneNumber
                                where acpn.StateId == stateId && acpn.AccountId == accouontId
                                select acpn);

                if (entities == null)
                    return null;

                return Mapper.Map<IEnumerable<AccountCheckoutPhoneNumberEntity>, IEnumerable<AccountCheckoutPhoneNumber>>(entities);
            }
        }

        public IEnumerable<AccountCheckoutPhoneNumber> GetAccountCheckoutPhoneNumberByStateIDs(long accountId, IEnumerable<long> stateIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from acpn in linqMetaData.AccountCheckoutPhoneNumber
                                where stateIds.Contains(acpn.StateId) && acpn.AccountId == accountId
                                select acpn).ToList();

                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<AccountCheckoutPhoneNumberEntity>, IEnumerable<AccountCheckoutPhoneNumber>>(entities);
            }
        }
    }
}
