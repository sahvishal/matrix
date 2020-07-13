using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CustomerIcdCodesRepository : PersistenceRepository, ICustomerIcdCodesRepository
    {
        public CustomerIcdCode GetCustomerIcdByCustomerIdCodeName(long customerId, string codeName)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entity = (from cicd in linqMetaData.CustomerIcdCode
                              join icdCode in linqMetaData.IcdCodes on cicd.IcdCodeId equals icdCode.Id
                              where icdCode.IcdCode == codeName && icdCode.IsActive && cicd.CustomerId == customerId
                              select cicd).FirstOrDefault();

                return Mapper.Map<CustomerIcdCodeEntity, CustomerIcdCode>(entity);
            }
        }

        public CustomerIcdCode Save(CustomerIcdCode customerIcdCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerIcdCode, CustomerIcdCodeEntity>(customerIcdCode);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();

                }

                return Mapper.Map<CustomerIcdCodeEntity, CustomerIcdCode>(entity);
            }
        }

        public void Save(IEnumerable<CustomerIcdCode> customerIcdCodes, long customerId)
        {
            DeactiveCustomerIcdCodes(customerId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<CustomerIcdCode>, IEnumerable<CustomerIcdCodeEntity>>(customerIcdCodes);

                var collection = new EntityCollection<CustomerIcdCodeEntity>();
                collection.AddRange(entities);

                adapter.SaveEntityCollection(collection);
            }
        }

        private void DeactiveCustomerIcdCodes(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var entity = new CustomerIcdCodeEntity()
                {
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var bucket = new RelationPredicateBucket(CustomerIcdCodeFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(CustomerIcdCodeFields.IsActive == true);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<CustomerIcdCode> GetIcdByCustomerId(long customerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from cicd in linqMetaData.CustomerIcdCode
                                join icdCode in linqMetaData.IcdCodes on cicd.IcdCodeId equals icdCode.Id
                                where icdCode.IsActive && cicd.IsActive && cicd.CustomerId == customerId 
                                select cicd);

                return Mapper.Map<IEnumerable<CustomerIcdCodeEntity>, IEnumerable<CustomerIcdCode>>(entities);
            }
        }

    }
}