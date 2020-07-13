using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class CustomerTargetedRepository : PersistenceRepository, ICustomerTargetedRepository
    {
        public CustomerTargeted GetByCustomerIdAndYear(long customerId, int year)
        {
            using (var adpater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adpater);
                var entity = (from ce in linqMetaData.CustomerTargeted
                              where ce.CustomerId == customerId && ce.ForYear == year
                              select ce).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<CustomerTargetedEntity, CustomerTargeted>(entity);
            }
        }

        public void Save(CustomerTargeted customerTargeted)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerTargeted, CustomerTargetedEntity>(customerTargeted);
                adapter.SaveEntity(entity);
            }
        }

        public IEnumerable<CustomerTargeted> GetCustomerTargetedByCustomerIdsAndYear(IEnumerable<long> customerIds, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ce in linqMetaData.CustomerTargeted
                                where ce.ForYear == forYear && customerIds.Contains(ce.CustomerId)
                                select ce).ToArray();

                return Mapper.Map<IEnumerable<CustomerTargetedEntity>, IEnumerable<CustomerTargeted>>(entities);
            }
        }

        public IEnumerable<CustomerTargeted> GetCustomerTargetedByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ce in linqMetaData.CustomerTargeted
                                where ce.CustomerId == customerId
                                select ce).ToArray();

                return Mapper.Map<IEnumerable<CustomerTargetedEntity>, IEnumerable<CustomerTargeted>>(entities);
            }
        }
    }
}
