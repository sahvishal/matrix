using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    [DefaultImplementation]
    public class CustomerPhoneNumberUpdateUploadLogRepository : PersistenceRepository, ICustomerPhoneNumberUpdateUploadLogRepository
    {
        public CustomerPhoneNumberUpdateUploadLog Save(CustomerPhoneNumberUpdateUploadLog domain)
        {
            using (var adapter=PersistenceLayer.GetDataAccessAdapter())
            {
                CustomerPhoneNumberUpdateUploadLogEntity entity = Mapper.Map<CustomerPhoneNumberUpdateUploadLog, CustomerPhoneNumberUpdateUploadLogEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                return Mapper.Map<CustomerPhoneNumberUpdateUploadLogEntity, CustomerPhoneNumberUpdateUploadLog>(entity);
            }
        }
    }
}