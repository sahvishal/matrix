using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Infrastructure.Repositories;
using System.Linq;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Marketing.Repositories
{
    [DefaultImplementation]
    public class CustomerResultPostedRepository : PersistenceRepository, ICustomerResultPostedRepository
    {
        public CustomerResultPosted GetByCustomerId(long customerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var entity = (from crp in linqMetaData.CustomerResultPosted where crp.CustomerId == customerId select crp).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<CustomerResultPostedEntity, CustomerResultPosted>(entity);
            }
        }

        public CustomerResultPosted Save(CustomerResultPosted customerResultPosted)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerResultPosted, CustomerResultPostedEntity>(customerResultPosted);
                myAdapter.SaveEntity(entity, true);

                return Mapper.Map<CustomerResultPostedEntity, CustomerResultPosted>(entity);
            }
        }
    }
}
