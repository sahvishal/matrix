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
    public class CustomerEligibilityRepository : PersistenceRepository, ICustomerEligibilityRepository
    {
        public CustomerEligibility GetByCustomerIdAndYear(long customerId, int year)
        {
            using (var adpater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adpater);
                var entity = (from ce in linqMetaData.CustomerEligibility
                              where ce.CustomerId == customerId && ce.ForYear == year
                              select ce).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<CustomerEligibilityEntity, CustomerEligibility>(entity);
            }
        }

        public void Save(CustomerEligibility customerEligibility)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerEligibility, CustomerEligibilityEntity>(customerEligibility);
                adapter.SaveEntity(entity);
            }
        }

        public IEnumerable<CustomerEligibility> GetCustomerEligibilityByCustomerIdsAndYear(IEnumerable<long> customerIds, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ce in linqMetaData.CustomerEligibility
                                where ce.ForYear == forYear && customerIds.Contains(ce.CustomerId)
                                select ce).ToArray();

                return Mapper.Map<IEnumerable<CustomerEligibilityEntity>, IEnumerable<CustomerEligibility>>(entities);
            }
        }

        public IEnumerable<CustomerEligibility> GetCustomerEligibilityByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ce in linqMetaData.CustomerEligibility
                                where customerIds.Contains(ce.CustomerId)
                                select ce).ToArray();

                return Mapper.Map<IEnumerable<CustomerEligibilityEntity>, IEnumerable<CustomerEligibility>>(entities);
            }
        }

        public IEnumerable<CustomerEligibility> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ce in linqMetaData.CustomerEligibility
                                where ce.CustomerId == customerId
                                select ce).ToArray();

                return Mapper.Map<IEnumerable<CustomerEligibilityEntity>, IEnumerable<CustomerEligibility>>(entities);
            }
        }
    }
}
