using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CustomerPredictedZipRespository : PersistenceRepository, ICustomerPredictedZipRespository
    {
        public void Save(List<CustomerPredictedZip> customerPredictedZips)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CustomerPredictedZipEntity>();

                foreach (var item in customerPredictedZips)
                {
                    entities.Add(Mapper.Map<CustomerPredictedZip, CustomerPredictedZipEntity>(item));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public List<CustomerPredictedZip> GetByCustomerIdAndDate(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from cpz in linqMetaData.CustomerPredictedZip
                             where customerIds.Contains(cpz.CustomerId)
                             select cpz);
                if (fromDate != null)
                    query = (from q in query where q.DateCreated >= fromDate select q);

                if (toDate != null)
                    query = (from q in query where q.DateCreated <= toDate select q);

                return query.Select(x => new CustomerPredictedZip()
                {
                    CustomerId = x.CustomerId,
                    DateCreated = x.DateCreated,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    PredictedZip = x.PredictedZip
                }).ToList();
            }
        }

        public IEnumerable<CustomerPredictedZip> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from cpz in linqMetaData.CustomerPredictedZip
                             where cpz.CustomerId == customerId
                             select cpz).ToArray();

                return query.Select(x => new CustomerPredictedZip()
                {
                    CustomerId = x.CustomerId,
                    DateCreated = x.DateCreated,
                    Id = x.Id,
                    IsActive = x.IsActive,
                    PredictedZip = x.PredictedZip
                });
            }
        }
    }
}
