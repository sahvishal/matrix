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
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CustomerTraleRepository : PersistenceRepository, ICustomerTraleRepository
    {
        public void Save(CustomerTrale domainObject)
        {
            var entity = Mapper.Map<CustomerTrale, CustomerTraleEntity>(domainObject);

            if (domainObject == null) return;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public CustomerTrale GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ct in linqMetaData.CustomerTrale
                              where ct.CustomerId == customerId
                              select ct).SingleOrDefault();

                return entity == null ? null : Mapper.Map<CustomerTraleEntity, CustomerTrale>(entity);
            }
        }
        public IEnumerable<CustomerTrale> GetByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ct in linqMetaData.CustomerTrale
                                where customerIds.Contains(ct.CustomerId)
                                select ct).ToArray();

                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<CustomerTraleEntity>, IEnumerable<CustomerTrale>>(entities);
            }
        }
    }
}
