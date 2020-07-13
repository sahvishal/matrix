using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class CustomerAccountGlocomNumberRepository : PersistenceRepository, ICustomerAccountGlocomNumberRepository
    {
        public IEnumerable<CustomerAccountGlocomNumber> GetByCustomerId(long customerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from cagn in linqMetaData.CustomerAccountGlocomNumber
                                where cagn.CustomerId == customerId && cagn.IsActive
                                orderby cagn.CreatedDate
                                select cagn);
                return Mapper.Map<IEnumerable<CustomerAccountGlocomNumberEntity>, IEnumerable<CustomerAccountGlocomNumber>>(entities);
            }
        }

        public void Save(CustomerAccountGlocomNumber model, bool refatch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerAccountGlocomNumber, CustomerAccountGlocomNumberEntity>(model);
                adapter.SaveEntity(entity, refatch);
            }
        }

        public void Update(CustomerAccountGlocomNumber model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerAccountGlocomNumber, CustomerAccountGlocomNumberEntity>(model);
                if (entity.Id > 0)
                {
                    var bucket = new RelationPredicateBucket(CustomerAccountGlocomNumberFields.Id == entity.Id);
                    if (adapter.UpdateEntitiesDirectly(entity, bucket) == 0)
                        throw new PersistenceFailureException("Updation failed");
                }
            }
        }

        public CustomerAccountGlocomNumber GetByCustomerIdAndGlocomNumber(long customerId, string glocomNumbe)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entity = (from cagn in linqMetaData.CustomerAccountGlocomNumber
                              where cagn.CustomerId == customerId && cagn.GlocomNumber == glocomNumbe && cagn.IsActive
                              orderby cagn.CreatedDate
                              select cagn).FirstOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<CustomerAccountGlocomNumberEntity, CustomerAccountGlocomNumber>(entity);
            }
        }

        public IEnumerable<CustomerAccountGlocomNumber> GetByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from cagn in linqMetaData.CustomerAccountGlocomNumber
                                where customerIds.Contains(cagn.CustomerId) && cagn.IsActive
                                orderby cagn.CreatedDate
                                select cagn);
                return Mapper.Map<IEnumerable<CustomerAccountGlocomNumberEntity>, IEnumerable<CustomerAccountGlocomNumber>>(entities);
            }
        }
    }
}
