using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CustomerOrderHistoryRepository : PersistenceRepository, ICustomerOrderHistoryRepository
    {
        public void Save(IEnumerable<CustomerOrderHistory> domainList)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityList = Mapper.Map<IEnumerable<CustomerOrderHistory>, IEnumerable<CustomerOrderHistoryEntity>>(domainList);

                foreach (var entity in entityList)
                {
                    if (!adapter.SaveEntity(entity))
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }
    }
}
