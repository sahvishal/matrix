using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Insurance.Repositories
{
    [DefaultImplementation]
    public class CustomerBillingAccountRepository : PersistenceRepository, ICustomerBillingAccountRepository
    {
        public CustomerBillingAccount GetByCustomerIdBillingAccountId(long customerId, long billingAccountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cba in linqMetaData.CustomerBillingAccount
                              where cba.CustomerId == customerId && cba.BillingAccountId == billingAccountId
                              select cba).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<CustomerBillingAccountEntity, CustomerBillingAccount>(entity);
            }
        }

        public void Save(CustomerBillingAccount domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerBillingAccount, CustomerBillingAccountEntity>(domain);
                adapter.SaveEntity(entity, true, false);
            }
        }

        public IEnumerable<CustomerBillingAccount> GetAlreadySyncedCustomers(long[] customerIds, long billingAccountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cba in linqMetaData.CustomerBillingAccount
                                where customerIds.Contains(cba.CustomerId) && cba.BillingAccountId == billingAccountId
                                select cba);

                return Mapper.Map<IEnumerable<CustomerBillingAccountEntity>, IEnumerable<CustomerBillingAccount>>(entities);
            }
        }

        public IEnumerable<CustomerBillingAccount> GetCustomerBillingAccounts(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cba in linqMetaData.CustomerBillingAccount
                                where cba.CustomerId == customerId
                                select cba).ToArray();

                return Mapper.Map<IEnumerable<CustomerBillingAccountEntity>, IEnumerable<CustomerBillingAccount>>(entities);
            }
        }
    }
}
