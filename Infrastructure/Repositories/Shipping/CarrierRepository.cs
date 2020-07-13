using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Shipping;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Shipping
{
    public class CarrierRepository : UniqueItemRepository<Carrier, CarrierEntity>, ICarrierRepository
    {
        public CarrierRepository() : base(new CarrierMapper())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return CarrierFields.CarrierId; }
        }
    }
}
