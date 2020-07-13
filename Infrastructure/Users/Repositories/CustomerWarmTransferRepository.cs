using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class CustomerWarmTransferRepository : PersistenceRepository, ICustomerWarmTransferRepository
    {
        public CustomerWarmTransfer GetByCustomerIdAndYear(long customerId, int year)
        {
            using (var adpater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adpater);
                var entity = (from cwt in linqMetaData.CustomerWarmTransfer
                              where cwt.CustomerId == customerId && cwt.WarmTransferYear == year
                              select cwt).SingleOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<CustomerWarmTransferEntity, CustomerWarmTransfer>(entity);
            }
        }

        public void Save(CustomerWarmTransfer customerWarmTransfer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerWarmTransfer, CustomerWarmTransferEntity>(customerWarmTransfer);
                adapter.SaveEntity(entity);
            }
        }

        public IEnumerable<CustomerWarmTransfer> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cwt in linqMetaData.CustomerWarmTransfer
                                where cwt.CustomerId == customerId
                                select cwt).ToArray();

                return Mapper.Map<IEnumerable<CustomerWarmTransferEntity>, IEnumerable<CustomerWarmTransfer>>(entities);
            }
        }
    }
}
