using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class ChaseProductRepository : PersistenceRepository, IChaseProductRepository
    {
        public ChaseProduct GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cp in linqMetaData.ChaseProduct where cp.ChaseProductId == id select cp).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseProductEntity, ChaseProduct>(entity);
            }
        }

        public IEnumerable<ChaseProduct> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cp in linqMetaData.ChaseProduct where ids.Contains(cp.ChaseProductId) select cp).ToArray();

                return Mapper.Map<IEnumerable<ChaseProductEntity>, IEnumerable<ChaseProduct>>(entities);
            }
        }

        public ChaseProduct Save(ChaseProduct domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<ChaseProduct, ChaseProductEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<ChaseProductEntity, ChaseProduct>(entity);
            }
        }

        public IEnumerable<CustomerChaseProduct> GetCustomerChaseProductsByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccp in linqMetaData.CustomerChaseProduct where ccp.CustomerId == customerId select ccp).ToArray();

                return Mapper.Map<IEnumerable<CustomerChaseProductEntity>, IEnumerable<CustomerChaseProduct>>(entities);
            }
        }

        public IEnumerable<CustomerChaseProduct> GetCustomerChaseProductsByProductId(long chaseProductId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccc in linqMetaData.CustomerChaseProduct where ccc.ChaseProductId == chaseProductId select ccc).ToArray();

                return Mapper.Map<IEnumerable<CustomerChaseProductEntity>, IEnumerable<CustomerChaseProduct>>(entities);
            }
        }

        public CustomerChaseProduct SaveCustomerChaseProduct(CustomerChaseProduct domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ccp in linqMetaData.CustomerChaseProduct where ccp.CustomerId == domain.CustomerId && ccp.ChaseProductId == domain.ChaseProductId select ccp).SingleOrDefault();
                entity = entity ?? Mapper.Map<CustomerChaseProduct, CustomerChaseProductEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CustomerChaseProductEntity, CustomerChaseProduct>(entity);
            }
        }

        public IEnumerable<CustomerChaseProduct> SaveCustomerChaseProducts(IEnumerable<CustomerChaseProduct> domains)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<CustomerChaseProductEntity>();

                foreach (var domain in domains)
                {
                    entities.Add(Mapper.Map<CustomerChaseProduct, CustomerChaseProductEntity>(domain));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<IEnumerable<CustomerChaseProductEntity>, IEnumerable<CustomerChaseProduct>>(entities);
            }
        }

        public ChaseProduct GetByNameAndLevel(string productName, int level)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cp in linqMetaData.ChaseProduct where cp.Name == productName && cp.ProductLevel == level select cp).SingleOrDefault();

                return entity == null ? null : Mapper.Map<ChaseProductEntity, ChaseProduct>(entity);
            }
        }

        public void DeleteByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ccp in linqMetaData.CustomerChaseProduct where ccp.CustomerId == customerId select ccp);

                foreach (var customerChaseProductEntity in entities)
                {
                    adapter.DeleteEntity(customerChaseProductEntity);
                }
            }
        }
    }
}
