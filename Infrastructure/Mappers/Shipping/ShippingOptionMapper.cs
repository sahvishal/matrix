using Falcon.App.Core.Application;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Shipping
{
    public class ShippingOptionMapper : DomainEntityMapper<ShippingOption, ShippingOptionEntity>
    {
        private readonly IMapper<Carrier, CarrierEntity> _mapper;

        public ShippingOptionMapper()
            : this(new CarrierMapper())
        { }

        public ShippingOptionMapper(IMapper<Carrier, CarrierEntity> mapper)
        {
            _mapper = mapper;
        }

        protected override void MapDomainFields(ShippingOptionEntity entity, 
            ShippingOption domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.ShippingOptionId;
            domainObjectToMapTo.Type = (ShippingType)entity.Type;
            domainObjectToMapTo.Carrier = entity.Carrier != null ? _mapper.Map(entity.Carrier) : null;
            domainObjectToMapTo.CostToCompany = entity.CostToCompany;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.Disclaimer = entity.Disclaimer;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Price = entity.Price;
        }

        protected override void MapEntityFields(ShippingOption domainObject, 
            ShippingOptionEntity entityToMapTo)
        {
            entityToMapTo.ShippingOptionId = domainObject.Id;
            entityToMapTo.ShippingOptionId = domainObject.Id;
            entityToMapTo.Type = (byte) domainObject.Type;
            entityToMapTo.CarrierId = domainObject.Carrier.Id;
            entityToMapTo.CostToCompany = domainObject.CostToCompany;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.Disclaimer = domainObject.Disclaimer;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Price = domainObject.Price;
        }
    }
}