using Falcon.App.Core.Operations.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Shipping
{
    public class CarrierMapper : DomainEntityMapper<Carrier, CarrierEntity>
    {
        protected override void MapDomainFields(CarrierEntity carrierEntity, Carrier carrier)
        {
            carrier.Id = carrierEntity.CarrierId;
            carrier.Name = carrierEntity.Carrier;
        }

        protected override void MapEntityFields(Carrier carrier, CarrierEntity carrierEntity)
        {
            carrierEntity.CarrierId = carrier.Id;
            carrierEntity.Carrier = carrier.Name;
        }
    }
}